using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceBarsikKaryekram;
using MISUI.ServiceBudgetDonar;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.BarsikKaryekram
{
    public partial class KaryekramPragati : Base
    {
        private ProjectService wbs = null;
        private ComProjectBO objProjectBO = null;
        private ProjectUpalabdhiBO objUpalabdhi = null;
        private DataTable dtA = new DataTable();
        //private static DataTable dt = null;
        private DataTable dtB = new DataTable();
        private DataTable dtC = new DataTable();
        BarsikKaryekramService objBarsikService = null;

        //private ProjectVerificationBO projectVerificationBo = null;
        //private static int projectId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divContent.Visible = false;
                grdUploadedFiles.Visible = false;
                lblFileWarning.Visible = false;
                if (Request.QueryString["enc"] != null)
                {

                    SecureQueryString objQueryString = new SecureQueryString(Request.QueryString["enc"]);
                    if (objQueryString != null)
                    {
                        if (objQueryString["projectId"] != null)
                        {
                            Session["projectId"] = objQueryString["projectId"].ToInt32();
                        }
                    }

                }
                if (Session["kpChaumasikId"] != null && Session["kpChaumasikId"].ToString() != "0")
                {
                    ddlChaumarsik.SelectedValue = Session["kpChaumasikId"].ToString();
                    //PopulateAllTargets();
                    PopulateAnyaBarshik();
                    PopulateDonarAmountDetails();
                    PopulaterThekaParamarsaDetail();
                    PopulateDataForRepeater();
                    PopulateProblemRepeater();
                    PopulateChaumasikFile();
                    PopulateUpalabdhi();
                    PopulateBarshikBharit();
                }
            }
        }

        protected void PopulateUpalabdhi()
        {
            objUpalabdhi = new ProjectUpalabdhiBO();
            objUpalabdhi.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objUpalabdhi.ProjectId = Session["projectId"].ToInt32();
            DataTable dt = null;
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            dt = objBarsikService.PopulateUpalabdhi(objUpalabdhi);
            if (dt != null && dt.Rows.Count > 0)
            {
                hidUpalabdhId.Value = dt.Rows[0]["UPLABDHI_ID"].ToString();
                txtFirstCUpalabdhi.Text = dt.Rows[0]["FIRST_C_DESC"].ToString();
                txtSecondCUpalabdhi.Text = dt.Rows[0]["SECOND_C_DESC"].ToString();
                txtThirdCUpalabdhi.Text = dt.Rows[0]["THIRD_C_DESC"].ToString();

            }

        }

        protected void PopulateChaumasikFile()
        {
            /* aChaumasikFile.InnerHtml = "";
             aChaumasikFile.HRef = null;*/
            ProjectBarsikThekaParamarsaBO objBo = new ProjectBarsikThekaParamarsaBO();
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            objBo.ProjectId = Session["projectId"].ToInt32();//change after 
            objBo.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objBo.ChaumasikId = ddlChaumarsik.SelectedValue.ToInt32();
            DataTable dtChaumasikFile = objBarsikService.PopulateChaumasikFile(objBo);

            if (dtChaumasikFile != null && dtChaumasikFile.Rows.Count > 0)
            {
                /* aChaumasikFile.InnerHtml = dtChaumasikFile.Rows[0]["FILE_NAME"].ToString();
                 aChaumasikFile.HRef = Constants.ConstantAppPath + "/ChaumasikFiles/" + dtChaumasikFile.Rows[0]["FILE_NAME"];*/
                if (dtChaumasikFile.Rows[0]["FILE_NAME"].ToString() != "")
                {
                    lblFileWarning.Visible = true;
                    grdUploadedFiles.Visible = true;
                    string fileName = "";
                    Session["existingFilename"] = fileName = dtChaumasikFile.Rows[0]["FILE_NAME"].ToString();
                    DataTable dtFile = new DataTable();
                    dtFile.Columns.Add("FILE_NAME");
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
            }
        }
        protected void PopulateBarshikBharit()
        {
            BarsikBharitBo objBarsikBharitBo = new BarsikBharitBo();
            objBarsikBharitBo.ProjectId = Session["projectId"].ToInt32();
            objBarsikBharitBo.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            DataTable dt = null;
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            dt = objBarsikService.PopulateBarshikBharit(objBarsikBharitBo);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (ddlChaumarsik.SelectedValue == "1")
                    txtYesChaumashikBharitLakshya.Text = dt.Rows[0]["FIRST_BHARIT_LAKSHYA"].ToString();
                if (ddlChaumarsik.SelectedValue == "2")
                    txtYesChaumashikBharitLakshya.Text = dt.Rows[0]["SECOND_BHARIT_LAKSHYA"].ToString();
                if (ddlChaumarsik.SelectedValue == "3")
                    txtYesChaumashikBharitLakshya.Text = dt.Rows[0]["THIRD_BHARIT_LAKSHYA"].ToString();
            }
        }

        protected void PopulateAnyaBarshik()
        {
            ProjectBarshikAnyaBO objProjectBarshikAnya = new ProjectBarshikAnyaBO();
            objProjectBarshikAnya.ProjectId = Session["projectId"].ToInt32();
            objProjectBarshikAnya.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            DataTable dt = null;
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            dt = objBarsikService.PopulateBarshikAnya(objProjectBarshikAnya);
            if (ddlChaumarsik.SelectedValue == "1")
            {
                txtAnyaFirst.Enabled = true;
                txtAnyaSecond.Enabled = false;
                txtAnyaThird.Enabled = false;
            }
            else if (ddlChaumarsik.SelectedValue == "2")
            {
                txtAnyaFirst.Enabled = false;
                txtAnyaThird.Enabled = false;
                txtAnyaSecond.Enabled = true;
            }
            else
            {
                txtAnyaThird.Enabled = true;
                txtAnyaFirst.Enabled = false;
                txtAnyaSecond.Enabled = false;
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                txtAnyaFirst.Text = dt.Rows[0]["FIRST_ANYA_P"].ToString();
                txtAnyaSecond.Text = dt.Rows[0]["SECOND_ANYA_P"].ToString();
                txtAnyaThird.Text = dt.Rows[0]["THIRD_ANYA_P"].ToString();

                if (ddlChaumarsik.SelectedValue == "1")
                {
                    txtAnyaBarshik.Text = dt.Rows[0]["FIRST_RAKAM_ANYA"].ToString();

                }

                else if (ddlChaumarsik.SelectedValue == "2")
                {
                    txtAnyaBarshik.Text = dt.Rows[0]["SECOND_RAKAM_ANYA"].ToString();
                    txtAnyaSecond.Text = dt.Rows[0]["SECOND_ANYA_P"].ToString();
                    txtAnyaFirst.Text = dt.Rows[0]["FIRST_ANYA_P"].ToString();
                }

                else
                {
                    txtAnyaBarshik.Text = dt.Rows[0]["THIRD_RAKAM_ANYA"].ToString();
                }
                hidBarshikAnyaId.Value = dt.Rows[0]["BARSHIK_ANYA_ID"].ToString();

            }
        }
        protected void PopulaterThekaParamarsaDetail()
        {
            ProjectBudgetDetailBO objPBudgBO = new ProjectBudgetDetailBO();
            DataTable dt = null;
            objPBudgBO.ProjectId = Session["projectId"].ToInt32();//change after 
            objPBudgBO.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            dt = objBarsikService.PopulateBarsikThekaParamarsa(objPBudgBO);
            if (ddlChaumarsik.SelectedValue == "1")
            {
                txtPSFirstTNo.Enabled = true;
                txtPSFirstTRakam.Enabled = true;
                txtPBFirstTNo.Enabled = true;
                txtPBFirstTRakam.Enabled = true;
                txtThekaFirstTNo.Enabled = true;
                txtThekaFirstTRakam.Enabled = true;

                txtPSSecondTNo.Enabled = false;
                txtPSSSecondTRakam.Enabled = false;
                txtPBSecondTNo.Enabled = false;
                txtPBSecondTRakam.Enabled = false;
                txtThekaSecondTNO.Enabled = false;
                txtThekaSecondTRakam.Enabled = false;

                txtPSThirdTNo.Enabled = false;
                txtPSThirdTRakam.Enabled = false;
                txtPBThirdTNo.Enabled = false;
                txtPBThirdTRakam.Enabled = false;
                txtThekaThirdTNo.Enabled = false;
                txtThekaThirdTRakam.Enabled = false;


            }
            else if (ddlChaumarsik.SelectedValue == "2")
            {
                txtPSFirstTNo.Enabled = false;
                txtPSFirstTRakam.Enabled = false;
                txtPBFirstTNo.Enabled = false;
                txtPBFirstTRakam.Enabled = false;
                txtThekaFirstTNo.Enabled = false;
                txtThekaFirstTRakam.Enabled = false;

                txtPSSecondTNo.Enabled = true;
                txtPSSSecondTRakam.Enabled = true;
                txtPBSecondTNo.Enabled = true;
                txtPBSecondTRakam.Enabled = true;
                txtThekaSecondTNO.Enabled = true;
                txtThekaSecondTRakam.Enabled = true;

                txtPSThirdTNo.Enabled = false;
                txtPSThirdTRakam.Enabled = false;
                txtPBThirdTNo.Enabled = false;
                txtPBThirdTRakam.Enabled = false;
                txtThekaThirdTNo.Enabled = false;
                txtThekaThirdTRakam.Enabled = false;
            }
            else
            {

                txtPSFirstTNo.Enabled = false;
                txtPSFirstTRakam.Enabled = false;
                txtPBFirstTNo.Enabled = false;
                txtPBFirstTRakam.Enabled = false;
                txtThekaFirstTNo.Enabled = false;
                txtThekaFirstTRakam.Enabled = false;

                txtPSSecondTNo.Enabled = false;
                txtPSSSecondTRakam.Enabled = false;
                txtPBSecondTNo.Enabled = false;
                txtPBSecondTRakam.Enabled = false;
                txtThekaSecondTNO.Enabled = false;
                txtThekaSecondTRakam.Enabled = false;

                txtPSThirdTNo.Enabled = true;
                txtPSThirdTRakam.Enabled = true;
                txtPBThirdTNo.Enabled = true;
                txtPBThirdTRakam.Enabled = true;
                txtThekaThirdTNo.Enabled = true;
                txtThekaThirdTRakam.Enabled = true;
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                lblModification.Text = dt.Rows[0]["MODIFIED_DATE"].ToDateTime().ToString("D");
                lblModifiedBy.Text = dt.Rows[0]["MODIFIED_BY"].ToString();
                if (ddlChaumarsik.SelectedValue == "1")
                {
                    txtPSBNo.Text = dt.Rows[0]["P_F_T_SWADESHI_NO"].ToString();
                    txtPSBRakam.Text = dt.Rows[0]["P_F_T_SWADESHI_RAKAM"].ToString();
                    txtPBBNo.Text = dt.Rows[0]["P_F_T_BIDESHI_NO"].ToString();
                    txtPBBRakam.Text = dt.Rows[0]["P_F_T_BIDESHI_RAKAM"].ToString();
                    txtThekaBNo.Text = dt.Rows[0]["THEKA_F_T_NO"].ToString();
                    txtThekaBRakam.Text = dt.Rows[0]["THEKA_F_T_RAKAM"].ToString();

                    txtYesAbadhikoBhautik.Text = dt.Rows[0]["FIRST_BHAUTIK_P"].ToString();
                    txtYesAbadhikoBitiye.Text = dt.Rows[0]["FIRST_BITIYE_P"].ToString();
                    txtYesAbadhiSammaBhautik.Text = dt.Rows[0]["YES_ABADHI_SAMMA_BHAUTIK"].ToString();
                    txtYesAbadhiSammaBitiye.Text = dt.Rows[0]["YES_ABADI_SAMMA_BITIYE"].ToString();
                    txtBitekoAbadhi.Text = dt.Rows[0]["BITEKO_ABADHI"].ToString();
                    txtYesAawaBhautik.Text = dt.Rows[0]["FIRST_BHAUTIK_P"].ToString();
                    txtYesAawaPragati.Text = dt.Rows[0]["FIRST_BITIYE_P"].ToString();
                }
                else if (ddlChaumarsik.SelectedValue == "2")
                {
                    txtPSBNo.Text = dt.Rows[0]["P_S_T_SWADESHI_NO"].ToString();
                    txtPSBRakam.Text = dt.Rows[0]["P_S_T_SWADESI_RAKAM"].ToString();
                    txtPBBNo.Text = dt.Rows[0]["P_S_T_BIDESHI_NO"].ToString();
                    txtPBBRakam.Text = dt.Rows[0]["P_S_T_BIDESHI_RAKAM"].ToString();
                    txtThekaBNo.Text = dt.Rows[0]["THEKA_S_T_NO"].ToString();
                    txtThekaBRakam.Text = dt.Rows[0]["THEKA_S_T_RAKAM"].ToString();

                    txtYesAbadhikoBhautik.Text = dt.Rows[0]["SECOND_BHAUTIK_P"].ToString();
                    txtYesAbadhikoBitiye.Text = dt.Rows[0]["SECOND_BITIYE_P"].ToString();
                    txtYesAbadhiSammaBhautik.Text = dt.Rows[0]["YES_ABADHI_SAMMA_BHAUTIK_S"].ToString();
                    txtYesAbadhiSammaBitiye.Text = dt.Rows[0]["YES_ABADHI_SAMMA_BITIYE_S"].ToString();
                    txtBitekoAbadhi.Text = dt.Rows[0]["BITEKO_ABADHI_S"].ToString();
                    double totalBhautik = Convert.ToDouble(dt.Rows[0]["FIRST_BHAUTIK_P"]) + Convert.ToDouble(dt.Rows[0]["SECOND_BHAUTIK_P"]);
                    txtYesAawaBhautik.Text = totalBhautik.ToString();
                    double totalBitiyaPragati = Convert.ToDouble(dt.Rows[0]["SECOND_BITIYE_P"]) + Convert.ToDouble(dt.Rows[0]["FIRST_BITIYE_P"]);
                    txtYesAawaPragati.Text = totalBitiyaPragati.ToString();
                }
                else
                {
                    txtPSBNo.Text = dt.Rows[0]["P_T_T_SWADESHI_NO"].ToString();
                    txtPSBRakam.Text = dt.Rows[0]["P_T_T_SWADESHI_RAKAM"].ToString();
                    txtPBBNo.Text = dt.Rows[0]["P_T_T_BIDESHI_NO"].ToString();
                    txtPBBRakam.Text = dt.Rows[0]["P_T_T_BIDESHI_RAKAM"].ToString();
                    txtThekaBNo.Text = dt.Rows[0]["THEKA_T_T_NO"].ToString();
                    txtThekaBRakam.Text = dt.Rows[0]["THEKA_T_T_RAKAM"].ToString();

                    txtYesAbadhikoBhautik.Text = dt.Rows[0]["THIRD_BHAUTIK_P"].ToString();
                    txtYesAbadhikoBitiye.Text = dt.Rows[0]["THIRD_BITIYE_P"].ToString();
                    txtYesAbadhiSammaBhautik.Text = dt.Rows[0]["YES_ABADHI_SAMMA_BHAUTIK_T"].ToString();
                    txtYesAbadhiSammaBitiye.Text = dt.Rows[0]["YES_ABADHI_SAMMA_BITIYE_T"].ToString();
                    txtBitekoAbadhi.Text = dt.Rows[0]["BITEKO_ABADHI_T"].ToString();
                    double totalThirdBhautik = Convert.ToDouble(dt.Rows[0]["FIRST_BHAUTIK_P"]) +
                                            Convert.ToDouble(dt.Rows[0]["SECOND_BHAUTIK_P"]) +
                                            Convert.ToDouble(dt.Rows[0]["THIRD_BHAUTIK_P"]);
                    txtYesAawaBhautik.Text = totalThirdBhautik.ToString();
                    double totalThirdPragati = Convert.ToDouble(dt.Rows[0]["SECOND_BITIYE_P"]) +
                                            Convert.ToDouble(dt.Rows[0]["FIRST_BITIYE_P"]) +
                                            Convert.ToDouble(dt.Rows[0]["THIRD_BITIYE_P"]);
                    txtYesAawaPragati.Text = totalThirdPragati.ToString();
                }
                hidBhutikPragatiId.Value = dt.Rows[0]["PRAGATI_B_ID"].ToString();
                txtPSFirstTNo.Text = dt.Rows[0]["P_F_P_SWADESHI_NO"].ToString();
                txtPSFirstTRakam.Text = dt.Rows[0]["P_F_P_SWADESHI_RAKAM"].ToString();
                txtPSSecondTNo.Text = dt.Rows[0]["P_S_P_SWADESHI_NO"].ToString();
                txtPSSSecondTRakam.Text = dt.Rows[0]["P_S_P_SWADESI_RAKAM"].ToString();
                txtPSThirdTNo.Text = dt.Rows[0]["P_T_P_SWADESHI_NO"].ToString();
                txtPSThirdTRakam.Text = dt.Rows[0]["P_T_P_SWADESHI_RAKAM"].ToString();

                txtPBFirstTNo.Text = dt.Rows[0]["P_F_P_BIDESHI_NO"].ToString();
                txtPBFirstTRakam.Text = dt.Rows[0]["P_F_P_BIDESHI_RAKAM"].ToString();
                txtPBSecondTNo.Text = dt.Rows[0]["P_S_P_BIDESHI_NO"].ToString();
                txtPBSecondTRakam.Text = dt.Rows[0]["P_S_P_BIDESHI_RAKAM"].ToString();
                txtPBThirdTNo.Text = dt.Rows[0]["P_T_P_BIDESHI_NO"].ToString();
                txtPBThirdTRakam.Text = dt.Rows[0]["P_T_P_BIDESHI_RAKAM"].ToString();

                txtThekaFirstTNo.Text = dt.Rows[0]["THEKA_F_P_NO"].ToString();
                txtThekaFirstTRakam.Text = dt.Rows[0]["THEKA_F_P_RAKAM"].ToString();
                txtThekaSecondTNO.Text = dt.Rows[0]["THEKA_S_P_NO"].ToString();
                txtThekaSecondTRakam.Text = dt.Rows[0]["THEKA_S_P_RAKAM"].ToString();
                txtThekaThirdTNo.Text = dt.Rows[0]["THEKA_T_P_NO"].ToString();
                txtThekaThirdTRakam.Text = dt.Rows[0]["THEKA_T_P_RAKAM"].ToString();
                hidThekaParamarsaId.Value = dt.Rows[0]["BARSIK_THEKA_P_ID"].ToString();

            }

        }
        protected void PopulateDonarAmountDetails()
        {
            ProjectBudgetDetailBO objPBudgBO = new ProjectBudgetDetailBO();
            //objProjectBO.BudgetHeadId = ddlBudgetHeadId;
            objPBudgBO.ProjectId = Session["projectId"].ToInt32();//change after 
            objPBudgBO.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            DataTable dtShrotgatAayojanBadfad = objBarsikService.PopulateBudgDetail(objPBudgBO);
            dtA = dtShrotgatAayojanBadfad;
            if (dtShrotgatAayojanBadfad != null && dtShrotgatAayojanBadfad.Rows.Count > 0)
            {
                rptAayojanaBadfad.DataSource = dtShrotgatAayojanBadfad;
                rptAayojanaBadfad.DataBind();
                foreach (RepeaterItem ri in rptAayojanaBadfad.Items)
                {
                    TextBox txtFirstTRakam = ri.FindControl("txtFirstTRakam") as TextBox;
                    TextBox txtSecondTRakam = ri.FindControl("txtSecondTRakam") as TextBox;
                    TextBox txtThirdTRakam = ri.FindControl("txtThirdTRakam") as TextBox;
                    if (ddlChaumarsik.SelectedValue.ToInt32() == 1)
                    {
                        txtFirstTRakam.Enabled = true;
                        txtSecondTRakam.Enabled = false;
                        txtThirdTRakam.Enabled = false;
                    }
                    else if (ddlChaumarsik.SelectedValue.ToInt32() == 2)
                    {
                        txtFirstTRakam.Enabled = false;
                        txtSecondTRakam.Enabled = true;
                        txtThirdTRakam.Enabled = false;
                    }
                    else
                    {
                        txtFirstTRakam.Enabled = false;
                        txtSecondTRakam.Enabled = false;
                        txtThirdTRakam.Enabled = true;
                    }
                }

            }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProjectBudgetDetailBO objBudgProject = new ProjectBudgetDetailBO();
            DropDownList ddlShrot = new DropDownList();
            DropDownList ddlBhuktaniPrakar = new DropDownList();
            TextBox txtRakam = new TextBox();
            TextBox txtFirstTRakam = new TextBox();
            TextBox txtSecondTRakam = new TextBox();
            TextBox txtThirdTRakam = new TextBox();
            TextBox txtSodhBharnaMagF = new TextBox();
            TextBox txtSodhBharnaMagS = new TextBox();
            TextBox txtSodhBharnaMagT = new TextBox();
            TextBox txtSodhBharnaHalSammaMagF = new TextBox();
            TextBox txtSodhBharnaHalSammaMagS = new TextBox();
            TextBox txtSodhBharnaHalSammaMagT = new TextBox();
            TextBox txtSodhBharnaPraptaF = new TextBox();
            TextBox txtSodhBharnaPraptaS = new TextBox();
            TextBox txtSodhBharnaPraptaT = new TextBox();


            HiddenField hidBadfadId = new HiddenField();
            foreach (RepeaterItem rptItem in rptAayojanaBadfad.Items)
            {
                int k = 0;
                ddlShrot = (DropDownList)rptItem.FindControl("ddlShrot");
                ddlBhuktaniPrakar = (DropDownList)rptItem.FindControl("ddlBhuktaniPrakar");
                txtRakam = (TextBox)rptItem.FindControl("txtRakam");
                txtFirstTRakam = (TextBox)rptItem.FindControl("txtFirstTRakam");
                txtSecondTRakam = (TextBox)rptItem.FindControl("txtSecondTRakam");
                txtThirdTRakam = (TextBox)rptItem.FindControl("txtThirdTRakam");
                txtSodhBharnaMagF = (TextBox)rptItem.FindControl("txtSodhBharnaMagF");
                txtSodhBharnaMagS = (TextBox)rptItem.FindControl("txtSodhBharnaMagS");
                txtSodhBharnaMagT = (TextBox)rptItem.FindControl("txtSodhBharnaMagT");
                txtSodhBharnaHalSammaMagF = (TextBox)rptItem.FindControl("txtSodhBharnaHalSammaMagF");
                txtSodhBharnaHalSammaMagS = (TextBox)rptItem.FindControl("txtSodhBharnaHalSammaMagS");
                txtSodhBharnaHalSammaMagT = (TextBox)rptItem.FindControl("txtSodhBharnaHalSammaMagT");
                txtSodhBharnaPraptaF = (TextBox)rptItem.FindControl("txtSodhBharnaPraptaF");
                txtSodhBharnaPraptaS = (TextBox)rptItem.FindControl("txtSodhBharnaPraptaS");
                txtSodhBharnaPraptaT = (TextBox)rptItem.FindControl("txtSodhBharnaPraptaT");
                hidBadfadId = (HiddenField)rptItem.FindControl("hidBadfadId");
                objBudgProject.SBhMagGarneF = txtSodhBharnaMagF.Text.ToDecimal();
                objBudgProject.SBhMagGarneS = txtSodhBharnaMagS.Text.ToDecimal();
                objBudgProject.SBhMagGarneT = txtSodhBharnaMagT.Text.ToDecimal();
                objBudgProject.SBhHalSammaMagF = txtSodhBharnaHalSammaMagF.Text.ToDecimal();
                objBudgProject.SBhHalSammaMagS = txtSodhBharnaHalSammaMagS.Text.ToDecimal();
                objBudgProject.SBhHalSammaMagT = txtSodhBharnaHalSammaMagT.Text.ToDecimal();
                objBudgProject.SBhHalSammaPraptaF = txtSodhBharnaPraptaF.Text.ToDecimal();
                objBudgProject.SBhHalSammaPraptaS = txtSodhBharnaPraptaS.Text.ToDecimal();
                objBudgProject.SBhHalSammaPraptaT = txtSodhBharnaPraptaT.Text.ToDecimal();
                objBudgProject.BudgBadfadId = hidBadfadId.Value.ToDecimal();
                objBudgProject.FirstPRakam = txtFirstTRakam.Text.ToDecimal();
                objBudgProject.SecondPRakam = txtSecondTRakam.Text.ToDecimal();
                objBudgProject.ThirdPRakam = txtThirdTRakam.Text.ToDecimal();

                objBudgProject.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
                if (ddlChaumarsik.SelectedValue == "1")
                {
                    objBudgProject.Mode = "UF";
                }
                else if (ddlChaumarsik.SelectedValue == "2")
                {
                    objBudgProject.Mode = "US";
                }
                else
                {
                    objBudgProject.Mode = "UT";
                }
                objBarsikService = new BarsikKaryekramService();
                objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
                objBarsikService.InsertUpdateProjectBudgDetail(objBudgProject);
            }

            //barshikAnya
            ProjectBarshikAnyaBO objBarshikAnyaBo = new ProjectBarshikAnyaBO();
            objBarshikAnyaBo.ProjectId = Session["projectId"].ToInt32();
            objBarshikAnyaBo.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objBarshikAnyaBo.FirstAnyaPragati = txtAnyaFirst.Text.ToDecimal();
            objBarshikAnyaBo.SecondAnyaPragati = txtAnyaSecond.Text.ToDecimal();
            objBarshikAnyaBo.ThirdAnyaPragati = txtAnyaThird.Text.ToDecimal();
            objBarshikAnyaBo.BarshikAnyaID = hidBarshikAnyaId.Value.ToInt32();
            if (ddlChaumarsik.SelectedValue == "1")
            {
                objBarshikAnyaBo.Mode = "UF";
            }
            else if (ddlChaumarsik.SelectedValue == "2")
            {
                objBarshikAnyaBo.Mode = "US";
            }
            else
            {
                objBarshikAnyaBo.Mode = "UT";
            }


            ProjectBarsikThekaParamarsaBO objThekaParamarsa = new ProjectBarsikThekaParamarsaBO();
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            if (hidThekaParamarsaId.Value == "")
            {
                //objThekaParamarsa.Mode = "I";
            }
            else
            {
                if (ddlChaumarsik.SelectedValue == "1")
                {
                    objThekaParamarsa.Mode = "UF";
                }
                else if (ddlChaumarsik.SelectedValue == "2")
                {
                    objThekaParamarsa.Mode = "US";
                }
                else
                {
                    objThekaParamarsa.Mode = "UT";
                }

                objThekaParamarsa.BarsikThekaPId = hidThekaParamarsaId.Value.ToDecimal();
            }

            //paramarsa swadeshi
            objThekaParamarsa.PFPSwadeshiNo = txtPSFirstTNo.Text.ToDecimal();
            objThekaParamarsa.PFPSwadeshiRakam = txtPSFirstTRakam.Text.ToDecimal();
            objThekaParamarsa.PSPSwadeshiNo = txtPSSecondTNo.Text.ToDecimal();
            objThekaParamarsa.PSPSwadesiRakam = txtPSSSecondTRakam.Text.ToDecimal();
            objThekaParamarsa.PTPSwadeshiNo = txtPSThirdTNo.Text.ToDecimal();
            objThekaParamarsa.PTPSwadeshiRakam = txtPSThirdTRakam.Text.ToDecimal();

            //paramarsadata bideshi
            objThekaParamarsa.PFPBideshiNo = txtPBFirstTNo.Text.ToDecimal();
            objThekaParamarsa.PFPBideshiRakam = txtPBFirstTRakam.Text.ToDecimal();
            objThekaParamarsa.PSPBideshiNo = txtPBSecondTNo.Text.ToDecimal();
            objThekaParamarsa.PSPBideshiRakam = txtPBSecondTRakam.Text.ToDecimal();
            objThekaParamarsa.PTPBideshiNo = txtPBThirdTNo.Text.ToDecimal();
            objThekaParamarsa.PTPBideshiRakam = txtPBThirdTRakam.Text.ToDecimal();

            objThekaParamarsa.ThekaFPNo = txtThekaFirstTNo.Text.ToDecimal();
            objThekaParamarsa.ThekaFPRakam = txtThekaFirstTRakam.Text.ToDecimal();
            objThekaParamarsa.ThekaSPNo = txtThekaSecondTNO.Text.ToDecimal();
            objThekaParamarsa.ThekaSPRakam = txtThekaSecondTRakam.Text.ToDecimal();
            objThekaParamarsa.ThekaTPNo = txtThekaThirdTNo.Text.ToDecimal();
            objThekaParamarsa.ThekaTPRakam = txtThekaThirdTRakam.Text.ToDecimal();

            objThekaParamarsa.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objThekaParamarsa.ProjectId = Session["projectId"].ToInt32();
            objBarsikService.InsertUpdateProjectBarsikThekaParamarsa(objThekaParamarsa);

            //bhautik biteya pragati
            ProjectBhautikBPragatiBO objBhautikPragatai = new ProjectBhautikBPragatiBO();
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();

            objBhautikPragatai.Mode = "I";

            if (ddlChaumarsik.SelectedValue == "1")
            {
                objBhautikPragatai.FirstBhautikP = txtYesAbadhikoBhautik.Text.ToDecimal();
                objBhautikPragatai.FirstBitiyeP = txtYesAbadhikoBitiye.Text.ToDecimal();
                objBhautikPragatai.YesAbadhiSammaBhautik = txtYesAbadhiSammaBhautik.Text.ToDecimal();
                objBhautikPragatai.YesAbadiSammaBitiye = txtYesAbadhiSammaBitiye.Text.ToDecimal();
                objBhautikPragatai.BitekoAbadhi = txtBitekoAbadhi.Text.ToDecimal();
                objBhautikPragatai.ModifiedBy = Session["username"].ToString();
                objBhautikPragatai.ModifiedDate = DateTime.Now;
                if (hidBhutikPragatiId.Value != "")
                {
                    objBhautikPragatai.Mode = "UF";
                    objBhautikPragatai.PragatiBId = hidBhutikPragatiId.Value.ToDecimal();
                }
            }
            else if (ddlChaumarsik.SelectedValue == "2")
            {
                objBhautikPragatai.SecondBhautikP = txtYesAbadhikoBhautik.Text.ToDecimal();
                objBhautikPragatai.SecondBitiyeP = txtYesAbadhikoBitiye.Text.ToDecimal();
                objBhautikPragatai.YesAbadhiSammaBhautikS = txtYesAbadhiSammaBhautik.Text.ToDecimal();
                objBhautikPragatai.YesAbadhiSammaBitiyeS = txtYesAbadhiSammaBitiye.Text.ToDecimal();
                objBhautikPragatai.BitekoAbadhiS = txtBitekoAbadhi.Text.ToDecimal();
                objBhautikPragatai.ModifiedBy = Session["username"].ToString();
                objBhautikPragatai.ModifiedDate = DateTime.Now;
                if (hidBhutikPragatiId.Value != "")
                {
                    objBhautikPragatai.Mode = "US";
                    objBhautikPragatai.PragatiBId = hidBhutikPragatiId.Value.ToDecimal();
                }
            }
            else
            {
                objBhautikPragatai.ThirdBhautikP = txtYesAbadhikoBhautik.Text.ToDecimal();
                objBhautikPragatai.ThirdBitiyeP = txtYesAbadhikoBitiye.Text.ToDecimal();
                objBhautikPragatai.YesAbadhiSammaBhautikT = txtYesAbadhiSammaBhautik.Text.ToDecimal();
                objBhautikPragatai.YesAbadhiSammaBitiyeT = txtYesAbadhiSammaBitiye.Text.ToDecimal();
                objBhautikPragatai.BitekoAbadhiT = txtBitekoAbadhi.Text.ToDecimal();
                objBhautikPragatai.ModifiedBy = Session["username"].ToString();
                objBhautikPragatai.ModifiedDate = DateTime.Now;
                if (hidBhutikPragatiId.Value != "")
                {
                    objBhautikPragatai.Mode = "UT";
                    objBhautikPragatai.PragatiBId = hidBhutikPragatiId.Value.ToDecimal();
                }
            }
            objBhautikPragatai.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objBhautikPragatai.ProjectId = Session["projectId"].ToInt32();

            objBarsikService.InsertUpdateProjectBhautikBPragati(objBhautikPragatai);
            //labhanbit

            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = Session["projectId"].ToInt32();
            objProjectBO.ChaumasikId = ddlChaumarsik.SelectedValue.ToInt32();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            wbs.ClearProjectLavanvitPragati(objProjectBO);


            TextBox txtMahila = new TextBox();
            TextBox txtBalbalika = new TextBox();
            TextBox txtAadibasiJanajati = new TextBox();
            TextBox txtDalit = new TextBox();
            TextBox txtMadhesi = new TextBox();
            TextBox txtMuslim = new TextBox();
            TextBox txtAnya = new TextBox();


            foreach (RepeaterItem rptItem in rptLavanvit.Items)
            {
                int k = 0;

                txtMahila = (TextBox)rptItem.FindControl("txtMahila");
                txtBalbalika = (TextBox)rptItem.FindControl("txtBalbalika");
                txtAadibasiJanajati = (TextBox)rptItem.FindControl("txtAadibasiJanajati");
                txtDalit = (TextBox)rptItem.FindControl("txtDalit");
                txtMadhesi = (TextBox)rptItem.FindControl("txtMadhesi");
                txtMuslim = (TextBox)rptItem.FindControl("txtMuslim");
                txtAnya = (TextBox)rptItem.FindControl("txtAnya");

                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = Session["projectId"].ToInt32();
                objProjectBO.ChaumasikId = ddlChaumarsik.SelectedValue.ToInt32();
                objProjectBO.LavanbitMahila = txtMahila.Text.ToInt32();
                objProjectBO.LavanbitBalBalika = txtBalbalika.Text.ToInt32();
                objProjectBO.LavanbitJanajati = txtAadibasiJanajati.Text.ToInt32();
                objProjectBO.LavanbitDalit = txtDalit.Text.ToInt32();
                objProjectBO.LavanbitMadheshi = txtMadhesi.Text.ToInt32();
                objProjectBO.LavanbitMuslim = txtMuslim.Text.ToInt32();
                objProjectBO.Anya = txtAnya.Text.ToInt32();

                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                k = wbs.SaveProjectLavanvitPragati(objProjectBO);

            }
            //problem 
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = Session["projectId"].ToInt32();
            objProjectBO.ChaumasikId = ddlChaumarsik.SelectedValue.ToInt32();
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            wbs.ClearProjectProblems(objProjectBO);

            //DropDownList ddlChaumasik = new DropDownList();
            TextBox txtProblems = new TextBox();
            TextBox txtReasons = new TextBox();
            TextBox txtEfforts = new TextBox();
            TextBox txtSuggestions = new TextBox();
            CheckBox chkNdac = new CheckBox();

            foreach (RepeaterItem rptItem in rptProblems.Items)
            {
                int k = 0;
                // ddlChaumasik = (DropDownList)rptItem.FindControl("ddlChaumasik");
                txtProblems = (TextBox)rptItem.FindControl("txtProblems");
                txtReasons = (TextBox)rptItem.FindControl("txtReasons");
                txtEfforts = (TextBox)rptItem.FindControl("txtEfforts");
                txtSuggestions = (TextBox)rptItem.FindControl("txtSuggestions");
                chkNdac = (CheckBox)rptItem.FindControl("chkNdac");
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = Session["projectId"].ToInt32();
                objProjectBO.ChaumasikId = ddlChaumarsik.SelectedValue.ToInt32();
                objProjectBO.Problems = txtProblems.Text;
                objProjectBO.Reasons = txtReasons.Text;
                objProjectBO.Efforts = txtEfforts.Text;
                objProjectBO.Suggestions = txtSuggestions.Text;
                objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
                if (chkNdac.Checked == true)
                {
                    objProjectBO.Ndac = 1;
                }
                else
                {
                    objProjectBO.Ndac = 0;
                }

                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                k = wbs.SaveProjectProblems(objProjectBO);

            }

            /////File upload
            ProjectBarsikThekaParamarsaBO objBo = new ProjectBarsikThekaParamarsaBO();
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            objBo.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objBo.ProjectId = Session["projectId"].ToInt32();
            objBo.ChaumasikId = ddlChaumarsik.SelectedValue.ToInt32();

            string allFiles = "";
            ///// file upload remains
            if (FileChaumasik.HasFile) // CHECK IF ANY FILE HAS BEEN SELECTED.
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
                        String newfolder = Server.MapPath("~") + @"ChaumasikFiles\";
                        String path = newfolder + str;
                        hpf.SaveAs(path);
                        allFiles += str + ",";
                    }
                }
                objBo.ChaumasikFileName = allFiles;
            }
            else
            {
                if (Session["projectId"] != null && Session["projectId"].ToInt32() > 0)
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
            int i = objBarsikService.InsertUpdateChaumasikFile(objBo);
            //insert barshik anya
            int a = objBarsikService.InsertUpdateBarshikAnya(objBarshikAnyaBo);
            /*if (FileChaumasik.HasFile)
            {
                ProjectBarsikThekaParamarsaBO objBo = new ProjectBarsikThekaParamarsaBO();
                objBarsikService = new BarsikKaryekramService();
                objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
                //lblImage.Text = DateTime.Now + FileBarshik.FileName;
                string ext = System.IO.Path.GetExtension(this.FileChaumasik.PostedFile.FileName);
                var splitseparator = new string[] { ext };
                var result = Splitstring(DateTime.Now + FileChaumasik.FileName, splitseparator);
                String source = result[0];
                string str = source + ext;
                str = Regex.Replace(str, @"/", "_");
                str = Regex.Replace(str, @":", "_");
                objBo.ChaumasikFileName = str;
                objBo.FiscalYearId = Session["fiscal_year_id"].ToInt32();
                objBo.ProjectId = Session["projectId"].ToInt32();
                objBo.ChaumasikId = ddlChaumarsik.SelectedValue.ToInt32();
                UploadFile(FileChaumasik, str);
                int i = objBarsikService.InsertUpdateChaumasikFile(objBo);

            }*/

            //upalabdhi
            ProjectUpalabdhiBO objUpalabdhi = new ProjectUpalabdhiBO();
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            objUpalabdhi.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objUpalabdhi.ProjectId = Session["projectId"].ToInt32();
            objUpalabdhi.FirstCDesc = txtFirstCUpalabdhi.Text;
            objUpalabdhi.SecondCDesc = txtSecondCUpalabdhi.Text;
            objUpalabdhi.ThirdCDesc = txtThirdCUpalabdhi.Text;
            if (hidUpalabdhId.Value == "")
            {
                objUpalabdhi.Mode = "I";
            }
            else
            {
                objUpalabdhi.UplabdhiId = hidUpalabdhId.Value.ToInt32();
                if (ddlChaumarsik.SelectedValue == "1")
                {
                    objUpalabdhi.Mode = "UF";
                }
                else if (ddlChaumarsik.SelectedValue == "2")
                {
                    objUpalabdhi.Mode = "US";
                }
                else
                {
                    objUpalabdhi.Mode = "UT";
                }
            }

            objBarsikService.InsertUpdateProjectUpalabdhi(objUpalabdhi);
            //


            //
            Response.Redirect(Constants.ConstantAppPath + "/Modules/BarsikKaryekram/KaryekramPragati.aspx");
            //

        }

        protected string[] Splitstring(String source, String[] splitseparator)
        {
            String[] result = source.Split(splitseparator, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        private void UploadFile(FileUpload fileUpload, String str)
        {
            String newfolder = Server.MapPath("~") + @"\ChaumasikFiles\";
            if (!Directory.Exists(newfolder))
            {
                Directory.CreateDirectory(newfolder);
            }
            fileUpload.PostedFile.SaveAs(newfolder + "/" + str);

        }

        private void PopulateDataForRepeater()
        {
            DataTable dt = null;
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = Session["projectId"].ToInt32();
            objProjectBO.ChaumasikId = ddlChaumarsik.SelectedValue.ToInt32();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dt = wbs.PopulateProjectLavanvitPragati(objProjectBO);
            dtB = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                rptLavanvit.DataSource = dt;
                rptLavanvit.DataBind();

            }
            else
            {
                DataTable db = new DataTable();
                rptLavanvit.DataSource = db;
                rptLavanvit.DataBind();
            }
        }
        protected void rptLavanvit_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList ddlChaumasik = new DropDownList();

            }
        }

        protected void btnAddLavanvit_Click(object sender, EventArgs e)
        {
            dtB.Clear();
            dtB.Columns.Add("CHAUMASIK_ID");
            dtB.Columns.Add("MAHILA");
            dtB.Columns.Add("BALBALIKA");
            dtB.Columns.Add("AADIBASI_JANAJATI");
            dtB.Columns.Add("DALIT");
            dtB.Columns.Add("MADHESI");
            dtB.Columns.Add("MUSLIM");
            dtB.Columns.Add("ANYA");

            DropDownList ddlChaumasik = new DropDownList();
            TextBox txtMahila = new TextBox();
            TextBox txtBalbalika = new TextBox();
            TextBox txtAadibasiJanajati = new TextBox();
            TextBox txtDalit = new TextBox();
            TextBox txtMadhesi = new TextBox();
            TextBox txtMuslim = new TextBox();
            TextBox txtAnya = new TextBox();

            foreach (RepeaterItem rptItem in rptLavanvit.Items)
            {
                DataRow drA = dtA.NewRow();
                txtMahila = (TextBox)rptItem.FindControl("txtMahila");
                txtBalbalika = (TextBox)rptItem.FindControl("txtBalbalika");
                txtAadibasiJanajati = (TextBox)rptItem.FindControl("txtAadibasiJanajati");
                txtDalit = (TextBox)rptItem.FindControl("txtDalit");
                txtMadhesi = (TextBox)rptItem.FindControl("txtMadhesi");
                txtMuslim = (TextBox)rptItem.FindControl("txtMuslim");
                txtAnya = (TextBox)rptItem.FindControl("txtAnya");
                drA["CHAUMASIK_ID"] = 0;
                drA["MAHILA"] = txtMahila.Text;
                drA["BALBALIKA"] = txtBalbalika.Text;
                drA["AADIBASI_JANAJATI"] = txtAadibasiJanajati.Text;
                drA["DALIT"] = txtDalit.Text;
                drA["MADHESI"] = txtMadhesi.Text;
                drA["MUSLIM"] = txtMuslim.Text;
                drA["ANYA"] = txtAnya.Text;
                if (txtMahila.Text != "" || txtBalbalika.Text != "" || txtAadibasiJanajati.Text != "" || txtDalit.Text != "" || txtMadhesi.Text != "" || txtAnya.Text != "")
                    dtB.Rows.Add(drA);
            }

            DataRow drB = dtB.NewRow();
            drB["CHAUMASIK_ID"] = 0;
            drB["MAHILA"] = "";
            drB["BALBALIKA"] = "";
            drB["AADIBASI_JANAJATI"] = "";
            drB["DALIT"] = "";
            drB["MADHESI"] = "";
            drB["MUSLIM"] = "";
            drB["ANYA"] = "";
            dtB.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptLavanvit.DataSource = db;
            rptLavanvit.DataBind();

            rptLavanvit.DataSource = dtB;
            rptLavanvit.DataBind();
        }

        private void PopulateProblemRepeater()
        {
            DataTable dt = null;
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = Session["projectId"].ToInt32();
            objProjectBO.ChaumasikId = ddlChaumarsik.SelectedValue.ToInt32();
            objProjectBO.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dt = wbs.PopulateProjectProblems(objProjectBO);
            dtC = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                rptProblems.DataSource = dt;
                rptProblems.DataBind();
                //btnSaveProblem.Visible = true;
            }
            else
            {
                DataTable dt1 = new DataTable();
                rptProblems.DataSource = dt1;
                rptProblems.DataBind();
            }
        }

        protected void rptProblems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList ddlChaumasik = new DropDownList();

                CheckBox chkNdac = new CheckBox();
                chkNdac = (CheckBox)e.Item.FindControl("chkNdac");
                if (dtC.Rows[e.Item.ItemIndex]["NDAC"].ToString() == "1")
                {
                    chkNdac.Checked = true;
                }
                else
                {
                    chkNdac.Checked = false;

                }

            }
        }

        protected void btnSaveProblem_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddProblems_Click(object sender, EventArgs e)
        {
            dtC.Clear();
            dtC.Columns.Add("CHAUMASIK_ID");
            dtC.Columns.Add("PROBLEMS");
            dtC.Columns.Add("REASONS");
            dtC.Columns.Add("EFFORTS");
            dtC.Columns.Add("SUGGESTIONS");
            dtC.Columns.Add("NDAC");

            // btnSaveProblem.Visible = true;


            TextBox txtProblems = new TextBox();
            TextBox txtReasons = new TextBox();
            TextBox txtEfforts = new TextBox();
            TextBox txtSuggestions = new TextBox();
            CheckBox chkNdac = new CheckBox();

            foreach (RepeaterItem rptItem in rptProblems.Items)
            {
                DataRow drA = dtC.NewRow();
                txtProblems = (TextBox)rptItem.FindControl("txtProblems");
                txtReasons = (TextBox)rptItem.FindControl("txtReasons");
                txtEfforts = (TextBox)rptItem.FindControl("txtEfforts");
                txtSuggestions = (TextBox)rptItem.FindControl("txtSuggestions");
                chkNdac = (CheckBox)rptItem.FindControl("chkNdac");
                drA["CHAUMASIK_ID"] = 0;
                drA["PROBLEMS"] = txtProblems.Text;
                drA["REASONS"] = txtReasons.Text;
                drA["EFFORTS"] = txtEfforts.Text;
                drA["SUGGESTIONS"] = txtSuggestions.Text;
                if (chkNdac.Checked == true)
                    drA["NDAC"] = 1;
                else
                {
                    drA["NDAC"] = 0;
                }
                if (txtProblems.Text != "" || txtReasons.Text != "")
                    dtC.Rows.Add(drA);
            }

            DataRow drB = dtC.NewRow();
            drB["CHAUMASIK_ID"] = 0;
            drB["PROBLEMS"] = "";
            drB["REASONS"] = "";
            drB["EFFORTS"] = "";
            drB["SUGGESTIONS"] = "";
            drB["NDAC"] = 0;
            dtC.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptProblems.DataSource = db;
            rptProblems.DataBind();

            rptProblems.DataSource = dtC;
            rptProblems.DataBind();
        }

        protected void ddlChaumarsik_SelectedIndexChanged(object sender, EventArgs e)
        {
            divContent.Visible = false;
            Session["kpChaumasikId"] = ddlChaumarsik.SelectedValue;
            PopulateDonarAmountDetails();
            PopulaterThekaParamarsaDetail();
            PopulateDataForRepeater();
            PopulateProblemRepeater();
            PopulateUpalabdhi();
            PopulateChaumasikFile();
            PopulateAnyaBarshik();
            PopulateBarshikBharit();
            if (ddlChaumarsik.SelectedValue == "1")
            {
                divContent.Visible = true;
                txtFirstCUpalabdhi.Enabled = true;
                txtSecondCUpalabdhi.Enabled = false;
                txtThirdCUpalabdhi.Enabled = false;
            }
            else if (ddlChaumarsik.SelectedValue == "2")
            {
                divContent.Visible = true;
                txtFirstCUpalabdhi.Enabled = false;
                txtSecondCUpalabdhi.Enabled = true;
                txtThirdCUpalabdhi.Enabled = false;
            }
            else if (ddlChaumarsik.SelectedValue == "3")
            {
                divContent.Visible = true;
                txtFirstCUpalabdhi.Enabled = false;
                txtSecondCUpalabdhi.Enabled = false;
                txtThirdCUpalabdhi.Enabled = true;
            }
            else
            {
                divContent.Visible = false;

            }
        }

        protected void grdUploadedFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                string url = Constants.ConstantAppPath + "/ChaumasikFiles/" + e.CommandArgument.ToString();
                //Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", Constants.ConstantAppPath + "/ChaumasikFiles/" + e.CommandArgument.ToString()));
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + url + "','_blank')", true);
            }
        }

        
    }
}