using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Validation;
using System.Windows.Forms;
using System.IO;

namespace ISSI
{
    public class XlFileImporter
    {
        private int[] rowArray;
        private bool contRows;
        private int[] columnArray;
        private string[] conversionArray;
        private DataTable outputTable;


        //Get Import Settings from csv file- ie in config settings. Output table contains all columns of target table.
        public XlFileImporter(string rows, string columns, string conversions, DataTable targetTable, bool continuousRows)
        {
            try
            {
                rowArray = rows.Split(',').Select(s => Int32.Parse(s)).ToArray();
                columnArray = columns.Split(',').Select(s => Int32.Parse(s)).ToArray();
                conversionArray = conversions.Split(',');
                contRows = continuousRows;
            }
            catch
            {
                MessageBox.Show("Import settings in wrong format, see config file.");
            }

            outputTable = targetTable.Copy();
            outputTable.Clear();

        }

        //User entered rows/columns, conversions extracted from target table.  Output table contains all columns of target table.
        public XlFileImporter(int[] rows, int[] columns, DataTable targetTable, bool continuousRows)
        {
            rowArray = rows;
            columnArray = columns;
            conversionArray = GetConversions(targetTable);
            contRows = continuousRows;

        }

        // User entered rows, columns from config, conversions from target table.  Output table contains all columns of target table.
        public XlFileImporter(int[] rows, string columns, DataTable targetTable, bool continuousRows)
        {
            try
            {
                rowArray = rows;
                columnArray = columns.Split(',').Select(s => Int32.Parse(s)).ToArray();
                conversionArray = GetConversions(targetTable);
                contRows = continuousRows;
                outputTable = targetTable.Copy();
                outputTable.Clear();

            }
            catch
            {
                MessageBox.Show("Import settings in wrong format, see config file.");
            }


        }
        // User entered rows, columns/conversions from config
        public XlFileImporter(int[] rows, string columns, string conversions, DataTable targetTable, bool continuousRows)
        {
            try
            {
                rowArray = rows;
                columnArray = columns.Split(',').Select(s => Int32.Parse(s)).ToArray();
                conversionArray = conversions.Split(',');
                contRows = continuousRows;
            }
            catch
            {

                MessageBox.Show("Import setting in wrong format, see config file");
            }
        }


