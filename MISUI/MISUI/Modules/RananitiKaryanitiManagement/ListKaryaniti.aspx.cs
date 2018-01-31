using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.RananitiKaryanitiManagement
{
    public partial class ListKaryaniti : Base
    {
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAllRananiti();

            }
        }

        private void PopulateAllRananiti()
        {
            DataTable dtRananiti = null;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtRananiti = wbs.PopulateAllRananiti(Session["LanguageSetting"].ToString());
            if (dtRananiti != null && dtRananiti.Rows.Count > 0)
            {
                ddlRananiti.DataSource = dtRananiti;
                ddlRananiti.DataValueField = "RANANITI_ID";
                ddlRananiti.DataTextField = "RANANITI_NAME";
                ddlRananiti.DataBind();
                ddlRananiti.Items.Insert(0, "--छान्नुहोस्--");
            }
        }

        protected void btnAddEditKaryaniti_Click(object sender, EventArgs e)
        {
            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/RananitiKaryanitiManagement/AddEditKaryaniti.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        protected void lvKaryaniti_LayoutCreated(object sender, EventArgs e)
        {
            Label lblKaryanitiName = (Label)lvKaryaniti.FindControl("lblKaryanitiName");
            lblKaryanitiName.Text = GetLabel("Karyaniti Name");
            Label action = (Label)lvKaryaniti.FindControl("lblAction");
            action.Text = GetLabel("Action");
        }

        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            int projectId = 0;
            if (e.CommandName == "edit")
            {
                projectId = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["id"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/RananitiKaryanitiManagement/AddEditKaryaniti.aspx" + str.EncryptedString);
            }
            else if (e.CommandName == "delete")
            {
                int i = 0;
                int karyanitiId = 0;
                karyanitiId = int.Parse(e.CommandArgument.ToString());
                objProjectBO = new ComProjectBO();
                objProjectBO.KaryanitiId = karyanitiId;
                objProjectBO.Mode = "D";
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                i = wbs.AddEditKaryaniti(objProjectBO);
                if (i > 0)
                {
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/RananitiKaryanitiManagement/ListKaryaniti.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Delete failed')</script>");
                }

            }
        }

        protected void ddlRananiti_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtKaryaniti = null;
            int rananitiId = ddlRananiti.SelectedValue.ToInt32();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtKaryaniti = wbs.PopulateAllKaryaniti(rananitiId, Session["LanguageSetting"].ToString());
            if (dtKaryaniti != null && dtKaryaniti.Rows.Count > 0)
            {
                lvKaryaniti.DataSource = dtKaryaniti;
                lvKaryaniti.DataBind();
            }
        }
    }
}