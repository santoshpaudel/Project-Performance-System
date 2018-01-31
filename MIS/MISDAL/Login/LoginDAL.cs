using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON.Entity;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.Login
{
    public class LoginDAL : BaseDB
    {
        public DataTable CheckUserExistence(ComLogin objLogin)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_CHECK_USER_EXISTENCE", objLogin.Username, objLogin.Password, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateFiscalYear(ComLogin objLogin)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_POPULATE_FISCAL_YEAR_DETAIL", objLogin.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable GetParentOfficeId(int officeId)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_POPULATE_PARENT_OFFICE_ID", officeId,  OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int ChangePassword(ComLogin objLogin)
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PR_CHANGE_PASSWORD");
            db.AddInParameter(cmd, "v_user_id", DbType.Int32, objLogin.UserId);
            db.AddInParameter(cmd, "v_new_password", DbType.String, objLogin.NewPassword);
            int i = 0;
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
    }
}
