using System;
using System.Data;
using MISUI.ServiceMenuOffice;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.DirectoryManagement
{
    public partial class AddMinistry : Base
    {

        public static int ministryId = 0;
        public static DataTable dtPopulateMinistryDetails = null;

        ComMinistry objComMinistry = new ComMinistry();
       

        Service1 objWebService = new Service1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                if (objQueryString != null)
                {
                    if (objQueryString["ministryId"] != null)
                    {
                        ministryId = int.Parse(objQueryString["ministryId"]);

                    }
                }
               
               if (ministryId == 0)// add ministry
                {
                    btnAddMinistry.Text = "Add Ministry";
                    
                }

                // to edit ministry
               else
                {
                    populateMinistryDetails(ministryId);
                    btnAddMinistry.Text = "Update Ministry";
                }
            }
        }

        private void populateMinistryDetails(int ministryId)
        {
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            dtPopulateMinistryDetails = objWebService.PopulateMinistryDetails(ministryId);
            if (dtPopulateMinistryDetails != null && dtPopulateMinistryDetails.Rows.Count > 0)
            {

                txtMinistryEnglishName.Text = dtPopulateMinistryDetails.Rows[0]["MINISTRY_ENG_NAME"].ToString();
                txtMinistryNepaliName.Text = dtPopulateMinistryDetails.Rows[0]["MINISTRY_NEP_NAME"].ToString();
                txtCode.Text = dtPopulateMinistryDetails.Rows[0]["MINISTRY_CODE"].ToString();
            }
        }

        protected void btnAddMinistry_Click(object sender, EventArgs e)
        {
            int i = 0;
            objComMinistry.ministryEnglishName = txtMinistryEnglishName.Text;
            objComMinistry.ministryNepaliName = txtMinistryNepaliName.Text;
            objComMinistry.ministryCode = txtCode.Text;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
           i= objWebService.AddMinistry(objComMinistry,ministryId);
            if(i>0)
            {
                Response.Write("<script>alert('Ministry added successfully!')</script>");
                Response.Redirect(Constants.ConstantAppPath+ "/Modules/DirectoryManagement/MinistryList.aspx");
            }
            else
            {
                Response.Write("<script>alert('Ministry addition failed!')</script>");
            }

        }
    }
}