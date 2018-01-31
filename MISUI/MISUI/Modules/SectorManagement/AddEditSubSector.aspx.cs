using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceSectorMgmt;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;
using MISUICOMMON.HelperClass;

namespace MISUI.Modules.SectorManagement
{
    public partial class AddEditSubSector : Base
    {
        //public static int subSectorId = 0;
        //public static DataTable dtPopulateSubSector = null;
        //public static DataTable dtPopulateSector = null;
        private ComSubSector objComSubSector = null;

        private SectorService objWebService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
        
          if (!IsPostBack)
            {
                populateSectors(objComSubSector);
                SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                if (objQueryString != null)
                {
                    if (objQueryString["id"] != null)
                    {
                        Session["subSectorId"] = int.Parse(objQueryString["id"]);

                    }
                }

                if (Session["subSectorId"].ToInt32() == 0)// add sub sector
                {
                    btnAddSubsector.Text = "Add Sub Sector";

                }

                 // to edit budget head
                else
                {
                    populateSubSector(Session["subSectorId"].ToInt32());
                    btnAddSubsector.Text = "Update Sub Sector";
                }
            }
        }

        private void populateSectors(ComSubSector comSubSector)
        {
            objComSubSector = new ComSubSector();
            objWebService = new SectorService();
            objComSubSector.Lang = Session["LanguageSetting"].ToString();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
            DataTable dtPopulateSector = objWebService.PopulateAllSectors(objComSubSector);
            Session["dtPopulateSector"]= dtPopulateSector;
            if(dtPopulateSector!=null && dtPopulateSector.Rows.Count>0)
            {
                ddlSector.DataSource = dtPopulateSector;
                ddlSector.DataValueField = "SECTOR_ID";
                ddlSector.DataTextField = "SECTOR_NAME";
                ddlSector.DataBind();
                ddlSector.Items.Insert(0,"--क्षेत्र छान्नुहोस्--");
            }


        }

        private void populateSubSector(int i)
        {
            objWebService = new SectorService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
            ComSubSector objComSubSector=new ComSubSector();
            objComSubSector.SubSectorId = i;
            DataTable dtPopulateSubSector = objWebService.PopulateAllSubSectors(objComSubSector);
            Session["dtPopulateSubSector"] = dtPopulateSubSector;
            if (dtPopulateSubSector != null && dtPopulateSubSector.Rows.Count > 0)
            {
                txtSubSectorEngName.Text = dtPopulateSubSector.Rows[0]["activity_sub_sector_eng_name"].ToString();
                txtSubSectorNepName.Text = dtPopulateSubSector.Rows[0]["activity_sub_sector_nep_name"].ToString();
                txtSubSectorCode.Text = dtPopulateSubSector.Rows[0]["activity_sub_sector_code"].ToString();
                ddlSector.SelectedValue = dtPopulateSubSector.Rows[0]["activity_sector_id"].ToString();
                if (Convert.ToInt16(dtPopulateSubSector.Rows[0]["ISENABLE"]) == 1)
                {
                    chkIsEnable.Checked = true;
                }
                else
                {
                    chkIsEnable.Checked = false;
                }
            }
        }



        protected void btnAddSubSector_Click(object sender, EventArgs e)
        {
            int i = 0;
            objComSubSector = new ComSubSector();
            objComSubSector.SubSectorEngName = txtSubSectorEngName.Text;
            objComSubSector.SubSectorNepName = txtSubSectorNepName.Text;
            objComSubSector.SubSectorCode = txtSubSectorCode.Text;
            objComSubSector.SectorId = ddlSector.SelectedValue.ToInt32();
            objComSubSector.SubSectorId = Session["subSectorId"].ToInt32();
            objComSubSector.Islocked = 0;
            if (chkIsEnable.Checked == true)
                objComSubSector.Isenable = 1;
            else
            {
                objComSubSector.Isenable = 0;
            }
            objComSubSector.Lang = Session["LanguageSetting"].ToString();
            if (Session["subSectorId"].ToInt32() == 0)
            {
                objComSubSector.Mode = "I";
            }
            else
            {
                objComSubSector.Mode = "U";
            }
            objWebService = new SectorService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();

            i=objWebService.AddSubSector(objComSubSector);
            if(i>0)
            {
                Response.Write("<script>alert('Sub Sector added successfully!')</script>");
                Response.Redirect(Constants.ConstantAppPath + "/Modules/SectorManagement/ListSubSector.aspx");
            }
            else
            {
                Response.Write("<script>alert('Sub Sector addition failed!')</script>");
            }

        }
    }
}