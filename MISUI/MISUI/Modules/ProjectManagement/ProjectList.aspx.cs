using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.ProjectManagement
{
    public partial class ProjectList : Base
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
                if (Session["office_id"].ToString() == "2")
                {
                    btnAddEditProject.Visible = true;
                }
                else
                {
                    btnAddEditProject.Visible = false;
                }

                
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
                PopulateBudgetHead();
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
            // for project/program admin and data entry users
            if (Session["role_id"].ToInt32() == 4||Session["role_id"].ToInt32() == 6)
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

        protected void btnAddEditProject_Click(object sender, EventArgs e)
        {
            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/ProjectManagement/AddEditProject.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        protected void lvProject_LayoutCreated(object sender, EventArgs e)
        {
            Label lblProjectName = (Label)lvProject.FindControl("lblProjectName");
            lblProjectName.Text = GetLabel("Project Name");
            Label lblStartDate = (Label)lvProject.FindControl("lblStartDate");
            lblStartDate.Text = GetLabel("Start Date");
            Label lblStatus = (Label)lvProject.FindControl("Status");
            lblStatus.Text = GetLabel("Status");
            Label action = (Label)lvProject.FindControl("lblAction");
            action.Text = GetLabel("Action");
        }

        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            int projectId = 0;
            if (e.CommandName == "edit")
            {
                projectId = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["id"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/AddEditProject.aspx" + str.EncryptedString);
            }
            else if (e.CommandName == "delete")
            {
                int i = 0;
                projectId = int.Parse(e.CommandArgument.ToString());
                objProjectBO=new ComProjectBO();
                objProjectBO.ProjectId = projectId;
                objProjectBO.Mode = "D";
                wbs=new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                i=wbs.AddEditProject(objProjectBO);
                if(i>0)
                {
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/ProjectList.aspx");    
                }
                else
                {
                    Response.Write("<script>alert('Delete failed')</script>");
                }
                
            }
            else if (e.CommandName == "lock")
            {
                int i = 0;
                projectId = int.Parse(e.CommandArgument.ToString());
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = projectId;
                objProjectBO.Mode = "L";
                wbs=new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                i = wbs.AddEditProject(objProjectBO);
                if (i > 0)
                    PopulateProjects(ddlBudgetHead.SelectedValue.ToInt32());
                    //Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/ProjectList.aspx");    
                else
                {
                    Response.Write("<script>alert('Lock failed')</script>");
                }
            }
            else if (e.CommandName == "unlock")
            {
                int i = 0;
                projectId = int.Parse(e.CommandArgument.ToString());
                objProjectBO=new ComProjectBO();
                objProjectBO.ProjectId = projectId;
                objProjectBO.Mode = "L";
                wbs=new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                i = wbs.AddEditProject(objProjectBO);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/ProjectList.aspx");    
                else
                {
                    Response.Write("<script>alert('Unlock failed')</script>");
                }
            }
            else if (e.CommandName == "verify")
            {
                int i = 0;
                string mode = string.Empty;
                projectId = int.Parse(e.CommandArgument.ToString());
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = projectId;
                if (Session["role_id"].ToInt32()==12)
                    
                    objProjectBO.Mode =mode= "V1"; //verification level 1
                else if (Session["role_id"].ToInt32() == 13)
                    objProjectBO.Mode =mode= "V2"; //verification level 2
                else if (Session["role_id"].ToInt32() == 14)
                    objProjectBO.Mode =mode= "V3"; //verification level 3
                else if (Session["role_id"].ToInt32() == 15)
                    objProjectBO.Mode = mode= "V4"; //verification level 4

                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                int check = 0;
                check=wbs.CheckLowerLevelVerification(projectId, mode);

                if (check == 1)
                {
                    wbs = new ProjectService();
                    wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                    i = wbs.AddEditProject(objProjectBO);
                    if (i > 0)
                        Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/ProjectList.aspx");
                    else
                    {
                        Response.Write("<script>alert('Verification failed')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Verification failed. Lower level verification is required.')</script>");
                }
            }
            else
            {
                
            }
        }

        protected void ddlBudgetHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProjects(ddlBudgetHead.SelectedValue.ToInt32());
            /*lvProject.DataSource = null;
            lvProject.DataBind();

            objProjectBO = new ComProjectBO();
            objProjectBO.BudgetHeadId = ddlBudgetHead.SelectedValue.ToInt32();
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objProjectBO.OfficeId = Session["office_id"].ToInt32();
            objProjectBO.Lang = Session["LanguageSetting"].ToString();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtProjectDetail = wbs.PopulateProjectList(objProjectBO);
            if (dtProjectDetail != null && dtProjectDetail.Rows.Count > 0)
            {
                lvProject.DataSource = dtProjectDetail;
                lvProject.DataBind();
            }*/
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