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
using System.IO;

namespace ISSI
{
    public partial class EditSite : Form
    {
        public string newFilter = "";
        public int sid = 0;
        private bool filtered = false;

        public EditSite()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            InitializeComponent();
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.siteDetailsTableAdapter.Fill(this.sbi_salesdbDataSet.SiteDetails);
        }

        public EditSite(int siteID)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            InitializeComponent();
            sid = siteID;
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.siteDetailsTableAdapter.FillBySiteID(this.sbi_salesdbDataSet.SiteDetails, siteID);
            this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
            this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
            this.sbi_installdbDataSet.SiteContactEvents.OrderByDescending(row => row.Field<int?>("CEventID"));
            this.siteDetailsTableAdapter1.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteID);
            if (sbi_installdbDataSet.SiteDetails.Rows.Count == 0)
            {
                DataRow dr = sbi_installdbDataSet.SiteDetails.NewRow();
                dr["SiteID"] = siteID;

                sbi_installdbDataSet.SiteDetails.Rows.Add(dr);
                //foreach (DataRow r in this.sbi_installdbDataSet.JobKeyDates.Rows)
                //{
                //    DataRow ds = sbi_installdbDataSet.KeyDateList.NewRow();
                //    ds["JobID"] = jobID;
                //    ds["KeyDateID"] = r["KeyDateID"];
                //    sbi_installdbDataSet.KeyDateList.Rows.Add(ds);


                //}

                this.siteDetailsBindingSource1.Position = sbi_installdbDataSet.SiteDetails.Rows.IndexOf(dr);
                
                this.siteDetailsBindingSource1.EndEdit();
                this.siteDetailsTableAdapter1.Update(sbi_installdbDataSet.SiteDetails);
            }
            this.siteContactEventsDataGridView.Sort(this.siteContactEventsDataGridView.Columns["CEventID"], ListSortDirection.Descending);
            this.vInstallLineSummaryAllBindingSource.Filter = "Status = 'LIVE'";
            this.button7.Text = "Show All";
            filtered = true;
            // fillBuildView();
        }

        public EditSite(int siteID, bool filt)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            InitializeComponent();
            sid = siteID;
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.siteDetailsTableAdapter.FillBySiteID(this.sbi_salesdbDataSet.SiteDetails, siteID);
            this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
            this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
            this.sbi_installdbDataSet.SiteContactEvents.OrderByDescending(row => row.Field<int?>("CEventID"));
            this.siteDetailsTableAdapter1.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteID);
            if (sbi_installdbDataSet.SiteDetails.Rows.Count == 0)
            {
                DataRow dr = sbi_installdbDataSet.SiteDetails.NewRow();
                dr["SiteID"] = siteID;

                sbi_installdbDataSet.SiteDetails.Rows.Add(dr);
                //foreach (DataRow r in this.sbi_installdbDataSet.JobKeyDates.Rows)
                //{
                //    DataRow ds = sbi_installdbDataSet.KeyDateList.NewRow();
                //    ds["JobID"] = jobID;
                //    ds["KeyDateID"] = r["KeyDateID"];
                //    sbi_installdbDataSet.KeyDateList.Rows.Add(ds);


                //}

                this.siteDetailsBindingSource1.Position = sbi_installdbDataSet.SiteDetails.Rows.IndexOf(dr);

                this.siteDetailsBindingSource1.EndEdit();
                this.siteDetailsTableAdapter1.Update(sbi_installdbDataSet.SiteDetails);
            }
            this.siteContactEventsDataGridView.Sort(this.siteContactEventsDataGridView.Columns["CEventID"], ListSortDirection.Descending);
            if (filt)
            {
                this.vInstallLineSummaryAllBindingSource.Filter = "Status = 'LIVE'";
                this.button7.Text = "Show All";
                filtered = true; 
            }
            // fillBuildView();
        }

        private void siteDetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.siteDetailsBindingSource.EndEdit();
            this.siteDetailsBindingSource1.EndEdit();
            this.jobBindingSource.EndEdit();
            this.contactsBindingSource.EndEdit();
            this.siteContactEventsBindingSource.EndEdit();
            this.jobKeyDatesTableAdapter1.Fill(sbi_installdbDataSet.JobKeyDates);
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                int job = Convert.ToInt32(r.Cells["JobID"].Value);
                this.jobDetailsTableAdapter.Fill(this.sbi_installdbDataSet.JobDetails);
                this.sbi_installdbDataSet.JobDetails.FindByJobID(job)["SalesLaunchDate"] = r.Cells["SalesLaunchDate"].Value;
                this.jobDetailsTableAdapter.Update(this.sbi_installdbDataSet.JobDetails);
                this.keyDateListTableAdapter1.FillByJobID(this.sbi_installdbDataSet.KeyDateList, job);
                for (int j = 5; j < dataGridView1.Columns.Count; j = j + 2)
                {
                    string colname = dataGridView1.Columns[j].Name;
                    int id = Convert.ToInt32(r.Cells[colname].Tag);
                    

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(r.Cells[colname].Value)))
                    {
                        this.sbi_installdbDataSet.KeyDateList.FindByKeyDateListID(id).DateComplete = (DateTime)r.Cells[colname].Value;
                    }

                    if (r.Cells["chk" + colname].Value == DBNull.Value)
                    {
                        this.sbi_installdbDataSet.KeyDateList.FindByKeyDateListID(id).Complete = false; 
                    }
                    else
                    {
                        this.sbi_installdbDataSet.KeyDateList.FindByKeyDateListID(id).Complete = Convert.ToBoolean(r.Cells["chk" + colname].Value);
                    }
                    
                }
                this.keyDateListTableAdapter1.Update(this.sbi_installdbDataSet.KeyDateList);


            }
            foreach (DataGridViewRow r in vInstallLineSummaryAllDataGridView.Rows)
            {
                int instid = Convert.ToInt32(r.Cells["InstallID"].Value);
                this.installScheduleTableAdapter1.FillByInstallID(this.sbi_installdbDataSet.InstallSchedule, instid);
                this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(instid)["RAG"] = r.Cells["RAG"].Value;
                
                this.installScheduleTableAdapter1.Update(this.sbi_installdbDataSet.InstallSchedule);


            }


            this.jobTableAdapter.Update(this.sbi_salesdbDataSet.Job);
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            this.siteDetailsTableAdapter1.Update(sbi_installdbDataSet.SiteDetails);
            this.contactsTableAdapter.Update(this.sbi_installdbDataSet);
            //this.Close();

        }

        private void EditSite_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.OpsPlanner' table. You can move, or remove it, as needed.
            this.opsPlannerTableAdapter1.Fill(this.sbi_installdbDataSet.OpsPlanner);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.Contacts' table. You can move, or remove it, as needed.
            this.contactsTableAdapter.Fill(this.sbi_installdbDataSet.Contacts);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            //this.siteDetailsTableAdapter1.Fill(this.sbi_installdbDataSet.SiteDetails);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.OPSPlanner' table. You can move, or remove it, as needed.
            this.oPSPlannerTableAdapter.Fill(this.sbi_salesdbDataSet.OPSPlanner);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteContactEvents' table. You can move, or remove it, as needed.
            this.siteContactEventsTableAdapter.Fill(this.sbi_installdbDataSet.SiteContactEvents);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteContactEvents' table. You can move, or remove it, as needed.
            //this.siteContactEventsTableAdapter.Fill(this.sbi_installdbDataSet.SiteContactEvents);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.JobDetails' table. You can move, or remove it, as needed.
            this.jobDetailsTableAdapter.Fill(this.sbi_installdbDataSet.JobDetails);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            //this.siteDetailsTableAdapter1.Fill(this.sbi_installdbDataSet.SiteDetails);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vInstallLineSummaryAll' table. You can move, or remove it, as needed.
            //this.vInstallLineSummaryAllTableAdapter.Fill(this.sbi_installdbDataSet.vInstallLineSummaryAll);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.sbi_salesdbDataSet.Job);
            fillBuildView();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.siteDetailsBindingSource.EndEdit();
            this.siteDetailsBindingSource1.EndEdit();
            this.jobBindingSource.EndEdit();
            this.contactsBindingSource.EndEdit();
            this.siteContactEventsBindingSource.EndEdit();
            saveBuild();
            this.contactsTableAdapter.Update(this.sbi_installdbDataSet);
            this.jobTableAdapter.Update(this.sbi_salesdbDataSet.Job);
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            this.tableAdapterManager1.UpdateAll(this.sbi_installdbDataSet);

            DataRowView currentSite = (DataRowView)siteDetailsBindingSource.Current;
            //currentPO["Name"] = tbPOSOP.Text;

            int siteID = Convert.ToInt32(currentSite["SiteID"]);

            //TODO: Create new JobDetails record if none exists and add an install line

            //int clientID = Convert.ToInt32(comboBox1.SelectedValue);


            //using (EditJob ej = new EditJob(clientID, true))
            //{
            //    this.DialogResult = DialogResult.OK;
            //    var result = ej.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        string ejreturn = Convert.ToString(ej.returnJobId);
            //        if (String.IsNullOrWhiteSpace(newFilter))
            //        {
            //            newFilter = "JobId = " + ejreturn;
            //        }
            //        else
            //        {
            //            newFilter += " OR JobID = " + ejreturn;
            //        }

            //    }

            //}
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.siteDetailsTableAdapter.FillBySiteID(this.sbi_salesdbDataSet.SiteDetails, siteID);
            this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
            this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
            this.sbi_installdbDataSet.SiteContactEvents.OrderByDescending(row => row.Field<int?>("CEventID"));
            this.siteDetailsTableAdapter1.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteID);
            fillBuildView();
        }

        private void jobDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {




                int jobId = Convert.ToInt32(jobDataGridView.Rows[e.RowIndex].Cells["JobID"].Value);
                this.Validate();
                this.siteDetailsBindingSource.EndEdit();
                this.jobBindingSource.EndEdit();
                saveBuild();
                this.jobTableAdapter.Update(this.sbi_salesdbDataSet.Job);
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
                DataRowView currentSite = (DataRowView)siteDetailsBindingSource.Current;
                //currentPO["Name"] = tbPOSOP.Text;

                int siteID = Convert.ToInt32(currentSite["SiteID"]);

                this.jobDetailsTableAdapter.FillByJobID(this.sbi_installdbDataSet.JobDetails, jobId);
                bool createNew = sbi_installdbDataSet.JobDetails.Rows.Count == 0;


                EditJob ej = new EditJob(jobId, createNew);
                ej.ShowDialog();
                this.siteDetailsTableAdapter.FillBySiteID(this.sbi_salesdbDataSet.SiteDetails, siteID);
                this.jobTableAdapter.Fill(this.sbi_salesdbDataSet.Job);
                this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
                this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
                this.sbi_installdbDataSet.SiteContactEvents.OrderByDescending(row => row.Field<int?>("CEventID"));
                this.siteDetailsTableAdapter1.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteID);
                fillBuildView();


            }
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.siteDetailsBindingSource.EndEdit();
            this.siteDetailsBindingSource1.EndEdit();
            this.jobBindingSource.EndEdit();
            this.contactsBindingSource.EndEdit();
            this.siteContactEventsBindingSource.EndEdit();
            saveBuild();
            this.jobTableAdapter.Update(this.sbi_salesdbDataSet.Job);
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            this.siteDetailsTableAdapter1.Update(sbi_installdbDataSet.SiteDetails);
            this.contactsTableAdapter.Update(this.sbi_installdbDataSet);


            DataRowView currentSite = (DataRowView)siteDetailsBindingSource.Current;
            int siteID = Convert.ToInt32(currentSite["SiteID"]);
            ContactSite cs = new ContactSite(siteID, true);
            cs.Show();
            this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
            this.siteContactEventsDataGridView.Sort(this.siteContactEventsDataGridView.Columns["CEventID"], ListSortDirection.Descending);
        }

        private void vInstallLineSummaryAllDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {




                int installId = Convert.ToInt32(vInstallLineSummaryAllDataGridView.Rows[e.RowIndex].Cells["InstallID"].Value);
                this.Validate();
                this.siteDetailsBindingSource.EndEdit();
                this.jobBindingSource.EndEdit();
                saveBuild();
                this.jobTableAdapter.Update(this.sbi_salesdbDataSet.Job);
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
                DataRowView currentSite = (DataRowView)siteDetailsBindingSource.Current;
                //currentPO["Name"] = tbPOSOP.Text;

                int siteID = Convert.ToInt32(currentSite["SiteID"]);




                EditInstall ei = new EditInstall(installId);
                ei.ShowDialog();
                this.siteDetailsTableAdapter.FillBySiteID(this.sbi_salesdbDataSet.SiteDetails, siteID);
                this.jobTableAdapter.Fill(this.sbi_salesdbDataSet.Job);
                this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
                this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
                this.sbi_installdbDataSet.SiteContactEvents.OrderByDescending(row => row.Field<int?>("CEventID"));
                this.siteDetailsTableAdapter1.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteID);
                fillBuildView();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Today;
            int i = this.vInstallLineSummaryAllDataGridView.SelectedRows.Count;
            if (i > 0)
            {
                int[] iids = new int[i];
                int j = 0;
                
                foreach (DataGridViewRow r in this.vInstallLineSummaryAllDataGridView.SelectedRows)
                {
                    iids[j] = Convert.ToInt32(r.Cells["InstallID"].Value);
                    if( j == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["InstallDate"].Value)))
                        {
                            start = (DateTime)r.Cells["InstallDate"].Value;
                        }
                    }
                    j++;
                }
                DatePicker dp = new DatePicker(iids, start);
                dp.ShowDialog();
                DateTime newDate = dp.selDate;

                if (newDate.Year>2015)
                {
                    foreach (int k in iids)
                    {
                        this.installScheduleTableAdapter1.FillByInstallID(this.sbi_installdbDataSet.InstallSchedule, k);
                        this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(k)["InstallDate"] = newDate;
                        this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(k)["InstallDay"] = -1;
                        this.installScheduleTableAdapter1.Update(this.sbi_installdbDataSet.InstallSchedule);

                    } 
                }
                this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, sid);
            }
        }

        private void siteContactEventsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {




                int cid = Convert.ToInt32(siteContactEventsDataGridView.Rows[e.RowIndex].Cells["CEventID"].Value);
                this.Validate();
                this.siteDetailsBindingSource.EndEdit();
                this.jobBindingSource.EndEdit();
                saveBuild();
                this.jobTableAdapter.Update(this.sbi_salesdbDataSet.Job);
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);



                ContactSite cs = new ContactSite(sid, cid);
                cs.ShowDialog();
                this.siteDetailsTableAdapter.FillBySiteID(this.sbi_salesdbDataSet.SiteDetails, sid);
                this.jobTableAdapter.Fill(this.sbi_salesdbDataSet.Job);
                this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, sid);
                this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, sid);
                this.sbi_installdbDataSet.SiteContactEvents.OrderByDescending(row => row.Field<int?>("CEventID"));
                this.siteDetailsTableAdapter1.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, sid);
                this.siteContactEventsDataGridView.Sort(this.siteContactEventsDataGridView.Columns["CEventID"], ListSortDirection.Descending);
                fillBuildView();

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int i = this.vInstallLineSummaryAllDataGridView.SelectedRows.Count;
            if (i > 0)
            {
                int[] iids = new int[i];
                int j = 0;
                foreach (DataGridViewRow r in this.vInstallLineSummaryAllDataGridView.SelectedRows)
                {
                    iids[j] = Convert.ToInt32(r.Cells["InstallID"].Value);
                    j++;
                }
                MovementDialog md = new MovementDialog(iids);
                md.ShowDialog();

            }
        }

        private void fillBuildView()
        {
            dataGridView1.Columns.Clear();
            if (sid != 0)
            {
                string connectionString = Properties.Settings.Default.sbi_installdbConnectionString;
                string commandText = "vKeyDatesPivot";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;



                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                                {


                                if (dt.AsEnumerable()
                                                       .Count(row => row.Field<int>("SiteID") == sid)>0)
                                {
                                    DataTable tblFiltered = dt.AsEnumerable()
                                                       .Where(row => row.Field<int>("SiteID") == sid).OrderByDescending(row => row.Field<int>("JobID")).CopyToDataTable();

                                    foreach (DataColumn c in tblFiltered.Columns)
                                    {
                                        if (c.ColumnName.Contains("chk"))
                                        {
                                            DataGridViewCheckBoxColumn dgvc = new DataGridViewCheckBoxColumn();
                                            dgvc.Name = c.ColumnName;
                                            dgvc.DataPropertyName = c.ColumnName;
                                            
                                            dataGridView1.Columns.Add(dgvc);
                                            dgvc.Width = 25;
                                            dgvc.HeaderText = "";

                                        }
                                        else
                                        {
                                            DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                                            dgvc.Name = c.ColumnName;
                                            dgvc.DataPropertyName = c.ColumnName;
                                            dataGridView1.Columns.Add(dgvc);
                                        }
                                    }



                                    dataGridView1.AutoGenerateColumns = false;
                                    dataGridView1.DataSource = tblFiltered;
                                   dataGridView1.Columns[0].Visible = false;
                                   dataGridView1.Columns[1].Visible = false;
                                    dataGridView1.Columns["HouseType"].Frozen = true;
                                }

                            }
                            
                        }
                        //conn.Open();
                        //cmd.ExecuteNonQuery();
                    }
                    if (this.dataGridView1.Columns.Contains("SOPID"))
                    {
                        this.dataGridView1.Sort(this.dataGridView1.Columns["SOPID"], ListSortDirection.Descending); 
                    }

                }



                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    int job = Convert.ToInt32(r.Cells["JobID"].Value);

                    for (int j = 5; j < dataGridView1.Columns.Count; j = j+2)
                    {
                        string colname = dataGridView1.Columns[j].Name;
                        int id = Convert.ToInt32(this.jobKeyDatesTableAdapter1.RetrieveID(colname));
                        this.keyDateListTableAdapter1.FillByJobIDKeyDateID(this.sbi_installdbDataSet.KeyDateList, job, id);
                        foreach (sbi_installdbDataSet.KeyDateListRow kdr in this.sbi_installdbDataSet.KeyDateList.Rows)
                        {
                            ////kdr["DateComplete"] = r.Cells[colname].Value;
                            //int k = j + 1;
                            ////kdr["Complete"] = r.Cells["chk" + k].Value ?? DBNull.Value;
                            //r.Cells["chk" + k].Value = kdr["Complete"] ?? 0;

                            //r.Cells[colname].Style.BackColor = r.Cells["chk" + k].Value != DBNull.Value && Convert.ToInt32(r.Cells["chk" + k].Value) > 0 ? Color.Green : Color.White;
                            r.Cells[colname].Tag = kdr["KeyDateListID"];
                            r.Cells["chk" + colname].Tag = kdr["KeyDateListID"];
                            if(Convert.ToString(r.Cells["chk" + colname].EditedFormattedValue) == "True")
                            {
                                r.Cells[colname].Style.BackColor = Color.LightGreen;
                            }

                        }

                    }
                    //this.keyDateListTableAdapter1.Update(this.sbi_installdbDataSet.KeyDateList);


                }

                foreach(DataGridViewColumn c in dataGridView1.Columns)
                {
                   
                    if (c.Index > 2 && c.Index < 4)
                    {
                        c.MinimumWidth = 100; 
                    }
                    else
                    { 
                        c.MinimumWidth = 50;
                    }
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {




                int jobId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["JobID"].Value);
                this.Validate();
                this.siteDetailsBindingSource.EndEdit();
                this.jobBindingSource.EndEdit();
                saveBuild();
                this.jobTableAdapter.Update(this.sbi_salesdbDataSet.Job);
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
                
                DataRowView currentSite = (DataRowView)siteDetailsBindingSource.Current;
                //currentPO["Name"] = tbPOSOP.Text;

                int siteID = Convert.ToInt32(currentSite["SiteID"]);

                this.jobDetailsTableAdapter.FillByJobID(this.sbi_installdbDataSet.JobDetails, jobId);
                bool createNew = sbi_installdbDataSet.JobDetails.Rows.Count == 0;


                EditJob ej = new EditJob(jobId, createNew);
                ej.ShowDialog();
                this.siteDetailsTableAdapter.FillBySiteID(this.sbi_salesdbDataSet.SiteDetails, siteID);
                this.jobTableAdapter.Fill(this.sbi_salesdbDataSet.Job);
                this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
                this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
                this.sbi_installdbDataSet.SiteContactEvents.OrderByDescending(row => row.Field<int?>("CEventID"));
                this.siteDetailsTableAdapter1.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteID);
                fillBuildView();

            }
        }

        private void contactsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {
                if (contactsDataGridView.Columns[e.ColumnIndex].Name == "Email1")
                {
                    string email = Convert.ToString(contactsDataGridView.Rows[e.RowIndex].Cells["Email1"].Value);
                    EmailFile("test", ReadSignature(), "Show Business Interiors", email); 
                }
            }
        }
        private string ReadSignature()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);

            if (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

                if (fiSignature.Length > 0)
                {
                    StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                    signature = sr.ReadToEnd();

                    if (!string.IsNullOrEmpty(signature))
                    {
                        string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                        signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                    }
                }
            }
            return signature;
        }
        private void EmailFile(string filepath, string body, string title, string email)
        {

            try
            {



                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                oMailItem.HTMLBody = "<FONT size = \"2\" face=\"Arial\">";
                oMailItem.HTMLBody += body;


                if (filepath != "test")
                {
                    Microsoft.Office.Interop.Outlook.Attachment oAttach = oMailItem.Attachments.Add(filepath);
                }
                oMailItem.Subject = title;
                

                Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMailItem.Recipients;

                Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add(email);
                oRecip.Resolve();
                // Send.
                // oMsg.Send();
                // Clean up.
                oMailItem.Display(true);
                oRecip = null;
                oRecips = null;
                oMailItem = null;
                outlookApp = null;
            }

            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewPurchasing vp = new ViewPurchasing(sid, "Site");
            vp.ShowDialog();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void checkchanged()
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCell c = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dataGridView1.Columns[e.ColumnIndex].Name.Contains("chk"))
                {
                    if (Convert.ToString(c.EditedFormattedValue) == "True")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Style.BackColor = Color.LightGreen;
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value)))
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = Convert.ToString(DateTime.Today);
                        }

                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void vInstallLineSummaryAllDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.jobTypesTableAdapter1.Fill(this.sbi_installdbDataSet.JobTypes);
            foreach (DataGridViewRow r in vInstallLineSummaryAllDataGridView.Rows)
            {
                if (!r.IsNewRow)
                {
                    
                    int catID = Convert.ToInt32(r.Cells["JobType"].Value);
                    Color col = ColorTranslator.FromHtml("#" + this.sbi_installdbDataSet.JobTypes.FindByTypeID(catID)["ColourCode"].ToString());
                    for (int i = 0; i < 6; i++)
                    {
                        r.Cells[i].Style.BackColor = col;
                    }

                    if (r.Cells["RAG"].Value != null && r.Cells["RAG"].Value != DBNull.Value)
                    {
                        if ((Convert.ToInt32(r.Cells["RAG"].Value)) == 1)
                        {
                            r.Cells["InstallDate"].Style.BackColor = Color.Red;

                        }
                        if ((Convert.ToInt32(r.Cells["RAG"].Value)) == 2)
                        {
                            r.Cells["InstallDate"].Style.BackColor = Color.Orange;

                        }
                        if ((Convert.ToInt32(r.Cells["RAG"].Value)) == 3)
                        {
                            r.Cells["InstallDate"].Style.BackColor = Color.Green;

                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataRowView currentSite = (DataRowView)siteDetailsBindingSource.Current;
            //currentPO["Name"] = tbPOSOP.Text;

            int siteID = Convert.ToInt32(currentSite["SiteID"]);
            this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
            this.siteContactEventsDataGridView.Sort(this.siteContactEventsDataGridView.Columns["CEventID"], ListSortDirection.Descending);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in vInstallLineSummaryAllDataGridView.SelectedRows)
            {
                int iid = Convert.ToInt32(r.Cells["InstallID"].Value);




                foreach (DataGridViewRow s in jobDataGridView.SelectedRows)
                {
                    
                    int jobid = Convert.ToInt32(s.Cells["JobID"].Value);
                    this.jobDetailsTableAdapter.Fill(this.sbi_installdbDataSet.JobDetails);
                    if (this.sbi_installdbDataSet.JobDetails.FindByJobID(jobid) == null)
                    {
                        DataRow dr = sbi_installdbDataSet.JobDetails.NewRow();
                        dr["JobID"] = jobid;

                        sbi_installdbDataSet.JobDetails.Rows.Add(dr);

                        this.jobDetailsTableAdapter.Update(sbi_installdbDataSet.JobDetails); 
                    }

                    if (iid != 0 && jobid != 0)
                    {
                        int nid = 0;

                        if (this.installScheduleTableAdapter1.MaxInstallID(jobid) == null || this.installScheduleTableAdapter1.MaxInstallID(jobid) == 0)
                        {


                            nid = (Convert.ToInt32(this.sbi_salesdbDataSet.Job.FindByJobID(jobid)["SOPID"]) * 100) + 1;


                        }
                        else
                        {
                            nid = Convert.ToInt32(this.installScheduleTableAdapter1.MaxInstallID(jobid)) + 1;
                        }
                        string connectionString = Properties.Settings.Default.sbi_installdbConnectionString;
                        string commandText = "CloneInstall";


                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand(commandText, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add(new SqlParameter("@oldid", iid));
                                cmd.Parameters.Add(new SqlParameter("@jobid", jobid));
                                cmd.Parameters.Add(new SqlParameter("@newid", nid));

                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                }

            }

            this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, sid);
        }

        private void EditSite_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Save Changes?", "Save Changes?", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                this.Validate();
                this.siteDetailsBindingSource.EndEdit();
                this.siteDetailsBindingSource1.EndEdit();
                this.jobBindingSource.EndEdit();
                this.contactsBindingSource.EndEdit();
                this.siteContactEventsBindingSource.EndEdit();
                this.jobKeyDatesTableAdapter1.Fill(sbi_installdbDataSet.JobKeyDates);
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    int job = Convert.ToInt32(r.Cells["JobID"].Value);
                    this.jobDetailsTableAdapter.Fill(this.sbi_installdbDataSet.JobDetails);
                    this.sbi_installdbDataSet.JobDetails.FindByJobID(job)["SalesLaunchDate"] = r.Cells["SalesLaunchDate"].Value;
                    this.jobDetailsTableAdapter.Update(this.sbi_installdbDataSet.JobDetails);
                    this.keyDateListTableAdapter1.FillByJobID(this.sbi_installdbDataSet.KeyDateList, job);
                    for (int j = 5; j < dataGridView1.Columns.Count; j = j + 2)
                    {
                        string colname = dataGridView1.Columns[j].Name;
                        int id = Convert.ToInt32(r.Cells[colname].Tag);


                        if (!String.IsNullOrWhiteSpace(Convert.ToString(r.Cells[colname].Value)))
                        {
                            this.sbi_installdbDataSet.KeyDateList.FindByKeyDateListID(id).DateComplete = (DateTime)r.Cells[colname].Value;
                        }

                        if (r.Cells["chk" + colname].Value == DBNull.Value)
                        {
                            this.sbi_installdbDataSet.KeyDateList.FindByKeyDateListID(id).Complete = false;
                        }
                        else
                        {
                            this.sbi_installdbDataSet.KeyDateList.FindByKeyDateListID(id).Complete = Convert.ToBoolean(r.Cells["chk" + colname].Value);
                        }

                    }
                    this.keyDateListTableAdapter1.Update(this.sbi_installdbDataSet.KeyDateList);


                }
                foreach (DataGridViewRow r in vInstallLineSummaryAllDataGridView.Rows)
                {
                    int instid = Convert.ToInt32(r.Cells["InstallID"].Value);
                    this.installScheduleTableAdapter1.FillByInstallID(this.sbi_installdbDataSet.InstallSchedule, instid);
                    this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(instid)["RAG"] = r.Cells["RAG"].Value;
                    this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(instid)["Notes"] = r.Cells["Notes"].Value;
                    this.installScheduleTableAdapter1.Update(this.sbi_installdbDataSet.InstallSchedule);


                }


                this.jobTableAdapter.Update(this.sbi_salesdbDataSet.Job);
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
                this.siteDetailsTableAdapter1.Update(sbi_installdbDataSet.SiteDetails);
                this.contactsTableAdapter.Update(this.sbi_installdbDataSet);
            }

            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void saveBuild()
        {
            this.jobKeyDatesTableAdapter1.Fill(sbi_installdbDataSet.JobKeyDates);
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                int job = Convert.ToInt32(r.Cells["JobID"].Value);
                this.jobDetailsTableAdapter.Fill(this.sbi_installdbDataSet.JobDetails);
                this.sbi_installdbDataSet.JobDetails.FindByJobID(job)["SalesLaunchDate"] = r.Cells["SalesLaunchDate"].Value;
                this.jobDetailsTableAdapter.Update(this.sbi_installdbDataSet.JobDetails);
                this.keyDateListTableAdapter1.FillByJobID(this.sbi_installdbDataSet.KeyDateList, job);
                for (int j = 5; j < dataGridView1.Columns.Count; j = j + 2)
                {
                    string colname = dataGridView1.Columns[j].Name;
                    int id = Convert.ToInt32(r.Cells[colname].Tag);


                    if (!String.IsNullOrWhiteSpace(Convert.ToString(r.Cells[colname].Value)))
                    {
                        this.sbi_installdbDataSet.KeyDateList.FindByKeyDateListID(id).DateComplete = (DateTime)r.Cells[colname].Value;
                    }

                    if (r.Cells["chk" + colname].Value == DBNull.Value)
                    {
                        this.sbi_installdbDataSet.KeyDateList.FindByKeyDateListID(id).Complete = false;
                    }
                    else
                    {
                        this.sbi_installdbDataSet.KeyDateList.FindByKeyDateListID(id).Complete = Convert.ToBoolean(r.Cells["chk" + colname].Value);
                    }

                }
                this.keyDateListTableAdapter1.Update(this.sbi_installdbDataSet.KeyDateList);


            }
        }
        private void vInstallLineSummaryAllDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            filtered = !filtered;
            if (filtered)
            {
                this.vInstallLineSummaryAllBindingSource.Filter = "Status = 'LIVE'";
                this.button7.Text = "Show All";
            }
            else
            {
                this.vInstallLineSummaryAllBindingSource.RemoveFilter();
                this.button7.Text = "Filter Live";
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.contactsDataGridView.SelectedRows.Count != 1)
            {
                e.Cancel = true;

            }
        }

        
        private void moveToTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.contactsDataGridView.SelectedRows.Count == 1)
            {
                DataRow dr = ((DataRowView)this.contactsDataGridView.SelectedRows[0].DataBoundItem).Row;
                int cid = Convert.ToInt32(dr["ContactID"]);
                DataRow dr2 = this.sbi_installdbDataSet.Contacts.NewRow();
                dr2.ItemArray = dr.ItemArray;
                dr2["ContactID"] = -1;
                this.sbi_installdbDataSet.Contacts.Rows.Add(dr2);
                this.contactsTableAdapter.DeleteQuery(cid);


                this.contactsBindingSource.EndEdit();
                

               


                this.contactsTableAdapter.Update(this.sbi_installdbDataSet.Contacts);
                this.contactsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.Contacts, sid);

                
                

            }

            

        }

        
    }
}
