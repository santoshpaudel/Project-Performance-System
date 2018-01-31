using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceBudgetDonar;
using MISUI.ServiceMenuOffice;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.Budget
{
    public partial class BudgetDonarMap : Base
    {
        private DataTable dtPopulateFiscalYear = null;
        private DataTable dtPopulatePaymentType = null;
        private DataTable dtPopulateDonar = null;
        private DataTable dtPopulateBudgetHead = null;
        private DataTable dtPopulateBudgetDonarMapDetails = null;

        public static int BudgetDonarMapId = 0;

        private Service1 objService1 = null;
        private BudgetDonarService objWebService = null;
        private ComBudgetDonar objComBudgetDonar = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBudgetHead();
                PopulateDonar();
                PopulatePaymentType();
                PopulateFiscalYear();
                SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                if (objQueryString != null)
                {
                    if (objQueryString["id"] != null)
                    {
                        BudgetDonarMapId = int.Parse(objQueryString["id"]);

                    }
                    if (objQueryString["EditId"] != null)
                    {
                        BudgetDonarMapId = int.Parse(objQueryString["EditId"]);

                    }
                }
                if (BudgetDonarMapId > 0)
                {
                    BudgetDonarMapDetails(BudgetDonarMapId);
                }
            }

        }

        private void BudgetDonarMapDetails(int budgetDonarMapId)
        {
            objComBudgetDonar=new ComBudgetDonar();
            objComBudgetDonar.BudgetDonarMapId = budgetDonarMapId;
            objWebService = new BudgetDonarService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
            dtPopulateBudgetDonarMapDetails = objWebService.PopulateBudgetDonarMapDetails(objComBudgetDonar);
            if (dtPopulateBudgetDonarMapDetails != null && dtPopulateBudgetDonarMapDetails.Rows.Count > 0)
            {
                ddlBudgetHead.SelectedValue = dtPopulateBudgetDonarMapDetails.Rows[0]["BUDG_HEAD_ID"].ToString();
                ddlDonar.SelectedValue = dtPopulateBudgetDonarMapDetails.Rows[0]["DONAR_ID"].ToString();
                ddlPaymentType.SelectedValue = dtPopulateBudgetDonarMapDetails.Rows[0]["PAYMENT_TYPE_ID"].ToString();
                ddlFiscalYear.SelectedValue = dtPopulateBudgetDonarMapDetails.Rows[0]["FISCAL_YEAR_ID"].ToString();
                if ((dtPopulateBudgetDonarMapDetails.Rows[0]["IS_ENABLE"]).ToInt32() == 1)
                {
                    chkIsEnable.Checked = true;
                }
                else
                {
                    chkIsEnable.Checked = false;
                }

            }
        }

        private void PopulateFiscalYear()
        {
            objWebService = new BudgetDonarService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
            dtPopulateFiscalYear = objWebService.PopulateFiscalYear(Session["LanguageSetting"].ToString());
            if(dtPopulateFiscalYear!=null && dtPopulateFiscalYear.Rows.Count>0)
            {
                ddlFiscalYear.DataSource = dtPopulateFiscalYear;
                ddlFiscalYear.DataTextField = "FISCAL_YEAR";
                ddlFiscalYear.DataValueField = "FISCAL_YEAR_ID";
                ddlFiscalYear.DataBind();
                ddlFiscalYear.Items.Insert(0,"--Choose Fiscal Year--");
            }
        }

        private void PopulatePaymentType()
        {
            objWebService = new BudgetDonarService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
            dtPopulatePaymentType = objWebService.PopulatePaymentType(Session["LanguageSetting"].ToString());
            if (dtPopulatePaymentType != null && dtPopulatePaymentType.Rows.Count > 0)
            {
                ddlPaymentType.DataSource = dtPopulatePaymentType;
                ddlPaymentType.DataTextField = "PAYMENT_TYPE_NAME";
                ddlPaymentType.DataValueField = "PAYMENT_TYPE_ID";
                ddlPaymentType.DataBind();
                ddlPaymentType.Items.Insert(0, "--Choose Payment Type--");
            }
        }

        private void PopulateDonar()
        {
            objWebService = new BudgetDonarService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
            dtPopulateDonar = objWebService.PopulateAllDonars(Session["LanguageSetting"].ToString());
            if (dtPopulateDonar != null && dtPopulateDonar.Rows.Count > 0)
            {
                ddlDonar.DataSource = dtPopulateDonar;
                ddlDonar.DataTextField = "DONAR_NAME";
                ddlDonar.DataValueField ="DONAR_ID";
                ddlDonar.DataBind();
                ddlDonar.Items.Insert(0, "--Choose Donar--");
            }
        }

        private void PopulateBudgetHead()
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            dtPopulateBudgetHead = objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString());
            if (dtPopulateBudgetHead != null && dtPopulateBudgetHead.Rows.Count > 0)
            {
                ddlBudgetHead.DataSource = dtPopulateBudgetHead;
                ddlBudgetHead.DataTextField = "BUDGET_HEAD_NAME";
                ddlBudgetHead.DataValueField = "BUDGET_HEAD_ID";
                ddlBudgetHead.DataBind();
                ddlBudgetHead.Items.Insert(0, "--Choose Budget Head--");
            }
        }

        protected void btnMapBudgetDonar_Click(object sender, EventArgs e)
        {
            objComBudgetDonar = new ComBudgetDonar();
            int i = 0;
            objComBudgetDonar.BudgetDonarMapId = BudgetDonarMapId;
            objComBudgetDonar.BudgetHeadId = ddlBudgetHead.SelectedValue.ToInt32();
            objComBudgetDonar.DonarId = ddlDonar.SelectedValue.ToInt32();
            objComBudgetDonar.PaymentTypeId = ddlPaymentType.SelectedValue.ToInt32();
            objComBudgetDonar.FiscalYearId = ddlFiscalYear.SelectedValue.ToInt32();
            objComBudgetDonar.IsEnable = (chkIsEnable.Checked) ? 1 : 0;
            objComBudgetDonar.IsLocked = 0;
            if(BudgetDonarMapId==0)
            {
                objComBudgetDonar.Mode = "I";
            }
            else
            {
                objComBudgetDonar.Mode = "U";
            }
            
            objWebService = new BudgetDonarService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
            i = objWebService.AddEditMapBudgetDonar(objComBudgetDonar);
            if (i > 0)
            {
                Response.Write("<script>alert(' Budget-Donar mapped successfully!')</script>");
                Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/BudgetToLineItemMap.aspx");
            }
            else
            {
                Response.Write("<script>alert('Line Item Detail  addition failed!')</script>");
            }

        }
    }
}