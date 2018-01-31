using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI;
using MISUI.ServiceBudgetDonar;
using MISUI.ServiceLogin;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUI.ServiceSectorMgmt;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;
using MISUICOMMON.HelperClass;
using ComSubSector = MISUI.ServiceSectorMgmt.ComSubSector;
using EntitySubSector = MISUI.ServiceProject.ComSubSector;



namespace MISUI.Modules.ProjectManagement
{
    public partial class AddEditProject : Base
    {
        private ProjectService wbs = null;
        private ComProjectBO objProjectBO = null;
        //private ProjectVerificationBO projectVerificationBo = null;
        //public static int projectId = 0;
        DataTable dtA = new DataTable();
        private DataTable dtPopulateBudgetHead = null;
        private Service1 objService1 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //enabled only for npc users
            if (Session["office_id"].ToInt32() == 2)
            {
                ddlBudgetHead.Enabled = true;
            }

            if (!IsPostBack)
            {
                //PopulateBudgetHead();
                PopulateSector();
                PopulateSahashrabdiBikashLakshya();
                PopulateDigoBikashLakshya();
                if (Request.QueryString["enc"] != null)
                {

                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["id"] != null)
                        {
                            Session["projectId"] = objQueryString["id"].ToInt32();
                            string id = Session["projectId"].ToString();
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
                    if (Session["role_id"].ToInt32() == 12 || Session["role_id"].ToInt32() == 13 || Session["role_id"].ToInt32() == 14 || Session["role_id"].ToInt32() == 15)
                    {
                        btnSave.Enabled = false;
                        btnAddSansodhan.Enabled = false;
                        btnSave.Visible = false;
                        btnAddSansodhan.Visible = false;
                    }
                    if (Session["projectId"].ToInt32() > 0)
                    {
                        PopulateProjectDetails(Session["projectId"].ToInt32());
                    }
                }

                ddlMinistry.Enabled = true;
                PopulateMinistries();

                if (Session["ministry_id"].ToInt32() > 0)
                {
                    ddlMinistry.Enabled = false;
                    ddlMinistry.SelectedValue = Session["ministry_id"].ToString();
                }
                else
                {
                    if (Session["projectId"].ToInt32() > 0)
                    {
                        ddlMinistry.SelectedValue = Session["project_ministry_id"].ToString();
                    }
                    else
                    {
                        ddlMinistry.SelectedValue = "4"; // default MoFALD
                    }
                    
                }
                PopulateBudgetHead();
            }
        }

