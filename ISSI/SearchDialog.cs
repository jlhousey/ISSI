using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MoreLinq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISSI
{
    public partial class SearchDialog : Form
    {


        private DataGridView findvalues;
        int rowindex = 0;
        int colindex = 0;

        public SearchDialog()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;

        }
        public SearchDialog(DataGridView view)
        {
            InitializeComponent();
            findvalues = view;
            this.ActiveControl = textBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {

                string check = Convert.ToString(findvalues.Rows[rowindex].Cells[colindex].FormattedValue.ToString());
                while (rowindex < findvalues.Rows.Count && !isMatch(check))
                {
                    if (colindex == findvalues.Columns.Count - 1)
                    {
                        rowindex++;
                        colindex = 0;

                    }
                    else
                    {
                        colindex++;
                    }
                    if (rowindex < findvalues.Rows.Count && findvalues.Rows[rowindex].Cells[colindex].Visible)
                    {
                        check = Convert.ToString(findvalues.Rows[rowindex].Cells[colindex].FormattedValue.ToString());
                    }
                }

                if (rowindex >= findvalues.Rows.Count)
                {
                    MessageBox.Show("No further values found");
                    rowindex = 0;
                    colindex = 0;

                }
                else
                {

                    if (findvalues.Rows[rowindex].Cells[colindex].Visible)
                    {
                        findvalues.CurrentCell = findvalues.Rows[rowindex].Cells[colindex];
                        findvalues.Rows[rowindex].Cells[colindex].Selected = true;

                        if (colindex == findvalues.Columns.Count - 1)
                        {
                            rowindex++;
                            colindex = 0;

                        }
                        else
                        {
                            colindex++;
                        }
                    }
                    else
                    {
                        if (colindex == findvalues.Columns.Count - 1)
                        {
                            rowindex++;
                            colindex = 0;

                        }
                        else
                        {
                            colindex++;
                        }

                        button1.PerformClick();
                    }
                }

            }
        }

        private bool isMatch(string cellvalue)
        {
            if (checkBox1.Checked)
            {
                if (textBox1.Text == cellvalue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (cellvalue.ToUpper().Contains(textBox1.Text.ToUpper()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
