using System;
using System.Data;
using MISUI.ServiceOfficeMgmt;
using MISUI.ServiceVdcMun;
using MISUICOMMON;
using MISUI.ServiceMenuOffice;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using ComOffice = MISUI.ServiceOfficeMgmt.ComOffice;

namespace MISUI.Modules.OfficeManagement
{
    public partial class AddOffice : Base
    {
       // public static int officeId = 0;
       // public static int entryMode = 0;
       // public static DataTable dtPopulateOfficeDetails = null;

        ComOffice objComOffice = new ComOffice();
        OfficeManagementService objWebService = new OfficeManagementService();
        Service1 objService=new Service1();
        VdcMunService objVdcMunService=new VdcMunService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["officeId"] = int.Parse(Request.QueryString["officeId"]);
                Session["entryMode"] = int.Parse(Request.QueryString["entryMode"]);

                populateOfficeType();
                /*populateMinistry();*/
                populateDistrict();

                if (Session["entryMode"].ToInt32() == 1)
                {
                    populateOfficeDetails(Session["officeId"].ToInt32());
                    btnAddOffice.Text = "Update Office";
                }

                // to add child office of selected office
                if (Session["entryMode"].ToInt32() == 0)
                {
                    btnAddOffice.Text = "Add Office";
                }
            }
            

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        private void populateOfficeDetails(int i)
        {
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOffice();
            Session["dtPopulateOfficeDetails"]= objWebService.PopulateOfficeDetails(i);
            DataTable dtPopulateOfficeDetails = (DataTable) Session["dtPopulateOfficeDetails"];
            if (dtPopulateOfficeDetails != null && dtPopulateOfficeDetails.Rows.Count > 0)
            {
                txtOfficeEnglishName.Text = dtPopulateOfficeDetails.Rows[0]["OFFICE_ENG_NAME"].ToString();
                txtOfficeNepaliName.Text = dtPopulateOfficeDetails.Rows[0]["OfFICE_NEP_NAME"].ToString();
                ddlOfficeType.SelectedValue = dtPopulateOfficeDetails.Rows[0]["OFFICE_TYPE_ID"].ToString();
                /*ddlMinistry.SelectedValue = dtPopulateOfficeDetails.Rows[0]["MINISTRY_ID"].ToString();*/
                ddlDistrict.SelectedValue = dtPopulateOfficeDetails.Rows[0]["DISTRICT_ID"].ToString();
                PopulateVdcMunByDisId(ddlDistrict.SelectedValue.ToInt32());
                ddlVdcMun.SelectedValue = dtPopulateOfficeDetails.Rows[0]["VDC_MUN_ID"].ToString();
                if (dtPopulateOfficeDetails.Rows[0]["is_enable"].ToString() == "1")
                {
                    chkIsEnable.Checked = true;
                }
                else
                {
                    chkIsEnable.Checked = false;
                }
            }

        }

        private void populateDistrict()
        {
            DataTable dt = null;
            objService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            dt = objService.populateDistrict(Session["LanguageSetting"].ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlDistrict.DataSource = dt;
                ddlDistrict.DataValueField = "DISTRICT_ID";
                ddlDistrict.DataTextField = "DISTRICT_NAME";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--जिल्ला छान्नुहोस्--");
            }
        }

       /* private void populateMinistry()
        {
            DataTable dt = null;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            dt = objWebService.PopulateAllMinistries();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlMinistry.DataSource = dt;
                ddlMinistry.DataValueField = "MINISTRY_ID";
                ddlMinistry.DataTextField = "MINISTRY_NEP_NAME";
                ddlMinistry.DataBind();
                ddlMinistry.Items.Insert(0, "--मन्त्रालय छान्नुहोस्--");
            }
        }*/



        private void populateOfficeType()
        {
            DataTable dt = null;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOffice();
            dt = objWebService.populateOfficeType();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlOfficeType.DataSource = dt;
                ddlOfficeType.DataTextField = "OFFICE_TYPE_NAME";
                ddlOfficeType.DataValueField = "OFFICE_TYPE_ID";
                ddlOfficeType.DataBind();
                ddlOfficeType.Items.Insert(0, "--कार्यालय प्रकार छान्नुहोस्--");
            }
        }

        protected void btnAddOffice_Click(object sender, EventArgs e)
        {
            objComOffice.officeEnglishName = txtOfficeEnglishName.Text;
            objComOffice.officeNepaliName = txtOfficeNepaliName.Text;
            if(Session["entryMode"].ToInt32()==0) // to add new
            {
                objComOffice.officeParentId = Session["officeId"].ToInt32();
            }
            else //to edit existing
            {
                DataTable dtPopulateOfficeDetails = (DataTable)Session["dtPopulateOfficeDetails"];
                objComOffice.officeParentId = dtPopulateOfficeDetails.Rows[0]["PARENT_OFFICE_ID"].ToInt16();
            }
            objComOffice.officeTypeId = ddlOfficeType.SelectedValue.ToInt16();
            /*objComOffice.ministryId = ddlMinistry.SelectedValue.ToInt16();*/
            objComOffice.vdcMunId = ddlVdcMun.SelectedValue.ToInt16();
            objComOffice.districtId = ddlDistrict.SelectedValue.ToInt16();
            objComOffice.isEnable = (chkIsEnable.Checked) ? 1 : 0;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOffice();
            int i = 0;
            i=objWebService.AddOffice(objComOffice,Session["entryMode"].ToInt32(),Session["officeId"].ToInt32());
            if(i>0)
            {
                Response.Write("<script>alert('Office added successfully!')</script>");
                Response.Redirect(Constants.ConstantAppPath + "/Modules/OfficeManagement/OfficeList.aspx", false);
            }
            else
            {
                Response.Write("<script>alert('Office addition failed!')</script>");
            }
            

        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateVdcMunByDisId(ddlDistrict.SelectedValue.ToInt32());

        }
        public void PopulateVdcMunByDisId(int disId)
        {
            DataTable dt = null;
            objVdcMunService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationVdcMun();
            dt = objVdcMunService.populateVdcMun(ddlDistrict.SelectedValue.ToInt32());
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlVdcMun.DataSource = dt;
                ddlVdcMun.DataValueField = "VDC_ID";
                ddlVdcMun.DataTextField = "VDC_NEP_NAME";
                ddlVdcMun.DataBind();
                ddlVdcMun.Items.Insert(0, "--गाविस/न.पा. छान्नुहोस्--");
            }
        }
    }
}