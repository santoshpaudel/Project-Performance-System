using System;
using System.Data;
using System.Data.Common;
using MISCOMMON;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.DataAccess.Client;

namespace MISDAL
{
    /// <summary>
    /// 
    /// </summary>
    public class Base
    {
        private Database db = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="Base"/> class.
        /// </summary>
        public Base()
        {
            db = DatabaseFactory.CreateDatabase();
        }


        /// <summary>
        /// Fetches the roles.
        /// </summary>
        /// <returns></returns>
        public DataTable FetchRoles()
        {
            // db = DatabaseFactory.CreateDatabase("connStr");
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pr_select_role", OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }



        /// <summary>
        /// Populates the district.
        /// </summary>
        /// <returns></returns>
        public DataTable populateDistrict(string lang)
        {
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pr_select_all_district", lang, OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// Populates the ministry.
        /// </summary>
        /// <returns></returns>
        public DataTable populateMinistry()
        {
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pr_select_all_ministry", OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }



        /// <summary>
        /// Populates the ministry details.
        /// </summary>
        /// <param name="ministryId">The ministry identifier.</param>
        /// <returns></returns>
        public DataTable PopulateMinistryDetails(int ministryId)
        {
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pkg_ministry.select_ministry", ministryId, OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// Adds the ministry.
        /// </summary>
        /// <param name="objComMinistry">The object COM ministry.</param>
        /// <param name="ministryId">The ministry identifier.</param>
        public int AddMinistry(ComMinistry objComMinistry, int ministryId)
        {
            int i = 0;
            if (ministryId == 0)//to insert ministry item
            {
                DbCommand cmd = null;

                cmd = db.GetStoredProcCommand("pkg_ministry.add_ministry");
                db.AddInParameter(cmd, "v_ministry_nep_name", DbType.String, objComMinistry.ministryNepaliName);
                db.AddInParameter(cmd, "v_ministry_eng_name", DbType.String, objComMinistry.ministryEnglishName);
                db.AddInParameter(cmd, "v_ministry_code", DbType.String, objComMinistry.ministryCode);
                i = db.ExecuteNonQuery(cmd);
            }
            else // to update ministry item
            {
                DbCommand cmd = null;

                cmd = db.GetStoredProcCommand("pkg_ministry.update_ministry");
                db.AddInParameter(cmd, "v_ministry_nep_name", DbType.String, objComMinistry.ministryNepaliName);
                db.AddInParameter(cmd, "v_ministry_eng_name", DbType.String, objComMinistry.ministryEnglishName);
                db.AddInParameter(cmd, "v_ministry_code", DbType.String, objComMinistry.ministryCode);
                db.AddInParameter(cmd, "v_ministry_id", DbType.Int16, ministryId);
                i = db.ExecuteNonQuery(cmd);
            }
            return i;
        }

        /// <summary>
        /// Populates all ministries.
        /// </summary>
        /// <returns></returns>
        public DataTable PopulateAllMinistries(string lang)
        {

            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pkg_ministry.PopulateAllMinistries", lang, OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateMinistries()
        {

            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pkg_ministry.PopulateMinistries", OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateMinistriesForMap()
        {

            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pkg_ministry.PopulateMinistries", OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public void deleteMinistry(int ministryId)
        {
            DbCommand cmd = null;

            cmd = db.GetStoredProcCommand("pkg_ministry.delete_ministry");
            db.AddInParameter(cmd, "v_ministry_id", DbType.Int16, ministryId);
            db.ExecuteNonQuery(cmd);
        }

        

        public DataTable PopulateAllBudgetHeads(string lang, int ministryId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_budget_head.PopulateAllBudgetHeads", lang, ministryId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateAllProjectsByMinistryId(string lang, int ministryId, int chaumasikId, int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptProjectsMId", lang, ministryId, chaumasikId, fiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateAllProjectsByUserId(string lang, int userId, int chaumasikId, int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptProjectsUId", lang, userId, chaumasikId, fiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateAllBudgetHeadsByOfficeId(string lang, int officeId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_budget_head.PopulateBudgetHeadsByOfficeId", lang, officeId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateAllBudgetHeadsByUserId(string lang, int userId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_budget_head.PopulateBudgetHeadsByUserId", lang, userId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

       

        public void deleteBudgetHead(int budgetHeadId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_budget_head.DeleteBudgetHead");

            db.AddInParameter(cmd, "v_Budget_Head_ID", DbType.Int32, budgetHeadId);
            db.ExecuteNonQuery(cmd);
        }






        public DataTable FetchDistrict(string lang)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_SELECT_ALL_DISTRICT", lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        

        public DataTable FetchAllRole()
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_SELECT_ROLE", OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }



        //public DataTable FetchuserlistNow()
        //{
        //    db = DatabaseFactory.CreateDatabase("connStrr");
        //    DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM TBL_USER");
        //    DataSet ds = null;
        //    DataTable dt = null;
        //    ds = db.ExecuteDataSet(cmd);
        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        dt = ds.Tables[0];
        //    }
        //    return dt;
        //}



       

        public DataTable PopulateBudgetHeadDetails(int budgetHeadId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_budget_head.SelectBudgetHead", budgetHeadId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateFiscalYear()
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_POPULATE_FISCAL_YEAR", OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int AddEditBudgetHead(ComBudgetHeadBO objBudget)
        {
            int i = 0;
            if (objBudget.BudgetHeadId == 0)
            {
                DbCommand cmd = null;
                cmd = db.GetStoredProcCommand("pkg_budget_head.InsertBudgetHead");
                db.AddInParameter(cmd, "v_Budget_Head_nep_name", DbType.String, objBudget.BudgetHeadNepName);
                db.AddInParameter(cmd, "v_Budget_Head_eng_name", DbType.String, objBudget.BudgetHeadEngName);
                db.AddInParameter(cmd, "v_Budget_code", DbType.String, objBudget.BudgetCode);
                db.AddInParameter(cmd, "v_Fiscal_Year_Id", DbType.Int16, objBudget.FiscalYearId);
                db.AddInParameter(cmd, "v_ISENABLE", DbType.Int16, objBudget.IsEnable);
                db.AddInParameter(cmd, "v_ISLOCKED", DbType.Int16, objBudget.IsLocked);
                i = db.ExecuteNonQuery(cmd);
            }
            else
            {
                DbCommand cmd = null;
                cmd = db.GetStoredProcCommand("pkg_budget_head.UpdateBudgetHead");
                db.AddInParameter(cmd, "v_Budget_Head_nep_name", DbType.String, objBudget.BudgetHeadNepName);
                db.AddInParameter(cmd, "v_Budget_Head_eng_name", DbType.String, objBudget.BudgetHeadEngName);
                db.AddInParameter(cmd, "v_Budget_code", DbType.String, objBudget.BudgetCode);
                db.AddInParameter(cmd, "v_Budget_Head_id", DbType.Int16, objBudget.BudgetHeadId);
                db.AddInParameter(cmd, "v_Fiscal_Year_Id", DbType.Int16, objBudget.FiscalYearId);
                db.AddInParameter(cmd, "v_ISENABLE", DbType.Int16, objBudget.IsEnable);
                i = db.ExecuteNonQuery(cmd);
            }
            return i;
        }


       

        public int LockBudgetHead(int budgetHeadId)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("pkg_budget_head.LockBudgetHead");
            db.AddInParameter(cmd, "v_budget_head_id", DbType.Int16, budgetHeadId);
            i = db.ExecuteNonQuery(cmd);
            return i;   
        }

        public int UnLockBudgetHead(int budgetHeadId)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("pkg_budget_head.UnlockBudgetHead");
            db.AddInParameter(cmd, "v_budget_head_id", DbType.Int16, budgetHeadId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }


        public int ClearBudgetOrganizationMap(int budgetHeadId)
        {
            DbCommand cmd = null;
            int i = 0;
            cmd = db.GetStoredProcCommand("PR_CLEAR_BUD_ORGANIZATION_MAP");
            db.AddInParameter(cmd, "v_budget_head_id", DbType.Int32, budgetHeadId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int InsertBudgetOrganizationMap(int budgetHeadId, int officeId)
        {
            DbCommand cmd = null;
            int i = 0;
            cmd = db.GetStoredProcCommand("PR_INSERT_BUD_ORGANIZATION_MAP");
            db.AddInParameter(cmd, "v_budget_head_id", DbType.Int32, budgetHeadId);
            db.AddInParameter(cmd, "v_office_id", DbType.Int32, officeId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateBudgetOrganizationMap(int budgetHeadId)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_fetch_BUD_ORGANIZATION_MAP", budgetHeadId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateAllOffices(int ministryId)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_FETCH_ALL_OFFICES", ministryId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }


        public int ClearBudgetUserMap(int officeId, int budgetHeadId, int ministryId)
        {
            DbCommand cmd = null;
            int i = 0;
            cmd = db.GetStoredProcCommand("PR_CLEAR_BUD_USER_MAP");
            db.AddInParameter(cmd, "v_office_id", DbType.Int32, officeId);
            db.AddInParameter(cmd, "v_budget_head_id", DbType.Int32, budgetHeadId);
            db.AddInParameter(cmd, "v_ministry_id", DbType.Int32, ministryId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int InsertBudgetUserMap(int budgetHeadId, int ministryId, int officeId, int userId)
        {
            DbCommand cmd = null;
            int i = 0;
            cmd = db.GetStoredProcCommand("PR_INSERT_BUD_USER_MAP");
            db.AddInParameter(cmd, "v_budget_head_id", DbType.Int32, budgetHeadId);
            db.AddInParameter(cmd, "v_ministry_id", DbType.Int32, ministryId);
            db.AddInParameter(cmd, "v_office_id", DbType.Int32, officeId);
            db.AddInParameter(cmd, "v_user_id", DbType.Int32, userId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateBudgetUserMap(int budgetHeadId)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_FETCH_BUD_USER_MAP", budgetHeadId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateAllUsersByOfficeId(int officeId)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_POP_USERS_BY_OFFICE_ID", officeId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }


        public DataTable PopulatePPByMinistryId(string lang, int ministryId, int chaumasikId, int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptPPMId", lang, ministryId, chaumasikId, fiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulatePPByUserId(string lang, int userId, int chaumasikId, int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptPPUId", lang, userId, chaumasikId, fiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulatePSByMinistryId(int ministryId, int chaumasikId, int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptPSMId",ministryId, chaumasikId, fiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /*public DataTable PopulatePSByUserId(string lang, int userId, int chaumasikId, int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptPSUId", userId, chaumasikId, fiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }*/

        public DataTable PopulatePSPEByMinistryId(int ministryId, int chaumasikId, int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptPSPEMId", ministryId, chaumasikId, fiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

      /*  public DataTable PopulatePSPEByUserId(string lang, int userId, int chaumasikId, int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptPSPEUId", lang, userId, chaumasikId, fiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
*/
        public DataTable PopulatePBasicByMinistryId(string lang, int ministryId,  int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptPMId", lang, ministryId,  fiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulatePBasicByUserId(string lang, int userId, int fiscalYearId)
        {
            DbCommand cmd = db.GetStoredProcCommand("pkg_project.PopulateRptPUId", lang, userId,  fiscalYearId, OracleDbType.RefCursor);
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
