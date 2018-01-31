using System;
using System.Data;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceVdcMun;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;
using VdcMun = MISUI.ServiceVdcMun.VdcMun;

namespace MISUI.Modules.DirectoryManagement
{
    public partial class AddMunVdc : Base
    {
        public static string VdcMunId = "0";
        Service1 wbs = new Service1();
        VdcMunService objVdcMunService=new VdcMunService();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                LoadDistrict();
                SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                if (objQueryString != null)
                {
                    if (objQueryString["id"] != null)
                    {
                       VdcMunId = objQueryString["id"];
                       loadMunVdcDetails(VdcMunId);

                    }
                }
                //button Labels
                btn_Save.Text = GetLabel("Add");
                btn_List.Text = GetLabel("Cancel");
            }
        }

        private void loadMunVdcDetails(string id)
        {
            objVdcMunService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationVdcMun();
            DataTable dtud = objVdcMunService.FetchMunVdcDetailsById(id);
            if (dtud!=null && dtud.Rows.Count > 0)
            {
                txtVMeng.Text = dtud.Rows[0]["VDC_ENG_NAME"].ToString();
                txtVMnep.Text = dtud.Rows[0]["VDC_NEP_NAME"].ToString();
                txtVMcode.Text = dtud.Rows[0]["VDC_CODE"].ToString();
                ddlVdcMunType.SelectedValue = dtud.Rows[0]["VDCMUN_TYPE"].ToString();
                ddlDistrict.SelectedValue = dtud.Rows[0]["DISTRICT_ID"].ToString();
                if (dtud.Rows[0]["ISENABLE"].ToString() == "1")
                {
                    chkIsEnable.Checked = true;
                }
                else
                {
                    chkIsEnable.Checked = false;
                }

            }
        }
      
        private void LoadDistrict()
        {
            DataTable dtd= new DataTable();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            dtd = wbs.FetchDistrict(Session["LanguageSetting"].ToString());
            if (dtd!=null && dtd.Rows.Count>0)
            {
                ddlDistrict.DataSource = dtd;
                ddlDistrict.DataTextField = "DISTRICT_NAME";
                ddlDistrict.DataValueField = "DISTRICT_ID";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0,"Choose District");
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
                VdcMun obj =new VdcMun();
                obj.District = Convert.ToInt32(ddlDistrict.SelectedValue);
                obj.VdcMunNameEng = txtVMeng.Text;
                obj.VdcMunNameNep = txtVMnep.Text;
                obj.VdcMunType = ddlVdcMunType.SelectedValue;
                 obj.VdcMunCode = txtVMcode.Text;
                 if (chkIsEnable.Checked == true)
                     obj.IsEnable = 1;
                 else
                     obj.IsEnable = 0;
            obj.IsLocked = 0;

            if (VdcMunId=="0")
            {
                objVdcMunService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationVdcMun();
                int i = objVdcMunService.InsertVdcMun(obj);
                if (i>0)
                {
                    Response.Write("<script>alert('VDC/MUN added successfully.');</script>");
                    Response.Redirect(Constants.ConstantAppPath+"/Modules/DirectoryManagement/VdcMunList.aspx");
                }
                else
                {
                    Response.Write("<script>alert('VDC/MUN addition failed!');</script>");
                }
            }
            else
            {
                obj.VdcMunId = VdcMunId;
                objVdcMunService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationVdcMun();
                int i = objVdcMunService.UpdateVdcMunById(obj);
                if (i > 0)
                {
                    Response.Write("<script>alert('VDC/MUN updated successfully');</script>");
                    Response.RedirectPermanent(Constants.ConstantAppPath + "/Modules/DirectoryManagement/VdcMunList.aspx");
                }
                else
                {
                    Response.Write("<script>alert('VDC/MUN update failed');</script>");
                }
            }
            
        }

        protected void btn_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("VdcMunList.aspx");
        }

    }
}