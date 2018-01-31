using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceOutputTarget;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;
using MISUICOMMON.HelperClass;

namespace MISUI.Modules.OutputTargetManagement
{
    public partial class AddOutput : Base
    {
        //private static int outputId = 0;
        //private static DataTable dtPopulateOutput = null;
        private OutputTargetService objWebService = null;
        OutputTarget objOutputTarget = null;
        private Service1 objService1 = null;
        private OutputTarget objComOutputTarget = null;
        private DataTable dtOutput = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateOutputType();
                populateSubSector();
                populateResponsibleBody();
                populateOutput();
               // populateActivities();
                
                SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                if (objQueryString != null)
                {
                    if (objQueryString["id"] != null)
                    {
                        Session["outputId"] = int.Parse(objQueryString["id"]);

                    }
                }

                if (Session["outputId"].ToInt32() == 0)
                {
                    btnAddOutput.Text = "Add Output";

                }

                 
                else
                {
                    populateOutputDetails(Session["outputId"].ToInt32());
                    btnAddOutput.Text = "Update Output";
                }
            }
        }
        private void populateOutput()
        {
            objWebService = new OutputTargetService();
            objComOutputTarget = new OutputTarget();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            objComOutputTarget.Lang = Session["LanguageSetting"].ToString();
            dtOutput = objWebService.PopulateAllOutputs(objComOutputTarget);
            if (dtOutput != null && dtOutput.Rows.Count > 0)
            {
                ddlOutput.DataSource = dtOutput;
                ddlOutput.DataValueField = "ACTIVITY_OUTPUT_ID";
                ddlOutput.DataTextField = "ACTIVITY_OUTPUT_NAME";
                ddlOutput.DataBind();

                ddlOutput.Items.Insert(0,"--छान्नुहोस्--");

            }
        }
        private void populateResponsibleBody()
        {
            /*DataTable dt = new DataTable();
            objOutputTarget = new OutputTarget();
            objOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objWebService = new OutputTargetService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dt = objWebService.PopulateOffice(objOutputTarget);

            if (dt != null && dt.Rows.Count > 0)
            {
                chkResponsibleOffices.DataSource = dt;
                chkResponsibleOffices.DataTextField = "OFFICE_NAME";
                chkResponsibleOffices.DataValueField = "OFFICE_ID";
                chkResponsibleOffices.DataBind();
            }*/
            DataTable dt = new DataTable();
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            dt = objService1.PopulateMinistries();

            if (dt != null && dt.Rows.Count > 0)
            {
                chkResponsibleOffices.DataSource = dt;
                if (Session["LanguageSetting"].ToString() == "Nepali")
                {
                    chkResponsibleOffices.DataTextField = "OFFICE_NEP_NAME";
                }
                else
                {
                    chkResponsibleOffices.DataTextField = "OFFICE_ENG_NAME";

                }

                chkResponsibleOffices.DataValueField = "OFFICE_ID";
                chkResponsibleOffices.DataBind();
            }

        }

        private void populateOutputDetails(int i)
        {
            objWebService = new OutputTargetService();
            objOutputTarget=new OutputTarget();
            objOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objOutputTarget.ActivityOutputId = i;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            Session["dtPopulateOutput"] = objWebService.PopulateOutputById(objOutputTarget);
            DataTable dtPopulateOutput = (DataTable)Session["dtPopulateOutput"];
            if (dtPopulateOutput != null && dtPopulateOutput.Rows.Count > 0)
            {
                txtOutputEngName.Text = dtPopulateOutput.Rows[0]["ACTIVITY_OUTPUT_ENG_NAME"].ToString();
                txtOutputNepName.Text = dtPopulateOutput.Rows[0]["ACTIVITY_OUTPUT_NEP_NAME"].ToString();
                txtOutputCode.Text = dtPopulateOutput.Rows[0]["ACTIVITY_OUTPUT_CODE"].ToString();
                ddlOutput.SelectedValue = dtPopulateOutput.Rows[0]["PARENT_OUTPUT_ID"].ToString();
                ddlOutputType.SelectedValue = dtPopulateOutput.Rows[0]["ACTIVITY_OUTPUT_TYPE_ID"].ToString();
                
                txtToipYear.Text = dtPopulateOutput.Rows[0]["TOIP_YEAR"].ToString();
                ddlSubsector.SelectedValue = dtPopulateOutput.Rows[0]["SUB_SECTOR_ID"].ToString();

                string responsibleOffices = dtPopulateOutput.Rows[0]["RESPONSIBLE_OFFICE_ID"].ToString();
                if (responsibleOffices != "" || responsibleOffices != string.Empty)
                {
                    List<string> offices = responsibleOffices.Split(new char[] { ',' }).ToList<string>();

                    for (int k = 0; k < chkResponsibleOffices.Items.Count; k++)
                    {
                        for (int j = 0; j < offices.Count; j++)
                        {
                            if (chkResponsibleOffices.Items[k].Value == offices[j])
                            {
                                chkResponsibleOffices.Items[k].Selected = true;
                                break;
                            }
                        }
                    }
                }
                //ddlActivity.SelectedValue = dtPopulateOutput.Rows[0]["ACTIVITY_ID"].ToString();
                if (dtPopulateOutput.Rows[0]["ISENABLE"].ToString() == "1")
                {
                    chkIsEnable.Checked = true;
                }
                else
                {
                    chkIsEnable.Checked = false;
                }
            }
           
        }

        private void populateOutputType()
        {
           
            DataTable dt= new DataTable();
            objOutputTarget=new OutputTarget();
            objOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objWebService=new OutputTargetService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dt = objWebService.populateOutputType(objOutputTarget);
            if(dt!=null && dt.Rows.Count>0)
            {
                ddlOutputType.DataSource = dt;
                ddlOutputType.DataTextField = "ACTIVITY_OUTPUT_TYPE_NAME";
                ddlOutputType.DataValueField = "ACTIVITY_OUTPUT_TYPE_ID";
                ddlOutputType.DataBind();
                ddlOutputType.Items.Insert(0,"--Select Output Type--");
            }

        }
        private void populateSubSector()
        {

            DataTable dt = new DataTable();
            objOutputTarget = new OutputTarget();
            objOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objWebService = new OutputTargetService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dt = objWebService.populateSubSector(objOutputTarget);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlSubsector.DataSource = dt;
                ddlSubsector.DataTextField = "ACTIVITY_SUB_SECTOR_NAME";
                ddlSubsector.DataValueField = "ACTIVITY_SUB_SECTOR_ID";
                ddlSubsector.DataBind();
                ddlSubsector.Items.Insert(0, "--Select Sub Sector Type--");
            }
        }

       /* protected void ddlSubSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateActivities(ddlSubsector.SelectedValue.ToInt32());
        }



        private void populateActivities(int i)
        {
            DataTable dt = new DataTable();
            objOutputTarget = new OutputTarget();
            objOutputTarget.Lang = Session["LanguageSetting"].ToString();
            objOutputTarget.SubSectorId = i;
            objWebService = new OutputTargetService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            dt = objWebService.populateActivities(objOutputTarget);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlOutputType.DataSource = dt;
                ddlOutputType.DataTextField = "ACTIVITY_NAME";
                ddlOutputType.DataValueField = "ACTIVITY_ID";
                ddlOutputType.DataBind();
                ddlOutputType.Items.Insert(0, "--Select Activity--");
            }
        }*/

        protected void btnAddOutput_Click(object sender, EventArgs e)
        {
           int i = 0;
            objOutputTarget=new OutputTarget();
            objOutputTarget.ActivityOutputId = Session["outputId"].ToInt32();
            objOutputTarget.ActivityOutputEngName = txtOutputEngName.Text;
            objOutputTarget.ActivityOutputNepName = txtOutputNepName.Text;
            objOutputTarget.ActivityOutputCode = txtOutputCode.Text;
            objOutputTarget.ParentOutputId = ddlOutput.SelectedValue.ToInt32();
            objOutputTarget.ActivityOutputTypeId = ddlOutputType.SelectedValue.ToInt32();
            objOutputTarget.ToipYear = txtToipYear.Text;

            objOutputTarget.SubSectorId = ddlSubsector.SelectedValue.ToInt32();
           // objOutputTarget.ActivityId = ddlActivity.SelectedValue.ToInt32();

            string responsibleOffices = string.Empty;
            foreach (ListItem it in chkResponsibleOffices.Items)
                if (it.Selected)
                {
                    responsibleOffices += it.Value + ",";
                }

            objOutputTarget.ResponsibleOfficeId = responsibleOffices;

            objOutputTarget.IsEnable = (chkIsEnable.Checked) ? 1 : 0;
            objOutputTarget.IsLocked = 0;
            if (Session["outputId"].ToInt32() == 0)
            {
                objOutputTarget.Mode = "I";
            }
            else
            {
                objOutputTarget.Mode = "U";
            }
            objWebService = new OutputTargetService();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOutputTarget();
            i=objWebService.AddOutput(objOutputTarget);
            if (i > 0)
            {
                Response.Write("<script>alert('Activity output added successfully!')</script>");
                Response.Redirect(Constants.ConstantAppPath + "/Modules/OutputTargetManagement/ListOutput.aspx");
            }
            else
            {
                Response.Write("<script>alert('Activity output addition failed!')</script>");
            }


        }
        }

       
    
}