using System;
using System.Data;
using System.Web.UI;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;

namespace MISUI
{
    public partial class Home : Base
    {
        private Service1 objService1 = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        private DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            fiscalYearId.Value = Session["fiscal_year_id"].ToString();
            if (!IsPostBack)
            {
                ddlMinistry.Enabled = true;
                PopulateMinistries();

                if (Session["ministry_id"].ToInt32() > 0)
                {
                    ddlMinistry.Enabled = false;
                    ddlMinistry.SelectedValue = Session["ministry_id"].ToString();
                    ddlMinistryPriority.Enabled = false;
                    ddlMinistryPriority.SelectedValue = Session["ministry_id"].ToString();
                    PopulateProjectsByMinistryId();
                }
                else
                {
                    ddlMinistry.SelectedValue = "4"; // default MoFALD
                    ddlMinistryPriority.SelectedValue = "4"; // default MoFALD
                    PopulateProjectsByMinistryId();
                }
                //ddlTrimester.SelectedValue = "1";
                LoadChart();
                GetPriorityChart();
                LoadBarChart();
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
                ddlMinistryPriority.DataSource = dtMinistries;
                if (Session["LanguageSetting"].ToString() == "Nepali")
                {
                    ddlMinistry.DataTextField = "OFFICE_NEP_NAME";
                    ddlMinistryPriority.DataTextField = "OFFICE_NEP_NAME";
                }
                else
                {
                    ddlMinistry.DataTextField = "OFFICE_ENG_NAME";
                    ddlMinistryPriority.DataTextField = "OFFICE_ENG_NAME";
                }

                ddlMinistry.DataValueField = "OFFICE_ID";
                ddlMinistry.DataBind();
                ddlMinistry.Items.Insert(0, "--छान्नुहोस्--");

                ddlMinistryPriority.DataValueField = "OFFICE_ID";
                ddlMinistryPriority.DataBind();
                ddlMinistryPriority.Items.Insert(0, "--छान्नुहोस्--");
            }
        }

        protected void btnViewChart(object sender, EventArgs e)
        {
            LoadChart();
            GetPriorityChart();
            LoadBarChart();
        }

        private void LoadBarChart()
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateProject = new DataTable();

