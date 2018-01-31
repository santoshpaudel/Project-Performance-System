
namespace MISCOMMON
{
    public class JsTreeModel
    {
        public string text;
        public JsTreeAttribute attr;
        public JsTreeModel[] children;
    }

    public class JsTreeAttribute
    {
        public string id;
        public bool selected;
    }
}