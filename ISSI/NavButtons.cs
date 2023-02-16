using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISSI.sbi_installdbDataSetTableAdapters;

namespace ISSI
{
    public partial class NavButtons : UserControl
    {
        private sbi_installdbDataSet sbi_installdbDataSet;
        private SubConAreasTableAdapter subConAreasTableAdapter;
        private PurchasingAreasTableAdapter purchasingAreasTableAdapter;
        public NavButtons()
        {
            InitializeComponent();
        }

        private void btnPurchaseOrders_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            InstallListAll ila = mf.ActiveMdiChild as InstallListAll;
            InstallList il = mf.ActiveMdiChild as InstallList;

            if (ila != null)
            {
                ila.saveChanges();
            }
            else
            {
                if (il != null)
                {
                    il.saveChanges();
                }
            }

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

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            InstallListAll ila = mf.ActiveMdiChild as InstallListAll;
            InstallList il = mf.ActiveMdiChild as InstallList;

            if (ila != null)
            {
                ila.saveChanges();
            }
            else
            {
                if (il != null)
                {
                    il.saveChanges();
                }
            }
            WeekView wv = new ISSI.WeekView();
            wv.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            InstallListAll ila = mf.ActiveMdiChild as InstallListAll;
            InstallList il = mf.ActiveMdiChild as InstallList;

            if (ila != null)
            {
                ila.saveChanges();
            }
            else
            {
                if (il != null)
                {
                    il.saveChanges();
                }
            }
            sbi_installdbDataSet = new sbi_installdbDataSet();
            purchasingAreasTableAdapter = new PurchasingAreasTableAdapter();
            purchasingAreasTableAdapter.Fill(sbi_installdbDataSet.PurchasingAreas);
            foreach (DataRow r in sbi_installdbDataSet.PurchasingAreas)
            {
                if (Convert.ToInt32(r["LinkToSMS"]) == 1)
                {
                    ImportPurchasing import = new ImportPurchasing(Convert.ToInt32(r["PurchasingID"]));
                    import.GetImportTable();
                    import.UpdatePurchasingList();
                }
            }

        }

