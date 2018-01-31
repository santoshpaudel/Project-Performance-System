using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceMenuOffice;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.DirectoryManagement
{
    public partial class MinistryList : Base
    {
        Service1 objWebService = new Service1();
        private DataTable dtListView = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAddMinistry.Text = GetLabel("ADD MINISTRY");
            if (!this.IsPostBack)
            {
                this.BindListView();
            }
        }
        private void BindListView()
        {

            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            dtListView = objWebService.PopulateAllMinistries(Session["LanguageSetting"].ToString());
            if (dtListView != null && dtListView.Rows.Count > 0)
            {
                lvMinistry.DataSource = dtListView;
                lvMinistry.DataBind();
            }

        }
        protected void OnLayoutCreated(object sender, EventArgs e)
        {
            // (lv.FindControl("lt_Title") as Literal).Text = "Your text";
            /* Label lblMengName = (Label) lvMinistry.FindControl("lblMinistryName");
             lblMengName.Text = GetLabel("MINISTRY ENGLISH NAME");*/
            Label lblMName = (Label)lvMinistry.FindControl("lblMinistryName");
            lblMName.Text = GetLabel("MINISTRY NAME");
            Label lblMCode = (Label)lvMinistry.FindControl("lblMinistryCode");
            lblMCode.Text = GetLabel("MINISTRY CODE");
            Label status = (Label)lvMinistry.FindControl("Status");
            status.Text = GetLabel("STATUS");
           
        }


        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvMinistry.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
        }

       
        protected void btnAddMinistry_Click(object sender, EventArgs e)
        {
            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "AddMinistry.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            int ministryId = 0;
            if (e.CommandName == "edit")
            {
                ministryId = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["ministryId"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/DirectoryManagement/AddMinistry.aspx" + str.EncryptedString, false);
            }
            else if(e.CommandName=="delete")
            {
                ministryId = int.Parse(e.CommandArgument.ToString());
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
                objWebService.deleteMinistry(ministryId);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/DirectoryManagement/MinistryList.aspx");
            }
            else if (e.CommandName == "lock")
            {

                ministryId = int.Parse(e.CommandArgument.ToString());
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
                // objWebService.lockMinistry(ministryId);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/DirectoryManagement/MinistryList.aspx");
            }
            else
            {
                ministryId = int.Parse(e.CommandArgument.ToString());
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
                // objWebService.lockMinistry(ministryId);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/DirectoryManagement/MinistryList.aspx");
            }
        }

        protected void lvMinistry_ItemEditing(object sender, ListViewEditEventArgs e)
        {
           
        }
    }
}