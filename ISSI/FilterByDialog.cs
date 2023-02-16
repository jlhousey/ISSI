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
    public partial class FilterByDialog : Form
    {

        public string criteria;
        public string filtervalue;
        private DataTable findvalues;
        private string disp;
        private string val;
        //private string pk;
        private bool returnpk;
        private DataTable datasource;
        public FilterByDialog()
        {
            InitializeComponent();
        }
        public FilterByDialog(string value, string display, DataGridView view)
        {
            if (view.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("value");
                dt.Columns.Add("display");
                foreach (DataGridViewRow r in view.Rows)
                {
                    DataRow row = dt.NewRow();
                    row["value"] = r.Cells[value].Value;
                    row["display"] = Convert.ToString(r.Cells[display].FormattedValue.ToString());
                    dt.Rows.Add(row);
                }
                findvalues = dt;
                disp = display;
                val = value;
                var distinctvalues = dt.AsEnumerable().DistinctBy(row => new { Select = row["display"] });


                datasource = distinctvalues.CopyToDataTable();

                InitializeComponent();

                BindingSource bs = new BindingSource();
                bs.DataSource = datasource;
                bs.Sort = "display";


                comboBox2.DataSource = bs;
                comboBox2.ValueMember = "display";

            }
            //comboBox2.ValueMember = "Select";

        }

        public FilterByDialog(string value, string display, DataTable lookup, bool pk)
        {
            returnpk = pk;
            val = value;
            if (lookup.Rows.Count > 0)
            {



                datasource = lookup;

                InitializeComponent();

                BindingSource bs = new BindingSource();
                bs.DataSource = datasource;



                comboBox2.DataSource = bs;

                comboBox2.ValueMember = value;
                comboBox2.DisplayMember = display;
                //comboBox2.AutoCompleteSource = datasource;

            }
            //comboBox2.ValueMember = "Select";

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var criteriaList = new List<string>();

            if (!returnpk)
            {
                filtervalue = Convert.ToString(comboBox2.SelectedValue);
                foreach (DataRow r in findvalues.Rows)
                {

                    if (Convert.ToString(r["display"]) == filtervalue)
                    {
                        string chk = Convert.ToString(r["value"]);
                        if (!String.IsNullOrWhiteSpace(chk) && !criteriaList.Contains(chk))
                        {
                            criteriaList.Add(chk);
                            criteria += val + " = " + r["value"].ToString() + " OR ";
                        }



                    }
                }
                if (criteria != null)
                {
                    criteria = criteria.Substring(0, criteria.Length - 4);
                    //MessageBox.Show(criteria);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
            }
            else
            {
                string pkval = Convert.ToString(comboBox2.SelectedValue);
                filtervalue = pkval;
                criteria += val + " = " + pkval;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
