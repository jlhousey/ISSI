using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace ISSI
{
    public class DataGridValidator
    {
        public Dictionary<DataGridViewCell, int> invalidCells;
        public DataGridView dataGridView;
        private List<DataTable> parentColumns;
        private List<DataRelation> dataRelations;
        //private Dictionary<int,DataColumn> displayMembers;
        public DataTable sourceTable;


        public DataGridValidator(DataGridView dgv, DataTable tbl)
        {
            sourceTable = tbl;
            dataGridView = dgv;

            FormatDatagridColumns(dgv);


            invalidCells = new Dictionary<DataGridViewCell, int>();
            parentColumns = new List<DataTable>();
            dataRelations = new List<DataRelation>();
            DataRelationCollection relations = tbl.ParentRelations;
            foreach (DataRelation rel in relations)
            {
                DataTable parentTable = GetParentTable(rel);
                DataTable columns = new DataTable();


                foreach (DataColumn c in rel.ChildColumns)
                {
                    string s = c.ColumnName;

                    string v = rel.ParentColumns[Array.IndexOf(rel.ChildColumns, c)].ColumnName;

                    string t = null;


                    if (dgv.Columns.Contains(s))

                    {
                        DataColumn col = new DataColumn(s, c.DataType);

                        columns.Columns.Add(col);

                        if (dgv.Columns[s].Tag != null)
                        {
                            t = dgv.Columns[s].Tag.ToString();
                            columns.Columns.Add(t, parentTable.Columns[t].DataType);

                        }

                        foreach (DataRow parentRow in parentTable.Rows)
                        {
                            DataRow row = columns.Rows.Add();
                            row[s] = parentRow[v];
                            if (t != null)
                            {
                                row[t] = parentRow[t];
                            }

                        }
                        parentColumns.Add(columns);
                        dataRelations.Add(rel);

                        foreach (DataGridViewRow r in dgv.Rows)
                        {


                            var val = r.Cells[s].Value;
                            if (val != DBNull.Value && val != null)
                            {

                                //if (parentTable.Select(s + "=" + val.ToString()).Length > 0)
                                List<DataRow> li = parentTable.Select().ToList();
                                if (parentTable.Select().ToList().Exists(row => row[v].ToString().ToUpper() == val.ToString().ToUpper()))
                                {
                                    r.Cells[s].Style.ForeColor = Color.Blue;

                                }
                                else
                                {
                                    r.Cells[s].Style.ForeColor = Color.Red;


                                    invalidCells.Add(r.Cells[s], parentColumns.IndexOf(columns));


                                }
                            }
                        }
                    }
                }
            }




        }
        public DataTable GetList(DataGridViewCell cell)

        {
            DataTable valueList = new DataTable();

            valueList = parentColumns[invalidCells[cell]];


            return valueList;
        }


        private void FormatDatagridColumns(DataGridView dgv)
        {
            foreach (DataColumn c in sourceTable.Columns)
            {

                string clm = c.ColumnName;



                if (dgv.Columns.Contains(clm))
                {

                    foreach (DataGridViewRow r in dgv.Rows)
                    {
                        r.Cells[clm].Style.BackColor = System.Drawing.Color.BlanchedAlmond;
                    }

                }



            }
        }
        private DataTable GetParentTable(DataRelation rel)
        {
            DataTable parent = rel.ParentTable;
            string adaptername = "ISSI.sbi_salesdbDataSetTableAdapters." + parent.TableName + "TableAdapter";

            Type tableType = parent.GetType();
            Type adapterType = Type.GetType(adaptername);
            object adapter = Assembly.GetExecutingAssembly().CreateInstance(adapterType.FullName);
            MethodInfo fillMethod = adapterType.GetMethod("Fill", new Type[] { tableType });
            fillMethod.Invoke(adapter, new object[] { parent });
            return parent;
        }

        public DataTable AddNewItem(DataGridViewCell cell)
        {
            string primaryKeyColumn = cell.OwningColumn.Name;
            switch (primaryKeyColumn)
            {


                case "JobID":
                    {
                        //EditJob es = new EditJob(cell.Value.ToString(), true);
                        //es.ShowDialog();
                        sbi_salesdbDataSetTableAdapters.JobTableAdapter ta = new sbi_salesdbDataSetTableAdapters.JobTableAdapter();
                        sbi_salesdbDataSet.JobDataTable parent = new sbi_salesdbDataSet.JobDataTable();
                        ta.Fill(parent);
                        //es.Dispose();
                        return parent;


                    }
                case "ClientID":
                    {
                        string suppID = cell.Value.ToString();
                        if (MessageBox.Show("Create New Supplier with ID " + suppID + "?", "Create New Supplier", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //EditClient es = new EditClient(cell.Value.ToString(), true);
                            //es.ShowDialog();
                            sbi_salesdbDataSetTableAdapters.ClientTableAdapter ta = new sbi_salesdbDataSetTableAdapters.ClientTableAdapter();
                            sbi_salesdbDataSet.ClientDataTable parent = new sbi_salesdbDataSet.ClientDataTable();
                            ta.Fill(parent);
                            //es.Dispose();
                            return parent;
                        }
                        return null;
                    }
                default:
                    {
                        DataRelation rel = dataRelations[invalidCells[cell]];
                        DataTable parent = rel.ParentTable;
                        string adaptername = "ISSI.sbi_salesdbDataSetTableAdapters." + parent.TableName + "TableAdapter";

                        Type tableType = parent.GetType();
                        Type adapterType = Type.GetType(adaptername);
                        object adapter = Assembly.GetExecutingAssembly().CreateInstance(adapterType.FullName);
                        MethodInfo fillMethod = adapterType.GetMethod("Fill", new Type[] { tableType });
                        fillMethod.Invoke(adapter, new object[] { parent });
                        DataRow r = parent.NewRow();
                        r[cell.OwningColumn.Name] = cell.Value;
                        parent.Rows.Add(r);
                        //Type dataSetType= Type.GetType("sbi_salesdbDataSet");
                        MethodInfo updateMethod = adapterType.GetMethod("Update", new Type[] { tableType });

                        updateMethod.Invoke(adapter, new object[] { parent });
                        return parent;
                    }
            }
        }

        public bool IsValid()
        {
            if (invalidCells.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }






    }
}
