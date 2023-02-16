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
    public partial class SelectDeveloper : Form
    {
        private bool newItem;
        public SelectDeveloper()
        {
            InitializeComponent();
        }

        public SelectDeveloper(bool newitem)
        {
            InitializeComponent();
            this.Text = "Create new client";
            newItem = newitem;
        }

        private void developerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.developerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }

        private void SelectDeveloper_Load(object sender, EventArgs e)
        {

            this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Nothing Selected");

            }
            else
            {

                int devID = Convert.ToInt32(comboBox1.SelectedValue);

                if (!newItem)
                {
                    EditDeveloper ed = new EditDeveloper(devID);
                    ed.ShowDialog();
                }
                else
                {
                    EditClient ec = new EditClient(devID, true);
                    ec.ShowDialog();
                }

            }
        }
    }
}
