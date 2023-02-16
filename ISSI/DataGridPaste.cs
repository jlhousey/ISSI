using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ISSI
{
    class DataGridPaste
    {
        public void PasteFromExcel(DataGridView grid)
        {
            char[] rowSplitter = { '\r', '\n' };
            char[] columnSplitter = { '\t' };
            //get the text from clipboard
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);
            //split it into lines
            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
            //get the row and column of selected cell in grid
            int r = grid.SelectedCells[0].RowIndex;
            int c = grid.SelectedCells[0].ColumnIndex;
            int rlength = grid.SelectedColumns.Count;
            int cheight = grid.SelectedRows.Count;

            //add rows into grid to fit clipboard lines
            if (cheight != rowsInClipboard.Length || rlength != rowsInClipboard[0].Length)
            {
                MessageBox.Show("Selection does not match clipboard contents");
            }
            // loop through the lines, split them into cells and place the values in the corresponding cell.
            for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
            {
                //split row into cell values
                string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                //cycle through cell values
                for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                {
                    //assign cell value, only if it within columns of the grid
                    if (grid.ColumnCount - 1 >= c + iCol)
                    {
                        grid.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];
                    }
                }
            }

        }
    }
}
