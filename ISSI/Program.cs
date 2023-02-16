using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.ConnectionUI;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;


namespace ISSI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string conStr = Properties.Settings.Default.sbi_salesdbConnectionString;
                using (SqlConnection conn = new SqlConnection(conStr))
                {

                    conn.Open();
                    MessageBox.Show("Connection OK");

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Invalid Connection String");
                string newConn;
                if (TryGetDataConnectionStringFromUser(out newConn))
                {


                    MessageBox.Show("Correct connection string for config file should be: \n" + newConn);


                }


            }
            Application.Run(new MainScreen());
        }
        static bool TryGetDataConnectionStringFromUser(out string outConnectionString)
        {
            using (var dialog = new DataConnectionDialog())
            {

                dialog.DataSources.Add(DataSource.SqlDataSource);
                dialog.DataSources.Add(DataSource.SqlFileDataSource);
                // The way how you show the dialog is somewhat unorthodox; `dialog.ShowDialog()`
                // would throw a `NotSupportedException`. Do it this way instead:
                DialogResult userChoice = DataConnectionDialog.Show(dialog);

                // Return the resulting connection string if a connection was selected:
                if (userChoice == DialogResult.OK)
                {
                    outConnectionString = dialog.ConnectionString;
                    return true;
                }
                else
                {
                    outConnectionString = null;
                    return false;
                }
            }
        }
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
        }

    }
}
