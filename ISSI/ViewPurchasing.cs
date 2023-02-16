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
    public partial class ViewPurchasing : Form
    {
        public ViewPurchasing()
        {
            InitializeComponent();
            this.vPurchasingLinesTableAdapter.Fill(this.sbi_installdbDataSet.vPurchasingLines);
            textBox1.Visible = false;
            textBox2.Visible = false;
        }
        public ViewPurchasing(int ID, string level)
        {
            InitializeComponent();
            switch (level)
            {
                case "Job":
                    this.vPurchasingLinesTableAdapter.FillByJob(this.sbi_installdbDataSet.vPurchasingLines,ID);
                    if (this.sbi_installdbDataSet.vPurchasingLines.Rows.Count > 0)
                    {
                        textBox1.Text = Convert.ToString(this.sbi_installdbDataSet.vPurchasingLines.Rows[0]["Client"]);
                        textBox2.Text = Convert.ToString(this.sbi_installdbDataSet.vPurchasingLines.Rows[0]["Site"]);

                    }
                    break;
                case "Site":
                    this.vPurchasingLinesTableAdapter.FillBySite(this.sbi_installdbDataSet.vPurchasingLines,ID);
                    if (this.sbi_installdbDataSet.vPurchasingLines.Rows.Count > 0)
                    {
                        textBox1.Text = Convert.ToString(this.sbi_installdbDataSet.vPurchasingLines.Rows[0]["Client"]);
                        textBox2.Text = Convert.ToString(this.sbi_installdbDataSet.vPurchasingLines.Rows[0]["Site"]);

                    }
                    break;
                default:
                    this.vPurchasingLinesTableAdapter.Fill(this.sbi_installdbDataSet.vPurchasingLines);
                    textBox1.Visible = false;
                    textBox2.Visible = false;

                    break;
            }
                
        }

        private void ViewPurchasing_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.PurchasingAreas' table. You can move, or remove it, as needed.
            this.purchasingAreasTableAdapter.Fill(this.sbi_installdbDataSet.PurchasingAreas);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vPurchasingLines' table. You can move, or remove it, as needed.
            //this.vPurchasingLinesTableAdapter.Fill(this.sbi_installdbDataSet.vPurchasingLines);

        }

        private void purchasingAreasDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {
                vPurchasingLinesBindingSource.RemoveFilter();
                string pId = Convert.ToString(purchasingAreasDataGridView.Rows[e.RowIndex].Cells["PurchasingID"].Value);
                vPurchasingLinesBindingSource.Filter = "PurchasingID = " + pId;
            }
        }
    }
}
