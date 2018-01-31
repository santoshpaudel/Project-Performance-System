using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MISUICOMMON.HelperClass
{
    public static class SessionHelper
    {
        public static string SessionOfficeId
        {
            get { return HttpContext.Current.Session["office_id"].ToString(); }
        }
        public static string SessionLanguageSetting
        {
            get { return HttpContext.Current.Session["LanguageSetting"].ToString(); }
        }
         public static string SessionFiscalYear
        {
            get { return HttpContext.Current.Session["fiscal_year_id"].ToString(); }
        }
        
    }
}
