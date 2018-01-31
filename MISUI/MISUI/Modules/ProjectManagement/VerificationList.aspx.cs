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
    public partial class VerificationList : Base
    {
        private Service1 objService1 = null;
        private DataTable dtPopulateBudgetHead = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        private DataTable dtProjectDetail = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBudgetHead();
                ddlMinistry.Enabled = true;
                PopulateMinistries();

                if (Session["ministry_id"].ToInt32() > 0)
                {
                    ddlMinistry.Enabled = false;
                    ddlMinistry.SelectedValue = Session["ministry_id"].ToString();
                }
                else
                {
                    ddlMinistry.SelectedValue = "4"; // default MoFALD
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

        protected void ddlMinistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateBudgetHead();
        }

        private void PopulateBudgetHead()
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            // for project/program admin and data entry
            if (Session["role_id"].ToInt32() == 4 || Session["role_id"].ToInt32() == 6)
            {
                /*dtPopulateBudgetHead =
                    objService1.PopulateAllBudgetHeadsByOfficeId(Session["LanguageSetting"].ToString(),
                        Session["office_id"].ToInt32());*/
                dtPopulateBudgetHead =
                    objService1.PopulateAllBudgetHeadsByUserId(Session["LanguageSetting"].ToString(),
                        Session["user_id"].ToInt32());
            }
            //for npc users and others; 
            else
            {
                int ministryId = ddlMinistry.SelectedValue.ToInt32();
                dtPopulateBudgetHead =
                    objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(),
                        ministryId);
            }

            if (dtPopulateBudgetHead != null && dtPopulateBudgetHead.Rows.Count > 0)
            {
                ddlBudgetHead.DataSource = dtPopulateBudgetHead;
                ddlBudgetHead.DataTextField = "BUDGET_HEAD_NAME";
                ddlBudgetHead.DataValueField = "BUDGET_HEAD_ID";
                ddlBudgetHead.DataBind();
                ddlBudgetHead.Items.Insert(0, "--छान्नुहोस्--");
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


        protected void ddlBudgetHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProjects(ddlBudgetHead.SelectedValue.ToInt32());
        }
       
        private void PopulateProjects(int budgHeadId)
        {
            lvProject.DataSource = null;
            lvProject.DataBind();

            objProjectBO = new ComProjectBO();
            objProjectBO.BudgetHeadId = budgHeadId;
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objProjectBO.OfficeId = Session["office_id"].ToInt32();
            objProjectBO.MinistryId = Session["ministry_id"].ToInt32();
            objProjectBO.Lang = Session["LanguageSetting"].ToString();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtProjectDetail = wbs.PopulateProjectList(objProjectBO);
            if (dtProjectDetail != null && dtProjectDetail.Rows.Count > 0)
            {
                lvProject.DataSource = dtProjectDetail;
                lvProject.DataBind();
            }
        }
    }
}