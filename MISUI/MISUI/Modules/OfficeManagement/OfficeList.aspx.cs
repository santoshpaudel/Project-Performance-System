using System;
using System.Web.Script.Serialization;
using MISUICOMMON;
using MISUICOMMON.HelperClass;

namespace MISUI.Modules.OfficeManagement
{
    public partial class OfficeList : Base
    {
        public string jsonModel = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = GetTreetext();

             jsonModel = new JavaScriptSerializer().Serialize(model);
           
        }
        private JsTreeModel[] GetTreetext()
        {
            var tree = new JsTreeModel[] 
            {
                new JsTreeModel { text = "Confirm Application", attr = new JsTreeAttribute { id = "10", selected = true } },
                new JsTreeModel 
                { 
                    text = "Things",
                    attr = new JsTreeAttribute { id = "20" },
                    children = new JsTreeModel[]
                        {
                            new JsTreeModel { text = "Thing 1", attr = new JsTreeAttribute { id = "21", selected = true } },
                            new JsTreeModel { text = "Thing 2", attr = new JsTreeAttribute { id = "22" } },
                            new JsTreeModel { text = "Thing 3", attr = new JsTreeAttribute { id = "23" } },
                            new JsTreeModel 
                            { 
                                text = "Thing 4", 
                                attr = new JsTreeAttribute { id = "24" },
                                children = new JsTreeModel[] 
                                { 
                                    new JsTreeModel { text = "Thing 4.1", attr = new JsTreeAttribute { id = "241" } }, 
                                    new JsTreeModel { text = "Thing 4.2", attr = new JsTreeAttribute { id = "242" } }, 
                                    new JsTreeModel { text = "Thing 4.3", attr = new JsTreeAttribute { id = "243" } }
                                },
                            },
                        }
                },
                new JsTreeModel 
                {
                    text = "Colors",
                    attr = new JsTreeAttribute { id = "40" },
                    children = new JsTreeModel[]
                        {
                            new JsTreeModel { text = "Red", attr = new JsTreeAttribute { id = "41" } },
                            new JsTreeModel { text = "Green", attr = new JsTreeAttribute { id = "42" } },
                            new JsTreeModel { text = "Blue", attr = new JsTreeAttribute { id = "43" } },
                            new JsTreeModel { text = "Yellow", attr = new JsTreeAttribute { id = "44" } },
                        }
                }
            };

            return tree;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int a=hidOfficeId.ToInt32();

        }
    }
}
