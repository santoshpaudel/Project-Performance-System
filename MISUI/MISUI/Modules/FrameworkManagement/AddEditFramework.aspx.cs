using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceFrameworkMgmt;
using MISUI.ServiceLogin;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.FrameworkManagement
{
    public partial class AddEditFramework : Base
    {
        private ComLogin objComLogin = null;
        private LoginService objWebService = null;
        private DataTable dtFiscalYear = null;
        private FrameworkManagementService objFramework = null;
        private FrameworkBO objFrameworkBO = null;
       // private static int frameworkId = 0;
        DataTable dtFramework = null;
            

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateFiscalYear();
                if (Request.QueryString["enc"] != null)
                {

                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["frameworkId"] != null)
                        {
                            Session["frameworkId"] = objQueryString["frameworkId"].ToInt32();
                        }
                    }

                }
                if (Session["frameworkId"].ToInt32() > 0)
                {
                    PopulateFrameworkDetails(Session["frameworkId"].ToInt32());
                }
            }
        }

        private void PopulateFrameworkDetails(int frameworkId)
        {
            objFrameworkBO = new FrameworkBO();
            objFrameworkBO.FrameworkId = frameworkId;
            objFramework = new FrameworkManagementService();
            objFramework.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationFramework();
            dtFramework = objFramework.PopulateFrameworkDetails(objFrameworkBO);
            if(dtFramework!=null && dtFramework.Rows.Count>0)
            {
                ddlBaseYear.SelectedValue = dtFramework.Rows[0]["BASE_YEAR_ID"].ToString();
                ddlFirstYear.SelectedValue = dtFramework.Rows[0]["FIRST_YEAR_ID"].ToString();
                ddlSecondYear.SelectedValue = dtFramework.Rows[0]["SECOND_YEAR_ID"].ToString();
                ddlThirdYear.SelectedValue = dtFramework.Rows[0]["THIRD_YEAR_ID"].ToString();
            }
        }

        private void PopulateFiscalYear()
        {
            objComLogin = new ComLogin();
            objComLogin.Lang = Session["LanguageSetting"].ToString();
            objWebService = new LoginService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationLogin();
            dtFiscalYear = objWebService.PopulateFiscalYear(objComLogin);
            if (dtFiscalYear != null && dtFiscalYear.Rows.Count > 0)
            {
                ddlBaseYear.DataSource = dtFiscalYear;
                ddlBaseYear.DataTextField = "FISCAL_YEAR";
                ddlBaseYear.DataValueField = "FISCAL_YEAR_ID";
                ddlBaseYear.DataBind();
                ddlBaseYear.Items.Insert(0, "-- आ.व. छान्नुहोस्--");

                ddlFirstYear.DataSource = dtFiscalYear;
                ddlFirstYear.DataTextField = "FISCAL_YEAR";
                ddlFirstYear.DataValueField = "FISCAL_YEAR_ID";
                ddlFirstYear.DataBind();
                ddlFirstYear.Items.Insert(0, "-- आ.व. छान्नुहोस्--");

                ddlSecondYear.DataSource = dtFiscalYear;
                ddlSecondYear.DataTextField = "FISCAL_YEAR";
                ddlSecondYear.DataValueField = "FISCAL_YEAR_ID";
                ddlSecondYear.DataBind();
                ddlSecondYear.Items.Insert(0, "-- आ.व. छान्नुहोस्--");

                ddlThirdYear.DataSource = dtFiscalYear;
                ddlThirdYear.DataTextField = "FISCAL_YEAR";
                ddlThirdYear.DataValueField = "FISCAL_YEAR_ID";
                ddlThirdYear.DataBind();
                ddlThirdYear.Items.Insert(0, "-- आ.व. छान्नुहोस्--");
            }
        }

        protected void btnAddFramework_Click(object sender, EventArgs e)
        {
           objFramework=new FrameworkManagementService();
           objFrameworkBO =new FrameworkBO();
           objFrameworkBO.FrameworkId = Session["frameworkId"].ToInt32();
            objFrameworkBO.FrameworkEngName = txtFrameworkEngName.Text;
            objFrameworkBO.FrameworkNepName = txtFrameworkNepName.Text;
            objFrameworkBO.BaseYearId = ddlBaseYear.SelectedValue.ToInt32();
            objFrameworkBO.FirstYearId = ddlFirstYear.SelectedValue.ToInt32();
            objFrameworkBO.SecondYearId = ddlSecondYear.SelectedValue.ToInt32();
            objFrameworkBO.ThirdYearId = ddlThirdYear.SelectedValue.ToInt32();
            if (Session["frameworkId"].ToInt32() > 0)
            {
                objFrameworkBO.Mode = "U";
            }
            else
            {
                objFrameworkBO.Mode = "I";
            }
            
            objFrameworkBO.IsEnable = 1;
            objFrameworkBO.IsLocked = 0;
            objFramework.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationFramework();
            Int32 i = 0;
            i = objFramework.AddEditFramework(objFrameworkBO);
            if(i>0)
            {
                Response.Write("<script>alert('Framework added successfully!')</script>");
                Response.Redirect(Constants.ConstantAppPath + "/Modules/FrameworkManagement/AddEditFramework.aspx");
            }
            else
            {
                Response.Write("<script>alert('Framework addition failed!')</script>");
            }
        }
    }
}