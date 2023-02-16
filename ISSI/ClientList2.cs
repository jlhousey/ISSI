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
    public partial class ClientList2 : Form
    {
        private int userID;
        //DataTable modified;
        bool filter = false;
        bool isLoaded = false;
        public string clientFilter = "";
        public string statusFilter = "";
        public string sopFilter = "";
        public Stack<object[]> undolist = new Stack<object[]>();


        public ClientList2()
        {
            InitializeComponent();
            /*Login login = new Login();
            login.ShowDialog();*/
            if (Session.loaded)
            {
                userID = Session.UserID;
                // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
                if (userID != 5)
                {
                    this.dAMTableAdapter.FillBySAM(this.sbi_salesdbDataSet.DAM, userID);
                }
                else
                {
                    this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
                }
                this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);
                // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Region' table. You can move, or remove it, as needed.
                this.regionTableAdapter.Fill(this.sbi_salesdbDataSet.Region);
                // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
                this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
                this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Site' table. You can move, or remove it, as needed.
                this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
                this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);


            }
            else
            {
                MessageBox.Show("Login failed");
                this.Load += new EventHandler(CloseOnStart);

            }
        }

        private void dAMBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.lineDataGridView.EndEdit();
            this.lineBindingSource.EndEdit();
            getmodified();

            this.Validate();


            this.lineTableAdapter.Update(sbi_salesdbDataSet.Line);
            this.dAMBindingSource.EndEdit();


            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

            //if (modified!= null)
            //{
            //    this.sbi_salesdbDataSet.Line.Merge(modified);
            //    this.lineTableAdapter.Update(sbi_salesdbDataSet.Line);
            //    this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            //    modified.Clear();
            //    this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);  
            //}

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.JobInfo' table. You can move, or remove it, as needed.
            this.jobInfoTableAdapter.Fill(this.sbi_salesdbDataSet.JobInfo);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.LineInfo1' table. You can move, or remove it, as needed.
            this.lineInfo1TableAdapter.Fill(this.sbi_salesdbDataSet.LineInfo1);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.JobsByClient' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.




        }
        private void CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int clientId = 1;
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {
                clientId = Convert.ToInt32(clientDataGridView.Rows[e.RowIndex].Cells["ClientID"].Value);

            }
            EditClient ec = new EditClient(clientId);
            ec.ShowDialog();
            RefreshAfterAdd();
        }

        private void lineDataGridView_Validated(object sender, EventArgs e)
        {

        }
        private void lineDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            //MessageBox.Show("Error happened " + anError.Context.ToString() + anError.ColumnIndex);

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

        private void OrderByComboBoxColumn()
        {



        }
        private int GetBoundValue(int id)
        {
            int site = Convert.ToInt32(this.sbi_salesdbDataSet.Job.FindByJobID(id)["SiteID"]);
            int client = Convert.ToInt32(this.sbi_salesdbDataSet.SiteDetails.FindBySiteID(site)["ClientID"]);
            int DAMID = Convert.ToInt32(this.sbi_salesdbDataSet.Client.FindByClientID(client)["DAMID"]);


            return DAMID;
        }

        private void lineDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {



        }

        private void getmodified()
        {
            DataTable changes = this.sbi_salesdbDataSet.Line.GetChanges();
            if (changes != null && changes.Rows.Count > 0)
            {

                //modified = this.sbi_salesdbDataSet.Line.Clone();
                //modified.PrimaryKey = null;
                //modified.Columns["LineID"].Unique = false;
                foreach (DataRow r in changes.Rows)
                {
                    updateAllocation(r);
                    //if (r.RowState != DataRowState.Added)
                    //{


                    //    DataRow original = modified.NewRow();
                    //    for (int i = 0; i < changes.Columns.Count; i++)
                    //    {

                    //        original[i] = r[i, DataRowVersion.Original];
                    //    }

                    //    string connectionString = Properties.Settings.Default.sbi_salesdbConnectionString;

                    //    int jID = Convert.ToInt32(original["JobID"]);
                    //    int newLine = -1;


                    //    original["Deleted"] = 1;
                    //    original["ModifiedBy"] = Session.UserID;
                    //    original["DateModified"] = DateTime.Today;
                    //    original["LineID"] = newLine;

                    //    modified.Rows.Add(original);
                    //}
                }

            }

        }
        private void updateAllocation(DataRow r)
        {
            string oi = Convert.ToString(r["OIDate"]);
            if (!String.IsNullOrWhiteSpace(oi))

            {
                {
                    int lineID = Convert.ToInt32(r["LineId"].ToString());
                    DateTime sDate = Convert.ToDateTime(Convert.ToString(r["OIDate"].ToString()));


                    DateTime firstDayOfTheMonth = new DateTime(sDate.Year, sDate.Month, 1);
                    DateTime eomonth = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    this.sbi_salesdbDataSet.Line.FindByLineID(lineID).OIAllocatedMonth = eomonth;
                }
            }
            string install = Convert.ToString(r["InstallDate"]);

            if (!String.IsNullOrWhiteSpace(install))
            {
                {
                    int lineID = Convert.ToInt32(r["LineId"].ToString());
                    DateTime sDate = Convert.ToDateTime(r["InstallDate"].ToString());

                    DateTime wedOfWeek = sDate.AddDays(3 - Convert.ToInt32(sDate.DayOfWeek));
                    DateTime firstDayOfTheMonth = new DateTime(wedOfWeek.Year, wedOfWeek.Month, 1);
                    DateTime eomonth = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    this.sbi_salesdbDataSet.Line.FindByLineID(lineID).SalesAllocatedMonth = eomonth;
                }
            }
        }

        private void lineDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {
                if (e.ColumnIndex < 5)
                {


                    int jobId = Convert.ToInt32(lineDataGridView.Rows[e.RowIndex].Cells["JobID"].Value);
                    int siteID = Convert.ToInt32(this.sbi_salesdbDataSet.Job.FindByJobID(jobId)["SiteID"]);
                    int clientID = Convert.ToInt32(this.sbi_salesdbDataSet.SiteDetails.FindBySiteID(siteID)["ClientID"]);


                    EditJob ej = new EditJob(clientID, jobId);
                    ej.ShowDialog();
                    this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                    this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
                    this.jobInfoTableAdapter.Fill(this.sbi_salesdbDataSet.JobInfo);
                }


                else
                {
                    int lineId = Convert.ToInt32(lineDataGridView.Rows[e.RowIndex].Cells["LineID"].Value);
                    EditLine el = new EditLine(lineId);
                    el.ShowDialog();
                    this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                    this.jobInfoTableAdapter.Fill(this.sbi_salesdbDataSet.JobInfo);
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //DataTable dt = new DataTable();
            //dt.Columns.Add("JobID");
            //dt.Columns.Add("ClientName");
            //foreach (DataGridViewRow r in lineDataGridView.Rows)
            //{
            //    DataRow row = dt.NewRow();
            //    row["JobID"] = r.Cells["JobID"].Value;
            //    row["ClientName"] = Convert.ToString(r.Cells["Client"].FormattedValue.ToString());
            //    dt.Rows.Add(row);
            //}


            using (FilterByDialog fbd = new FilterByDialog("JobId", "Client", lineDataGridView))
            {

                var result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filter = fbd.criteria;

                    if (String.IsNullOrWhiteSpace(this.lineBindingSource.Filter))
                    {
                        this.lineBindingSource.Filter = "(" + filter + ")";
                    }
                    else
                    {
                        this.lineBindingSource.Filter += " AND (" + filter + ")";
                    }

                    button2.Enabled = false;

                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FilterByDialog fbd = new FilterByDialog("StatusID", "Name", this.sbi_salesdbDataSet.Client, true))
            {

                var result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filter = fbd.criteria;
                    string filter2 = filter.Substring(8);
                    filter = "Status" + filter2;

                    if (String.IsNullOrWhiteSpace(this.lineBindingSource.Filter))
                    {
                        this.lineBindingSource.Filter = "(" + filter + ")";
                    }
                    else
                    {
                        string filter1 = this.lineBindingSource.Filter;
                        this.lineBindingSource.Filter += " AND (" + filter + ")";
                    }
                    button3.Enabled = false;

                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FilterByDialog fbd = new FilterByDialog("JobId", "JobId", lineDataGridView))
            {

                var result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filter = fbd.criteria;

                    if (String.IsNullOrWhiteSpace(this.lineBindingSource.Filter))
                    {
                        this.lineBindingSource.Filter = "(" + filter + ")";
                    }
                    else
                    {
                        this.lineBindingSource.Filter += " AND (" + filter + ")";
                    }

                    button1.Enabled = false;

                }

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lineBindingSource.RemoveFilter();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void clientDataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {




        }

        private void clientDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            lineBindingSource.RemoveFilter();
            filter = false;
        }

        private void lineDataGridView_Paint(object sender, PaintEventArgs e)
        {

            foreach (DataGridViewRow r in lineDataGridView.Rows)
            {
                if (!r.IsNewRow)
                {
                    if (GetBoundValue(Convert.ToInt32(r.Cells["JobID"].Value)) != Convert.ToInt32(r.Cells["DAMID"].Value))
                    {
                        r.DefaultCellStyle.BackColor = Color.Salmon;

                    }
                    if ((Convert.ToInt32(r.Cells["StatusID"].Value)) < 4)
                    {
                        r.DefaultCellStyle.ForeColor = Color.Red;

                    }
                }
            }
            isLoaded = true;
        }

        private void ClientList2_Shown(object sender, EventArgs e)
        {

            filter = true;
        }

        public void saveChanges()
        {
            int pos = this.lineDataGridView.FirstDisplayedScrollingRowIndex;
            this.Validate();
            this.lineBindingSource.EndEdit();





            getmodified();

            this.lineBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            //if (modified != null)
            //{
            //    this.sbi_salesdbDataSet.Line.Merge(modified);
            //    this.lineTableAdapter.Update(sbi_salesdbDataSet.Line);
            //    this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            //    modified.Clear();
            //    this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
            //}
            if (pos != -1)
            {
                this.lineDataGridView.FirstDisplayedScrollingRowIndex = pos;
            }

        }

        public void RefreshAfterAdd()
        {
            int csi = comboBox1.SelectedIndex;
            this.lineBindingSource.RemoveFilter();

            if (userID != 5)
            {
                this.dAMTableAdapter.FillBySAM(this.sbi_salesdbDataSet.DAM, userID);
            }
            else
            {
                this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            }
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
            this.jobInfoTableAdapter.Fill(this.sbi_salesdbDataSet.JobInfo);
            this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
            this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);


            string filter1 = "";
            string filter2 = "";
            string filter3 = "";
            string filter4 = "";
            string filter5 = "";

            if (!String.IsNullOrWhiteSpace(clientFilter))
            {
                foreach (DataGridViewRow r in this.lineDataGridView.Rows)
                {
                    var criteriaList = new List<string>();

                    if (Convert.ToString(r.Cells["Client"].FormattedValue.ToString()) == clientFilter)
                    {
                        if (String.IsNullOrWhiteSpace(filter1))
                        {
                            string chk = Convert.ToString(r.Cells["JobID"].Value.ToString());
                            if (!String.IsNullOrWhiteSpace(chk) && !criteriaList.Contains(chk))
                            {
                                filter1 += "JobID = " + chk;
                                criteriaList.Add(chk);
                            }


                        }
                        else
                        {
                            string chk = Convert.ToString(r.Cells["JobID"].Value.ToString());
                            if (!String.IsNullOrWhiteSpace(chk) && !criteriaList.Contains(chk))
                            {
                                filter1 += " OR JobID = " + chk;
                            }


                        }
                    }
                }

            }


            if (!String.IsNullOrWhiteSpace(sopFilter))
            {
                foreach (DataGridViewRow r in this.lineDataGridView.Rows)
                {
                    var criteriaList = new List<string>();
                    if (Convert.ToString(r.Cells["JobID"].FormattedValue.ToString()) == sopFilter)
                    {
                        if (String.IsNullOrWhiteSpace(filter2))
                        {
                            string chk = Convert.ToString(r.Cells["JobID"].Value.ToString());
                            if (!String.IsNullOrWhiteSpace(chk) && !criteriaList.Contains(chk))
                            {
                                filter2 += "JobID = " + chk;
                                criteriaList.Add(chk);
                            }


                        }
                        else
                        {
                            string chk = Convert.ToString(r.Cells["JobID"].Value.ToString());
                            if (!String.IsNullOrWhiteSpace(chk) && !criteriaList.Contains(chk))
                            {
                                filter2 += " OR JobID = " + chk;
                            }


                        }
                    }
                }

            }

            if (!String.IsNullOrWhiteSpace(statusFilter))
            {
                filter3 = "StatusID = " + statusFilter;
            }

            if (String.IsNullOrWhiteSpace(filter1) || String.IsNullOrWhiteSpace(filter2))
            {
                filter4 = filter1 + filter2;
            }
            else
            {
                filter4 = "(" + filter1 + ") AND (" + filter2 + ")";
            }

            if (String.IsNullOrWhiteSpace(filter4) || String.IsNullOrWhiteSpace(filter3))
            {
                filter5 = filter4 + filter3;
            }
            else
            {
                filter5 = "(" + filter4 + ") AND (" + filter3 + ")";
            }

            this.lineBindingSource.Filter = filter5;
            comboBox1.SelectedIndex = csi;
        }
        public void RefreshAfterAdd(int jobID)
        {

            int csi = comboBox1.SelectedIndex;
            if (jobID != 0)
            {
                if (!String.IsNullOrWhiteSpace(this.lineBindingSource.Filter))
                {
                    this.lineBindingSource.Filter = "(" + this.lineBindingSource.Filter + ") OR JobID = " + jobID;
                }
            }
            int pos = this.lineDataGridView.FirstDisplayedScrollingRowIndex;
            if (userID != 5)
            {
                this.dAMTableAdapter.FillBySAM(this.sbi_salesdbDataSet.DAM, userID);
            }
            else
            {
                this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            }
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
            this.jobInfoTableAdapter.Fill(this.sbi_salesdbDataSet.JobInfo);
            this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
            this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);

            if (pos != -1)
            {
                this.lineDataGridView.FirstDisplayedScrollingRowIndex = pos + 1;
            }

            comboBox1.SelectedIndex = csi;
        }

        public void RefreshAfterAdd(string filter)
        {

            int csi = comboBox1.SelectedIndex;
            if (!String.IsNullOrWhiteSpace(filter))
            {
                if (!String.IsNullOrWhiteSpace(this.lineBindingSource.Filter))
                {
                    this.lineBindingSource.Filter = "(" + this.lineBindingSource.Filter + ") OR (" + filter + ")";
                }
            }
            int pos = this.lineDataGridView.FirstDisplayedScrollingRowIndex;
            if (userID != 5)
            {
                this.dAMTableAdapter.FillBySAM(this.sbi_salesdbDataSet.DAM, userID);
            }
            else
            {
                this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            }
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
            this.jobInfoTableAdapter.Fill(this.sbi_salesdbDataSet.JobInfo);
            this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
            this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);

            this.lineDataGridView.FirstDisplayedScrollingRowIndex = pos + 1;
            comboBox1.SelectedIndex = csi;
        }
        private void clientDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (filter)
            {

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                lineBindingSource.RemoveFilter();
                string name = Convert.ToString(clientDataGridView.Rows[e.RowIndex].Cells["ClientName"].Value);
                string criteria = "";
                var criteriaList = new List<string>();



                foreach (DataGridViewRow r in lineDataGridView.Rows)
                {

                    if (Convert.ToString(r.Cells["Client"].FormattedValue) == name)
                    {
                        string chk = Convert.ToString(r.Cells["JobID"].Value);
                        if (!String.IsNullOrWhiteSpace(chk) && !criteriaList.Contains(chk))
                        {
                            criteriaList.Add(chk);
                            criteria += "JobID = " + r.Cells["JobID"].Value.ToString() + " OR ";
                        }



                    }
                }
                if (!String.IsNullOrWhiteSpace(criteria))
                {
                    criteria = criteria.Substring(0, criteria.Length - 4);
                    //MessageBox.Show(criteria);

                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    this.lineBindingSource.Filter = "(" + criteria + ")";

                }
                else
                {
                    //MessageBox.Show("No current active jobs for this client");
                }
                filter = true;

            }

            else
            {
                filter = true;
            }

        }

        private void lineDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.lineDataGridView.Rows[e.RowIndex].Selected = true;

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.lineDataGridView.SelectedRows.Count == 1)
            {
                DataRow dr = ((DataRowView)this.lineDataGridView.SelectedRows[0].DataBoundItem).Row;


                /* int jID = Convert.ToInt32(dr["JobID"]);
                 int samID = Convert.ToInt32(dr["SAMID"]);                 
                 int damID = Convert.ToInt32(dr["DAMID"]);


                     string connectionString = Properties.Settings.Default.sbi_salesdbConnectionString;
                     string commandText = "CreateLine";

                     int newLine;




                      using (SqlConnection conn = new SqlConnection(connectionString))
                         {
                             using (SqlCommand cmd = new SqlCommand(commandText, conn))
                             {
                                 cmd.CommandType = CommandType.StoredProcedure;

                                 cmd.Parameters.Add(new SqlParameter("@JobID", jID));
                                 cmd.Parameters.Add(new SqlParameter("@DamID", damID));
                                 cmd.Parameters.Add(new SqlParameter("@SAMID", samID));


                                 SqlParameter LineID = new SqlParameter("@LineID", SqlDbType.Int);
                                 LineID.Direction = ParameterDirection.Output;
                                 cmd.Parameters.Add(LineID);

                                 conn.Open();
                                 cmd.ExecuteNonQuery();

                                 //MessageBox.Show("LineID" + LineID.Value);
                                 newLine = Convert.ToInt32(LineID.Value);
                             }
                         }
                         */
                DataRow dr2 = this.sbi_salesdbDataSet.Line.NewRow();
                dr2.ItemArray = dr.ItemArray;
                dr2["LineID"] = -1;
                this.sbi_salesdbDataSet.Line.Rows.Add(dr2);
                this.lineBindingSource.EndEdit();
                getmodified();

                this.Validate();


                this.lineTableAdapter.Update(sbi_salesdbDataSet.Line);
                this.dAMBindingSource.EndEdit();


                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

                //if (modified != null)
                //{
                //    this.sbi_salesdbDataSet.Line.Merge(modified);
                //    this.lineTableAdapter.Update(sbi_salesdbDataSet.Line);
                //    this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
                //    modified.Clear();
                //    this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                //}

            }

            this.lineDataGridView.Sort(this.lineDataGridView.Columns["JobID"], ListSortDirection.Ascending);



        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.lineDataGridView.SelectedRows.Count != 1)
            {
                e.Cancel = true;

            }
        }

        private void lineDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lineDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (isLoaded)
            //{
            //    int lineID;

            //    lineID = Convert.ToInt32(clientDataGridView.Rows[e.RowIndex].Cells["LineID"].Value);
            //    object[] changedRow = this.sbi_salesdbDataSet.Line.FindByLineID(lineID).ItemArray;
            //    undolist.Push(changedRow);
            //}
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //object[] changedRow = undolist.Pop();
            //DataRow newRow = this.sbi_salesdbDataSet.Line.NewRow();
            //newRow.ItemArray = changedRow;
            //int uID = Convert.ToInt32(newRow["LineID"]);
            //this.sbi_salesdbDataSet.Line.FindByLineID(uID).ItemArray = changedRow;

        }
        private void ClientList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                SearchDialog searchForm = new SearchDialog(lineDataGridView);
                searchForm.Show();
            }
            else
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    PasteFromExcel(lineDataGridView);
                }
            }

        }
        public void PasteFromExcel(DataGridView grid)
        {

            if (grid.SelectedCells.Count > 0)
            {
                char[] rowSplitter = { '\r', '\n' };
                char[] columnSplitter = { '\t' };
                //get the text from clipboard
                IDataObject dataInClipboard = Clipboard.GetDataObject();
                if (dataInClipboard != null)
                {
                    string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);
                    //split it into lines
                    if (stringInClipboard != null)
                    {
                        string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
                        //get the row and column of selected cell in grid

                        int rowZero = grid.SelectedCells[0].RowIndex;
                        int columnZero = grid.SelectedCells[0].ColumnIndex;
                        int rowMax = grid.SelectedCells[grid.SelectedCells.Count - 1].RowIndex;
                        int columnMax = grid.SelectedCells[grid.SelectedCells.Count - 1].ColumnIndex;
                        int rlength = columnZero - columnMax + 1;
                        int cheight = rowZero - rowMax + 1;
                        int r = Math.Min(rowZero, rowMax);
                        int c = Math.Min(columnZero, columnMax);
                        //add rows into grid to fit clipboard lines
                        if (grid.SelectedCells.Count > 1 && (cheight != rowsInClipboard.Length || rlength != rowsInClipboard[0].Split(columnSplitter).Length))
                        {
                            MessageBox.Show("Selection does not match clipboard contents");
                        }
                        // loop through the lines, split them into cells and place the values in the corresponding cell.
                        else
                        {
                            for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
                            {
                                if (grid.RowCount - 1 >= r + iRow)
                                {
                                    //split row into cell values
                                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                                    //cycle through cell values
                                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                                    {
                                        //assign cell value, only if it within columns of the grid
                                        if (grid.ColumnCount - 1 >= c + iCol)
                                        {
                                            grid.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
