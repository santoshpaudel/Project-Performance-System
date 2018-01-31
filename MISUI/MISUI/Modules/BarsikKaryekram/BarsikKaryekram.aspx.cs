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
    public partial class BarsikKaryekram : Base
    {
        private ProjectService wbs = null;
        private DataTable dtA = new DataTable();

        //private ProjectVerificationBO projectVerificationBo = null;
        //private static DataTable dt = null;

        BarsikKaryekramService objBarsikService = null;
        //private static int projectId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
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
                PopulateDonarAmountDetails();
                PopulaterThekaParamarsaDetail();
                PopulateBarshikFile();
                PopulateBarshikAnya();
                PopulateBarshikBharit();
            }

            if (txtAnyaBarshik.Text.ToInt32() == 0)
            {
                ResetAnyaChaumasik();
            }
        }

        protected void ResetAnyaChaumasik()
        {
            txtAnyaFirst.Text = "";
            txtAnyaSecond.Text = "";
            txtAnyaThird.Text = "";
            txtAnyaRemarks.Text = "";
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
            if (dt != null && dt.Rows.Count > 0)
            {
                txtPSBNo.Text = dt.Rows[0]["SWADESHI"].ToString();
                txtPSBRakam.Text = dt.Rows[0]["RAKAM_SWADESHI"].ToString();
                txtPSFirstTNo.Text = dt.Rows[0]["P_F_T_SWADESHI_NO"].ToString();
                txtPSFirstTRakam.Text = dt.Rows[0]["P_F_T_SWADESHI_RAKAM"].ToString();
                txtPSSecondTNo.Text = dt.Rows[0]["P_S_T_SWADESHI_NO"].ToString();
                txtPSSSecondTRakam.Text = dt.Rows[0]["P_S_T_SWADESI_RAKAM"].ToString();
                txtPSThirdTNo.Text = dt.Rows[0]["P_T_T_SWADESHI_NO"].ToString();
                txtPSThirdTRakam.Text = dt.Rows[0]["P_T_T_SWADESHI_RAKAM"].ToString();
                txtPBBNo.Text = dt.Rows[0]["BIDESHI"].ToString();
                txtPBBRakam.Text = dt.Rows[0]["RAKAM_BIDESHI"].ToString();
                txtPBFirstTNo.Text = dt.Rows[0]["P_F_T_BIDESHI_NO"].ToString();
                txtPBFirstTRakam.Text = dt.Rows[0]["P_F_T_BIDESHI_RAKAM"].ToString();
                txtPBSecondTNo.Text = dt.Rows[0]["P_S_T_BIDESHI_NO"].ToString();
                txtPBSecondTRakam.Text = dt.Rows[0]["P_S_T_BIDESHI_RAKAM"].ToString();
                txtPBThirdTNo.Text = dt.Rows[0]["P_T_T_BIDESHI_NO"].ToString();
                txtPBThirdTRakam.Text = dt.Rows[0]["P_T_T_BIDESHI_RAKAM"].ToString();
                txtThekaBNo.Text = dt.Rows[0]["THEKKA_SANKHYA"].ToString();
                txtThekaBRakam.Text = dt.Rows[0]["THEKKA_RAKAM"].ToString();
                txtThekaFirstTNo.Text = dt.Rows[0]["THEKA_F_T_NO"].ToString();
                txtThekaFirstTRakam.Text = dt.Rows[0]["THEKA_F_T_RAKAM"].ToString();
                txtThekaSecondTNO.Text = dt.Rows[0]["THEKA_S_T_NO"].ToString();
                txtThekaSecondTRakam.Text = dt.Rows[0]["THEKA_S_T_RAKAM"].ToString();
                txtThekaThirdTNo.Text = dt.Rows[0]["THEKA_T_T_NO"].ToString();
                txtThekaThirdTRakam.Text = dt.Rows[0]["THEKA_T_T_RAKAM"].ToString();
                lblModification.Text = dt.Rows[0]["MODIFIED_DATE"].ToDateTime().ToString("D");
                lblModifiedBy.Text = dt.Rows[0]["MODIFIED_BY"].ToString();
                hidThekaParamarsaId.Value = dt.Rows[0]["BARSIK_THEKA_P_ID"].ToString();

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
                txtBarshik.Text = dt.Rows[0]["BARSHIK_BHARIT_LAKSHYA"].ToString();
                txtFirstBharit.Text = dt.Rows[0]["FIRST_BHARIT_LAKSHYA"].ToString();
                txtSecondBharit.Text = dt.Rows[0]["SECOND_BHARIT_LAKSHYA"].ToString();
                txtThirdBharit.Text = dt.Rows[0]["THIRD_BHARIT_LAKSHYA"].ToString();
                hidBarshikBharitId.Value = dt.Rows[0]["BARSHIK_BHARIT_LAKSHYA_ID"].ToString();
            }
        }

        protected void PopulateBarshikAnya()
        {
            ProjectBarshikAnyaBO objProjectBarshikAnya = new ProjectBarshikAnyaBO();
            objProjectBarshikAnya.ProjectId = Session["projectId"].ToInt32();
            objProjectBarshikAnya.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            DataTable dt = null;
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            dt = objBarsikService.PopulateBarshikAnya(objProjectBarshikAnya);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtAnyaFirst.Text = dt.Rows[0]["FIRST_RAKAM_ANYA"].ToString();
                txtAnyaSecond.Text = dt.Rows[0]["SECOND_RAKAM_ANYA"].ToString();
                txtAnyaThird.Text = dt.Rows[0]["THIRD_RAKAM_ANYA"].ToString();
                txtAnyaRemarks.Text = dt.Rows[0]["REMARKS_ANYA"].ToString();
                hidBarshikAnyaId.Value = dt.Rows[0]["BARSHIK_ANYA_ID"].ToString();
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

            }
        }

        protected void PopulateBarshikFile()
        {
            /*aBarshikFile.InnerHtml = "";
            aBarshikFile.HRef = null;*/
            ProjectBarsikThekaParamarsaBO objBo = new ProjectBarsikThekaParamarsaBO();
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            objBo.ProjectId = Session["projectId"].ToInt32();//change after 
            objBo.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            DataTable dtBarshikFile = objBarsikService.PopulateBarshikFile(objBo);
            Session["dtBarshikFile"] = objBarsikService.PopulateBarshikFile(objBo);

            if (dtBarshikFile != null && dtBarshikFile.Rows.Count > 0)
            {
                if (dtBarshikFile.Rows[0]["FILE_NAME"].ToString() != "")
                {
                    lblFileWarning.Visible = true;
                    grdUploadedFiles.Visible = true;
                    string fileName = "";
                    Session["existingFilename"] = fileName = dtBarshikFile.Rows[0]["FILE_NAME"].ToString();
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
                hidBadfadId = (HiddenField)rptItem.FindControl("hidBadfadId");
                objBudgProject.BadfadId = hidBadfadId.Value.ToDecimal();
                objBudgProject.FirstTRakam = txtFirstTRakam.Text.ToDecimal();
                objBudgProject.SecondTRakam = txtSecondTRakam.Text.ToDecimal();
                objBudgProject.ThirdCRakam = txtThirdTRakam.Text.ToDecimal();
                objBudgProject.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
                objBudgProject.Mode = "I";
                objBarsikService = new BarsikKaryekramService();
                objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
                objBarsikService.InsertUpdateProjectBudgDetail(objBudgProject);
            }
            ProjectBarsikThekaParamarsaBO objThekaParamarsa = new ProjectBarsikThekaParamarsaBO();

            //barshikAnya
            ProjectBarshikAnyaBO objBarshikAnyaBo = new ProjectBarshikAnyaBO();
            objBarshikAnyaBo.ProjectId = Session["projectId"].ToInt32();
            objBarshikAnyaBo.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objBarshikAnyaBo.FirstRakamAnya = txtAnyaFirst.Text.ToDecimal();
            objBarshikAnyaBo.SecondRakamAnya = txtAnyaSecond.Text.ToDecimal();
            objBarshikAnyaBo.ThirdRakamAnya = txtAnyaThird.Text.ToDecimal();
            objBarshikAnyaBo.RemarksAnya = txtAnyaRemarks.Text;

            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            if (hidBarshikAnyaId.Value == "")
            {
                objBarshikAnyaBo.Mode = "I";
            }
            else
            {
                objBarshikAnyaBo.Mode = "U";
                objBarshikAnyaBo.BarshikAnyaID = hidBarshikAnyaId.Value.ToInt32();
            }

            //barshikBharit
            BarsikBharitBo objBarsikBharitBo=new BarsikBharitBo();
            objBarsikBharitBo.ProjectId = Session["projectId"].ToInt32();
            objBarsikBharitBo.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objBarsikBharitBo.BarshikBharitLakshya = txtBarshik.Text.ToDecimal();
            objBarsikBharitBo.FirstBharitLakshya = txtFirstBharit.Text.ToDecimal();
            objBarsikBharitBo.SecondBharitLakshya = txtSecondBharit.Text.ToDecimal();
            objBarsikBharitBo.ThirdBharitLakshya = txtThirdBharit.Text.ToDecimal();
            if(hidBarshikBharitId.Value=="")
            {
                objBarsikBharitBo.Mode = "I";
            }
            else
            {
                objBarsikBharitBo.Mode = "U";
            }


            if (hidThekaParamarsaId.Value == "")
            {
                objThekaParamarsa.Mode = "I";
            }
            else
            {
                objThekaParamarsa.Mode = "U";
                objThekaParamarsa.BarsikThekaPId = hidThekaParamarsaId.Value.ToDecimal();
            }

            //paramarsa swadeshi
            objThekaParamarsa.PFTSwadeshiNo = txtPSFirstTNo.Text.ToDecimal();
            objThekaParamarsa.PFTSwadeshiRakam = txtPSFirstTRakam.Text.ToDecimal();
            objThekaParamarsa.PSTSwadeshiNo = txtPSSecondTNo.Text.ToDecimal();
            objThekaParamarsa.PSTSwadesiRakam = txtPSSSecondTRakam.Text.ToDecimal();
            objThekaParamarsa.PTTSwadeshiNo = txtPSThirdTNo.Text.ToDecimal();
            objThekaParamarsa.PTTSwadeshiRakam = txtPSThirdTRakam.Text.ToDecimal();
            //pragati
            objThekaParamarsa.PFPSwadeshiNo = 0;
            objThekaParamarsa.PFPSwadeshiRakam = 0;
            objThekaParamarsa.PSPSwadeshiNo = 0;
            objThekaParamarsa.PSPSwadesiRakam = 0;
            objThekaParamarsa.PTPSwadeshiNo = 0;
            objThekaParamarsa.PTPSwadeshiRakam = 0;
            //end

            //paramarsadata bideshi
            objThekaParamarsa.PFTBideshiNo = txtPBFirstTNo.Text.ToDecimal();
            objThekaParamarsa.PFTBideshiRakam = txtPBFirstTRakam.Text.ToDecimal();
            objThekaParamarsa.PSTBideshiNo = txtPBSecondTNo.Text.ToDecimal();
            objThekaParamarsa.PSTBideshiRakam = txtPBSecondTRakam.Text.ToDecimal();
            objThekaParamarsa.PTTBideshiNo = txtPBThirdTNo.Text.ToDecimal();
            objThekaParamarsa.PTTBideshiRakam = txtPBThirdTRakam.Text.ToDecimal();
            //pragati
            objThekaParamarsa.PFPBideshiNo = 0;
            objThekaParamarsa.PFPBideshiRakam = 0;
            objThekaParamarsa.PSPBideshiNo = 0;
            objThekaParamarsa.PSPBideshiRakam = 0;
            objThekaParamarsa.PTPBideshiNo = 0;
            objThekaParamarsa.PTPBideshiRakam = 0;
            //end
            //
            //theka details//
            objThekaParamarsa.ThekaFTNo = txtThekaFirstTNo.Text.ToDecimal();
            objThekaParamarsa.ThekaFTRakam = txtThekaFirstTRakam.Text.ToDecimal();
            objThekaParamarsa.ThekaSTNo = txtThekaSecondTNO.Text.ToDecimal();
            objThekaParamarsa.ThekaSTRakam = txtThekaSecondTRakam.Text.ToDecimal();
            objThekaParamarsa.ThekaTTNo = txtThekaThirdTNo.Text.ToDecimal();
            objThekaParamarsa.ThekaTTRakam = txtThekaThirdTRakam.Text.ToDecimal();
            //pragati
            objThekaParamarsa.ThekaFPNo = 0;
            objThekaParamarsa.ThekaFPRakam = 0;
            objThekaParamarsa.ThekaSPNo = 0;
            objThekaParamarsa.ThekaSPRakam = 0;
            objThekaParamarsa.ThekaTPNo = 0;
            objThekaParamarsa.ThekaTPRakam = 0;

            //end
            objThekaParamarsa.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objThekaParamarsa.ProjectId = Session["projectId"].ToInt32();
            objThekaParamarsa.ModifiedBy = Session["username"].ToString();
            objThekaParamarsa.ModifiedDate = DateTime.Now;
            objBarsikService.InsertUpdateProjectBarsikThekaParamarsa(objThekaParamarsa);

            //upload multiple files
            ProjectBarsikThekaParamarsaBO objBo = new ProjectBarsikThekaParamarsaBO();
            objBarsikService = new BarsikKaryekramService();
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();

            //insert barshik anya
            int a = objBarsikService.InsertUpdateBarshikAnya(objBarshikAnyaBo);

            int b = objBarsikService.InsertUpdateBarshikBharit(objBarsikBharitBo);

            objBo.FiscalYearId = Session["fiscal_year_id"].ToInt32();
            objBo.ProjectId = Session["projectId"].ToInt32();
            string allFiles = "";
            ///// file upload remains
            if (FileBarshikUpload.HasFile) // CHECK IF ANY FILE HAS BEEN SELECTED.
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
                        String newfolder = Server.MapPath("~") + @"BarshikFiles\";
                        String path = newfolder + str;
                        hpf.SaveAs(path);
                        allFiles += str + ",";
                    }
                }
                objBo.BarshikFileName = allFiles;
            }
            else
            {
                DataTable BarshikFile = (DataTable)Session["dtBarshikFile"];
                if (BarshikFile != null && BarshikFile.Rows.Count > 0)
                {
                    //update case
                    objBo.BarshikFileName = Session["existingFilename"].ToString();
                }
                else
                {
                    //insert case
                    objBo.BarshikFileName = "";
                }
            }

            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            int j = objBarsikService.InsertUpdateBarshikFile(objBo);

            Response.Redirect(Constants.ConstantAppPath + "/Modules/BarsikKaryekram/BarsikKaryekram.aspx");
            /*if (FileBarshik.HasFile)
            {
                ProjectBarsikThekaParamarsaBO objBo = new ProjectBarsikThekaParamarsaBO();
                objBarsikService = new BarsikKaryekramService();
                objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
                //lblImage.Text = DateTime.Now + FileBarshik.FileName;
                string ext = System.IO.Path.GetExtension(this.FileBarshik.PostedFile.FileName);
                var splitseparator = new string[] { ext };
                var result = Splitstring(DateTime.Now + FileBarshik.FileName, splitseparator);
                String source = result[0];
                string str = source  + ext;
                str = Regex.Replace(str, @"/", "_");
                str = Regex.Replace(str, @":", "_");
                objBo.BarshikFileName = str;
                objBo.FiscalYearId = Session["fiscal_year_id"].ToInt32();
                objBo.ProjectId = Session["projectId"].ToInt32();
                UploadFile(FileBarshik, str);
                int i=objBarsikService.InsertUpdateBarshikFile(objBo);

            }*/


        }

        protected string[] Splitstring(String source, String[] splitseparator)
        {
            String[] result = source.Split(splitseparator, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        private void UploadFile(FileUpload fileUpload, String str)
        {
            String newfolder = Server.MapPath("~") + @"\BarshikFiles\";
            if (!Directory.Exists(newfolder))
            {
                Directory.CreateDirectory(newfolder);
            }
            fileUpload.PostedFile.SaveAs(newfolder + "/" + str);

        }


        protected void grdUploadedFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                string url = Constants.ConstantAppPath + "/BarshikFiles/" + e.CommandArgument.ToString();
                //Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", Constants.ConstantAppPath + "/BarshikFiles/" + e.CommandArgument.ToString()));
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + url + "','_blank')", true);
            }
        }
        
    }
}