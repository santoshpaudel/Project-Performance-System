using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON.Entity;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.OutputTargetManagement
{
    public class OutputTargetManagementDAL : BaseDB
    {
        public int AddOutput(OutputTarget objOutputTarget)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_ACTIVITY_OUTPUT ");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objOutputTarget.Mode);
            db.AddInParameter(cmd, "V_ACTIVITY_OUTPUT_ID", DbType.Decimal, objOutputTarget.ActivityOutputId);
            db.AddInParameter(cmd, "V_ACTIVITY_OUTPUT_ENG_NAME", DbType.String, objOutputTarget.ActivityOutputEngName);
            db.AddInParameter(cmd, "V_ACTIVITY_OUTPUT_NEP_NAME", DbType.String, objOutputTarget.ActivityOutputNepName);
            db.AddInParameter(cmd, "V_ACTIVITY_OUTPUT_CODE", DbType.String, objOutputTarget.ActivityOutputCode);
            db.AddInParameter(cmd, "V_PARENT_OUTPUT_ID", DbType.Int32, objOutputTarget.ParentOutputId);
            db.AddInParameter(cmd, "V_ACTIVITY_OUTPUT_TYPE_ID", DbType.String, objOutputTarget.ActivityOutputTypeId);
            db.AddInParameter(cmd, "V_SUB_SECTOR_ID", DbType.Decimal, objOutputTarget.SubSectorId);
            db.AddInParameter(cmd, "V_TOIP_YEAR", DbType.String, objOutputTarget.ToipYear);
            db.AddInParameter(cmd, "V_RESPONSIBLE_OFFICE_ID", DbType.String, objOutputTarget.ResponsibleOfficeId);
            db.AddInParameter(cmd, "V_ISENABLE", DbType.Int16, objOutputTarget.IsEnable);
            db.AddInParameter(cmd, "V_ISLOCKED", DbType.Int16, objOutputTarget.IsLocked);
            i = db.ExecuteNonQuery(cmd);

            return i;
        }

        public DataTable SelectOutput(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_Select_Output", objOutputTarget.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable SelectOutputById(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_Select_OutPut_By_ID", objOutputTarget.ActivityOutputId, objOutputTarget.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateAllOutputs(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_Select_ALL_Outputs", objOutputTarget.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable populateOutputType(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_POPULATE_OUTPUT_TYPE", objOutputTarget.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /////////////////////////////////////TARGETS//////////////////////////////////////////////////////////////
        public int AddTarget(OutputTarget objOutputTarget)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_ACTIVITY_TARGET");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objOutputTarget.Mode);
            db.AddInParameter(cmd, "V_TARGET_ID", DbType.Decimal, objOutputTarget.TargetId);
            db.AddInParameter(cmd, "V_PUSTYAYIYEKO_SHROT", DbType.String, objOutputTarget.PustyayiyekoShrot);
            db.AddInParameter(cmd, "V_TARGET_FIRST_YEAR", DbType.String, objOutputTarget.TargetFirstYear);
            db.AddInParameter(cmd, "V_TARGET_SECOND_YEAR", DbType.String, objOutputTarget.TargetSecondYear);
            db.AddInParameter(cmd, "V_TARGET_THIRD_YEAR", DbType.String, objOutputTarget.TargetThirdYear);
            db.AddInParameter(cmd, "V_ACTIVITY_OUTPUT_MAP_ID", DbType.String, objOutputTarget.ActivityOutputMapId);
            db.AddInParameter(cmd, "V_ISENABLE", DbType.Int16, objOutputTarget.IsEnable);
            db.AddInParameter(cmd, "V_ISLOCKED", DbType.Int16, objOutputTarget.IsLocked);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int AddProjectOutputTarget(OutputTarget objOutputTarget)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_PROJECT_OUTPUT_TARGET");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objOutputTarget.Mode);
            db.AddInParameter(cmd, "V_P_TARGET_ID", DbType.Decimal, objOutputTarget.PtargetId);
            db.AddInParameter(cmd, "V_P_TARGET_FIRST_YEAR", DbType.String, objOutputTarget.TargetFirstYear);
            db.AddInParameter(cmd, "V_P_TARGET_SECOND_YEAR", DbType.String, objOutputTarget.TargetSecondYear);
            db.AddInParameter(cmd, "V_P_TARGET_THIRD_YEAR", DbType.String, objOutputTarget.TargetThirdYear);
            db.AddInParameter(cmd, "V_P_TARGET_BASE_YEAR", DbType.String, objOutputTarget.BaseYearTarget);
            db.AddInParameter(cmd, "V_P_OVERALL_TARGET", DbType.String, objOutputTarget.OverallTarget);
            db.AddInParameter(cmd, "V_ACTIVITY_OUTPUT_MAP_ID", DbType.String, objOutputTarget.ActivityOutputMapId);
            db.AddInParameter(cmd, "V_ISENABLE", DbType.Int16, objOutputTarget.IsEnable);
            db.AddInParameter(cmd, "V_ISLOCKED", DbType.Int16, objOutputTarget.IsLocked);
            db.AddInParameter(cmd, "V_FRAMEWORK_ID", DbType.Int32, objOutputTarget.FrameworkId);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Decimal, objOutputTarget.ProjectId);
            i = db.ExecuteNonQuery(cmd);

            return i;
        }

        public DataTable SelectTarget(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_Select_Target", objOutputTarget.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable SelectFramework()
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_ALL_FRAMEWORKS", OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable SelectTargetById(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_Select_Target_By_ID", objOutputTarget.TargetId, objOutputTarget.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateAllTargets(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_POPULATE_TARGET_DETAILS", objOutputTarget.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateProjectTargets(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_POPULATE_P_TARGET_DETAILS",
                                                    objOutputTarget.Lang,objOutputTarget.ProjectId, objOutputTarget.MinistryId ,OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }



        public DataTable populateSubSector(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_Sub_Sector", objOutputTarget.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateSectorsToFilter(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_Sectors_ToFilter", objOutputTarget.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateSubSectorsToFilter(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_SubSectors_ToFilter", objOutputTarget.Lang, objOutputTarget.SectorId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateAllActivitiesToFilter(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_Activities_ToFilter", objOutputTarget.Lang, objOutputTarget.SubSectorId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateOffice(OutputTarget objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_OUTPUT_TARGET.PR_POPULATE_OFFICE", objOutputTarget.Lang, OracleDbType.RefCursor);
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
