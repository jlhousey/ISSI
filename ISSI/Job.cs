using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISSI
{
    public partial class Job : UserControl
    {

        public bool selected = false;
        public int installid;
        public int jobtype;
        public int siteid;
        public bool haschanged = true;
        public Color backColor = Color.AliceBlue;
      
        public Job()
        {
            InitializeComponent();
           // this.installScheduleTableAdapter.Fill(this.sbi_installdbDataSet.InstallSchedule);
           // int installID = Convert.ToInt32(this.installIDTextBox.Text);
           // this.lineInfoDashboardTableAdapter.FillByInstallID(this.sbi_salesdbDataSet.LineInfoDashboard, installID);
            
            
        }
        public Job(int installID, int siteId)
        {
            InitializeComponent();
            this.installScheduleTableAdapter.FillByInstallID(this.sbi_installdbDataSet.InstallSchedule,installID);
            this.workScheduleTableAdapter.FillByHRID(this.sbi_installdbDataSet.WorkSchedule,1);
            this.workScheduleTableAdapter1.FillByHRID(this.sbi_installdbDataSet1.WorkSchedule, 4);
            this.employeeTableAdapter.FillByDept(this.sbi_installdbDataSet.Employee,1);
            this.employeeTableAdapter1.FillByDept(this.sbi_installdbDataSet1.Employee, 2);
            this.vInstallLineSummaryInstallOnlyTableAdapter.FillByInstallID(this.sbi_installdbDataSet.vInstallLineSummaryInstallOnly, installID);
            this.reqSubConTableAdapter.FillByInstallIDSubConID(this.sbi_installdbDataSet.ReqSubCon, installID, 1);
            this.reqHResourceTableAdapter1.FillByHRIDInstallID(this.sbi_installdbDataSet.ReqHResource, 1, installID);
            this.reqHResourceTableAdapter2.FillByHRIDInstallID(this.sbi_installdbDataSet1.ReqHResource, 1, installID);
            this.siteDetailsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteId);
            if(this.sbi_installdbDataSet.ReqHResource.Rows.Count == 0)
            {
                workScheduleDataGridView.Visible = false;
            }

            //if (this.sbi_installdbDataSet1.ReqHResource.Rows.Count == 0)
            //{
            //    workScheduleDataGridView1.Visible = false;
            //}
            installid = installID;
            jobtype = Convert.ToInt32(this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(installid)["JobType"]);
            if(jobtype == 10)
            {
                jobtype = 0;
            }
            siteid = siteId;
            //this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Job_MouseWheel);
            
            
        }

       

        public void installScheduleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            

        }
       
        public void updateInstall(int day)
        {
            this.installScheduleBindingSource.EndEdit();
            //this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(installid)["RowNum"] = row;
            this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(installid)["InstallDay"] = day;
            DateTime workSchedDate = (DateTime)this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(installid)["InstallDate"];
            if (day!= -1)
            {
                workSchedDate = workSchedDate.AddDays(day); 
            }
           
            foreach (DataGridViewRow r in this.workScheduleDataGridView.Rows)
            {
                if (day == -1)
                {
                    r.Cells["wsDate"].Value = DBNull.Value;
                }
                else
                {
                    r.Cells["wsDate"].Value = workSchedDate;
                }

                r.Cells["hrID"].Value = 1;
                r.Cells["DefaultItem"].Value = 1;
            }

            //foreach (DataGridViewRow r in this.workScheduleDataGridView1.Rows)
            //{
            //    if (day == -1)
            //    {
            //        r.Cells["wsDate"].Value = DBNull.Value;
            //    }
            //    else
            //    {
            //        r.Cells["wsDate"].Value = workSchedDate;
            //    }

            //    r.Cells["hrID"].Value = 4;
            //    r.Cells["DefaultItem"].Value = 1;
            //}
            this.Validate();
            this.workScheduleBindingSource.EndEdit();
            this.workScheduleBindingSource1.EndEdit();
            this.installScheduleBindingSource.EndEdit();
            this.siteDetailsBindingSource.EndEdit();
            this.workScheduleTableAdapter.Update(this.sbi_installdbDataSet.WorkSchedule);
            this.workScheduleTableAdapter1.Update(this.sbi_installdbDataSet1.WorkSchedule);
            this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);
        }

        private void Job_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void productTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void houseTypeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableLayoutPanel tlp = (TableLayoutPanel)this.Parent;
            int d = tlp.GetColumn(this);
            updateInstall(d);

            EditSite ei = new EditSite(siteid);
            ei.ShowDialog();
            this.installScheduleTableAdapter.FillByInstallID(this.sbi_installdbDataSet.InstallSchedule, installid);
            this.workScheduleTableAdapter.FillByHRID(this.sbi_installdbDataSet.WorkSchedule, 1);
            this.workScheduleTableAdapter1.FillByHRID(this.sbi_installdbDataSet1.WorkSchedule, 4);
            this.employeeTableAdapter.FillByDept(this.sbi_installdbDataSet.Employee, 1);
            this.employeeTableAdapter1.FillByDept(this.sbi_installdbDataSet1.Employee, 2);
            this.vInstallLineSummaryInstallOnlyTableAdapter.FillByInstallID(this.sbi_installdbDataSet.vInstallLineSummaryInstallOnly, installid);
            this.reqSubConTableAdapter.FillByInstallIDSubConID(this.sbi_installdbDataSet.ReqSubCon, installid, 1);
            this.reqHResourceTableAdapter1.FillByHRIDInstallID(this.sbi_installdbDataSet.ReqHResource, 1, installid);
            this.reqHResourceTableAdapter2.FillByHRIDInstallID(this.sbi_installdbDataSet1.ReqHResource, 1, installid);
            this.siteDetailsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteid);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void workScheduleDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void workScheduleDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            workScheduleDataGridView.EndEdit();
            workScheduleDataGridView.Focus();
        }

        private void workScheduleDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            workScheduleDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            workScheduleDataGridView.EndEdit();

        }
    }
}
