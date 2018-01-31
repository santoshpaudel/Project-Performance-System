using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceActivityMgmt;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.OutputTargetManagement
{
    public partial class AddProjectOutput : Base
    {
        private Service1 objService1 = null;
        private DataTable dtPopulateBudgetHead = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        private DataTable dtProjectDetail = null;
        //private ProjectVerificationBO projectVerificationBo = null;
        DataTable dtA = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptOutput.DataSource = null;
                rptOutput.DataBind();
                if (Request.QueryString["enc"] != null)
                {
                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["projectId"] != null)
                        {
                            Session["projectId"] = objQueryString["projectId"].ToInt32();
                        }
                    }

                }
                if (Session["projectId"].ToInt32() > 0)
                {
                    PopulateProjectOutput(Session["projectId"].ToInt32(), Session["fiscal_year_id"].ToInt32());
                }

            }


        }

        protected void btnSaveOutput_Click(object sender, EventArgs e)
        {
            int i = 0;
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = Session["projectId"].ToInt32();
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objProjectBO.ModifiedDate = DateTime.Now;
            objProjectBO.ModifiedBy = Session["username"].ToString();
            //To clear project pratifal
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            i = wbs.ClearProjectPratifal(objProjectBO);
            TextBox txtOrder = new TextBox();
            TextBox txtOutput = new TextBox();
            DropDownList ddlUnit = new DropDownList();
            TextBox txtYearlyTarget = new TextBox();
            TextBox txtFirstQuarterTarget = new TextBox();
            TextBox txtSecondQuarterTarget = new TextBox();
            TextBox txtThirdQuarterTarget = new TextBox();
            TextBox txtOutputRemarks = new TextBox();
            int k = 0;
            foreach (RepeaterItem rptItem in rptOutput.Items)
            {
                txtOrder = (TextBox) rptItem.FindControl("txtOrder");
                txtOutput = (TextBox)rptItem.FindControl("txtOutput");
                txtYearlyTarget = (TextBox)rptItem.FindControl("txtYearlyTarget");
                ddlUnit = (DropDownList)rptItem.FindControl("ddlUnit");
                txtFirstQuarterTarget = (TextBox)rptItem.FindControl("txtFirstQuarterTarget");
                txtSecondQuarterTarget = (TextBox)rptItem.FindControl("txtSecondQuarterTarget");
                txtThirdQuarterTarget = (TextBox)rptItem.FindControl("txtThirdQuarterTarget");
                txtOutputRemarks = (TextBox)rptItem.FindControl("txtOutputRemarks");
                //objProjectBO.Order=txtOrder.Text;
                objProjectBO.Output = txtOutput.Text;
                objProjectBO.UnitId = ddlUnit.SelectedValue.ToInt32();
                objProjectBO.YearlyTarget = txtYearlyTarget.Text.ToDecimal();
                objProjectBO.FirstQuarterTarget = txtFirstQuarterTarget.Text.ToDecimal();
                objProjectBO.SecondQuarterTarget = txtSecondQuarterTarget.Text.ToDecimal();
                objProjectBO.ThirdQuarterTarget = txtThirdQuarterTarget.Text.ToDecimal();
                objProjectBO.OutputRemarks = txtOutputRemarks.Text;
                objProjectBO.Order = txtOrder.Text.ToInt32();
                //if (txtYearlyTarget.Text.ToDecimal() != txtFirstQuarterTarget.Text.ToDecimal() + txtSecondQuarterTarget.Text.ToDecimal() + txtThirdQuarterTarget.Text.ToDecimal())
                //{
                //    Response.Write("alert('तीन वटा चौमासिक लक्ष्यको योग वार्षिक लक्ष्य बराबर हुनुपर्दछ।')");
                //    txtYearlyTarget.Focus();
                //}
                //else
                //{
                //    wbs = new ProjectService();
                //    wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                //    k = wbs.SaveProjectPratifal(objProjectBO);
                //}

                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                k = wbs.SaveProjectPratifal(objProjectBO);
            }
            if (k > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
    "alert('इन्ट्री सफल भएको छ।'); window.location='" +
    Constants.ConstantAppPath + "/Modules/OutputTargetManagement/AddProjectOutput.aspx" + "';", true);
                // Response.Redirect(Constants.ConstantAppPath + "/Modules/BarsikKaryekram/ListProjectBarshikKaryakram.aspx");
            }
            else
            {
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
        "alert('इन्ट्री सफल भएन। कृपया पुन: प्रयास गर्नुहोला।'); window.location='" +
           Constants.ConstantAppPath + "/Modules/OutputTargetManagement/AddProjectOutput.aspx" + "';", true);
                    // Response.Redirect(Constants.ConstantAppPath + "/Modules/BarsikKaryekram/ListProjectBarshikKaryakram.aspx");
                }
            }
        }

        protected void rptOutput_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ActivityManagementService objAms = new ActivityManagementService();
                DropDownList ddlUnit = (DropDownList)e.Item.FindControl("ddlUnit");
                ActivityDetailBO objAdb = new ActivityDetailBO();
                objAdb.Lang = Session["LanguageSetting"].ToString();
                objAms.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
                DataTable dtUnit = objAms.SelectActivityUnit(objAdb);

                if (dtUnit != null && dtUnit.Rows.Count > 0)
                {
                    ddlUnit.DataSource = dtUnit;
                    ddlUnit.DataTextField = "UNIT_NAME";
                    ddlUnit.DataValueField = "UNIT_ID";
                    ddlUnit.DataBind();
                    ddlUnit.Items.Insert(0, "--छान्नुहोस्--");
                }
                DropDownList ddlPlanUnit = new DropDownList();
                ddlPlanUnit = (DropDownList)e.Item.FindControl("ddlUnit");
                ddlPlanUnit.SelectedValue = dtA.Rows[e.Item.ItemIndex]["UNIT_ID"].ToString();

            }
        }

        protected void btnAddProjectOutput_Click(object sender, EventArgs e)
        {
            dtA.Clear();
            dtA.Columns.Add("OUTPUT_ORDER");
            dtA.Columns.Add("OUTPUT");
            dtA.Columns.Add("UNIT_ID");
            dtA.Columns.Add("YEARLY_TARGET");
            dtA.Columns.Add("FIRST_QUARTER_TARGET");
            dtA.Columns.Add("SECOND_QUARTER_TARGET");
            dtA.Columns.Add("THIRD_QUARTER_TARGET");
            dtA.Columns.Add("OUTPUT_REMARKS");
            TextBox txtOrder=new TextBox();
            TextBox txtOutput = new TextBox();
            DropDownList ddlUnit = new DropDownList();
            TextBox txtYearlyTarget = new TextBox();
            TextBox txtFirstQuarterTarget = new TextBox();
            TextBox txtSecondQuarterTarget = new TextBox();
            TextBox txtThirdQuarterTarget = new TextBox();
            TextBox txtOutputRemarks = new TextBox();
            foreach (RepeaterItem rptItem in rptOutput.Items)
            {
                DataRow drA = dtA.NewRow();
                txtOrder = (TextBox) rptItem.FindControl("txtOrder");
                txtOutput = (TextBox)rptItem.FindControl("txtOutput");
                ddlUnit = (DropDownList)rptItem.FindControl("ddlUnit");
                txtYearlyTarget = (TextBox)rptItem.FindControl("txtYearlyTarget");
                txtFirstQuarterTarget = (TextBox)rptItem.FindControl("txtFirstQuarterTarget");
                txtSecondQuarterTarget = (TextBox)rptItem.FindControl("txtSecondQuarterTarget");
                txtThirdQuarterTarget = (TextBox)rptItem.FindControl("txtThirdQuarterTarget");
                txtOutputRemarks = (TextBox)rptItem.FindControl("txtOutputRemarks");
                drA["OUTPUT_ORDER"] = txtOrder.Text;
                drA["OUTPUT"] = txtOutput.Text;
                drA["UNIT_ID"] = ddlUnit.SelectedValue.ToInt32();
                drA["YEARLY_TARGET"] = txtYearlyTarget.Text;
                drA["FIRST_QUARTER_TARGET"] = txtFirstQuarterTarget.Text;
                drA["SECOND_QUARTER_TARGET"] = txtSecondQuarterTarget.Text;
                drA["THIRD_QUARTER_TARGET"] = txtThirdQuarterTarget.Text;
                drA["OUTPUT_REMARKS"] = txtOutputRemarks.Text;
                if (txtYearlyTarget.Text != "")
                {
                    dtA.Rows.Add(drA);
                }
            }
            DataRow drB = dtA.NewRow();
            drB["OUTPUT_ORDER"] = "";
            drB["OUTPUT"] = "";
            drB["UNIT_ID"] = 0;
            drB["YEARLY_TARGET"] = 0;
            drB["FIRST_QUARTER_TARGET"] = 0;
            drB["SECOND_QUARTER_TARGET"] = 0;
            drB["THIRD_QUARTER_TARGET"] = 0;
            drB["OUTPUT_REMARKS"] = "";
            dtA.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptOutput.DataSource = db;
            rptOutput.DataBind();

            rptOutput.DataSource = dtA;
            rptOutput.DataBind();


        }

        private void PopulateProjectOutput(int projectId, int fiscalYearId)
        {
            DataTable dtProjectOutput = null;
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = projectId;
            objProjectBO.FiscalYearId = fiscalYearId;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtA = dtProjectOutput = wbs.PopulateProjectOutput(objProjectBO);

            if (dtProjectOutput != null && dtProjectOutput.Rows.Count > 0)
            {
                rptOutput.DataSource = dtProjectOutput;
                rptOutput.DataBind();
                lblModification.Text = dtProjectOutput.Rows[0]["MODIFIED_DATE"].ToDateTime().ToString("D");
                lblModifiedBy.Text = dtProjectOutput.Rows[0]["MODIFIED_BY"].ToString();
            }
            else
            {

                dtA.Clear();
                DataRow drB = dtA.NewRow();
                drB["OUTPUT_ORDER"] =0;
                drB["OUTPUT"] = "";
                drB["UNIT_ID"] = 0;
                drB["YEARLY_TARGET"] = 0;
                drB["FIRST_QUARTER_TARGET"] = 0;
                drB["SECOND_QUARTER_TARGET"] = 0;
                drB["THIRD_QUARTER_TARGET"] = 0;
                drB["OUTPUT_REMARKS"] = "";
                dtA.Rows.Add(drB);

                rptOutput.DataSource = dtA;
                rptOutput.DataBind();
            }

        }

       
    }
}