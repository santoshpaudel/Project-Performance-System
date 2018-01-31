using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON.Entity;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.RoleManagement
{
    public class RoleManagementDAL : BaseDB
    {
        /// <summary>
        /// Adds the roles.
        /// </summary>
        /// <param name="objRoles">The obj roles.</param>
        /// <returns></returns>
        public int AddRoles(Roles objRoles)
        {
            int i = 0;
                DbCommand cmd = null;
                cmd = db.GetStoredProcCommand("PKG_COM_ROLE.PR_COM_ROLE");
                db.AddInParameter(cmd, "V_MODE", DbType.String, objRoles.Mode);
               // db.AddInParameter(cmd, "v_lang", DbType.String, objRoles.Lang);
                db.AddInParameter(cmd, "V_ROLE_ID", DbType.Decimal, objRoles.RoleId);
                db.AddInParameter(cmd, "V_ROLE_ENG_NAME", DbType.String, objRoles.RoleEngName);
                db.AddInParameter(cmd, "V_ROLE_NEP_NAME", DbType.String, objRoles.RoleNepName);
                db.AddInParameter(cmd, "V_ISENABLE", DbType.Int16, objRoles.Isenable);
                db.AddInParameter(cmd, "V_ISLOCKED", DbType.Int16, objRoles.Islocked);
                i = db.ExecuteNonQuery(cmd);
            
            return i;
        }

        /// <summary>
        /// Selects the role.
        /// </summary>
        /// <param name="objRoles">The obj roles.</param>
        /// <returns></returns>
        public DataTable SelectRole(Roles objRoles)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_COM_ROLE.PR_Select_Role",objRoles.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// Selects the role by id.
        /// </summary>
        /// <param name="objRoles">The obj roles.</param>
        /// <returns></returns>
        public DataTable SelectRoleById(Roles objRoles)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_COM_ROLE.PR_Select_RoleByID",objRoles.RoleId, objRoles.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
    }
}
