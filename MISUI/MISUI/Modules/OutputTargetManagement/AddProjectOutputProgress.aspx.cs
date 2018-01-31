using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceBarsikKaryekram;
using MISUI.ServiceProject;
using MISUICOMMON.Constants;
using MISUICOMMON.QueryString;
using MISUICOMMON.HelperClass;

namespace MISUI.Modules.OutputTargetManagement
{
    public partial class AddProjectOutputTarget : Base
    {
        //private ProjectVerificationBO projectVerificationBo = null;
        private ProjectService wbs = null;
        private BarsikKaryekramService objBarsikService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divContent.Visible = false;
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
                if (Session["pChaumasikId"] != null && Session["pChaumasikId"].ToString() != "0")
                {
                    ddlChaumasik.SelectedValue = Session["pChaumasikId"].ToString();
                    PopulateProgress();

                }
            }

        }

        protected void ddlChaumarsik_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProgress();
        }

        private void PopulateProgress()
        {
            divContent.Visible = false;
            Session["pChaumasikId"] = ddlChaumasik.SelectedValue;
            PopulateAllProgress();
            foreach (GridViewRow row in grdTarget.Rows)
            {
                TextBox txtFirst = (TextBox)row.FindControl("txtFirstQuarterProgress");
                TextBox txtSecond = (TextBox)row.FindControl("txtSecondQuarterProgress");
                TextBox txtThird = (TextBox)row.FindControl("txtThirdQuarterProgress");
                if (ddlChaumasik.SelectedValue.ToInt32() == 1)
                {
                    divContent.Visible = true;
                    txtFirst.Enabled = true;
                    txtSecond.Enabled = false;
                    txtThird.Enabled = false;
                }
                else if (ddlChaumasik.SelectedValue.ToInt32() == 2)
                {
                    divContent.Visible = true;
                    txtFirst.Enabled = false;
                    txtSecond.Enabled = true;
                    txtThird.Enabled = false;
                }
                else if (ddlChaumasik.SelectedValue.ToInt32() == 3)
                {
                    divContent.Visible = true;
                    txtFirst.Enabled = false;
                    txtSecond.Enabled = false;
                    txtThird.Enabled = true;
                }
                else
                {
                    divContent.Visible = false;
                }
            }
        }

        private void PopulateAllProgress()
        {
            objBarsikService = new BarsikKaryekramService();
            ProjectOutputTBarsikBO objProjectOutBarsik = new ProjectOutputTBarsikBO();
            objProjectOutBarsik.Lang = SessionHelper.SessionLanguageSetting;
            objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
            objProjectOutBarsik.ProjectId = Session["projectId"].ToInt32();
            objProjectOutBarsik.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            //objProjectOutBarsik.ChaumasikId = SessionHelper.SessionFiscalYear.ToInt32();
            Session["dtProgress"] = objBarsikService.PopulateProjectProgress(objProjectOutBarsik);
            DataTable dtProgress = (DataTable)Session["dtProgress"];
            if (dtProgress != null && dtProgress.Rows.Count > 0)
            {
                grdTarget.DataSource = dtProgress;
                grdTarget.DataBind();
                lblModification.Text = dtProgress.Rows[0]["OP_MODIFIED_DATE"].ToDateTime().ToString("D");
                lblModifiedBy.Text = dtProgress.Rows[0]["OP_MODIFIED_BY"].ToString();
            }
        }

        protected void GrdTarget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int i = 0;
            ProjectOutputTBarsikBO objProjectOutBarsik = new ProjectOutputTBarsikBO();
            if (e.CommandName == "edit")
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);//
                int RowIndex = gvr.RowIndex;
                /*objProjectOutBarsik.PTargetId =
                    ((HiddenField)grdTarget.Rows[RowIndex].FindControl("hidProjectOutputId")).Value.ToDecimal();*/
                objProjectOutBarsik.ProjectOutputId = e.CommandArgument.ToString().ToInt32();
                objProjectOutBarsik.PTargetFirstP = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtFirstQuarterProgress")).Text;
                objProjectOutBarsik.PTargetSecondP = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtSecondQuarterProgress")).Text;
                objProjectOutBarsik.PTargetThirdP = ((TextBox)grdTarget.Rows[RowIndex].FindControl("txtThirdQuarterProgress")).Text;
                objProjectOutBarsik.ProjectId = Session["projectId"].ToInt32();
                objProjectOutBarsik.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
                objProjectOutBarsik.ModifiedBy = Session["username"].ToString();
                objProjectOutBarsik.ModifiedDate = DateTime.Now;
                if (ddlChaumasik.SelectedValue == "1")
                    {
                        objProjectOutBarsik.Mode = "UF";
                    }
                else if (ddlChaumasik.SelectedValue == "2")
                    {
                        objProjectOutBarsik.Mode = "US";
                    }
                else
                    {
                        objProjectOutBarsik.Mode = "UT";
                    }
              

                objBarsikService = new BarsikKaryekramService();
                objBarsikService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationBarsikKaryekram();
                i = objBarsikService.InsertUpdateProjectOutputProgress(objProjectOutBarsik);
                if (i > 0)
                {
                    Response.Write("<script>alert('Target successfully recorded.') </script>");
                    Response.Redirect(Constants.ConstantAppPath + "/Modules/OutputTargetManagement/AddProjectOutputProgress.aspx");
                    //PopulateProgress();
                }
                else
                {
                    Response.Write("<script>alert('Target not recorded.') </script>");
                }
            }
        }

        protected void grdTarget_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
    }
}