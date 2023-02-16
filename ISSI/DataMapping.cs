using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Validation;


namespace ISSI
{
    class DataMapping
    {
        private Dictionary<string, DataColumn> dataMap;
        private int[] rowArray;
        private bool contRows;
        private IEnumerable<Cell> workSheetCells;
        public bool loadSuccess;
        private DataTable sqlTable;
        private bool readComments = false;
        private string commentsColumn = null;
        private bool warn = false;

        //Settings in csv format in config file.
        public DataMapping(string xlColumns, string sqlColumns, DataTable sqlTbl)
        {
            string[] xlColumnArray = null;
            string[] sqlColumnArray = null;
            sqlTable = sqlTbl;
            loadSuccess = true;
            try
            {
                //xlColumnArray = xlColumns.Split(',').Select(s => Int32.Parse(s)).ToArray();
                xlColumnArray = xlColumns.Split(',');
                sqlColumnArray = sqlColumns.Split(',');

            }
            catch
            {
                MessageBox.Show("Import settings in wrong format, see config file.");
                loadSuccess = false;
            }


            if (xlColumnArray == null || sqlColumnArray == null)
            {
                MessageBox.Show("Could not retrieve import mappings");
                loadSuccess = false;
            }
            else
            {
                if (xlColumnArray.Length != sqlColumnArray.Length)
                {
                    MessageBox.Show("Column mappings do not match in length");
                    loadSuccess = false;
                }
                else
                {
                    Dictionary<string, DataColumn> dm = new Dictionary<string, DataColumn>();
                    for (int i = 0; i < sqlColumnArray.Length; i++)
                    {
                        DataColumn c = new DataColumn();
                        c.ColumnName = sqlColumnArray[i];
                        if (!sqlTable.Columns.Contains(sqlColumnArray[i]))
                        {
                            MessageBox.Show("Invalid SQL Column Name in import settings");
                            loadSuccess = false;
                        }
                        else
                        {
                            c.DataType = sqlTable.Columns[sqlColumnArray[i]].DataType;
                            c.MaxLength = sqlTable.Columns[sqlColumnArray[i]].MaxLength;
                            dm.Add(xlColumnArray[i], c);
                        }



                    }
                    dataMap = dm;

                }
            }



        }

        //Import sttingd from int/string array (xl column numbers and sql column names)
        public DataMapping(string[] xlColumnArray, string[] sqlColumnArray, DataTable sqlTbl)
        {

            sqlTable = sqlTbl;
            if (xlColumnArray == null || sqlColumnArray == null)
            {
                MessageBox.Show("Could not retrieve import mappings");
                loadSuccess = false;
            }
            else
            {
                if (xlColumnArray.Length != sqlColumnArray.Length)
                {
                    MessageBox.Show("Column mappings do not match in length");
                    loadSuccess = false;
                }
                else
                {
                    Dictionary<string, DataColumn> dm = new Dictionary<string, DataColumn>();
                    for (int i = 0; i < sqlColumnArray.Length; i++)
                    {
                        DataColumn c = new DataColumn();
                        c.ColumnName = sqlColumnArray[i];
                        if (!sqlTable.Columns.Contains(sqlColumnArray[i]))
                        {
                            MessageBox.Show("Invalid SQL Column Name in import settings");
                            loadSuccess = false;
                        }
                        else
                        {
                            c.DataType = sqlTable.Columns[sqlColumnArray[i]].DataType;
                            c.MaxLength = sqlTable.Columns[sqlColumnArray[i]].MaxLength;
                            dm.Add(xlColumnArray[i], c);
                        }


                    };
                    dataMap = dm;
                }
            }
        }
        public void WarningsOff()
        {
            warn = false;
        }

