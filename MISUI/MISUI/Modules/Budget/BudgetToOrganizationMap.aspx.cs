using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MISUI.ServiceMenuOffice;
using MISUICOMMON.Constants;
using MISUICOMMON.HelperClass;

namespace MISUI.Modules.Budget
{
    public partial class BudgetToOrganizationMap : Base
    {
        //private static DataTable dtPopulateBudgetHead = null;
        private Service1 objService1 = null;
        //private static DataTable dtMinistries = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBudgetHead();
                PopulateMinistries();
            }
        }

        private void PopulateMinistries()
        {
           objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            Session["dtMinistries"] = objService1.PopulateMinistriesForMap();
            DataTable dtMinistries = (DataTable) Session["dtMinistries"];
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
                ddlMinistry.Items.Insert(0,"--छान्नुहोस्--");
            }
        }
        private void PopulateOffices(int ministryId)
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            Session["dtOffices"] = objService1.PopulateAllOffices(ministryId);
            DataTable dtOffices = (DataTable)Session["dtOffices"];
            if (dtOffices != null && dtOffices.Rows.Count > 0)
            {
                ddlOffice.DataSource = dtOffices;
                if (Session["LanguageSetting"].ToString() == "Nepali")
                {
                    ddlOffice.DataTextField = "OFFICE_NEP_NAME";
                }
                else
                {
                    ddlOffice.DataTextField = "OFFICE_ENG_NAME";

                }

                ddlOffice.DataValueField = "OFFICE_ID";
                ddlOffice.DataBind();
            }
        }

        private void PopulateBudgetHead()
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            Session["dtPopulateBudgetHead"] = objService1.PopulateAllBudgetHeads(Session["LanguageSetting"].ToString(), Session["ministry_id"].ToInt32());
            DataTable dtPopulateBudgetHead = (DataTable) Session["dtPopulateBudgetHead"];
            if (dtPopulateBudgetHead != null && dtPopulateBudgetHead.Rows.Count > 0)
            {
                ddlBudgetHead.DataSource = dtPopulateBudgetHead;
                ddlBudgetHead.DataTextField = "BUDGET_HEAD_NAME";
                ddlBudgetHead.DataValueField = "BUDGET_HEAD_ID";
                ddlBudgetHead.DataBind();
                ddlBudgetHead.Items.Insert(0, "--छान्नुहोस्--");
            }

        }

        protected void ddlBudgetHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateMinistries();
            ddlOffice.DataSource = null;
            ddlOffice.DataBind();
        }

        private void PopulateBudgetUserMap(int budgetHeadId)
        {
            DataTable dtUsers = (DataTable)Session["dtUsers"];
            chkUsers.DataSource = dtUsers;
            if (Session["LanguageSetting"].ToString() == "Nepali")
            {
                chkUsers.DataTextField = "USER_NEP_NAME";
            }
            else
            {
                chkUsers.DataTextField = "USER_ENG_NAME";

            }
            chkUsers.DataValueField = "USER_ID";
            chkUsers.DataBind();
            DataTable dt = null;
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            /*dt = objService1.PopulateBudgetOrganizationMap(budgetHeadId);*/
            dt = objService1.PopulateBudgetUserMap(budgetHeadId);
            if(dt!=null && dt.Rows.Count>0)
            {
                List<string> users = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++ )
                {
                    users.Add(dt.Rows[i]["USER_ID"].ToString());
                }

                for (int k = 0; k < chkUsers.Items.Count; k++)
                    {
                        for (int j = 0; j < users.Count; j++)
                        {
                            if (chkUsers.Items[k].Value == users[j])
                            {
                                chkUsers.Items[k].Selected = true;
                                break;
                            }
                        }
                    }
            }
        }

        protected void btnMap_Click(object sender, EventArgs e)
        {
            // Clear Budget User Map
            int j = 0;
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            //j=objService1.ClearBudgetOrganizationMap(ddlBudgetHead.SelectedValue.ToInt32());
            if (ddlBudgetHead.SelectedValue.ToInt32() > 0)
            {
                if (ddlMinistry.SelectedValue.ToInt32() > 0)
                {
                    if (ddlOffice.SelectedValue.ToInt32() > 0)
                    {
                        j = objService1.ClearBudgetUserMap(ddlOffice.SelectedValue.ToInt32(), ddlBudgetHead.SelectedValue.ToInt32(),ddlMinistry.SelectedValue.ToInt32());
                        int i = 0;
                        foreach (ListItem it in chkUsers.Items)
                        {
                            if (it.Selected)
                            {
                                objService1 = new Service1();
                                objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
                                /* i = objService1.InsertBudgetOrganizationMap(ddlBudgetHead.SelectedValue.ToInt32(),
                                                                                it.Value.ToInt32());*/
                                i = objService1.InsertBudgetUserMap(ddlBudgetHead.SelectedValue.ToInt32(),
                                    ddlMinistry.SelectedValue.ToInt32(), ddlOffice.SelectedValue.ToInt32(),
                                    it.Value.ToInt32());

                            }
                        }
                        if (i > 0)
                        {
                            Response.Write("<script>alert('Mapping Successful')</script>");
                            Response.Redirect(Constants.ConstantAppPath + "/Modules/Budget/BudgetToOrganizationMap.aspx");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please select office')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please select ministry')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please budget head')</script>");
            }

        }

        protected void ddlMinistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOffice.DataSource = null;
            ddlOffice.DataBind();
            PopulateOffices(ddlMinistry.SelectedValue.ToInt32());
        }

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkUsers.DataSource = null;
            chkUsers.DataBind();
            PopulateUsersByOfficeId(ddlOffice.SelectedValue.ToInt32());
            PopulateBudgetUserMap(ddlBudgetHead.SelectedValue.ToInt32());
            
        }

        private void PopulateUsersByOfficeId(int officeId)
        {
            objService1 = new Service1();
            objService1.AuthSoapHdValue = ServiceAuth.ServiceAuthentication();
            Session["dtUsers"] = objService1.PopulateAllUsersByOfficeId(officeId);
            DataTable dtUsers = (DataTable)Session["dtUsers"];
            if (dtUsers != null && dtUsers.Rows.Count > 0)
            {
                chkUsers.DataSource = dtUsers;
                if (Session["LanguageSetting"].ToString() == "Nepali")
                {
                    chkUsers.DataTextField = "USER_NEP_NAME";
                }
                else
                {
                    chkUsers.DataTextField = "USER_ENG_NAME";

                }

                chkUsers.DataValueField = "USER_ID";
                chkUsers.DataBind();
            }
        }
    }

}