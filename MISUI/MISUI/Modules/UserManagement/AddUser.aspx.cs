using System;
using System.Data;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceOfficeMgmt;
using MISUI.ServiceUserMgmt;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;
using Users = MISUI.ServiceUserMgmt.Users;

namespace MISUI.Modules.UserManagement
{
    public partial class AddUser : Base
    {
        Service1 wbs
        {
            get { return new Service1(); }
        }
        
        public OfficeManagementService objServiceOffice
        {
            get{return new OfficeManagementService();}
        }

        private UserManagementService objServiceUser = null;
        //public static string id = null;
       
        Users UserBo = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                LoadOffice();
                LoadRole();
                LoadUserType();
                SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                if (objQueryString != null)
                {
                    if (objQueryString["id"] != null)
                    {
                        Session["id"] = objQueryString["id"];
                        loadUserDetails(Session["id"].ToString());

                    }
                }
              
            }
            btn_AddUser.Text = GetLabel("Add");
            btn_UserList.Text = GetLabel("User List");

        }
      
        private void loadUserDetails(string id)
        {
            objServiceUser = new UserManagementService();
            objServiceUser.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationUser();
            DataTable dtud = objServiceUser.FetchUserDetailsById(id);
            if (dtud!=null && dtud.Rows.Count>0)
            {
                txtUsername.Text = dtud.Rows[0]["LOGIN_ID"].ToString();
                txtNameEng.Text=dtud.Rows[0]["USER_ENG_NAME"].ToString();
                txtNameNep.Text = dtud.Rows[0]["USER_NEP_NAME"].ToString();
                //txtPassword.Text = dtud.Rows[0][""].ToString();
                ddlOffice.SelectedValue = dtud.Rows[0]["OFFICE_ID"].ToString();
                ddlRole.SelectedValue = dtud.Rows[0]["ROLE_ID"].ToString();
                ddlUserType.SelectedValue = dtud.Rows[0]["TYPE_ID"].ToString();
                txtMobile.Text = dtud.Rows[0]["MOBILE_NO"].ToString();
                txtEmail.Text = dtud.Rows[0]["EMAIL_ID"].ToString();
                if (dtud.Rows[0]["enable_disable"].ToString() == "1")
                {
                    chkIsEnable.Checked = true;
                }
                else
                {
                    chkIsEnable.Checked = false;
                }
                
            }
        }
       
        private void LoadOffice()
        {
            DataTable dto=new DataTable();
           OfficeManagementService objServiceOffice1=new OfficeManagementService();
            objServiceOffice1.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOffice();
            dto = objServiceOffice1.FetchAllOffice(Session["LanguageSetting"].ToString());
            if (dto!=null && dto.Rows.Count > 0)
            {
                ddlOffice.DataSource = dto;
                ddlOffice.DataTextField = "OFFICE_NAME";
                ddlOffice.DataValueField = "OFFICE_ID";
                ddlOffice.DataBind();
                ddlOffice.Items.Insert(0, "CHOOSE OFFICE");
            }
        }
        private void LoadRole()
        {
            DataTable dtr=new DataTable();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            dtr = wbs.FetchAllRole();
            if (dtr!=null && dtr.Rows.Count > 0)
            {
                ddlRole.DataSource = dtr;
                ddlRole.DataTextField = "ROLE_NEP_NAME";
                ddlRole.DataValueField = "ROLE_ID";
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, "CHOOSE ROLE");
            }
        }
        private void LoadUserType()
        {
            DataTable dtr = new DataTable();
            objServiceUser = new UserManagementService();
            objServiceUser.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationUser();
            dtr = objServiceUser.FetchAllUserType();
            if (dtr!=null && dtr.Rows.Count > 0)
            {
                ddlUserType.DataSource = dtr;
                ddlUserType.DataTextField = "USER_TYPE_ENG_NAME";
                ddlUserType.DataValueField = "USER_TYPE_ID";
                ddlUserType.DataBind();
                ddlUserType.Items.Insert(0, "CHOOSE USER TYPE");
            }
        }

       
        
        protected void btn_AddUser_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text==txtRePassword.Text && txtPassword.Text!=null)
            {
                UserBo.Username = txtUsername.Text;
                UserBo.NameEng = txtNameEng.Text;
                UserBo.NameNep = txtNameNep.Text;
                UserBo.Password = txtPassword.Text;
                UserBo.Office = Convert.ToInt32(ddlOffice.SelectedValue);
                UserBo.Role = ddlRole.SelectedValue;
                UserBo.UserType = Convert.ToInt32(ddlUserType.SelectedValue);
                UserBo.Mobile = txtMobile.Text;
                UserBo.Email = txtEmail.Text;
                UserBo.Organizarion = null;
                UserBo.EnableDisable = (chkIsEnable.Checked) ? 1 : 0;
                UserBo.RequestStatus = null;
                UserBo.RequestedBy = 0;
                

                if (Session["id"] != null && Session["id"].ToInt32() >0)
                {
                  UserBo.UserId = Session["id"].ToInt32();
                  UserBo.IsLocked = 0;
                  objServiceUser = new UserManagementService();
                  objServiceUser.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationUser();
                  int i=objServiceUser.UpdateUserById(UserBo);
                    if (i>0)
                    {
                        Response.Write("<script>alert('User Details Updated Successfully!');</script>");
                        Response.Redirect(Constants.ConstantAppPath+"/Modules/UserManagement/UsersList.aspx");
                    }
                    else
                    {
                        //not inserted
                        Response.Write("<script>alert('User Details Update Failed!');</script>");

                    
                    }
                }
                else 
                {
                    objServiceUser = new UserManagementService();
                    objServiceUser.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationUser();
                   int i = objServiceUser.InsertUser(UserBo);
                    if (i > 0)
                    {
                       
                        Response.Write("<script>alert('User Added Successfully!');</script>");
                        Response.Redirect(Constants.ConstantAppPath + "/Modules/UserManagement/UsersList.aspx");
                    }
                    else
                    {
                        //not inserted
                        Response.Write("<script>alert('User Addition Failed');</script>");

                    }
                }
            
           
                
            }
            else
            {
                    //password mismatch
                Response.Write("<script>alert('Password Mismatched');</script>");
                
            }
        }

        protected void btn_UserList_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.ConstantAppPath + "/Modules/UserManagement/UsersList.aspx");
        }
    }
}