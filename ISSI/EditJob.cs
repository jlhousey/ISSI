using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ISSI
{
    public partial class EditJob : Form
    {
        int jID = 0;
        public int returnJobId = 0;
        //private DataTable modified;
        public EditJob()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            InitializeComponent();
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.sbi_salesdbDataSet.Job);
            this.siteDetailsTableAdapter.Fill(this.sbi_salesdbDataSet.SiteDetails);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            siteDetailsBindingSource.Sort = "Name";
            
        }

       

        public EditJob(int jobID, bool newItem)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            jID = jobID;
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            InitializeComponent();
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.FillByJobID(this.sbi_salesdbDataSet.Job, jobID);
            this.siteDetailsTableAdapter.Fill(this.sbi_salesdbDataSet.SiteDetails);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.installScheduleTableAdapter.Fill(this.sbi_installdbDataSet.InstallSchedule);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.JobDetails' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.JobKeyDates' table. You can move, or remove it, as needed.
            this.jobKeyDatesTableAdapter.Fill(this.sbi_installdbDataSet.JobKeyDates);
            this.keyDateListTableAdapter.Fill(this.sbi_installdbDataSet.KeyDateList);
            if (newItem)
            {
                DataRow dr = sbi_installdbDataSet.JobDetails.NewRow();
                dr["JobID"] = jobID;

                sbi_installdbDataSet.JobDetails.Rows.Add(dr);
                
                this.tableAdapterManager1.UpdateAll(sbi_installdbDataSet);
                this.jobDetailsBindingSource.Position = sbi_installdbDataSet.JobDetails.Rows.IndexOf(dr);

            }
            else
            {
                this.jobDetailsTableAdapter.FillByJobID(this.sbi_installdbDataSet.JobDetails, jobID);
            }

        }
        public EditJob(int clientID, int siteID, bool newItem)
        {
            

        }
        public EditJob(int clientID, int jobID)
        {
           

        }

        private void jobBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           
            this.Validate();

            this.jobBindingSource.EndEdit();
            this.lineBindingSource.EndEdit();
            this.installScheduleBindingSource.EndEdit();
            
            this.keyDateListBindingSource.EndEdit();
            this.jobDetailsBindingSource.EndEdit();


            try
            {
                this.keyDateListTableAdapter.Update(this.sbi_installdbDataSet.KeyDateList);
            }
            catch(SqlException sqlex)
            {
                MessageBox.Show("One or more fields in the KeyDate table are invalid.  Please check and retry/nSql Error message: " +sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was thrown while attempting to update the database." + ex.Message);
            }
            this.tableAdapterManager1.UpdateAll(this.sbi_installdbDataSet);
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }
        private void getmodified()
        {
            

        }

        private void updateAllocation(DataRow r)
        {
            
        }

        private void EditJob_Load(object sender, EventArgs e)
        {
            //installScheduleDataGridView.CurrentCell.Selected = false;
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.KeyDateList' table. You can move, or remove it, as needed.
            this.keyDateListTableAdapter.Fill(this.sbi_installdbDataSet.KeyDateList);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vInstallDefaults' table. You can move, or remove it, as needed.
            this.vInstallDefaultsTableAdapter.Fill(this.sbi_installdbDataSet.vInstallDefaults);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SubConAreas' table. You can move, or remove it, as needed.
            this.subConAreasTableAdapter.Fill(this.sbi_installdbDataSet.SubConAreas);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.HResources' table. You can move, or remove it, as needed.
            this.hResourcesTableAdapter.Fill(this.sbi_installdbDataSet.HResources);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.PurchasingAreas' table. You can move, or remove it, as needed.
            this.purchasingAreasTableAdapter.Fill(this.sbi_installdbDataSet.PurchasingAreas);
            
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.JobTypes' table. You can move, or remove it, as needed.
            this.jobTypesTableAdapter.Fill(this.sbi_installdbDataSet.JobTypes);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter1.Fill(this.sbi_installdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.OpsPlanner' table. You can move, or remove it, as needed.
            this.opsPlannerTableAdapter.Fill(this.sbi_installdbDataSet.OpsPlanner);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.InstallSchedule' table. You can move, or remove it, as needed.
            this.installScheduleTableAdapter.Fill(this.sbi_installdbDataSet.InstallSchedule);
            
            this.sAMTableAdapter.Fill(this.sbi_salesdbDataSet1.SAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet1.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet1.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet1.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.sbi_salesdbDataSet1.Category);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet1.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_salesdbDataSet1.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet1.Line' table. You can move, or remove it, as needed.
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet1.Line);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet1.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet1.DAM);

            getLines();



            //installScheduleDataGridView.CurrentCell.Selected = false;
            

        }

        private void getLines()
        {
            this.sbi_installdbDataSet.ReqSubCon.Clear();
            this.sbi_installdbDataSet.ReqPurchasing.Clear();
            this.sbi_installdbDataSet.ReqHResource.Clear();
            DataTable jobinstalls = this.installScheduleTableAdapter.GetDataByJobID(jID);
            foreach (DataRow r in jobinstalls.Rows)
            {
               
                this.reqSubConTableAdapter.FillByInstallID(this.sbi_installdbDataSet.ReqSubCon, Convert.ToInt32(r["InstallID"]));
                this.reqPurchasingTableAdapter.FillByInstallID(this.sbi_installdbDataSet.ReqPurchasing, Convert.ToInt32(r["InstallID"]));
                this.reqHResourceTableAdapter.FillByInstallID(this.sbi_installdbDataSet.ReqHResource, Convert.ToInt32(r["InstallID"]));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                this.Validate();
                this.jobBindingSource.EndEdit();
                this.lineBindingSource.EndEdit();
                this.lineTableAdapter.Update(this.sbi_salesdbDataSet.Line);
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
                DataRowView drv = (DataRowView)jobBindingSource.Current;
                int currentJob = Convert.ToInt32(drv["JobID"]);

               
                this.jobTableAdapter.FillByJobID(this.sbi_salesdbDataSet.Job, currentJob);
                if (this.sbi_salesdbDataSet.Job.FindByJobID(currentJob)["SOPID"] == null)
                {
                    MessageBox.Show("No SOP allocated to this job");


                }
                else
                {
                    DataRow r = this.sbi_installdbDataSet.InstallSchedule.NewRow();
                    if (this.installScheduleTableAdapter.MaxInstallID(currentJob) == null || this.installScheduleTableAdapter.MaxInstallID(currentJob) == 0)
                    {


                        r["InstallID"] = (Convert.ToInt32(this.sbi_salesdbDataSet.Job.FindByJobID(currentJob)["SOPID"]) * 100) + 1;


                    }

                    else
                    {
                        r["InstallID"] = this.installScheduleTableAdapter.MaxInstallID(currentJob) + 1;
                    }
                    r["OpsPlannerID"] = Session.UserID;
                    r["JobID"] = currentJob;
                    r["JobType"] = 1;
                    r["StatusID"] = 1;
                    this.vInstallDefaultsTableAdapter.Fill(this.sbi_installdbDataSet.vInstallDefaults);
                    r["SAMID"]=this.sbi_installdbDataSet.vInstallDefaults.FindByJobID(currentJob)["SAMID"];
                    r["DAMID"] = this.sbi_installdbDataSet.vInstallDefaults.FindByJobID(currentJob)["DAMID"];
                    r["InstallDate"] = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                    r["OriginalInstallDate"] = r["InstallDate"];
                    int iid = Convert.ToInt32(r["InstallID"]);

                    this.sbi_installdbDataSet.InstallSchedule.Rows.Add(r);
                    this.installScheduleTableAdapter.Update(this.sbi_installdbDataSet.InstallSchedule);
                    this.tableAdapterManager1.UpdateAll(sbi_installdbDataSet);



                    EditInstall el = new EditInstall(iid);
                    el.newiid = true;
                    el.ShowDialog();
                   
                }
                
                    this.installScheduleTableAdapter.Fill(this.sbi_installdbDataSet.InstallSchedule);
                    getLines();



            }

             
        }

        private void lineDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }

        }

        private void lineDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void lineDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (jID != 0)
            {
                string connectionString = Properties.Settings.Default.sbi_installdbConnectionString;
                string commandText = "CreateBuild";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@p1", jID));


                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            this.keyDateListTableAdapter.Fill(this.sbi_installdbDataSet.KeyDateList);
        }

        private void installScheduleDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {




                int installId = Convert.ToInt32(installScheduleDataGridView.Rows[e.RowIndex].Cells["InstallID"].Value);
                this.Validate();
                this.siteDetailsBindingSource.EndEdit();
                this.jobBindingSource.EndEdit();
                this.jobTableAdapter.Update(this.sbi_salesdbDataSet.Job);
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
                DataRowView currentSite = (DataRowView)siteDetailsBindingSource.Current;
                //currentPO["Name"] = tbPOSOP.Text;






                EditInstall ei = new EditInstall(installId);
                ei.ShowDialog();

                
                this.installScheduleTableAdapter.Fill(this.sbi_installdbDataSet.InstallSchedule);
                
                getLines();
            }
        }

        private void keyDateListDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == keyDateListDataGridView.Columns["Complete"].Index && e.RowIndex != -1)
            {
               keyDateListDataGridView.EndEdit();
            }
        }
        private void myDataGrid_OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == keyDateListDataGridView.Columns["Complete"].Index && e.RowIndex != -1)
            {

                if (keyDateListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value && (bool)keyDateListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    if (keyDateListDataGridView.Rows[e.RowIndex].Cells["DateComplete"].Value == DBNull.Value || keyDateListDataGridView.Rows[e.RowIndex].Cells["DateComplete"].Value == null)
                    {
                        keyDateListDataGridView.Rows[e.RowIndex].Cells["DateComplete"].Value = Convert.ToString(DateTime.Today); 
                    } 
                }
                else
                {
                    if (keyDateListDataGridView.Rows[e.RowIndex].Cells["DateComplete"].Value == DBNull.Value || keyDateListDataGridView.Rows[e.RowIndex].Cells["DateComplete"].Value == null)
                    {
                        keyDateListDataGridView.Rows[e.RowIndex].Cells["DateComplete"].Value = DBNull.Value; 
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           


        }

        private void reqSubConDataGridView_Paint(object sender, PaintEventArgs e)
        {
            foreach (DataGridViewRow r in reqSubConDataGridView.Rows)
            {
                if (r.Cells["CMRAG"].Value != null && r.Cells["CMRAG"].Value != DBNull.Value)
                {
                    if ((Convert.ToInt32(r.Cells["CMRAG"].Value)) == 1)
                    {
                        r.Cells["Notes"].Style.BackColor = Color.Red;
                        r.Cells["CheckDate"].Style.BackColor = Color.Red;

                    }
                    if ((Convert.ToInt32(r.Cells["CMRAG"].Value)) == 2)
                    {
                        r.Cells["Notes"].Style.BackColor = Color.Orange;
                        r.Cells["CheckDate"].Style.BackColor = Color.Orange;

                    }
                    if ((Convert.ToInt32(r.Cells["CMRAG"].Value)) == 3)
                    {
                        r.Cells["Notes"].Style.BackColor = Color.Green;
                        r.Cells["CheckDate"].Style.BackColor = Color.Green;
                    }
                } 
            }

            foreach (DataGridViewRow r in reqSubConDataGridView.Rows)
            {
                if (r.Cells["SCIRAG"].Value != null && r.Cells["SCIRAG"].Value != DBNull.Value)
                {
                    if ((Convert.ToInt32(r.Cells["SCIRAG"].Value)) == 1)
                    {
                        r.Cells["InstallDate"].Style.BackColor = Color.Red;

                    }
                    if ((Convert.ToInt32(r.Cells["SCIRAG"].Value)) == 2)
                    {
                        r.Cells["InstallDate"].Style.BackColor = Color.Orange;

                    }
                    if ((Convert.ToInt32(r.Cells["SCIRAG"].Value)) == 3)
                    {
                        r.Cells["InstallDate"].Style.BackColor = Color.Green;

                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewPurchasing vp = new ViewPurchasing(jID, "Job");
            vp.ShowDialog();
        }

        private void keyDateListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Invalid Data in KeyDates table");
        }

        private void keyDateListDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if(Convert.ToString(keyDateListDataGridView.Rows[e.RowIndex].Cells["Complete"].EditedFormattedValue) == "True")
            {
                keyDateListDataGridView.Rows[e.RowIndex].Cells["DateComplete"].Style.BackColor = Color.LightGreen;
            }
            else
            {
                keyDateListDataGridView.Rows[e.RowIndex].Cells["DateComplete"].Style.BackColor = Color.White;
            }
        }

        private void installScheduleDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void installScheduleDataGridView_Paint(object sender, PaintEventArgs e)
        {
            this.jobTypesTableAdapter.Fill(this.sbi_installdbDataSet.JobTypes);
            foreach (DataGridViewRow r in installScheduleDataGridView.Rows)
            {
                if (!r.IsNewRow)
                {

                    int catID = Convert.ToInt32(r.Cells["JobType"].Value);
                    Color col = ColorTranslator.FromHtml("#" + this.sbi_installdbDataSet.JobTypes.FindByTypeID(catID)["ColourCode"].ToString());
                    for (int i = 0; i <2; i++)
                    {
                        r.Cells[i].Style.BackColor = col;
                    }

                    if (r.Cells["RAG"].Value != null && r.Cells["RAG"].Value != DBNull.Value)
                    {
                        if ((Convert.ToInt32(r.Cells["RAG"].Value)) == 1)
                        {
                            r.Cells["InstDate"].Style.BackColor = Color.Red;

                        }
                        if ((Convert.ToInt32(r.Cells["RAG"].Value)) == 2)
                        {
                            r.Cells["InstDate"].Style.BackColor = Color.Orange;

                        }
                        if ((Convert.ToInt32(r.Cells["RAG"].Value)) == 3)
                        {
                            r.Cells["InstDate"].Style.BackColor = Color.Green;

                        }
                    }
                }
            }
        }

        private void EditJob_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Save Changes?", "Save Changes?", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                this.Validate();

                this.jobBindingSource.EndEdit();
                this.lineBindingSource.EndEdit();
                this.installScheduleBindingSource.EndEdit();

                this.keyDateListBindingSource.EndEdit();
                this.jobDetailsBindingSource.EndEdit();


                try
                {
                    this.keyDateListTableAdapter.Update(this.sbi_installdbDataSet.KeyDateList);
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("One or more fields in the KeyDate table are invalid.  Please check and retry/nSql Error message: " + sqlex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error was thrown while attempting to update the database." + ex.Message);
                }
                this.tableAdapterManager1.UpdateAll(this.sbi_installdbDataSet);
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            }

            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void reqPurchasingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void keyDateListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