        public void AddColumn(string xl, string columnName, Type columnType)
        {


            if (!dataMap.ContainsKey(xl))
            {
                DataColumn c = new DataColumn();
                c.ColumnName = columnName;
                c.DataType = columnType;
                if (sqlTable.Columns.Contains(columnName))
                {

                    MessageBox.Show("Additional display column " + xl + " would update the values in sql column " + columnName + " as this column name exists in the database.  If this is required please add this mapping in the correct settings field, otherwise change the display column name");
                }

                else
                {
                    if (columnType == typeof(string))
                    {
                        c.MaxLength = 255;
                    }

                    dataMap.Add(xl, c);
                }

            }
            else
            {
                MessageBox.Show("Additional display column has already been mapped- check config file");
            }

        }
        public void IncludeComments(string sqlCol)
        {
            commentsColumn = sqlCol;
            readComments = true;
        }

        public void RowSelect(int[] rows, bool cont)
        {
            if (cont)
            {
                if (rows[1] < rows[0] || rows == null)
                {
                    MessageBox.Show("Row numbers invalid.  Please check and retry");

                }

                else
                {
                    rowArray = rows;
                    contRows = cont;
                }
            }
            else
            {
                if (rowArray == null)
                {
                    MessageBox.Show("No rows specified.  Please check and retry");

                }
                else
                {
                    rowArray = rows;
                    contRows = cont;
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
                MessageBox.Show("Cannot find temporary file");
                return false;
            }

        }


        public DataTable GetReturnTable()
        {

            DataTable dt = new DataTable();
            foreach (DataColumn c in dataMap.Values)
            {
                dt.Columns.Add(c);
            }


            return dt;


        }

        public string GetColumnType(string col)
        {
            string column = dataMap[col].DataType.Name;
            return column;
        }


        private DataRow ConvertValues(string val, DataRow row, int col, string cellRef)
        {
            if (val == null)
            {
                //MessageBox.Show("nullval");
                row[col] = DBNull.Value;
            }
            else
            {
                string columnType = row.Table.Columns[col].DataType.Name;

                string columnName = row.Table.Columns[col].ColumnName;

                try
                {
                    switch (columnType)
                    {
                        case "String":
                            string fullString = "";
                            if (!String.IsNullOrWhiteSpace(Convert.ToString(val)))
                            {
                                 fullString = Convert.ToString(val);
                                 
                            }
                            
                            string validString;
                            int columnLength = row.Table.Columns[col].MaxLength;
                            if (fullString.Length > columnLength)
                            {
                                validString = fullString.Substring(0, columnLength);

                                if (warn)
                                {
                                    MessageBox.Show("Value in cell exceeds maximum length and has been truncated \n Column Name: " + columnName + "\n Column Type: " + columnType + "\n Cell: " + cellRef + "\n Value: " + fullString + "\n New Value:" + validString);
                                }

                            }
                            else
                            {
                                validString = fullString;
                            }
                            row[col] = validString;
                            break;
                        case "Int32":
                            string digits = new string(val.TakeWhile(c => Char.IsDigit(c)).ToArray());
                            int result;
                            if (Int32.TryParse(digits, out result))
                            {
                                row[col] = result;
                            }
                            break;
                        case "Decimal":
                            row[col] = Decimal.Round(Convert.ToDecimal(val), 2);
                            break;
                        case "DateTime":

                            row[col] = DateTime.FromOADate(Convert.ToDouble(val));


                            break;

                    }
                }

                catch (Exception)
                {



                    if (warn)
                    {
                        MessageBox.Show("A value could not be converted- field has been left blank \n Column Name: " + columnName + "\n Column Type: " + columnType + "\n Cell: " + cellRef + "\n Value: " + val);
                    }
                    row[col] = DBNull.Value;


                }
            }
            return row;

        }

        public DataTable OutputTable(string importFile, int sheetNumber)
        {
            DataTable returnTable = GetReturnTable();
            if (readComments)
            {
                returnTable.Columns.Add(commentsColumn, typeof(string));
            }

            if (ValidateFile(importFile))
            {
                using (SpreadsheetDocument ssDocument = SpreadsheetDocument.Open(@importFile, false))
                {
                    //This code takes too long
                    /* OpenXmlValidator validator = new OpenXmlValidator();
                     var errors = validator.Validate(ssDocument);
                     int errCount = errors.Count();
                     if ( errCount!= 0)
                     {
                         string[] errs = new string[errCount];
                         for (int i = 0; i<errCount; i++)
                         {
                             errs[i] = errors.ElementAt(i).Description;
                         }

                         Session.Log(errs);

                     }*/
                   IEnumerable<Comment> coms= null;
                   if (readComments)
                    {
                       coms = sheetComments(ssDocument, sheetNumber);
                    }
                    
                    




                        
                            //MessageBox.Show("Specified number of rows exceeds number of datarows on selected sheet");
                            
                       
                        



                            if (contRows)
                            {
                            //check if first row exists

                            /*int n = rowArray[0];
                            Cell cell0 = rows.ElementAt(n-1).Descendants<Cell>().ElementAt(0);
                                string cell0Ref = cell0.CellReference;
                                char[] charArray = cell0Ref.ToCharArray();
                                Array.Reverse(charArray);
                                cell0Ref = string(charArray);
                                string digits = new string(cell0Ref.TakeWhile(c => Char.IsDigit(c)).ToArray());
                                int blanks = Convert.ToInt32(digits);*/
                            
                            
                            
                                
                                IEnumerable<Sheet> sheets = ssDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                                WorkbookPart workbookPart = ssDocument.WorkbookPart;
                                string relationshipId = sheets.ElementAt(sheetNumber - 1).Id.Value;

                                WorksheetPart worksheetPart = (WorksheetPart)ssDocument.WorkbookPart.GetPartById(relationshipId);
                                OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
                                //for (int i = rowArray[0]; i <= rowArray[1]; i++)
                                int i = 1;
                                Row rowi;
                                while (reader.Read() && i<=rowArray[1])
                                {
                                    //rowi = rows.ElementAt(i-1);
                                    if (reader.ElementType == typeof(Row))
                                        do
                                        {
                                            {
                                                rowi = (Row)reader.LoadCurrentElement();

                                            }



                                            if (rowi != null && i + 1 >= rowArray[0])
                                            {
                                                string rowComments = "";
                                                DataRow tempRow = returnTable.NewRow();

                                                int k = 0;
                                                foreach (string j in dataMap.Keys)
                                                {



                                                    string cellRef = j + i.ToString();
                                                    string x = null;
                                                    Cell cl = GetCell(ssDocument, sheetNumber, cellRef, rowi);

                                                    if (cl != null)
                                                    {
                                                        x = GetCellValue(ssDocument, cl);
                                                        if (readComments)
                                                        {
                                                            rowComments = GetCellComment(coms, cl, rowComments);
                                                        }
                                                    }
                                                    tempRow = ConvertValues(x, tempRow, k, cellRef);
                                                    k++;


                                                }

                                                /*int k = 0;
                                                foreach (int j in dataMap.Keys)
                                                {

                                                    var x = GetCellValue(ssDocument, rows.ElementAt(i - 1).Descendants<Cell>().ElementAt(j - 1));
                                                    tempRow = ConvertValues(x, tempRow, k, i);
                                                    k++;

                                                }*/
                                                if (readComments)
                                                {
                                                    tempRow[commentsColumn] = rowComments;
                                                }


                                                returnTable.Rows.Add(tempRow);

                                            }
                                            i++; 
                                        } while (reader.ReadNextSibling() && i <= rowArray[1]);
                                } 
                            




                            }
                            else
                            {
                            IEnumerable<Row> rows = GetSheetRows(ssDocument, sheetNumber);
                            foreach (int i in rowArray)
                                {

                                    Row rowi = rows.Where(r => r.RowIndex == i).FirstOrDefault();
                                    if (rowi == null)
                                    {
                                        continue;
                                    }
                                    string rowComments = "";
                                    DataRow tempRow = returnTable.NewRow();
                                    int k = 0;
                                    foreach (string j in dataMap.Keys)
                                    {
                                        string cellRef = j + i.ToString();
                                        string x = null;
                                        Cell cl = GetCell(ssDocument, sheetNumber, cellRef, rowi);
                                        if (cl != null)
                                        {
                                            x = GetCellValue(ssDocument, cl);
                                            if (readComments)
                                            {
                                                rowComments = GetCellComment(coms, cl, rowComments);
                                            }
                                        }


                                        //var x = GetCellValue(ssDocument, rows.ElementAt(i - 1).Descendants<Cell>().ElementAt(j - 1));
                                        tempRow = ConvertValues(x, tempRow, k, cellRef);
                                        k++;

                                    }
                                    if (readComments)
                                    {
                                        tempRow[commentsColumn] = rowComments;
                                    }
                                    returnTable.Rows.Add(tempRow);

                                }

                            }
                        
                   
                }

            }


            return returnTable;
        }

        private IEnumerable<Row> GetSheetRows(SpreadsheetDocument document, int sheetNumber)
        {
            WorkbookPart workbookPart = document.WorkbookPart;
            IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
            string relationshipId = sheets.ElementAt(sheetNumber - 1).Id.Value;
            IEnumerable<Row> rows;
            try
            {
                WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                workSheetCells = workSheet.Descendants<Cell>();
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                rows = sheetData.Descendants<Row>();
            }
            catch
            {
                MessageBox.Show("Selected sheet contains invalid data");
                rows = null;
            }





            return rows;
        }




        private Cell GetCell(SpreadsheetDocument document, int sheetNumber, string reference, Row row)
        {
            Cell cl = null;

            OpenXmlReader reader2 = OpenXmlReader.Create(row);
            int k = 0;
            while (reader2.Read() && k<50)
            {
                
                {
                    if (reader2.ElementType == typeof(Cell))
                    {
                        Cell c = (Cell)reader2.LoadCurrentElement();

                        

                        if (c.CellReference != null && reference.Equals(c.CellReference))
                        {
                            cl = c;
                            k = 50;
                        }
                        else
                        {
                            k++;
                        }
                       
                    }
                }
            }
            //IEnumerable<Cell> findCell = workSheetCells.Where(c => reference.Equals(c.CellReference));
            //cl = row.Elements<Cell>().Where(c => reference.Equals(c.CellReference)).FirstOrDefault();
            //for (int i = 0; i< row.Count() && i < 40; i++)
            //{
            //    Cell c = row.Elements<Cell>().ElementAt(i);
            //    {
            //        if (reference.Equals(c.CellReference))
            //        {
            //            cl = c;
            //        }
            //    }
            //}
            


            return cl; 
        }

        private Cell GetCell(SpreadsheetDocument document, int sheetNumber, int col, Row row)
        {
            Cell cl = null;

            //IEnumerable<Cell> findCell = workSheetCells.Where(c => reference.Equals(c.CellReference));


            cl = row.Elements<Cell>().ElementAt(col);
            

            return cl; ;
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
        private string GetCellComment(IEnumerable<Comment> comments, Cell cell, string rowComments)
        {

            string reference = cell.CellReference;


            if (comments != null)
            {
                try
                {

                    Comment cellComment = comments.Where(c => reference.Equals(c.Reference)).FirstOrDefault();
                    if (cellComment != null)
                    {
                        rowComments += cellComment.InnerText + "\n";
                    }


                }
                catch
                {
                    if (warn)
                    {
                        MessageBox.Show("Couldn't read cell comment");
                    }

                }
                return rowComments;
            }
            else
            {
                return null;
            }

        }

        private IEnumerable<Comment> sheetComments(SpreadsheetDocument document, int sheetNumber)
        {
            WorkbookPart workbookPart = document.WorkbookPart;
            IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
            string relationshipId = sheets.ElementAt(sheetNumber - 1).Id.Value;
            try
            {
                WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                WorksheetCommentsPart commentsPart = worksheetPart.WorksheetCommentsPart;
                Comments comments = commentsPart.Comments;
                CommentList clist = comments.CommentList;
                IEnumerable<Comment> sheetcomments = clist.Elements<Comment>();
                return sheetcomments;

            }
            catch
            {
                MessageBox.Show("Selected sheet contains no comments");
                return null;
            }
        }


    }
}
