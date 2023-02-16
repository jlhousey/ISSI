using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;

namespace ISSI
{
    public partial class MovementDialog : Form
    {
        private int[] installids;
        private DateTime moveto;
        private bool movement = true;

        public MovementDialog()
        {
            InitializeComponent();
        }

        public MovementDialog(int[] installIDs)
        {
            InitializeComponent();
            installids = installIDs;
            movement = false;
            comboBox1.Visible = false;
            label2.Visible = false;
           
        }
        public MovementDialog(int[] installIDs, DateTime moveTo)
        {
            InitializeComponent();
            installids = installIDs;
            moveto = moveTo;
            
        }

        private void MovementDialog_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.MovementCodes' table. You can move, or remove it, as needed.
            this.movementCodesTableAdapter.Fill(this.sbi_installdbDataSet.MovementCodes);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string by = "";
            string mf = "";
            string mt = "";
            string softs = "";

            foreach (int i in installids)
            {
               
                

                this.installScheduleTableAdapter1.Fill(this.sbi_installdbDataSet.InstallSchedule);
                DataRow instline = this.sbi_installdbDataSet.InstallSchedule.FindByInstallID(i);
                DataRow r = this.sbi_installdbDataSet.Movements.NewRow();
                if (movement)
                {
                    r["MovementCode"] = comboBox1.SelectedValue;
                }
                else

                {
                    r["MovementCode"] = 4;

                }
                r["MoveDate"] = DateTime.Today;
                r["installID"] = i;
                r["MoveFrom"] = instline["InstallDate"];
                if (movement) {
                    r["MoveTo"] = moveto;
                    mt = Convert.ToString(moveto);
                    mf = Convert.ToString(instline["InstallDate"]);
                   
                }
                else
                {
                    r["MoveTo"]= instline["InstallDate"];
                    mt = Convert.ToString(instline["InstallDate"]);
                }
                r["Notes"] = this.textBox1.Text;

                this.sbi_installdbDataSet.Movements.Rows.Add(r);

                


            }
            this.movementsTableAdapter.Update(this.sbi_installdbDataSet.Movements);
            //DialogResult dr = MessageBox.Show("Generate Email", "Email?", MessageBoxButtons.YesNo);
            GenerateEmailDialog ged = new GenerateEmailDialog();
            DialogResult dr = ged.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                bool showtrail = ged.trail;
                DataTable dt = this.sbi_installdbDataSet.vEmailLines.Clone();
                foreach (int i in installids)
                {
                    this.vEmailLinesTableAdapter1.FillByInstallID(this.sbi_installdbDataSet.vEmailLines, i);
                    DataRow s = this.sbi_installdbDataSet.vEmailLines.FindByInstallID(i);
                    if (movement)
                    {
                        s["InstallDate"] = moveto; 
                    }
                    dt.Rows.Add(s.ItemArray);

                    this.vEmailSubconTableAdapter1.FillByInstallID(this.sbi_installdbDataSet.vEmailSubcon, i);
                    if (this.sbi_installdbDataSet.vEmailSubcon.Rows.Count > 0)
                    {
                        foreach (DataRow r in this.sbi_installdbDataSet.vEmailSubcon.Rows)
                        {
                            try { softs += "<p>" + Convert.ToString(r["InstallID"]) +" - " + Convert.ToString(r["Supplier"]) + " - " + Convert.ToString(r["Installing"]) + " </p>"; }
                            catch { softs += "<p>" + Convert.ToString(r["InstallID"]) + " - Softs TBC </p>"; }
                        }
                    }
                }

                if (movement)
                {
                    by += "<b>Installation moved from W/C " + mf + " into W/C " + mt + "</b><br><br>";

                }
                else
                {
                    by += "<b>Installation W/C " + mt +"</b><br><br>";
                }
               


                //string by = HTMLGenerator.ConvertDataTableToHTML(dt);
                this.vEmailSitesTableAdapter1.Fill(this.sbi_installdbDataSet.vEmailSites);
                DataTable ds = this.sbi_installdbDataSet.SiteDetails;
                string[] eby = HTMLGenerator.GenerateSiteSplit(dt, this.sbi_installdbDataSet.vEmailSites);
                string by1 = eby[0];


                by += by1;
                by += "<br>";
                

                by += this.textBox1.Text;
                by += "<br><br>";
                by += softs;
                if (showtrail)
                {
                    foreach (int i in installids)
                    {

                        this.vEmailMovementsTableAdapter1.FillByInstallID(this.sbi_installdbDataSet.vEmailMovements, i);
                        DataTable dt3 = this.sbi_installdbDataSet.vEmailMovements.AsEnumerable().OrderByDescending(row => row.Field<int?>("JobType")).CopyToDataTable();
                        
                        for (int k = 4; k < 8; k++)
                        {
                            by += "<b>" + Convert.ToString(dt3.Rows[0][k]) + ", </b>";
                        }
                        dt3.Rows.RemoveAt(0);
                        dt3.Columns.Remove("SOPID");
                        dt3.Columns.Remove("HouseType");
                        dt3.Columns.Remove("InstallID");
                        dt3.Columns.Remove("Product");

                        string moves = HTMLGenerator.ConvertDataTableToHTML(dt3);
                        by += moves.Replace("MoveDate", "Date") + "<br><br>";
                    } 
                }
                string by3 = by.Replace("00:00:00", "");
                string by2 = by3.Replace("\r\n", "<br>");
                string et = "";
                if (movement)
                {
                    et += "Change to Schedule - ";

                }
                else
                {
                    et += "Addition to Schedule - ";
                }
                et += eby[1];
                EmailFile("test", by2, et);
            }
            this.Close();
        }

        private void EmailFile(string filepath, string body, string title)
        {

            try
            {



                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                oMailItem.HTMLBody = "<FONT size = \"2\" face=\"Arial\">";
                oMailItem.HTMLBody += body;


                if (filepath != "test")
                {
                    Microsoft.Office.Interop.Outlook.Attachment oAttach = oMailItem.Attachments.Add(filepath);
                }
                oMailItem.Subject = title;

                Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMailItem.Recipients;

                Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add("Additions Team");
                oRecip.Resolve();
                // Send.
                // oMsg.Send();
                // Clean up.
                oMailItem.Display(true);
                oRecip = null;
                oRecips = null;
                oMailItem = null;
                outlookApp = null;
            }

            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
