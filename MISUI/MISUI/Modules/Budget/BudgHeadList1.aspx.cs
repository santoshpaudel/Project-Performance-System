using System;
using System.Data;
using System.Web.UI.WebControls;
using MISUI.ServiceMenuOffice;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.Budget
{
    public partial class BudgHeadList1 : Base
    {
        Service1 objWebService = new Service1();
        private DataTable dtListView = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            btnAddBudgetHead.Text = GetLabel("ADD BUDGET HEAD");
            if (!IsPostBack)
            {
                BindListView();
            }

        }

        private void BindListView()
        {
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            dtListView = objWebService.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(), Session["ministry_id"].ToInt32());
            if (dtListView != null && dtListView.Rows.Count > 0)
            {
                //lblBudgetHead.Visible = true;
                ListView1.DataSource = dtListView;
                ListView1.DataBind();

            }
            else
            {
                //lblBudgetHead.Visible = true;
            }


        }

        protected void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }


        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            int budgetHeadId = 0;
            if (e.CommandName == "edit")
            {
                budgetHeadId = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["budgetHeadId"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/AddBudgetHead.aspx" + str.EncryptedString, false);
            }
            else if (e.CommandName == "delete")
            {
                budgetHeadId = int.Parse(e.CommandArgument.ToString());
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
                objWebService.deleteBudgetHead(budgetHeadId);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/BudgHeadList1.aspx");
            }
            else if (e.CommandName == "lock")
            {
                int i = 0;
                budgetHeadId = int.Parse(e.CommandArgument.ToString());
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
                i=objWebService.LockBudgetHead(budgetHeadId);
                if(i>0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/BudgHeadList1.aspx");
                else
                {
                    Response.Write("<script>alert('Lock failed')</script>");
                }
            }
            else
            {
                int i = 0;
                budgetHeadId = int.Parse(e.CommandArgument.ToString());
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
                i=objWebService.UnlockBudgetHead(budgetHeadId);
                if(i>0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/BudgHeadList1.aspx");
                else
                {
                    Response.Write("<script>alert('Unlock failed')</script>");
                }
            }
        }
        protected void btnAddBudgetHead_Click(object sender, EventArgs e)
        {

            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/Budget/AddBudgetHead.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        protected void lvlBudgetHead_LayoutCreated(object sender, EventArgs e)
        {
            Label lblBudgetHeadName = (Label)ListView1.FindControl("lblBudgetHeadName");
            lblBudgetHeadName.Text = GetLabel("BUDGET HEAD NAME");
            Label lblBudgetCode = (Label)ListView1.FindControl("lblBudgetCode");
            lblBudgetCode.Text = GetLabel("BUDGET HEAD CODE");
            Label lblStatus = (Label)ListView1.FindControl("Status");
            lblStatus.Text = GetLabel("STATUS");
            Label action = (Label)ListView1.FindControl("lblAction");
            action.Text = GetLabel("Action");
        }

    }
}