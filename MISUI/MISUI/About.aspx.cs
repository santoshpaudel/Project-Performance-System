using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI;

namespace WebApplication1
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var st = Request.QueryString["id"];

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HelloWorld(string id)
        {

            var tree = new JsTreeModel[]
                           {
                               new JsTreeModel
                                   {
                                       text = "Confirm Application",
                                       attr = new JsTreeAttribute {id = "10", selected = true}
                                   }
                           };
            return new JavaScriptSerializer().Serialize(tree);
        }
    }
}
