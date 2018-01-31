using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceLogin;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;

namespace MISUI
{
    public partial class ChangePassword : Base
    {
        private LoginService objWebService = null;
        private ComLogin objComLogin = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            objComLogin = new ComLogin();
            int i = 0;
            if (txtOldPassword.Text == Session["password"].ToString())
            {
                if (txtNewPassword.Text == txtConfirmNewPassword.Text)
                {
                    objComLogin.NewPassword = txtNewPassword.Text;
                    objComLogin.UserId = Session["user_id"].ToInt32();
                    objWebService = new LoginService();
                    objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationLogin();
                    i = objWebService.ChangePassword(objComLogin);
                    if (i > 0)
                    {
                        Session["password"] = txtNewPassword.Text;
                        Response.Write("<script>alert('पासवर्ड परिवर्तन सफल भएको छ।')</script>");
                        Response.Redirect(Constants.ConstantAppPath + "/Home.aspx");
                    }
                }
                else
                {
                    Response.Write(
                        "<script>alert('नयाँ पासवर्ड मिलेन।')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('पुरानो पासवर्ड मिलेन।')</script>");
            }
        }
    }
}