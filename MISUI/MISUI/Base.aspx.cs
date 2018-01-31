using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUICOMMON.HelperClass;

namespace MISUI
{
    public partial class Base : System.Web.UI.Page
    {
        private LanguageHelper objLang = null;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public string GetLabel(string label)
        {
            string result = string.Empty;

            result = LanguageHelper.GetLabel(label);
            return result;
        }
    }
}