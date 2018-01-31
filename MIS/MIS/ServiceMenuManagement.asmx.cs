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
using MISDAL;
using MISDAL.MenuManagement;

namespace MIS
{
    /// <summary>
    /// Summary description for ServiceMenuManagement
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceMenuManagement : BaseService
    {
        MenuManagementDAL objMenuDal
        {
            get { return new MenuManagementDAL(); }
        }

        [WebMethod]
        public void test(string menuId)
        {
            string str = string.Empty;
            DataSet ds = null;
            DataTable dt = null;
            DataTable dtRole = null;
            string pathAdd = string.Empty;
            string pathRemove = string.Empty;
            pathAdd = "../images/wrightMark.gif";
            pathRemove = "../images/delete.gif";
            string path = string.Empty;
            string roleId = string.Empty;
            string permission = string.Empty;
            //string menuId = string.Empty;
            ds = objMenuDal.FetchMenuPermission(int.Parse(menuId), 1);
            str = str + "<table class=\"table table-bordered table-condensed table-hover table-responsive \" ><tr><th>Role</th><th>Add</th><th>edit</th><th>delete</th><th>View</th></tr>";
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                dtRole = ds.Tables[1];
            }

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    permission = "1";
                    roleId = dr["role_id"].ToString();
                    str = str + "<tr><td>" + dr["role_eng_name"] + "</td>";
                    path = pathRemove;
                    if (dr["allow_add"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'A'," + permission + ")><img src='" + path + "'  /></a></td>";
                    //edit
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_edit"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'E'," + permission + ")><img src='" + path + "'  /></a></td>";
                    //delete
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_delete"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'D'," + permission + ")><img src='" + path + "'  /></a></td>";
                    //view
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_view"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'V'," + permission + ")><img src='" + path + "'  /></a></td>";
                    //verify_level1
                    //view
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_verify_level_1"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'VR1'," + permission + ")><img src='" + path + "'  /></a></td>";
                    
                    //verify_level2
                    //view
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_verify_level_2"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'VR2'," + permission + ")><img src='" + path + "'  /></a></td>";
                    //verify_level_3
                    //view
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_verify_level_3"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'VR3'," + permission + ")><img src='" + path + "'  /></a></td>";
                    //verify_level_4
                    //view
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_verify_level_4"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'VR4'," + permission + ")><img src='" + path + "'  /></a></td>";
                    
                    str = str + "</tr>";
                }

            }
            if (dtRole != null && dtRole.Rows.Count > 0)
            {
                foreach (DataRow dr in dtRole.Rows)
                {
                    path = pathRemove;
                    roleId = dr["role_id"].ToString();
                    str = str + "<tr><td>" + dr["role_eng_name"] + "</td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'A'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'E'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'D'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId + ",'V'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "</tr>";
                }

            }
            //dt = objDal.FetchRoles();


            str = str + "</table>";
            this.Context.Response.Write(str);
        }


       [WebMethod, SoapHeader("spAuthenticationHeader")]
        public void DeleteMenu(string id)
        {
           
            objMenuDal.DeleteMenu(int.Parse(id));
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable FetchMenuHierarchy(int id,string lang,int roleId)
        {
            Authentication();
            DataTable dt = null;
            dt = objMenuDal.FetchMenuHierarchy(id,lang,roleId);
            return dt;
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataSet FetchMenuPermission(int module, int role)
        {
            Authentication();
            DataSet ds = null;
            ds = objMenuDal.FetchMenuPermission(module, role);
            return ds;
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public void ChangePermission(ComMenuRolePermissionBO objBo)
        {
            Authentication();
            
            objMenuDal.InsertUpdateMenuPermission(objBo);
        }

        [WebMethod]
        public int AddMenu(ComMenu objComMenu, int entryMode, int menuId)
        {
            
            return objMenuDal.AddMenu(objComMenu, entryMode, menuId);
        }
        [WebMethod]
        public DataTable PopulateMenuDetails(int menuId)
        {
           
            return objMenuDal.PopulateMenuDetails(menuId);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FetchMenu(string id,string lang,int roleId)
        {
            if (id == "#")
            {
                var tree = new JsTreeModel[]
                               {
                                   new JsTreeModel
                                       {
                                           text = "Menu",
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
                dt = objMenuDal.FetchMenuHierarchy(int.Parse(id),lang,roleId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    tree1 = new JsTreeModel[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        tree1[i] =
                            new JsTreeModel
                            {
                                text = dr["menu_eng_name"].ToString(),
                                attr = new JsTreeAttribute { id = dr["menu_id"].ToString(), selected = true }
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
