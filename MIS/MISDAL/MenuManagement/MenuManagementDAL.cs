using System.Data;
using System.Data.Common;
using MISCOMMON;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.MenuManagement
{
    public class MenuManagementDAL:BaseDB
    {
        /// <summary>
        /// Fetches the menu permission.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public DataSet FetchMenuPermission(int module, int role)
        {
            // db = DatabaseFactory.CreateDatabase("connStr");

            DataSet ds = null;
            ds = db.ExecuteDataSet("pkg_module.select_menu_role_permission", module, role, OracleDbType.RefCursor, OracleDbType.RefCursor);

            return ds;
        }
        /// <summary>
        /// Fetches the menu hierarchy.
        /// </summary>
        /// <param name="menuId">The menu identifier.</param>
        /// <returns></returns>
        public DataTable FetchMenuHierarchy(int menuId,string lang,int roleId)
        {
            // db = DatabaseFactory.CreateDatabase("connStr");
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pkg_module.select_menu_hierarchy", menuId,lang,roleId, OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        /// <summary>
        /// Inserts the update menu permission.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void InsertUpdateMenuPermission(ComMenuRolePermissionBO obj)
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PR_COM_MENU_ROLE_PERMISSION");
            db.AddInParameter(cmd, "v_mode", DbType.String, obj.Mode);
            db.AddInParameter(cmd, "v_permission_map_id", DbType.Decimal, obj.PermissionMapId);
            db.AddInParameter(cmd, "v_role_id", DbType.Decimal, obj.RoleId);
            db.AddInParameter(cmd, "v_menu_id", DbType.Decimal, obj.MenuId);
            db.AddInParameter(cmd, "v_allow_add", DbType.Int16, obj.AllowAdd);
            db.AddInParameter(cmd, "v_allow_edit", DbType.Int16, obj.AllowEdit);
            db.AddInParameter(cmd, "v_allow_delete", DbType.Int16, obj.AllowDelete);
            db.AddInParameter(cmd, "v_allow_view", DbType.Int16, obj.AllowView);
            db.AddInParameter(cmd, "v_permisson_mode", DbType.String, obj.PermissionMode);
            db.AddInParameter(cmd, "v_verify_level_1", DbType.String, obj.AllowVerifyLevel1);
            db.AddInParameter(cmd, "v_verify_level_2", DbType.String, obj.AllowVerifyLevel2);
            db.AddInParameter(cmd, "v_verify_level_3", DbType.String, obj.AllowVerifyLevel3);
            db.AddInParameter(cmd, "v_verify_level_4", DbType.String, obj.AllowVerifyLevel4);
            db.ExecuteNonQuery(cmd);

        }

        /// <summary>
        /// Adds the menu.
        /// </summary>
        /// <param name="objComMenu">The object COM menu.</param>
        /// <param name="entryMode">The entry mode.</param>
        /// <param name="menuId">The menu identifier.</param>
        public int AddMenu(ComMenu objComMenu, int entryMode, int menuId)
        {
            int i = 0;
            if (entryMode == 0)//to insert menu item
            {
                DbCommand cmd = null;

                cmd = db.GetStoredProcCommand("pkg_module.insertmenuitem");
                db.AddInParameter(cmd, "v_menu_nep_name", DbType.String, objComMenu.menuNepaliName);
                db.AddInParameter(cmd, "v_menu_eng_name", DbType.String, objComMenu.menuEnglishName);

                db.AddInParameter(cmd, "v_menu_parent_id", DbType.Int16, objComMenu.menuParentId);
                db.AddInParameter(cmd, "v_menu_type_id", DbType.Int16, objComMenu.menuTypeId);
                db.AddInParameter(cmd, "v_menu_node_level", DbType.Int16, objComMenu.menuLevel);
                db.AddInParameter(cmd, "v_menu_path", DbType.String, objComMenu.menuPath);
                i = db.ExecuteNonQuery(cmd);
            }
            else // to update menu item
            {
                DbCommand cmd = null;

                cmd = db.GetStoredProcCommand("pkg_module.updatemenuitem");
                db.AddInParameter(cmd, "v_menu_nep_name", DbType.String, objComMenu.menuNepaliName);
                db.AddInParameter(cmd, "v_menu_eng_name", DbType.String, objComMenu.menuEnglishName);

                db.AddInParameter(cmd, "v_menu_parent_id", DbType.Int16, objComMenu.menuParentId);
                db.AddInParameter(cmd, "v_menu_type_id", DbType.Int16, objComMenu.menuTypeId);
                db.AddInParameter(cmd, "v_menu_node_level", DbType.Int16, objComMenu.menuLevel);
                db.AddInParameter(cmd, "v_menu_id", DbType.Int16, menuId);
                db.AddInParameter(cmd, "v_menu_path", DbType.String, objComMenu.menuPath);
                i = db.ExecuteNonQuery(cmd);
            }

            return i;


        }
        /// <summary>
        /// Populates the menu details.
        /// </summary>
        /// <param name="menuId">The menu identifier.</param>
        /// <returns></returns>
        public DataTable PopulateMenuDetails(int menuId)
        {
            /*DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("pkg_module.SelectMenuItem");*/
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pkg_module.SelectMenuItem", menuId, OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;

        }
        /// <summary>
        /// Deletes the menu.
        /// </summary>
        /// <param name="menuId">The menu id.</param>
        public void DeleteMenu(int menuId)
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PR_DELETE_MENU");
            db.AddInParameter(cmd, "v_menu_id", DbType.Int16, menuId);
            db.ExecuteNonQuery(cmd);
        }


    }
}
