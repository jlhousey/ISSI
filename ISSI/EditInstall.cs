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
    public partial class EditInstall : Form
    {
        private bool deletedflag = false;
        private int iid = 0;
        private DateTime originalInstDate;
        public bool newiid = false;
        public EditInstall()
        {
            InitializeComponent();
        }

        public EditInstall(int installId)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            InitializeComponent();
            iid = installId;
            this.opsPlannerTableAdapter.Fill(this.sbi_installdbDataSet1.OpsPlanner);
            this.vDAMTableAdapter.Fill(this.sbi_installdbDataSet1.vDAM);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vSAM' table. You can move, or remove it, as needed.
            this.vSAMTableAdapter.Fill(this.sbi_installdbDataSet1.vSAM);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vInstallLineSummaryAll' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_installdbDataSet.Status);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.JobTypes' table. You can move, or remove it, as needed.
            this.jobTypesTableAdapter.Fill(this.sbi_installdbDataSet.JobTypes);
            this.installScheduleTableAdapter.FillByInstallID(this.sbi_installdbDataSet.InstallSchedule, installId);
            this.vInstallLineSummaryAllTableAdapter.FillByInstallID(this.sbi_installdbDataSet1.vInstallLineSummaryAll, installId);
            if (this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"] != DBNull.Value)
            {
                originalInstDate = (DateTime)this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"];
            }
        }

        private void installScheduleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (deletedflag)
            {
                DialogResult dialogResult = MessageBox.Show("Are you absolutely 100% sure you want to delete this install? (Click No to exit without deleting the record)", "Delete Install", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    deletedflag = false;
                }
            }

            if (!deletedflag)
            {
                this.Validate();
                this.installScheduleBindingSource.EndEdit();
                if (this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid) != null) // check that record has not been deleted
                {
                    if ((this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid) != null && this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"] != DBNull.Value && originalInstDate != null && (DateTime)this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"] != originalInstDate))
                    {
                        this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDay"] = -1;
                        int[] instid = { iid };
                        MovementDialog md = new MovementDialog(instid, installDateDateTimePicker.Value);
                        md.ShowDialog();
                    }
                   
                    if (this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid) != null && this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"] != DBNull.Value)
                    {
                        this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);
                        if (newiid)
                        {
                            if (newiid)
                            {
                                DateTime ind = (DateTime)this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"];
                                bool cont = true;
                                if (ind.Date.AddDays(-(int)ind.DayOfWeek + (int)DayOfWeek.Monday) == DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek + (int)DayOfWeek.Monday))
                                {

                                    DialogResult dialogResult1 = MessageBox.Show("Date selected is this week.  Continue?", "Immediate Install", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (dialogResult1 == DialogResult.No)
                                    {
                                        cont = false;
                                    }
                                }
                                if (cont)
                                {
                                    this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDay"] = -1;
                                    int[] instid = { iid };
                                    MovementDialog md = new MovementDialog(instid);
                                    md.ShowDialog();
                                }

                            }
                            
                        }

                        originalInstDate = (DateTime)this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"];
                        this.movementsTableAdapter.Fill(this.sbi_installdbDataSet.Movements);
                        this.sbi_installdbDataSet.Movements.OrderByDescending(row => row.Field<int?>("MovementID"));
                    }
                    else
                    {
                        MessageBox.Show("No install date entered");
                    }

                    newiid = false;
                }
                else
                {
                    this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);
                    this.Close();
                } 
            }
            else
            {
                this.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.vPurchasingLines' table. You can move, or remove it, as needed.
            this.vPurchasingLinesTableAdapter.Fill(this.sbi_installdbDataSet1.vPurchasingLines);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.SMSLines' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.MovementCodes' table. You can move, or remove it, as needed.
            this.movementCodesTableAdapter.Fill(this.sbi_installdbDataSet.MovementCodes);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.Impacts' table. You can move, or remove it, as needed.
            this.impactsTableAdapter.Fill(this.sbi_installdbDataSet.Impacts);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.CheckListlist' table. You can move, or remove it, as needed.
            this.checkListlistTableAdapter.Fill(this.sbi_installdbDataSet.CheckListlist);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.Causes' table. You can move, or remove it, as needed.
            this.causesTableAdapter.Fill(this.sbi_installdbDataSet1.Causes);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.ChecklistItems' table. You can move, or remove it, as needed.
            this.checklistItemsTableAdapter.Fill(this.sbi_installdbDataSet1.ChecklistItems);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.PurchasingAreas' table. You can move, or remove it, as needed.
            this.purchasingAreasTableAdapter.Fill(this.sbi_installdbDataSet1.PurchasingAreas);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.sbi_installdbDataSet1.Employee);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.HResources' table. You can move, or remove it, as needed.
            this.hResourcesTableAdapter.Fill(this.sbi_installdbDataSet1.HResources);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.SubConAreas' table. You can move, or remove it, as needed.
            this.subConAreasTableAdapter.Fill(this.sbi_installdbDataSet1.SubConAreas);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.sbi_installdbDataSet1.Status);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.JobTypes' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.OpsPlanner' table. You can move, or remove it, as needed.
            this.opsPlannerTableAdapter.Fill(this.sbi_installdbDataSet.OpsPlanner);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet1.vDAM' table. You can move, or remove it, as needed.
            this.vDAMTableAdapter.Fill(this.sbi_installdbDataSet.vDAM);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vSAM' table. You can move, or remove it, as needed.
            this.vSAMTableAdapter.Fill(this.sbi_installdbDataSet.vSAM);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vInstallLineSummaryAll' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'sbi_installdbDataSet.Movements' table. You can move, or remove it, as needed.
            this.movementsTableAdapter.Fill(this.sbi_installdbDataSet.Movements);
            this.sbi_installdbDataSet.Movements.OrderByDescending(row => row.Field<int?>("MovementID"));
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.CheckListlist' table. You can move, or remove it, as needed.
            this.checkListlistTableAdapter.Fill(this.sbi_installdbDataSet.CheckListlist);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.WorkSchedule' table. You can move, or remove it, as needed.
            this.workScheduleTableAdapter.Fill(this.sbi_installdbDataSet.WorkSchedule);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.ReqSubCon' table. You can move, or remove it, as needed.
            this.reqSubConTableAdapter.Fill(this.sbi_installdbDataSet.ReqSubCon);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.Issues' table. You can move, or remove it, as needed.
            this.issuesTableAdapter.Fill(this.sbi_installdbDataSet.Issues);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.ReqHResource' table. You can move, or remove it, as needed.
            this.reqHResourceTableAdapter.Fill(this.sbi_installdbDataSet.ReqHResource);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.ReqPurchasing' table. You can move, or remove it, as needed.
            this.reqPurchasingTableAdapter.Fill(this.sbi_installdbDataSet.ReqPurchasing);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.InstallSchedule' table. You can move, or remove it, as needed.
            //this.installScheduleTableAdapter.Fill(this.sbi_installdbDataSet.InstallSchedule);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (iid != 0)
            {
                string connectionString = Properties.Settings.Default.sbi_installdbConnectionString;
                string commandText = "CreateChecklist";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@p1", iid));


                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            this.checkListlistTableAdapter.Fill(this.sbi_installdbDataSet.CheckListlist);
        }

        private void installDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            installDateDateTimePicker.Value = installDateDateTimePicker.Value.AddDays(-(int)installDateDateTimePicker.Value.DayOfWeek + (int)DayOfWeek.Monday);
            if (newiid)
            {   
                originalInstallDateDateTimePicker.Value = installDateDateTimePicker.Value;
                originalInstDate = originalInstallDateDateTimePicker.Value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (iid != 0)
            {
                string connectionString = Properties.Settings.Default.sbi_installdbConnectionString;
                string commandText = "CreateReqHResource";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@p1", iid));


                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            this.reqHResourceTableAdapter.Fill(this.sbi_installdbDataSet.ReqHResource);
            this.workScheduleTableAdapter.Fill(this.sbi_installdbDataSet.WorkSchedule);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (iid != 0)
            {
                string connectionString = Properties.Settings.Default.sbi_installdbConnectionString;
                string commandText = "CreateReqPurchasing";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@p1", iid));


                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            this.reqPurchasingTableAdapter.Fill(this.sbi_installdbDataSet.ReqPurchasing);
        }

        private void reqSubConDataGridView_Paint(object sender, PaintEventArgs e)
        {
            foreach (DataGridViewRow r in reqSubConDataGridView.Rows)
            {
                if (r.Cells["CMRAG"].Value != null && r.Cells["CMRAG"].Value != DBNull.Value)
                {
                    if ((Convert.ToInt32(r.Cells["CMRAG"].Value)) == 1)
                    {
                        r.Cells["SCNotes"].Style.BackColor = Color.Red;
                        r.Cells["CheckDate"].Style.BackColor = Color.Red;
                    }
                    if ((Convert.ToInt32(r.Cells["CMRAG"].Value)) == 2)
                    {
                        r.Cells["CheckDate"].Style.BackColor = Color.Orange;
                        r.Cells["SCNotes"].Style.BackColor = Color.Orange;
                    }
                    if ((Convert.ToInt32(r.Cells["CMRAG"].Value)) == 3)
                    {
                        r.Cells["CheckDate"].Style.BackColor = Color.Green;
                        r.Cells["SCNotes"].Style.BackColor = Color.Green;
                    }
                }

                if (r.Cells["SCIRAG"].Value != null && r.Cells["SCIRAG"].Value != DBNull.Value)
                {
                    if ((Convert.ToInt32(r.Cells["SCIRAG"].Value)) == 1)
                    {
                        r.Cells["InstallDate"].Style.BackColor = Color.Red;

                    }
                    if ((Convert.ToInt32(r.Cells["SCIRAG"].Value)) == 2)
                    {
                        r.Cells["InstallDate"].Style.BackColor = Color.Orange;

                    }
                    if ((Convert.ToInt32(r.Cells["SCIRAG"].Value)) == 3)
                    {
                        r.Cells["InstallDate"].Style.BackColor = Color.Green;

                    }
                }


            }
        }

        private void checkListlistDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (checkListlistDataGridView.Rows.Count > 0)
            {
                if (Convert.ToString(checkListlistDataGridView.Rows[e.RowIndex].Cells["Checked"].EditedFormattedValue) == "True")
                {
                    checkListlistDataGridView.Rows[e.RowIndex].Cells["DateChecked"].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    checkListlistDataGridView.Rows[e.RowIndex].Cells["DateChecked"].Style.BackColor = Color.White;
                } 
            }
        }

        private void checkListlistDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (checkListlistDataGridView.Rows.Count >0)
            {
                if (e.ColumnIndex == checkListlistDataGridView.Columns["Checked"].Index && e.RowIndex != -1)
                {

                    if (checkListlistDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value && (bool)checkListlistDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                    {
                        if (checkListlistDataGridView.Rows[e.RowIndex].Cells["DateChecked"].Value == DBNull.Value || checkListlistDataGridView.Rows[e.RowIndex].Cells["DateChecked"].Value == null)
                        {
                            checkListlistDataGridView.Rows[e.RowIndex].Cells["DateChecked"].Value = Convert.ToString(DateTime.Today);
                        }
                    }
                    else
                    {
                        if (checkListlistDataGridView.Rows[e.RowIndex].Cells["DateChecked"].Value == DBNull.Value || checkListlistDataGridView.Rows[e.RowIndex].Cells["DateChecked"].Value == null)
                        {
                            checkListlistDataGridView.Rows[e.RowIndex].Cells["DateChecked"].Value = DBNull.Value;
                        }
                    }
                } 
            }
        }

        private void checkListlistDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == checkListlistDataGridView.Columns["Checked"].Index && e.RowIndex != -1) 
            {
                checkListlistDataGridView.EndEdit();
            }
        }

        private void reqPurchasingDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {


                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                string criteria = "";
                vPurchasingLinesBindingSource.RemoveFilter();
                string pId = Convert.ToString(reqPurchasingDataGridView.Rows[e.RowIndex].Cells["PID"].Value);
                if (!String.IsNullOrWhiteSpace(pId))
                {
                    criteria = "PurchasingID = " + pId;
                }
                if (!String.IsNullOrWhiteSpace(criteria))
                {


                    
                    this.vPurchasingLinesBindingSource.Filter = "(" + criteria + ")";

                }

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            deletedflag = true;
        }

        private void EditInstall_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Save Changes?", "Save Changes?", MessageBoxButtons.YesNoCancel);

            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            if (dr == DialogResult.Yes)
            {
                if (deletedflag)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you absolutely 100% sure you want to delete this install? (Click No to exit without deleting the record)", "Delete Install", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        deletedflag = false;
                    }
                }

                if (!deletedflag)
                {
                    this.Validate();
                    this.installScheduleBindingSource.EndEdit();
                    if (this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid) != null) // check that record has not been deleted
                    {
                        if (this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid) != null && this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"] != DBNull.Value && originalInstDate != null && (DateTime)this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"] != originalInstDate)
                        {
                            this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDay"] = -1;
                            int[] instid = { iid };
                            MovementDialog md = new MovementDialog(instid, installDateDateTimePicker.Value);
                            md.ShowDialog();
                        }
                        if (this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid) != null && this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"] != DBNull.Value)
                        {
                            this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);
                            if (newiid)
                            {
                                DateTime ind = (DateTime)this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"];
                                bool cont = true;
                                if (ind.Date.AddDays(-(int)ind.DayOfWeek +(int)DayOfWeek.Monday) == DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek + (int)DayOfWeek.Monday))
                                {
                                   
                                    DialogResult dialogResult1 = MessageBox.Show("Date selected is this week.  Continue?", "Immediate Install", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (dialogResult1 == DialogResult.No)
                                    {
                                        cont = false;
                                    }
                                }
                                if (cont)
                                {
                                    this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDay"] = -1;
                                    int[] instid = { iid };
                                    MovementDialog md = new MovementDialog(instid);
                                    md.ShowDialog(); 
                                }
                                
                            }
                            originalInstDate = (DateTime)this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(iid)["InstallDate"];
                            this.movementsTableAdapter.Fill(this.sbi_installdbDataSet.Movements);
                            this.sbi_installdbDataSet.Movements.OrderByDescending(row => row.Field<int?>("MovementID"));
                        }
                        else
                        {
                            MessageBox.Show("No install date entered");
                        }
                    }
                    else
                    {
                        this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);
                        
                    }
                }
                else
                {
                   
                }
                
            }
        }
    }

}
