using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUICOMMON.HelperClass;

namespace MISUI.Modules.ProjectManagement
{
    public partial class ProjectPratifalVerificationList : Base
    {
        private Service1 objService1 = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlMinistry.Enabled = true;
            PopulateMinistries();
            if (Session["ministry_id"].ToInt32() > 0)
            {
                ddlMinistry.Enabled = false;
                ddlMinistry.SelectedValue = Session["ministry_id"].ToString();
            }
        }

        private void PopulateMinistries()
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            Session["dtMinistries"] = objService1.PopulateMinistries();
            DataTable dtMinistries = (DataTable)Session["dtMinistries"];
            if (dtMinistries != null && dtMinistries.Rows.Count > 0)
            {
                ddlMinistry.DataSource = dtMinistries;
                if (Session["LanguageSetting"].ToString() == "Nepali")
                {
                    ddlMinistry.DataTextField = "OFFICE_NEP_NAME";
                }
                else
                {
                    ddlMinistry.DataTextField = "OFFICE_ENG_NAME";

                }

                ddlMinistry.DataValueField = "OFFICE_ID";
                ddlMinistry.DataBind();
                ddlMinistry.Items.Insert(0, "--छान्नुहोस्--");
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            lvProject.DataSource = null;
            lvProject.DataBind();
            DataTable dtProjects = null;
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            if (Session["office_type_id"].ToInt32() == 4 || Session["office_type_id"].ToInt32() == 5 ||
                Session["office_type_id"].ToInt32() == 6)
            {
                dtProjects = objService1.PopulatePPByUserId(Session["LanguageSetting"].ToString(),
                        Session["user_id"].ToInt32(), ddlTrimester.SelectedValue.ToInt32(), Session["fiscal_year_id"].ToInt32());
            }
            //for npc users and others; 
            else
            {
                dtProjects = objService1.PopulatePPByMinistryId(Session["LanguageSetting"].ToString(),
                        ddlMinistry.SelectedValue.ToInt32(), ddlTrimester.SelectedValue.ToInt32(), Session["fiscal_year_id"].ToInt32());
            }

            if (dtProjects != null && dtProjects.Rows.Count > 0)
            {
                lvProject.DataSource = dtProjects;
                lvProject.DataBind();
            }
        }

        protected void lvProject_LayoutCreated(object sender, EventArgs e)
        {
            Label lblProjectName = (Label)lvProject.FindControl("lblProjectName");
            lblProjectName.Text = GetLabel("Project Name");
            Label lblVerificationLevel1 = (Label)lvProject.FindControl("lblVerificationLevel1");
            lblVerificationLevel1.Text = GetLabel("Verification Level 1");
            Label lblVerificationLevel2 = (Label)lvProject.FindControl("lblVerificationLevel2");
            lblVerificationLevel2.Text = GetLabel("Verification Level 2");
            Label lblVerificationLevel3 = (Label)lvProject.FindControl("lblVerificationLevel3");
            lblVerificationLevel3.Text = GetLabel("Verification Level 3");
            Label lblVerificationLevel4 = (Label)lvProject.FindControl("lblVerificationLevel4");
            lblVerificationLevel4.Text = GetLabel("Verification Level 4");
        }


    }
}