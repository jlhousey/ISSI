using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISSI
{
    public partial class SOPReg : Form
    {
        public DataTable modified;
        public string clientFilter = "";
        public string statusFilter = "";
        public string sopFilter = "";

        public SOPReg()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;


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
                    //DataRow original = modified.NewRow();
                    //for (int i = 0; i < changes.Columns.Count; i++)
                    //{

                    //    original[i] = r[i, DataRowVersion.Original];
                    //}

                    //string connectionString = Properties.Settings.Default.sbi_salesdbConnectionString;

                    //int jID = Convert.ToInt32(original["JobID"]);
                    //int newLine = -1;


                    //original["Deleted"] = 1;
                    //original["ModifiedBy"] = Session.UserID;
                    //original["DateModified"] = DateTime.Today;
                    //original["LineID"] = newLine;

                    //modified.Rows.Add(original);
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

        private void lineBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            int pos = this.lineDataGridView.FirstDisplayedScrollingRowIndex;
            this.Validate();
            this.lineDataGridView.EndEdit();
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
            //    this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            //}
            this.lineDataGridView.FirstDisplayedScrollingRowIndex = pos;
            this.lineDataGridView.Rows[pos].Selected = true;

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
            //    this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            //}
            this.lineDataGridView.FirstDisplayedScrollingRowIndex = pos;

        }
        public void RefreshAfterAdd()
        {
            this.lineBindingSource.RemoveFilter();

            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            this.jobInfoTableAdapter1.Fill(this.sbi_salesdbDataSet.JobInfo);
            this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
            this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);

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

        }
        public void RefreshAfterAdd(int jobID)
        {
            if (jobID != 0)
            {
                if (!String.IsNullOrWhiteSpace(this.lineBindingSource.Filter))
                {
                    this.lineBindingSource.Filter = "(" + this.lineBindingSource.Filter + ") OR JobID = " + jobID;
                }
            }
            int pos = this.lineDataGridView.FirstDisplayedScrollingRowIndex;
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            this.jobInfoTableAdapter1.Fill(this.sbi_salesdbDataSet.JobInfo);
            this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
            this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            this.lineDataGridView.FirstDisplayedScrollingRowIndex = pos + 1;

        }

        public void RefreshAfterAdd(string filter)
        {
            if (!String.IsNullOrWhiteSpace(filter))
            {
                if (!String.IsNullOrWhiteSpace(this.lineBindingSource.Filter))
                {
                    this.lineBindingSource.Filter = "(" + this.lineBindingSource.Filter + ") OR (" + filter + ")";
                }
            }
            int pos = this.lineDataGridView.FirstDisplayedScrollingRowIndex;
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            this.jobInfoTableAdapter1.Fill(this.sbi_salesdbDataSet.JobInfo);
            this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
            this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            this.lineDataGridView.FirstDisplayedScrollingRowIndex = pos + 1;

        }



        private void SOPReg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            this.jobInfoTableAdapter1.Fill(this.sbi_salesdbDataSet.JobInfo);
            this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
            this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
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
        private void lineDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            int jobId = Convert.ToInt32(lineDataGridView.Rows[r].Cells["JobID"].Value);
            int siteID = Convert.ToInt32(this.sbi_salesdbDataSet.Job.FindByJobID(jobId)["SiteID"]);
            int clientID = Convert.ToInt32(this.sbi_salesdbDataSet.SiteDetails.FindBySiteID(siteID)["ClientID"]);
            int lineId = Convert.ToInt32(lineDataGridView.Rows[r].Cells["LineID"].Value);

            this.lineBindingSource.EndEdit();
            getmodified();
            this.Validate();
            this.lineBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            //if (modified != null)
            //{
            //    this.sbi_salesdbDataSet.Line.Merge(modified);
            //    this.lineTableAdapter.Update(sbi_salesdbDataSet.Line);
            //    this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            //    modified.Clear();

            //}
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {
                int pos = this.lineDataGridView.FirstDisplayedScrollingRowIndex;
                switch (e.ColumnIndex)
                {
                    case 0:




                        EditJob ej = new EditJob(clientID, jobId);
                        ej.ShowDialog();
                        switch (comboBox1.SelectedItem.ToString())
                        {
                            case "All":
                                this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
                                break;
                            case "Outstanding":
                                this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                                break;
                            case "Completed":
                                this.lineTableAdapter.FillByCompleted(this.sbi_salesdbDataSet.Line);

                                break;
                            default:
                                this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
                                break;

                        }
                        this.jobInfoTableAdapter1.Fill(this.sbi_salesdbDataSet.JobInfo);
                        this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
                        this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
                        break;



                    default:



                        EditLine el = new EditLine(lineId);
                        el.ShowDialog();
                        switch (Convert.ToString(comboBox1.SelectedItem.ToString()))
                        {
                            case "All":
                                this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
                                break;
                            case "Outstanding":
                                this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                                break;
                            case "Completed":
                                this.lineTableAdapter.FillByCompleted(this.sbi_salesdbDataSet.Line);
                                break;
                            default:
                                this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);


                                break;


                        }
                        break;

                }
                this.lineDataGridView.FirstDisplayedScrollingRowIndex = pos;
                this.lineDataGridView.Rows[pos].Selected = true;
            }
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "All":
                    this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
                    break;
                case "Outstanding":
                    this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                    break;
                case "Completed":
                    this.lineTableAdapter.FillByCompleted(this.sbi_salesdbDataSet.Line);
                    break;

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
                    clientFilter = fbd.filtervalue;

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
            using (FilterByDialog fbd = new FilterByDialog("StatusID", "Name", this.sbi_salesdbDataSet.Status, true))
            {

                var result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filter = fbd.criteria;
                    statusFilter = fbd.filtervalue;
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
            using (FilterByDialog fbd = new FilterByDialog("JobID", "JobID", lineDataGridView))
            {

                var result = fbd.ShowDialog();
                sopFilter = fbd.filtervalue;
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
            clientFilter = "";
            statusFilter = "";
            sopFilter = "";
        }

        private void SOPReg_KeyDown(object sender, KeyEventArgs e)
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

        private void lineDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int lineCount = this.lineDataGridView.SelectedCells.Count;
            double sum = 0;
            string sumlabel = "";
            try
            {
                foreach (DataGridViewCell c in this.lineDataGridView.SelectedCells)
                {
                    if (c.OwningColumn.Name == "LineValue")
                    {
                        sum += Convert.ToDouble(c.Value);
                    }

                }
                sumlabel = sum.ToString();
            }
            catch
            {
                sumlabel = "n/a";
            }
            toolStripStatusLabel1.Text = "Count: " + lineCount + "  Sum: " + sumlabel;
            statusStrip1.Refresh();

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        public void RefreshInstall()
        {
            this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
            this.installScheduleTableAdapter1.Fill(this.sbi_salesdbDataSet.InstallSchedule);
            foreach (DataGridViewRow r in lineDataGridView.Rows)
            {
                int iid = 0;
                if (Int32.TryParse(r.Cells["InstallID"].Value.ToString(), out iid))
                {

                    if (iid != 0)
                    {
                        DataRow ir = this.sbi_salesdbDataSet.InstallSchedule.FindByInstallID(iid);
                        if (ir != null)
                        {

                            if (!String.IsNullOrWhiteSpace(Convert.ToString(ir["InstallDate"])))
                            {
                                DateTime iDate = Convert.ToDateTime(Convert.ToString(ir["InstallDate"]));
                                if (iDate.Year < 2100)
                                {
                                    if (String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["InstallDate"].Value)) || iDate != Convert.ToDateTime(r.Cells["InstallDate"].Value.ToString()))
                                    {
                                        DialogResult result = MessageBox.Show("SOP" + r.Cells["JobID"].FormattedValue.ToString() + " has moved on the install schedule to W/C " + Convert.ToDateTime(ir["InstallDate"]).ToShortDateString(), "Move job?", MessageBoxButtons.YesNo);

                                        if (result == DialogResult.Yes)
                                        {
                                            r.Cells["InstallDate"].Value = ir["InstallDate"];

                                        }

                                    }
                                }
                            }
                        }
                    }
                }

            }

            saveChanges();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in lineDataGridView.Rows)
            {
                if (!r.IsNewRow)
                {

                    if ((Convert.ToInt32(r.Cells["StatusID"].Value)) < 4)
                    {
                        r.DefaultCellStyle.ForeColor = Color.Red;

                    }
                }
            }
        }
    }

}