        private void btnSOPList_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            SOPReg sr = mf.ActiveMdiChild as SOPReg;
            ClientList2 cl = mf.ActiveMdiChild as ClientList2;
            if (sr != null)
            {
                sr.saveChanges();
            }
            else
            {
                if (cl != null)
                {
                    cl.saveChanges();
                }
            }
            SelectClient sc = new SelectClient();
            sc.ShowDialog();
            if (sr != null)
            {
                sr.RefreshAfterAdd();
                //mf.LoadBackgroundForm(sr);
            }
            else
            {

                if (cl != null)
                {
                    cl.RefreshAfterAdd();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int jobID = 0;
            MainScreen mf = this.FindForm() as MainScreen;
            SOPReg sr = mf.ActiveMdiChild as SOPReg;
            ClientList2 cl = mf.ActiveMdiChild as ClientList2;
            if (sr != null)
            {
                sr.saveChanges();
            }
            else if (cl != null)
            {
                cl.saveChanges();
            }
            ;

            using (SelectClient sc = new SelectClient(true))
            {

                var result = sc.ShowDialog();
                if (result == DialogResult.OK)
                {
                    jobID = sc.returnNewJob;

                }

            }

            if (sr != null)
            {
                sr.RefreshAfterAdd(jobID);
                //mf.LoadBackgroundForm(sr);
            }
            else
            {

                if (cl != null)
                {
                    cl.RefreshAfterAdd(jobID);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            SOPReg sr = mf.ActiveMdiChild as SOPReg;
            InstallList cl = mf.ActiveMdiChild as InstallList;

            if (sr != null)
            {
                sr.saveChanges();
            }
            else
            {
                if (cl != null)
                {
                    cl.saveChanges();
                }
            }


            mf.LoadBackgroundForm(new InstallList());
        }

        private void btnDepOverview_Click(object sender, EventArgs e)
        {

        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            SOPReg sr = mf.ActiveMdiChild as SOPReg;
            InstallList cl = mf.ActiveMdiChild as InstallList;

            if (sr != null)
            {
                sr.saveChanges();
            }
            else
            {
                if (cl != null)
                {
                    cl.MarkInstalled();
                }
            }


            mf.LoadBackgroundForm(new InstallList());
        }

        private void btnLeadScreen_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            InstallListAll ila = mf.ActiveMdiChild as InstallListAll;
            InstallList il = mf.ActiveMdiChild as InstallList;

            if (ila != null)
            {
                ila.saveChanges();
            }
            else
            {
                if (il != null)
                {
                    il.saveChanges();
                }
            }



            mf.LoadBackgroundForm(new InstallListAll());

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            InstallListAll ila = mf.ActiveMdiChild as InstallListAll;
            InstallList il = mf.ActiveMdiChild as InstallList;

            if (ila != null)
            {
                ila.saveChanges();
            }
            else
            {
                if (il != null)
                {
                    il.saveChanges();
                }
            }

            SelectSite ss = new SelectSite();
            ss.ShowDialog();
            if (ila != null)
            {
                ila.RefreshAfterAdd();
                //mf.LoadBackgroundForm(sr);
            }
            else
            {

                if (il != null)
                {
                    il.RefreshAfterAdd();
                }
            }


        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btPOList_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            SOPReg sr = mf.ActiveMdiChild as SOPReg;
            ClientList2 cl = mf.ActiveMdiChild as ClientList2;

            if (sr != null)
            {
                sr.saveChanges();
            }
            else
            {
                if (cl != null)
                {
                    cl.saveChanges();
                }
            }

            SelectJob sj = new SelectJob();
            sj.ShowDialog();
            if (sr != null)
            {
                sr.RefreshAfterAdd();
                //mf.LoadBackgroundForm(sr);
            }
            else
            {

                if (cl != null)
                {
                    cl.RefreshAfterAdd();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            InstallListAll ila = mf.ActiveMdiChild as InstallListAll;
            InstallList il = mf.ActiveMdiChild as InstallList;

            if (ila != null)
            {
                ila.saveChanges();
            }
            else
            {
                if (il != null)
                {
                    il.saveChanges();
                }
            }

            ContactList cl = new ContactList();
            cl.ShowDialog();
            if (ila != null)
            {
                ila.RefreshAfterAdd();
                //mf.LoadBackgroundForm(sr);
            }
            else
            {

                if (il != null)
                {
                    il.RefreshAfterAdd();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            SOPReg sr = mf.ActiveMdiChild as SOPReg;
            ClientList2 cl = mf.ActiveMdiChild as ClientList2;
            if (sr != null)
            {
                sr.saveChanges();
            }
            else
            {
                if (cl != null)
                {
                    cl.saveChanges();
                }
            }

            SelectDAM sd = new SelectDAM();
            sd.ShowDialog();
            if (sr != null)
            {
                sr.RefreshAfterAdd();
                //mf.LoadBackgroundForm(sr);
            }
            else
            {

                if (cl != null)
                {
                    cl.RefreshAfterAdd();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainScreen mf = this.FindForm() as MainScreen;
            InstallListAll ila = mf.ActiveMdiChild as InstallListAll;
            InstallList il = mf.ActiveMdiChild as InstallList;

            if (ila != null)
            {
                ila.saveChanges();
            }
            else
            {
                if (il != null)
                {
                    il.saveChanges();
                }
            }

            SubContractSchedules scs = new SubContractSchedules();
            scs.ShowDialog();
            if (ila != null)
            {
                ila.RefreshAfterAdd();
                //mf.LoadBackgroundForm(sr);
            }
            else
            {

                if (il != null)
                {
                    il.RefreshAfterAdd();
                }
            }


        }
    }
}
