using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceLogin;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;

namespace MISUI
{
    public partial class Login : System.Web.UI.Page
    {
        private LoginService objWebService = null;
        private ComLogin objComLogin = null;
        //public static DataTable dtFiscalYear = null;
        //private static DataTable dtParentOfficeTable = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkDownloadFile.HRef = Constants.ConstantAppPath + "/UserManual/UserManual.pdf";
            if(!IsPostBack)
            {
                PopulateFiscalYear();
            }
        }

        private void PopulateFiscalYear()
        {
            objComLogin=new ComLogin();
            objComLogin.Lang = Session["LanguageSetting"].ToString();
            objWebService = new LoginService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationLogin();
            DataTable dtFiscalYear = objWebService.PopulateFiscalYear(objComLogin);
            Session["dtFiscalYear"] = dtFiscalYear;
            if (dtFiscalYear != null && dtFiscalYear.Rows.Count > 0)
            {
                ddlFiscalYear.DataSource = dtFiscalYear;
                ddlFiscalYear.DataTextField = "FISCAL_YEAR";
                ddlFiscalYear.DataValueField = "FISCAL_YEAR_ID";
                ddlFiscalYear.DataBind();
                ddlFiscalYear.Items.Insert(0, "-- आ.व. छान्नुहोस्--");
            }
            
        }


        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            objComLogin = new ComLogin();
            objComLogin.Lang = Session["LanguageSetting"].ToString();
            objComLogin.Username = txtUsername.Text;
            objComLogin.Password = txtPassword.Text;
            objWebService = new LoginService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationLogin();
            dt = objWebService.CheckUserExistence(objComLogin);

            if(dt!=null && dt.Rows.Count>0)
            {
                Session["username"] = dt.Rows[0]["LOGIN_ID"].ToString();
                Session["password"] = dt.Rows[0]["LOGIN_PASSWORD"].ToString();
                Session["user_id"] = dt.Rows[0]["user_id"].ToString();
                Session["office_id"] = dt.Rows[0]["office_id"].ToString();
                Session["role_id"] = dt.Rows[0]["role_id"].ToString();
                Session["mobile_no"] = dt.Rows[0]["mobile_no"].ToString();
                Session["email_id"] = dt.Rows[0]["email_id"].ToString();
                Session["type_id"] = dt.Rows[0]["TYPE_ID"].ToString();
                Session["fiscal_year_id"] = ddlFiscalYear.SelectedValue.ToInt32();
                Session["fiscal_name"] = ddlFiscalYear.SelectedItem.Text;
                Session["office_type_id"] = dt.Rows[0]["OFFICE_TYPE_ID"].ToString();
                Session["office_name"] = GetOfficeName(Session["office_id"].ToInt32());
                ///// ministry_id is assigned 0 for NPC user
                if (Session["office_id"].ToInt32()!=2)// NPC office
                {
                    int pId = Session["office_id"].ToInt32();
                    while (pId != 2)
                    {
                        pId = GetMinistryIdOfUser(pId);
                    }
                    DataTable dtParentOfficeTable = (DataTable)Session["dtParentOfficeTable"];
                    int ministryId = dtParentOfficeTable.Rows[0]["OFFICE_ID"].ToInt32();
                    Session["ministry_id"] = ministryId;
                }
                else
                {
                    Session["ministry_id"] = 0;
                    
                }
                Response.Redirect(Constants.ConstantAppPath+"/Home.aspx");

            }
            else
            {
                lblMsg.Text = "Error! Invalid username or password";
            }
        }

        //protected void btnDownloadFile_Click(object sender, ImageClickEventArgs e)
        //{
        //    string dwldUrl = Constants.ConstantAppPath + "/UserManual/UserManual.pdf";
        //    Response.ContentType = "application/pdf";
        //    Response.AppendHeader("Content-Disposition","attachment; filename=UserManual.pdf");
        //    Response.TransmitFile(Constants.ConstantAppPath + "/UserManual/UserManual.pdf");
        //    Response.End();
        //}

        private string GetOfficeName(int officeId)
        {
            objWebService = new LoginService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationLogin();
            DataTable dtOffice = objWebService.GetParentOfficeId(officeId);
            string officeName = dtOffice.Rows[0]["OFFICE_NEP_NAME"].ToString();
            return officeName;
        }

        private int GetMinistryIdOfUser(int officeId)
        {
           // int ministryId = officeId;
           objWebService = new LoginService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationLogin();
            DataTable dtParentOfficeTable=objWebService.GetParentOfficeId(officeId);
            Session["dtParentOfficeTable"] = dtParentOfficeTable;
            int pId = dtParentOfficeTable.Rows[0]["PARENT_OFFICE_ID"].ToInt32();
           /* while(pId!=2)
            {
                pId=GetMinistryIdOfUser(pId);
                break;
            }
           
            ministryId = dt.Rows[0]["OFFICE_ID"].ToInt32();*/
            return pId;
        }
    }
}