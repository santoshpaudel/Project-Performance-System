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
    public partial class ReportVerificationList : Base
    {
        private Service1 objService1 = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMinistry.Enabled = true;
                PopulateMinistries();
                if (Session["ministry_id"].ToInt32() > 0)
                {
                    ddlMinistry.Enabled = false;
                    ddlMinistry.SelectedValue = Session["ministry_id"].ToString();
                   // PopulateBudgetHead();
                }
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

        /*protected void ddlMinistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBudghead.Items.Clear();
            ddlProject.Items.Clear();
            PopulateBudgetHead();
        }

        private void PopulateBudgetHead()
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            if (Session["office_type_id"].ToInt32() == 4 || Session["office_type_id"].ToInt32() == 5 ||
                Session["office_type_id"].ToInt32() == 6)
            {
                Session["dtPopulateBudgetHead"] =
                    objService1.PopulateAllBudgetHeadsByUserId(Session["LanguageSetting"].ToString(),
                        Session["user_id"].ToInt32());
            }
            //for npc users and others; 
            else
            {
                Session["dtPopulateBudgetHead"] =
                    objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(),
                        ddlMinistry.SelectedValue.ToInt32());
            }
            DataTable dtPopulateBudgetHead = (DataTable)Session["dtPopulateBudgetHead"];
            if (dtPopulateBudgetHead != null && dtPopulateBudgetHead.Rows.Count > 0)
            {
                ddlBudghead.DataSource = dtPopulateBudgetHead;
                ddlBudghead.DataTextField = "BUDGET_HEAD_NAME";
                ddlBudghead.DataValueField = "BUDGET_HEAD_ID";
                ddlBudghead.DataBind();
                ddlBudghead.Items.Insert(0, "--छान्नुहोस्--");
            }
        }

        protected void ddlBudghead_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlProject.Items.Clear();
            PopulateProjectsByBudgetHead(ddlBudghead.SelectedValue.ToInt32());
        }

        private void PopulateProjectsByBudgetHead(int budgHeadId)
        {
            objProjectBO = new ComProjectBO();
            objProjectBO.BudgetHeadId = budgHeadId;
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objProjectBO.OfficeId = Session["office_id"].ToInt32();
            objProjectBO.MinistryId = Session["ministry_id"].ToInt32();
            objProjectBO.SelectedMinistryId = ddlMinistry.SelectedValue.ToInt32();
            objProjectBO.Lang = Session["LanguageSetting"].ToString();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            Session["dtProjectDetail"] = wbs.PopulateProjectListForReport(objProjectBO);
            DataTable dtProjectDetail = (DataTable)Session["dtProjectDetail"];
            if (dtProjectDetail != null && dtProjectDetail.Rows.Count > 0)
            {
                ddlProject.DataSource = dtProjectDetail;
                ddlProject.DataTextField = "PROJECT_NAME";
                ddlProject.DataValueField = "PROJECT_ID";
                ddlProject.DataBind();
                ddlProject.Items.Insert(0, "--छान्नुहोस्--");
            }

        }*/


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
                /*Session["dtPopulateBudgetHead"] =
                    objService1.PopulateAllBudgetHeadsByUserId(Session["LanguageSetting"].ToString(),
                        Session["user_id"].ToInt32());*/
                dtProjects = objService1.PopulateAllProjectsByUserId(Session["LanguageSetting"].ToString(),
                        Session["user_id"].ToInt32(), ddlTrimester.SelectedValue.ToInt32(), Session["fiscal_year_id"].ToInt32());
            }
            //for npc users and others; 
            else
            {
                /*Session["dtPopulateBudgetHead"] =
                    objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(),
                        ddlMinistry.SelectedValue.ToInt32());*/
                dtProjects = objService1.PopulateAllProjectsByMinistryId(Session["LanguageSetting"].ToString(),
                        ddlMinistry.SelectedValue.ToInt32(), ddlTrimester.SelectedValue.ToInt32(), Session["fiscal_year_id"].ToInt32());
            }

            if (dtProjects != null && dtProjects.Rows.Count > 0)
            {
                lvProject.DataSource = dtProjects;
                lvProject.DataBind();
            }
            
        }
    }
}