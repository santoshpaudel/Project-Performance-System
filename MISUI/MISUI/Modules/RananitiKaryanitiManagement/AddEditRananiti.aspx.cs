using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceOutputTarget;
using MISUI.ServiceProject;
using MISUI.ServiceSectorMgmt;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;
using ComSubSector = MISUI.ServiceSectorMgmt.ComSubSector;

namespace MISUI.Modules.RananitiKaryanitiManagement
{
    public partial class AddEditRananiti : Base
    {
        private ProjectService wbs = null;
        private ComProjectBO objProjectBO = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSector();


                if (Request.QueryString["enc"] != null)
                {

                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["id"] != null)
                        {
                            Session["rananitiId"] = objQueryString["id"].ToInt32();
                        }
                        if (Session["rananitiId"].ToInt32() > 0)
                        {
                            PopulateRananitiDetails(Session["rananitiId"].ToInt32());
                        }
                    }
                }
            }
        }

        private void PopulateRananitiDetails(int rananitiId)
        {
            ProjectService objWebService = new ProjectService();
            DataTable dtRananitiDetails = null;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtRananitiDetails = objWebService.PopulateRananitiDetails(rananitiId);
            if (dtRananitiDetails != null && dtRananitiDetails.Rows.Count > 0)
            {
                ddlSector.SelectedValue = dtRananitiDetails.Rows[0]["ACTIVITY_SECTOR_ID"].ToString();
                PopulateSubSector(ddlSector.SelectedValue.ToInt32());
                ddlSubSector.SelectedValue = dtRananitiDetails.Rows[0]["SUB_SECTOR_ID"].ToString();
                hidSubSector.Value = ddlSubSector.SelectedValue;
                txtRananitiEnglishName.Text = dtRananitiDetails.Rows[0]["RANANITI_ENG_NAME"].ToString();
                txtRananitiNepaliName.Text = dtRananitiDetails.Rows[0]["RANANITI_NEP_NAME"].ToString();
            }
        }

        private void PopulateSubSector(int SectorId)
        {
            SectorService objWebService = new SectorService();
            ComSubSector objComSubSector = new ComSubSector();
            DataTable dtPopulateSubSector = null;
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

        protected void btnAddRananiti_Click(object sender, EventArgs e)
        {
            objProjectBO = new ComProjectBO();
            if (Session["rananitiId"].ToInt32() > 0)
            {
                objProjectBO.Mode = "U";
                objProjectBO.RananitiId = Session["rananitiId"].ToInt32();
            }
            else
            {
                objProjectBO.Mode = "I";
            }
            objProjectBO.SubSector = ddlSubSector.SelectedValue.ToInt32();
            objProjectBO.RananitiEngName = txtRananitiEnglishName.Text;
            objProjectBO.RananitiNepName = txtRananitiNepaliName.Text;
            int i = 0;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            i = wbs.AddEditRananiti(objProjectBO);
            if (i > 0)
            {
                Response.Write("<script>alert('Rananiti is inserted/updated successfully!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Rananiti insertion/updation failed!')</script>");
            }

        }
    }
}