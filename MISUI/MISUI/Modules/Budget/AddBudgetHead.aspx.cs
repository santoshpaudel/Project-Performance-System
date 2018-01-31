using System;
using System.Data;
using MISUI.ServiceMenuOffice;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.Budget
{
    public partial class AddBudgetHead : Base
    {
        //private static int budgetHeadId = 0;
        //private static DataTable dtPopulateBudgetHeadDetails = null;
        private ComBudgetHeadBO objBudgetBo = null;

        private Service1 objWebService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateFiscalYear();
                SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                if (objQueryString != null)
                {
                    if (objQueryString["budgetHeadId"] != null)
                    {
                        Session["budgetHeadId"] = int.Parse(objQueryString["budgetHeadId"]);

                    }
                }

                if (Session["budgetHeadId"].ToInt32() == 0)// add budget head
                {
                    btnAddBudgetHead.Text = "Add Budget Head";

                }

                 // to edit budget head
                else
                {
                    populateBudgetHeadDetails(Session["budgetHeadId"].ToInt32());
                    btnAddBudgetHead.Text = "Update Budget Head";
                }
            }
        }

        private void populateBudgetHeadDetails(int i)
        {
            objWebService = new Service1();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            Session["dtPopulateBudgetHeadDetails"] = objWebService.PopulateBudgetHeadDetails(i);
            DataTable dtPopulateBudgetHeadDetails = (DataTable) Session["dtPopulateBudgetHeadDetails"];
            if (dtPopulateBudgetHeadDetails != null && dtPopulateBudgetHeadDetails.Rows.Count > 0)
            {
                txtBudgetHeadEnglishName.Text = dtPopulateBudgetHeadDetails.Rows[0]["budget_head_eng_name"].ToString();
                txtBudgetHeadNepaliName.Text = dtPopulateBudgetHeadDetails.Rows[0]["budget_head_nep_name"].ToString();
                txtBudgetCode.Text = dtPopulateBudgetHeadDetails.Rows[0]["budget_code"].ToString();
                ddlFiscalYear.SelectedValue = dtPopulateBudgetHeadDetails.Rows[0]["fiscal_year_id"].ToString();
                if (Convert.ToInt16(dtPopulateBudgetHeadDetails.Rows[0]["ISENABLE"]) == 1)
                {
                    chkIsEnable.Checked = true;
                }
                else
                {
                    chkIsEnable.Checked = false;
                }
            }
        }

        private void populateFiscalYear()
        {
            DataTable DtFiscalYear = null;
            objWebService = new Service1();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            DtFiscalYear = objWebService.PopulateFiscalYear();
            if(DtFiscalYear!=null && DtFiscalYear.Rows.Count>0)
            {
                ddlFiscalYear.DataSource = DtFiscalYear;
                ddlFiscalYear.DataTextField = "FISCAL_YEAR_NEP";
                ddlFiscalYear.DataValueField = "FISCAL_YEAR_ID";
                ddlFiscalYear.DataBind();
                ddlFiscalYear.Items.Insert(0,"--आ.व. छान्नुहोस्--");
            }
        }

        protected void btnAddBudgetHead_Click(object sender, EventArgs e)
        {
            int i = 0;
            objBudgetBo=new ComBudgetHeadBO();
            objBudgetBo.BudgetHeadEngName = txtBudgetHeadEnglishName.Text;
            objBudgetBo.BudgetHeadNepName = txtBudgetHeadNepaliName.Text;
            objBudgetBo.BudgetCode = txtBudgetCode.Text;
            objBudgetBo.FiscalYearId = ddlFiscalYear.SelectedValue.ToInt32();
            objBudgetBo.BudgetHeadId = Session["budgetHeadId"].ToInt32();
            objBudgetBo.IsLocked = 0;
            if (chkIsEnable.Checked == true)
                objBudgetBo.IsEnable = 1;
            else
            {
                objBudgetBo.IsEnable = 0;
            }
            objWebService = new Service1();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();

            i=objWebService.AddEditBudgetHead(objBudgetBo);
            if(i>0)
            {
                Response.Write("<script>alert('Budget Head added successfully!')</script>");
                Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/BudgHeadList1.aspx");
            }
            else
            {
                Response.Write("<script>alert('Budget Head addition failed!')</script>");
            }

        }
    }
}