        private bool ValidateProperties(DataTable targetTable)
        {

            // TODO Check properties are valid
            bool columnCheck;
            bool rowCheck;
            int numCols = targetTable.Columns.Count;
            if (columnArray.Length == numCols && conversionArray.Length == numCols)
            {
                columnCheck = true;
            }
            else
            {
                MessageBox.Show("Mapping settings incorrect or are not compatible with the destination table");
                columnCheck = false;
            }


            if (contRows)
            {
                if (rowArray[1] <= rowArray[0])
                {
                    MessageBox.Show("Row numbers invalid.  Please check and retry");
                    rowCheck = false;
                }

                else
                {
                    rowCheck = true;

                }
            }
            else
            {
                rowCheck = true;
            }

            if (rowCheck && columnCheck)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool ValidateFile(string importFile)
        {
            if (System.IO.Directory.Exists(@importFile))
            {
                return true;
            }
            else
            {
                return false;
            }

        }






        public DataTable OutputTable(string importFile, int sheetNumber, DataTable targetTable)
        {
            DataTable returnTable = MirrorTable(targetTable);

            if (ValidateFile(importFile) && ValidateProperties(targetTable))
            {
                using (SpreadsheetDocument ssDocument = SpreadsheetDocument.Open(@importFile, false))
                {
                    OpenXmlValidator validator = new OpenXmlValidator();
                    var errors = validator.Validate(ssDocument);
                    if (errors.Count() == 0)
                    {


                        IEnumerable<Row> rows = GetSheetRows(ssDocument, sheetNumber);

                        if (rowArray.Max() > rows.Count())
                        {
                            MessageBox.Show("Specified number of rows exceeds number of datarows on selected sheet");
                        }
                        else
                        {



                            if (contRows)
                            {

                                for (int i = rowArray[0]; i <= rowArray[1]; i++)
                                {
                                    string column0 = GetCellValue(ssDocument, rows.ElementAt(i - 1).Descendants<Cell>().ElementAt(0));
                                    if (column0 == null)
                                    {
                                        continue;
                                    }
                                    DataRow tempRow = returnTable.NewRow();
                                    foreach (int j in columnArray)
                                    {
                                        var x = GetCellValue(ssDocument, rows.ElementAt(i - 1).Descendants<Cell>().ElementAt(j - 1));
                                        tempRow = ConvertValues(x, tempRow, j);

                                    }
                                    targetTable.Rows.Add(tempRow);

                                }

                                MessageBox.Show("Specified number of rows exceeds number of datarows on selected sheet");


                            }
                            else
                            {
                                foreach (int i in rowArray)
                                {
                                    string column0 = GetCellValue(ssDocument, rows.ElementAt(i - 1).Descendants<Cell>().ElementAt(0));
                                    if (column0 == null)
                                    {
                                        continue;
                                    }
                                    DataRow tempRow = returnTable.NewRow();
                                    foreach (int j in columnArray)
                                    {
                                        var x = GetCellValue(ssDocument, rows.ElementAt(i - 1).Descendants<Cell>().ElementAt(j - 1));
                                        tempRow = ConvertValues(x, tempRow, j);

                                    }
                                    returnTable.Rows.Add(tempRow);

                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The file you are trying to import is in an invalid format.");
                    }
                }

            }


            return returnTable;
        }

        public List<string> OutputSheets(string importFile)
        {
            if (ValidateFile(importFile))
            {
                List<string> sheetNames = new List<string>();
                using (SpreadsheetDocument ssDocument = SpreadsheetDocument.Open(@importFile, false))
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

        private IEnumerable<Row> GetSheetRows(SpreadsheetDocument document, int sheetNumber)
        {
            WorkbookPart workbookPart = document.WorkbookPart;
            IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
            string relationshipId = sheets.ElementAt(sheetNumber - 1).Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);
            Worksheet workSheet = worksheetPart.Worksheet;
            SheetData sheetData = workSheet.GetFirstChild<SheetData>();
            IEnumerable<Row> rows = sheetData.Descendants<Row>();
            return rows;
        }

        private string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue != null)
            {
                string value = cell.CellValue.InnerXml;

                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                }
                else
                {
                    return value;
                }
            }

            else
            {
                return null;
            }
        }

        private DataRow ConvertValues(string val, DataRow row, int col)
        {

            switch (conversionArray[col])
            {
                case "t":
                    row[col] = val.ToString().Trim();
                    break;
                case "i":
                    string digits = new string(val.TakeWhile(c => Char.IsDigit(c)).ToArray());
                    int result;
                    if (Int32.TryParse(digits, out result))
                    {
                        row[col] = result;
                    }
                    break;
                case "d":
                    row[col] = Convert.ToDecimal(val);
                    break;
                case "dt":
                    try
                    {
                        row[col] = DateTime.FromOADate(Convert.ToDouble(val));
                    }
                    catch
                    {
                        row[col] = DBNull.Value;
                    }
                    break;

            }
            return row;

        }

        private DataTable MirrorTable(DataTable targetTable)
        {
            DataTable mTable = new DataTable();
            foreach (DataColumn col in targetTable.Columns)
            {
                mTable.Columns.Add(col.ColumnName);


            }
            return mTable;

        }

        private string[] GetConversions(DataTable targetTable)
        {
            List<string> convs = new List<string>();

            foreach (DataColumn col in targetTable.Columns)
            {
                string colType = col.DataType.ToString();

                switch (colType)

                {
                    case "int":
                        convs.Add("i");
                        break;
                    case "string":
                        convs.Add("t");
                        break;
                    case "DateTime":
                        convs.Add("dt");
                        break;
                    case "Double":
                        convs.Add("d");
                        break;


                }

            }
            return convs.ToArray();
        }



    }
}
