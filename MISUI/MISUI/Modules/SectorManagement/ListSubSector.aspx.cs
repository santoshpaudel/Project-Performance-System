using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceSectorMgmt;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.SubSectorManagement
{
    public partial class ListSubSector : Base
    {
        private SectorService objWebService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAddSubSector.Text = GetLabel("ADD");
            if (!IsPostBack)
            {
                BindListView();
            }
        }

        public DataTable dtListView = null;
        private ComSubSector objComSubSector = null;
        private void BindListView()
        {
            objWebService=new SectorService();
            objComSubSector = new ComSubSector();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
            objComSubSector.Lang = Session["LanguageSetting"].ToString();
            dtListView = objWebService.PopulateAllSubSectors(objComSubSector);
            if (dtListView != null && dtListView.Rows.Count > 0)
            {
                lvSubSector.DataSource = dtListView;
                lvSubSector.DataBind();

            }
            else
            {
               
            }
        }


        protected void btnAddSubSector_Click(object sender, EventArgs e)
        {

            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/SectorManagement/AddEditSubSector.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        protected void lvSubSector_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }


        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            int subSectorId = 0;
            if (e.CommandName == "edit")
            {
                subSectorId = int.Parse(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["id"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/SectorManagement/AddEditSubSector.aspx" + str.EncryptedString, false);
            }
            else if (e.CommandName == "delete")
            {
                objComSubSector = new ComSubSector();
                objComSubSector.SubSectorId = int.Parse(e.CommandArgument.ToString());
                objComSubSector.Mode = "D";
                objWebService = new SectorService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
                objWebService.AddSubSector(objComSubSector);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/SectorManagement/ListSubSector.aspx");
            }
            else if (e.CommandName == "lock")
            {
                int i = 0;
                objComSubSector = new ComSubSector();
                objComSubSector.SubSectorId = int.Parse(e.CommandArgument.ToString());
                objComSubSector.Mode = "L";
                objWebService = new SectorService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
                i = objWebService.AddSubSector(objComSubSector);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/SectorManagement/ListSubSector.aspx");
                else
                {
                    Response.Write("<script>alert('Lock failed')</script>");
                }
            }
            else
            {
                int i = 0;
                objComSubSector = new ComSubSector();
                objComSubSector.SubSectorId = int.Parse(e.CommandArgument.ToString());
                objComSubSector.Mode = "L";
                objWebService = new SectorService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
                i = objWebService.AddSubSector(objComSubSector);
                if (i > 0)
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/SectorManagement/ListSubSector.aspx");
                else
                {
                    Response.Write("<script>alert('Unlock failed')</script>");
                }
            }
        }
        protected void btnSubSector_Click(object sender, EventArgs e)
        {

            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/SectorManagement/AddSubSector.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        protected void lvSubSector_LayoutCreated(object sender, EventArgs e)
        {
            Label lblSubSectorName = (Label)lvSubSector.FindControl("lblSubSectorName");
            lblSubSectorName.Text = GetLabel("SUB SECTOR NAME");
            Label lblSubSectorCode = (Label)lvSubSector.FindControl("lblSubSectorCode");
            lblSubSectorCode.Text = GetLabel("SUB SECTOR CODE");
            Label lblSectorName = (Label)lvSubSector.FindControl("lblSectorName");
            lblSectorName.Text = GetLabel("SECTOR NAME");
            Label lblStatus = (Label)lvSubSector.FindControl("Status");
            lblStatus.Text = GetLabel("STATUS");
            Label action = (Label)lvSubSector.FindControl("lblAction");
            action.Text = GetLabel("Action");
        }
    }
}