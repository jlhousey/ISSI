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
    public partial class ContactList : Form
    {
        public ContactList()
        {
            InitializeComponent();
        }

        

        private void ContactList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vContactDetails' table. You can move, or remove it, as needed.
            this.vContactDetailsTableAdapter.Fill(this.sbi_installdbDataSet.vContactDetails);

        }

        private void ContactList_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.Control && e.KeyCode == Keys.F)
            {
                SearchDialog searchForm = new SearchDialog(vContactDetailsDataGridView);
                searchForm.Show();
            }
           

        }

        private void vContactDetailsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int siteId = 1;
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {
                siteId = Convert.ToInt32(vContactDetailsDataGridView.Rows[e.RowIndex].Cells["SiteID"].Value);

            }
            EditSite es = new EditSite(siteId);
            es.ShowDialog();
        }
    }
}
