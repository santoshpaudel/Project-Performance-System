using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceVdcMun;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.DirectoryManagement
{
    public partial class VdcMunList : Base
    {
        VdcMunService wbs = new VdcMunService();
        protected void Page_Load(object sender, EventArgs e)
        {

            btn_AddNew.Text = GetLabel("Add VDC/Mun");
            if (!IsPostBack)
            {
                LoadAllMunVdc();

            }
        }
       
        private void LoadAllMunVdc()
        {
            DataTable dtvm = new DataTable();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationVdcMun();
            dtvm = wbs.FetchAllVdcMun(Session["LanguageSetting"].ToString());
            Session["vdcList"] = dtvm;
            if (dtvm != null && dtvm.Rows.Count > 0)
            {
                lvVdcMunList.DataSource = dtvm;
                lvVdcMunList.DataBind();
            }
        }


        
        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            // Response.RedirectPermanent("AddMunVdc.aspx");
            SecureQueryString str = new SecureQueryString();
            str["id"] = "0";
            string url = Constants.ConstantAppPath + "/Modules/DirectoryManagement/AddMunVdc.aspx" + str.EncryptedString;
            Response.Redirect(url, false);
        }

        

        protected void lvVdcMunList_LayoutCreated(object sender, EventArgs e)
        {
            /*Label lblVdcMunEngName = (Label)lvVdcMunList.FindControl("lblVdcMunEngName");
            lblVdcMunEngName.Text = GetLabel("VDC/MUN ENGLISH NAME");*/
            Label lblVdcMunName = (Label)lvVdcMunList.FindControl("lblVdcMunName");
            lblVdcMunName.Text = GetLabel("VDC/MUN NAME");
            Label lblVdcMunType = (Label)lvVdcMunList.FindControl("lblVdcMunType");
            lblVdcMunType.Text = GetLabel("VDC/MUN TYPE");
            Label lblVdcCode = (Label)lvVdcMunList.FindControl("lblVdcCode");
            lblVdcCode.Text = GetLabel("VDC/MUN CODE");
            Label status = (Label)lvVdcMunList.FindControl("Status");
            status.Text = GetLabel("STATUS");
            Label action = (Label)lvVdcMunList.FindControl("lblAction");
            action.Text = GetLabel("Action");
        }

        protected void lvVdcMun_ItemEditing(object sender, ListViewEditEventArgs e)
        {
           
        }

        protected void BtnEdit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                SecureQueryString str = new SecureQueryString();
                str["id"] = e.CommandArgument.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/DirectoryManagement/AddMunVdc.aspx" + str.EncryptedString);

            }
            else if (e.CommandName == "delete")
            {
                int id = 0;
                id = Convert.ToInt32(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationVdcMun();
                int a = wbs.DeleteVdcMunById(id);
                if (a > 0)
                {
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/DirectoryManagement/VdcMunList.aspx");
                }
                else
                {
                    Response.Write("<script>alert('VDC/MUN delete failed!')</script>");
                }

            }
            else if (e.CommandName == "lock")
            {
                int id = 0;
                id = int.Parse(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationVdcMun();
                wbs.LockVdcMun(id);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/DirectoryManagement/VdcMunList.aspx");
            }
            else
            {
                int id = 0;
                id = int.Parse(e.CommandArgument.ToString());
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationVdcMun();
                wbs.UnlockVdcMun(id);
                Response.Redirect(Constants.ConstantAppPath + "/Modules/DirectoryManagement/VdcMunList.aspx");
            }
        }
    }
}