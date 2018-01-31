using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceProject;
using MISUI.ServiceSectorMgmt;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;
using ComSubSector = MISUI.ServiceSectorMgmt.ComSubSector;

namespace MISUI.Modules.RananitiKaryanitiManagement
{
    public partial class ListRananiti : Base
    {
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        private DataTable dtRananitiDetail = null;
        SectorService objWebService = new SectorService();
        ComSubSector objComSubSector = new ComSubSector();
        DataTable dtPopulateSubSector = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSector();

            }
        }
        private void PopulateSector()
        {
            ComSubSector objComSubSector = new ComSubSector();
            SectorService objWebService = new SectorService();
            DataTable dtPopulateSector = null;
            objComSubSector.Lang = Session["LanguageSetting"].ToString();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
            dtPopulateSector = objWebService.PopulateAllSectors(objComSubSector);
            if (dtPopulateSector != null && dtPopulateSector.Rows.Count > 0)
            {
                ddlSector.DataSource = dtPopulateSector;
                ddlSector.DataValueField = "SECTOR_ID";
                ddlSector.DataTextField = "SECTOR_NAME";
                ddlSector.DataBind();
                ddlSector.Items.Insert(0, "--छान्नुहोस्--");
            }

        }

        protected void btnAddEditRananiti_Click(object sender, EventArgs e)
        {
            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/RananitiKaryanitiManagement/AddEditRananiti.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        protected void lvRananiti_LayoutCreated(object sender, EventArgs e)
        {
            Label lblRananitiName = (Label)lvRananiti.FindControl("lblRananitiName");
            lblRananitiName.Text = GetLabel("Rananiti Name");
            Label action = (Label)lvRananiti.FindControl("lblAction");
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
                Response.Redirect(Constants.ConstantAppPath + "/Modules/RananitiKaryanitiManagement/AddEditRananiti.aspx" + str.EncryptedString);
            }
            else if (e.CommandName == "delete")
            {
                int i = 0;
                int rananitiId = 0;
                rananitiId = int.Parse(e.CommandArgument.ToString());
                objProjectBO = new ComProjectBO();
                objProjectBO.RananitiId = rananitiId;
                objProjectBO.Mode = "D";
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                i = wbs.AddEditRananiti(objProjectBO);
                if (i > 0)
                {
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/RananitiKaryanitiManagement/ListRananiti.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Delete failed')</script>");
                }

            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            lvRananiti.DataSource = null;
            lvRananiti.DataBind();

            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtRananitiDetail = wbs.PopulateAllRananitiBySubSectorId(ddlSubSector.SelectedValue.ToInt32(), Session["LanguageSetting"].ToString());
            if (dtRananitiDetail != null && dtRananitiDetail.Rows.Count > 0)
            {
                lvRananiti.DataSource = dtRananitiDetail;
                lvRananiti.DataBind();
            }
        }

        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
            objComSubSector.SectorId = ddlSector.SelectedValue.ToInt32();
            objComSubSector.Lang = Session["LanguageSetting"].ToString();
            dtPopulateSubSector = objWebService.PopulateSubSectorsBySectorId(objComSubSector);
            if (dtPopulateSubSector != null && dtPopulateSubSector.Rows.Count > 0)
            {
                ddlSubSector.DataSource = dtPopulateSubSector;
                ddlSubSector.DataValueField = "ACTIVITY_SUB_SECTOR_ID";
                ddlSubSector.DataTextField = "SUB_SECTOR_NAME";
                ddlSubSector.DataBind();
                ddlSubSector.Items.Insert(0, "--छान्नुहोस्--");
            }
        }
    }
}