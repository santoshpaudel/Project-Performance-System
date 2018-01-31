using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceOutputTarget;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.OutputTargetManagement
{
    public partial class ListOutput : Base
    {
        private OutputTargetService objWebService = null;
        private OutputTarget objComOutputTarget = null;
        public DataTable dtListView = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAddOutput.Text = GetLabel("ADD OUTPUT");
            if (!IsPostBack)
            {
                BindListView();
            }
        }

        private void BindListView()
        {
            objWebService = new OutputTargetService();
            objComOutputTarget = new OutputTarget();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            objComOutputTarget.Lang = Session["LanguageSetting"].ToString();
            dtListView = objWebService.PopulateAllOutputs(objComOutputTarget);
            if (dtListView != null && dtListView.Rows.Count > 0)
            {
                lvOutput.DataSource = dtListView;
                lvOutput.DataBind();

            }
            else
            {

            }
        }

        protected void btnAddOutput_Click(object sender, EventArgs e)
        {
            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/OutputTargetManagement/AddOutput.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        protected void lvOutput_LayoutCreated(object sender, EventArgs e)
        {
            Label lblOutputName = (Label)lvOutput.FindControl("lblOutputName");
            lblOutputName.Text = GetLabel("OUTPUT NAME");
            Label lblOutputCode = (Label)lvOutput.FindControl("lblOutputCode");
            lblOutputCode.Text = GetLabel("OUTPUT CODE");
            Label lblOutputType = (Label)lvOutput.FindControl("lblOutputType");
            lblOutputType.Text = GetLabel("OUTPUT TYPE");
            Label lblToipYear = (Label)lvOutput.FindControl("lblToipYear");
            lblToipYear.Text = GetLabel("TOIP YEAR");
            Label lblSubSector = (Label)lvOutput.FindControl("lblSubSector");
            lblSubSector.Text = GetLabel("SUB SECTOR NAME");
            Label lblStatus = (Label)lvOutput.FindControl("Status");
            lblStatus.Text = GetLabel("STATUS");
            Label action = (Label)lvOutput.FindControl("lblAction");
            action.Text = GetLabel("Action");
            
        }

        protected void lvOutput_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            
        }

        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            int outputId = 0;
            if (e.CommandName == "edit")
            {
                outputId = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["id"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/OutputTargetManagement/AddOutput.aspx" + str.EncryptedString, false);
            }
            else if (e.CommandName == "delete")
            {
                objComOutputTarget = new OutputTarget();
                objComOutputTarget.ActivityOutputId = int.Parse(e.CommandArgument.ToString());
                objComOutputTarget.Mode = "D";
                objWebService = new OutputTargetService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
                objWebService.AddOutput(objComOutputTarget);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/OutputTargetManagement/ListOutput.aspx");
            }
            else if (e.CommandName == "lock")
            {
                int i = 0;
                objComOutputTarget = new OutputTarget();
                objComOutputTarget.ActivityOutputId = int.Parse(e.CommandArgument.ToString());
                objComOutputTarget.Mode = "L";
                objWebService = new OutputTargetService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
                i = objWebService.AddOutput(objComOutputTarget);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/OutputTargetManagement/ListOutput.aspx");
                else
                {
                    Response.Write("<script>alert('Lock failed')</script>");
                }
            }
            else
            {
                int i = 0;
                objComOutputTarget = new OutputTarget();
                objComOutputTarget.ActivityOutputId = int.Parse(e.CommandArgument.ToString());
                objComOutputTarget.Mode = "L";
                objWebService = new OutputTargetService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
                i = objWebService.AddOutput(objComOutputTarget);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/OutputTargetManagement/ListOutput.aspx");
                else
                {
                    Response.Write("<script>alert('Unlock failed')</script>");
                }
            }
        }
    }
}