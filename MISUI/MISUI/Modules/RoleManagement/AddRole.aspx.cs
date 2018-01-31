using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;
using MISUI.ServiceRoleMgmt;
using MISUICOMMON.HelperClass;
namespace MISUI.Modules.RoleManagement
{
    public partial class AddRole : Base
    {

        ServiceRoleMgmt.RoleManagement wbs = new ServiceRoleMgmt.RoleManagement();

        private Roles objRoles = null;
        private int roleId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            btnAddRoles.Text = GetLabel("Add");
            if (!IsPostBack)
            {
                if (Request.QueryString["enc"] != null)
                {

                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["id"] != null)
                        {
                            roleId = int.Parse(objQueryString["id"]);
                            hidroleId.Value = objQueryString["id"];

                        }
                    }

                }
                if (roleId != 0)
                {
                    PopulateRoleById(roleId);
                }
                else
                {
                    LoadAllRoles();
                }

            }

        }


        /// <summary>
        /// Loads all roles.
        /// </summary>
        private void LoadAllRoles()
        {
            Roles objRoles = new Roles();
            objRoles.Lang = Session["LanguageSetting"].ToString();
            DataTable dt = new DataTable();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationRole();
            dt = wbs.PopulateRole(objRoles);
            //Session["vdcList"] = dtvm;
            if (dt != null && dt.Rows.Count > 0)
            {
                lvRoles.DataSource = dt;
                lvRoles.DataBind();
            }
        }
        /// <summary>
        /// Populates the role by id.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        private void PopulateRoleById(int roleId)
        {
            Roles objRoles = new Roles();
            objRoles.Lang = Session["LanguageSetting"].ToString();
            objRoles.RoleId = roleId;
            DataTable dt = new DataTable();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationRole();
            dt = wbs.PopulateRoleById(objRoles);
            //Session["vdcList"] = dtvm;
            if (dt != null && dt.Rows.Count > 0)
            {
                txtRoleEngName.Text = dt.Rows[0]["role_eng_name"].ToString();
                txtRoleNepName.Text = dt.Rows[0]["role_nep_name"].ToString();
                txtRoleId.Text = dt.Rows[0]["role_id"].ToString();
                if (dt.Rows[0]["isenable"].ToString() == "1")
                {
                    IsActive.Checked = true;
                }
                else
                {
                    IsActive.Checked = false;
                }


            }
            ClientScript.RegisterStartupScript(this.GetType(), "name1", "<script type='text/javascript' src='../../assets/js/bootstrap.js'></script><script>  "
              + " $('#modal-form').modal();" + "  </script>");
        }

        protected void btnAddRoles_Click(object sender, EventArgs e)
        {
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationRole();
            objRoles = new Roles();
            if (hidroleId.Value.ToInt32() > 0)
            {
                objRoles.Mode = "U";
                objRoles.RoleId = hidroleId.Value.ToInt32();
            }
            else
            {
                objRoles.Mode = "I";
            }

            objRoles.RoleEngName = txtRoleEngName.Text;
            objRoles.RoleNepName = txtRoleNepName.Text;
            objRoles.Isenable = IsActive.Checked == true ? 1 : 0;
            wbs.AddRole(objRoles);
            Response.Redirect(Constants.ConstantAppPath + "/Modules/RoleManagement/AddRole.aspx");
        }

        protected void OnLayoutCreated(object sender, EventArgs e)
        {
            /*Label lblVdcMunEngName = (Label)lvVdcMunList.FindControl("lblVdcMunEngName");
           lblVdcMunEngName.Text = GetLabel("VDC/MUN ENGLISH NAME");*/
            Label lblRoleName = (Label)lvRoles.FindControl("lblRoleName");
            lblRoleName.Text = GetLabel("ROLE NAME");
            Label status = (Label)lvRoles.FindControl("Status");
            status.Text = GetLabel("STATUS");
            Label action = (Label)lvRoles.FindControl("lblAction");
            action.Text = GetLabel("Action");
        }

        protected void lvRoles_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            int roleId = 0;

            if (e.CommandName == "edit")
            {
                roleId = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["id"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/RoleManagement/AddRole.aspx" + str.EncryptedString, false);
            }
            else if (e.CommandName == "delete")
            {
                int i = 0;
                wbs = new ServiceRoleMgmt.RoleManagement();
                roleId = int.Parse(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationRole();
                objRoles = new Roles();
                objRoles.RoleId = roleId;
                objRoles.Mode = "D";
                i = wbs.AddRole(objRoles);
                //wbs.deleteDonar(donarId);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/RoleManagement/AddRole.aspx");
                else
                {
                    Response.Write("<script>alert('Delete failed')</script>");
                }
            }
            else if (e.CommandName == "lock")
            {
                wbs = new ServiceRoleMgmt.RoleManagement();
                int i = 0;
                roleId = int.Parse(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationRole();
                objRoles = new Roles();
                objRoles.RoleId = roleId;
                objRoles.Mode = "L";
                i = wbs.AddRole(objRoles);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/RoleManagement/AddRole.aspx");
                else
                {
                    Response.Write("<script>alert('Delete failed')</script>");
                }

            }
            else
            {
                wbs = new ServiceRoleMgmt.RoleManagement();
                int i = 0;
                roleId = int.Parse(e.CommandArgument.ToString());
                roleId = int.Parse(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationRole();
                objRoles = new Roles();
                objRoles.RoleId = roleId;
                objRoles.Mode = "L";
                i = wbs.AddRole(objRoles);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/RoleManagement/AddRole.aspx");
                else
                {
                    Response.Write("<script>alert('Delete failed')</script>");
                }

            }
        }
    }
}