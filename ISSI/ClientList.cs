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
    public partial class ClientList : Form
    {
        private int userID;

        public ClientList()
        {
            InitializeComponent();
            /*Login login = new Login();
            login.ShowDialog();*/
            if (Session.loaded)
            {
                userID = Session.UserID;
                // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
                this.dAMTableAdapter.FillBySAM(this.sbi_salesdbDataSet.DAM, userID);
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



            this.Validate();

            this.lineBindingSource.EndEdit();
            this.lineTableAdapter.Update(sbi_salesdbDataSet.Line);
            this.dAMBindingSource.EndEdit();


            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
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
        private void lineDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int banding = 1;
            int jobid = 0;
            this.jobTableAdapter1.Fill(this.sbi_salesdbDataSet.Job);
            this.siteDetailsTableAdapter1.Fill(this.sbi_salesdbDataSet.SiteDetails);
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);

            foreach (DataGridViewRow r in lineDataGridView.Rows)

            {

                if (!r.IsNewRow)
                {
                    int j = 0;
                    int s = 0;
                    int c = 0;
                    if (Int32.TryParse(r.Cells["JobID"].Value.ToString(), out j))
                    {
                        if (jobid != j)
                        {
                            banding = banding + 1;
                        }

                        if (banding % 2 > 0)
                        {
                            r.DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                        }
                        else
                        {
                            r.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        }


                        jobid = j;
                        string x = this.sbi_salesdbDataSet.Job.FindByJobID(j)["SiteID"].ToString();
                        string y = this.sbi_salesdbDataSet.Job.FindByJobID(j)["HouseType"].ToString();
                        r.Cells["HouseType"].Value = y;
                        if (Int32.TryParse(x, out s))
                        {
                            r.Cells["SiteID"].Value = this.sbi_salesdbDataSet.SiteDetails.FindBySiteID(s)["Name"];

                            if (Int32.TryParse(this.sbi_salesdbDataSet.SiteDetails.FindBySiteID(s)["ClientID"].ToString(), out c))
                            {
                                r.Cells["Client"].Value = this.sbi_salesdbDataSet.Client.FindByClientID(c)["Name"];
                            }
                        }
                    }




                }

            }
            this.sbi_salesdbDataSet.Line.AcceptChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable changes = this.sbi_salesdbDataSet.Line.GetChanges();
            foreach (DataRow r in changes.Rows)
            {
                DataRow original = (DataRow)r[0, DataRowVersion.Original];
                original["Deleted"] = 1;
                original["ModifiedBy"] = Session.UserID;
                original["ModifiedDate"] = DateTime.Today;
                original["LineID"] = DBNull.Value;
                this.sbi_salesdbDataSet.Line.Rows.Add(original);


            }
        }

        private void lineDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {
                switch (e.ColumnIndex)
                {
                    case 1:

                        int jobId = Convert.ToInt32(lineDataGridView.Rows[e.RowIndex].Cells["JobID"].Value);
                        int clientID = Convert.ToInt32(lineDataGridView.Rows[e.RowIndex].Cells["ClientID"].Value);


                        EditJob ej = new EditJob(clientID, jobId);
                        ej.ShowDialog();
                        this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                        break;

                    case 2:
                        int siteId = Convert.ToInt32(lineDataGridView.Rows[e.RowIndex].Cells["SiteID"].Value);


                        EditSite es = new EditSite(siteId);
                        es.ShowDialog();
                        this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                        break;

                    default:


                        int lineId = Convert.ToInt32(lineDataGridView.Rows[e.RowIndex].Cells["LineID"].Value);
                        EditLine el = new EditLine(lineId);
                        el.ShowDialog();
                        this.lineTableAdapter.FillByStatus(this.sbi_salesdbDataSet.Line);
                        break;

                }
            }
        }
    }
}
