using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using MISUI.ServiceActivityMgmt;
using MISUI.ServiceMenu;
using MISUI.ServiceMenuOffice;
using MISUI.ServiceOfficeMgmt;
using MISUI.ServiceProject;
using MISUI.ServiceSectorMgmt;
using MISUICOMMON.HelperClass;
using WebApplication1;
using ComSubSector = MISUI.ServiceSectorMgmt.ComSubSector;
using EntitySubSector = MISUI.ServiceProject.ComSubSector;


namespace MISUI
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private Service1 objService = new Service1();
        ServiceMenuManagement objServiceMenu = new ServiceMenuManagement();
        OfficeManagementService objServiceOffice = new OfficeManagementService();

        public string lang = null;

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void HelloWorld(string id)
        {
            if (id == "#")
            {
                var tree = new JsTreeModel[]
                               {
                                   new JsTreeModel
                                       {
                                           text = "A",
                                           attr = new JsTreeAttribute {id = "10", selected = true}
                                       },
                                   new JsTreeModel
                                       {
                                           text = "B",
                                           attr = new JsTreeAttribute {id = "11", selected = true}
                                       }
                               };

                this.Context.Response.ContentType = "application/json; charset=utf-8";

                this.Context.Response.Write(new JavaScriptSerializer().Serialize(tree).Replace("null", "true"));
            }
            else
            {
                var tree = new JsTreeModel[] { };
                if (id == "10")
                {
                    tree = new JsTreeModel[]
                               {

                                   new JsTreeModel
                                       {
                                           text = "A1",
                                           attr = new JsTreeAttribute {id = "21"}
                                       }
                               };
                }
                if (id == "11")
                {
                    tree = new JsTreeModel[]
                               {

                                   new JsTreeModel
                                       {
                                           text = "B1",
                                           attr = new JsTreeAttribute {id = "12"}
                                       }
                               };
                }

                this.Context.Response.ContentType = "application/json; charset=utf-8";

                this.Context.Response.Write(new JavaScriptSerializer().Serialize(tree).Replace("null", "true"));

            }
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

                // Base objDal=new Base();
                DataTable dt = null;
                var tree1 = new JsTreeModel[] { };
                objServiceOffice.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOffice();
                // dt = objService.FetchOfficeHierarchy(int.Parse(id));
                dt = objServiceOffice.FetchOfficeHierarchy(int.Parse(id));
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
                                    attr = new JsTreeAttribute { id = dr["office_id"].ToString(), selected = true }
                                };
                        i++;
                    }
                }
                this.Context.Response.ContentType = "application/json; charset=utf-8";

                this.Context.Response.Write(new JavaScriptSerializer().Serialize(tree1).Replace("null", "true"));
            }

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FetchMenu(string id)
        {
            lang = Session["LanguageSetting"].ToString();

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
                objServiceMenu.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationMenu();
                dt = objServiceMenu.FetchMenuHierarchy(int.Parse(id), lang, Session["role_id"].ToInt32());
                if (dt != null && dt.Rows.Count > 0)
                {
                    tree1 = new JsTreeModel[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        tree1[i] =
                            new JsTreeModel
                                {
                                    text = dr["menu_name"].ToString(),
                                    attr = new JsTreeAttribute { id = dr["menu_id"].ToString(), selected = true }
                                };
                        i++;
                    }
                }
                this.Context.Response.ContentType = "application/json; charset=utf-8";

                this.Context.Response.Write(new JavaScriptSerializer().Serialize(tree1).Replace("null", "true"));
            }

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
            pathAdd = "../../images/wrightMark.gif";
            pathRemove = "../../images/delete.gif";
            string path = string.Empty;
            string roleId = string.Empty;
            string permission = string.Empty;
            //string menuId = string.Empty;

            //service autentication
            objServiceMenu.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationMenu();
            //service method call
            ds = objServiceMenu.FetchMenuPermission(int.Parse(menuId), 1);
            //
            str = str + "<table class='table'><tr><td>Role</td><td>Add</td><td>edit</td><td>delete</td><td>View</td></tr>";
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
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                          ",'A'," + permission + ")><img src='" + path + "'  /></a></td>";
                    //edit
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_edit"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                          ",'E'," + permission + ")><img src='" + path + "'  /></a></td>";
                    //delete
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_delete"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                          ",'D'," + permission + ")><img src='" + path + "'  /></a></td>";
                    //view
                    path = pathRemove;
                    permission = "1";
                    if (dr["allow_view"].ToString() == "1")
                    {
                        path = pathAdd;
                        permission = "0";
                    }
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                          ",'V'," + permission + ")><img src='" + path + "'  /></a></td>";
                    /*//verify_level1
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
*/
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
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                          ",'A'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                          ",'E'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                          ",'D'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                          ",'V'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    /*str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                         ",'VR1'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                         ",'VR2'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                         ",'VR3'," + 1 + ")><img src='" + path + "'  /></a></td>";
                    str = str + "<td><a href='javascript:void(0)' onclick=changePermission(" + menuId + "," + roleId +
                         ",'VR4'," + 1 + ")><img src='" + path + "'  /></a></td>";*/
                    str = str + "</tr>";
                }

            }
            //dt = objDal.FetchRoles();


            str = str + "</table>";
            this.Context.Response.Write(str);
        }

        [WebMethod]
        public void DeleteOffice(string id)
        {
            objServiceOffice.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationOffice();
            objServiceOffice.DeleteOffice(id);
        }
        [WebMethod]
        public void DeleteMenu(string id)
        {
            objServiceMenu.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationMenu();
            objServiceMenu.DeleteMenu(id);
        }

        [WebMethod]
        public void ChangePermission(string menu, string role, string mode, string permission)
        {

            ComMenuRolePermissionBO objBo = new ComMenuRolePermissionBO();
            objBo.AllowAdd = mode == "A" ? int.Parse(permission) : 0;
            objBo.AllowEdit = mode == "E" ? int.Parse(permission) : 0;
            objBo.AllowDelete = mode == "D" ? int.Parse(permission) : 0;
            objBo.AllowView = mode == "V" ? int.Parse(permission) : 0;
            objBo.AllowVerifyLevel1 = mode == "VR1" ? int.Parse(permission) : 0;
            objBo.AllowVerifyLevel2 = mode == "VR2" ? int.Parse(permission) : 0;
            objBo.AllowVerifyLevel3 = mode == "VR3" ? int.Parse(permission) : 0;
            objBo.AllowVerifyLevel4 = mode == "VR4" ? int.Parse(permission) : 0;
            objBo.MenuId = int.Parse(menu);
            objBo.RoleId = int.Parse(role);
            objBo.PermissionMode = mode;
            objServiceMenu.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationMenu();
            objServiceMenu.ChangePermission(objBo);
            test(menu);
        }

        [WebMethod(EnableSession = true)]
        public void SetMenuClick(string menuId)
        {
            Session["menuClick"] = menuId;
        }
        [WebMethod(EnableSession = true)]
        public void SetKeyboard(string keyBoard)
        {
            if (keyBoard == "1")
            {
                Session["KbdType"] = "Romanized";
            }
            else if (keyBoard == "2")
            {
                Session["KbdType"] = "Traditional";
            }
            else
            {
                Session["KbdType"] = "English";
            }



        }
        public class Combo
        {
            public int ComboId { get; set; }
            public string Name { get; set; }
        }

        public class barGraph
        {
            public string Project { get; set; }
            public decimal BhautikProgress { get; set; }
            public decimal BitiyeProgress { get; set; }

        }

        [WebMethod(EnableSession = true)]
        public List<Combo> FindActivityBySectorID(string sectorId)
        {
            ActivityManagementService wbs = new ActivityManagementService();
            ActivityDetailBO objActivityDetailBo = new ActivityDetailBO();

            DataTable dtActivity = null;
            List<Combo> objList = new List<Combo>();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            objActivityDetailBo.Lang = Session["LanguageSetting"].ToString();
            objActivityDetailBo.ActivitySubSectorId = sectorId.ToInt32();
            dtActivity = wbs.SelectActivityDetailBySector(objActivityDetailBo);
            if (dtActivity != null && dtActivity.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtActivity.Rows)
                {
                    objList.Add(new Combo { ComboId = dr["activity_detail_id"].ToInt32(), Name = dr["activity_detail_name"].ToString() });
                }
            }
            return objList;
        }
        [WebMethod(EnableSession = true)]
        public List<Combo> FindActivityOutputBySectorID(string sectorId)
        {
            ActivityManagementService wbs = new ActivityManagementService();
            ActivityDetailBO objActivityDetailBo = new ActivityDetailBO();

            DataTable dtActivity = null;
            List<Combo> objList = new List<Combo>();
            wbs.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationActivity();
            objActivityDetailBo.Lang = Session["LanguageSetting"].ToString();
            objActivityDetailBo.ActivitySubSectorId = sectorId.ToInt32();
            dtActivity = wbs.SelectActivityOutputBySector(objActivityDetailBo);
            if (dtActivity != null && dtActivity.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtActivity.Rows)
                {
                    objList.Add(new Combo { ComboId = dr["activity_output_id"].ToInt32(), Name = dr["activity_output_name"].ToString() });
                }
            }
            return objList;
        }
        [WebMethod(EnableSession = true)]
        public List<Combo> FindSubSectorBySectorId(string sectorId)
        {
            SectorService objWebService = new SectorService();
            ComSubSector objComSubSector = new ComSubSector();
            DataTable dtPopulateSubSector = null;
            List<Combo> objList = new List<Combo>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationSector();
            objComSubSector.SectorId = sectorId.ToDecimal();
            objComSubSector.Lang = Session["LanguageSetting"].ToString();
            dtPopulateSubSector = objWebService.PopulateSubSectorsBySectorId(objComSubSector);
            if (dtPopulateSubSector != null && dtPopulateSubSector.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtPopulateSubSector.Rows)
                {
                    objList.Add(new Combo { ComboId = dr["ACTIVITY_SUB_SECTOR_ID"].ToInt32(), Name = dr["SUB_SECTOR_NAME"].ToString() });
                }
            }
            return objList;
        }
        [WebMethod(EnableSession = true)]
        public List<Combo> FindRananitiBySectorId(string subSectorId)
        {
            ProjectService objWebService = new ProjectService();
            EntitySubSector objComSubSector = new EntitySubSector();
            DataTable dtPopulateRananiti = null;
            List<Combo> objList = new List<Combo>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComSubSector.SubSectorId = subSectorId.ToDecimal();
            objComSubSector.Lang = Session["LanguageSetting"].ToString();
            dtPopulateRananiti = objWebService.PopulateRananitiBySubSectorId(objComSubSector);
            if (dtPopulateRananiti != null && dtPopulateRananiti.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtPopulateRananiti.Rows)
                {
                    objList.Add(new Combo { ComboId = dr["RANANITI_ID"].ToInt32(), Name = dr["RANANITI_NAME"].ToString() });
                }
            }
            return objList;
        }
        [WebMethod(EnableSession = true)]
        public List<Combo> FindKaryanitiByRananitiId(string rananitiId)
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateKaryaniti = new DataTable();
            List<Combo> objList = new List<Combo>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.Rananiti = rananitiId.ToInt32();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            dtPopulateKaryaniti = objWebService.PopulateKaryanitiByRananitiId(objComProjectBO);
            if (dtPopulateKaryaniti != null && dtPopulateKaryaniti.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtPopulateKaryaniti.Rows)
                {
                    objList.Add(new Combo { ComboId = dr["KARYANITI_ID"].ToInt32(), Name = dr["KARYANITI_NAME"].ToString() });
                }
            }
            return objList;
        }

        [WebMethod(EnableSession = true)]
        public List<Combo> FindSahasabdiBikashGantabyaByLakshya(string lakshyaId)
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateGantabya = new DataTable();
            List<Combo> objList = new List<Combo>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.SahasabdiBikashLakshya = lakshyaId.ToInt32();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            dtPopulateGantabya = objWebService.PopulateSahashrabdiBikashGantabya(objComProjectBO);
            if (dtPopulateGantabya != null && dtPopulateGantabya.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtPopulateGantabya.Rows)
                {
                    objList.Add(new Combo { ComboId = dr["GANTABYA_ID"].ToInt32(), Name = dr["GANTABYA_NAME"].ToString() });
                }
            }
            return objList;
        }
        [WebMethod(EnableSession = true)]
        public List<Combo> FindSahasabdiBikashSuchakByGantabya(string gantabyaId)
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateSuchak = new DataTable();
            List<Combo> objList = new List<Combo>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.SahasabdiBikashGantabya = gantabyaId.ToInt32();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            dtPopulateSuchak = objWebService.PopulateSahashrabdiBikashSuchak(objComProjectBO);
            if (dtPopulateSuchak != null && dtPopulateSuchak.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtPopulateSuchak.Rows)
                {
                    objList.Add(new Combo { ComboId = dr["SUCHAK_ID"].ToInt32(), Name = dr["SUCHAK_NAME"].ToString() });
                }
            }
            return objList;
        }

        [WebMethod(EnableSession = true)]
        public List<Combo> FindDigoBikashGantabyaByLakshya(string lakshyaId)
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateGantabya = new DataTable();
            List<Combo> objList = new List<Combo>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.DigoBikashLakshya = lakshyaId.ToInt32();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            dtPopulateGantabya = objWebService.PopulateDigoBikashGantabya(objComProjectBO);
            if (dtPopulateGantabya != null && dtPopulateGantabya.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtPopulateGantabya.Rows)
                {
                    objList.Add(new Combo { ComboId = dr["DIGO_GANTABYA_ID"].ToInt32(), Name = dr["DIGO_GANTABYA_NAME"].ToString() });
                }
            }
            return objList;
        }

        [WebMethod(EnableSession = true)]
        public List<Combo> FindDigoBikashSuchakByGantabya(string gantabyaId)
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateSuchak = new DataTable();
            List<Combo> objList = new List<Combo>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.DigoBikashGantabya = gantabyaId.ToInt32();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            dtPopulateSuchak = objWebService.PopulateDigoBikashSuchak(objComProjectBO);
            if (dtPopulateSuchak != null && dtPopulateSuchak.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtPopulateSuchak.Rows)
                {
                    objList.Add(new Combo { ComboId = dr["DIGO_SUCHAK_ID"].ToInt32(), Name = dr["DIGO_SUCHAK_NAME"].ToString() });
                }
            }
            return objList;
        }


        [WebMethod(EnableSession = true)]
        public List<Combo> FindProjectByBudgetHead(string budgetHeadId)
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateProject = new DataTable();
            List<Combo> objList = new List<Combo>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            objComProjectBO.BudgetHeadId = budgetHeadId.ToInt32();
            dtPopulateProject = objWebService.PopulateProjectByBudgetHead(objComProjectBO);
            if (dtPopulateProject != null && dtPopulateProject.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtPopulateProject.Rows)
                {
                    if (Session["LanguageSetting"].ToString() == "Nepali")
                        objList.Add(new Combo { ComboId = dr["PROJECT_ID"].ToInt32(), Name = dr["PROJECT_NEP_NAME"].ToString() });
                    else
                    {
                        objList.Add(new Combo { ComboId = dr["PROJECT_ID"].ToInt32(), Name = dr["PROJECT_ENG_NAME"].ToString() });
                    }
                }
            }
            return objList;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FetchPragatiToDashboard(string ministryId, string priorityId, string chaumasikId, string fiscalYearId)
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateProject = new DataTable();
            List<barGraph> objList = new List<barGraph>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            objComProjectBO.MinistryId = ministryId.ToInt32();
            objComProjectBO.Priority = priorityId.ToInt32();
            objComProjectBO.ChaumasikId = chaumasikId.ToInt32();
            dtPopulateProject = objWebService.PopulateProjectSamastigatReport(objComProjectBO);
            if (dtPopulateProject != null && dtPopulateProject.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPopulateProject.Rows)
                {
                    objList.Add(new barGraph { Project = dr["PROJECT_NEP_NAME"].ToString(), BhautikProgress = dr["BHAUTIK_PRAGATI"].ToDecimal(), BitiyeProgress = dr["BITIYE_PRAGATI"].ToDecimal() });

                }
            }
            // return objList;

            this.Context.Response.ContentType = "application/json; charset=utf-8";

            this.Context.Response.Write(new JavaScriptSerializer().Serialize(objList).Replace("null", "true"));
        }

        [WebMethod(EnableSession = true)]
        public string GetChartData(int ministryId, string mode, int trimesterId)
        {
            string result = string.Empty;

            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();

            DataSet ds = null;
            DataTable dt = null;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.MinistryId = ministryId.ToInt32();
            objComProjectBO.FiscalYearId = SessionHelper.SessionFiscalYear.ToInt32();
            objComProjectBO.Mode = mode;
            objComProjectBO.ChaumasikId = trimesterId;
            dt = objWebService.PopulateChartData(objComProjectBO);

            // dt = ds.Tables[0];
            if (mode == "1")
            {
                result = " var chartData = [";
            }
            else if (mode == "2")
            {
                result = " var chartData2 = [";
            }
            else if (mode == "3")
            {
                result = " var chartData3 = [";
            }
            else
            {
            }
            foreach (DataRow dr in dt.Rows)
            {
                if (mode == "2" || mode == "3")
                {
                    if (dr["name"].ToString() == "<50")
                    {
                        result = result + "{'country':'" + dr["name"] + "','value50':" + dr["no"] +
                               "},";
                    }
                    else if (dr["name"].ToString() == ">50 and <80")
                    {
                        result = result + "{'country':'" + dr["name"] + "','value5080':" + dr["no"] +
                              "},";
                    }
                    else
                    {

                        result = result + "{'country':'" + dr["name"] + "','value80':" + dr["no"] +
                              "},";
                    }

                }
                else
                {
                    result = result + "{'country':'" + dr["name"] + "','value':" + dr["no"] +
                              "},";
                }


            }
            result = result.Substring(0, result.Length - 1);
            result = result + "];";
            return result;
        }

        [WebMethod(EnableSession = true)]
        public string GetBarChartData(ComProjectBO obj)
        {
            string result = string.Empty;

            ProjectService objWebService = new ProjectService();

            DataSet ds = null;
            DataTable dt = null;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dt = objWebService.PopulateBarChartData(obj);
            result = " var BarChartData = [";
            foreach (DataRow dr in dt.Rows)
            {
                result = result + "{'projectName':'" + dr["PROJECT_NEP_NAME"] + "','bhautik':" + dr["BHAUTIK_PRAGATI"] + ",'bitiye':" + dr["BITIYE_PRAGATI"] +
                             "},";

            }
            result = result.Substring(0, result.Length - 1);
            result = result + "];";
            return result;
        }

       
        [WebMethod(EnableSession = true)]
        public string GetBarChartDataBarshik(ComProjectBO obj)
        {
            string result = string.Empty;
            ProjectService objWebService = new ProjectService();
            DataSet ds = null;
            DataTable dt = null;
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            dt = objWebService.PopulateBarshikChart(obj);
            result = " var BarChartDataBarshik = [";
            foreach (DataRow dr in dt.Rows)
            {
                result = result + "{'projectName':'" + dr["PROJECT_NEP_NAME"] + "','bhautik':" + dr["BHAUTIK_PRAGATI"] + ",'bitiye':" + dr["BITIYE_PRAGATI"] +
                             "},";
            }
            result = result.Substring(0, result.Length - 1);
            result = result + "];";
            return result;
        }

        [WebMethod(EnableSession = true)]
        public List<Combo> FindProjectByMinistryId(int ministryId)
        {
            ProjectService objWebService = new ProjectService();
            ComProjectBO objComProjectBO = new ComProjectBO();
            DataTable dtPopulateProject = new DataTable();
            List<Combo> objList = new List<Combo>();
            objWebService.AuthSoapHdValue = ServiceAuth.ServiceAuthenticationProject();
            objComProjectBO.Lang = Session["LanguageSetting"].ToString();
            objComProjectBO.MinistryId = ministryId;
            dtPopulateProject = objWebService.PopulateProjectByMinstryId(objComProjectBO);
           
            if (dtPopulateProject != null && dtPopulateProject.Rows.Count > 0)
            {
                objList.Add(new Combo { ComboId = 0, Name = "छान्नुहोस" });
                foreach (DataRow dr in dtPopulateProject.Rows)
                {
                   
                        objList.Add(new Combo { ComboId = dr["PROJECT_ID"].ToInt32(), Name = dr["PROJECT_NAME"].ToString() });
                }
            }
            return objList;
        }


    }
}
