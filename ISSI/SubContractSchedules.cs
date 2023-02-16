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
    public partial class SubContractSchedules : Form
    {
        public SubContractSchedules()
        {
            InitializeComponent();
        }

        private void SubContractSchedules_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vSubConInstallSummary' table. You can move, or remove it, as needed.
            this.vSubConInstallSummaryTableAdapter.Fill(this.sbi_installdbDataSet.vSubConInstallSummary);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SubConAreas' table. You can move, or remove it, as needed.
            this.subConAreasTableAdapter.Fill(this.sbi_installdbDataSet.SubConAreas);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vSubConInstallSummary' table. You can move, or remove it, as needed.
            this.vSubConInstallSummaryTableAdapter.Fill(this.sbi_installdbDataSet.vSubConInstallSummary);

        }

        private void subConAreasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.subConAreasBindingSource.EndEdit();
            this.reqSubConTableAdapter1.Fill(this.sbi_installdbDataSet.ReqSubCon);

            foreach(DataGridViewRow r in vSubConInstallSummaryDataGridView.Rows)
            {
                int rcid = Convert.ToInt32(r.Cells["ReqSCID"].Value);
                DataRow s = this.sbi_installdbDataSet.ReqSubCon.FindByReqSCID(rcid);
                s["Supplier"] = r.Cells["Supplier"].Value;
                s["CheckDate"] = r.Cells["CheckDate"].Value;
                s["InstallDate"] = r.Cells["SCInstall"].Value;
                s["SCIRAG"] = r.Cells["SCIRAG"].Value;
                s["CMRAG"] = r.Cells["CMRAG"].Value;
                s["Notes"] = r.Cells["SubConNotes"].Value;
                s["InstallNotes"] = r.Cells["InstallNotes"].Value;

            }
            this.reqSubConTableAdapter1.Update(this.sbi_installdbDataSet.ReqSubCon);
            this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);

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

        private void vSubConInstallSummaryDataGridView_Paint(object sender, PaintEventArgs e)
        {
            //this.vSubConInstallSummaryDataGridView.Sort(vSubConInstallSummaryDataGridView.Columns["InstallDate"], ListSortDirection.Ascending);
            foreach (DataGridViewRow r in vSubConInstallSummaryDataGridView.Rows)
            {
                if (!r.IsNewRow)
                {

                    
                    Color col = ColorTranslator.FromHtml("#" + r.Cells["ColourCode"].Value.ToString());
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
                    if (r.Cells["CMRAG"].Value != null && r.Cells["CMRAG"].Value != DBNull.Value)
                    {
                        if ((Convert.ToInt32(r.Cells["CMRAG"].Value)) == 1)
                        {
                            r.Cells["SubConNotes"].Style.BackColor = Color.Red;
                            r.Cells["CheckDate"].Style.BackColor = Color.Red;
                        }
                        if ((Convert.ToInt32(r.Cells["CMRAG"].Value)) == 2)
                        {
                            r.Cells["SubConNotes"].Style.BackColor = Color.Orange;
                            r.Cells["CheckDate"].Style.BackColor = Color.Orange;
                        }
                        if ((Convert.ToInt32(r.Cells["CMRAG"].Value)) == 3)
                        {
                            r.Cells["SubConNotes"].Style.BackColor = Color.Green;
                            r.Cells["CheckDate"].Style.BackColor = Color.Green;
                        }
                    }
                    if (r.Cells["SCIRAG"].Value != null && r.Cells["SCIRAG"].Value != DBNull.Value)
                    {
                        if ((Convert.ToInt32(r.Cells["SCIRAG"].Value)) == 1)
                        {
                            r.Cells["SCInstall"].Style.BackColor = Color.Red;

                        }
                        if ((Convert.ToInt32(r.Cells["SCIRAG"].Value)) == 2)
                        {
                            r.Cells["SCInstall"].Style.BackColor = Color.Orange;

                        }
                        if ((Convert.ToInt32(r.Cells["SCIRAG"].Value)) == 3)
                        {
                            r.Cells["SCInstall"].Style.BackColor = Color.Green;

                        }
                    }
                }
            }
        }

        private void SubContractSchedules_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Save Changes?", "Save Changes?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                this.Validate();
                this.subConAreasBindingSource.EndEdit();
                this.reqSubConTableAdapter1.Fill(this.sbi_installdbDataSet.ReqSubCon);

                foreach (DataGridViewRow r in vSubConInstallSummaryDataGridView.Rows)
                {
                    int rcid = Convert.ToInt32(r.Cells["ReqSCID"].Value);
                    DataRow s = this.sbi_installdbDataSet.ReqSubCon.FindByReqSCID(rcid);
                    s["Supplier"] = r.Cells["Supplier"].Value;
                    s["CheckDate"] = r.Cells["CheckDate"].Value;
                    s["InstallDate"] = r.Cells["SCInstall"].Value;
                    s["SCIRAG"] = r.Cells["SCIRAG"].Value;
                    s["CMRAG"] = r.Cells["CMRAG"].Value;
                    s["Notes"] = r.Cells["SubConNotes"].Value;
                    s["InstallNotes"] = r.Cells["InstallNotes"].Value;

                }
                this.reqSubConTableAdapter1.Update(this.sbi_installdbDataSet.ReqSubCon);
                this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (FilterByDialog fbd = new FilterByDialog("JobType", "Product", vSubConInstallSummaryDataGridView))
            {

                var result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filter = fbd.criteria;

                    if (String.IsNullOrWhiteSpace(this.vSubConInstallSummaryBindingSource.Filter))
                    {
                        this.vSubConInstallSummaryBindingSource.Filter = "(" + filter + ")";
                    }
                    else
                    {
                        this.vSubConInstallSummaryBindingSource.Filter += " AND (" + filter + ")";
                    }

                    button1.Enabled = false;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FilterByDialog fbd = new FilterByDialog("InstallID", "Supplier", vSubConInstallSummaryDataGridView))
            {

                var result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filter = fbd.criteria;

                    if (String.IsNullOrWhiteSpace(this.vSubConInstallSummaryBindingSource.Filter))
                    {
                        this.vSubConInstallSummaryBindingSource.Filter = "(" + filter + ")";
                    }
                    else
                    {
                        this.vSubConInstallSummaryBindingSource.Filter += " AND (" + filter + ")";
                    }

                    button2.Enabled = false;

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            vSubConInstallSummaryBindingSource.RemoveFilter();
            button1.Enabled = true;
            button2.Enabled = true;
            
            
        
    }
    }
}
