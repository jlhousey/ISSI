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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int userID = (int)this.cbUserID.SelectedValue;
            sbi_installdbDataSet.OpsPlannerRow userRow = this.sbi_installdbDataSet.OpsPlanner.FindByOpsPlannerID(userID);
            string userPassword = userRow.Password;

            if (this.tbPassword.Text == userPassword)
            {
                Session.Login(userID);


                //EditDeveloper ed = new EditDeveloper();

                //ed.Show();
                this.Close();



            }
            else
            {
                MessageBox.Show("Invalid password");

            }


        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sbi_installdbDataSet.OpsPlanner' table. You can move, or remove it, as needed.
            this.opsPlannerTableAdapter.Fill(this.sbi_installdbDataSet.OpsPlanner);
            // TODO: This line of code loads data into the 'sbi_salesdbDataSet.Users' table. You can move, or remove it, as needed.
            this.UsersTableAdapter.Fill(this.sbi_salesdbDataSet.Users);
            UsersBindingSource.Sort = "Name";

        }
    }
}
