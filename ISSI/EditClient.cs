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
    public partial class EditClient : Form
    {
        public EditClient()
        {
            InitializeComponent();
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);

            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.sbi_salesdbDataSet.Region);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.JobsByClient' table. You can move, or remove it, as needed.
            this.jobsByClientTableAdapter.Fill(this.sbi_salesdbDataSet.JobsByClient);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
        }

        public EditClient(int devID, bool newItem)
        {
            InitializeComponent();
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);

            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.sbi_salesdbDataSet.Region);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.JobsByClient' table. You can move, or remove it, as needed.
            this.jobsByClientTableAdapter.Fill(this.sbi_salesdbDataSet.JobsByClient);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            if (newItem)
            {
                button1.Visible = false;
                DataRow dr = sbi_salesdbDataSet.Client.NewRow();
                dr["ClientID"] = -1;
                dr["Name"] = "New Client";
                dr["RegionID"] = 1;
                dr["DAMID"] = 1;
                dr["DeveloperID"] = devID;
                sbi_salesdbDataSet.Client.Rows.Add(dr);
                this.clientBindingSource.Position = sbi_salesdbDataSet.Client.Rows.IndexOf(dr);
                comboBox3.SelectedValue = devID;
            }

        }

        public EditClient(int clientId)
        {
            InitializeComponent();
            this.clientTableAdapter.FillByClient(this.sbi_salesdbDataSet.Client, clientId);

            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Developer' table. You can move, or remove it, as needed.
            this.jobsByClientTableAdapter.FillByClient(this.sbi_salesdbDataSet.JobsByClient, clientId);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.sbi_salesdbDataSet.Region);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.JobsByClient' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Region' table. You can move, or remove it, as needed.
            jobsByClientDataGridView.Sort(SOPID, ListSortDirection.Descending);


        }

        private void clientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            this.Close();

        }

        private void EditClient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.siteDetailsTableAdapter.Fill(this.sbi_salesdbDataSet.SiteDetails);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            DataRowView currentClient = (DataRowView)clientBindingSource.Current;
            //currentPO["Name"] = tbPOSOP.Text;

            int clientID = Convert.ToInt32(currentClient["ClientID"]);
            EditJob ej = new EditJob(clientID, true);
            ej.ShowDialog();
            this.jobsByClientTableAdapter.FillByClient(this.sbi_salesdbDataSet.JobsByClient, clientID);
            jobsByClientDataGridView.Sort(SOPID, ListSortDirection.Descending);

        }

        private void jobsByClientDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void jobsByClientDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView currentClient = (DataRowView)clientBindingSource.Current;
            int clientID = Convert.ToInt32(currentClient["ClientID"]);
            int siteId = 1;
            int jobId = 1;
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {
                if (e.ColumnIndex == 2)
                {
                    siteId = Convert.ToInt32(jobsByClientDataGridView.Rows[e.RowIndex].Cells["SiteID"].Value);


                    EditSite es = new EditSite(siteId);
                    es.ShowDialog();
                    this.jobsByClientTableAdapter.FillByClient(this.sbi_salesdbDataSet.JobsByClient, clientID);
                    jobsByClientDataGridView.Sort(SOPID, ListSortDirection.Descending);
                }
                else
                {
                    jobId = Convert.ToInt32(jobsByClientDataGridView.Rows[e.RowIndex].Cells["JobID"].Value);
                    EditJob ej = new EditJob(clientID, jobId);
                    ej.ShowDialog();
                    this.jobsByClientTableAdapter.FillByClient(this.sbi_salesdbDataSet.JobsByClient, clientID);
                    jobsByClientDataGridView.Sort(SOPID, ListSortDirection.Descending);
                }
            }
        }
    }
}
