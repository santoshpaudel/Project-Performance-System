using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceMenu;
using MISUI.ServiceMenuOffice;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
namespace MISUI.Controls
{
    public partial class UCMenu : System.Web.UI.UserControl
    {
        ServiceMenuManagement objService = new ServiceMenuManagement();
        public string menu = string.Empty;
        public string lang
        {
            get { return Session["LanguageSetting"].ToString(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            LoadMenu();
        }
        /// <summary>
        /// Loads the menu.
        /// </summary>
        public void LoadMenu()
        {
            string lastClick = string.Empty;
            string menuPath = string.Empty;
            string addClass = "class='active open'";
            if(Session["menuClick"]!=null)
            lastClick=Session["menuClick"].ToString();
            DataTable dt = null;
           // string menu = string.Empty;
            menu="";
            menu = menu + " <ul class='nav nav-list'>";
            objService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationMenu();
            dt = objService.FetchMenuHierarchy(0, lang, Session["role_id"].ToInt32());//for primary menu's
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["menu_id"].ToString()==lastClick)
                {  
                    menu = menu + "<li " + addClass + ">";
                }
                else
                {
                    menu = menu + "<li>";
                }
                menuPath = dr["menu_path"].ToString() == "#" ? "javascript:void(0)" : Constants.ConstantAppPath + "/" + dr["menu_path"];
                menu = menu + "<a href='" + menuPath + "' class='dropdown-toggle' onclick='setMenuClick(" + dr["menu_id"].ToString() + ")'>";
                menu = menu + " <i class='menu-icon fa fa-desktop'> </i><span class='menu-text'>" + dr["menu_name"] + "</span><b class='arrow fa fa-angle-down'></b></a><b class='arrow'></b>";
                menu = menu+FindChild(dr["menu_id"].ToString());
                menu = menu + "</li>";

            }
            menu = menu +
                   "</ul>";
        }
        public string FindChild(string menuId)
        {
            DataTable dtChild = null;
            string subMenu = string.Empty;
            objService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationMenu();
            dtChild = objService.FetchMenuHierarchy(menuId.ToInt32(), lang, Session["role_id"].ToInt32());
            subMenu = subMenu +
                              " <ul class='submenu'>";
                foreach (DataRow dr in dtChild.Rows)
                {
                    subMenu = subMenu +
                              "<li><a href='" + Constants.ConstantAppPath + "/" + dr["menu_path"] + "'>";
                    subMenu = subMenu +
                              "<i class='menu-icon fa fa-caret-right'></i>" + dr["menu_name"] + "</a><b class='arrow'></b></li>";
                }
            subMenu = subMenu + "</ul>";
            return subMenu;
        }
    }
}