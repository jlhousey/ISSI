using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSI.sbi_installdbDataSetTableAdapters;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;


namespace ISSI
{
    class ImportPurchasing : IDisposable

    {
        private XlFileHandler xlFileHandler;
        private DataMapping dm;
        private DataTable importItems;
        private sbi_installdbDataSet sbi_installdbDataSet;
        private SMSLinesTableAdapter sMSLinesTableAdapter;
        private PurchasingAreasTableAdapter purchasingAreasTableAdapter;
        private InstallScheduleTableAdapter installScheduleTableAdapter;
        private string xlCols;
        private string sqlCols;
        //private string sheets;
        private string[] sheetarray;
        private string filename;
        private string destpath;
        private int[] rowArray;
        private int purchasingID;
        //private List<DataTable> tabtables;
        private string filter;
        private string areaname;


        public ImportPurchasing(int purchasingid)
        {
            sbi_installdbDataSet = new sbi_installdbDataSet();
            purchasingID = purchasingid;
            purchasingAreasTableAdapter = new PurchasingAreasTableAdapter();
            purchasingAreasTableAdapter.Fill(sbi_installdbDataSet.PurchasingAreas);
            DataRow purchasingrow = sbi_installdbDataSet.PurchasingAreas.FindByPurchasingID(purchasingID);
            try
            {
                xlCols = Convert.ToString(purchasingrow["ColumnsToImport"]);

                sqlCols = "InstallID,Product,Status,ShipDate,ShipRef,DelDate,POD";

                string rows = Convert.ToString(purchasingrow["RowsToImport"]);
                string sheets = Convert.ToString(purchasingrow["TabNames"]);
                filter = Convert.ToString(purchasingrow["Filter"]);
                areaname = Convert.ToString(purchasingrow["Name"]);
                filename = Convert.ToString(purchasingrow["SMSPath"]);
                destpath = Properties.Settings.Default.TempFileDirectory;
                rowArray = rows.Split(',').Select(s => Int32.Parse(s)).ToArray();
                sheetarray = sheets.Split(',').ToArray();
            }
            catch
            {
                MessageBox.Show("Import settings incorrect, edit PurchasingAreasTable in SSMS.");
            }
        }

        public DataTable GetImportTable()
        {
            string destfile = "ImportedPurchasing" + purchasingID + Session.UserName() + ".xlsx";

            xlFileHandler = new XlFileHandler("", destfile, filename, destpath);
            xlFileHandler.FileCopy(false);
            DataTable sqlTable = new DataTable();
            string[] sqltblcols = sqlCols.Split(',').ToArray();
            foreach (string x in sqltblcols)
            {
                sqlTable.Columns.Add(x);

            }
            sqlTable.Columns["InstallID"].DataType = typeof(Int32);
            
            sqlTable.Columns["Product"].DataType = typeof(string);
            sqlTable.Columns["Product"].MaxLength = 50;
            sqlTable.Columns["Status"].DataType = typeof(string);
            sqlTable.Columns["Status"].MaxLength = 50;
            sqlTable.Columns["ShipDate"].DataType = typeof(DateTime);
            
            sqlTable.Columns["ShipRef"].DataType = typeof(string);
            sqlTable.Columns["ShipRef"].MaxLength = 255;
            sqlTable.Columns["DelDate"].DataType = typeof(DateTime);
            
            sqlTable.Columns["POD"].DataType = typeof(string);
            sqlTable.Columns["POD"].MaxLength = 50;

            
            DataTable sql2 = sqlTable.Clone();
            sqlTable.Columns.Add("TabName");
            sqlTable.Columns.Add("PurchasingID");


            

            string ofileName = xlFileHandler.OutputFile();
            List<string> importsheets = xlFileHandler.OutputSheets();
            foreach(string s in sheetarray)
            {
                int i = importsheets.IndexOf(s);
                if (i != -1)
                {
                    dm = new DataMapping(xlCols, sqlCols, sql2);
                    dm.RowSelect(rowArray, true);
                    DataTable dt = (dm.OutputTable(ofileName, i + 1));
                  
                  

                    foreach (DataRow t in dt.Rows)
                    {
                        if ((String.IsNullOrWhiteSpace(filter)|| Convert.ToString(t["Product"]).Trim() == filter)&& t["InstallID"]!=DBNull.Value)
                        {
                            DataRow r = sqlTable.NewRow();
                            r["TabName"] = s;
                            r["PurchasingID"] = purchasingID;
                            for (int k = 0; k < dt.Columns.Count; k++)
                            {
                                string clm = dt.Columns[k].ColumnName;
                                if (sqlTable.Columns.Contains(clm))
                                {
                                    if (t[k] != null)
                                    {
                                        r[clm] = t[k];
                                    }
                                    else
                                    {
                                        r[clm] = DBNull.Value;
                                    }
                                } 
                            }
                            sqlTable.Rows.Add(r);
                        }
                       

                      



                       
                    }
                    
                }
            }


            importItems = sqlTable;
            return sqlTable;
            //foreach(DataTable dt in tabtables)
            //{

            //}


        }


