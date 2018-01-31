using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON.Entity;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.FrameworkManagement
{
    public class FrameworkDAL : BaseDB
    {
        public int AddEditFramework(FrameworkBO objFrameworkBO)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_ADD_EDIT_FRAMEWORK");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objFrameworkBO.Mode);
            db.AddInParameter(cmd, "V_FRAMEWORK_ID", DbType.Int32, objFrameworkBO.FrameworkId);
            db.AddInParameter(cmd, "V_FRAMEWORK_ENG_NAME", DbType.String, objFrameworkBO.FrameworkEngName);
            db.AddInParameter(cmd, "V_FRAMEWORK_NEP_NAME", DbType.String, objFrameworkBO.FrameworkNepName);
            db.AddInParameter(cmd, "V_BASE_YEAR_ID", DbType.Int32, objFrameworkBO.BaseYearId);
            db.AddInParameter(cmd, "V_FIRST_YEAR_ID", DbType.Int32, objFrameworkBO.FirstYearId);
            db.AddInParameter(cmd, "V_SECOND_YEAR_ID", DbType.Int32, objFrameworkBO.SecondYearId);
            db.AddInParameter(cmd, "V_THIRD_YEAR_ID", DbType.Int32, objFrameworkBO.ThirdYearId);
            db.AddInParameter(cmd, "V_IS_ENABLE", DbType.Int32, objFrameworkBO.IsEnable);
            db.AddInParameter(cmd, "V_IS_LOCKED", DbType.Int32, objFrameworkBO.IsLocked);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateFrameworkDetails(FrameworkBO objFrameworkBo)
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_FRAMEWORK_DETAILS", objFrameworkBo.FrameworkId, OracleDbType.RefCursor);
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet(cmd);
            if(ds!=null && ds.Tables.Count>0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateAllFrameworks()
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_ALL_FRAMEWORKS", OracleDbType.RefCursor);
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
    }
}
