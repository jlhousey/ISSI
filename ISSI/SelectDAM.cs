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
    public partial class SelectDAM : Form
    {
        public SelectDAM()
        {
            InitializeComponent();
        }

        private void SelectDAM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Nothing Selected");

            }
            else
            {

                int DAMID = Convert.ToInt32(comboBox1.SelectedValue);
                EditDAM ed = new EditDAM(DAMID);
                ed.ShowDialog();

            }


        }
    }
}
