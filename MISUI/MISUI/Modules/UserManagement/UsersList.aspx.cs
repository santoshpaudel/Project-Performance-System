using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceOfficeMgmt;
using MISUI.ServiceUserMgmt;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.UserManagement
{
    public partial class UsersList : Base
    {
        
        private UserManagementService objServiceUser = null;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            btn_AddNew.Text = GetLabel("Add User");
            if (!IsPostBack)
            {
                LoadListView();
               
            }
        }
       

        private void LoadListView()
        {
            DataTable dtu = new DataTable();
            objServiceUser=new UserManagementService();
            objServiceUser.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationUser();
            dtu = objServiceUser.FetchUserList(Session["LanguageSetting"].ToString());
            if (dtu != null && dtu.Rows.Count > 0)
            {
                lvUserList.DataSource = dtu;
                lvUserList.DataBind();
                Session["UserList"] = dtu;
            }
        }

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/UserManagement/Adduser.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
            // Response.RedirectPermanent("Adduser.aspx");
        }

      
        protected void lvUserList_LayoutCreated(object sender, EventArgs e)
        {
            Label lblUsername = (Label)lvUserList.FindControl("lblUsername");
            lblUsername.Text = GetLabel("USER NAME");
            Label lblOffice = (Label)lvUserList.FindControl("lblOffice");
            lblOffice.Text = GetLabel("OFFICE");
            Label lblMobileNumber = (Label)lvUserList.FindControl("lblMobileNumber");
            lblMobileNumber.Text = GetLabel("MOBILE NUMBER");
            Label lblEmail = (Label)lvUserList.FindControl("lblEmail");
            lblEmail.Text = GetLabel("EMAIL");
            Label status = (Label)lvUserList.FindControl("Status");
            status.Text = GetLabel("STATUS");
            Label action = (Label)lvUserList.FindControl("lblAction");
            action.Text = GetLabel("ACTION");
        }

        protected void lvUsers_ItemEditing(object sender, ListViewEditEventArgs e)
        {
           
        }

        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                //int id = Convert.ToInt32(e.CommandArgument);
                int id = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["id"] = e.CommandArgument.ToString();
                string url = Constants.ConstantAppPath + "/Modules/UserManagement/AddUser.aspx" + str.EncryptedString;
                Response.Redirect(url);

            }
            else if (e.CommandName == "delete")
            {
                int id = 0;
                id = Convert.ToInt32(e.CommandArgument.ToString());
                objServiceUser = new UserManagementService();
                objServiceUser.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationUser();
                int a = objServiceUser.DeleteUserById(id);
                if (a > 0)
                {
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/UserManagement/UsersList.aspx");
                }
                else
                {
                    //not deleted
                }

            }
            else if (e.CommandName == "lock")
            {
                int id = 0;
                id = int.Parse(e.CommandArgument.ToString());
                objServiceUser = new UserManagementService();
                objServiceUser.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationUser();
                objServiceUser.LockUser(id);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/UserManagement/UsersList.aspx");
            }
            else
            {
                int id = 0;
                id = int.Parse(e.CommandArgument.ToString());
                objServiceUser = new UserManagementService();
                objServiceUser.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationUser();
                objServiceUser.UnlockUser(id);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/UserManagement/UsersList.aspx");
            }
        }
    }
}