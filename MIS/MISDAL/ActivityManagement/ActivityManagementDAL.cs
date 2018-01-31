using System.Data;
using System.Data.Common;
using MISCOMMON.Entity;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.ActivityManagement
{
    public class ActivityManagementDAL : BaseDB
    {
        /// <summary>
        /// Adds the roles.
        /// </summary>
        /// <param name="objActivity">The obj activity.</param>
        /// <returns></returns>
        public int ActivityDetail(ActivityDetailBO objActivity)
        {
            int i = 0;
                DbCommand cmd = null;
                cmd = db.GetStoredProcCommand("PKG_ACTIVITY.PR_ACTIVITY_DETAIL");
                db.AddInParameter(cmd, "V_MODE", DbType.String, objActivity.Mode);
                db.AddInParameter(cmd, "V_ACTIVITY_DETAIL_ID", DbType.Decimal, objActivity.ActivityDetailId);
                db.AddInParameter(cmd, "V_ACTIVITY_DETAIL_ENG_NAME", DbType.String, objActivity.ActivityDetailEngName);
                db.AddInParameter(cmd, "V_ACTIVITY_DETAIL_NEP_NAME", DbType.String, objActivity.ActivityDetailNepName);
                db.AddInParameter(cmd, "V_ACTIVITY_UNIT_ID", DbType.Decimal, objActivity.ActivityUnitId);
                db.AddInParameter(cmd, "V_ISENABLE", DbType.Int16, objActivity.Isenable);
                db.AddInParameter(cmd, "V_ISLOCKED", DbType.Int16, objActivity.Islocked);
                db.AddInParameter(cmd, "V_ACTIVITY_SUB_SECTOR_ID", DbType.Decimal, objActivity.ActivitySubSectorId);
                
                i = db.ExecuteNonQuery(cmd);
            
            return i;
        }

        /// <summary>
        /// Selects the role.
        /// </summary>
        /// <param name="objActivity">The obj activity.</param>
        /// <returns></returns>
        public DataTable SelectActivityDetail(ActivityDetailBO objActivity)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY.PR_SELECT_ACTIVITY_DETAIL", objActivity.Lang, OracleDbType.RefCursor);
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
        public DataTable SelectActivityDetailById(ActivityDetailBO objActivity)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY.PR_SELECT_ACTIVITY_DETAIL_ID", objActivity.Lang, objActivity.ActivityDetailId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable SelectActivityUnit(ActivityDetailBO objActivity)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY.PR_SELECT_ACTIVITY_UNIT", objActivity.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        #region activity output map

        /// <summary>
        /// Selects the role.
        /// </summary>
        /// <param name="objActivity">The obj activity.</param>
        /// <returns></returns>
        public DataTable SelectActivityOutputMapDetail(ActivityOutputMapBO objActivityOutputMap)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY.PR_SELECT_ACTIVITY_OUTPUT_MAP", objActivityOutputMap.Lang, OracleDbType.RefCursor);
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
        /// Adds the roles.
        /// </summary>
        /// <param name="objActivity">The obj activity.</param>
        /// <returns></returns>
        public int ActivityOutputMap(ActivityOutputMapBO objActivity)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_ACTIVITY.PR_ACTIVITY_OUTPUT_MAP");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objActivity.Mode);
            db.AddInParameter(cmd, "V_ACTIVITY_OUTPUT_MAP_ID", DbType.Decimal, objActivity.ActivityOutputMapId);
            db.AddInParameter(cmd, "V_ACTIVITY_DETAIL_ID", DbType.Decimal, objActivity.ActivityDetailId);
            db.AddInParameter(cmd, "V_ACTIVITY_OUTPUT_ID", DbType.Decimal, objActivity.ActivityOutputId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Decimal, objActivity.FiscalYearId);
            db.AddInParameter(cmd, "V_ISENABLED", DbType.Int16, objActivity.Isenabled);
            db.AddInParameter(cmd, "V_ISLOCKED", DbType.Int16, objActivity.Islocked);
            

            i = db.ExecuteNonQuery(cmd);

            return i;
        }
        /// <summary>
        /// Selects the role by id.
        /// </summary>
        /// <param name="objRoles">The obj roles.</param>
        /// <returns></returns>
        public DataTable SelectActivityOutputById(ActivityOutputMapBO objActivity)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY.PR_SELECT_ACTTIVITY_OUT_BY_ID", objActivity.Lang, objActivity.ActivityOutputMapId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable SelectActivityDetailBySector(ActivityDetailBO objActivity)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY.PR_SELECT_ACTIVITY_BY_SECTOR", objActivity.Lang, objActivity.ActivitySubSectorId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable SelectActivityOutputBySector(ActivityDetailBO objActivity)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY.PR_SELECT_OUTPUT_BY_SECTOR", objActivity.Lang, objActivity.ActivitySubSectorId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        
        #endregion
    }
}
