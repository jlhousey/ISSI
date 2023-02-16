using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ISSI
{
    public partial class WeekView : Form
    {

        List<Job> selectedJobs = new List<Job>();
        bool layoutChanged = false;
        bool editing = false;
        public WeekView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (layoutChanged)
            {
                DialogResult dr = MessageBox.Show("Save Changes?", "Save Changes?", MessageBoxButtons.YesNoCancel);
             
                if (dr == DialogResult.Yes)
                {
                    foreach (Job j in tlpWeekLayout.Controls)
                    {
                        if (j.haschanged)
                        {
                            
                            int col = this.tlpWeekLayout.GetColumn(j);
                            j.updateInstall(col);
                        }
                    }  
                }

               
            }



            // foreach (Control j in this.tlpWeekLayout.Controls)
            //{
            //    tlpWeekLayout.Controls.Remove(j);
            //    j.Dispose();

            //}

            //foreach (Control j in this.tlpHolding.Controls)
            //{
            //    tlpHolding.Controls.Remove(j);
            //    j.Dispose();

            //}
            HandleRef gh = new HandleRef(this.tlpWeekLayout, this.tlpWeekLayout.Handle);
            HandleRef gh2 = new HandleRef(this.tlpWeekLayout, this.tlpHolding.Handle);
            Session.EnableRepaint(gh, false);
            Session.EnableRepaint(gh2, false);
            List<Control> ctrls = new List<Control>();
            
            foreach (Control c in tlpWeekLayout.Controls)
            {
                ctrls.Add(c);
            }
            foreach (Control d in this.tlpHolding.Controls)
            {
                ctrls.Add(d);
            }


                tlpWeekLayout.Controls.Clear();
            tlpHolding.Controls.Clear();

            foreach (Control c in ctrls)
            {
                c.Dispose();
            }

            DateTime fdow= wcPicker.Value.AddDays(-(int)wcPicker.Value.DayOfWeek + (int)DayOfWeek.Monday);
            
            lblMon.Text ="Mon- " + Convert.ToString(fdow);
            lblTue.Text = "Tue- " + Convert.ToString(fdow.AddDays(1));
            lblWed.Text = "Wed- " + Convert.ToString(fdow.AddDays(2));
            lblThur.Text = "Thu- " + Convert.ToString(fdow.AddDays(3));
            lblFri.Text = "Fri- " + Convert.ToString(fdow.AddDays(4));

            string weekCommencing = fdow.ToShortDateString();
                this.vInstallLineSummaryInstallOnlyTableAdapter.FillByInstallDate(this.sbi_installdbDataSet.vInstallLineSummaryInstallOnly, weekCommencing);
                this.JobTypesTableAdapter.Fill(this.sbi_installdbDataSet.JobTypes);
                for (int i = 0; i < 6; i++)
                {
                var rows = this.sbi_installdbDataSet.vInstallLineSummaryInstallOnly.AsEnumerable()
           .Where(row => row.Field<int?>("InstallDay") == i)
               .OrderBy(row => row.Field<int?>("JobType")).ThenByDescending(row => row.Field<int?>("SiteID"));



                    if (rows.Any())
                    {
                        DataTable tblFiltered = rows.CopyToDataTable();
                        int k = 0;
                        foreach (DataRow r in tblFiltered.Rows)
                        {

                            Job j = new Job(Convert.ToInt32(r["InstallID"]), Convert.ToInt32(r["SiteID"]));
                            if (!String.IsNullOrWhiteSpace(Convert.ToString(r["JobType"].ToString())))
                            {
                                int catID = Convert.ToInt32(r["JobType"]);
                                
                                

                                


                                Color col = ColorTranslator.FromHtml("#" + this.sbi_installdbDataSet.JobTypes.FindByTypeID(catID)["ColourCode"].ToString());

                                j.BackColor = col;
                                j.backColor = col;
                                foreach (Control c in j.Controls)
                                {
                                    c.BackColor = col;
                                }
                            j.workScheduleDataGridView.BackgroundColor = col;
                        }
                        j.ragbox.ForeColor = Color.White;
                        j.ragbox.BackColor = Color.Black;
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(r["RAG"].ToString())))
                        {
                            int rag = Convert.ToInt32(r["RAG"]);
                            
                            switch (rag)
                            {
                                case 1:
                                    j.ragbox.ForeColor = Color.Red;
                                    j.ragbox.Visible = true;
                                    break;
                                case 2:
                                    j.ragbox.ForeColor = Color.Orange;
                                    j.ragbox.Visible = true;
                                    break;
                                case 3:
                                    j.ragbox.ForeColor = Color.Green;
                                    j.ragbox.Visible = true;
                                    break;
                            }
                      
                        }
                        //j.DoubleClick += new EventHandler(jobDblClick);
                        //    j.Click += new EventHandler(jobClick);
                            {

                                this.tlpWeekLayout.Controls.Add(j, i, k);
                            }
                            k++;
                        }
                    }
                }

            var rows2 = this.sbi_installdbDataSet.vInstallLineSummaryInstallOnly.AsEnumerable()
           .Where(row => row.Field<int?>("InstallDay") == null || row.Field<int?>("InstallDay") > 5 || row.Field<int?>("InstallDay") < 0)
           .OrderBy(row => row.Field<int?>("JobType")).ThenByDescending(row => row.Field<int?>("SiteID"));
               
            if (rows2.Any())
            {
                DataTable tblFiltered2 = rows2.CopyToDataTable();
                int m = 0;
                foreach (DataRow r in tblFiltered2.Rows)
                {

                    Job j = new Job(Convert.ToInt32(r["InstallID"]), Convert.ToInt32(r["SiteID"]));
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(r["JobType"].ToString())))
                    {
                        int catID = Convert.ToInt32(r["JobType"]);
                        Color col = ColorTranslator.FromHtml("#" + this.sbi_installdbDataSet.JobTypes.FindByTypeID(catID)["ColourCode"].ToString());

                        j.BackColor = col;
                        j.backColor = col;
                        foreach (Control c in j.Controls)
                        {
                            c.BackColor = col;


                        }
                        j.workScheduleDataGridView.BackgroundColor = col;
                    }
                    j.ragbox.ForeColor = Color.White;
                    j.ragbox.BackColor = Color.Black;
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(r["RAG"].ToString())))
                    {
                        int rag = Convert.ToInt32(r["RAG"]);

                        switch (rag)
                        {
                            case 1:
                                j.ragbox.ForeColor = Color.Red;
                                j.ragbox.Visible = true;
                                break;
                            case 2:
                                j.ragbox.ForeColor = Color.Orange;
                                j.ragbox.Visible = true;
                                break;
                            case 3:
                                j.ragbox.ForeColor = Color.Green;
                                j.ragbox.Visible = true;
                                break;
                        }

                    }
                    //j.DoubleClick += new EventHandler(jobDblClick);
                    //j.Click += new EventHandler(jobClick);


                    {

                        this.tlpHolding.Controls.Add(j, 0, m);
                    }
                    m++;
                }  
            }
            ReOrderPanel(tlpHolding, -1);
            ReOrderPanel(tlpWeekLayout, -1);
            Session.EnableRepaint(gh, true);
            Session.EnableRepaint(gh2, true);
            
            this.tlpHolding.Refresh();
            this.tlpWeekLayout.Refresh();
            
            //foreach (Job j in this.tlpHolding.Controls)
            //{
            //    //j.Invalidate();
            //    //j.Update();
            //    j.Refresh();
            //}
            //foreach (Job j in this.tlpWeekLayout.Controls)
            //{
            //    //j.Invalidate();
            //    //j.Update();
            //    j.Refresh();
            //}

        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        void jobDblClick(object sender, EventArgs e)
        {
            Job j = sender as Job;
            jobClick(j, EventArgs.Empty);

            TableLayoutPanel tlp = (TableLayoutPanel)j.Parent;

            //int col = tlp.GetColumn(j);
            //int row = tlp.GetRow(j);
            //for (int i = tlp.RowCount; i >= row; i--)
            //{
            //    if (tlp.GetControlFromPosition(col, i) != null)
            //    {
            //        tlp.SetRow(tlp.GetControlFromPosition(col, i), i + selectedJobs.Count);
            //    }
            //}
            var cellPos = GetRowColIndex(tlp, tlp.PointToClient(Cursor.Position));
            int col = cellPos[0];
            pasteJobs(tlp, col);
            ReOrderPanel(tlpHolding, -1);
            ReOrderPanel(tlpWeekLayout, -1);

        }

        void jobClick(object sender, EventArgs e)
        {
            Job j = sender as Job;
            

            if (j.selected)
            {
                j.BackColor = j.backColor;
                selectedJobs.Remove(j);
            }
            else
            {
                j.BackColor = Color.Cyan;
                selectedJobs.Add(j);
            }

            j.selected = !j.selected;
        }
        private void saveChanges_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.vInstallLineSummaryInstallOnlyBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.sbi_installdbDataSet);
            foreach (Job j in tlpWeekLayout.Controls)
            {
                if (j.haschanged)
                {
                    
                    int col = this.tlpWeekLayout.GetColumn(j);
                    j.updateInstall(col);
                }
            }
            foreach (Job j in tlpHolding.Controls)
            {
                if (j.haschanged)
                {

                    
                    j.updateInstall(-1);
                }
            }

        }

        private void WeekView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.vInstallLineSummaryInstallOnly' table. You can move, or remove it, as needed.
            //this.vInstallLineSummaryInstallOnlyTableAdapter.Fill(this.sbi_installdbDataSet.vInstallLineSummaryInstallOnly);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.JobTypes' table. You can move, or remove it, as needed.
            //this.JobTypesTableAdapter.Fill(this.sbi_installdbDataSet.JobTypes);
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.InstallSchedule' table. You can move, or remove it, as needed.
            //this.vInstallLineSummaryInstallOnlyTableAdapter.Fill(this.sbi_installdbDataSet.vInstallLineSummaryInstallOnly);

        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            var cellPos = GetRowColIndex(tlpWeekLayout, tlpWeekLayout.PointToClient(Cursor.Position));
            int col = cellPos[0];
            pasteJobs(tlpWeekLayout,col);
            ReOrderPanel(tlpWeekLayout, col);
            ReOrderPanel(tlpHolding, -1);
        }

        private void tableLayoutPanel2_MouseClick(object sender, MouseEventArgs e)
        {
            var cellPos = GetRowColIndex(tlpHolding, tlpHolding.PointToClient(Cursor.Position));
            int col = cellPos[0];
            pasteJobs(tlpHolding,col);
            ReOrderPanel(tlpWeekLayout, -1);
        }

        private void pasteJobs( TableLayoutPanel tlp, int col)
        {
            HandleRef gh = new HandleRef(tlp, tlp.Handle);

            Session.EnableRepaint(gh, false);
            for (int i = 0; i<tlp.RowCount && (tlp.GetControlFromPosition(col, i) != null); i++)
            {
                Job j = (Job)tlp.GetControlFromPosition(col, i);
                selectedJobs.Add(j);
                

            }

            for (int i = 0; i < tlp.RowCount && (tlp.GetControlFromPosition(col, i) != null); i++)
            {
                Job j = (Job)tlp.GetControlFromPosition(col, i);
                
                tlp.Controls.Remove(j);

            }

            List<Job> selectedJobs2 = selectedJobs.OrderBy(j=> j.jobtype).ThenBy(j=> j.siteid).ToList();
                                                                                                              
            


            foreach (Job k in selectedJobs2)
            {
                tlp.Controls.Add(k, col, selectedJobs2.IndexOf(k));
                k.haschanged = true;
                k.BackColor = k.backColor;
                k.selected = false;

            }
            selectedJobs.Clear();
            layoutChanged = true;
            Session.EnableRepaint(gh, true);


            tlp.Refresh();

        }

        private void ReOrderPanel (TableLayoutPanel tlp, int col)
        {
            HandleRef gh = new HandleRef(tlp, tlp.Handle);
            
            Session.EnableRepaint(gh, false);
            
            for (int i = 0; i < tlp.ColumnCount; i++)
            {
                if (i != col)
                {
                    List<Job> reorderJobs = new List<Job>();
                    for (int k = 0; k < tlp.RowCount ; k++)
                    {
                        Job j = (Job)tlp.GetControlFromPosition(i, k);
                        if (j !=null)
                        {
                            reorderJobs.Add(j);
                            
                        }

                    }

                    for (int k = 0; k < tlp.RowCount; k++)
                    {
                        Job j = (Job)tlp.GetControlFromPosition(i, k);
                        if (j != null)
                        {
                            
                            tlp.Controls.Remove(j);
                        }

                    }

                    List<Job> reorderJobs2 = reorderJobs.OrderBy(p => p.jobtype).ThenBy(p => p.siteid).ToList();
                    if (reorderJobs.Count >0)
                    {
                        foreach (Job l in reorderJobs2)
                        {
                            tlp.Controls.Add(l, i, reorderJobs2.IndexOf(l));

                        } 
                    }
                }
            }
            Session.EnableRepaint(gh, true);
            

            tlp.Refresh();
           
        }
        int[] GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            int[] xy = new int[] { col, row };

            return xy;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void wcPicker_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DateTime fdow = wcPicker.Value.AddDays(-(int)wcPicker.Value.DayOfWeek + (int)DayOfWeek.Monday -7);
            wcPicker.Value = fdow;
            btnLoad.PerformClick();
            button2.Text = "Unlock Layout";
        }

        private void btnFwd_Click(object sender, EventArgs e)
        {
            DateTime fdow = wcPicker.Value.AddDays(-(int)wcPicker.Value.DayOfWeek + (int)DayOfWeek.Monday + 7);
            wcPicker.Value = fdow;
            btnLoad.PerformClick();
            button2.Text = "Unlock Layout";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editing = !editing;

            if (editing)
            {
                button2.Text = "Lock Layout";

                foreach (Control c in tlpHolding.Controls)
                {
                    c.DoubleClick += new EventHandler(jobDblClick);
                    c.Click += new EventHandler(jobClick);
                }

                foreach (Control c in tlpWeekLayout.Controls)
                {
                    c.DoubleClick += new EventHandler(jobDblClick);
                    c.Click += new EventHandler(jobClick);
                } 
            }
            else
            {
                button2.Text = "Unlock Layout";
                foreach (Control c in tlpHolding.Controls)
                {
                    c.DoubleClick -= new EventHandler(jobDblClick);
                    c.Click -= new EventHandler(jobClick);
                }

                foreach (Control c in tlpWeekLayout.Controls)
                {
                    c.DoubleClick -= new EventHandler(jobDblClick);
                    c.Click -= new EventHandler(jobClick);
                }
            }
        }
    }
}
