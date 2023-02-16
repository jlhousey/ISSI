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
    public partial class SelectJob : Form
    {
        public int clientID;
        public int siteID;
        private bool newItem = false;
        public SelectJob()
        {
            InitializeComponent();
        }

        public SelectJob(bool newitem)
        {
            InitializeComponent();
            newItem = newitem;
        }

        private void clientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }

        private void SelectSite_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.sbi_salesdbDataSet.Job);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.JobDetails' table. You can move, or remove it, as needed.
            this.siteDetailsTableAdapter.Fill(this.sbi_salesdbDataSet.SiteDetails);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.siteDetailsTableAdapter.Fill(this.sbi_salesdbDataSet.SiteDetails);
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
                int clientID = Convert.ToInt32(comboBox1.SelectedValue);
                int jobID = Convert.ToInt32(comboBox5.SelectedValue);
                if (!newItem)
                {


                    EditJob ej = new EditJob(jobID,false);
                    ej.ShowDialog();
                }
                else
                {

                }

            }
        }

        private void developerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.developerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }
    }
}
