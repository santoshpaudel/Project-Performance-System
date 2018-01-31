using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceFrameworkMgmt;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.FrameworkManagement
{
    public partial class FrameworkList : Base
    {
        private FrameworkBO objFrameworkBo = null;
        private FrameworkManagementService wbs = null;
        private DataTable dtFrameworks = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAllFrameworks();
            }
        }

        private void PopulateAllFrameworks()
        {
            lvFramework.DataSource = null;
            lvFramework.DataBind();

            objFrameworkBo = new FrameworkBO();
            wbs = new FrameworkManagementService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationFramework();
            dtFrameworks = wbs.PopulateAllFrameworks();
            if (dtFrameworks != null && dtFrameworks.Rows.Count > 0)
            {
                lvFramework.DataSource = dtFrameworks;
                lvFramework.DataBind();
            }
        }

        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            int frameworkId = 0;
            if (e.CommandName == "edit")
            {
                frameworkId = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["frameworkId"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/FrameworkManagement/AddEditFramework.aspx" + str.EncryptedString);
            }
            else if (e.CommandName == "delete")
            {
                int i = 0;
                frameworkId = int.Parse(e.CommandArgument.ToString());
                objFrameworkBo = new FrameworkBO();
                objFrameworkBo.FrameworkId = frameworkId;
                objFrameworkBo.Mode = "D";
                wbs = new FrameworkManagementService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationFramework();
                i = wbs.AddEditFramework(objFrameworkBo);
                if (i > 0)
                {
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/FrameworkManagement/FrameworkList.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Delete failed')</script>");
                }

            }
            else if (e.CommandName == "lock")
            {
                int i = 0;
                frameworkId = int.Parse(e.CommandArgument.ToString());
                objFrameworkBo = new FrameworkBO();
                objFrameworkBo.FrameworkId = frameworkId;
                objFrameworkBo.Mode = "L";
                wbs = new FrameworkManagementService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationFramework();
                i = wbs.AddEditFramework(objFrameworkBo);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/FrameworkManagement/FrameworkList.aspx");    
                else
                {
                    Response.Write("<script>alert('Lock failed')</script>");
                }
            }
            else
            {
                int i = 0;
                frameworkId = int.Parse(e.CommandArgument.ToString());
                objFrameworkBo = new FrameworkBO();
                objFrameworkBo.FrameworkId = frameworkId;
                objFrameworkBo.Mode = "L";
                wbs = new FrameworkManagementService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationFramework();
                i = wbs.AddEditFramework(objFrameworkBo);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/FrameworkManagement/FrameworkList.aspx");
                else
                {
                    Response.Write("<script>alert('Unlock failed')</script>");
                }
            } 
        }

        protected void btnAddFramework_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.ConstantAppPath + "/Modules/FrameworkManagement/AddEditFramework.aspx");
        }

        protected void lvFramework_LayoutCreated(object sender, EventArgs e)
        {
            Label lblFrameworkEngName = (Label)lvFramework.FindControl("lblFrameworkEngName");
            lblFrameworkEngName.Text = GetLabel("Framework English Name");
            Label lblFrameworkNepName = (Label)lvFramework.FindControl("lblFrameworkNepName");
            lblFrameworkNepName.Text = GetLabel("Framework Nepali Name");
            Label lblBaseYear = (Label)lvFramework.FindControl("lblBaseYear");
            lblBaseYear.Text = GetLabel("Base Year");
            Label lblFirstYear = (Label)lvFramework.FindControl("lblFirstYear");
            lblFirstYear.Text = GetLabel("First Year");
            Label lblSecondYear = (Label)lvFramework.FindControl("lblSecondYear");
            lblSecondYear.Text = GetLabel("Second Year");
            Label lblThirdYear = (Label)lvFramework.FindControl("lblThirdYear");
            lblThirdYear.Text = GetLabel("Third Year");
            Label lblStatus = (Label)lvFramework.FindControl("Status");
            lblStatus.Text = GetLabel("Status");
            Label action = (Label)lvFramework.FindControl("lblAction");
            action.Text = GetLabel("Action");
        }
    }
}