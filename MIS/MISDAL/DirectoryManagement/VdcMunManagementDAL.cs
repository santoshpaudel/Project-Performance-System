using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.DirectoryManagement
{
    public class VdcMunManagementDAL : BaseDB
    {
        public int InsertVdcMun(VdcMun obj)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PR_INSERT_VDC_MUN");
            db.AddInParameter(cmd, "v_VDC_MUN_CODE", DbType.String, obj.VdcMunCode);
            db.AddInParameter(cmd, "v_VDC_MUN_ENG_NAME", DbType.String, obj.VdcMunNameEng);
            db.AddInParameter(cmd, "v_VDC_MUN_NEP_NAME", DbType.String, obj.VdcMunNameNep);
            db.AddInParameter(cmd, "v_VDC_MUN_TYPE", DbType.String, obj.VdcMunType);
            db.AddInParameter(cmd, "v_DISTRICT", DbType.Int32, obj.District);
            db.AddInParameter(cmd, "v_ISENABLE", DbType.Int32, obj.IsEnable);
            db.AddInParameter(cmd, "v_ISLOCKED", DbType.Int32, obj.IsLocked);
            i= db.ExecuteNonQuery(cmd);
            return i;
        }
        public DataTable SearchVdcMunByDistrict(Users uBo)
        {
            // db = DatabaseFactory.CreateDatabase("connStrr");
            DbCommand cmd = db.GetStoredProcCommand("PR_SELECT_VdcMun_BY_DISTRICT", OracleDbType.RefCursor);
            db.AddInParameter(cmd, "DISTRICT", DbType.Int32, uBo.District);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable FetchMunVdcDetailsById(string id)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_SELECT_VdcMun_BY_ID", id, OracleDbType.RefCursor);
            //db.AddInParameter(cmd, "v_VDC_ID", DbType.Int32, id);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int UpdateVdcMunById(VdcMun obj)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PR_UPDATE_VdcMun_BY_ID");
            db.AddInParameter(cmd, "v_VDC_ID", DbType.Int32, obj.VdcMunId);
            db.AddInParameter(cmd, "v_VDC_MUN_CODE", DbType.String, obj.VdcMunCode);
            db.AddInParameter(cmd, "v_VDC_MUN_ENG_NAME", DbType.String, obj.VdcMunNameEng);
            db.AddInParameter(cmd, "v_VDC_MUN_NEP_NAME", DbType.String, obj.VdcMunNameNep);
            db.AddInParameter(cmd, "v_VDC_MUN_TYPE", DbType.String, obj.VdcMunType);
            db.AddInParameter(cmd, "v_DISTRICT", DbType.Int32, obj.District);
            db.AddInParameter(cmd, "v_ISENABLE", DbType.Int32, obj.IsEnable);
            i= db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable FetchAllVdcMun(string lang)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_SELECT_All_VdcMun", lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable populateVdcMun(int disId)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_POPULATE_VDC_MUN_BY_DIS_ID", disId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int DeleteVdcMunById(int id)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PR_DELETE_VDC_MUN");
            db.AddInParameter(cmd, "v_vdc_mun_id", DbType.Int16, id);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int LockVdcMun(int vdcMunId)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PR_LOCK_VDC_MUN");
            db.AddInParameter(cmd, "v_vdc_mun_id", DbType.Int16, vdcMunId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int UnlockVdcMun(int vdcMunId)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PR_UNLOCK_VDC_MUN");
            db.AddInParameter(cmd, "v_vdc_mun_id", DbType.Int16, vdcMunId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
    }
}
