using System;
using System.Data;
using System.Web.UI.WebControls;
using MISUI.ServiceActivityMgmt;
using MISUI.ServiceSectorMgmt;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;
using MISUI.ServiceRoleMgmt;
using MISUICOMMON.HelperClass;

namespace MISUI.Modules.ActivityManagement
{
    public partial class AddActivityDetail : Base
    {

        ServiceActivityMgmt.ActivityManagementService wbs = new ServiceActivityMgmt.ActivityManagementService();

        private ActivityDetailBO objActivityBo = null;
        private int activityDetailId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            btnAddRoles.Text = GetLabel("Add");
            btnCancel.Text = GetLabel("Cancel");
            if (!IsPostBack)
            {
                populateSectors();
                populateSubSector();
                populateActivityUnit();
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
        private void populateActivityUnit()
        {
            wbs=new ActivityManagementService();
            DataTable dtUnit = null;
            objActivityBo=new ActivityDetailBO();
            objActivityBo.Lang = Session["languageSetting"].ToString();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            dtUnit = wbs.SelectActivityUnit(objActivityBo);
            if(dtUnit!=null && dtUnit.Rows.Count>0)
            {
                ddlUnit.DataSource = dtUnit;
                ddlUnit.DataTextField = "unit_name";
                ddlUnit.DataValueField = "unit_id";
                ddlUnit.DataBind();
                ddlUnit.Items.Insert(0, "-- छान्नुहोस्--");
            }
        }


        /// <summary>
        /// Loads all Activity.
        /// </summary>
        private void LoadAllActivityDetail()
        {
            objActivityBo = new ActivityDetailBO();
            objActivityBo.Lang = Session["LanguageSetting"].ToString();
            DataTable dt = new DataTable();
            wbs = new ActivityManagementService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            dt = wbs.PopulateActivityDetail(objActivityBo);
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
        /// <param name="activityDetailId">The activity detail id.</param>
        private void PopulateActivityDetailById(int activityDetailId)
        {
           objActivityBo=new ActivityDetailBO();
            objActivityBo.Lang = Session["LanguageSetting"].ToString();
            objActivityBo.ActivityDetailId = activityDetailId;
            DataTable dt = new DataTable();
            wbs=new ActivityManagementService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            dt = wbs.SelectActivityDetailById(objActivityBo);
            //Session["vdcList"] = dtvm;
            if (dt != null && dt.Rows.Count > 0)
            {
                txtActivityDetailNepName.Text = dt.Rows[0]["activity_detail_nep_name"].ToString();
                txtActivityDetailEngName.Text = dt.Rows[0]["activity_detail_eng_name"].ToString();
                txtActivityDetailId.Text = dt.Rows[0]["activity_detail_id"].ToString();
                if (dt.Rows[0]["isenable"].ToString() == "1")
                {
                    IsActive.Checked = true;
                }
                else
                {
                    IsActive.Checked = false;
                }
                ddlSubSector.SelectedValue = dt.Rows[0]["ACTIVITY_SUB_SECTOR_ID"].ToString();
                ddlUnit.SelectedValue = dt.Rows[0]["ACTIVITY_UNIT_ID"].ToString();
            }
            ClientScript.RegisterStartupScript(this.GetType(), "name1", "<script>  "
              + " $('#modal-form').modal();" + "  </script>");
        }

        protected void btnAddRoles_Click(object sender, EventArgs e)
        {
            wbs=new ActivityManagementService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            objActivityBo = new ActivityDetailBO();
            if (hidActivityDetailId.Value.ToInt32() > 0)
            {
                objActivityBo.Mode = "U";
                objActivityBo.ActivityDetailId = hidActivityDetailId.Value.ToInt32();
            }
            else
            {
                objActivityBo.Mode = "I";
            }

            objActivityBo.ActivityDetailEngName = txtActivityDetailEngName.Text;
            objActivityBo.ActivityDetailNepName = txtActivityDetailNepName.Text;
            objActivityBo.Isenable = IsActive.Checked == true ? 1 : 0;
            objActivityBo.ActivityUnitId = ddlUnit.SelectedValue.ToInt32();
            objActivityBo.ActivitySubSectorId = ddlSubSector.SelectedValue.ToInt32();
            wbs.ActivityDetail(objActivityBo);
            Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/AddActivityDetail.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/AddActivityDetail.aspx");
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
                Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/AddActivityDetail.aspx" + str.EncryptedString, false);
            }
            else if (e.CommandName == "delete")
            {
                int i = 0;
                wbs = new ActivityManagementService();
                roleId = int.Parse(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
                objActivityBo = new ActivityDetailBO();
                objActivityBo.ActivityDetailId = roleId;
                objActivityBo.Mode = "D";
                i = wbs.ActivityDetail(objActivityBo);
                //wbs.deleteDonar(donarId);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/AddActivityDetail.aspx");
                else
                {
                    Response.Write("<script>alert('Delete failed')</script>");
                }
            }
            else if (e.CommandName == "lock")
            {
                wbs = new ActivityManagementService();
                int i = 0;
                roleId = int.Parse(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
                objActivityBo = new ActivityDetailBO();
                objActivityBo.ActivityDetailId = roleId;
                objActivityBo.Mode = "L";
                i = wbs.ActivityDetail(objActivityBo);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/AddActivityDetail.aspx");
                else
                {
                    Response.Write("<script>alert('Lock failed')</script>");
                }

            }
            else
            {
                wbs = new ActivityManagementService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
                int i = 0;
                roleId = int.Parse(e.CommandArgument.ToString());
                roleId = int.Parse(e.CommandArgument.ToString());
                objActivityBo = new ActivityDetailBO();
                objActivityBo.ActivityDetailId = roleId;
                objActivityBo.Mode = "L";
                i = wbs.ActivityDetail(objActivityBo);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/ActivityManagement/AddActivityDetail.aspx");
                else
                {
                    Response.Write("<script>alert('Delete failed')</script>");
                }

            }
        }
    }
}