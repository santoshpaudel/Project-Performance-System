using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON;
using MISDAL.OfficeManagement;

namespace MIS
{
    /// <summary>
    /// Summary description for OfficeManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OfficeManagementService : BaseService
    {


        OfficeManagementDAL objOfficeDal
        {
            get { return new OfficeManagementDAL(); }
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public void DeleteOffice(string id)
        {
            Authentication();
            objOfficeDal.DeleteOffice(int.Parse(id));
        }


        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable FetchOfficeHierarchy(int id)
        {
            Authentication();
            DataTable dt = null;
            dt = objOfficeDal.FetchOfficeHierarchy(id);
            return dt;
        }


        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddOffice(ComOffice objComOffice, int entryMode, int officeId)
        {
            Authentication();
            return objOfficeDal.AddOffice(objComOffice, entryMode, officeId);
        }

        [WebMethod]
        public DataTable PopulateOfficeDetails(int i)
        {
            return objOfficeDal.PopulateOfficeDetails(i);
        }
        [WebMethod]
        public DataTable populateOfficeType()
        {

            return objOfficeDal.populateOfficeType();
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable FetchAllOffice(string lang)
        {
            Authentication();
            return objOfficeDal.FetchAllOffice(lang);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FetchOffice(string id)
        {
            if (id == "#")
            {
                var tree = new JsTreeModel[]
                               {
                                   new JsTreeModel
                                       {
                                           text = "Office",
                                           attr = new JsTreeAttribute {id = "0", selected = true}
                                       }
                               };

                this.Context.Response.ContentType = "application/json; charset=utf-8";

                this.Context.Response.Write(new JavaScriptSerializer().Serialize(tree).Replace("null", "true"));
            }
            else
            {
                DataTable dt = null;
                var tree1 = new JsTreeModel[] { };
                dt = objOfficeDal.FetchOfficeHierarchy(int.Parse(id));
                if (dt != null && dt.Rows.Count > 0)
                {
                    tree1 = new JsTreeModel[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        tree1[i] =
                            new JsTreeModel
                            {
                                text = dr["office_nep_name"].ToString(),
                                attr = new JsTreeAttribute { id = dr["child_office_id"].ToString(), selected = true }
                            };
                        i++;
                    }
                }
                this.Context.Response.ContentType = "application/json; charset=utf-8";

                this.Context.Response.Write(new JavaScriptSerializer().Serialize(tree1).Replace("null", "true"));
            }

        }

    }
}
