using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using MISUI.CrystalReport.ProjectTrans;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUI.Services.Report;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;

namespace MISUI.CrystalViewer.ProjectTrans
{
    public partial class ProjectStatusProblemsEffortsViewer : Base
    {
        //private static DataTable dtMinistries = null;
        private Service1 objService1 = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        private DataTable dt = null;
        private ReportFactory objRptFactory = null;
        private ReportServices objRptServices = null;
        private ProjectStatusProblemsEffortsReport crpt1 = new ProjectStatusProblemsEffortsReport();
        private ProjectStatusProblemsEffortsReport crpt = new ProjectStatusProblemsEffortsReport();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlMinistry.Enabled = true;
                PopulateMinistries();
                if (Session["ministry_id"].ToInt32() > 0)
                {
                    ddlMinistry.Enabled = false;
                    ddlMinistry.SelectedValue = Session["ministry_id"].ToString();
                }
            }
            if (IsPostBack)
            {
                RptViewer.ReportSource = Session["ProblemReport"];
                RptViewer.RefreshReport();
                RptViewer.DataBind();
            }
        }

        private void PopulateMinistries()
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            Session["dtMinistries"] = objService1.PopulateMinistries();
            DataTable dtMinistries = (DataTable) Session["dtMinistries"];
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
            if (Session["LanguageSetting"].ToString() == "Nepali")
            {
                PopulateStatusProblemsAndEffortsForReport(crpt1);

            }

            else
            {
                PopulateStatusProblemsAndEffortsForReport(crpt);
            }
        }

        private void PopulateStatusProblemsAndEffortsForReport(ReportDocument repDoc)
        {
            objProjectBO = new ComProjectBO();
            objProjectBO.MinistryId = ddlMinistry.SelectedValue.ToInt32();
            objProjectBO.ChaumasikId = ddlChaumasik.SelectedValue.ToInt32();
            objProjectBO.Priority = ddlPriority.SelectedValue.ToInt32();
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dt = wbs.PopulateStatusProblemsAndEffortsForReport(objProjectBO);
            if (dt != null && dt.Rows.Count > 0)
            {
                lnkVerify.Visible = true;
                Session["dtProjectStatusProblemsAndEfforts"] = dt;
                //objPlanRpt = new PlanListRpt();
                objRptFactory = new ReportFactory();
                objRptFactory.SetReport(repDoc);


                objRptServices = new ReportServices();
                objRptServices.GetReport(repDoc, RptViewer);

                repDoc.Database.Tables[0].SetDataSource(dt);

                cryParameter(repDoc);

                RptViewer.ReportSource = repDoc;
                Session["ProblemReport"] = repDoc;
                //chartViewer.ReportSource = objPrjBhautikPragatiGrpRpt;




                // crystalViewer.Zoom(75);
                //chartViewer.Zoom(93);
            }


        
            
        }
        void cryParameter(ReportDocument repDoc)
        {


            //ParameterField pMinistry = new ParameterField();
            //ParameterDiscreteValue dMinistry = new ParameterDiscreteValue();
            //dMinistry.Value = "1";
            //pMinistry.CurrentValues.Add(dMinistry);
            //repDoc.DataDefinition.ParameterFields["Ministry"].ApplyCurrentValues(pMinistry.CurrentValues);



            //ParameterField pDepartment = new ParameterField();
            //ParameterDiscreteValue dDepartment = new ParameterDiscreteValue();
            //dDepartment.Value = "2";
            //pDepartment.CurrentValues.Add(dDepartment);
            //repDoc.DataDefinition.ParameterFields["Department"].ApplyCurrentValues(pDepartment.CurrentValues);


            //ParameterField pDirectorate = new ParameterField();
            //ParameterDiscreteValue dDirectorate = new ParameterDiscreteValue();
            //dDirectorate.Value = "3";
            //pDirectorate.CurrentValues.Add(dDirectorate);
            //repDoc.DataDefinition.ParameterFields["Directorate"].ApplyCurrentValues(pDirectorate.CurrentValues);


            //ParameterField pDistrictOffice = new ParameterField();
            //ParameterDiscreteValue dDistrictOffice = new ParameterDiscreteValue();
            //dDistrictOffice.Value = "4";
            //pDistrictOffice.CurrentValues.Add(dDistrictOffice);
            //repDoc.DataDefinition.ParameterFields["DistrictOffice"].ApplyCurrentValues(pDistrictOffice.CurrentValues);

            //ParameterField pAddress = new ParameterField();
            //ParameterDiscreteValue dAddress = new ParameterDiscreteValue();
            //dAddress.Value = "5";
            //pAddress.CurrentValues.Add(dAddress);
            //repDoc.DataDefinition.ParameterFields["Address"].ApplyCurrentValues(pAddress.CurrentValues);

        }
        protected void viewer_Unload(object sender, EventArgs e)
        {
            if (this.RptViewer != null)
            {
                //this.tabviewer.Close();
                this.RptViewer.Dispose();
            }
        }

        protected void lnkVerify_Click(object sender, EventArgs e)
        {
            int i = 0;
            string mode = string.Empty;
            objProjectBO = new ComProjectBO();
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objProjectBO.ChaumasikId = ddlChaumasik.SelectedValue.ToInt32();
            objProjectBO.MinistryId = ddlMinistry.SelectedValue.ToInt32();
            objProjectBO.Priority = ddlPriority.SelectedValue.ToInt32();

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
            check = wbs.CheckLowerLevelProjectStatusProblemEffortReport(objProjectBO);

            if (check == 1)
            {
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                i = wbs.AddProjectStatusProblemEffortReportVerification(objProjectBO);
                if (i > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Report Verified.'); window.location='" +
                                Constants.ConstantAppPath + "/CrystalViewer/ProjectTrans/ProjectStatusProblemsEffortsViewer.aspx';", true);
                    //Response.Redirect(Constants.ConstantAppPath + "/CrystalViewer/ProjectTrans/ProjectStatusProblemsEffortsViewer.aspx");
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Verification failed.'); window.location='" +
                                Constants.ConstantAppPath + "/CrystalViewer/ProjectTrans/ProjectStatusProblemsEffortsViewer.aspx';", true);
                   // Response.Write("<script>alert('Verification failed')</script>");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Verification failed. Lower level verification is required.'); window.location='" +
                                Constants.ConstantAppPath + "/CrystalViewer/ProjectTrans/ProjectStatusProblemsEffortsViewer.aspx';", true);
                //Response.Write("<script>alert('Verification failed. Lower level verification is required.')</script>");
            }
        }
    }
}