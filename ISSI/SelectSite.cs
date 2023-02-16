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
    public partial class SelectSite : Form
    {
        public int clientID;
        public int siteID;
        public SelectSite()
        {
            InitializeComponent();
        }

        private void clientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }

        private void SelectSite_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.siteDetailsTableAdapter.Fill(this.sbi_salesdbDataSet.SiteDetails);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.siteDetailsTableAdapter.FillBySorted(this.sbi_salesdbDataSet.SiteDetails);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Nothing Selected");

            }
            else
            {
                clientID = Convert.ToInt32(comboBox1.SelectedValue);
                siteID = Convert.ToInt32(comboBox2.SelectedValue);

                EditSite es = new EditSite(siteID);
                es.ShowDialog();
                this.siteDetailsTableAdapter.FillBySorted(this.sbi_salesdbDataSet.SiteDetails);
            }
        }

        private void developerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.developerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           comboBox1.Enabled = false;
            var innerJoinQuery =
     from site in this.sbi_salesdbDataSet.SiteDetails
     join client in this.sbi_salesdbDataSet.Client on site.ClientID equals client.ClientID
     join dev in this.sbi_salesdbDataSet.Developer on client.DeveloperID equals dev.DevID
     where dev.DevID == Convert.ToInt32(comboBox3.SelectedValue) && !site.IsNameNull()
     select new { SiteID = site.SiteID, Name = site.Name};
            var orderedQuery = innerJoinQuery.OrderBy(row => row.Name);
            comboBox2.DataSource = orderedQuery.ToList();



        }
    }
}
