using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using MISUI.CrystalReport.ProjectTrans;
using MISUI.ServiceBarsikKaryekram;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUI.Services.Report;
using MISUICOMMON.HelperClass;

namespace MISUI.CrystalViewer.ProjectTrans
{
    public partial class ProjectPragatiViewer : Base
    {
        private ReportFactory objRptFactory = null;
        private ReportServices objRptServices = null;

        private ProjectKaryekramPragati crpt1 = new ProjectKaryekramPragati();

        private Service1 objService1 = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        private BarsikKaryekramService objBarsikService = null;

        private DataTable dtProjectDetail = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMinistry.Enabled = true;
                Session["rptProjectId"] = "0";
                PopulateMinistries();
                if (Session["ministry_id"].ToInt32() > 0)
                {
                    ddlMinistry.Enabled = false;
                    ddlMinistry.SelectedValue = Session["ministry_id"].ToString();
                    PopulateBudgetHead();

                }
            }
            if (IsPostBack)
            {
                RptViewer.ReportSource = Session["PragatiReport"];
                RptViewer.RefreshReport();
                RptViewer.DataBind();
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
            RptViewer.ReportSource = null;
            ddlBudghead.Items.Clear();
            ddlProject.Items.Clear();
            PopulateBudgetHead();
        }

        private void PopulateBudgetHead()
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            // for project/program/pariyojana users
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
            RptViewer.ReportSource = null;
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
            dtProjectDetail = wbs.PopulateProjectListForReport(objProjectBO);
            if (dtProjectDetail != null && dtProjectDetail.Rows.Count > 0)
            {
                ddlProject.DataSource = dtProjectDetail;
                ddlProject.DataTextField = "PROJECT_NAME";
                ddlProject.DataValueField = "PROJECT_ID";
                ddlProject.DataBind();
                ddlProject.Items.Insert(0, "--छान्नुहोस्--");
            }

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            int prId = ddlProject.SelectedValue.ToInt32();
            Session["rptProjectId"] = prId.ToString();
            if (Session["LanguageSetting"].ToString() == "Nepali")
            {
                LoadReport(prId.ToInt32(), crpt1);
            }
           
        }

        protected void LoadReport(int prjlId, ReportDocument repDoc)
        {

            objBarsikService = new BarsikKaryekramService();
            ProjectOutputTBarsikBO objProjectOutBarsik = new ProjectOutputTBarsikBO();
            objProjectOutBarsik.Lang = SessionHelper.SessionLanguageSetting;
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            objProjectOutBarsik.ProjectId = prjlId;
            objProjectOutBarsik.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objProjectOutBarsik.ChaumasikId = ddlChaumasik.SelectedValue.ToInt32();
            //Session["dtProjectPratifal"] = objBarsikService.PopulateProjectProgress(objProjectOutBarsik);
            DataTable dtProjectPratifal = (DataTable)Session["dtProjectPratifal"];
            Session["dtPopulateProjectPratifalReport"] = dtProjectPratifal;
            objRptFactory = new ReportFactory();
            objRptFactory.SetReport(repDoc);
            objRptServices = new ReportServices();
            objRptServices.GetReport(repDoc, RptViewer);

            /*repDoc.Database.Tables[0].SetDataSource(dtProjectNatija);*/

            repDoc.Database.Tables[0].SetDataSource(dtProjectPratifal);

            if (dtProjectPratifal != null && dtProjectPratifal.Rows.Count > 0)
            {
               
                RptViewer.ReportSource = repDoc;
                Session["PratifalReport"] = repDoc;
            }
            else
            {
                RptViewer.ReportSource = null;
                Session["PratifalReport"] = null;
            }
        }

        protected void viewer_Unload(object sender, EventArgs e)
        {
            if (this.RptViewer != null)
            {
                //this.RptViewer.Close();
                this.RptViewer.Dispose();
            }
        }
    }
}