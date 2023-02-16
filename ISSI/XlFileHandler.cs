using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Windows.Forms;
using System.IO;


namespace ISSI
{
    public class XlFileHandler

    {
        //Initial directory for fileselector dialog
        private string rootPath;
        //Temporary file name to be copied to
        private string destFile;
        //Full file name of target file
        private string fileName;
        //Destination path of folder to save in
        private string destPath;
        public string FileName
        {
            get
            {
                return fileName;
            }
        }

        public XlFileHandler()
        {
            rootPath = "c:\\";
            fileName = GetFile();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select destination file";
            fdlg.InitialDirectory = @rootPath;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                destPath = Path.GetDirectoryName(fdlg.FileName);
                destFile = fdlg.SafeFileName;

            }
            else
            {
                try
                {
                    destPath = Properties.Settings.Default.TempFileDirectory;
                    destFile = "temp.xlsx";
                    MessageBox.Show("No destination selected- default location is " + destPath);
                }
                catch
                {
                    MessageBox.Show("No destination selected. Cannot read default setting. Please check your configuration settings");
                }

                fdlg.Dispose();
            }



        }
        public XlFileHandler(string rtPath, string dstFile)
        {
            rootPath = rtPath;
            destFile = dstFile;
            fileName = GetFile();
            try
            {
                destPath = Properties.Settings.Default.TempFileDirectory;

            }
            catch
            {
                MessageBox.Show("Error reading temporary file location. Please check your configuration settings");
            }
        }

        public XlFileHandler(string rtPath)
        {
            rootPath = rtPath;
            fileName = GetFile();
            destFile = "SAPOSimport" + Session.UserName() + ".xlsx";
            try
            {
                destPath = Properties.Settings.Default.TempFileDirectory;

            }
            catch
            {
                MessageBox.Show("Error reading temporary file location. Please check your configuration settings");
            }
        }

        public XlFileHandler(string rtPath, string dstFile, string flName, string dstPath)
        {
            rootPath = rtPath;
            destFile = dstFile;
            fileName = flName;
            destPath = dstPath;

        }

        public void ImportFileSelect()
        {
            fileName = GetFile();

        }
        public string OutputFile()
        {
            string fullDestPath = System.IO.Path.Combine(destPath, destFile);
            return fullDestPath;
        }

        public string GetFile()
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select file to import";
            if (!System.IO.Directory.Exists(@rootPath))
            {
                MessageBox.Show(rootPath + " does not exist.");
                rootPath = "c:\\";

            }
            fdlg.InitialDirectory = @rootPath;
            fdlg.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fdlg.Dispose();
                return fdlg.FileName;

            }
            else
            {
                MessageBox.Show("Warning- No file selected", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fdlg.Dispose();
                return null;

            }

        }

        public void TempFileCopy()
        {
            destPath = Properties.Settings.Default.TempFileDirectory;


            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(@destPath))
            {
                System.IO.Directory.CreateDirectory(@destPath);
            }

            string fullDestPath = System.IO.Path.Combine(destPath, destFile);
            System.IO.File.Copy(@fileName, @fullDestPath, true);

        }

        public void FileCopy(bool warn)
        {

            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(@destPath))
            {
                System.IO.Directory.CreateDirectory(@destPath);

                if (warn)
                {
                    MessageBox.Show("Destination location created" + destPath);
                }

            }

            string fullDestPath = System.IO.Path.Combine(destPath, destFile);

            if (warn)
            {
                if (!System.IO.File.Exists(@fullDestPath) || MessageBox.Show("File already exists, overwite?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.IO.File.Copy(@fileName, @fullDestPath, true);
                }
            }
            else
            {
                if (fileName == null)
                {
                    MessageBox.Show("File copy failed, filename is null");

                }
                else
                {
                    System.IO.File.Copy(@fileName, @fullDestPath, true);
                }

            }



        }

        private bool ValidateFile(string importFile)
        {
            if (System.IO.File.Exists(@importFile))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<string> OutputSheets()
        {
            if (ValidateFile(OutputFile()))
            {
                List<string> sheetNames = new List<string>();
                string fullDestPath = System.IO.Path.Combine(destPath, destFile);
                using (SpreadsheetDocument ssDocument = SpreadsheetDocument.Open(@fullDestPath, false))
                {
                    WorkbookPart wbPart = ssDocument.WorkbookPart;
                    IEnumerable<Sheet> sheets = wbPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();

                    foreach (Sheet s in sheets)
                    {
                        string name = s.Name;
                        sheetNames.Add(name);

                    }



                }
                return sheetNames;
            }
            else
            {
                return null;
            }

        }
    }


}
