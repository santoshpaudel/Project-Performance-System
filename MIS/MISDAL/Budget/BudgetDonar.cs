using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.Budget
{
    public class BudgetDonar : BaseDB
    {

        public int AddDonar(ComBudgetDonar objComBudgetDonar, int donarId)
        {
            int i = 0;
            if (donarId == 0)
            {
                DbCommand cmd = null;
                cmd = db.GetStoredProcCommand("pkg_donar.InsertDonar");
                db.AddInParameter(cmd, "v_donar_nep_name", DbType.String, objComBudgetDonar.DonarNepName);
                db.AddInParameter(cmd, "v_donar_eng_name", DbType.String, objComBudgetDonar.DonarEngName);
                db.AddInParameter(cmd, "v_donar_code", DbType.String, objComBudgetDonar.DonarCode);
                db.AddInParameter(cmd, "v_donar_type", DbType.Int32, objComBudgetDonar.DonarType);
                db.AddInParameter(cmd, "v_is_enable", DbType.Int16, objComBudgetDonar.IsEnable);
                db.AddInParameter(cmd, "v_is_locked", DbType.Int16, objComBudgetDonar.IsLocked);
                i = db.ExecuteNonQuery(cmd);
            }

            else
            {
                DbCommand cmd = null;
                cmd = db.GetStoredProcCommand("pkg_donar.UpdateDonar");
                db.AddInParameter(cmd, "v_donar_nep_name", DbType.String, objComBudgetDonar.DonarNepName);
                db.AddInParameter(cmd, "v_donar_eng_name", DbType.String, objComBudgetDonar.DonarEngName);
                db.AddInParameter(cmd, "v_donar_code", DbType.String, objComBudgetDonar.DonarCode);
                db.AddInParameter(cmd, "v_donar_type", DbType.Int32, objComBudgetDonar.DonarType);
                db.AddInParameter(cmd, "v_donar_id", DbType.Int16, donarId);
                db.AddInParameter(cmd, "v_is_enable", DbType.Int16, objComBudgetDonar.IsEnable);
                i = db.ExecuteNonQuery(cmd);
            }

            return i;
        }

        public DataTable PopulateAllDonars(string lang)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_donar.PopulateAllDonars", lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateDonarDetails(int donarId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_donar.SelectDonar", donarId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public void DeleteDonar(int donarId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_donar.DeleteDonar");

            db.AddInParameter(cmd, "v_Donar_ID", DbType.Int32, donarId);
            db.ExecuteNonQuery(cmd);
        }


        public int LockBudgetDonar(int donarId)
        {
            int i = 0;
            DbCommand cmd = db.GetStoredProcCommand("pkg_donar.LockBudgetDonar");

            db.AddInParameter(cmd, "v_Donar_ID", DbType.Int32, donarId);
            i=db.ExecuteNonQuery(cmd);
            return i;
        }
      
        public int UnlockBudgetDonar(int donarId)
        {
            int i = 0;
            DbCommand cmd = db.GetStoredProcCommand("pkg_donar.UnlockBudgetDonar");

            db.AddInParameter(cmd, "v_Donar_ID", DbType.Int32, donarId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
    }
}
