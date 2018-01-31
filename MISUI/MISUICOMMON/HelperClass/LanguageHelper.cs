using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace MISUICOMMON.HelperClass
{
    public class LanguageHelper
    {
        public static string GetLabel(string labelName)
        {
            //labelName = labelName.ToUpper();
            if (!String.IsNullOrEmpty(labelName))
            {

                string sessionLanguage = "";
                DataTable dtUnicode = null;
                if (HttpContext.Current.Session["LanguageSetting"] != null)
                {
                    sessionLanguage = HttpContext.Current.Session["LanguageSetting"].ToString();
                }
                if (HttpContext.Current.Session["UnicodeWords"] != null)
                {
                    dtUnicode = (DataTable)HttpContext.Current.Session["UnicodeWords"];
                }
                if (sessionLanguage != "English")
                {
                    if (dtUnicode != null)
                    {
                        var drNepaliLabel = dtUnicode.AsEnumerable().Where(s => s.Field<string>("LABELS IN ENGLISH") == labelName.ToUpper());
                        foreach (var dr in drNepaliLabel)
                        {
                            labelName = (dr["LABELS IN NEPALI"] == null) ? labelName : dr["LABELS IN NEPALI"].ToString();
                        }
                        labelName = labelName.Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
                    }
                }
            }
            return labelName;
        }
        public static void GetLanguageList()
        {
            string appPath = HttpContext.Current.Request.ApplicationPath;
            string physicalPath = HttpContext.Current.Request.MapPath(appPath);
            string filepath = System.IO.Path.GetFullPath(physicalPath + @"\Unicode\Unicode.xls");
            DataTable dtRes = new DataTable();
            dtRes = ReadFromEXcel(filepath);
            if (dtRes != null)
            {
                HttpContext.Current.Session["UnicodeWords"] = dtRes;
            }
            else
            {
                HttpContext.Current.Session["UnicodeWords"] = null;
            }

        }
        public static DataTable ReadFromEXcel(string filepath, string sheetname = "Sheet1")
        {
            DataTable dtExcel = null;
            string extension = "";
            string connString = "";
            if (filepath != "")
            {
                if (filepath.Contains("."))
                {
                    extension = Path.GetExtension(filepath);
                }
                if (extension == ".xls")
                {
                    connString = "provider=Microsoft.Jet.OLEDB.4.0;" + @"data source=" + filepath + ";" + "Extended Properties=Excel 8.0;";
                }
                else
                {
                    connString = "provider=Microsoft.ACE.OLEDB.12.0;" + @"data source=" + filepath + ";" + "Extended Properties=Excel 12.0;";
                }
                OleDbConnection oledbConn = new OleDbConnection(connString);
                try
                {
                    oledbConn.Open();
                    string query = string.Format("SELECT * FROM [{0}$]", sheetname);
                    using (OleDbDataAdapter myCommand = new OleDbDataAdapter(query, oledbConn))
                    {
                        dtExcel = new DataTable();
                        myCommand.Fill(dtExcel);
                    }

                }
                catch (Exception ex)
                {
                    //ExceptionManager.AppendLog(ex);
                    dtExcel = null;
                }
                finally
                {
                    oledbConn.Close();
                }
            }
            return dtExcel;
        }
    }
}
