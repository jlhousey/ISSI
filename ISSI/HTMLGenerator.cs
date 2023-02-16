using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ISSI.sbi_installdbDataSetTableAdapters;

namespace ISSI
{
    public static class HTMLGenerator
    {
        
        public static string ConvertDataTableToHTML(DataTable dt)
        {
            if (dt.Rows.Count >0)
            {
                string html = "<table cellpadding = \"10\">";
                //add header row
                html += "<tr>";
                for (int i = 4; i < dt.Columns.Count-1; i++)
                {
                    string nam = dt.Columns[i].ColumnName;
                    if(nam == "InstallDate")
                    {
                        nam = "Install W/C";
                    }
                    html += "<td><font size = \"2\" face = \"Arial\"><b>" + nam + "</b></font></td>";
                }
                   
                html += "</tr>";
                //add rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "<tr bgcolor=\"" + dt.Rows[i][0].ToString()+"\">";

                    html += "<td><font size = \"2\" face = \"Arial\"><b>" + dt.Rows[i][4].ToString() + "</b></font></td>";
                    for (int j = 5; j < dt.Columns.Count-1; j++)
                    {   
                        if(dt.Columns[j].ColumnName == "RAG")
                        {
                            string RAG = "White";

                            if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[i][j])))
                            {
                                if ((Convert.ToInt32(dt.Rows[i][j]) == 1))
                                {
                                    RAG = "Red";

                                }
                                if ((Convert.ToInt32(dt.Rows[i][j]) == 2))
                                {
                                    RAG = "Orange";

                                }
                                if ((Convert.ToInt32(dt.Rows[i][j]) == 3))
                                {
                                    RAG = "Green";

                                } 
                            }
                            html += "<td bgcolor= \"" + RAG + "\"><font size = \"2\" face = \"Arial\">" + dt.Rows[i][j].ToString() + "</font></td>";
                        }
                        else
	                    {
                            html += "<td><font size = \"2\" face = \"Arial\">" + dt.Rows[i][j].ToString() + "</font></td>"; 
                        }
                    }
                        
                    html += "</tr>";
                }
                html += "</table>";
                return html; 
            }
            else
            {
                return "";
            }
        }
        
        public static string[] GenerateSiteSplit (DataTable edt, sbi_installdbDataSet.vEmailSitesDataTable sdt)
        {
            string[] ebody = new string[2];
            List<string> emailtitles = new List<string>();
            
            string body = "";
            StringBuilder builder = new StringBuilder();
            builder.Append("<html>");
            builder.Append("<head>");
            builder.Append("<title>");
            builder.Append("Page-");
            builder.Append(Guid.NewGuid());
            builder.Append("</title>");
            builder.Append("</head>");
            builder.Append("<body>");
            //builder.Append("<b>");
            int sid = 0;
            DataTable edt2 = edt.AsEnumerable().OrderBy(row => row.Field<int?>("SiteID")).ThenBy(row => row.Field<int?>("JobType")).CopyToDataTable();
            DataTable siterows = edt.Clone();
            string sops = "";
            string houses = "";
            string sitename = "";
            string clientname = "";
            foreach (DataRow r in edt2.Rows)
            
            {
                if (Convert.ToInt32(r["SiteID"]) != sid)
                {
                    if(sid !=0)
                    {
                        emailtitles.Add(sops + " - " + clientname + " - " + houses + " @ " + sitename);
                    }
                    sops = "";
                    houses = "";
                    builder.Append(ConvertDataTableToHTML(siterows));
                    siterows.Clear();
                    sid = Convert.ToInt32(r["SiteID"]);
                   

                    DataRow s = sdt.FindBySiteID(sid);

                    clientname = Convert.ToString(s["Client"]);
                    sitename = Convert.ToString(s["Site"]);


                    for (int j = 1; j < sdt.Columns.Count; j++)
                    {
                        if (j != 3 && !String.IsNullOrWhiteSpace(Convert.ToString(s.ItemArray[j]))) //column 3 is the SiteID-need to find a better way around this!
                        {
                            builder.Append(Convert.ToString(s.ItemArray[j]));
                            builder.Append("<br>");

                        }

                    }
                    builder.Append("<br>");
                    sbi_installdbDataSet installdbDataSet = new sbi_installdbDataSet();
                    ContactsTableAdapter cta = new ContactsTableAdapter();
                    cta.FillBySiteID(installdbDataSet.Contacts, sid);
                    if (installdbDataSet.Contacts.Rows.Count > 0)
                    {
                        DataRow sitemanager = installdbDataSet.Contacts.Rows[0];
                        string name = Convert.ToString(sitemanager["Name"]);
                        string tel = Convert.ToString(sitemanager["Tel1"]);
                        string email = Convert.ToString(sitemanager["Email1"]);
                        builder.Append("<b>Contact: " + name + "<br>" + tel + "<br>" + email + "<br>");
                    }

                    siterows.Rows.Add(r.ItemArray);
                    sops += "SOP" + Convert.ToString(r["SOPID"]);
                    houses += Convert.ToString(r["HouseType"]);
                }
                else
                {
                    siterows.Rows.Add(r.ItemArray);
                    sops += "/" + Convert.ToString(r["SOPID"]);
                    houses += "/" + Convert.ToString(r["HouseType"]);
                }
                
            }
            emailtitles.Add(sops + " - " + clientname + " - " + houses + " @ " + sitename);
            builder.Append(ConvertDataTableToHTML(siterows));

            //builder.Append("</b>");
            builder.Append("</body>");
            body = builder.ToString();
            ebody[0] = body;
            string title = "";

            foreach (string st in emailtitles)
            {
                title += st + "  ";
            }
            ebody[1] = title;
            return ebody;
        }
    }
}
