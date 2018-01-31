using System;
using System.Data;
using MISUI.ServiceBudgetDonar;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;
using MISUICOMMON.HelperClass;

namespace MISUI.Modules.Budget
{
    public partial class AddBudgetDonar : Base
    {
       // private static int donarId = 0;
        //private static DataTable dtPopulateDonarDetails = null;
        private BudgetDonarService objWebService = null;
        ComBudgetDonar objComBudgetDonar = new ComBudgetDonar();

       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                if (objQueryString != null)
                {
                    if (objQueryString["id"] != null)
                    {
                        Session["donarId"] = int.Parse(objQueryString["id"]);

                    }
                }

                if (Session["donarId"].ToInt32() == 0)// add donar
                {
                    btnAddDonar.Text = "Add Donar";

                }

                 // to edit donar
                else
                {
                    populateDonarDetails(Session["donarId"].ToInt32());
                    btnAddDonar.Text = "Update Donar";
                }
            }
        }

        private void populateDonarDetails(int donarId)
        {
            objWebService=new BudgetDonarService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
            Session["dtPopulateDonarDetails"] = objWebService.PopulateDonarDetails(donarId);
            DataTable dtPopulateDonarDetails = (DataTable) Session["dtPopulateDonarDetails"];
            if (dtPopulateDonarDetails != null && dtPopulateDonarDetails.Rows.Count > 0)
            {

                txtDonarEnglishName.Text = dtPopulateDonarDetails.Rows[0]["donar_eng_name"].ToString();
                txtDonarNepaliName.Text = dtPopulateDonarDetails.Rows[0]["donar_nep_name"].ToString();
                txtDonarCode.Text = dtPopulateDonarDetails.Rows[0]["donar_code"].ToString();
                ddlDonarType.SelectedValue = dtPopulateDonarDetails.Rows[0]["donar_type"].ToString();
                if (dtPopulateDonarDetails.Rows[0]["ISENABLE"].ToString() == "1")
                {
                    chkIsEnable.Checked = true;
                }
                else
                {
                    chkIsEnable.Checked = false;
                }
            }

        }
        protected void btnAddDonar_Click(object sender, EventArgs e)
        {
            int i = 0;
            objComBudgetDonar.DonarEngName = txtDonarEnglishName.Text;
            objComBudgetDonar.DonarNepName = txtDonarNepaliName.Text;
            objComBudgetDonar.DonarCode = txtDonarCode.Text;
            objComBudgetDonar.DonarType = ddlDonarType.SelectedValue.ToInt32();
            objComBudgetDonar.IsEnable = (chkIsEnable.Checked) ? 1 : 0;
            objComBudgetDonar.IsLocked = 0;
            objWebService = new BudgetDonarService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
            i=objWebService.AddDonar(objComBudgetDonar, Session["donarId"].ToInt32());
            if (i > 0)
            {
                Response.Write("<script>alert('Budget Donar added successfully!')</script>");
                Response.Redirect(Constants.ConstantAppPath+"/Modules/Budget/BudgetDonarsList.aspx");
            }
            else
            {
                Response.Write("<script>alert('Budget Donar addition failed!')</script>");
            }


        }
    }
}