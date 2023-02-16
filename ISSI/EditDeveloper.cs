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
    public partial class EditDeveloper : Form
    {
        public EditDeveloper()
        {
            InitializeComponent();
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.sbi_salesdbDataSet.Region);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);
        }
        public EditDeveloper(bool newItem)
        {
            InitializeComponent();
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.sbi_salesdbDataSet.Region);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);
            if (newItem)
            {
                DataRow dr = sbi_salesdbDataSet.Developer.NewRow();
                dr["DevID"] = -1;
                dr["Name"] = "<New Developer>";
                dr["ColorCode"] = 1;

                sbi_salesdbDataSet.Developer.Rows.Add(dr);
                this.developerBindingSource.Position = sbi_salesdbDataSet.Developer.Rows.IndexOf(dr);

            }
        }

        public EditDeveloper(int devID)
        {
            InitializeComponent();
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.sbi_salesdbDataSet.Region);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.FillByDevID(this.sbi_salesdbDataSet.Developer, devID);
        }

        private void developerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("No Name entered");
            }
            else
            {
                this.Validate();
                this.developerBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            }

        }

        private void EditDeveloper_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("No Name entered");
            }
            else
            {
                this.Validate();
                this.developerBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            }

            DataRowView currentDev = (DataRowView)developerBindingSource.Current;
            //currentPO["Name"] = tbPOSOP.Text;

            int devID = Convert.ToInt32(currentDev["DevID"]);
            EditClient ec = new EditClient(devID, true);
            ec.ShowDialog();
        }
    }
}
