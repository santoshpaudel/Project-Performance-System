using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceOutputTarget;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;

namespace MISUI.Modules.OutputTargetManagement
{
    public partial class ListTarget : System.Web.UI.Page
    {
        private OutputTargetService objWebService = null;
        private OutputTarget objComOutputTarget = null;
        public DataTable dtTarget = null;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSectors();
                PopulateAllTargets();
            }

        }

        private void PopulateSectors()
        {
            DataTable dt = new DataTable();
            objWebService = new OutputTargetService();
            objComOutputTarget = new OutputTarget();
            objComOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dt = objWebService.PopulateSectorsToFilter(objComOutputTarget);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlSector.DataSource = dt;
                ddlSector.DataTextField = "Sector_Name";
                ddlSector.DataValueField = "Sector_ID";
                ddlSector.DataBind();
                ddlSector.Items.Insert(0, "--क्षेत्र छान्नुहोस्--");
            }
        }

        private void PopulateAllTargets()
        {
            objWebService = new OutputTargetService();
            objComOutputTarget = new OutputTarget();
            objComOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dtTarget = objWebService.PopulateAllTargets(objComOutputTarget);
            if (dtTarget != null && dtTarget.Rows.Count > 0)
            {
                grdTarget.DataSource = dtTarget;
                grdTarget.DataBind();
                Session["TargetData"] = dtTarget;

            }
            else
            {

            }
        }

        protected void GrdTarget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int i = 0;
            objComOutputTarget = new OutputTarget();
            if (e.CommandName == "edit")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                objComOutputTarget.ActivityOutputMapId = int.Parse(e.CommandArgument.ToString());
                objComOutputTarget.PustyayiyekoShrot = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtPustyayiyekoShrot")).Text;
                objComOutputTarget.TargetFirstYear = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtFirstYearTarget")).Text;
                objComOutputTarget.TargetSecondYear = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtSecondYearTarget")).Text;
                objComOutputTarget.TargetThirdYear = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtThirdYearTarget")).Text;
                objWebService=new OutputTargetService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
                i = objWebService.AddTarget(objComOutputTarget);
                if(i>0)
                {
                    Response.Write("<script>alert('Target successfully recorded.') </script>");
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/OutputTargetManagement/ListTarget.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Target not recorded.') </script>");
                }
            }
        }

        protected void btnSearchClick(object sender, EventArgs e)
        {
            DataView view = new DataView();
            view.Table = (DataTable)Session["TargetData"];
            string SearchExpression = null;
            int sid = ddlSector.SelectedValue.ToInt32();
            int ssid = ddlSubSector.SelectedValue.ToInt32();
            int aid = ddlActivity.SelectedValue.ToInt32();
            if (sid>0 && ssid==0 && aid==0)
            {
                view.RowFilter = "SECTOR_ID = " + sid;
                grdTarget.DataSource = view;
                grdTarget.DataBind();
            }
            else if (sid > 0 && ssid> 0 && aid == 0)
            {
                view.RowFilter = "ACTIVITY_SUB_SECTOR_ID = " + ssid;
                grdTarget.DataSource = view;
                grdTarget.DataBind();
            }
            else if (sid > 0 && ssid> 0 && aid >0)
            {
                view.RowFilter = "ACTIVITY_DETAIL_ID = " + aid;
                grdTarget.DataSource = view;
                grdTarget.DataBind();
            }
            else
            {
                grdTarget.DataSource = Session["TargetData"];
                grdTarget.DataBind();
            }
           
        }

        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objWebService = new OutputTargetService();
            objComOutputTarget = new OutputTarget();
            objComOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objComOutputTarget.SectorId = ddlSector.SelectedValue.ToInt32();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dt = objWebService.PopulateSubSectorsToFilter(objComOutputTarget);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlSubSector.DataSource = dt;
                ddlSubSector.DataTextField = "Sub_Sector_Name";
                ddlSubSector.DataValueField = "Activity_Sub_Sector_ID";
                ddlSubSector.DataBind();
                ddlSubSector.Items.Insert(0, "--उपक्षेत्र छान्नुहोस्--");
            }
        }

        protected void ddlSubSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objWebService = new OutputTargetService();
            objComOutputTarget = new OutputTarget();
            objComOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objComOutputTarget.SubSectorId = ddlSubSector.SelectedValue.ToInt32();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dt = objWebService.PopulateAllActivitiesToFilter(objComOutputTarget);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlActivity.DataSource = dt;
                ddlActivity.DataTextField = "ACTIVITY_NAME";
                ddlActivity.DataValueField = "ACTIVITY_DETAIL_ID";
                ddlActivity.DataBind();
                ddlActivity.Items.Insert(0, "--सूचक छान्नुहोस्--");
            }
        }
    }
}