        public void UpdatePurchasingList()
        {
            sMSLinesTableAdapter = new SMSLinesTableAdapter();
            sMSLinesTableAdapter.Fill(sbi_installdbDataSet.SMSLines);
            sMSLinesTableAdapter.DeleteQuery(purchasingID);
            foreach (DataRow r in importItems.Rows)
            {
                DataRow s = sbi_installdbDataSet.SMSLines.NewRow();
                s.ItemArray = r.ItemArray;
                sbi_installdbDataSet.SMSLines.Rows.Add(s);
                
            }


            //List<string> newInstallIDs = new List<String>();
            //foreach (DataRow r in importItems.Rows)
            //{

            //    if (ValidateSOPNumber(r))
            //    {
            //        //remove asterisk characters used to mark if a job is a revist.

            //        string val = r["InstallID"].ToString().Replace("*", "");

            //        int val3 = Convert.ToInt32(val);

            //        DataTable dt = reqPurchasingTableAdapter.GetDataByInstallIDPurchasingID(val3, purchasingID);


            //        if (dt.Rows.Count == 0)
            //        {

            //            DataRow newRow = sbi_installdbDataSet.ReqPurchasing.NewRow();
            //            newRow["InstallID"] = val3;
            //            newRow["PurchasingAreaID"] = purchasingID;
            //            for (int i = 0; i < importItems.Columns.Count; i++)
            //            {
            //                string clm = importItems.Columns[i].ColumnName;
            //                if (sbi_installdbDataSet.ReqPurchasing.Columns.Contains(clm) && clm != "InstallID")
            //                {
            //                    newRow[clm] = r[i];
            //                }
            //            }
            //            sbi_installdbDataSet.ReqPurchasing.Rows.Add(newRow);

            //        }
            //        else
            //        {
            //            DataRow s = sbi_installdbDataSet.ReqPurchasing.FindByReqSCID(Convert.ToInt32(dt.Rows[0]["ReqSCID"]));
            //            if (s.RowState != DataRowState.Modified)
            //            {
            //                for (int i = 0; i < importItems.Columns.Count; i++)
            //                {
            //                    string clm = importItems.Columns[i].ColumnName;
            //                    if (sbi_installdbDataSet.ReqPurchasing.Columns.Contains(clm) && clm != "InstallID")
            //                    {
            //                        s[clm] = r[i];
            //                    }
            //                }
            //            }


            //        }
            //    }

            //}
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
                
                this.sMSLinesTableAdapter.Update(this.sbi_installdbDataSet.SMSLines);
                MessageBox.Show(areaname + " - Update successful");
            }
            //catch (DBConcurrencyException dbcx)
            //{
            //    DialogResult response = MessageBox.Show(CreateMessage((sbi_installdbDataSet.ReqPurchasingRow)
            //        (dbcx.Row)), "Concurrency Exception", MessageBoxButtons.YesNo);

            //    ProcessDialogResult(response);
            //}

            catch (Exception ex)
            {
                MessageBox.Show("An error was thrown while attempting to update the database." + ex.Message);
            }
        }
        //private string CreateMessage(sbi_installdbDataSet.ReqPurchasingRow cr)
        //{
        //    return
        //        "Someone had made  change while you were updating the Install Schedule \n" +
        //        "Database: " + GetRowData(GetCurrentRowInDB(cr), DataRowVersion.Default) + "\n" +
        //        "Original: " + GetRowData(cr, DataRowVersion.Original) + "\n" +
        //        "Proposed: " + GetRowData(cr, DataRowVersion.Current) + "\n" +
        //        "Do you still want to update the database with the proposed value?";
        //}
        ////-------------------------------------------------------------------------- 
        //// This method loads a temporary table with current records from the database 
        //// and returns the current values from the row that caused the exception. 
        ////-------------------------------------------------------------------------- 
        //private sbi_installdbDataSet.SMSLinesDataTable tempSMSLinesDataTable =
        //    new sbi_installdbDataSet.SMSLinesDataTable();

        //private sbi_installdbDataSet.ReqPurchasingRow GetCurrentRowInDB(sbi_installdbDataSet.ReqPurchasingRow RowWithError)
        //{
        //    //this.sMSLinesTableAdapter.Fill(tempSMSLinesDataTable);

        //    //sbi_installdbDataSet.SMSLinesRow currentRowInDb =
        //    //    tempSMSLinesDataTable.FindByReqPurID(RowWithError.ReqPurID);

        //    //return currentRowInDb;
        //}


        //-------------------------------------------------------------------------- 
        // This method takes a Row and RowVersion  
        // and returns a string of column values to display to the user. 
        //-------------------------------------------------------------------------- 
        //private string GetRowData(sbi_installdbDataSet.ReqPurchasingRow depRow, DataRowVersion RowVersion)
        //{
        //    //string rowData = "";

        //    //for (int i = 0; i < depRow.ItemArray.Length; i++)
        //    //{
        //    //    rowData = rowData + depRow[i, RowVersion].ToString() + " ";
        //    //}
        //    //return rowData;
        //}


        // This method takes the DialogResult selected by the user and updates the database  
        // with the new values or cancels the update and resets the Customers table  
        // (in the dataset) with the values currently in the database. 

        //private void ProcessDialogResult(DialogResult response)
        //{
        //    //switch (response)
        //    //{
        //    //    case DialogResult.Yes:
        //    //        sbi_installdbDataSet.Merge(tempReqPurchasingDataTable, true, MissingSchemaAction.Ignore);
        //    //        UpdateDatabase();
        //    //        break;

        //    //    case DialogResult.No:
        //    //        sbi_installdbDataSet.Merge(tempReqPurchasingDataTable);
        //    //        MessageBox.Show("Update cancelled");
        //    //        break;
        //    //}
        //}
        public void Dispose()
        {
            if (sbi_installdbDataSet != null)
            {
                sbi_installdbDataSet.Dispose();
                sbi_installdbDataSet = null;


            }
            if (sMSLinesTableAdapter != null)
            {
                sMSLinesTableAdapter.Dispose();
                sMSLinesTableAdapter = null;
            }
            if (purchasingAreasTableAdapter!= null)
            {
                purchasingAreasTableAdapter.Dispose();
                purchasingAreasTableAdapter = null;
            }
            if (installScheduleTableAdapter != null)
            {
                installScheduleTableAdapter.Dispose();
                installScheduleTableAdapter = null;
            }
    }
    }

}
