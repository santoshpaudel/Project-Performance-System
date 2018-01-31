using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceActivityMgmt;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;
using MISUICOMMON.QueryString;

namespace MISUI.Modules.ProjectManagement
{
    public partial class AddEditProjectAdministrativeDetails : System.Web.UI.Page
    {
        private DataTable dtPopulateBudgetHead = null;
        private Service1 objService1 = null;
        DataTable dtA = new DataTable();
        ProjectService wbs = new ProjectService();
        private ComProjectBO objProjectBO = null;
        //private  static DataTable dt = null;
        //public static int projectId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // PopulateBudgetHead();
                rptBhautikSamagri.DataSource = null;
                rptBhautikSamagri.DataBind();
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
                    btnAddAdminDetails.Enabled = false;
                    btnAddAdminDetails.Visible = false;
                    btnAddBhautikSamagri.Enabled = false;
                    btnAddBhautikSamagri.Visible = false;
                }
                if (Session["projectId"].ToInt32() > 0)
                {
                    PopulateAdministrativeDetails(Session["projectId"].ToInt32());
                }
            }
        }
        /*private void PopulateBudgetHead()
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

        protected void rptBhautikSamagri_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ActivityManagementService objAms = new ActivityManagementService();
                DropDownList ddlUnit = (DropDownList)e.Item.FindControl("ddlUnit");
                ActivityDetailBO objAdb = new ActivityDetailBO();
                objAdb.Lang = Session["LanguageSetting"].ToString();
                objAms.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
                DataTable dtUnit = objAms.SelectActivityUnit(objAdb);

                if (dtUnit != null && dtUnit.Rows.Count > 0)
                {
                    ddlUnit.DataSource = dtUnit;
                    ddlUnit.DataTextField = "UNIT_NAME";
                    ddlUnit.DataValueField = "UNIT_ID";
                    ddlUnit.DataBind();
                    ddlUnit.Items.Insert(0, "--छान्नुहोस्--");
                }
                DropDownList ddlPlanUnit = new DropDownList();
                ddlPlanUnit = (DropDownList)e.Item.FindControl("ddlUnit");
                ddlPlanUnit.SelectedValue = dtA.Rows[e.Item.ItemIndex]["UNIT_ID"].ToString();

            }
        }

        protected void btnAddBhautikSamagri_Click(object sender, EventArgs e)
        {
            dtA.Clear();
            dtA.Columns.Add("BHAUTIK_SAMAGRI_ID");
            dtA.Columns.Add("PROJECT_ID");
            dtA.Columns.Add("ITEM_NAME");
            dtA.Columns.Add("UNIT_ID");
            dtA.Columns.Add("QUANTITY");
            dtA.Columns.Add("ANUMANIT_RAKAM");
            dtA.Columns.Add("SAMAGRI_KAIFIYAT");
            TextBox txtSamagriName = new TextBox();
            DropDownList ddlUnit = new DropDownList();
            TextBox txtQuantity = new TextBox();
            TextBox txtAnumanitRakam = new TextBox();
            TextBox txtSamagriKaifiyat = new TextBox();
            foreach (RepeaterItem rptItem in rptBhautikSamagri.Items)
            {
                DataRow drA = dtA.NewRow();
                txtSamagriName = (TextBox)rptItem.FindControl("txtItemName");
                ddlUnit = (DropDownList)rptItem.FindControl("ddlUnit");
                txtQuantity = (TextBox)rptItem.FindControl("txtQuantity");
                txtAnumanitRakam = (TextBox)rptItem.FindControl("txtAnumanitRakam");
                txtSamagriKaifiyat = (TextBox)rptItem.FindControl("txtSamagriKaifiyat");
                drA["ITEM_NAME"] = txtSamagriName.Text;
                drA["UNIT_ID"] = ddlUnit.SelectedValue.ToInt32();
                drA["QUANTITY"] = txtQuantity.Text;
                drA["ANUMANIT_RAKAM"] = txtAnumanitRakam.Text;
                drA["SAMAGRI_KAIFIYAT"] = txtSamagriKaifiyat.Text;
                if (txtQuantity.Text != "" || txtAnumanitRakam.Text != "")
                    dtA.Rows.Add(drA);
            }

            DataRow drB = dtA.NewRow();
            drB["ITEM_NAME"] = "";
            drB["UNIT_ID"] = 0;
            drB["QUANTITY"] = "";
            drB["ANUMANIT_RAKAM"] = "";
            drB["SAMAGRI_KAIFIYAT"] = "";
            dtA.Rows.Add(drB);

            // to empty the repeater
            DataTable db = new DataTable();
            rptBhautikSamagri.DataSource = db;
            rptBhautikSamagri.DataBind();

            rptBhautikSamagri.DataSource = dtA;
            rptBhautikSamagri.DataBind();
        }

        //protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    //to clear the repeater before dropdown-selected value gets changed
        //    rptBhautikSamagri.DataSource = null;
        //    rptBhautikSamagri.DataBind();

        //    PopulateAdministrativeDetails(ddlProject.SelectedValue.ToInt32());
        //}

        private void PopulateAdministrativeDetails(int projectId)
        {

            DataTable dtBhautikSamagri = null;
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = projectId;
            wbs = new ProjectService();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            Session["dt"] = wbs.PopulateAdministrativeDetails(objProjectBO);
            DataTable dt = (DataTable)Session["dt"];
            if (dt != null && dt.Rows.Count > 0)
            {
                rbdExistingJanashakti.SelectedValue = dt.Rows[0]["EXISTING_JANASHAKTI"].ToString();
                txtThapJanashakti.Text = dt.Rows[0]["THAP_JANASHAKTI"].ToString();
                txtJanaShaktiKaifiyat.Text = dt.Rows[0]["THAP_JANASHAKTI_KAIFIYAT"].ToString();
                txtMinistryRaaya.Text = dt.Rows[0]["MINISTRY_RAAYA"].ToString();
                txtChuttayiyekoRakam.Text = dt.Rows[0]["CHUTTAYIYEKO_RAKAM"].ToString();
                txtDaatriBibaran.Text = dt.Rows[0]["DAATRI_BIBARAN"].ToString();
                txtNepalSarkarBibaran.Text = dt.Rows[0]["NEPAL_SARKAR_BIBARAN"].ToString();
                txtPhaseOutPlan.Text = dt.Rows[0]["PHASE_OUT_PLAN"].ToString();
                dtBhautikSamagri = wbs.PopulateBhautikSamagri(objProjectBO);
                dtA = dtBhautikSamagri;
                if (dtBhautikSamagri != null && dtBhautikSamagri.Rows.Count > 0)
                {
                    rptBhautikSamagri.DataSource = dtBhautikSamagri;
                    rptBhautikSamagri.DataBind();
                    foreach (RepeaterItem rptItem in rptBhautikSamagri.Items)
                    {
                        TextBox txtItem = new TextBox();
                        DropDownList ddlUnit = new DropDownList();
                        TextBox txtAnumanitRakam = new TextBox();
                        TextBox txtQuantity = new TextBox();
                        TextBox txtSamagriKaifiyat = new TextBox();
                        txtItem = (TextBox)rptItem.FindControl("txtItemName");
                        ddlUnit = (DropDownList)rptItem.FindControl("ddlUnit");
                        txtQuantity = (TextBox)rptItem.FindControl("txtQuantity");
                        txtAnumanitRakam = (TextBox)rptItem.FindControl("txtAnumanitRakam");
                        txtSamagriKaifiyat = (TextBox)rptItem.FindControl("txtSamagriKaifiyat");

                    }
                }
                else
                {

                    dtA.Clear();
                    DataRow drB = dtA.NewRow();
                    drB["ITEM_NAME"] = "";
                    drB["UNIT_ID"] = 0;
                    drB["QUANTITY"] = 0;
                    drB["ANUMANIT_RAKAM"] = 0;
                    drB["SAMAGRI_KAIFIYAT"] = "";
                    dtA.Rows.Add(drB);

                    rptBhautikSamagri.DataSource = dtA;
                    rptBhautikSamagri.DataBind();
                }
            }
        }

        protected void btnAddAdminDetails_Click(object sender, EventArgs e)
        {
            int i = 0;
            objProjectBO = new ComProjectBO();
            objProjectBO.ProjectId = Session["projectId"].ToInt32();
            objProjectBO.ExistingJanashakti = rbdExistingJanashakti.SelectedValue.ToInt32();
            objProjectBO.ThapJanashakti = txtThapJanashakti.Text.ToInt32();
            objProjectBO.MinistryRaaya = txtMinistryRaaya.Text;
            objProjectBO.ChuttayiyekoRakam = txtChuttayiyekoRakam.Text.ToDecimal();
            objProjectBO.DaatriBibaran = txtDaatriBibaran.Text;
            objProjectBO.NepalSarkarBibaran = txtNepalSarkarBibaran.Text;
            objProjectBO.MantralayaBibaran = txtMantralayaBibaran.Text;
            objProjectBO.PhaseOutPlan = txtPhaseOutPlan.Text;
            objProjectBO.ThapJanashaktiKaifiyat = txtJanaShaktiKaifiyat.Text;
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
            i = wbs.SaveAdminDetails(objProjectBO);
            if (i > 0)
            {
                int j = 0;
                //To clear project bhautik samagri
                objProjectBO = new ComProjectBO();
                objProjectBO.ProjectId = Session["projectId"].ToInt32();
                wbs = new ProjectService();
                wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                wbs.ClearBhautikSamagri(objProjectBO);

                TextBox txtBhautikSamagri = new TextBox();
                DropDownList ddlUnit = new DropDownList();
                TextBox txtQuantity = new TextBox();
                TextBox txtAnumanitRakam = new TextBox();
                TextBox txtSamagriKaifiyat = new TextBox();
                foreach (RepeaterItem rptItem in rptBhautikSamagri.Items)
                {
                    int k = 0;
                    txtBhautikSamagri = (TextBox)rptItem.FindControl("txtItemName");
                    ddlUnit = (DropDownList)rptItem.FindControl("ddlUnit");
                    txtQuantity = (TextBox)rptItem.FindControl("txtQuantity");
                    txtAnumanitRakam = (TextBox)rptItem.FindControl("txtAnumanitRakam");
                    txtSamagriKaifiyat = (TextBox)rptItem.FindControl("txtSamagriKaifiyat");
                    objProjectBO = new ComProjectBO();
                    objProjectBO.ProjectId = Session["projectId"].ToInt32();
                    objProjectBO.BhautikSamagri = txtBhautikSamagri.Text;
                    objProjectBO.UnitId = ddlUnit.SelectedValue.ToInt32();
                    objProjectBO.Quantity = txtQuantity.Text.ToDecimal();
                    objProjectBO.AnumanitRakam = txtAnumanitRakam.Text.ToDecimal();
                    objProjectBO.SamagriKaifiyat = txtSamagriKaifiyat.Text;
                    wbs = new ProjectService();
                    wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
                    k = wbs.SaveBhautikSamagri(objProjectBO);

                }
                Response.Write("<script>alert('Project administrative details added successfully!')</script>");
                SecureQueryString str = new SecureQueryString();
                str["id"] = Session["projectId"].ToString();
                Response.Redirect(Constants.ConstantAppPath + "/Modules/ProjectManagement/AddEditProjectOtherDetails.aspx" + str.EncryptedString);
            }
            else
            {
                Response.Write("<script>alert('Project other details addition failed!')</script>");
            }
        }

        /*protected void ddlBudgetHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateProject = new DataTable();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            //objComProjectBO.BudgetHeadId = ddlBudgetHead.SelectedValue.ToInt32();
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
    }
}