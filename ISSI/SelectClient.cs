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
    public partial class SelectClient : Form
    {
        private bool newItem = false;
        public int returnNewJob = 0;
        public string returnNewFilter = "";
        public int returnNewSite = 0;
        public SelectClient()
        {
            InitializeComponent();
        }

        public SelectClient(bool newJob)
        {
            InitializeComponent();
            newItem = newJob;
            if (newJob)
            {
                this.Text = "Create New Job";

            }
            else
            {
                this.Text = "Create New Site";
                returnNewSite = -1;
            }
        }



        private void developerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.developerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sbi_salesdbDataSet);

        }

        private void SelectClient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.sbi_salesdbDataSet.Client);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Developer' table. You can move, or remove it, as needed.
            this.developerTableAdapter.Fill(this.sbi_salesdbDataSet.Developer);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Nothing Selected");

            }
            else

            {
                int clientID = Convert.ToInt32(comboBox2.SelectedValue);
                if (newItem)
                {

                    using (EditJob ej = new EditJob(clientID, true))
                    {
                        this.DialogResult = DialogResult.OK;
                        var result = ej.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            returnNewJob = ej.returnJobId;

                        }

                    }



                }
                else
                {



                    if (returnNewSite != -1)
                    {
                        EditClient ec = new EditClient(clientID);
                        ec.ShowDialog();
                    }
                    else
                    {
                        if (clientID != -1)
                        {
                            string connectionString = Properties.Settings.Default.sbi_salesdbConnectionString;
                            string commandText = "CreateSite";
                            int cID = clientID;
                            int newSite;

                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.Add(new SqlParameter("@ClientID", cID));
                                    SqlParameter SiteID = new SqlParameter("@SiteID", SqlDbType.Int);
                                    SiteID.Direction = ParameterDirection.Output;
                                    cmd.Parameters.Add(SiteID);

                                    conn.Open();
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("SiteID" + SiteID.Value);
                                    newSite = Convert.ToInt32(SiteID.Value);
                                }
                            }



                            using (EditSite es = new EditSite(newSite))
                            {
                                this.DialogResult = DialogResult.OK;
                                var result = es.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    returnNewSite = newSite;
                                    returnNewFilter = es.newFilter;

                                }

                            }

                        }

                    }
                }

            }
        }
    }
}
