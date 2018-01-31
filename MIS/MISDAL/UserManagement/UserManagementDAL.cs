using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.UserManagement
{
   public class UserManagementDAL:BaseDB
    {
       public DataTable FetchUserList(string lang)
       {

           DbCommand cmd = db.GetStoredProcCommand("PR_Fetch_User_List", lang, OracleDbType.RefCursor);
           DataSet ds = null;
           DataTable dt = null;
           ds = db.ExecuteDataSet(cmd);
           if (ds != null && ds.Tables.Count > 0)
           {
               dt = ds.Tables[0];
           }
           return dt;
       }
       public int InsertUser(Users UserBo)
       {
           DbCommand cmd = null;
           cmd = db.GetStoredProcCommand("PR_Insert_User");
           db.AddInParameter(cmd, "v_LOGIN_ID", DbType.String, UserBo.Username);
           db.AddInParameter(cmd, "v_USER_ENG_NAME", DbType.String, UserBo.NameEng);
           db.AddInParameter(cmd, "v_USER_NEP_NAME", DbType.String, UserBo.NameNep);
           db.AddInParameter(cmd, "v_LOGIN_PASSWORD", DbType.String, UserBo.Password);
           db.AddInParameter(cmd, "v_OFFICE_ID", DbType.Int32, UserBo.Office);
           db.AddInParameter(cmd, "v_ROLE_ID", DbType.Int32, UserBo.Role);
           db.AddInParameter(cmd, "v_TYPE_ID", DbType.Int32, UserBo.UserType);
           db.AddInParameter(cmd, "v_EMAIL_ID", DbType.String, UserBo.Email);
           db.AddInParameter(cmd, "v_MOBILE_NO", DbType.String, UserBo.Mobile);
           db.AddInParameter(cmd, "v_ORGANIZATION", DbType.String, UserBo.Organizarion);
           db.AddInParameter(cmd, "v_REQUEST_STATUS", DbType.String, UserBo.RequestStatus);
           db.AddInParameter(cmd, "v_REQUESTED_BY", DbType.Int32, UserBo.RequestedBy);
           db.AddInParameter(cmd, "v_ENABLE_DISABLE", DbType.Int32, UserBo.EnableDisable);
           db.AddInParameter(cmd, "v_ISLOCKED", DbType.Int32, UserBo.IsLocked);

           return db.ExecuteNonQuery(cmd);

       }
       public DataTable FetchAllUserType()
       {
           DbCommand cmd = db.GetStoredProcCommand("PR_SELECT_USER_TYPE", OracleDbType.RefCursor);
           DataSet ds = null;
           DataTable dt = null;
           ds = db.ExecuteDataSet(cmd);
           if (ds != null && ds.Tables.Count > 0)
           {
               dt = ds.Tables[0];
           }
           return dt;
       }
       public DataTable FetchUserDetailsById(string id)
       {
           //db = DatabaseFactory.CreateDatabase("connStrr");
           DbCommand cmd = db.GetStoredProcCommand("PR_SELECT_USER_BY_ID", id, OracleDbType.RefCursor);
           //db.AddInParameter(cmd,"v_ID", DbType.Int32, id);
           DataSet ds = null;
           DataTable dt = null;
           ds = db.ExecuteDataSet(cmd);
           if (ds != null && ds.Tables.Count > 0)
           {
               dt = ds.Tables[0];
           }
           return dt;
       }

       public int DeleteUserById(int id)
       {
           //db = DatabaseFactory.CreateDatabase("connStrr");
           DbCommand cmd = db.GetStoredProcCommand("PR_DELETE_USER_BY_ID");

           db.AddInParameter(cmd, "v_ID", DbType.Int32, id);
           return db.ExecuteNonQuery(cmd);

       }

       public DataTable SearchUserByOfficeId(Users uBo)
       {
           //db = DatabaseFactory.CreateDatabase("connStrr");
           DbCommand cmd = db.GetStoredProcCommand("PR_SELECT_USER_BY_OFFICE_ID", OracleDbType.RefCursor);
           db.AddInParameter(cmd, "v_OFFICE_ID", DbType.Int32, uBo.Office);
           DataSet ds = null;
           DataTable dt = null;
           ds = db.ExecuteDataSet(cmd);
           if (ds != null && ds.Tables.Count > 0)
           {
               dt = ds.Tables[0];
           }
           return dt;
       }

       public int UpdateUserById(Users UserBo)
       {
           DbCommand cmd = null;
           cmd = db.GetStoredProcCommand("PR_UPDATE_USER_BY_ID");
           db.AddInParameter(cmd, "v_USER_ID", DbType.Int32, UserBo.UserId);
           db.AddInParameter(cmd, "v_LOGIN_ID", DbType.String, UserBo.Username);
           db.AddInParameter(cmd, "v_USER_ENG_NAME", DbType.String, UserBo.NameEng);
           db.AddInParameter(cmd, "v_USER_NEP_NAME", DbType.String, UserBo.NameNep);
           db.AddInParameter(cmd, "v_LOGIN_PASSWORD", DbType.String, UserBo.Password);
           db.AddInParameter(cmd, "v_OFFICE_ID", DbType.Int32, UserBo.Office);
           db.AddInParameter(cmd, "v_ROLE_ID", DbType.String, UserBo.Role);
           db.AddInParameter(cmd, "v_TYPE_ID", DbType.Int32, UserBo.UserType);
           db.AddInParameter(cmd, "v_EMAIL_ID", DbType.String, UserBo.Email);
           db.AddInParameter(cmd, "v_MOBILE_NO", DbType.String, UserBo.Mobile);
           db.AddInParameter(cmd, "v_ORGANIZATION", DbType.String, UserBo.Organizarion);
           db.AddInParameter(cmd, "v_REQUEST_STATUS", DbType.String, UserBo.RequestStatus);
           db.AddInParameter(cmd, "v_REQUESTED_BY", DbType.Int32, UserBo.RequestedBy);
           db.AddInParameter(cmd, "v_ENABLE_DISABLE", DbType.Int32, UserBo.EnableDisable);

           return db.ExecuteNonQuery(cmd);
       }

       public int UnlockUser(int userId)
       {
           DbCommand cmd = db.GetStoredProcCommand("PR_UNLOCK_USER");
           db.AddInParameter(cmd, "v_ID", DbType.Int32, userId);
           return db.ExecuteNonQuery(cmd);
       }

       public int LockUser(int userId)
       {
           DbCommand cmd = db.GetStoredProcCommand("PR_LOCK_USER");
           db.AddInParameter(cmd, "v_ID", DbType.Int32, userId);
           return db.ExecuteNonQuery(cmd);
       }
    }
}
