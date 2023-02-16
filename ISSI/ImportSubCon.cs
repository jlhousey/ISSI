using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSI.sbi_installdbDataSetTableAdapters;
using System.Data;
using System.Windows.Forms;

namespace ISSI
{

    class ImportSubCon



    {
        private XlFileHandler xlFileHandler;
        private DataMapping dm;
        private DataMapping dm2;
        private DataTable importItems;
        private sbi_installdbDataSet sbi_installdbDataSet;
        private ReqSubConTableAdapter reqSubConTableAdapter;
        private SubConAreasTableAdapter subConAreasTableAdapter;
        private InstallScheduleTableAdapter installScheduleTableAdapter;
        private string xlCols;
        private string sqlCols;
        
        private string filename;
        private string destpath;
        private int[] rowArray;
        private int subconID;



        public ImportSubCon(int subconid)
        {
            sbi_installdbDataSet = new sbi_installdbDataSet();
            subconID = subconid;
            subConAreasTableAdapter = new SubConAreasTableAdapter();
            subConAreasTableAdapter.Fill(sbi_installdbDataSet.SubConAreas);
            DataRow subconrow = sbi_installdbDataSet.SubConAreas.FindBySubConAreaID(subconID);
            try
            {
                xlCols = Convert.ToString(subconrow["ColumnsToImport"]);
                    
                sqlCols = "InstallID,Notes,CMRAG";
                
                string rows = Convert.ToString(subconrow["RowsToImport"]);
                filename = Convert.ToString(subconrow["SchedulePath"]);
                destpath = Properties.Settings.Default.TempFileDirectory;
                rowArray = rows.Split(',').Select(s => Int32.Parse(s)).ToArray();

            }
            catch
            {
                MessageBox.Show("Import settings incorrect, edit SubConAreasTable in SSMS.");
            }




        }

        public void GetImportTable()
        {
            string destfile = "ImportedSubCon"+ subconID + Session.UserName() + ".xlsx";

            xlFileHandler = new XlFileHandler("", destfile, filename, destpath);
            xlFileHandler.FileCopy(false);
            dm = new DataMapping(xlCols, sqlCols, sbi_installdbDataSet.ReqSubCon);



            dm.RowSelect(new int[] { 2, 2000}, true);
            string ofileName = xlFileHandler.OutputFile();
            importItems = dm.OutputTable(ofileName, 3);
            dm2 = new DataMapping(xlCols, sqlCols, sbi_installdbDataSet.ReqSubCon);
            dm2.RowSelect(rowArray, true);
            
            importItems.Merge(dm2.OutputTable(ofileName, 1));
        }


        public void UpdateSubConList()
        {
            reqSubConTableAdapter = new ReqSubConTableAdapter();
            reqSubConTableAdapter.Fill(sbi_installdbDataSet.ReqSubCon);
            
            List<string> newInstallIDs = new List<String>();
            foreach (DataRow r in importItems.Rows)
            {

                if (ValidateSOPNumber(r))
                {
                    //remove asterisk characters used to mark if a job is a revist.

                    string val = r["InstallID"].ToString().Replace("*", "");

                    int val3 = Convert.ToInt32(val);
                    
                    DataTable dt = reqSubConTableAdapter.GetDataByInstallIDSubConID(val3, subconID);
                    

                    if (dt.Rows.Count == 0)
                    {
                       
                        DataRow newRow = sbi_installdbDataSet.ReqSubCon.NewRow();
                        newRow["InstallID"] = val3;
                        newRow["SubConAreaID"] = subconID;
                        for (int i = 0; i < importItems.Columns.Count; i++)
                        {
                            string clm = importItems.Columns[i].ColumnName;
                            if (sbi_installdbDataSet.ReqSubCon.Columns.Contains(clm) && clm != "InstallID")
                            {
                                newRow[clm] = r[i];
                            }
                        }
                        sbi_installdbDataSet.ReqSubCon.Rows.Add(newRow);

                    }
                    else
                    {
                        DataRow s = sbi_installdbDataSet.ReqSubCon.FindByReqSCID(Convert.ToInt32(dt.Rows[0]["ReqSCID"]));
                        if (s.RowState != DataRowState.Modified)
                        {
                            for (int i = 0; i < importItems.Columns.Count; i++)
                            {
                                string clm = importItems.Columns[i].ColumnName;
                                if (sbi_installdbDataSet.ReqSubCon.Columns.Contains(clm) && clm != "InstallID")
                                {
                                    s[clm] = r[i];
                                }
                            }
                        }


                    }
                }

            }
            UpdateDatabase();

        }

