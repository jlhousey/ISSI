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
    public partial class EditRegion : Form
    {
        public EditRegion()
        {
            InitializeComponent();
        }

        private void jobBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.jobBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }

        private void EditRegion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.sbi_salesdbDataSet.Job);

        }
    }
}