        private void PopulateMinistries()
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            Session["dtMinistries"] = objService1.PopulateMinistries();
            DataTable dtMinistries = (DataTable)Session["dtMinistries"];
            if (dtMinistries != null && dtMinistries.Rows.Count > 0)
            {
                ddlMinistry.DataSource = dtMinistries;
                if (Session["LanguageSetting"].ToString() == "Nepali")
                {
                    ddlMinistry.DataTextField = "OFFICE_NEP_NAME";
                }
                else
                {
                    ddlMinistry.DataTextField = "OFFICE_ENG_NAME";
                }

                ddlMinistry.DataValueField = "OFFICE_ID";
                ddlMinistry.DataBind();
                ddlMinistry.Items.Insert(0, "--छान्नुहोस्--");

            }
        }



        private void PopulateBudgetHead()
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();

            //// for project/program/pariyojana users
            //if (Session["office_type_id"].ToInt32() == 4 || Session["office_type_id"].ToInt32() == 5 ||
            //    Session["office_type_id"].ToInt32() == 6)
            //{
            //    /*dtPopulateBudgetHead =
            //        objService1.PopulateAllBudgetHeadsByOfficeId(Session["LanguageSetting"].ToString(),
            //            Session["office_id"].ToInt32());*/
            //    dtPopulateBudgetHead =
            //        objService1.PopulateAllBudgetHeadsByUserId(Session["LanguageSetting"].ToString(),
            //            Session["user_id"].ToInt32());
            //}
            ////for npc users and others; 
            //else
            //{
            //    dtPopulateBudgetHead =
            //        objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(),
            //            Session["ministry_id"].ToInt32());
            //}

            // for project/program admin and data entry
            if (Session["role_id"].ToInt32() == 4 || Session["role_id"].ToInt32() == 6)
            {
                /*dtPopulateBudgetHead =
                    objService1.PopulateAllBudgetHeadsByOfficeId(Session["LanguageSetting"].ToString(),
                        Session["office_id"].ToInt32());*/
                dtPopulateBudgetHead =
                    objService1.PopulateAllBudgetHeadsByUserId(Session["LanguageSetting"].ToString(),
                        Session["user_id"].ToInt32());
            }
            //for npc users and others; 
            else
            {
                int ministryId = ddlMinistry.SelectedValue.ToInt32();
                dtPopulateBudgetHead =
                    objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(),
                        ministryId);
            }

            if (dtPopulateBudgetHead != null && dtPopulateBudgetHead.Rows.Count > 0)
            {
                ddlBudgetHead.DataSource = dtPopulateBudgetHead;
                ddlBudgetHead.DataTextField = "BUDGET_HEAD_NAME";
                ddlBudgetHead.DataValueField = "BUDGET_HEAD_ID";
                ddlBudgetHead.DataBind();
                ddlBudgetHead.Items.Insert(0, "--छान्नुहोस्--");
            }

        }

        private void PopulateSector()
        {
            ComSubSector objComSubSector = new ComSubSector();
            SectorService objWebService = new SectorService();
            DataTable dtPopulateSector = null;
            objComSubSector.Lang = Session["LanguageSetting"].ToString();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
            dtPopulateSector = objWebService.PopulateAllSectors(objComSubSector);
            if (dtPopulateSector != null && dtPopulateSector.Rows.Count > 0)
            {
                ddlSector.DataSource = dtPopulateSector;
                ddlSector.DataValueField = "SECTOR_ID";
                ddlSector.DataTextField = "SECTOR_NAME";
                ddlSector.DataBind();
                ddlSector.Items.Insert(0, "--छान्नुहोस्--");
            }


        }

        private void PopulateSahashrabdiBikashLakshya()
        {
            ComProjectBO obj = new ComProjectBO();
            obj.Lang = Session["LanguageSetting"].ToString();
            DataTable DtBikashLakshya = null;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            DtBikashLakshya = wbs.PopulateSahashrabdiBikashLakshya(obj);
            if (DtBikashLakshya != null && DtBikashLakshya.Rows.Count > 0)
            {
                ddlSahasabdiBikashLakshya.DataSource = DtBikashLakshya;
                ddlSahasabdiBikashLakshya.DataTextField = "LAKSHYA_NAME";
                ddlSahasabdiBikashLakshya.DataValueField = "LAKSHYA_ID";
                ddlSahasabdiBikashLakshya.DataBind();
                ddlSahasabdiBikashLakshya.Items.Insert(0, "--छान्नुहोस्--");
            }
        }
        private void PopulateSahashrabdiBikashGantabya()
        {
            ComProjectBO obj = new ComProjectBO();
            obj.Lang = Session["LanguageSetting"].ToString();
            DataTable DtBikashGantabya = null;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            obj.SahasabdiBikashLakshya = ddlSahasabdiBikashLakshya.SelectedValue.ToInt32();
            DtBikashGantabya = wbs.PopulateSahashrabdiBikashGantabya(obj);
            if (DtBikashGantabya != null && DtBikashGantabya.Rows.Count > 0)
            {
                ddlSahasabdiBikashGantabya.DataSource = DtBikashGantabya;
                ddlSahasabdiBikashGantabya.DataTextField = "GANTABYA_NAME";
                ddlSahasabdiBikashGantabya.DataValueField = "GANTABYA_ID";
                ddlSahasabdiBikashGantabya.DataBind();
                ddlSahasabdiBikashGantabya.Items.Insert(0, "--छान्नुहोस्--");
            }
        }
        private void PopulateSahashrabdiBikashSuchak()
        {
            ComProjectBO obj = new ComProjectBO();
            obj.Lang = Session["LanguageSetting"].ToString();
            DataTable DtBikashSuchak = null;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            obj.SahasabdiBikashGantabya = ddlSahasabdiBikashGantabya.SelectedValue.ToInt32();
            DtBikashSuchak = wbs.PopulateSahashrabdiBikashSuchak(obj);
            if (DtBikashSuchak != null && DtBikashSuchak.Rows.Count > 0)
            {
                ddlSahasabdiBikashSuchak.DataSource = DtBikashSuchak;
                ddlSahasabdiBikashSuchak.DataTextField = "SUCHAK_NAME";
                ddlSahasabdiBikashSuchak.DataValueField = "SUCHAK_ID";
                ddlSahasabdiBikashSuchak.DataBind();
                ddlSahasabdiBikashSuchak.Items.Insert(0, "--छान्नुहोस्--");
            }
        }

        private void PopulateDigoBikashLakshya()
        {
            ComProjectBO obj = new ComProjectBO();
            obj.Lang = Session["LanguageSetting"].ToString();
            DataTable dtDigoBksLakshya = null;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtDigoBksLakshya = wbs.PopulateDigoBikashLakshya(obj);
            if (dtDigoBksLakshya != null && dtDigoBksLakshya.Rows.Count > 0)
            {
                ddlDigoBikashLakshya.DataSource = dtDigoBksLakshya;
                ddlDigoBikashLakshya.DataTextField = "DIGO_LAKSHYA_NAME";
                ddlDigoBikashLakshya.DataValueField = "DIGO_LAKSHYA_ID";
                ddlDigoBikashLakshya.DataBind();
                ddlDigoBikashLakshya.Items.Insert(0, "--छान्नुहोस्--");
            }
        }

        private void PopulateProjectDetails(int projectId)
        {
            DataTable dtProjectSansodhan = null;
            ComProjectBO obj = new ComProjectBO();
            DataTable dtPopulateProjectDetails = null;
            obj.ProjectId = projectId;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dtPopulateProjectDetails = wbs.PopulateProjectDetails(obj);
            if (dtPopulateProjectDetails != null && dtPopulateProjectDetails.Rows.Count > 0)
            {
                ddlBudgetHead.SelectedValue = dtPopulateProjectDetails.Rows[0]["BUDGET_HEAD_ID"].ToString();
                txtAyojanaNepName.Text = dtPopulateProjectDetails.Rows[0]["PROJECT_NEP_NAME"].ToString();
                txtAyojanaEngName.Text = dtPopulateProjectDetails.Rows[0]["PROJECT_ENG_NAME"].ToString();
                txtAyojanaLakshya.Text = dtPopulateProjectDetails.Rows[0]["PROJECT_LAKSHYA"].ToString();
                txtAyojanaUdeshya.Text = dtPopulateProjectDetails.Rows[0]["PROJECT_UDESHYA"].ToString();
                txtAyojanaPratifal.Text = dtPopulateProjectDetails.Rows[0]["PROJECT_PRATIFAL"].ToString();
                txtAyojanaKriyakalap.Text = dtPopulateProjectDetails.Rows[0]["PROJECT_MAIN_ACTIVITY"].ToString();
                rblKaryakramPrakar.SelectedValue = dtPopulateProjectDetails.Rows[0]["PROJECT_PROGRAM_TYPE"].ToString();
                txtSuruMiti.Text = dtPopulateProjectDetails.Rows[0]["SURU_MITI"].ToString();
                txtAyojanaSampannaMiti.Text = dtPopulateProjectDetails.Rows[0]["SAMPAANA_MITI"].ToString();
                rbdJalBayuSanket.SelectedValue = dtPopulateProjectDetails.Rows[0]["JALVAYU_SANKET"].ToString();
                rbdYojanaRananiti.SelectedValue = dtPopulateProjectDetails.Rows[0]["YOJANA_RANANITI_NO"].ToString();
                lblModification.Text = dtPopulateProjectDetails.Rows[0]["MODIFIED_DATE"].ToDateTime().ToString("D");
                lblModifiedBy.Text = dtPopulateProjectDetails.Rows[0]["MODIFIED_BY"].ToString();
                /* txtAyojanaSampannaMitiPratham.Text =dtPopulateProjectDetails.Rows[0]["SAMPAANA_MITI1"].ToString();
                 txtAyojanaSampannaMitiDoshro.Text =dtPopulateProjectDetails.Rows[0]["SAMPAANA_MITI2"].ToString();
                 txtAyojanaSampannaMitiTeshro.Text =dtPopulateProjectDetails.Rows[0]["SAMPAANA_MITI3"].ToString();*/
                ddlSector.SelectedValue = dtPopulateProjectDetails.Rows[0]["SECTOR_ID"].ToString();
                Session["project_ministry_id"] = dtPopulateProjectDetails.Rows[0]["MINISTRY_ID"].ToInt32();

                SectorService objWebService = new SectorService();
                ComSubSector objComSubSector = new ComSubSector();
                DataTable dtPopulateSubSector = null;
                objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
                objComSubSector.SectorId = dtPopulateProjectDetails.Rows[0]["SECTOR_ID"].ToInt32();
                objComSubSector.Lang = Session["LanguageSetting"].ToString();
                dtPopulateSubSector = objWebService.PopulateSubSectorsBySectorId(objComSubSector);
                if (dtPopulateSubSector != null && dtPopulateSubSector.Rows.Count > 0)
                {
                    ddlSubSector.DataSource = dtPopulateSubSector;
                    ddlSubSector.DataTextField = "SUB_SECTOR_NAME";
                    ddlSubSector.DataValueField = "ACTIVITY_SUB_SECTOR_ID";
                    ddlSubSector.DataBind();
                    ddlSubSector.Items.Insert(0, "छान्नुहोस्");
                }
                hidSubSector.Value = ddlSubSector.SelectedValue = dtPopulateProjectDetails.Rows[0]["SUB_SECTOR_ID"].ToString();
                ProjectService objPs = new ProjectService();
                EntitySubSector objCss = new EntitySubSector();
                DataTable dtPopulateRananiti = null;
                objPs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                objCss.SubSectorId = ddlSubSector.SelectedValue.ToInt32();
                objCss.Lang = Session["LanguageSetting"].ToString();
                dtPopulateRananiti = objPs.PopulateRananitiBySubSectorId(objCss);
                if (dtPopulateRananiti != null && dtPopulateRananiti.Rows.Count > 0)
                {
                    ddlRananiti.DataSource = dtPopulateRananiti;
                    ddlRananiti.DataTextField = "RANANITI_NAME";
                    ddlRananiti.DataValueField = "RANANITI_ID";
                    ddlRananiti.DataBind();
                    ddlRananiti.Items.Insert(0, "छान्नुहोस्");
                }

                hidRananiti.Value = ddlRananiti.SelectedValue = dtPopulateProjectDetails.Rows[0]["RANANITI_ID"].ToString();

                objPs = new ProjectService();
                ComProjectBO objComProjectBO = new ComProjectBO();
                DataTable dtPopulateKaryaniti = new DataTable();
                objPs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                objComProjectBO.Rananiti = ddlRananiti.SelectedValue.ToInt32();
                objComProjectBO.Lang = Session["LanguageSetting"].ToString();
                dtPopulateKaryaniti = objPs.PopulateKaryanitiByRananitiId(objComProjectBO);
                if (dtPopulateKaryaniti != null && dtPopulateKaryaniti.Rows.Count > 0)
                {
                    ddlKaryaniti1.DataSource = dtPopulateKaryaniti;
                    ddlKaryaniti1.DataTextField = "KARYANITI_NAME";
                    ddlKaryaniti1.DataValueField = "KARYANITI_ID";
                    ddlKaryaniti1.DataBind();
                    ddlKaryaniti1.Items.Insert(0, "छान्नुहोस्");
                    ddlKaryaniti2.DataSource = dtPopulateKaryaniti;
                    ddlKaryaniti2.DataTextField = "KARYANITI_NAME";
                    ddlKaryaniti2.DataValueField = "KARYANITI_ID";
                    ddlKaryaniti2.DataBind();
                    ddlKaryaniti2.Items.Insert(0, "छान्नुहोस्");
                    ddlKaryaniti3.DataSource = dtPopulateKaryaniti;
                    ddlKaryaniti3.DataTextField = "KARYANITI_NAME";
                    ddlKaryaniti3.DataValueField = "KARYANITI_ID";
                    ddlKaryaniti3.DataBind();
                    ddlKaryaniti3.Items.Insert(0, "छान्नुहोस्");
                }

                hidKaryaniti1.Value = ddlKaryaniti1.SelectedValue = dtPopulateProjectDetails.Rows[0]["KARYANITI_ID1"].ToString();
                hidKaryaniti2.Value = ddlKaryaniti2.SelectedValue = dtPopulateProjectDetails.Rows[0]["KARYANITI_ID2"].ToString();
                hidKaryaniti3.Value = ddlKaryaniti3.SelectedValue = dtPopulateProjectDetails.Rows[0]["KARYANITI_ID3"].ToString();
                //added later
                if (dtPopulateProjectDetails.Rows[0]["SAHASRABDI_OR_DIGO"].ToInt32() == 1)
                {
                    rbdSahaSrabdiDigo.SelectedValue="1";
                    /*sahaSrabdi1.Visible = true;
                    sahaSrabdi2.Visible = true;
                    sahaSrabdi3.Visible = true;
                    digo1.Visible = false;
                    digo2.Visible = false;
                    digo3.Visible = false;*/
                }
                else
                {
                    rbdSahaSrabdiDigo.SelectedValue = "2";
                    /*sahaSrabdi1.Visible = false;
                    sahaSrabdi2.Visible = false;
                    sahaSrabdi3.Visible = false;
                    digo1.Visible = true;
                    digo2.Visible = true;
                    digo3.Visible = true;*/
                }

                ddlSahasabdiBikashLakshya.SelectedValue =
                    dtPopulateProjectDetails.Rows[0]["SAHA_BIKASH_LAKSHYA"].ToString();
               
                ddlDigoBikashLakshya.SelectedValue = dtPopulateProjectDetails.Rows[0]["DIGO_BIKASH_LAKSHYA"].ToString();

                if (dtPopulateProjectDetails.Rows[0]["SAHASRABDI_OR_DIGO"].ToInt32() == 1)
                {
                    PopulateSahashrabdiBikashGantabya();
                }
                else
                {
                    PopulateDigoBikashGantabya();
                }

               /* objPs = new ProjectService();
                objComProjectBO = new ComProjectBO();
                DataTable dtPopulateGantabya = new DataTable();
                DataTable dtPopulateDigoGantabya = new DataTable();

                objPs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                objComProjectBO.SahasabdiBikashLakshya = ddlSahasabdiBikashLakshya.SelectedValue.ToInt32();
                objComProjectBO.Lang = Session["LanguageSetting"].ToString();
                objComProjectBO.DigoBikashLakshya = ddlDigoBikashLakshya.SelectedValue.ToInt32();
                dtPopulateGantabya = objPs.PopulateSahashrabdiBikashGantabya(objComProjectBO);
                dtPopulateDigoGantabya = objPs.PopulateDigoBikashGantabya(objComProjectBO);

                if (dtPopulateGantabya != null && dtPopulateGantabya.Rows.Count > 0)
                {
                    ddlSahasabdiBikashGantabya.DataSource = dtPopulateGantabya;
                    ddlSahasabdiBikashGantabya.DataTextField = "GANTABYA_NAME";
                    ddlSahasabdiBikashGantabya.DataValueField = "GANTABYA_ID";
                    ddlSahasabdiBikashGantabya.DataBind();
                    ddlSahasabdiBikashGantabya.Items.Insert(0, "छान्नुहोस्");

                }*/

                hidSahasabdiBikashGantabya.Value = ddlSahasabdiBikashGantabya.SelectedValue =
                    dtPopulateProjectDetails.Rows[0]["SAHA_BIKASH_GANTABYA"].ToString();

                /*if (dtPopulateDigoGantabya != null && dtPopulateDigoGantabya.Rows.Count > 0)
                {
                    ddlDigoBikashGantabya.DataSource = dtPopulateDigoGantabya;
                    ddlDigoBikashGantabya.DataTextField = "DIGO_GANTABYA_NAME";
                    ddlDigoBikashGantabya.DataValueField = "DIGO_GANTABYA_ID";
                    ddlDigoBikashGantabya.DataBind();
                    ddlDigoBikashGantabya.Items.Insert(0, "छान्नुहोस्");
                }*/
                hidDigoBikashGantavya.Value = ddlDigoBikashGantabya.SelectedValue =
                   dtPopulateProjectDetails.Rows[0]["DIGO_BIKASH_GANTABYA"].ToString();

                if (dtPopulateProjectDetails.Rows[0]["SAHASRABDI_OR_DIGO"].ToInt32() == 1)
                {
                    PopulateSahashrabdiBikashSuchak();
                }
                else
                {
                    PopulateDigoBikashSuchak();
                }

                /*objPs = new ProjectService();
                objComProjectBO = new ComProjectBO();
                DataTable dtPopulateSuchak = new DataTable();
                DataTable dtPopulateDigoSuchak = new DataTable();
                objPs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                objComProjectBO.SahasabdiBikashGantabya = ddlSahasabdiBikashGantabya.SelectedValue.ToInt32();
                objComProjectBO.Lang = Session["LanguageSetting"].ToString();
                objComProjectBO.DigoBikashGantabya = ddlDigoBikashGantabya.SelectedValue.ToInt32();
                dtPopulateSuchak = objPs.PopulateSahashrabdiBikashSuchak(objComProjectBO);
                dtPopulateDigoSuchak = objPs.PopulateDigoBikashSuchak(objComProjectBO);
                if (dtPopulateSuchak != null && dtPopulateSuchak.Rows.Count > 0)
                {
                    ddlSahasabdiBikashSuchak.DataSource = dtPopulateSuchak;
                    ddlSahasabdiBikashSuchak.DataTextField = "SUCHAK_NAME";
                    ddlSahasabdiBikashSuchak.DataValueField = "SUCHAK_ID";
                    ddlSahasabdiBikashSuchak.DataBind();
                    ddlSahasabdiBikashSuchak.Items.Insert(0, "छान्नुहोस्");
                }

                if (dtPopulateDigoSuchak != null && dtPopulateDigoSuchak.Rows.Count > 0)
                {
                    ddlDigoBikashSuchak.DataSource = dtPopulateDigoSuchak;
                    ddlDigoBikashSuchak.DataTextField = "DIGO_SUCHAK_NAME";
                    ddlDigoBikashSuchak.DataValueField = "DIGO_SUCHAK_ID";
                    ddlDigoBikashSuchak.DataBind();
                    ddlDigoBikashSuchak.Items.Insert(0, "छान्नुहोस्");
                }*/


                hidSahasabdiBikashSuchak.Value = ddlSahasabdiBikashSuchak.SelectedValue =
                    dtPopulateProjectDetails.Rows[0]["SAHA_BIKASH_SUCHAK"].ToString();
                hidDigoBikashSuchak.Value =
                    ddlDigoBikashSuchak.SelectedValue =
                    dtPopulateProjectDetails.Rows[0]["DIGO_BIKASH_SUCHAK"].ToString();

                rbdGaribiSankhet.SelectedValue = dtPopulateProjectDetails.Rows[0]["GARIBI_SANKET"].ToString();
                rbdLaingikSankhet.SelectedValue = dtPopulateProjectDetails.Rows[0]["LAINGIK_SANKET"].ToString();
                string AayojanaKisim = dtPopulateProjectDetails.Rows[0]["AAYOJANA_KISIM"].ToString();
                List<string> AayojanaType = AayojanaKisim.Split(new char[] { ',' }).ToList<string>();

                for (int i = 0; i < chkAyojanaKisim.Items.Count; i++)
                {
                    for (int j = 0; j < AayojanaType.Count; j++)
                    {
                        if (chkAyojanaKisim.Items[i].Value == AayojanaType[j])
                        {
                            chkAyojanaKisim.Items[i].Selected = true;
                            break;
                        }
                    }
                }
                rbdMadhyaKharchaYojana.SelectedValue = dtPopulateProjectDetails.Rows[0]["PRIORITY"].ToString();
                txtKaryanayanNikaya.Text = dtPopulateProjectDetails.Rows[0]["NIKAAYA"].ToString();
                txtAyojanaLagat.Text = dtPopulateProjectDetails.Rows[0]["KUL_LAAGAT"].ToString();
                if (dtPopulateProjectDetails.Rows[0]["IS_ENABLE"].ToInt32() == 1)
                {
                    chkEnable.Checked = true;
                }
                else
                {
                    chkEnable.Checked = false;
                }
                obj = new ComProjectBO();
                obj.ProjectId = projectId;
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                dtProjectSansodhan = wbs.PopulateProjectSansodhan(obj);
                dtA = dtProjectSansodhan;
                if (dtProjectSansodhan != null && dtProjectSansodhan.Rows.Count > 0)
                {
                    rptSansodhan.DataSource = dtProjectSansodhan;
                    rptSansodhan.DataBind();
                    foreach (RepeaterItem rptItem in rptSansodhan.Items)
                    {
                        TextBox txtSansodhanDate = new TextBox();
                        txtSansodhanDate = (TextBox)rptItem.FindControl("txtSansodhanDate");
                    }
                }
                else
                {

                    dtA.Clear();
                    DataRow drB = dtA.NewRow();
                    drB["SANSODHAN_DATE"] = "";
                    dtA.Rows.Add(drB);

                    rptSansodhan.DataSource = dtA;
                    rptSansodhan.DataBind();
                }
            }
        }

        private void PopulateDigoBikashSuchak()
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateSuchak = new DataTable();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.DigoBikashGantabya = ddlDigoBikashGantabya.SelectedValue.ToInt32();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            dtPopulateSuchak = objWebService.PopulateDigoBikashSuchak(objComProjectBO);
            if (dtPopulateSuchak != null && dtPopulateSuchak.Rows.Count > 0)
            {
                ddlDigoBikashSuchak.DataSource = dtPopulateSuchak;
                ddlDigoBikashSuchak.DataTextField = "DIGO_SUCHAK_NAME";
                ddlDigoBikashSuchak.DataValueField = "DIGO_SUCHAK_ID";
                ddlDigoBikashSuchak.DataBind();
                ddlDigoBikashSuchak.Items.Insert(0, "--छान्नुहोस्--");
            }
        }

        private void PopulateDigoBikashGantabya()
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateGantabya = new DataTable();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.DigoBikashLakshya = ddlDigoBikashLakshya.SelectedValue.ToInt32();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            dtPopulateGantabya = objWebService.PopulateDigoBikashGantabya(objComProjectBO);
            if (dtPopulateGantabya != null && dtPopulateGantabya.Rows.Count > 0)
            {
                ddlDigoBikashGantabya.DataSource = dtPopulateGantabya;
                ddlDigoBikashGantabya.DataTextField = "DIGO_GANTABYA_NAME";
                ddlDigoBikashGantabya.DataValueField = "DIGO_GANTABYA_ID";
                ddlDigoBikashGantabya.DataBind();
                ddlDigoBikashGantabya.Items.Insert(0,"--छान्नुहोस्--");
            }
        }

        protected void btnAddEditProject_Click(object sender, EventArgs e)
        {
            objProjectBO = new ComProjectBO();
            objProjectBO.UserId = Session["user_id"].ToInt32();
            objProjectBO.OfficeId = Session["office_id"].ToInt32();

            int i = 0;
            objProjectBO.BudgetHeadId = ddlBudgetHead.SelectedValue.ToInt32();
            objProjectBO.AyojanaEngName = txtAyojanaEngName.Text;
            objProjectBO.AjojanaNepName = txtAyojanaNepName.Text;
            objProjectBO.AyojanaLakshya = txtAyojanaLakshya.Text;
            objProjectBO.AyojanaUdeshya = txtAyojanaUdeshya.Text;
            objProjectBO.AyojanaPratifal = txtAyojanaPratifal.Text;
            objProjectBO.AyojanaKriyakalap = txtAyojanaKriyakalap.Text;
            objProjectBO.KaryakramPrakar = rblKaryakramPrakar.SelectedValue.ToInt32();
            objProjectBO.SuruMiti = txtSuruMiti.Text;
            objProjectBO.AyojanaSampannaMiti = txtAyojanaSampannaMiti.Text;
            objProjectBO.Sector = ddlSector.SelectedValue.ToInt32();
            objProjectBO.SubSector = hidSubSector.Value.ToInt32();
            objProjectBO.Rananiti = hidRananiti.Value.ToInt32();
            objProjectBO.Karyaniti1 = hidKaryaniti1.Value.ToInt32();
            objProjectBO.Karyaniti2 = hidKaryaniti2.Value.ToInt32();
            objProjectBO.Karyaniti3 = hidKaryaniti3.Value.ToInt32();
            if (rbdSahaSrabdiDigo.SelectedValue=="1")
            {
                //sahashrabdi selected
                objProjectBO.SahasrabdiOrDigo = 1;
                objProjectBO.SahasabdiBikashGantabya = hidSahasabdiBikashGantabya.Value.ToInt32();
                objProjectBO.SahasabdiBikashSuchak = hidSahasabdiBikashSuchak.Value.ToInt32();
                objProjectBO.SahasabdiBikashLakshya = ddlSahasabdiBikashLakshya.SelectedValue.ToInt32();
                /*objProjectBO.DigoBikashGantabya = 0;
                objProjectBO.DigoBikashSuchak = 0;
                objProjectBO.DigoBikashLakshya = 0;*/
            }
            else
            {
                //digo selected
                objProjectBO.SahasrabdiOrDigo = 2;
                objProjectBO.DigoBikashGantabya = hidDigoBikashGantavya.Value.ToInt32();
                objProjectBO.DigoBikashSuchak = hidDigoBikashSuchak.Value.ToInt32();
                objProjectBO.DigoBikashLakshya = ddlDigoBikashLakshya.SelectedValue.ToInt32();
                /*objProjectBO.SahasabdiBikashGantabya = 0;
                objProjectBO.SahasabdiBikashSuchak = 0;
                objProjectBO.SahasabdiBikashLakshya = 0;*/
            }
            
            objProjectBO.GaribiSankhet = rbdGaribiSankhet.SelectedValue.ToInt32();
            objProjectBO.LaingikSankhet = rbdLaingikSankhet.SelectedValue.ToInt32();
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objProjectBO.ModifiedBy = Session["username"].ToString();
            objProjectBO.ModifiedDate = DateTime.Now;
            if (Session["projectId"].ToInt32() > 0)
            {
                objProjectBO.ProjectId = Session["projectId"].ToInt32();
                objProjectBO.Mode = "U";
            }
            else
            {
                objProjectBO.Mode = "I";
            }
            string ayojanaKishim = string.Empty;
            foreach (ListItem it in chkAyojanaKisim.Items)
                if (it.Selected)
                {
                    ayojanaKishim += it.Value + ",";
                }

            objProjectBO.AyojanaKishim = ayojanaKishim;
            objProjectBO.Priority = rbdMadhyaKharchaYojana.SelectedValue.ToInt32();
            objProjectBO.AyojanaLagat = txtAyojanaLagat.Text.ToDecimal();
            objProjectBO.KaryanayanNikay = txtKaryanayanNikaya.Text;
            objProjectBO.JalvayuSanket = rbdJalBayuSanket.SelectedValue.ToInt32();
            objProjectBO.YojanaRananitiNo = rbdYojanaRananiti.SelectedValue.ToInt32();
            objProjectBO.IsLocked = 0;
            if (chkEnable.Checked)
                objProjectBO.IsEnable = 1;
            else
            {
                objProjectBO.IsEnable = 0;
            }

            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            DataTable dt = null;
            dt = wbs.GetBudgetOrganizationMapDetails(ddlBudgetHead.SelectedValue.ToInt32());
            objProjectBO.MinistryId = dt.Rows[0]["Ministry_Id"].ToInt32();

            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();

            // int i is the project id here
            i = wbs.AddEditProject(objProjectBO);
            if (i > 0)
            {
                int j = 0;
                //To clear project sansodhan
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = i;
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                j = wbs.ClearProjectSansodhan(objProjectBO);

                TextBox txtSansodhanDate = new TextBox();
                foreach (RepeaterItem rptItem in rptSansodhan.Items)
                {
                    int k = 0;
                    txtSansodhanDate = (TextBox)rptItem.FindControl("txtSansodhanDate");
                    objProjectBO = new ComProjectBO();
                    objProjectBO.ProjectId = i;
                    objProjectBO.SansodhanDate = txtSansodhanDate.Text;
                    wbs = new ProjectService();
                    wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                    k = wbs.SaveProjectSansodhan(objProjectBO);

                }
                Response.Write("<script>alert('Project Details added successfully!')</script>");
                SecureQueryString str = new SecureQueryString();
                str["id"] = i.ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/AddEditProjectCostingTiming.aspx" + str.EncryptedString);
            }
            else
            {
                Response.Write("<script>alert('Project Details addition failed!')</script>");
            }

        }

        protected void btnAddSansodhan_Click(object sender, EventArgs e)
        {
            dtA.Clear();
            dtA.Columns.Add("SANSODHAN_ID");
            dtA.Columns.Add("PROJECT_ID");
            dtA.Columns.Add("SANSODHAN_DATE");

            TextBox txtSansodhanDate = new TextBox();

            foreach (RepeaterItem rptItem in rptSansodhan.Items)
            {
                DataRow drA = dtA.NewRow();
                txtSansodhanDate = (TextBox)rptItem.FindControl("txtSansodhanDate");
                drA["SANSODHAN_DATE"] = txtSansodhanDate.Text;
                if (txtSansodhanDate.Text != "")
                    dtA.Rows.Add(drA);
            }

            DataRow drB = dtA.NewRow();
            drB["SANSODHAN_DATE"] = "";
            dtA.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptSansodhan.DataSource = db;
            rptSansodhan.DataBind();

            rptSansodhan.DataSource = dtA;
            rptSansodhan.DataBind();
        }

        protected void rptSansodhan_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
            }

        }

        protected void ddlMinistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateBudgetHead();
        }
    }
}





