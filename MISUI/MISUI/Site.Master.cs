using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;

namespace MISUI
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect(Constants.ConstantAppPath + "/Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Session["username"]!=null)
                {
                    lblUsername.Text = Session["username"].ToString();
                    lblOfficeName.Text = Session["office_name"].ToString();
                    lblSelectedFiscalYear.Text = Session["fiscal_name"].ToString();
                }
                else
                {
                   /* lblUsername.Text = "Welcome";*/
                    Response.Redirect(Constants.ConstantAppPath+ "/Login.aspx");
                }
                LanguageHelper.GetLanguageList();
                //Session["KbdType"] = "Romanized";
            }
            lnkEnglish.Visible = true;
            lnkTraditional.Visible = true;
            lnk.Visible = true;
            if (Session["KbdType"] != null)
            {
                if (Session["KbdType"].ToString() == "Romanized")
                {

                    lnk.Visible = false;
                }
                else
                    if (Session["KbdType"].ToString() == "Traditional")
                    {

                        lnkTraditional.Visible = false;

                    }
                    else
                    {
                        lnkEnglish.Visible = false;
                    }
            }
            else
            {
                Session["KbdType"] = "Traditional";
            }

            //  admin100.HRef = Constants.ConstantAppPath + "Modules/OfficeManagement/OfficeList.aspx";
        }

        protected void imgNepal_Click(object sender, ImageClickEventArgs e)
        {
            Session["LanguageSetting"] = "Nepali";
            Response.Redirect(Request.RawUrl);


        }


        protected void imgUK_Click(object sender, ImageClickEventArgs e)
        {
            Session["LanguageSetting"] = "English";
            Response.Redirect(Request.RawUrl);
        }


        protected void ImgHome_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Constants.ConstantAppPath + "/Home.aspx");
        }

        protected void lbtnLogout_OnClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect(Constants.ConstantAppPath + "/Login.aspx");
        }


        protected void lnk_Click(object sender, EventArgs e)
        {
            lnkEnglish.Visible = true;
            lnkTraditional.Visible = true;
            lnk.Visible = true;
            lnk.Visible = false;

            Session["KbdType"] = "Romanized";
        }

        protected void lnkTraditional_Click(object sender, EventArgs e)
        {
            lnkEnglish.Visible = true;
            lnkTraditional.Visible = true;
            lnk.Visible = true;
            lnkTraditional.Visible = false;

            Session["KbdType"] = "Traditional";
        }

        protected void lnkEnglish_Click(object sender, EventArgs e)
        {
            lnkEnglish.Visible = true;
            lnkTraditional.Visible = true;
            lnk.Visible = true;
            lnkEnglish.Visible = false;

            Session["KbdType"] = "English";
        }

        protected void lbtnChangePassword_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Constants.ConstantAppPath + "/ChangePassword.aspx");
        }

        protected void lnkBtnFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.ConstantAppPath + "/Feedback.aspx");
        }
    }
}
