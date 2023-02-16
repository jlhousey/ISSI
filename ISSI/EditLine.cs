using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ISSI
{
    public partial class EditLine : Form
    {
        private DataTable modified;
        //private int sam;
        //private int dam;
        public EditLine()
        {
            InitializeComponent();
            this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.FillExDel(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.sbi_salesdbDataSet.Category);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.sAMTableAdapter.Fill(this.sbi_salesdbDataSet.SAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);

            foreach (Control x in this.Controls)
            {
                if (x is DateTimePicker)
                {
                    DateTimePicker y = (DateTimePicker)x;
                    if (y.Checked == true)
                    {
                        x.ForeColor = Color.White;

                    }

                }
            }
        }
        public EditLine(int lineID)
        {
            InitializeComponent();
            this.lineTableAdapter.FillByLineID(this.sbi_salesdbDataSet.Line, lineID);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.FillExDel(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.sbi_salesdbDataSet.Category);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.sAMTableAdapter.Fill(this.sbi_salesdbDataSet.SAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);


        }
        public EditLine(int lineID, int damID, int samID)
        {

            InitializeComponent();
            this.lineTableAdapter.FillByLineID(this.sbi_salesdbDataSet.Line, lineID);

            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.FillExDel(this.sbi_salesdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.ProductType' table. You can move, or remove it, as needed.
            this.productTypeTableAdapter.Fill(this.sbi_salesdbDataSet.ProductType);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.sbi_salesdbDataSet.Category);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Line' table. You can move, or remove it, as needed.
            this.sAMTableAdapter.Fill(this.sbi_salesdbDataSet.SAM);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.DAM' table. You can move, or remove it, as needed.
            this.dAMTableAdapter.Fill(this.sbi_salesdbDataSet.DAM);

            //sam = samID;
            //dam = damID;

            //comboBox3.SelectedValue = 1;
            //bornDateDateTimePicker.Value = DateTime.Today;
            //comboBox5.SelectedValue = samID;
            //comboBox6.SelectedValue = damID;
            //commsDueCheckBox.Checked = true;
            //comboBox4.SelectedValue = damID;
        }

        private void lineBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

            this.lineBindingSource.EndEdit();
            //getmodified();
            this.lineTableAdapter.Update(this.sbi_salesdbDataSet.Line);
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            //if (modified != null)
            //{
            //    this.sbi_salesdbDataSet.Line.Merge(modified);
            //    this.lineTableAdapter.Update(sbi_salesdbDataSet.Line);
            //    this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            //    modified.Clear();
            //    this.lineTableAdapter.Fill(this.sbi_salesdbDataSet.Line);
            //}
            this.Close();

        }
        private void getmodified()
        {
            DataTable changes = this.sbi_salesdbDataSet.Line.GetChanges();
            if (changes != null && changes.Rows.Count > 0)
            {
                modified = this.sbi_salesdbDataSet.Line.Clone();
                foreach (DataRow r in changes.Rows)
                {
                    DataRow original = modified.NewRow();
                    for (int i = 0; i < changes.Columns.Count; i++)
                    {

                        original[i] = r[i, DataRowVersion.Original];
                    }

                    string connectionString = Properties.Settings.Default.sbi_salesdbConnectionString;

                    int jID = Convert.ToInt32(original["JobID"]);
                    int newLine = -1;


                    original["Deleted"] = 1;
                    original["ModifiedBy"] = Session.UserID;
                    original["DateModified"] = DateTime.Today;
                    original["LineID"] = newLine;

                    modified.Rows.Add(original);
                }

            }

        }

        private void EditLine_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.SAM' table. You can move, or remove it, as needed.


        }

        private void statusStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void installProbLabel_Click(object sender, EventArgs e)
        {

        }

        private void oIDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void installDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this record from the database?", "Delete record?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                deletedCheckBox.Visible = true;
                deletedCheckBox.Checked = true;
                deletedCheckBox.CheckState = CheckState.Checked;

                this.Validate();

                this.lineBindingSource.EndEdit();
                this.lineTableAdapter.Update(this.sbi_salesdbDataSet.Line);
                this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
                this.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            clearDate("DesignedDate");


        }

        private void label2_Click(object sender, EventArgs e)
        {
            clearDate("PresentationDate");
        }

        private void clearDate(string columnName)

        {
            DataRowView drv = (DataRowView)lineBindingSource.Current;
            int currentLine = Convert.ToInt32(drv["LineID"]);
            this.sbi_salesdbDataSet.Line.Rows.Find(currentLine).SetField(columnName, DBNull.Value);
            this.Validate();

            this.lineBindingSource.EndEdit();
            //getmodified();
            this.lineTableAdapter.Update(this.sbi_salesdbDataSet.Line);
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            //if (modified != null)
            //{
            //    this.sbi_salesdbDataSet.Line.Merge(modified);
            //    this.lineTableAdapter.Update(sbi_salesdbDataSet.Line);
            //    this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);
            //    modified.Clear();

            //}
            EditLine el = new EditLine(currentLine);

            this.Hide();
            el.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            clearDate("OpsDate");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            clearDate("InvoiceDate");
        }

        private void installDateDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            if (installDateDateTimePicker.Checked && installDateDateTimePicker.Value != null)
            {
                DateTime sDate = installDateDateTimePicker.Value;

                DateTime wedOfWeek = sDate.AddDays(3 - Convert.ToInt32(sDate.DayOfWeek));
                DateTime firstDayOfTheMonth = new DateTime(wedOfWeek.Year, wedOfWeek.Month, 1);
                DateTime eomonth = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                salesAllocatedMonthDateTimePicker.Value = eomonth;
            }
        }

        private void oIDateDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            if (oIDateDateTimePicker.Checked && oIDateDateTimePicker.Value != null)
            {
                DateTime sDate = oIDateDateTimePicker.Value;


                DateTime firstDayOfTheMonth = new DateTime(sDate.Year, sDate.Month, 1);
                DateTime eomonth = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                oIAllocatedMonthDateTimePicker.Value = eomonth;
            }
        }
    }
}
