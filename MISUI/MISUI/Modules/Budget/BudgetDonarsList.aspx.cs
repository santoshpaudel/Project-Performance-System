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
using MISUICOMMON.QueryString;

namespace MISUI.Modules.Budget
{
    public partial class BudgetDonarsList : Base
    {

        private BudgetDonarService objWebService = null;
        DataTable dtListView = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            btnAddBudgetDonars.Text = GetLabel("ADD BUDGET DONAR");

            if (!IsPostBack)
            {
                BindListView();
            }
        }
        private void BindListView()
        {
            objWebService=new BudgetDonarService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
            dtListView = objWebService.PopulateAllDonars(Session["LanguageSetting"].ToString());
            if (dtListView != null && dtListView.Rows.Count > 0)
            {
              //  lblBudgetDonars.Visible = true;
                lvDonar.DataSource = dtListView;
                lvDonar.DataBind();

            }
            else
            {
               // lblBudgetDonars.Visible = true;
            }


        }

        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvDonar.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
        }

     
        protected void OnLayoutCreated(object sender, EventArgs e)
        {
            /*Label lblDonarEnglishName = (Label)lvDonar.FindControl("lblDonarEnglishName");
            lblDonarEnglishName.Text = GetLabel("DONAR ENGLISH NAME");*/
            Label lblDonarName = (Label)lvDonar.FindControl("lblDonarName");
            lblDonarName.Text = GetLabel("DONAR NAME");
            Label lblDonarCode = (Label)lvDonar.FindControl("lblDonarCode");
            lblDonarCode.Text = GetLabel("DONAR CODE");
            Label status = (Label)lvDonar.FindControl("Status");
            status.Text = GetLabel("STATUS");
            Label action = (Label)lvDonar.FindControl("lblAction");
            action.Text = GetLabel("Action");

        }

        protected void btnAddBudgetDonar_Click(object sender, EventArgs e)
        {
            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/Budget/AddBudgetDonar.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            int donarId = 0;
            if (e.CommandName == "edit")
            {
                donarId = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["id"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/AddBudgetDonar.aspx" + str.EncryptedString, false);
            }
            else if (e.CommandName == "delete")
            {
                objWebService=new BudgetDonarService();
                donarId = int.Parse(e.CommandArgument.ToString());
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
                objWebService.deleteDonar(donarId);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/BudgetDonarsList.aspx");
            }
            else if (e.CommandName == "lock")
            {
                objWebService=new BudgetDonarService();
                int i = 0;
                donarId = int.Parse(e.CommandArgument.ToString());
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
                i=objWebService.LockBudgetDonar(donarId);
                if(i>0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/BudgetDonarsList.aspx");
                else
                {
                    Response.Write("<script>alert('Lock failed')</script>");
                }
            }
            else
            {
                objWebService=new BudgetDonarService();
                int i = 0;
                donarId = int.Parse(e.CommandArgument.ToString());
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
                i=objWebService.UnlockBudgetDonar(donarId);
                if(i>0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/BudgetDonarsList.aspx");
                else
                {
                    Response.Write("<script>alert('Lock failed')</script>"); 
                }
            }
        }

        protected void lvDonar_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            
        }
    }
}