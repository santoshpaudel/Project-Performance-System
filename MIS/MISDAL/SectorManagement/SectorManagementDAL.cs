using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON.Entity;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.SectorManagement
{
    public class SectorManagementDAL : BaseDB
    {
        public int AddSubSector(ComSubSector objComSubSector)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_ACTIVITY_SUB_SECTOR.PR_ACTIVITY_SUB_SECTOR");
            db.AddInParameter(cmd, "V_ACTIVITY_SUB_SECTOR_ID", DbType.Decimal, objComSubSector.SubSectorId);
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComSubSector.Mode);
            db.AddInParameter(cmd, "V_ACTIVITY_SECTOR_ID", DbType.Decimal, objComSubSector.SectorId);
            db.AddInParameter(cmd, "V_ACTIVITY_SUB_SECTOR_ENG_NAME", DbType.String, objComSubSector.SubSectorEngName);
            db.AddInParameter(cmd, "V_ACTIVITY_SUB_SECTOR_NEP_NAME", DbType.String, objComSubSector.SubSectorNepName);
            db.AddInParameter(cmd, "V_ACTIVITY_SUB_SECTOR_CODE", DbType.String, objComSubSector.SubSectorCode);
            db.AddInParameter(cmd, "V_ISENABLE", DbType.Int16, objComSubSector.Isenable);
            db.AddInParameter(cmd, "V_ISLOCKED", DbType.Int16, objComSubSector.Islocked);
            i = db.ExecuteNonQuery(cmd);

            return i;
        }

        public DataTable SelectSubSector(ComSubSector objComSubSector)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY_SUB_SECTOR.PR_Select_Sub_SECTOR", objComSubSector.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable SelectSubSectorById(ComSubSector objComSubSector)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY_SUB_SECTOR.PR_Select_Sub_Sector_ByID", objComSubSector.SubSectorId, objComSubSector.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateAllSectors(ComSubSector objComSubSector)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY_SUB_SECTOR.PR_Select_ALL_Sectors", objComSubSector.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateSubSectorsBySectorId(ComSubSector objComSubSector)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_ACTIVITY_SUB_SECTOR.PR_Select_SubSectorsBySectorId", objComSubSector.SectorId, objComSubSector.Lang, OracleDbType.RefCursor);
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
 