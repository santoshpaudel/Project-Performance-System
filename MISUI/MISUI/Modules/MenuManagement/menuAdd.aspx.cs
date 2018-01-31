using System;
using System.Data;
using MISUI.ServiceMenu;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using ComMenu = MISUI.ServiceMenu.ComMenu;

namespace MISUI.Modules.MenuManagement
{
    public partial class menuAdd : Base
    {
       // Service1 objService = new Service1();
        public static int menuId = 0;
        public static int entryMode = 0;
        public static DataTable dtPopulateMenuDetails = null;

        ComMenu objComMenu = new ComMenu();

        //Base objBase=new Base();

        ServiceMenuManagement objService = new ServiceMenuManagement();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                menuId = int.Parse(Request.QueryString["menuId"]);
                entryMode = int.Parse(Request.QueryString["entryMode"]);

                // to edit menu with selected menuId

                if (entryMode==1)
                {
                   populateMenuDetails(menuId);
                   btnAddMenu.Text = "Update Menu";
                }

                // to add child menu of selected menuId
                if (entryMode==0)
                {
                    btnAddMenu.Text = "Add Menu";
                }
            }

        }

        private void populateMenuDetails(int menuId)
        {
            objService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationMenu();
           dtPopulateMenuDetails=objService.PopulateMenuDetails(menuId);
           if (dtPopulateMenuDetails != null && dtPopulateMenuDetails.Rows.Count > 0)
           {
               txtMenuEnglishName.Text = dtPopulateMenuDetails.Rows[0]["MENU_ENG_NAME"].ToString();
               txtMenuNepaliName.Text = dtPopulateMenuDetails.Rows[0]["MENU_NEP_NAME"].ToString();
               txtMenuPath.Text = dtPopulateMenuDetails.Rows[0]["MENU_PATH"].ToString();
           }
        }

        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            objComMenu.menuEnglishName = txtMenuEnglishName.Text;
            objComMenu.menuNepaliName = txtMenuNepaliName.Text;
            objComMenu.menuPath = txtMenuPath.Text;
            if(entryMode==0)//to add new menu 
            {
                objComMenu.menuParentId = menuId;
            }
            else // to edit existing menu
            {
                objComMenu.menuParentId = dtPopulateMenuDetails.Rows[0]["MENU_PARENT_ID"].ToInt16();
            }
            objComMenu.menuTypeId = 1;
            objComMenu.menuLevel = 1;
            objService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationMenu();
            int i = 0;
            i=objService.AddMenu(objComMenu, entryMode, menuId);
            if(i>0)
            {
                    
                Response.Write("<script>alert('Menu added successfully')</script>");
                Response.Redirect(Constants.ConstantAppPath + "/Modules/MenuManagement/ListMenu.aspx");
            }
            else
            {
                Response.Write("<script>alert('Menu addition failed')</script>");
            }
            

        }
    }
}