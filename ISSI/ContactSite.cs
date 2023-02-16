using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ISSI
{
    public partial class ContactSite : Form
    {
        private int sid;
        public ContactSite()
        {
            InitializeComponent();
        }
        public ContactSite(int siteID, bool newItem)
        {
            sid = siteID;
            InitializeComponent();
            this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteContactEvents' table. You can move, or remove it, as needed.
            //this.siteContactEventsTableAdapter.Fill(this.sbi_installdbDataSet.SiteContactEvents);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.opsPlannerTableAdapter.Fill(this.sbi_installdbDataSet.OpsPlanner);
            this.siteDetailsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteID);
            this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
            this.siteDetailsTableAdapter1.FillBySiteID(this.sbi_salesdbDataSet.SiteDetails, siteID);
            this.contactsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.Contacts, siteID);
            
            if (sbi_installdbDataSet.SiteDetails.Rows.Count == 0)
            {
                DataRow dr = sbi_installdbDataSet.SiteDetails.NewRow();
                dr["SiteID"] = siteID;

                sbi_installdbDataSet.SiteDetails.Rows.Add(dr);
                //foreach (DataRow r in this.sbi_installdbDataSet.JobKeyDates.Rows)
                //{
                //    DataRow ds = sbi_installdbDataSet.KeyDateList.NewRow();
                //    ds["JobID"] = jobID;
                //    ds["KeyDateID"] = r["KeyDateID"];
                //    sbi_installdbDataSet.KeyDateList.Rows.Add(ds);


                //}

                this.tableAdapterManager.UpdateAll(sbi_installdbDataSet);
            }
            if (newItem)
            {
                DataRow dr = sbi_installdbDataSet.SiteContactEvents.NewRow();
                dr["SiteID"] = siteID;
                dr["ContactDate"] = DateTime.Now;
                dr["OpsPlannerID"] = Session.UserID;
                dr["FollowUp"] = false;

                sbi_installdbDataSet.SiteContactEvents.Rows.Add(dr);
                //foreach (DataRow r in this.sbi_installdbDataSet.JobKeyDates.Rows)
                //{
                //    DataRow ds = sbi_installdbDataSet.KeyDateList.NewRow();
                //    ds["JobID"] = jobID;
                //    ds["KeyDateID"] = r["KeyDateID"];
                //    sbi_installdbDataSet.KeyDateList.Rows.Add(ds);


                //}
                this.tableAdapterManager.UpdateAll(sbi_installdbDataSet);
                //this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
                this.siteContactEventsBindingSource.Position = sbi_installdbDataSet.SiteContactEvents.Rows.IndexOf(dr);
                
            }

            followUpCheckBox.Checked = false;

        }
        public ContactSite(int siteID, int contactevent)
        {
            sid = siteID;
            InitializeComponent();
            this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteContactEvents' table. You can move, or remove it, as needed.
            //this.siteContactEventsTableAdapter.Fill(this.sbi_installdbDataSet.SiteContactEvents);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            this.opsPlannerTableAdapter.Fill(this.sbi_installdbDataSet.OpsPlanner);
            this.siteDetailsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteDetails, siteID);
            this.siteContactEventsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.SiteContactEvents, siteID);
            this.siteDetailsTableAdapter1.FillBySiteID(this.sbi_salesdbDataSet.SiteDetails, siteID);
            this.contactsTableAdapter.FillBySiteID(this.sbi_installdbDataSet.Contacts, siteID);


            DataRow dr = this.sbi_installdbDataSet.SiteContactEvents.FindByCEventID(contactevent);  
            this.siteContactEventsBindingSource.Position = sbi_installdbDataSet.SiteContactEvents.Rows.IndexOf(dr);
            followUpCheckBox.Checked = false;


        }
        private void siteDetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //if (followUpCheckBox.Checked)
            //{
            //    SetReminder();
            //}

            this.Validate();
            this.siteDetailsBindingSource.EndEdit();
            this.siteContactEventsBindingSource.EndEdit();
            
            this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);


        }
        private void SetReminder()
        {
            DialogResult dialogResult = MessageBox.Show("Set Reminder?", "Outlook Integration", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
                Outlook.AppointmentItem appt = outlookApp.Application.CreateItem(
                    Outlook.OlItemType.olAppointmentItem)
                    as Outlook.AppointmentItem;
                appt.Subject = "Contact " + nameTextBox.Text;
                appt.Body = notesTextBox.Text;
                //appt.Sensitivity = Outlook.OlSensitivity.olPrivate;
                appt.Start = followUpDateDateTimePicker.Value;
                appt.Categories = "ContactSite";
                appt.End = followUpDateDateTimePicker.Value;
                appt.ReminderSet = true;
                appt.ReminderMinutesBeforeStart = 5;
                appt.Save(); 
            }
        }

        private void ContactSite_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.Contacts' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.OpsPlanner' table. You can move, or remove it, as needed.
            


            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vInstallLineSummaryAll' table. You can move, or remove it, as needed.
            // this.vInstallLineSummaryAllTableAdapter.Fill(this.sbi_installdbDataSet.vInstallLineSummaryAll);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteDetails' table. You can move, or remove it, as needed.
            //this.siteDetailsTableAdapter.Fill(this.sbi_installdbDataSet.SiteDetails);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.SiteContactEvents' table. You can move, or remove it, as needed.
            //this.siteContactEventsTableAdapter.Fill(this.sbi_installdbDataSet.SiteContactEvents);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.Contacts' table. You can move, or remove it, as needed.



        }

        private void siteContactEventsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //if (followUpCheckBox.Checked)
            //{
            //    SetReminder();
            //}

            this.Validate();
            this.siteContactEventsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);

        }

        private void vInstallLineSummaryAllDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1 || e.ColumnIndex == -1))
            {
                int jobId = Convert.ToInt32(vInstallLineSummaryAllDataGridView.Rows[e.RowIndex].Cells["JobID"].Value);
                int siteID = Convert.ToInt32(vInstallLineSummaryAllDataGridView.Rows[e.RowIndex].Cells["lineSiteId"].Value);
                int installID = Convert.ToInt32(vInstallLineSummaryAllDataGridView.Rows[e.RowIndex].Cells["InstallID"].Value);
                if (vInstallLineSummaryAllDataGridView.Columns[e.ColumnIndex].Name == "Site")
                {





                    EditSite es = new EditSite(siteID);
                    es.ShowDialog();


                    this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
                }
                else
                {
                    if (vInstallLineSummaryAllDataGridView.Columns[e.ColumnIndex].Name == "SopID")
                    {
                        EditJob ej = new EditJob(jobId, false);
                        ej.ShowDialog();


                        this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
                    }
                    else
                    {
                        if (vInstallLineSummaryAllDataGridView.Columns[e.ColumnIndex].Name == "InstallID")
                        {
                            EditInstall ei = new EditInstall(installID);
                            ei.ShowDialog();


                            this.vInstallLineSummaryAllTableAdapter.FillBySiteID(this.sbi_installdbDataSet.vInstallLineSummaryAll, siteID);
                        }
                    }
                }

            }
        }

        private void ContactSite_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Save Changes?", "Save Changes?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (followUpCheckBox.Checked)
                {
                    SetReminder();
                }

                this.Validate();
                this.siteDetailsBindingSource.EndEdit();
                this.siteContactEventsBindingSource.EndEdit();

                this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);
            }
        }
    }
}
