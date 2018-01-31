using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using MISUI.CrystalReport.ProjectTrans;
using MISUI.ServiceBarsikKaryekram;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUI.Services.Report;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;

namespace MISUI.CrystalViewer.ProjectTrans
{
    public partial class ProjectPratifalViewer : Base
    {
        private ReportFactory objRptFactory = null;
        private ReportServices objRptServices = null;


        /* private ProjectNatijaRpt crpt1 = new ProjectNatijaRpt();
         private ProjectNatijaRpt crpt = new ProjectNatijaRpt();*/

        private ProjectPratifalRpt crpt1 = new ProjectPratifalRpt();
        private ProjectPratifalRpt crpt = new ProjectPratifalRpt();

        private Service1 objService1 = null;
        // private static DataTable dtMinistries = null;
        //private static DataTable dtPopulateBudgetHead = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        private BarsikKaryekramService objBarsikService = null;

        //private static DataTable dtProjectNatija = null;
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
                /*RptViewer.ReportSource = Session["NatijaReport"];*/
                RptViewer.ReportSource = Session["PratifalReport"];
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
            /*if (Session["ministry_id"].ToInt32() == 0)
            {
                dtPopulateBudgetHead = objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(), ddlMinistry.SelectedValue.ToInt32());

            }
            else
            {
                dtPopulateBudgetHead = objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(), Session["ministry_id"].ToInt32());
                
            }*/

            // for project/program/pariyojana users
            if (Session["office_type_id"].ToInt32() == 4 || Session["office_type_id"].ToInt32() == 5 ||
                Session["office_type_id"].ToInt32() == 6)
            {
                /*Session["dtPopulateBudgetHead"] =
                    objService1.PopulateAllBudgetHeadsByOfficeId(Session["LanguageSetting"].ToString(),
                        Session["office_id"].ToInt32());*/
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
            //Session["rptPlanId"] = selPlan.SelectedValue.ToString();


            int prId = ddlProject.SelectedValue.ToInt32();

            Session["rptProjectId"] = prId.ToString();



            if (Session["LanguageSetting"].ToString() == "Nepali")
            {
                LoadReport(prId.ToInt32(), crpt1);

            }

            else
            {
                LoadReport(prId.ToInt32(), crpt);
            }
        }

        protected void LoadReport(int prjlId, ReportDocument repDoc)
        {
            //repDoc = new ReportDocument();

            objBarsikService = new BarsikKaryekramService();
            ProjectOutputTBarsikBO objProjectOutBarsik = new ProjectOutputTBarsikBO();
            objProjectOutBarsik.Lang = SessionHelper.SessionLanguageSetting;
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            objProjectOutBarsik.ProjectId = prjlId;
            objProjectOutBarsik.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objProjectOutBarsik.ChaumasikId = ddlChaumasik.SelectedValue.ToInt32();
            /*Session["dtProjectNatija"] = objBarsikService.PopulateProjectTargetsBarsikRpt(objProjectOutBarsik);
            DataTable dtProjectNatija = (DataTable) Session["dtProjectNatija"];
             
            Session["dtPopulateProjectNatijaReport"] = dtProjectNatija;*/

            Session["dtProjectPratifal"] = objBarsikService.PopulateProjectProgressRpt(objProjectOutBarsik);
            DataTable dtProjectPratifal = (DataTable)Session["dtProjectPratifal"];

            Session["dtPopulateProjectPratifalReport"] = dtProjectPratifal;

            objRptFactory = new ReportFactory();
            objRptFactory.SetReport(repDoc);


            objRptServices = new ReportServices();
            objRptServices.GetReport(repDoc, RptViewer);

            /*repDoc.Database.Tables[0].SetDataSource(dtProjectNatija);*/

            repDoc.Database.Tables[0].SetDataSource(dtProjectPratifal);

            //cryParameter(repDoc);

            // RptViewer.ReportSource = repDoc;
            //chartViewer.ReportSource = objPrjBhautikPragatiGrpRpt;


            /*if (dtProjectNatija != null && dtProjectNatija.Rows.Count > 0)
            {
                RptViewer.ReportSource = repDoc;
                Session["NatijaReport"] = repDoc;
            }
            else
            {
                RptViewer.ReportSource = null;
                Session["NatijaReport"] = null;
            }*/

            if (dtProjectPratifal != null && dtProjectPratifal.Rows.Count > 0)
            {
                lnkVerify.Visible = false;
                RptViewer.ReportSource = repDoc;
                Session["PratifalReport"] = repDoc;
            }
            else
            {
                RptViewer.ReportSource = null;
                Session["PratifalReport"] = null;
            }


            // crystalViewer.Zoom(75);
            //chartViewer.Zoom(93);



        }


        void cryParameter(ReportDocument repDoc)
        {




        }



        protected void viewer_Unload(object sender, EventArgs e)
        {
            if (this.RptViewer != null)
            {
                //this.RptViewer.Close();
                this.RptViewer.Dispose();
            }
        }

        protected void lnkVerify_Click(object sender, EventArgs e)
        {
            int i = 0;
            string mode = string.Empty;
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = ddlProject.SelectedValue.ToInt32();
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objProjectBO.ChaumasikId = ddlChaumasik.SelectedValue.ToInt32();
            if (Session["role_id"].ToInt32() == 12)
                objProjectBO.Mode = mode = "V1"; //verification level 1
            else if (Session["role_id"].ToInt32() == 13)
                objProjectBO.Mode = mode = "V2"; //verification level 2
            else if (Session["role_id"].ToInt32() == 14)
                objProjectBO.Mode = mode = "V3"; //verification level 3
            else if (Session["role_id"].ToInt32() == 15)
                objProjectBO.Mode = mode = "V4"; //verification level 4

            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            int check = 0;
            check = wbs.CheckLowerLevelProjectPratifalReport(objProjectBO);

            if (check == 1)
            {
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                i = wbs.AddProjectPratifalReportVerification(objProjectBO);
                if (i > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Report Verified'); window.location='" +
                                Constants.ConstantAppPath + "/CrystalViewer/ProjectTrans/ProjectPratifalViewer.aspx';", true);
                   // Response.Redirect(Constants.ConstantAppPath + "/CrystalViewer/ProjectTrans/ProjectPratifalViewer.aspx");
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Verification failed.'); window.location='" +
                                Constants.ConstantAppPath + "/CrystalViewer/ProjectTrans/ProjectPratifalViewer.aspx';", true);
                    //Response.Write("<script>alert('Verification failed')</script>");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Verification failed. Lower level verification is required.'); window.location='" +
                                Constants.ConstantAppPath + "/CrystalViewer/ProjectTrans/ProjectPratifalViewer.aspx';", true);
                //Response.Write("<script>alert('Verification failed. Lower level verification is required.')</script>");
            }
        }
    }
}