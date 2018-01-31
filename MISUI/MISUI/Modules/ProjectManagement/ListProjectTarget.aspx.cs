using System;
using System.Data;
using System.Web.UI.WebControls;
using MISUI.ServiceOutputTarget;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.ProjectManagement
{
    public partial class ListProjectTarget :Base
    {
        private OutputTargetService objWebService = null;
        private OutputTarget objComOutputTarget = null;
        //private static DataTable dtTarget = null;

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
                            Session["prjId"] = objQueryString["projectId"].ToInt32();
                           // projectId = objQueryString["projectId"].ToInt32();
                        }
                    }

                }
                PopulateSectors();
                PopulateAllTargets();
                int sid = 0;
                int ssid = 0;
                if (Session["sidListProjectTarget"] != null)
                {
                    sid = Session["sidListProjectTarget"].ToInt32();
                    ddlSector.SelectedValue = sid.ToString();
                    PopulateSubSectors(sid);
                }
                if (Session["ssidListProjectTarget"] != null)
                {
                    ssid = Session["ssidListProjectTarget"].ToInt32();
                    ddlSubSector.SelectedValue = ssid.ToString();
                    PopulateActivities(ssid);
                }
                if (Session["aidListProjectTarget"] != null)
                {
                    int aid = Session["aidListProjectTarget"].ToInt32();
                    ddlActivity.SelectedValue = aid.ToString();
                    PopulateTargetsWithSession(sid, ssid, aid);
                }
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

                ddlModalSector.DataSource = dt;
                ddlModalSector.DataTextField = "Sector_Name";
                ddlModalSector.DataValueField = "Sector_ID";
                ddlModalSector.DataBind();
                ddlModalSector.Items.Insert(0, "--क्षेत्र छान्नुहोस्--");
            }
        }
        
        private void PopulateAllTargets()
        {
            objWebService = new OutputTargetService();
            objComOutputTarget = new OutputTarget();
            objComOutputTarget.Lang = SessionHelper.SessionLanguageSetting;
            objComOutputTarget.MinistryId = Session["ministry_id"].ToInt32();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            objComOutputTarget.ProjectId = Session["prjId"].ToString().ToInt32();
            DataTable dtTarget = objWebService.PopulateProjectTargets(objComOutputTarget);
            Session["dtTarget"] = dtTarget;
            if (dtTarget != null && dtTarget.Rows.Count > 0)
            {
                /*grdTarget.DataSource = dtTarget;
                grdTarget.DataBind();*/
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
                objComOutputTarget.PtargetId = e.CommandArgument.ToString().ToDecimal();
                objComOutputTarget.ActivityOutputMapId = ((HiddenField)grdTarget.Rows[RowIndex].FindControl("hidAOutputMapId")).Value.ToDecimal(); 
                objComOutputTarget.TargetFirstYear = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtFirstYearTarget")).Text;
                objComOutputTarget.TargetSecondYear = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtSecondYearTarget")).Text;
                objComOutputTarget.TargetThirdYear = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtThirdYearTarget")).Text;
                objComOutputTarget.OverallTarget = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtOverAllTarget")).Text;
                objComOutputTarget.BaseYearTarget = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtBaseYearTarget")).Text;
                objComOutputTarget.ProjectId = Session["prjId"].ToString().ToInt32();
                objComOutputTarget.FrameworkId = ((DropDownList)grdTarget.Rows[RowIndex].FindControl("ddlFramework")).SelectedValue.ToDecimal();
                objComOutputTarget.Mode = "I";
                if(objComOutputTarget.PtargetId!=0)
               {
                   objComOutputTarget.Mode = "U";
               }
               
                objWebService=new OutputTargetService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
                i = objWebService.AddProjectOutputTarget(objComOutputTarget);
                if(i>0)
                {
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/ListProjectTarget.aspx");
                    
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
            Session["sidListProjectTarget"] = sid;
            int ssid = ddlSubSector.SelectedValue.ToInt32();
            Session["ssidListProjectTarget"] = ssid;
            int aid = ddlActivity.SelectedValue.ToInt32();
            Session["aidListProjectTarget"] = aid; 
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

        private void PopulateTargetsWithSession(int sid,int ssid,int aid)
        {
            DataView view = new DataView();
            view.Table = (DataTable)Session["TargetData"];
            string SearchExpression = null;
            if (sid > 0 && ssid == 0 && aid == 0)
            {
                view.RowFilter = "SECTOR_ID = " + sid;
                grdTarget.DataSource = view;
                grdTarget.DataBind();
            }
            else if (sid > 0 && ssid > 0 && aid == 0)
            {
                view.RowFilter = "ACTIVITY_SUB_SECTOR_ID = " + ssid;
                grdTarget.DataSource = view;
                grdTarget.DataBind();
            }
            else if (sid > 0 && ssid > 0 && aid > 0)
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
            PopulateSubSectors(ddlSector.SelectedValue.ToInt32());
        }
        private void PopulateSubSectors(int sid)
        {
            DataTable dt = new DataTable();
            objWebService = new OutputTargetService();
            objComOutputTarget = new OutputTarget();
            objComOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objComOutputTarget.SectorId = sid;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dt = objWebService.PopulateSubSectorsToFilter(objComOutputTarget);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlSubSector.DataSource = dt;
                ddlSubSector.DataTextField = "Sub_Sector_Name";
                ddlSubSector.DataValueField = "Activity_Sub_Sector_ID";
                ddlSubSector.DataBind();
                ddlSubSector.Items.Insert(0, "--उपक्षेत्र छान्नुहोस्--");

                ddlModalSubSector.DataSource = dt;
                ddlModalSubSector.DataTextField = "Sub_Sector_Name";
                ddlModalSubSector.DataValueField = "Activity_Sub_Sector_ID";
                ddlModalSubSector.DataBind();
                ddlModalSubSector.Items.Insert(0, "--उपक्षेत्र छान्नुहोस्--");
            }
        }

        protected void ddlSubSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateActivities(ddlSubSector.SelectedValue.ToInt32());

        }

        private void PopulateActivities(int ssid)
        {
            DataTable dt = new DataTable();
            objWebService = new OutputTargetService();
            objComOutputTarget = new OutputTarget();
            objComOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objComOutputTarget.SubSectorId = ssid;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dt = objWebService.PopulateAllActivitiesToFilter(objComOutputTarget);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlActivity.DataSource = dt;
                ddlActivity.DataTextField = "ACTIVITY_NAME";
                ddlActivity.DataValueField = "ACTIVITY_DETAIL_ID";
                ddlActivity.DataBind();
                ddlActivity.Items.Insert(0, "--सूचक छान्नुहोस्--");

                ddlModalActivity.DataSource = dt;
                ddlModalActivity.DataTextField = "ACTIVITY_NAME";
                ddlModalActivity.DataValueField = "ACTIVITY_DETAIL_ID";
                ddlModalActivity.DataBind();
                ddlModalActivity.Items.Insert(0, "--सूचक छान्नुहोस्--");
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
                DataTable dtTarget = (DataTable)Session["dtTarget"];
                ddl.SelectedValue = dtTarget.Rows[e.Row.RowIndex]["framework_id"].ToString();
            }
        }

        protected void ddlModalSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSubSectors(ddlSector.SelectedValue.ToInt32());
            ClientScript.RegisterStartupScript(this.GetType(), "name1", "<script type='text/javascript' src='../../assets/js/bootstrap.js'></script><script>  "
            + " $('#modal-form').modal();" + "  </script>");
        }

        protected void ddlModalSubSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateActivities(ddlSubSector.SelectedValue.ToInt32());
            ClientScript.RegisterStartupScript(this.GetType(), "name1", "<script type='text/javascript' src='../../assets/js/bootstrap.js'></script><script>  "
            + " $('#modal-form').modal();" + "  </script>");
        }

        protected void btnModalSearchClick(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "name1", "<script type='text/javascript' src='../../assets/js/bootstrap.js'></script><script>  "
            + " $('#modal-form').modal();" + "  </script>");
        }

        protected void btnSaveNatijaSuchakList_Click(object sender, EventArgs e)
        {
            
        }
    }
}