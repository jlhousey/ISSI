using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Diagnostics;
using ISSI.sbi_installdbDataSetTableAdapters;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace ISSI
{
    public static class Session
    {
        private static int userID;
        private static DateTime loggedOn;
        public static bool loaded = false;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(HandleRef hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        
        public static void EnableRepaint(HandleRef handle, bool enable)
        {
            const int WM_SETREDRAW = 0x000B;
            SendMessage(handle, WM_SETREDRAW, new IntPtr(enable ? 1 : 0), IntPtr.Zero);
        }



        public static void Login(int id)
        {

            userID = id;
            loggedOn = DateTime.Now;
            loaded = true;

        }

        public static void Logout()
        {
            userID = 0;



        }

        public static string UserName()
        {
            OpsPlannerTableAdapter usersTableAdapter = new OpsPlannerTableAdapter();
            sbi_installdbDataSet.OpsPlannerDataTable users = usersTableAdapter.GetData();
            string userName = users.FindByOpsPlannerID(userID).Name;
            return userName;

        }
        public static int UserID
        {
            get { return userID; }
        }

        public static DateTime LoggedOn()
        {
            return loggedOn;

        }


        public static void Log(string[] logMessage)
        {
            StreamWriter w = new StreamWriter("log.txt", true);

            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            var type = method.DeclaringType;
            var name = method.Name;
            w.WriteLine(type.ToString());
            w.WriteLine(method.ToString());
            foreach (string s in logMessage)

            {
                w.WriteLine("  :");
                w.WriteLine("  :{0}", s);
                w.WriteLine("-------------------------------");

            }


        }
        public static void Log(string logMessage)
        {
            StreamWriter w = File.AppendText("log.txt");
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            var type = method.DeclaringType;
            var name = method.Name;
            w.WriteLine(type.ToString());
            w.WriteLine(method.ToString());

            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");




        }

        public static void DumpLog()
        {
            StreamReader r = File.OpenText("log.txt");
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }


        public static byte[] Encrypt(string clearText)
        {
            string EncryptionKey = "Showbiz01";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearBytes = ms.ToArray();
                }
            }
            return clearBytes;
        }
        public static string Decrypt(byte[] cipherBytes)
        {
            string EncryptionKey = "Showbiz01";
            string cipherText = null;
            if (cipherBytes != null)
            {

                try
                {
                    //cipherBytes = Convert.FromBase64String(cipherText);
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(cipherBytes, 0, cipherBytes.Length);
                                cs.Close();
                            }
                            cipherText = Encoding.Unicode.GetString(ms.ToArray());
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to decrypt data");

                }
            }

            return cipherText;
        }
    }

}

