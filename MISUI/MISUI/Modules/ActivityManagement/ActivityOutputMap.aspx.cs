using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceActivityMgmt;
using MISUI.ServiceSectorMgmt;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.ActivityManagement
{
    public partial class ActivityOutputMap :Base
    {
        ServiceActivityMgmt.ActivityManagementService wbs = new ServiceActivityMgmt.ActivityManagementService();

        private ActivityDetailBO objActivityBo = null;
        private ActivityOutputMapBO objActivityOutputBo = null;

        private int activityDetailId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            btnAddRoles.Text = GetLabel("Add");
            btnCancel.Text = GetLabel("Cancel");
            if (!IsPostBack)
            {
               populateSectors();
                populateSubSector();
               // PopulateActivityDetail();

                if (Request.QueryString["enc"] != null)
                {

                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["id"] != null)
                        {
                            activityDetailId = int.Parse(objQueryString["id"]);
                            hidActivityDetailId.Value = objQueryString["id"];

                        }
                    }

                }
                if (activityDetailId != 0)
                {
                    PopulateActivityDetailById(activityDetailId);
                }
                else
                {
                    LoadAllActivityDetail();
                }

            }

        }

        private void populateSectors()
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
                ddlSector.Items.Insert(0, "--क्षेत्र छान्नुहोस्--");
            }


        }
        private void populateSubSector()
        {
            SectorService objWebService = new SectorService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
            DataTable dtPopulateSubSector = null;
            string selectedDataText = string.Empty;
            ComSubSector objComSubSector = new ComSubSector();

            dtPopulateSubSector = objWebService.PopulateAllSubSectors(objComSubSector);
            if (dtPopulateSubSector != null && dtPopulateSubSector.Rows.Count > 0)
            {
                selectedDataText = Session["LanguageSetting"].ToString() == "Nepali" ? "activity_sub_sector_nep_name" : "activity_sub_sector_eng_name";
                ddlSubSector.DataSource = dtPopulateSubSector;
                ddlSubSector.DataTextField = selectedDataText;
                ddlSubSector.DataValueField = "activity_sub_sector_id";
                ddlSubSector.DataBind();
                ddlSubSector.Items.Insert(0, "-- छान्नुहोस्--");
            }
        }
        private void PopulateOutput()
        {
            SectorService objWebService = new SectorService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
            DataTable dtPopulateSubSector = null;
            string selectedDataText = string.Empty;
            ComSubSector objComSubSector = new ComSubSector();

            dtPopulateSubSector = objWebService.PopulateAllSubSectors(objComSubSector);
            if (dtPopulateSubSector != null && dtPopulateSubSector.Rows.Count > 0)
            {
                selectedDataText = Session["LanguageSetting"].ToString() == "Nepali" ? "activity_sub_sector_nep_name" : "activity_sub_sector_eng_name";
                ddlSubSector.DataSource = dtPopulateSubSector;
                ddlSubSector.DataTextField = selectedDataText;
                ddlSubSector.DataValueField = "activity_sub_sector_id";
                ddlSubSector.DataBind();
                ddlSubSector.Items.Insert(0, "-- छान्नुहोस्--");
            }
        }
        
        private void PopulateActivityDetail()
        {
            objActivityBo = new ActivityDetailBO();
            objActivityBo.Lang = Session["LanguageSetting"].ToString();
            DataTable dt = new DataTable();
            wbs = new ActivityManagementService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            dt = wbs.PopulateActivityDetail(objActivityBo);
            if(dt!=null && dt.Rows.Count>0)
            {
                ddlActivityDetail.DataSource = dt;
                ddlActivityDetail.DataTextField = "activity_detail_name";
                ddlActivityDetail.DataValueField = "activity_detail_id";
                ddlActivityDetail.DataBind();
            }

        }

        /// <summary>
        /// Loads all Activity.
        /// </summary>
        private void LoadAllActivityDetail()
        {
           
            objActivityOutputBo=new ActivityOutputMapBO();
            objActivityOutputBo.Lang = Session["LanguageSetting"].ToString();
            DataTable dt = new DataTable();
            wbs = new ActivityManagementService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            dt = wbs.PopulateActivityOutputMapDetail(objActivityOutputBo);
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
        /// <param name="activityMapId">The activity map id.</param>
        private void PopulateActivityDetailById(int activityMapId)
        {
            objActivityOutputBo = new ActivityOutputMapBO();
            objActivityOutputBo.Lang = Session["LanguageSetting"].ToString();
            objActivityOutputBo.ActivityOutputMapId = activityMapId;
            DataTable dt = new DataTable();
            wbs = new ActivityManagementService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            dt = wbs.SelectActivityOutputById(objActivityOutputBo);
            //Session["vdcList"] = dtvm;
            if (dt != null && dt.Rows.Count > 0)
            {    WebService1 objWebService=new WebService1();
                //bind Activity
                ddlActivityDetail.DataSource =
                objWebService.FindActivityBySectorID(dt.Rows[0]["ACTIVITY_SUB_SECTOR_ID"].ToString());
                ddlActivityDetail.DataValueField = "ComboId";
                ddlActivityDetail.DataTextField = "Name";
                ddlActivityDetail.DataBind();
                //bind output
                ddlOutput.DataSource =
                objWebService.FindActivityOutputBySectorID(dt.Rows[0]["ACTIVITY_SUB_SECTOR_ID"].ToString());
                ddlOutput.DataValueField = "ComboId";
                ddlOutput.DataTextField = "Name";
                ddlOutput.DataBind();
                //
                ddlSubSector.SelectedValue = dt.Rows[0]["ACTIVITY_SUB_SECTOR_ID"].ToString();
                ddlActivityDetail.SelectedValue = dt.Rows[0]["ACTIVITY_DETAIL_ID"].ToString();
                ddlOutput.SelectedValue = dt.Rows[0]["ACTIVITY_OUTPUT_ID"].ToString();
                if (dt.Rows[0]["isenabled"].ToString() == "1")
                {
                    IsActive.Checked = true;
                }
                else
                {
                    IsActive.Checked = false;
                }
                //ddlSubSector.SelectedValue = dt.Rows[0]["ACTIVITY_SUB_SECTOR_ID"].ToString();
                //ddlUnit.SelectedValue = dt.Rows[0]["ACTIVITY_UNIT_ID"].ToString();
                
            }
            LoadAllActivityDetail();
            ClientScript.RegisterStartupScript(this.GetType(), "name1", "<script>  "
              + " $('#modal-form').modal();  var bsModal = $.fn.modal.noConflict();" + "  </script>");
            
        }

        protected void btnAddRoles_Click(object sender, EventArgs e)
        {
            wbs = new ActivityManagementService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            objActivityOutputBo = new ActivityOutputMapBO();
            if (hidActivityDetailId.Value.ToInt32() > 0)
            {
                objActivityOutputBo.Mode = "U";
                objActivityOutputBo.ActivityOutputMapId = hidActivityDetailId.Value.ToInt32();
            }
            else
            {
                objActivityOutputBo.Mode = "I";
            }

            objActivityOutputBo.ActivityOutputId = hidOutputId.Value.ToInt32();
            objActivityOutputBo.FiscalYearId = 1;
            objActivityOutputBo.Isenabled = IsActive.Checked == true ? 1 : 0;
            objActivityOutputBo.ActivityDetailId = hidSelectedActivityId.Value.ToInt32();
            wbs.ActivityOutputMap(objActivityOutputBo);
            Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/ActivityOutputMap.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/ActivityOutputMap.aspx");
        }

        protected void OnLayoutCreated(object sender, EventArgs e)
        {
            /*Label lblVdcMunEngName = (Label)lvVdcMunList.FindControl("lblVdcMunEngName");
           lblVdcMunEngName.Text = GetLabel("VDC/MUN ENGLISH NAME");*/
            Label lblRoleName = (Label)lvRoles.FindControl("lblActivityName");
            lblRoleName.Text = GetLabel("Activity Name");
            Label status = (Label)lvRoles.FindControl("Status");
            status.Text = GetLabel("STATUS");
            Label action = (Label)lvRoles.FindControl("lblAction");
            action.Text = GetLabel("Action");
            Label subSector = (Label)lvRoles.FindControl("lblSubSector");
            subSector.Text = GetLabel("Sub Sector");
            Label lblOutput = (Label)lvRoles.FindControl("lblOutput");
            lblOutput.Text = GetLabel("Output Name");
            Label lblUnit = (Label)lvRoles.FindControl("lblUnit");
            lblUnit.Text = GetLabel("Unit");
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
                Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/ActivityOutputMap.aspx" + str.EncryptedString, false);
            }
            else if (e.CommandName == "delete")
            {
                int i = 0;
                wbs = new ActivityManagementService();
                roleId = int.Parse(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
                objActivityOutputBo = new ActivityOutputMapBO();
                objActivityOutputBo.ActivityOutputMapId = roleId;
                objActivityOutputBo.Mode = "D";
                i = wbs.ActivityOutputMap(objActivityOutputBo);
                //wbs.deleteDonar(donarId);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/ActivityOutputMap.aspx");
                else
                {
                    Response.Redirect("<script>alert('Delete failed')</script>");
                }
            }
            else if (e.CommandName == "lock")
            {
                wbs = new ActivityManagementService();
                int i = 0;
                roleId = int.Parse(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
                objActivityOutputBo = new ActivityOutputMapBO();
                objActivityOutputBo.ActivityOutputMapId = roleId;
                objActivityOutputBo.Mode = "L";
                i = wbs.ActivityOutputMap(objActivityOutputBo);
            
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/ActivityOutputMap.aspx");
                else
                {
                    Response.Redirect("<script>alert('Lock failed')</script>");
                }

            }
            else
            {
                wbs = new ActivityManagementService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
                int i = 0;
                roleId = int.Parse(e.CommandArgument.ToString());
                roleId = int.Parse(e.CommandArgument.ToString());
                objActivityOutputBo = new ActivityOutputMapBO();
                objActivityOutputBo.ActivityOutputMapId = roleId;
                objActivityOutputBo.Mode = "L";
                i = wbs.ActivityOutputMap(objActivityOutputBo);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/ActivityOutputMap.aspx");
                else
                {
                    Response.Redirect("<script>alert('Delete failed')</script>");
                }

            }
        }

       
    }
}