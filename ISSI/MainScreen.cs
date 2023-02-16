using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ISSI.sbi_installdbDataSetTableAdapters;


namespace ISSI

{
    public partial class MainScreen : Form
    {

        private InstallList installList;
        private NavButtons navButtons;
        private Form backgroundForm;
        private sbi_installdbDataSet sbi_installdbDataSet;
        private SubConAreasTableAdapter subConAreasTableAdapter;
        public MainScreen()
        {


            InitializeComponent();

            Login login = new Login();
            login.ShowDialog();

            if (Session.loaded)
            {
                ;
                if (installList == null)
                {
                    slUser.Text = Session.UserName();

                    bool disable = Control.ModifierKeys == Keys.Shift;
                    if (Properties.Settings.Default.AutoImportSubCon && !disable)
                    {
                        sbi_installdbDataSet = new sbi_installdbDataSet();
                        subConAreasTableAdapter = new SubConAreasTableAdapter();
                        subConAreasTableAdapter.Fill(sbi_installdbDataSet.SubConAreas);
                        foreach (DataRow r in sbi_installdbDataSet.SubConAreas)
                        {
                            if (Convert.ToInt32(r["LinkToSchedule"]) == 1)
                            {
                                ImportSubCon import = new ImportSubCon(Convert.ToInt32(r["SubConAreaID"]));
                                import.GetImportTable();
                                import.UpdateSubConList(); 
                            }
                        }
                        
                    }
                    //MessageBox.Show("Loaded");
                    installList = new InstallList();
                }
                this.WindowState = FormWindowState.Maximized;


                navButtons = new NavButtons();
                this.Controls.Add(navButtons);
                navButtons.Dock = DockStyle.Top;
                navButtons.Dock = DockStyle.Left;
                navButtons.Enabled = true;
                navButtons.Visible = true;
                navButtons.BringToFront();

                this.LoadBackgroundForm(installList);


            }
            else
            {
                MessageBox.Show("Login failed");
                this.Load += new EventHandler(CloseOnStart);

            }

        }

        private void CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }




        public void LoadBackgroundForm(Form background)
        {
            if (backgroundForm != null)
            {
                backgroundForm.Close();
            }
            backgroundForm = background;

            backgroundForm.MdiParent = this;

            backgroundForm.Show();
            //backgroundForm.Dock = DockStyle.Fill;
            backgroundForm.WindowState = FormWindowState.Maximized;




        }




    }
}