        private bool ValidateSOPNumber(DataRow r)
        {
            if (r["InstallID"] == DBNull.Value)
            {
                return false;
            }
            else
            {
               
                string val = r["InstallID"].ToString();
                
                try
                {
                    int iid = Convert.ToInt32(val);
                    installScheduleTableAdapter = new InstallScheduleTableAdapter();
                    installScheduleTableAdapter.Fill(sbi_installdbDataSet.InstallSchedule);
                    if (sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid) != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                catch
                {
                    string errorRow = (rowArray[0] + importItems.Rows.IndexOf(r)).ToString();
                    MessageBox.Show("Invalid entry on row " + errorRow + " of Sub Contractor Schedule. \n The InstallID " + val + " could not be read");
                    return false;
                }
            }
        }

        private void UpdateDatabase()
        {
            try
            {
                installScheduleTableAdapter.Fill(sbi_installdbDataSet.InstallSchedule);
                this.reqSubConTableAdapter.Update(this.sbi_installdbDataSet.ReqSubCon);
                MessageBox.Show("Update successful");
            }
            catch (DBConcurrencyException dbcx)
            {
                DialogResult response = MessageBox.Show(CreateMessage((sbi_installdbDataSet.ReqSubConRow)
                    (dbcx.Row)), "Concurrency Exception", MessageBoxButtons.YesNo);

                ProcessDialogResult(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error was thrown while attempting to update the database." + ex.Message);
            }
        }
        private string CreateMessage(sbi_installdbDataSet.ReqSubConRow cr)
        {
            return
                "Someone had made  change while you were updating the Install Schedule \n" +
                "Database: " + GetRowData(GetCurrentRowInDB(cr), DataRowVersion.Default) + "\n" +
                "Original: " + GetRowData(cr, DataRowVersion.Original) + "\n" +
                "Proposed: " + GetRowData(cr, DataRowVersion.Current) + "\n" +
                "Do you still want to update the database with the proposed value?";
        }
        //-------------------------------------------------------------------------- 
        // This method loads a temporary table with current records from the database 
        // and returns the current values from the row that caused the exception. 
        //-------------------------------------------------------------------------- 
        private sbi_installdbDataSet.ReqSubConDataTable tempReqSubConDataTable =
            new sbi_installdbDataSet.ReqSubConDataTable();

        private sbi_installdbDataSet.ReqSubConRow GetCurrentRowInDB(sbi_installdbDataSet.ReqSubConRow RowWithError)
        {
            this.reqSubConTableAdapter.Fill(tempReqSubConDataTable);

            sbi_installdbDataSet.ReqSubConRow currentRowInDb =
                tempReqSubConDataTable.FindByReqSCID(RowWithError.ReqSCID);

            return currentRowInDb;
        }


        //-------------------------------------------------------------------------- 
        // This method takes a Row and RowVersion  
        // and returns a string of column values to display to the user. 
        //-------------------------------------------------------------------------- 
        private string GetRowData(sbi_installdbDataSet.ReqSubConRow depRow, DataRowVersion RowVersion)
        {
            string rowData = "";

            for (int i = 0; i < depRow.ItemArray.Length; i++)
            {
                rowData = rowData + depRow[i, RowVersion].ToString() + " ";
            }
            return rowData;
        }


        // This method takes the DialogResult selected by the user and updates the database  
        // with the new values or cancels the update and resets the Customers table  
        // (in the dataset) with the values currently in the database. 

        private void ProcessDialogResult(DialogResult response)
        {
            switch (response)
            {
                case DialogResult.Yes:
                    sbi_installdbDataSet.Merge(tempReqSubConDataTable, true, MissingSchemaAction.Ignore);
                    UpdateDatabase();
                    break;

                case DialogResult.No:
                    sbi_installdbDataSet.Merge(tempReqSubConDataTable);
                    MessageBox.Show("Update cancelled");
                    break;
            }
        }

        public void Dispose()
        {
            if (sbi_installdbDataSet != null)
            {
                sbi_installdbDataSet.Dispose();
                sbi_installdbDataSet = null;


            }
            if (reqSubConTableAdapter != null)
            {
                reqSubConTableAdapter.Dispose();
                reqSubConTableAdapter = null;
            }
            if (subConAreasTableAdapter != null)
            {
                subConAreasTableAdapter.Dispose();
                subConAreasTableAdapter = null;
            }
            if (installScheduleTableAdapter != null)
            {
                installScheduleTableAdapter.Dispose();
                installScheduleTableAdapter = null;
            }

            if (tempReqSubConDataTable != null)
            {
                tempReqSubConDataTable.Dispose();
                tempReqSubConDataTable = null;
            }
        }
    }
}
