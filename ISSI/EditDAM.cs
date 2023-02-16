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


    public partial class EditDAM : Form
    {
        private Dictionary<Control, DateTime> salesTargets;
        private Dictionary<Control, DateTime> oiTargets;
        public EditDAM()
        {
            InitializeComponent();
            this.oPSPlannerTableAdapter.Fill(this.sbi_salesdbDataSet.OPSPlanner);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SAM' table. You can move, or remove it, as needed.
            this.sAMTableAdapter.Fill(this.sbi_salesdbDataSet.SAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            this.oiTargetTableAdapter1.Fill(this.sbi_salesdbDataSet.OITarget);
            this.salesTargetTableAdapter1.Fill(this.sbi_salesdbDataSet.SalesTarget);
            getControlDictionarys();
            addTargets();
        }
        public EditDAM(int damID)
        {
            InitializeComponent();
            this.oPSPlannerTableAdapter.Fill(this.sbi_salesdbDataSet.OPSPlanner);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SAM' table. You can move, or remove it, as needed.
            this.sAMTableAdapter.Fill(this.sbi_salesdbDataSet.SAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.FillByDAMID(this.sbi_salesdbDataSet.DAM, damID);
            this.oiTargetTableAdapter1.Fill(this.sbi_salesdbDataSet.OITarget);
            this.salesTargetTableAdapter1.Fill(this.sbi_salesdbDataSet.SalesTarget);
            getControlDictionarys();
            addTargets();
        }
        public EditDAM(bool newitem)
        {
            InitializeComponent();
            this.oPSPlannerTableAdapter.Fill(this.sbi_salesdbDataSet.OPSPlanner);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SAM' table. You can move, or remove it, as needed.
            this.sAMTableAdapter.Fill(this.sbi_salesdbDataSet.SAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);
            this.oiTargetTableAdapter1.Fill(this.sbi_salesdbDataSet.OITarget);
            this.salesTargetTableAdapter1.Fill(this.sbi_salesdbDataSet.SalesTarget);


            if (newitem)
            {
                DataRow dr = sbi_salesdbDataSet.DAM.NewRow();

                dr["Name"] = "<New DAM>";
                dr["ColorCode"] = 1;

                sbi_salesdbDataSet.DAM.Rows.Add(dr);
                this.dAMBindingSource.Position = sbi_salesdbDataSet.DAM.Rows.IndexOf(dr);

            }
            getControlDictionarys();
            addTargets();

        }

        private void dAMBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dAMBindingSource.EndEdit();
            splitTargets();
            this.salesTargetTableAdapter1.Update(this.sbi_salesdbDataSet.SalesTarget);
            this.oiTargetTableAdapter1.Update(this.sbi_salesdbDataSet.OITarget);

            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }

        private void EditDAM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.OPSPlanner' table. You can move, or remove it, as needed.

            getControlDictionarys();
            addTargets();
        }

        private void splitTargets()
        {
            DataRowView drv = (DataRowView)this.dAMBindingSource.Current;
            int dAMID = Convert.ToInt32(drv["DAMID"]);
            this.salesTargetTableAdapter1.DeleteTargets(dAMID, Convert.ToString(salesTargets.Values.First()));
            this.oiTargetTableAdapter1.DeleteTarget(dAMID, Convert.ToString(oiTargets.Values.First()));
            foreach (KeyValuePair<Control, DateTime> c in salesTargets)
            {
                DateTime start = c.Value;
                int year = start.Year;
                int month = start.Month;

                for (int i = 1; i < 4; i++)
                {
                    decimal val;
                    if (String.IsNullOrWhiteSpace(Convert.ToString(c.Key.Text)))
                    {
                        val = 0;
                    }
                    else
                    {
                        DateTime mthend = new DateTime(year, month, 1).AddMonths(i).AddDays(-1);
                        val = Convert.ToDecimal(c.Key.Text) / 3;
                        DataRow dr = this.sbi_salesdbDataSet.SalesTarget.NewRow();
                        dr["DAMID"] = dAMID;
                        dr["TargetMonthEnding"] = mthend;
                        dr["TargetValue"] = val;
                        this.sbi_salesdbDataSet.SalesTarget.Rows.Add(dr);

                    }

                }
            }
            foreach (KeyValuePair<Control, DateTime> c in oiTargets)
            {
                DateTime start = c.Value;
                int year = start.Year;
                int month = start.Month;

                for (int i = 1; i < 4; i++)
                {
                    decimal val;
                    if (String.IsNullOrWhiteSpace(Convert.ToString(c.Key.Text)))
                    {
                        val = 0;
                    }
                    else
                    {
                        DateTime mthend = new DateTime(year, month, 1).AddMonths(i).AddDays(-1);
                        val = Convert.ToDecimal(c.Key.Text) / 3;
                        DataRow dr = this.sbi_salesdbDataSet.OITarget.NewRow();
                        dr["DAMID"] = dAMID;
                        dr["TargetMonthEnding"] = mthend;
                        dr["OITargetValue"] = val;
                        this.sbi_salesdbDataSet.OITarget.Rows.Add(dr);

                    }

                }
            }
        }

        public void addTargets()
        {
            DataRowView drv = (DataRowView)this.dAMBindingSource.Current;
            int dAMID = Convert.ToInt32(drv["DAMID"]);
            foreach (KeyValuePair<Control, DateTime> c in salesTargets)
            {
                string val;
                c.Key.Focus();
                if (String.IsNullOrWhiteSpace(Convert.ToString(this.salesTargetTableAdapter1.PeriodTotal(dAMID, c.Value.ToString(), Convert.ToString(c.Value.AddMonths(3))))))
                {
                    val = "0";
                }
                else
                {
                    val = Convert.ToString((Convert.ToInt32(this.salesTargetTableAdapter1.PeriodTotal(dAMID, c.Value.ToString(), Convert.ToString(c.Value.AddMonths(3))))));
                }

                c.Key.Text = val;
                this.dAMBindingSource.EndEdit();
            }

            DataRowView drv2 = (DataRowView)this.dAMBindingSource.Current;
            int dAMID2 = Convert.ToInt32(drv["DAMID"]);
            foreach (KeyValuePair<Control, DateTime> c in oiTargets)
            {
                string val;
                c.Key.Focus();
                if (String.IsNullOrWhiteSpace(Convert.ToString(this.oiTargetTableAdapter1.PeriodTotal(dAMID, c.Value.ToString(), Convert.ToString(c.Value.AddMonths(3))))))
                {
                    val = "0";
                }
                else
                {
                    val = Convert.ToString((Convert.ToInt32(this.oiTargetTableAdapter1.PeriodTotal(dAMID, c.Value.ToString(), Convert.ToString(c.Value.AddMonths(3))))));
                }

                c.Key.Text = val;
                this.dAMBindingSource.EndEdit(); c.Key.Focus();

            }

        }

        public void getControlDictionarys()
        {
            List<Control> salesArray = new List<Control>();
            List<Control> oiArray = new List<Control>();

            salesArray.Add(lYQ1TargetTextBox);
            salesArray.Add(lYQ2TargetTextBox);
            salesArray.Add(lYQ3TargetTextBox);
            salesArray.Add(lYQ4TargetTextBox);
            salesArray.Add(tYQ1TargetTextBox);
            salesArray.Add(tYQ2TargetTextBox);
            salesArray.Add(tYQ3TargetTextBox);
            salesArray.Add(tYQ4TargetTextBox);
            salesArray.Add(nYQ1TargetTextBox);
            salesArray.Add(nYQ2TargetTextBox);
            salesArray.Add(nYQ3TargetTextBox);
            salesArray.Add(nYQ4TargetTextBox);

            oiArray.Add(textBox12);
            oiArray.Add(textBox11);
            oiArray.Add(textBox10);
            oiArray.Add(textBox9);
            oiArray.Add(textBox8);
            oiArray.Add(textBox7);
            oiArray.Add(textBox6);
            oiArray.Add(textBox5);
            oiArray.Add(textBox4);
            oiArray.Add(textBox3);
            oiArray.Add(textBox2);
            oiArray.Add(textBox1);

            DateTime now = DateTime.Now;
            DateTime start = new DateTime(now.Year - 1, 2, 1);
            salesTargets = new Dictionary<Control, DateTime>();
            oiTargets = new Dictionary<Control, DateTime>();
            for (int i = 0; i < 12; i++)
            {
                salesTargets.Add(salesArray[i], start.AddMonths(i * 3).AddDays(-1));
                oiTargets.Add(oiArray[i], start.AddMonths(i * 3).AddDays(-1));
            }




        }
    }
}
