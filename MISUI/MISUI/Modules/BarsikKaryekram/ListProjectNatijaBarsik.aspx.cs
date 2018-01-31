using System;
using System.Data;
using System.Web.UI.WebControls;
using MISUI.ServiceBarsikKaryekram;
using MISUI.ServiceOutputTarget;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.BarsikKaryekram
{
    public partial class ListProjectNatijaBarsik : System.Web.UI.Page
    {
        private OutputTargetService objWebService = null;
        private OutputTarget objComOutputTarget = null;
        //private static DataTable dtTarget = null;
        private BarsikKaryekramService objBarsikService = null;
       // private static int projectId = 0;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["enc"] != null)
                {

                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["projectId"] != null)
                        {
                            Session["projectId"] = objQueryString["projectId"].ToInt32();
                        }
                    }

                }
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
            objBarsikService = new BarsikKaryekramService();
            ProjectOutputTBarsikBO objProjectOutBarsik = new ProjectOutputTBarsikBO();
            objProjectOutBarsik.Lang = SessionHelper.SessionLanguageSetting;
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            objProjectOutBarsik.ProjectId = Session["projectId"].ToInt32();
            objProjectOutBarsik.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            Session["dtTarget"] = objBarsikService.PopulateProjectTargetsBarsik(objProjectOutBarsik);
            DataTable dtTarget = (DataTable) Session["dtTarget"];
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
            ProjectOutputTBarsikBO objProjectOutBarsik = new ProjectOutputTBarsikBO();
            if (e.CommandName == "edit")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                objProjectOutBarsik.PTargetId =
                    ((HiddenField)grdTarget.Rows[RowIndex].FindControl("hidPTargetId")).Value.ToDecimal();
                objProjectOutBarsik.PTargetBId = e.CommandArgument.ToString().ToDecimal();
                objProjectOutBarsik.PTargetFirstC = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtFirstYearTarget")).Text;
                objProjectOutBarsik.PTargetSecondC = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtSecondYearTarget")).Text;
                objProjectOutBarsik.PTargetThirdC = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtThirdYearTarget")).Text;
                objProjectOutBarsik.ProjectId = Session["projectId"].ToInt32();
                objProjectOutBarsik.FiscalYearId = SessionHelper.SessionFiscalYear.ToDecimal();

                objProjectOutBarsik.Mode = "I"; 
                if (objProjectOutBarsik.PTargetBId != 0)
                {
                    objProjectOutBarsik.Mode = "U";
                }
              
                objBarsikService= new BarsikKaryekramService();
                objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
                i = objBarsikService.InsertUpdateProjectOutputTBarsik(objProjectOutBarsik);
                if(i>0)
                {
                    Response.Write("<script>alert('Target successfully recorded.') </script>");
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/BarsikKaryekram/ListProjectNatijaBarsik.aspx");

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

        protected void grdTarget_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //SelectFramework
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                      objWebService=new OutputTargetService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlFramework");
                ddl.DataSource = objWebService.SelectFramework();
                ddl.DataValueField = "FRAMEWORK_ID";
                ddl.DataTextField = "FRAMEWORK_NEP_NAME";
                ddl.DataBind();
                ListItem lst = new ListItem("--छान्नुहोस", "0");
                ddl.Items.Insert(0, lst);
                DataTable dtTarget = (DataTable) Session["dtTarget"];
                ddl.SelectedValue = dtTarget.Rows[e.Row.RowIndex]["framework_id"].ToString();
            }
        }
    }
}