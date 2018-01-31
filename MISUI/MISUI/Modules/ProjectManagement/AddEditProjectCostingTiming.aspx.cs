using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceBudgetDonar;
using MISUI.ServiceLogin;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.ProjectManagement
{
    public partial class AddEditProjectCostingTiming : System.Web.UI.Page
    {
        private DataTable dtPopulateBudgetHead = null;
        private Service1 objService1 = null;
        private ProjectService wbs = null;
        private ComProjectBO objComProject = null;
        private DataTable dtBarshikBadfad = null;
        private DataTable dtAayojanaBadfad = null;
        private DataTable dtParamarsaBibaran = null;
        private DataTable dtA = new DataTable();
        private ComProjectBO objProjectBO = null;
        // private static DataTable dt = null;
        //private static string existingFilename = "";
        //private static string prevPage = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // PopulateBudgetHead();
                Session["prevPage"] = Request.UrlReferrer.ToString();
                rptAayojanaBadfad.DataSource = null;
                rptAayojanaBadfad.DataBind();
                grdUploadedFiles.Visible = false;
                lblFileWarning.Visible = false;
                if (Request.QueryString["enc"] != null)
                {

                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["id"] != null)
                        {
                            Session["projectId"] = objQueryString["id"].ToInt32();
                            SecureQueryString str = new SecureQueryString();
                            str["id"] = Session["projectId"].ToString();
                            string firstUrl = Constants.ConstantAppPath + "/Modules/ProjectManagement/AddEditProject.aspx" + str.EncryptedString;
                            prFstLnk.HRef = firstUrl;
                            string secUrl = Constants.ConstantAppPath +
                                            "/Modules/ProjectManagement/AddEditProjectCostingTiming.aspx" +
                                            str.EncryptedString;
                            prSecLnk.HRef = secUrl;
                            string thirdUrl = Constants.ConstantAppPath +
                                              "/Modules/ProjectManagement/AddEditProjectAdministrativeDetails.aspx" +
                                              str.EncryptedString;
                            prThdLnk.HRef = thirdUrl;
                            string fourthUrl = Constants.ConstantAppPath +
                                               "/Modules/ProjectManagement/AddEditProjectOtherDetails.aspx" +
                                               str.EncryptedString;
                            prFrtLnk.HRef = fourthUrl;
                        }
                    }

                }
                if (Session["role_id"].ToInt32() == 12 || Session["role_id"].ToInt32() == 13 || Session["role_id"].ToInt32() == 14 || Session["role_id"].ToInt32() == 15)
                {
                    btnAddAayojanaBadfad.Enabled = false;
                    btnAddAayojanaBadfad.Visible = false;
                    FileIeeiReport.Enabled = false;
                    FileIeeiReport.Visible = false;
                    btnSaveProjectCostingTiming.Visible = false;
                    btnSaveProjectCostingTiming.Enabled = false;
                }
                  
                if (Session["projectId"].ToInt32() > 0)
                {
                    PopulateProjectCostingTiming(Session["projectId"].ToInt32());
                }
            }
        }
        /* private void PopulateBudgetHead()
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
                 ddlBudgetHead.Items.Insert(0, "--छान्नुहोस्--");
             }

         }*/

        protected void btnAddAayojanaBadfad_Click(object sender, EventArgs e)
        {
            dtA.Clear();
            dtA.Columns.Add("BADFAD_ID");
            dtA.Columns.Add("PROJECT_ID");
            dtA.Columns.Add("DONAR_ID");
            dtA.Columns.Add("PAYMENT_TYPE_ID");
            dtA.Columns.Add("RAKAM");

            DropDownList ddlDonar = new DropDownList();
            DropDownList ddlPaymentType = new DropDownList();
            TextBox txtRakam = new TextBox();

            foreach (RepeaterItem rptItem in rptAayojanaBadfad.Items)
            {
                DataRow drA = dtA.NewRow();
                ddlDonar = (DropDownList)rptItem.FindControl("ddlShrot");
                ddlPaymentType = (DropDownList)rptItem.FindControl("ddlBhuktaniPrakar");
                txtRakam = (TextBox)rptItem.FindControl("txtRakam");
                drA["DONAR_ID"] = ddlDonar.SelectedValue.ToInt32();
                drA["PAYMENT_TYPE_ID"] = ddlPaymentType.SelectedValue.ToInt32();
                drA["RAKAM"] = txtRakam.Text;
                if (txtRakam.Text != "")
                    dtA.Rows.Add(drA);
            }

            DataRow drB = dtA.NewRow();
            drB["DONAR_ID"] = 0;
            drB["PAYMENT_TYPE_ID"] = 0;
            drB["RAKAM"] = "";
            dtA.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptAayojanaBadfad.DataSource = db;
            rptAayojanaBadfad.DataBind();

            rptAayojanaBadfad.DataSource = dtA;
            rptAayojanaBadfad.DataBind();
        }

        protected void rptAayojanaBadfad_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList dll = (DropDownList)e.Item.FindControl("ddlShrot");
                DataTable DtShrot = null;
                BudgetDonarService objWebService = new BudgetDonarService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBudgetDonar();
                DtShrot = objWebService.PopulateAllDonars(Session["LanguageSetting"].ToString());
                if (DtShrot != null && DtShrot.Rows.Count > 0)
                {
                    dll.DataSource = DtShrot;
                    dll.DataTextField = "DONAR_NAME";
                    dll.DataValueField = "DONAR_ID";
                    dll.DataBind();
                    dll.Items.Insert(0, "--छान्नुहोस्--");
                }

                DropDownList ddlBhuktaniPrakar = (DropDownList)e.Item.FindControl("ddlBhuktaniPrakar");
                ComProjectBO obj = null;
                obj = new ComProjectBO();
                obj.Lang = Session["LanguageSetting"].ToString();
                DataTable DtBhuktaniPrakar = null;
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                DtBhuktaniPrakar = wbs.PopulateBhuktaniPrakar(obj);
                if (DtBhuktaniPrakar != null && DtBhuktaniPrakar.Rows.Count > 0)
                {
                    ddlBhuktaniPrakar.DataSource = DtBhuktaniPrakar;
                    ddlBhuktaniPrakar.DataTextField = "PAYMENT_TYPE_NAME";
                    ddlBhuktaniPrakar.DataValueField = "PAYMENT_TYPE_ID";
                    ddlBhuktaniPrakar.DataBind();
                    ddlBhuktaniPrakar.Items.Insert(0, "--छान्नुहोस्--");
                }

                DropDownList ddlDonar = new DropDownList();
                ddlDonar = (DropDownList)e.Item.FindControl("ddlShrot");
                DropDownList ddlPaymentType = new DropDownList();
                ddlPaymentType = (DropDownList)e.Item.FindControl("ddlBhuktaniPrakar");
                ddlDonar.SelectedValue = dtA.Rows[e.Item.ItemIndex]["DONAR_ID"].ToString();
                ddlPaymentType.SelectedValue = dtA.Rows[e.Item.ItemIndex]["PAYMENT_TYPE_ID"].ToString();


            }
        }


        protected void btnSaveProjectCostingTiming_Click(object sender, EventArgs e)
        {
            objProjectBO = new ComProjectBO();
            objProjectBO.UserId = Session["user_id"].ToInt32();
            objProjectBO.OfficeId = Session["office_id"].ToInt32();
            int rowCount = 0;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            rowCount = wbs.CountMaxRows(objProjectBO);

            int i = 0;
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            //objProjectBO.BudgetHeadId = ddlBudgetHead.SelectedValue.ToInt32();
            objProjectBO.ProjectId = Session["projectId"].ToInt32();
            objProjectBO.DistrictNumber = txtDistrictNumber.Text.ToInt32();
            objProjectBO.ElectionAreaNumber = txtElectionAreaNumber.Text.ToInt32();
            objProjectBO.VdcMunNumber = txtVdcMunNumber.Text.ToInt32();
            objProjectBO.KaryanayanBibaran = txtBibaran.Text;
            objProjectBO.ChanautkoAdhar = txtChanautAadhar.Text;
            objProjectBO.SambhaabyataAdhyan = rbdSambhaabyataAdhyan.SelectedValue.ToInt32();
            if (rbdSambhaabyataAdhyan.SelectedValue.ToInt32() == 1)
            {
                objProjectBO.SambhaabyataAdhyanYear = txtAdhyanYear.Text.ToInt32();
                objProjectBO.SambhaabyataAdhyanNiskarsha = txtNiskarsha.Text;
                objProjectBO.SambhaabyataRemarks = txtRemarks.Text;    
            }
            else
            {
                objProjectBO.SambhaabyataRemarks = "उपयोगी नभएको";    
            }
            
            objProjectBO.PayBackPeriod = txtPayBackPeriod.Text;
            objProjectBO.PayBackPeriodRemarks = txtPaybackPeriodRemarks.Text;
            objProjectBO.BenefitCostRatio = txtBenefitCostRatio.Text.ToDecimal();
            objProjectBO.BenefitCostRatioRemarks = txtBenefitCostRatioRemarks.Text;
            objProjectBO.Firr = txtFirr.Text.ToDecimal();
            objProjectBO.FirrRemarks = txtFirrRemarks.Text;
            objProjectBO.Eirr = txtEirr.Text.ToDecimal();
            objProjectBO.EirrRemarks = txtEirrRemarks.Text;
            objProjectBO.NetPresentValue = txtNpv.Text;
            objProjectBO.NetPresentValueRemarks = txtNPVRemarks.Text;
            objProjectBO.CostEffectiveAnalysis = txtCostEffectiveness.Text;
            objProjectBO.CostEffectiveAnalysisRemarks = txtCostEffectivenessRemarks.Text;
            objProjectBO.KaryanoyanNikaaya = txtKaryanoyanNikaaya.Text;
            objProjectBO.EnvironmentalBibaran = rbdEnvironmentalBibaran.SelectedValue.ToInt32();
            objProjectBO.EnvironmentalBibaranRemarks = txtEnvironmentalBibaranRemarks.Text;
            DataTable dt = (DataTable)Session["dt"];
            if (dt != null && dt.Rows.Count > 0)
            {
                objProjectBO.Mode = "U";
            }
            else
            {
                objProjectBO.Mode = "I";
            }

            string allFiles = "";
            ///// file upload remains
            if (FileIeeiReport.HasFile) // CHECK IF ANY FILE HAS BEEN SELECTED.
            {
                HttpFileCollection hfc = Request.Files;


                for (int f = 0; f <= hfc.Count - 1; f++)
                {
                    HttpPostedFile hpf = hfc[f];
                    if (hpf.ContentLength > 0)
                    {
                        string fileName;
                        fileName = DateTime.Now + hpf.FileName;
                        string ext = System.IO.Path.GetExtension(hpf.FileName);
                        var splitseparator = new string[] { ext };
                        var result = Splitstring(fileName, splitseparator);
                        String source = result[0];
                        string str = source + ext;
                        str = Regex.Replace(str, @"/", "_");
                        str = Regex.Replace(str, @":", "_");
                        str = Regex.Replace(str, @" ", "_");
                        str = Regex.Replace(str, @",", "_");
                        String newfolder = Server.MapPath("~") + @"UploadedFiles\";
                        String path = newfolder + str;
                        hpf.SaveAs(path);
                        allFiles += str + ",";
                    }
                }
                objProjectBO.FileName = allFiles;
            }
            else
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    //update case
                    objProjectBO.FileName = Session["existingFilename"].ToString();
                }
                else
                {
                    //insert case
                    objProjectBO.FileName = "";
                }
            }

            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            i = wbs.SaveProjectCostingTiming(objProjectBO);
            if (i > 0)
            {
                int j = 0;
                //To clear project Shrotgat Budget Badfad
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = Session["projectId"].ToInt32();
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                j = wbs.ClearShrotgatBadfad(objProjectBO);

                DropDownList ddlShrot = new DropDownList();
                DropDownList ddlBhuktaniPrakar = new DropDownList();
                TextBox txtRakam = new TextBox();
                foreach (RepeaterItem rptItem in rptAayojanaBadfad.Items)
                {
                    int k = 0;
                    ddlShrot = (DropDownList)rptItem.FindControl("ddlShrot");
                    ddlBhuktaniPrakar = (DropDownList)rptItem.FindControl("ddlBhuktaniPrakar");
                    txtRakam = (TextBox)rptItem.FindControl("txtRakam");
                    objProjectBO = new ComProjectBO();
                    objProjectBO.ProjectId = Session["projectId"].ToInt32();
                    objProjectBO.Shrot = ddlShrot.SelectedValue.ToInt32();
                    objProjectBO.BhuktaniPrakar = ddlBhuktaniPrakar.SelectedValue.ToInt32();
                    objProjectBO.Rakam = txtRakam.Text.ToDecimal();

                    wbs = new ProjectService();
                    wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                    k = wbs.SaveShrotgatBudgetBadfad(objProjectBO);

                }
                Response.Write("<script>alert('Project costing and timing details added successfully!')</script>");
                SecureQueryString str = new SecureQueryString();
                str["id"] = Session["projectId"].ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/AddEditProjectAdministrativeDetails.aspx" + str.EncryptedString);
            }
            else
            {
                Response.Write("<script>alert('Project costing and timing details addition failed!')</script>");
            }
        }
        protected string[] Splitstring(String source, String[] splitseparator)
        {
            String[] result = source.Split(splitseparator, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }


        private void PopulateProjectCostingTiming(int projectId)
        {

            DataTable dtShrotgatAayojanBadfad = null;
            objProjectBO = new ComProjectBO();
            //objProjectBO.BudgetHeadId = ddlBudgetHeadId;
            objProjectBO.ProjectId = projectId;
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            Session["dt"] = wbs.PopulateProjectCostingTiming(objProjectBO);
            DataTable dt = (DataTable)Session["dt"];
            if (dt != null && dt.Rows.Count > 0)
            {
                txtDistrictNumber.Text = dt.Rows[0]["DISTRICT_NUMBER"].ToString();
                txtElectionAreaNumber.Text = dt.Rows[0]["ELECTION_AREA_NUMBER"].ToString();
                txtVdcMunNumber.Text = dt.Rows[0]["VDCMUN_NUMBER"].ToString();
                txtBibaran.Text = dt.Rows[0]["KARYANAYAN_BIBARAN"].ToString();
                txtChanautAadhar.Text = dt.Rows[0]["CHANAUT_ADHAR"].ToString();
                rbdSambhaabyataAdhyan.SelectedValue = dt.Rows[0]["SAMBHAABYATA_ADHYAN"].ToString();
                txtAdhyanYear.Text = dt.Rows[0]["SAMBHAABYATA_ADHYAN_YEAR"].ToString();
                txtNiskarsha.Text = dt.Rows[0]["SAMBHAABYATA_ADHYAN_NISKARSHA"].ToString();
                txtRemarks.Text = dt.Rows[0]["SAMBHAABYATA_REMARKS"].ToString();
                txtPayBackPeriod.Text = dt.Rows[0]["PAYBACK_PERIOD"].ToString();
                txtBenefitCostRatio.Text = dt.Rows[0]["BCR"].ToString();
                txtFirr.Text = dt.Rows[0]["FIRR"].ToString();
                txtEirr.Text = dt.Rows[0]["EIRR"].ToString();
                txtNpv.Text = dt.Rows[0]["NPV"].ToString();
                txtCostEffectiveness.Text = dt.Rows[0]["COST_EFFECTIVE"].ToString();
                txtKaryanoyanNikaaya.Text = dt.Rows[0]["KARYANOYAN_NIKAAYA"].ToString();
                txtPaybackPeriodRemarks.Text = dt.Rows[0]["PAYBACK_PERIOD_REMARKS"].ToString();
                txtBenefitCostRatioRemarks.Text = dt.Rows[0]["BCR_REMARKS"].ToString();
                txtFirrRemarks.Text = dt.Rows[0]["FIRR_REMARKS"].ToString();
                txtEirrRemarks.Text = dt.Rows[0]["EIRR_REMARKS"].ToString();
                txtNPVRemarks.Text = dt.Rows[0]["NPV_REMARKS"].ToString();
                txtCostEffectivenessRemarks.Text = dt.Rows[0]["COST_EFFECTIVE_REMARKS"].ToString();
                rbdEnvironmentalBibaran.SelectedValue = dt.Rows[0]["ENVIRONMENTAL_BIBARAN"].ToString();
                txtEnvironmentalBibaranRemarks.Text = dt.Rows[0]["REMARKS"].ToString();
                if (dt.Rows[0]["FILENAME"].ToString() != "")
                {
                    lblFileWarning.Visible = true;
                    grdUploadedFiles.Visible = true;
                    string fileName = "";
                    Session["existingFilename"] = fileName = dt.Rows[0]["FILENAME"].ToString();
                    DataTable dtFile = new DataTable();
                    dtFile.Columns.Add("FILENAME");
                    List<string> fileList = fileName.Split(new char[] { ',' }).ToList<string>();

                    for (int j = 0; j < fileList.Count - 1; j++)
                    {
                        DataRow dr = dtFile.NewRow();
                        dr[0] = fileList[j];
                        dtFile.Rows.Add(dr);
                    }
                    grdUploadedFiles.DataSource = dtFile;
                    grdUploadedFiles.DataBind();

                }
                else
                {
                    Session["existingFilename"] = "";
                }

                dtShrotgatAayojanBadfad = wbs.PopulateShrotgatAayojanaBadfad(objProjectBO);
                dtA = dtShrotgatAayojanBadfad;
                if (dtShrotgatAayojanBadfad != null && dtShrotgatAayojanBadfad.Rows.Count > 0)
                {
                    rptAayojanaBadfad.DataSource = dtShrotgatAayojanBadfad;
                    rptAayojanaBadfad.DataBind();
                    foreach (RepeaterItem rptItem in rptAayojanaBadfad.Items)
                    {
                        DropDownList ddlShrot = new DropDownList();
                        DropDownList ddlBhuktaniPrakar = new DropDownList();
                        TextBox txtRakam = new TextBox();
                        ddlShrot = (DropDownList)rptItem.FindControl("ddlShrot");
                        ddlBhuktaniPrakar = (DropDownList)rptItem.FindControl("ddlBhuktaniPrakar");
                        txtRakam = (TextBox)rptItem.FindControl("txtRakam");
                    }
                }
                else
                {

                    dtA.Clear();
                    DataRow drB = dtA.NewRow();
                    drB["DONAR_ID"] = 0;
                    drB["PAYMENT_TYPE_ID"] = 0;
                    drB["RAKAM"] = 0;
                    dtA.Rows.Add(drB);

                    rptAayojanaBadfad.DataSource = dtA;
                    rptAayojanaBadfad.DataBind();
                }
            }
        }

        /* protected void ddlBudgetHead_SelectedIndexChanged(object sender, EventArgs e)
         {
              ProjectService objWebService = new ProjectService();
              ComProjectBO objComProjectBO = new ComProjectBO();
              DataTable dtPopulateProject = new DataTable();
              objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
              objComProjectBO.Lang = Session["LanguageSetting"].ToString();
              objComProjectBO.BudgetHeadId = ddlBudgetHead.SelectedValue.ToInt32();
              dtPopulateProject = objWebService.PopulateProjectByBudgetHead(objComProjectBO);
              if (dtPopulateProject != null && dtPopulateProject.Rows.Count > 0)
              {
                  ddlProject.DataSource = dtPopulateProject;
                  ddlProject.DataValueField = "PROJECT_ID";
                  if(Session["LanguageSetting"].ToString()=="Nepali")
                      ddlProject.DataTextField = "PROJECT_NEP_NAME";
                  else
                  {
                      ddlProject.DataTextField = "PROJECT_ENG_NAME";
                  }
                  ddlProject.DataBind();
                  ddlProject.Items.Insert(0,"--छान्नुहोस्--");

                 
              }
            
          }*/

        protected void grdUploadedFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            /*if(e.CommandName=="Delete")
            {
                if (File.Exists(Constants.ConstantAppPath + "/UploadedFiles/" + e.CommandArgument.ToString()))
                {
                    File.Delete(Constants.ConstantAppPath + "/UploadedFiles/" + e.CommandArgument.ToString());
                }
                ViewState["FileName"] = ViewState["FileName"].ToString().Replace(e.CommandArgument+",", "");
            }*/
            if (e.CommandName == "View")
            {

                string url = Constants.ConstantAppPath + "/UploadedFiles/" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + url + "','_blank')", true);

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["prevPage"].ToString());
        }
    }

}