            //amcharts bar 
            WebService1 serv = new WebService1();
            string result = string.Empty;
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            //objComProjectBO.MinistryId = ddlMinistry.SelectedValue.ToInt32();
            //objComProjectBO.Priority = ddlPriority.SelectedValue.ToInt32();
            objComProjectBO.ProjectId = ddlProject.SelectedValue.ToInt32();
            objComProjectBO.ChaumasikId = ddlChaumasik.SelectedValue.ToInt32();
            objComProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            result = serv.GetBarChartDataBarshik(objComProjectBO);
            // result = "var chartData=" + result+";";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "bar2", "<script>" + result + "   </script>");
            ClientScript.RegisterStartupScript(this.GetType(), "bar3", "<script>" + result + "   </script>");

        }

        protected void ddlMinistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProjectsByMinistryId();
            GetPriorityChart();
            LoadChart();
            LoadBarChart();
        }


        private void LoadChart()
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateProject = new DataTable();

            //amcharts bar 
            WebService1 serv = new WebService1();
            string result = string.Empty;
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            //objComProjectBO.MinistryId = ddlMinistry.SelectedValue.ToInt32();
            //objComProjectBO.Priority = ddlPriority.SelectedValue.ToInt32();
            objComProjectBO.ProjectId = ddlProject.SelectedValue.ToInt32();
            objComProjectBO.ChaumasikId = ddlChaumasik.SelectedValue.ToInt32();
            objComProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            result = serv.GetBarChartData(objComProjectBO);
            // result = "var chartData=" + result+";";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "bar", "<script>" + result + "   </script>");
            ClientScript.RegisterStartupScript(this.GetType(), "bar1", "<script>" + result + "   </script>");

            //amcharts bar 


            //---
            //objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            //objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            //objComProjectBO.MinistryId = ddlMinistry.SelectedValue.ToInt32();
            ////objComProjectBO.Priority = ddlPriority.SelectedValue.ToInt32();
            //objComProjectBO.ProjectId = ddlProject.SelectedValue.ToInt32();
            //objComProjectBO.ChaumasikId = ddlChaumasik.SelectedValue.ToInt32();
            //objComProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            //dtPopulateProject = objWebService.PopulateProjectSamastigatDashboard(objComProjectBO);
            ////dtPopulateProject = GetData();
            //for (int i = 0; i < dtPopulateProject.Columns.Count; i++)
            //{

            //    if (dtPopulateProject.Columns[i].ColumnName == "BHAUTIK_PRAGATI" || dtPopulateProject.Columns[i].ColumnName == "BITIYE_PRAGATI")
            //    {
            //        Series series = new Series();
            //        series.IsValueShownAsLabel = true;
            //        series.ChartType = SeriesChartType.Column;

            //        for (int j = 0; j < dtPopulateProject.Rows.Count; j++)
            //        {
            //            if (dtPopulateProject.Columns[i].ColumnName == "BHAUTIK_PRAGATI")
            //            {
            //                Color c = Color.FromArgb(27,116,5);

            //                Decimal y = dtPopulateProject.Rows[j]["BHAUTIK_PRAGATI"].ToDecimal();
            //                series.Points.AddXY(dtPopulateProject.Rows[j]["PROJECT_NEP_NAME"].ToString(), y);
            //                series.Color = c;
            //                series.Name = "भौतिक प्रगति";
            //            }
            //            if (dtPopulateProject.Columns[i].ColumnName == "BITIYE_PRAGATI")
            //            {
            //                Color c = Color.FromArgb(239, 250, 15);

            //                Decimal y = dtPopulateProject.Rows[j]["BITIYE_PRAGATI"].ToDecimal();
            //                series.Points.AddXY(dtPopulateProject.Rows[j]["PROJECT_NEP_NAME"].ToString(), y);
            //                series.Color = c;
            //                series.Name = "वित्तिय प्रगति";
            //            }
            //        }
            //        Chart1.Series.Add(series);
            //    }
            //---

            //}


        }

        protected void btnViewPriorityChart(object sender, EventArgs e)
        {
            GetPriorityChart();
            LoadChart();
            LoadBarChart();
        }

        public void GetPriorityChart()
        {
            WebService1 serv = new WebService1();
            string result = string.Empty;
            result = serv.GetChartData(ddlMinistryPriority.SelectedValue.ToInt32(), "1", 0);
            // result = "var chartData=" + result+";";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "name", "<script>" + result + "   </script>");
            ClientScript.RegisterStartupScript(this.GetType(), "name1", "<script>" + result + "   </script>");
            //
            result = serv.GetChartData(ddlMinistryPriority.SelectedValue.ToInt32(), "2", ddlTrimester.SelectedValue.ToInt32());
            // result = "var chartData=" + result+";";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "name1", "<script>" + result + "   </script>");
            ClientScript.RegisterStartupScript(this.GetType(), "name2", "<script>" + result + "   </script>");
            //
            result = serv.GetChartData(ddlMinistryPriority.SelectedValue.ToInt32(), "3", ddlTrimester.SelectedValue.ToInt32());
            // result = "var chartData=" + result+";";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "name2", "<script>" + result + "   </script>");
            ClientScript.RegisterStartupScript(this.GetType(), "name3", "<script>" + result + "   </script>");
        }

        private void PopulateProjectsByMinistryId()
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateProject = new DataTable();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            objComProjectBO.MinistryId = ddlMinistry.SelectedValue.ToInt32();
            dtPopulateProject = objWebService.PopulateProjectByMinstryId(objComProjectBO);
            if (dtPopulateProject != null && dtPopulateProject.Rows.Count > 0)
            {
                ddlProject.DataSource = dtPopulateProject;
                ddlProject.DataTextField = "PROJECT_NAME";
                ddlProject.DataValueField = "PROJECT_ID";
                ddlProject.DataBind();
            }
        }

        protected void ImgDashboard_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Constants.ConstantAppPath + "/Home.aspx");
        }
    }
}