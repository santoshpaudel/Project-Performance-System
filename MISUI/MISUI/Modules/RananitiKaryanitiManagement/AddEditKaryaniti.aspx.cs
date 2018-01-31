using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceProject;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.RananitiKaryanitiManagement
{
    public partial class AddEditKaryaniti : Base
    {
        private ProjectService wbs = null;
        private ComProjectBO objProjectBO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAllRananiti();

                if (Request.QueryString["enc"] != null)
                {

                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["id"] != null)
                        {
                            Session["karyanitiId"] = objQueryString["id"].ToInt32();
                        }
                        if (Session["karyanitiId"].ToInt32() > 0)
                        {
                            PopulateKaryanitiDetails(Session["karyanitiId"].ToInt32());
                        }
                    }
                }
            }
        }

        private void PopulateKaryanitiDetails(int karyanitiId)
        {
            ProjectService objWebService = new ProjectService();
            DataTable dtKaryanitiDetails = null;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtKaryanitiDetails = objWebService.PopulateKaryanitiDetails(karyanitiId);
            if (dtKaryanitiDetails != null && dtKaryanitiDetails.Rows.Count > 0)
            {
                ddlRananiti.SelectedValue = dtKaryanitiDetails.Rows[0]["RANANITI_ID"].ToString();
                txtKaryanitiEnglishName.Text = dtKaryanitiDetails.Rows[0]["KARYANITI_ENG_NAME"].ToString();
                txtKaryanitiNepaliName.Text = dtKaryanitiDetails.Rows[0]["KARYANITI_NEP_NAME"].ToString();
            }
        }

        private void PopulateAllRananiti()
        {
            DataTable dtRananiti = null;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtRananiti = wbs.PopulateAllRananiti(Session["LanguageSetting"].ToString());
            if (dtRananiti != null && dtRananiti.Rows.Count > 0)
            {
                ddlRananiti.DataSource = dtRananiti;
                ddlRananiti.DataValueField = "RANANITI_ID";
                ddlRananiti.DataTextField = "RANANITI_NAME";
                ddlRananiti.DataBind();
                ddlRananiti.Items.Insert(0, "--छान्नुहोस्--");
            }
        }

        protected void btnAddKaryaniti_Click(object sender, EventArgs e)
        {
            objProjectBO = new ComProjectBO();
            if (Session["karyanitiId"].ToInt32() > 0)
            {
                objProjectBO.Mode = "U";
                objProjectBO.KaryanitiId = Session["karyanitiId"].ToInt32();
            }
            else
            {
                objProjectBO.Mode = "I";
            }
            objProjectBO.RananitiId = ddlRananiti.SelectedValue.ToInt32();
            objProjectBO.KaryanitiEngName = txtKaryanitiEnglishName.Text;
            objProjectBO.KaryanitiNepName = txtKaryanitiNepaliName.Text;
            int i = 0;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            i = wbs.AddEditKaryaniti(objProjectBO);
            if (i > 0)
            {
                Response.Write("<script>alert('Karyaniti is inserted/updated successfully!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Karyaniti insertion/updation failed!')</script>");
            }
        }
    }
}