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
    public partial class ProjectProblems : System.Web.UI.Page
    {
        private Service1 objService1 = null;
        private DataTable dtPopulateBudgetHead = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        private DataTable dtProjectDetail = null;
        DataTable dtA = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateBudgetHead();
                btnAddProblems.Visible = false;
                btnSaveProblem.Visible = false;
            }
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
                dtPopulateBudgetHead =
                    objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(),
                        Session["ministry_id"].ToInt32());
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

        protected void ddlBudgetHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptProblems.DataSource = null;
            rptProblems.DataBind();
            DataTable dtEmpty=new DataTable();
            ddlProjects.DataSource = dtEmpty;
            ddlProjects.DataBind();
            btnAddProblems.Visible = false;
            btnSaveProblem.Visible = false;
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
                ddlProjects.DataSource = dtProjectDetail;
                ddlProjects.DataTextField = "PROJECT_NAME";
                ddlProjects.DataValueField = "PROJECT_ID";
                ddlProjects.DataBind();
                ddlProjects.Items.Insert(0,"--आयोजना छान्नुहोस्--");
            }
        }

        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptProblems.DataSource = null;
            rptProblems.DataBind();
            ddlProjects.DataSource = null;
            ddlProjects.DataBind();
            btnAddProblems.Visible = true;
            btnSaveProblem.Visible = false;
            PopulateDataForRepeater();
        }

        private void PopulateDataForRepeater()
        {
            DataTable dt = null;
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = ddlProjects.SelectedValue.ToInt32();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dt=wbs.PopulateProjectProblems(objProjectBO);
            dtA = dt;
            if(dt!=null && dt.Rows.Count>0)
            {
                rptProblems.DataSource = dt;
                rptProblems.DataBind();
                btnSaveProblem.Visible = true;
            }
        }

        protected void rptProblems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList ddlChaumasik = new DropDownList();
                ddlChaumasik = (DropDownList)e.Item.FindControl("ddlChaumasik");
                ddlChaumasik.SelectedValue = dtA.Rows[e.Item.ItemIndex]["CHAUMASIK_ID"].ToString();

                CheckBox chkNdac=new CheckBox();
                chkNdac = (CheckBox)e.Item.FindControl("chkNdac");
                if(dtA.Rows[e.Item.ItemIndex]["NDAC"].ToString()=="1")
                {
                    chkNdac.Checked = true;
                }
                else
                {
                    chkNdac.Checked = false;
                    
                }

            }
        }

        protected void btnSaveProblem_Click(object sender, EventArgs e)
        {
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = ddlProjects.SelectedValue.ToInt32();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            wbs.ClearProjectProblems(objProjectBO);

            DropDownList ddlChaumasik = new DropDownList();
            TextBox txtProblems = new TextBox();
            TextBox txtReasons = new TextBox();
            TextBox txtEfforts = new TextBox();
            TextBox txtSuggestions = new TextBox();
            CheckBox chkNdac = new CheckBox();

            foreach (RepeaterItem rptItem in rptProblems.Items)
            {
                int k = 0;
                ddlChaumasik = (DropDownList)rptItem.FindControl("ddlChaumasik");
                txtProblems = (TextBox)rptItem.FindControl("txtProblems");
                txtReasons = (TextBox)rptItem.FindControl("txtReasons");
                txtEfforts = (TextBox)rptItem.FindControl("txtEfforts");
                txtSuggestions = (TextBox)rptItem.FindControl("txtSuggestions");
                chkNdac = (CheckBox) rptItem.FindControl("chkNdac");
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = ddlProjects.SelectedValue.ToInt32();
                objProjectBO.ChaumasikId = ddlChaumasik.SelectedValue.ToInt32();
                objProjectBO.Problems = txtProblems.Text;
                objProjectBO.Reasons = txtReasons.Text;
                objProjectBO.Efforts = txtEfforts.Text;
                objProjectBO.Suggestions = txtSuggestions.Text;
                if(chkNdac.Checked==true)
                {
                    objProjectBO.Ndac = 1;
                }
                else
                {
                    objProjectBO.Ndac = 0;
                }

                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                k = wbs.SaveProjectProblems(objProjectBO);

            }
        }

        protected void btnAddProblems_Click(object sender, EventArgs e)
        {
            dtA.Clear();
            dtA.Columns.Add("CHAUMASIK_ID");
            dtA.Columns.Add("PROBLEMS");
            dtA.Columns.Add("REASONS");
            dtA.Columns.Add("EFFORTS");
            dtA.Columns.Add("SUGGESTIONS");
            dtA.Columns.Add("NDAC");

            btnSaveProblem.Visible = true;

            DropDownList ddlChaumasik = new DropDownList();
            TextBox txtProblems = new TextBox();
            TextBox txtReasons = new TextBox();
            TextBox txtEfforts = new TextBox();
            TextBox txtSuggestions = new TextBox();
            CheckBox chkNdac = new CheckBox();

            foreach (RepeaterItem rptItem in rptProblems.Items)
            {
                DataRow drA = dtA.NewRow();
                ddlChaumasik = (DropDownList) rptItem.FindControl("ddlChaumasik");
                txtProblems = (TextBox)rptItem.FindControl("txtProblems");
                txtReasons = (TextBox)rptItem.FindControl("txtReasons");
                txtEfforts = (TextBox)rptItem.FindControl("txtEfforts");
                txtSuggestions = (TextBox)rptItem.FindControl("txtSuggestions");
                chkNdac = (CheckBox) rptItem.FindControl("chkNdac");
                drA["CHAUMASIK_ID"] = ddlChaumasik.SelectedValue.ToInt32();
                drA["PROBLEMS"] = txtProblems.Text;
                drA["REASONS"] = txtReasons.Text;
                drA["EFFORTS"] = txtEfforts.Text;
                drA["SUGGESTIONS"] = txtSuggestions.Text;
                if (chkNdac.Checked == true)
                    drA["NDAC"] = 1;
                else
                {
                    drA["NDAC"] = 0;
                }
                dtA.Rows.Add(drA);
            }

            DataRow drB = dtA.NewRow();
            drB["CHAUMASIK_ID"] = 0;
            drB["PROBLEMS"] = "";
            drB["REASONS"] = "";
            drB["EFFORTS"] = "";
            drB["SUGGESTIONS"] = "";
            drB["NDAC"] = 0;
            dtA.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptProblems.DataSource = db;
            rptProblems.DataBind();

            rptProblems.DataSource = dtA;
            rptProblems.DataBind();
        }
    }
}