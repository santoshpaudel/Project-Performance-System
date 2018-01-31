using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceActivityMgmt;
using MISUI.ServiceLogin;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.ProjectManagement
{
    public partial class AddEditProjectOtherDetails : System.Web.UI.Page
    {
        private Service1 objService1 = null;
        private DataTable dtPopulateBudgetHead = null;
        private DataTable dtParamarsaBibaran = null;
        private DataTable dtAayojanaPramukh = null;
        private DataTable dtThekkaSankhyaRakam = null;
        private DataTable dtParamarshaSankhya = null;
        private ComProjectBO objProjectBO = null;
        private ProjectService wbs = null;
        DataTable dtA = new DataTable();
        DataTable dtAP = new DataTable();
        DataTable dtAT = new DataTable();
        DataTable dtAPS = new DataTable();
        //private static DataTable dt = null;
        //public static int projectId = 0;
        ActivityManagementService objAms = new ActivityManagementService();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PopulateBudgetHead();
                rptParamarsaBibaran.DataSource = null;
                rptParamarsaBibaran.DataBind();
                rptThekkaSankhyaRakam.DataSource = null;
                rptThekkaSankhyaRakam.DataBind();
                BindUnit();
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
                    btnAddAayojanaPramukh.Enabled = false;
                    btnAddAayojanaPramukh.Visible = false;
                    btnAddParamarsaBibaran.Enabled = false;
                    btnAddParamarsaBibaran.Visible = false;
                    btnAddThekkaSankhyaRakam.Enabled = false;
                    btnAddThekkaSankhyaRakam.Visible = false;
                    btnParamarshaSankhya.Visible = false;
                    btnParamarshaSankhya.Enabled = false;
                    btnSaveOthers.Visible = false;
                    btnSaveOthers.Enabled = false;
                }
                if (Session["projectId"].ToInt32() > 0)
                {
                    PopulateOtherDetails(Session["projectId"].ToInt32());
                }
            }
        }

        private void BindUnit()
        {
            ActivityDetailBO objAdb = new ActivityDetailBO();
            objAdb.Lang = Session["LanguageSetting"].ToString();
            objAms.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            DataTable dtUnit = objAms.SelectActivityUnit(objAdb);
            ddlJaggaPraptiUnit.DataSource = dtUnit;
            ddlJaggaPraptiUnit.DataTextField = "UNIT_NAME";
            ddlJaggaPraptiUnit.DataValueField = "UNIT_ID";
            ddlJaggaPraptiUnit.DataBind();
            //ddlJaggaPraptiUnit.Items.Insert(0, "--छान्नुहोस्--");
        }
        /*  private void PopulateBudgetHead()
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

        protected void btnAddParamarsaBibaranRow_Click(object sender, EventArgs e)
        {
            dtA.Clear();
            dtA.Columns.Add("PARAMARSA_BIBARAN_ID");
            dtA.Columns.Add("PROJECT_ID");
            dtA.Columns.Add("FISCAL_YEAR_ID");
            dtA.Columns.Add("RAKAM_SWADESHI");
            dtA.Columns.Add("RAKAM_BIDESHI");

            DropDownList ddlFiscalYear = new DropDownList();
            TextBox txtRakamSwadeshi = new TextBox();
            TextBox txtRakamBideshi = new TextBox();

            foreach (RepeaterItem rptItem in rptParamarsaBibaran.Items)
            {
                DataRow drA = dtA.NewRow();
                ddlFiscalYear = (DropDownList)rptItem.FindControl("ddlAaba");
                txtRakamSwadeshi = (TextBox)rptItem.FindControl("txtRakamSwadeshi");
                txtRakamBideshi = (TextBox)rptItem.FindControl("txtRakamBideshi");
                drA["FISCAL_YEAR_ID"] = ddlFiscalYear.SelectedValue.ToInt32();
                drA["RAKAM_SWADESHI"] = txtRakamSwadeshi.Text;
                drA["RAKAM_BIDESHI"] = txtRakamBideshi.Text;
                if (txtRakamSwadeshi.Text != "")
                    dtA.Rows.Add(drA);
            }

            DataRow drB = dtA.NewRow();
            drB["FISCAL_YEAR_ID"] = 0;
            drB["RAKAM_SWADESHI"] = 0.00;
            drB["RAKAM_BIDESHI"] = 0.00;
            dtA.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptParamarsaBibaran.DataSource = db;
            rptParamarsaBibaran.DataBind();

            rptParamarsaBibaran.DataSource = dtA;
            rptParamarsaBibaran.DataBind();
        }

        protected void rptParamarsaBibaran_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataTable dtFiscalYear = null;
                DropDownList dll = (DropDownList)e.Item.FindControl("ddlAaba");
                ComLogin objComLogin = new ComLogin();
                objComLogin.Lang = Session["LanguageSetting"].ToString();
                LoginService objWebService = new LoginService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationLogin();
                dtFiscalYear = objWebService.PopulateFiscalYear(objComLogin);
                if (dtFiscalYear != null && dtFiscalYear.Rows.Count > 0)
                {
                    dll.DataSource = dtFiscalYear;
                    dll.DataTextField = "FISCAL_YEAR";
                    dll.DataValueField = "FISCAL_YEAR_ID";
                    dll.DataBind();
                    dll.Items.Insert(0, "-- आ.व. छान्नुहोस्--");
                }


                DropDownList ddlFiscalYear = new DropDownList();
                ddlFiscalYear = (DropDownList)e.Item.FindControl("ddlAaba");
                ddlFiscalYear.SelectedValue = dtA.Rows[e.Item.ItemIndex]["FISCAL_YEAR_ID"].ToString();
            }
        }

        protected void btnSaveOthers_Click(object sender, EventArgs e)
        {
            int i = 0;
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = Session["projectId"].ToInt32();
            //objProjectBO.Swadeshi = txtSwadeshi.Text.ToInt32();
            //objProjectBO.Bideshi = txtBideshi.Text.ToInt32();
            //objProjectBO.ThekkaSankhya = txtThekkaSankhya.Text.ToInt32();
            //objProjectBO.ThekkaRakam = txtThekkaRakam.Text.ToDecimal();
            if (chkIsUsable.Checked == true)
            {
                objProjectBO.LavanbitMahila = txtLavanbitMahila.Text.ToInt32();
                objProjectBO.LavanbitBalBalika = txtLavanbitBalBalika.Text.ToInt32();
                objProjectBO.LavanbitJanajati = txtLavanbitJanajati.Text.ToInt32();
                objProjectBO.LavanbitDalit = txtLavanbitDalit.Text.ToInt32();
                objProjectBO.LavanbitMadheshi = txtLavanbitMadhesi.Text.ToInt32();
                objProjectBO.LavanbitMuslim = txtLavanbitMuslim.Text.ToInt32();
                objProjectBO.Anya = txtAnya.Text.ToInt32();
                objProjectBO.LavanbitMahilaKaifiyat = txtLavanbitMahilaKaifiyat.Text;
                objProjectBO.LavanbitBalBalikaKaifiyat = txtLavanbitBalKaifiyat.Text;
                objProjectBO.LavanbitJanajatiKaifiyat = txtLavanbitJanaKaifiyat.Text;
                objProjectBO.LavanbitDalitKaifiyat = txtLavanbitDalitKaifiyat.Text;
                objProjectBO.LavanbitMadhesiKaifiyat = txtLavanbitMadhesiKaifiyat.Text;
                objProjectBO.LavanbitMuslimKaifiyat = txtLavanbitMuslimKaifiyat.Text;
                objProjectBO.LavanbitAnyaKaifiyat = txtAnyaKaifiyat.Text;
                objProjectBO.Shramdin = txtShramDin.Text.ToInt32();
                objProjectBO.Parimaan = txtParimaan.Text.ToDecimal();
                objProjectBO.Yogdan = txtYogdan.Text;
                
            }
            else
            {
                objProjectBO.LavanbitMahila = 0;
                objProjectBO.LavanbitBalBalika = 0;
                objProjectBO.LavanbitJanajati = 0;
                objProjectBO.LavanbitDalit = 0;
                objProjectBO.LavanbitMadheshi = 0;
                objProjectBO.LavanbitMuslim = 0;
                objProjectBO.Anya = 0;
                objProjectBO.LavanbitMahilaKaifiyat = "";
                objProjectBO.LavanbitBalBalikaKaifiyat = "";
                objProjectBO.LavanbitJanajatiKaifiyat = "";
                objProjectBO.LavanbitDalitKaifiyat = "";
                objProjectBO.LavanbitMadhesiKaifiyat = "";
                objProjectBO.LavanbitMuslimKaifiyat = "";
                objProjectBO.LavanbitAnyaKaifiyat = "";
                objProjectBO.Shramdin = 0;
                objProjectBO.Parimaan = 0;
                objProjectBO.Yogdan = "";
                
            }
            
            if(chkIsUsable.Checked==true)
                objProjectBO.IsUsable = 1;
            else
            {
                objProjectBO.IsUsable = 0;
            }
            objProjectBO.JaggaPrapti = txtJaggaPrapti.Text.ToDecimal();
            objProjectBO.JaggaPraptiUnit = ddlJaggaPraptiUnit.SelectedValue.ToInt32();
            DataTable dt = (DataTable)Session["dt"];
            if (dt != null && dt.Rows.Count > 0)
            {
                objProjectBO.Mode = "U";
            }
            else
            {
                objProjectBO.Mode = "I";
            }
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            i = wbs.SaveOtherDetails(objProjectBO);
            if (i > 0)
            {
                int j = 0;
                //To clear project paramarsha bibaran
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = Session["projectId"].ToInt32();
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                j = wbs.ClearParamarshaDetails(objProjectBO);
                DropDownList ddlFiscalYear = new DropDownList();
                TextBox txtRakamSwadeshi = new TextBox();
                TextBox txtRakamBideshi = new TextBox();
                foreach (RepeaterItem rptItem in rptParamarsaBibaran.Items)
                {
                    int k = 0;
                    ddlFiscalYear = (DropDownList)rptItem.FindControl("ddlAaba");
                    txtRakamBideshi = (TextBox)rptItem.FindControl("txtRakamBideshi");
                    txtRakamSwadeshi = (TextBox)rptItem.FindControl("txtRakamSwadeshi");
                    objProjectBO = new ComProjectBO();
                    objProjectBO.ProjectId = Session["projectId"].ToInt32();
                    objProjectBO.FiscalYearId = ddlFiscalYear.SelectedValue.ToInt32();
                    objProjectBO.RakamBideshi = txtRakamBideshi.Text.ToDecimal();
                    objProjectBO.RakamSwadeshi = txtRakamSwadeshi.Text.ToDecimal();

                    wbs = new ProjectService();
                    wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                    k = wbs.SaveParamarshaBibaran(objProjectBO);
                }


                int m = 0;
                //To clear project paramarsha sankhya
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = Session["projectId"].ToInt32();
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                m = wbs.ClearParamarshaSankhya(objProjectBO);

                DropDownList ddlFiscalYearPS = new DropDownList();
                TextBox txtSwadeshiSankhya = new TextBox();
                TextBox txtSwadeshiShramDin = new TextBox();
                TextBox txtBideshiSankhya = new TextBox();
                TextBox txtBideshiShramDin = new TextBox();

                foreach (RepeaterItem rptItem in rptParamarshaSankhya.Items)
                {
                    int k = 0;
                    ddlFiscalYearPS = (DropDownList)rptItem.FindControl("ddlAaba");
                    txtSwadeshiSankhya = (TextBox)rptItem.FindControl("txtSwadeshiSankhya");
                    txtSwadeshiShramDin = (TextBox)rptItem.FindControl("txtSwadeshiShramDin");
                    txtBideshiSankhya = (TextBox)rptItem.FindControl("txtBideshiSankhya");
                    txtBideshiShramDin = (TextBox)rptItem.FindControl("txtBideshiShramDin");
                    objProjectBO = new ComProjectBO();
                    objProjectBO.ProjectId = Session["projectId"].ToInt32();
                    objProjectBO.FiscalYearId = ddlFiscalYearPS.SelectedValue.ToInt32();
                    objProjectBO.Swadeshi = txtSwadeshiSankhya.Text.ToInt32();
                    objProjectBO.Bideshi = txtBideshiSankhya.Text.ToInt32();
                    objProjectBO.SwadeshiShramDin = txtSwadeshiShramDin.Text.ToDecimal();
                    objProjectBO.BideshiShramDin = txtBideshiShramDin.Text.ToDecimal();

                    wbs = new ProjectService();
                    wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                    k = wbs.SaveParamarshaSankhya(objProjectBO);
                }


                //To clear project thekka sankhya
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = Session["projectId"].ToInt32();
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                j = wbs.ClearProjectThekkaSankhya(objProjectBO);

                DropDownList ddlFiscalYearA = new DropDownList();
                TextBox txtThekkaSankhyaA = new TextBox();
                TextBox txtThekkaRakamA = new TextBox();

                foreach (RepeaterItem rptItem in rptThekkaSankhyaRakam.Items)
                {
                    int k = 0;
                    ddlFiscalYearA = (DropDownList)rptItem.FindControl("ddlAaba");
                    txtThekkaSankhyaA = (TextBox)rptItem.FindControl("txtThekkaSankhya");
                    txtThekkaRakamA = (TextBox)rptItem.FindControl("txtThekkaRakam");
                    objProjectBO = new ComProjectBO();
                    objProjectBO.ProjectId = Session["projectId"].ToInt32();
                    objProjectBO.FiscalYearId = ddlFiscalYearA.SelectedValue.ToInt32();
                    objProjectBO.ThekkaSankhya = txtThekkaSankhyaA.Text.ToInt32();
                    objProjectBO.ThekkaRakam = txtThekkaRakamA.Text.ToDecimal();

                    wbs = new ProjectService();
                    wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                    k = wbs.SaveProjectThekkaSankhya(objProjectBO);
                }

                //To clear project Aayojana pramukh
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = Session["projectId"].ToInt32();
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                wbs.ClearAayojanaPramukh(objProjectBO);

                TextBox txtPramukhStartDate = new TextBox();
                TextBox txtPramukhName = new TextBox();

                foreach (RepeaterItem rptItem in rptAayojanaPramukh.Items)
                {
                    txtPramukhStartDate = (TextBox)rptItem.FindControl("txtPramukhStartDate");
                    txtPramukhName = (TextBox)rptItem.FindControl("txtPramukhName");

                    objProjectBO = new ComProjectBO();
                    objProjectBO.ProjectId = Session["projectId"].ToInt32();
                    objProjectBO.PramukhStartDate = txtPramukhStartDate.Text;
                    objProjectBO.PramukhName = txtPramukhName.Text;

                    wbs = new ProjectService();
                    wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                    wbs.SaveAayojanaPramukh(objProjectBO);
                }
                Response.Write("<script>alert('Project details added successfully!')</script>");
                Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/ProjectList.aspx");

            }
            else
            {
                Response.Write("<script>alert('Project  details addition failed!')</script>");
            }
        }

        /*protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptParamarsaBibaran.DataSource = null;
            rptParamarsaBibaran.DataBind();
            PopulateOtherDetails(ddlBudgetHead.SelectedValue.ToInt32(), ddlProject.SelectedValue.ToInt32());
        }*/

        private void PopulateOtherDetails(int projectId)
        {
            DataTable dtParamasrhaBibaran = null;
            objProjectBO = new ComProjectBO();
            //objProjectBO.BudgetHeadId = ddlBudgetHeadId;
            objProjectBO.ProjectId = projectId;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            Session["dt"] = wbs.PopulateOtherDetails(objProjectBO);
            DataTable dt = (DataTable)Session["dt"];
            if (dt != null && dt.Rows.Count > 0)
            {
                //txtSwadeshi.Text = dt.Rows[0]["SWADESHI"].ToString();
                //txtBideshi.Text = dt.Rows[0]["BIDESHI"].ToString();
                //txtThekkaSankhya.Text = dt.Rows[0]["THEKKA_SANKHYA"].ToString();
                //txtThekkaRakam.Text = dt.Rows[0]["THEKKA_RAKAM"].ToString();
                txtLavanbitMahila.Text = dt.Rows[0]["LAVANBIT_MAHILA"].ToString();
                txtLavanbitBalBalika.Text = dt.Rows[0]["LAVANBIT_BALBALIKA"].ToString();
                txtLavanbitDalit.Text = dt.Rows[0]["LAVANBIT_DALIT"].ToString();
                txtLavanbitMadhesi.Text = dt.Rows[0]["LAVANBIT_MADHESI"].ToString();
                txtLavanbitJanajati.Text = dt.Rows[0]["LAVANBIT_JANAJATI"].ToString();
                txtLavanbitMuslim.Text = dt.Rows[0]["LAVANBIT_MUSLIM"].ToString();
                txtAnya.Text = dt.Rows[0]["ANYA"].ToString();

                if (dt.Rows[0]["IS_USABLE"].ToString() == "1")
                    chkIsUsable.Checked = true;
                else
                {
                    chkIsUsable.Checked = false;
                }

                txtLavanbitMahilaKaifiyat.Text = dt.Rows[0]["LAVANBIT_MAHILA_KAIFIYAT"].ToString();
                txtLavanbitBalKaifiyat.Text = dt.Rows[0]["LAVANBIT_BALBALIKA_KAIFIYAT"].ToString();
                txtLavanbitDalitKaifiyat.Text = dt.Rows[0]["LAVANBIT_DALIT_KAIFIYAT"].ToString();
                txtLavanbitMadhesiKaifiyat.Text = dt.Rows[0]["LAVANBIT_JANAJATI_KAIFIYAT"].ToString();
                txtLavanbitJanaKaifiyat.Text = dt.Rows[0]["LAVANBIT_MADHESI_KAIFIYAT"].ToString();
                txtLavanbitMuslimKaifiyat.Text = dt.Rows[0]["LAVANBIT_MUSLIM_KAIFIYAT"].ToString();
                txtAnyaKaifiyat.Text = dt.Rows[0]["ANYA_KAIFIYAT"].ToString();

                txtShramDin.Text = dt.Rows[0]["SHRAMDIN"].ToString();
                txtParimaan.Text = dt.Rows[0]["PARIMAAN"].ToString();
                txtYogdan.Text = dt.Rows[0]["YOGDAN"].ToString();
                txtJaggaPrapti.Text = dt.Rows[0]["JAGGA_PRAPTI"].ToString();
                ddlJaggaPraptiUnit.SelectedValue = dt.Rows[0]["JAGGA_PRAPTI_UNIT"].ToString();
                dtParamarsaBibaran = wbs.PopulateParamarshaBibaran(objProjectBO);
                dtA = dtParamarsaBibaran;
                if (dtParamarsaBibaran != null && dtParamarsaBibaran.Rows.Count > 0)
                {
                    rptParamarsaBibaran.DataSource = dtParamarsaBibaran;
                    rptParamarsaBibaran.DataBind();
                    foreach (RepeaterItem rptItem in rptParamarsaBibaran.Items)
                    {
                        DropDownList ddlFiscalYear = new DropDownList();
                        TextBox txtRakamSwadeshi = new TextBox();
                        TextBox txtRakamBideshi = new TextBox();

                        ddlFiscalYear = (DropDownList)rptItem.FindControl("ddlAaba");
                        txtRakamBideshi = (TextBox)rptItem.FindControl("txtRakamBideshi");
                        txtRakamSwadeshi = (TextBox)rptItem.FindControl("txtRakamSwadeshi");
                    }
                }
                else
                {
                    dtA.Clear();
                    DataRow drB = dtA.NewRow();
                    drB["FISCAL_YEAR_ID"] = 0;
                    drB["RAKAM_SWADESHI"] = 0.0;
                    drB["RAKAM_BIDESHI"] = 0.0;
                    dtA.Rows.Add(drB);
                    rptParamarsaBibaran.DataSource = dtA;
                    rptParamarsaBibaran.DataBind();
                }


                dtParamarshaSankhya = wbs.PopulateParamarshaSankhya(objProjectBO);
                dtAPS = dtParamarshaSankhya;
                if (dtParamarshaSankhya != null && dtParamarshaSankhya.Rows.Count > 0)
                {
                    rptParamarshaSankhya.DataSource = dtParamarshaSankhya;
                    rptParamarshaSankhya.DataBind();
                    foreach (RepeaterItem rptItem in rptParamarshaSankhya.Items)
                    {
                        DropDownList ddlFiscalYear = new DropDownList();
                        TextBox txtSwadeshiSankhya = new TextBox();
                        TextBox txtBideshiSankhya = new TextBox();

                        ddlFiscalYear = (DropDownList)rptItem.FindControl("ddlAaba");
                        txtSwadeshiSankhya = (TextBox)rptItem.FindControl("txtSwadeshiSankhya");
                        txtBideshiSankhya = (TextBox)rptItem.FindControl("txtBideshiSankhya");
                    }
                }
                else
                {
                    dtAPS.Clear();
                    DataRow drB = dtAPS.NewRow();
                    drB["FISCAL_YEAR_ID"] = 0;
                    drB["SWADESHI"] = 0;
                    drB["BIDESHI"] = 0;
                    drB["SWADESHI_SHRAM_DIN"] = 0;
                    drB["BIDESHI_SHRAM_DIN"] = 0;
                    dtAPS.Rows.Add(drB);
                    rptParamarshaSankhya.DataSource = dtAPS;
                    rptParamarshaSankhya.DataBind();
                }


                dtThekkaSankhyaRakam = wbs.PopulateThekkaSankhyaRakam(objProjectBO);
                dtAT = dtThekkaSankhyaRakam;
                if (dtThekkaSankhyaRakam != null && dtThekkaSankhyaRakam.Rows.Count > 0)
                {
                    rptThekkaSankhyaRakam.DataSource = dtThekkaSankhyaRakam;
                    rptThekkaSankhyaRakam.DataBind();
                    foreach (RepeaterItem rptItem in rptThekkaSankhyaRakam.Items)
                    {
                        DropDownList ddlFiscalYear = new DropDownList();
                        TextBox txtThekkaSankhyaA = new TextBox();
                        TextBox txtThekkaRakamA = new TextBox();

                        ddlFiscalYear = (DropDownList)rptItem.FindControl("ddlAaba");
                        txtThekkaSankhyaA = (TextBox)rptItem.FindControl("txtThekkaSankhya");
                        txtThekkaRakamA = (TextBox)rptItem.FindControl("txtThekkaRakam");
                    }
                }
                else
                {
                    dtAT.Clear();
                    DataRow drB = dtAT.NewRow();
                    drB["FISCAL_YEAR_ID"] = 0;
                    drB["THEKKA_SANKHYA"] = 0;
                    drB["THEKKA_RAKAM"] = 0;
                    dtAT.Rows.Add(drB);
                    rptThekkaSankhyaRakam.DataSource = dtAT;
                    rptThekkaSankhyaRakam.DataBind();
                }


                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                dtAayojanaPramukh = wbs.PopulateAayojanaPramukh(objProjectBO);
                dtAP = dtAayojanaPramukh;
                if (dtAayojanaPramukh != null && dtAayojanaPramukh.Rows.Count > 0)
                {
                    rptAayojanaPramukh.DataSource = dtAayojanaPramukh;
                    rptAayojanaPramukh.DataBind();
                    foreach (RepeaterItem rptItem in rptAayojanaPramukh.Items)
                    {
                        TextBox txtPramukhStartDate = new TextBox();
                        TextBox txtPramukhName = new TextBox();

                        txtPramukhStartDate = (TextBox)rptItem.FindControl("txtPramukhStartDate");
                        txtPramukhName = (TextBox)rptItem.FindControl("txtPramukhName");
                    }
                }
                else
                {
                    dtAP.Clear();
                    DataRow drB = dtAP.NewRow();
                    drB["PRAMUKH_START_DATE"] = "";
                    drB["PRAMUKH_NAME"] = "";
                    dtAP.Rows.Add(drB);
                    rptAayojanaPramukh.DataSource = dtAP;
                    rptAayojanaPramukh.DataBind();
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
                 if (Session["LanguageSetting"].ToString() == "Nepali")
                     ddlProject.DataTextField = "PROJECT_NEP_NAME";
                 else
                 {
                     ddlProject.DataTextField = "PROJECT_ENG_NAME";
                 }
                 ddlProject.DataBind();
                 ddlProject.Items.Insert(0, "--छान्नुहोस्--");


             }
         }*/

        protected void rptAayojanaPramukh_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnAddAayojanaPramukh_Click(object sender, EventArgs e)
        {
            dtAP.Clear();
            dtAP.Columns.Add("AAYOJANA_PRAMUKH_ID");
            dtAP.Columns.Add("PROJECT_ID");
            dtAP.Columns.Add("PRAMUKH_START_DATE");
            dtAP.Columns.Add("PRAMUKH_NAME");

            TextBox txtPramukhStartDate = new TextBox();
            TextBox txtPramukhName = new TextBox();

            foreach (RepeaterItem rptItem in rptAayojanaPramukh.Items)
            {
                DataRow drA1 = dtAP.NewRow();
                txtPramukhStartDate = (TextBox)rptItem.FindControl("txtPramukhStartDate");
                txtPramukhName = (TextBox)rptItem.FindControl("txtPramukhName");
                drA1["PRAMUKH_START_DATE"] = txtPramukhStartDate.Text;
                drA1["PRAMUKH_NAME"] = txtPramukhName.Text;
                if (txtPramukhName.Text != "" || txtPramukhStartDate.Text != "")
                    dtAP.Rows.Add(drA1);
            }

            DataRow drB = dtAP.NewRow();
            drB["PRAMUKH_START_DATE"] = "";
            drB["PRAMUKH_NAME"] = "";
            dtAP.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptAayojanaPramukh.DataSource = db;
            rptAayojanaPramukh.DataBind();

            rptAayojanaPramukh.DataSource = dtAP;
            rptAayojanaPramukh.DataBind();
        }

        protected void btnAddThekkaSankhyaRakam_Click(object sender, EventArgs e)
        {
            dtAT.Clear();
            dtAT.Columns.Add("THEKKA_SANKHYA_RAKAM_ID");
            dtAT.Columns.Add("PROJECT_ID");
            dtAT.Columns.Add("FISCAL_YEAR_ID");
            dtAT.Columns.Add("THEKKA_SANKHYA");
            dtAT.Columns.Add("THEKKA_RAKAM");

            DropDownList ddlFiscalYear = new DropDownList();
            TextBox txtThekkaSankhya = new TextBox();
            TextBox txtThekkaRakam = new TextBox();

            foreach (RepeaterItem rptItem in rptThekkaSankhyaRakam.Items)
            {
                DataRow drA = dtAT.NewRow();
                ddlFiscalYear = (DropDownList)rptItem.FindControl("ddlAaba");
                txtThekkaSankhya = (TextBox)rptItem.FindControl("txtThekkaSankhya");
                txtThekkaRakam = (TextBox)rptItem.FindControl("txtThekkaRakam");
                drA["FISCAL_YEAR_ID"] = ddlFiscalYear.SelectedValue.ToInt32();
                drA["THEKKA_SANKHYA"] = txtThekkaSankhya.Text;
                drA["THEKKA_RAKAM"] = txtThekkaRakam.Text;
                if (txtThekkaRakam.Text != "" || txtThekkaSankhya.Text != "")
                    dtAT.Rows.Add(drA);
            }

            DataRow drB = dtAT.NewRow();
            drB["FISCAL_YEAR_ID"] = 0;
            drB["THEKKA_SANKHYA"] = 0;
            drB["THEKKA_RAKAM"] = 0;
            dtAT.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptThekkaSankhyaRakam.DataSource = db;
            rptThekkaSankhyaRakam.DataBind();

            rptThekkaSankhyaRakam.DataSource = dtAT;
            rptThekkaSankhyaRakam.DataBind();
        }

        protected void rptThekkaSankhyaRakam_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataTable dtFiscalYear = null;
                DropDownList dll = (DropDownList)e.Item.FindControl("ddlAaba");
                ComLogin objComLogin = new ComLogin();
                objComLogin.Lang = Session["LanguageSetting"].ToString();
                LoginService objWebService = new LoginService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationLogin();
                dtFiscalYear = objWebService.PopulateFiscalYear(objComLogin);
                if (dtFiscalYear != null && dtFiscalYear.Rows.Count > 0)
                {
                    dll.DataSource = dtFiscalYear;
                    dll.DataTextField = "FISCAL_YEAR";
                    dll.DataValueField = "FISCAL_YEAR_ID";
                    dll.DataBind();
                    dll.Items.Insert(0, "-- आ.व. छान्नुहोस्--");
                }

                DropDownList ddlFiscalYear = new DropDownList();
                ddlFiscalYear = (DropDownList)e.Item.FindControl("ddlAaba");
                ddlFiscalYear.SelectedValue = dtAT.Rows[e.Item.ItemIndex]["FISCAL_YEAR_ID"].ToString();
            }
        }

        protected void btnParamarshaSankhya_Click(object sender, EventArgs e)
        {
            dtAPS.Clear();
            dtAPS.Columns.Add("PARAMARSHA_SANKHYA_ID");
            dtAPS.Columns.Add("PROJECT_ID");
            dtAPS.Columns.Add("FISCAL_YEAR_ID");
            dtAPS.Columns.Add("SWADESHI");
            dtAPS.Columns.Add("SWADESHI_SHRAM_DIN");
            dtAPS.Columns.Add("BIDESHI");
            dtAPS.Columns.Add("BIDESHI_SHRAM_DIN");

            DropDownList ddlFiscalYear = new DropDownList();
            TextBox txtSwadeshiSankhya = new TextBox();
            TextBox txtBideshiSankhya = new TextBox();
            TextBox txtSwadeshiShramDin = new TextBox();
            TextBox txtBideshiShramDin = new TextBox();

            foreach (RepeaterItem rptItem in rptParamarshaSankhya.Items)
            {
                DataRow drA = dtAPS.NewRow();
                ddlFiscalYear = (DropDownList)rptItem.FindControl("ddlAaba");
                txtSwadeshiSankhya = (TextBox)rptItem.FindControl("txtSwadeshiSankhya");
                txtBideshiSankhya = (TextBox)rptItem.FindControl("txtBideshiSankhya");
                txtSwadeshiShramDin = (TextBox)rptItem.FindControl("txtSwadeshiShramDin");
                txtBideshiShramDin = (TextBox)rptItem.FindControl("txtBideshiShramDin");
                drA["FISCAL_YEAR_ID"] = ddlFiscalYear.SelectedValue.ToInt32();
                drA["SWADESHI"] = txtSwadeshiSankhya.Text;
                drA["SWADESHI_SHRAM_DIN"] = txtSwadeshiShramDin.Text;
                drA["BIDESHI"] = txtBideshiSankhya.Text;
                drA["BIDESHI_SHRAM_DIN"] = txtBideshiShramDin.Text;
                dtAPS.Rows.Add(drA);
            }

            DataRow drB = dtAPS.NewRow();
            drB["FISCAL_YEAR_ID"] = 0;
            drB["SWADESHI"] = 0;
            drB["BIDESHI"] = 0;
            drB["SWADESHI_SHRAM_DIN"] = 0;
            drB["BIDESHI_SHRAM_DIN"] = 0;
            dtAPS.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptParamarshaSankhya.DataSource = db;
            rptParamarshaSankhya.DataBind();

            rptParamarshaSankhya.DataSource = dtAPS;
            rptParamarshaSankhya.DataBind();
        }

        protected void rptParamarshaSankhya_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataTable dtFiscalYear = null;
                DropDownList dll = (DropDownList)e.Item.FindControl("ddlAaba");
                ComLogin objComLogin = new ComLogin();
                objComLogin.Lang = Session["LanguageSetting"].ToString();
                LoginService objWebService = new LoginService();
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationLogin();
                dtFiscalYear = objWebService.PopulateFiscalYear(objComLogin);
                if (dtFiscalYear != null && dtFiscalYear.Rows.Count > 0)
                {
                    dll.DataSource = dtFiscalYear;
                    dll.DataTextField = "FISCAL_YEAR";
                    dll.DataValueField = "FISCAL_YEAR_ID";
                    dll.DataBind();
                    dll.Items.Insert(0, "-- आ.व. छान्नुहोस्--");
                }

                DropDownList ddlFiscalYear = new DropDownList();
                ddlFiscalYear = (DropDownList)e.Item.FindControl("ddlAaba");
                ddlFiscalYear.SelectedValue = dtAPS.Rows[e.Item.ItemIndex]["FISCAL_YEAR_ID"].ToString();
            }
        }
    }
}