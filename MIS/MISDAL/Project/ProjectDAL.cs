using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON.Entity;
using MISCOMMON.HelperClass;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.Project
{
    public class ProjectDAL : BaseDB
    {
        public int AddEditProject(ComProjectBO objProjectDetail)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_ADD_EDIT_PROJECT");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objProjectDetail.Mode);
            db.AddInParameter(cmd, "V_BUDGET_HEAD_ID", DbType.Int32, objProjectDetail.BudgetHeadId);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objProjectDetail.ProjectId);
            db.AddInParameter(cmd, "V_PROJECT_ENG_NAME", DbType.String, objProjectDetail.AyojanaEngName);
            db.AddInParameter(cmd, "V_PROJECT_NEP_NAME", DbType.String, objProjectDetail.AjojanaNepName);
            db.AddInParameter(cmd, "V_PROJECT_LAKSHYA", DbType.String, objProjectDetail.AyojanaLakshya);
            db.AddInParameter(cmd, "V_PROJECT_UDESHYA", DbType.String, objProjectDetail.AyojanaUdeshya);
            db.AddInParameter(cmd, "V_PROJECT_PRATIFAL", DbType.String, objProjectDetail.AyojanaPratifal);
            db.AddInParameter(cmd, "V_PROJECT_MAIN_ACTIVITY", DbType.String, objProjectDetail.AyojanaKriyakalap);
            db.AddInParameter(cmd, "V_PROJECT_PROGRAM_TYPE", DbType.Int32, objProjectDetail.KaryakramPrakar);
            db.AddInParameter(cmd, "V_PROJECT_START_YEAR", DbType.String, objProjectDetail.ProjectProposalTotalYear);
            db.AddInParameter(cmd, "V_SECTOR_ID", DbType.Int32, objProjectDetail.Sector);
            db.AddInParameter(cmd, "V_SUB_SECTOR_ID", DbType.Int32, objProjectDetail.SubSector);
            db.AddInParameter(cmd, "V_SURU_MITI", DbType.String, objProjectDetail.SuruMiti);
            db.AddInParameter(cmd, "V_SAMPAANA_MITI", DbType.String, objProjectDetail.AyojanaSampannaMiti);
            db.AddInParameter(cmd, "V_RANANITI_ID", DbType.Int32, objProjectDetail.Rananiti);
            db.AddInParameter(cmd, "V_KARYANITI_ID1", DbType.Int32, objProjectDetail.Karyaniti1);
            db.AddInParameter(cmd, "V_KARYANITI_ID2", DbType.Int32, objProjectDetail.Karyaniti2);
            db.AddInParameter(cmd, "V_KARYANITI_ID3", DbType.Int32, objProjectDetail.Karyaniti3);
            db.AddInParameter(cmd, "V_SAHA_BIKASH_LAKSHYA", DbType.Int32, objProjectDetail.SahasabdiBikashLakshya);
            db.AddInParameter(cmd, "V_SAHA_BIKASH_GANTABYA", DbType.Int32, objProjectDetail.SahasabdiBikashGantabya);
            db.AddInParameter(cmd, "V_SAHA_BIKASH_SUCHAK", DbType.Int32, objProjectDetail.SahasabdiBikashSuchak);
            db.AddInParameter(cmd, "V_GARIBI_SANKET", DbType.Int32, objProjectDetail.GaribiSankhet);
            db.AddInParameter(cmd, "V_LAINGIK_SANKET", DbType.Int32, objProjectDetail.LaingikSankhet);
            db.AddInParameter(cmd, "V_AAYOJANA_KISIM", DbType.String, objProjectDetail.AyojanaKishim);
            db.AddInParameter(cmd, "V_PRIORITY", DbType.Int32, objProjectDetail.Priority);
            db.AddInParameter(cmd, "V_KUL_LAAGAT", DbType.Decimal, objProjectDetail.AyojanaLagat);
            db.AddInParameter(cmd, "V_NIKAAYA", DbType.String, objProjectDetail.KaryanayanNikay);
            db.AddInParameter(cmd, "V_IS_ENABLE", DbType.Int32, objProjectDetail.IsEnable);
            db.AddInParameter(cmd, "V_IS_LOCKED", DbType.Int32, objProjectDetail.IsLocked);
            db.AddInParameter(cmd, "V_OFFICE_ID", DbType.Int32, objProjectDetail.OfficeId);
            db.AddInParameter(cmd, "V_USER_ID", DbType.Int32, objProjectDetail.UserId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objProjectDetail.FiscalYearId);
            db.AddInParameter(cmd, "V_MINISTRY_ID", DbType.Int32, objProjectDetail.MinistryId);
            db.AddOutParameter(cmd, "V_PR_ID", DbType.Int32, 0);
            db.AddInParameter(cmd, "V_SAHASRABDI_OR_DIGO", DbType.Int32, objProjectDetail.SahasrabdiOrDigo);
            db.AddInParameter(cmd, "V_DIGO_BIKASH_LAKSHYA", DbType.Int32, objProjectDetail.DigoBikashLakshya);
            db.AddInParameter(cmd, "V_DIGO_BIKASH_GANTABYA", DbType.Int32, objProjectDetail.DigoBikashGantabya);
            db.AddInParameter(cmd, "V_DIGO_BIKASH_SUCHAK", DbType.Int32, objProjectDetail.DigoBikashSuchak);
            db.AddInParameter(cmd, "V_JALVAYU_SANKET", DbType.Int32, objProjectDetail.JalvayuSanket);
            db.AddInParameter(cmd, "V_YOJANA_RANANITI_NO", DbType.Int32, objProjectDetail.YojanaRananitiNo);
            db.AddInParameter(cmd, "V_MODIFIED_BY", DbType.String, objProjectDetail.ModifiedBy);
            db.AddInParameter(cmd, "V_MODIFIED_DATE", DbType.DateTime, objProjectDetail.ModifiedDate);

            /* cmd.Parameters.Add(new OracleParameter("out_value", OracleDbType.Int32, ParameterDirection.Output));


             int projectId = objProjectDetail.ProjectId;
             db.AddOutParameter(cmd, "@projectId", DbType.Int32, 1);
             i = db.ExecuteNonQuery(cmd);
             projectId = int.Parse(cmd.Parameters["@projectId"].Value.ToString());

             return projectId;*/
            i = db.ExecuteNonQuery(cmd);
            int projectId;
            projectId = (cmd.Parameters["V_PR_ID"].Value.ToString()).ToInt32();
            return projectId;
        }
        public DataTable PopulateRananiti(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SELECT_RANANITI", objProjectDetail.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateKaryaniti(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SELECT_KARYANITI", objProjectDetail.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateSahashrabdiBikashLakshya(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SELECT_SAHA_LAKSHYA", objProjectDetail.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateSahashrabdiBikashGantabya(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SELECT_SAHA_GANTABYA", objProjectDetail.SahasabdiBikashLakshya, objProjectDetail.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateSahashrabdiBikashSuchak(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SELECT_SAHA_SUCHAK", objProjectDetail.SahasabdiBikashGantabya, objProjectDetail.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateDigoBikashLakshya(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SELECT_DIGO_LAKSHYA", objProjectDetail.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateDigoBikashGantabya(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SELECT_DIGO_GANTABYA", objProjectDetail.DigoBikashLakshya, objProjectDetail.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateDigoBikashSuchak(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SELECT_DIGO_SUCHAK", objProjectDetail.DigoBikashGantabya, objProjectDetail.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateBhuktaniPrakar(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SELECT_BHUKTANI_PRAKAR", objProjectDetail.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateParamarsaBibaran(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PARAMARSA_BIBARAN", objProjectDetail.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateAayojanaBadfad(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_AAYOJANA_BADFAD", objProjectDetail.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateBarshikBadfad(ComProjectBO objProjectDetail)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_BARSHIK_BADFAD", objProjectDetail.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateRananitiBySubSectorId(ComSubSector objComSubSector)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_Select_Rananiti", objComSubSector.SubSectorId, objComSubSector.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateKaryanitiByRananitiId(ComProjectBO objComProjectBO)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_Select_Karyaniti", objComProjectBO.Rananiti, objComProjectBO.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public int CountMaxRows(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_Count_Max_Rows", objComProjectBo.OfficeId, OracleDbType.RefCursor);
            int count = 0;
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                count = dt.Rows.Count;
            }
            return count;
        }
        public DataTable PopulateProjectByBudgetHead(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_Populate_Project", objComProjectBo.BudgetHeadId, objComProjectBo.Lang, OracleDbType.RefCursor);
            int count = 0;
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public int ClearShrotgatBadfad(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_SHROTGAT_BADFAD");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int SaveShrotgatBudgetBadfad(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_SHROTGAT_BADFAD");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_DONAR_ID", DbType.Int32, objComProjectBo.Shrot);
            db.AddInParameter(cmd, "V_PAYMENT_TYPE_ID", DbType.Int32, objComProjectBo.BhuktaniPrakar);
            db.AddInParameter(cmd, "V_RAKAM", DbType.Decimal, objComProjectBo.Rakam);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int SaveProjectCostingTiming(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_COSTING_TIMING");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_DISTRICT_NUMBER", DbType.Int32, objComProjectBo.DistrictNumber);
            db.AddInParameter(cmd, "V_ELECTION_AREA_NUMBER", DbType.Int32, objComProjectBo.ElectionAreaNumber);
            db.AddInParameter(cmd, "V_KARYANAYAN_BIBARAN", DbType.String, objComProjectBo.KaryanayanBibaran);
            db.AddInParameter(cmd, "V_VDCMUN_NUMBER", DbType.Int32, objComProjectBo.VdcMunNumber);
            db.AddInParameter(cmd, "V_CHANAUT_ADHAR", DbType.String, objComProjectBo.ChanautkoAdhar);
            db.AddInParameter(cmd, "V_SAMBHAABYATA_ADHYAN", DbType.Int32, objComProjectBo.SambhaabyataAdhyan);
            db.AddInParameter(cmd, "V_SAMBHAABYATA_ADHYAN_YEAR", DbType.Int32, objComProjectBo.SambhaabyataAdhyanYear);
            db.AddInParameter(cmd, "V_SAMBHAABYATA_NISKARSHA", DbType.String, objComProjectBo.SambhaabyataAdhyanNiskarsha);
            db.AddInParameter(cmd, "V_SAMBHAABYATA_REMARKS", DbType.String, objComProjectBo.SambhaabyataRemarks);
            db.AddInParameter(cmd, "V_PAYBACK_PERIOD", DbType.String, objComProjectBo.PayBackPeriod);
            db.AddInParameter(cmd, "V_BCR", DbType.Decimal, objComProjectBo.BenefitCostRatio);
            db.AddInParameter(cmd, "V_FIRR", DbType.Decimal, objComProjectBo.Firr);
            db.AddInParameter(cmd, "V_EIRR", DbType.Decimal, objComProjectBo.Eirr);
            db.AddInParameter(cmd, "V_NPV", DbType.String, objComProjectBo.NetPresentValue);
            db.AddInParameter(cmd, "V_COST_EFFECTIVE", DbType.String, objComProjectBo.CostEffectiveAnalysis);
            db.AddInParameter(cmd, "V_KARYANOYAN_NIKAAYA", DbType.String, objComProjectBo.KaryanoyanNikaaya);
            db.AddInParameter(cmd, "V_ENVIRONMENTAL_BIBARAN", DbType.Int32, objComProjectBo.EnvironmentalBibaran);
            db.AddInParameter(cmd, "V_REMARKS", DbType.String, objComProjectBo.EnvironmentalBibaranRemarks);
            db.AddInParameter(cmd, "V_FILE_NAME", DbType.String, objComProjectBo.FileName);
            db.AddInParameter(cmd, "V_PAYBACK_PERIOD_REMARKS", DbType.String, objComProjectBo.PayBackPeriodRemarks);
            db.AddInParameter(cmd, "V_BCR_REMARKS", DbType.String, objComProjectBo.BenefitCostRatioRemarks);
            db.AddInParameter(cmd, "V_FIRR_REMARKS", DbType.String, objComProjectBo.FirrRemarks);
            db.AddInParameter(cmd, "V_EIRR_REMARKS", DbType.String, objComProjectBo.EirrRemarks);
            db.AddInParameter(cmd, "V_NPV_REMARKS", DbType.String, objComProjectBo.NetPresentValueRemarks);
            db.AddInParameter(cmd, "V_COST_EFFECTIVE_REMARKS", DbType.String, objComProjectBo.CostEffectiveAnalysisRemarks);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public DataTable PopulateProjectCostingTiming(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_COSTING_TIMING", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;

        }
        public DataTable PopulateShrotgatAayojanaBadfad(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_SHROTGAT_BADFAD", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateAdministrativeDetails(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_ADMIN_DETAILS", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateBhautikSamagri(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_BHAUTIK_SAMAGRI", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public int SaveAdminDetails(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_ADMIN_DETAILS");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_EXISTING_JANASHAKTI", DbType.Int32, objComProjectBo.ExistingJanashakti);
            db.AddInParameter(cmd, "V_THAP_JANASHAKTI", DbType.Int32, objComProjectBo.ThapJanashakti);
            db.AddInParameter(cmd, "V_THAP_JANASHAKTI_KAIFIYAT", DbType.String, objComProjectBo.ThapJanashaktiKaifiyat);
            db.AddInParameter(cmd, "V_MINISTRY_RAAYA", DbType.String, objComProjectBo.MinistryRaaya);
            db.AddInParameter(cmd, "V_CHUTTAYIYEKO_RAKAM", DbType.Decimal, objComProjectBo.ChuttayiyekoRakam);
            db.AddInParameter(cmd, "V_DAATRI_BIBARAN", DbType.String, objComProjectBo.DaatriBibaran);
            db.AddInParameter(cmd, "V_NEPAL_SARKAR_BIBARAN", DbType.String, objComProjectBo.NepalSarkarBibaran);
            db.AddInParameter(cmd, "V_PHASE_OUT_PLAN", DbType.String, objComProjectBo.PhaseOutPlan);
            db.AddInParameter(cmd, "V_MANTRALAYA_BIBARAN", DbType.String, objComProjectBo.MantralayaBibaran);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int ClearBhautikSamagri(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_BHAUTIK_SAMAGRI");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int SaveBhautikSamagri(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_BHAUTIK_SAMAGRI");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_BHAUTIK_SAMAGRI", DbType.String, objComProjectBo.BhautikSamagri);
            db.AddInParameter(cmd, "V_UNIT_ID", DbType.Int32, objComProjectBo.UnitId);
            db.AddInParameter(cmd, "V_QUANTITY", DbType.Decimal, objComProjectBo.Quantity);
            db.AddInParameter(cmd, "V_ANUMANIT_RAKAM", DbType.Decimal, objComProjectBo.AnumanitRakam);
            db.AddInParameter(cmd, "V_SAMAGRI_KAIFIYAT", DbType.String, objComProjectBo.SamagriKaifiyat);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public DataTable PopulateOtherDetails(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_OTHER_DETAILS", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateParamarshaBibaran(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PARAMARSHA_BIBARAN", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public int SaveOtherDetails(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_OTHER_DETAILS");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_SWADESHI", DbType.Int32, objComProjectBo.Swadeshi);
            db.AddInParameter(cmd, "V_BIDESHI", DbType.Int32, objComProjectBo.Bideshi);
            db.AddInParameter(cmd, "V_THEKKA_SANKHYA", DbType.Int32, objComProjectBo.ThekkaSankhya);
            db.AddInParameter(cmd, "V_THEKKA_RAKAM", DbType.Decimal, objComProjectBo.ThekkaRakam);
            db.AddInParameter(cmd, "V_LAVANBIT_MAHILA", DbType.Int32, objComProjectBo.LavanbitMahila);
            db.AddInParameter(cmd, "V_LAVANBIT_BALBALIKA", DbType.Int32, objComProjectBo.LavanbitBalBalika);
            db.AddInParameter(cmd, "V_LAVANBIT_DALIT", DbType.Int32, objComProjectBo.LavanbitDalit);
            db.AddInParameter(cmd, "V_LAVANBIT_JANAJATI", DbType.Int32, objComProjectBo.LavanbitJanajati);
            db.AddInParameter(cmd, "V_LAVANBIT_MADHESI", DbType.Int32, objComProjectBo.LavanbitMadheshi);
            db.AddInParameter(cmd, "V_LAVANBIT_MUSLIM", DbType.Int32, objComProjectBo.LavanbitMuslim);
            db.AddInParameter(cmd, "V_ANYA", DbType.Int32, objComProjectBo.Anya);

            db.AddInParameter(cmd, "V_LAVANBIT_MAHILA_KAIFIYAT", DbType.String, objComProjectBo.LavanbitMahilaKaifiyat);
            db.AddInParameter(cmd, "V_LAVANBIT_BALBALIKA_KAIFIYAT", DbType.String, objComProjectBo.LavanbitBalBalikaKaifiyat);
            db.AddInParameter(cmd, "V_LAVANBIT_DALIT_KAIFIYAT", DbType.String, objComProjectBo.LavanbitDalitKaifiyat);
            db.AddInParameter(cmd, "V_LAVANBIT_JANAJATI_KAIFIYAT", DbType.String, objComProjectBo.LavanbitJanajatiKaifiyat);
            db.AddInParameter(cmd, "V_LAVANBIT_MADHESI_KAIFIYAT", DbType.String, objComProjectBo.LavanbitMadhesiKaifiyat);
            db.AddInParameter(cmd, "V_LAVANBIT_MUSLIM_KAIFIYAT", DbType.String, objComProjectBo.LavanbitMuslimKaifiyat);
            db.AddInParameter(cmd, "V_ANYA_KAIFIYAT", DbType.String, objComProjectBo.LavanbitAnyaKaifiyat);

            db.AddInParameter(cmd, "V_SHRAMDIN", DbType.Int32, objComProjectBo.Shramdin);
            db.AddInParameter(cmd, "V_PARIMAAN", DbType.Decimal, objComProjectBo.Parimaan);
            db.AddInParameter(cmd, "V_YOGDAN", DbType.String, objComProjectBo.Yogdan);
            db.AddInParameter(cmd, "V_IS_USABLE", DbType.Int32, objComProjectBo.IsUsable);
            db.AddInParameter(cmd, "V_JAGGA_PRAPTI", DbType.Decimal, objComProjectBo.JaggaPrapti);
            db.AddInParameter(cmd, "V_JAGGA_PRAPTI_UNIT", DbType.Int32, objComProjectBo.JaggaPraptiUnit);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int ClearParamarshaDetails(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_PARAMARSHA_DETAILS");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int SaveParamarshaBibaran(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_PARAMARSHA_BIBARAN");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            db.AddInParameter(cmd, "V_RAKAM_SWADESHI", DbType.Decimal, objComProjectBo.RakamSwadeshi);
            db.AddInParameter(cmd, "V_RAKAM_BIDESHI", DbType.Decimal, objComProjectBo.RakamBideshi);

            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public DataTable PopulateProjectList(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PROJECT_LIST", objComProjectBo.BudgetHeadId, objComProjectBo.FiscalYearId, objComProjectBo.Lang, objComProjectBo.MinistryId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateProjectListForReport(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PROJECT_LIST_RPT", objComProjectBo.BudgetHeadId, objComProjectBo.OfficeId, objComProjectBo.FiscalYearId, objComProjectBo.Lang, objComProjectBo.MinistryId, objComProjectBo.SelectedMinistryId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateProjectDetails(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PROJECT_DETAILS", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateProjectSansodhan(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PROJECT_SANSODHAN", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public int ClearProjectSansodhan(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_PROJECT_SANSODHAN");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int SaveProjectSansodhan(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_PROJECT_SANSODHAN");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_SANSODHAN_DATE", DbType.String, objComProjectBo.SansodhanDate);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int ClearProjectProblems(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_PROJECT_PROBLEMS");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_CHAUMASIK_ID", DbType.Int32, objComProjectBo.ChaumasikId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }
        public int SaveProjectProblems(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_PROJECT_PROBLEMS");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_CHAUMASIK_ID", DbType.Int32, objComProjectBo.ChaumasikId);
            db.AddInParameter(cmd, "V_PROBLEMS", DbType.String, objComProjectBo.Problems);
            db.AddInParameter(cmd, "V_REASONS", DbType.String, objComProjectBo.Reasons);
            db.AddInParameter(cmd, "V_EFFORTS", DbType.String, objComProjectBo.Efforts);
            db.AddInParameter(cmd, "V_SUGGESTIONS", DbType.String, objComProjectBo.Suggestions);
            db.AddInParameter(cmd, "V_NDAC", DbType.Int32, objComProjectBo.Ndac);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateProjectProblems(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PROJECT_PROBLEMS", objComProjectBo.ProjectId, objComProjectBo.ChaumasikId, objComProjectBo.FiscalYearId,
                OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int ClearProjectLavanvitPragati(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_PRAGATI_LAVANVIT");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_CHAUMASIK_ID", DbType.Int32, objComProjectBo.ChaumasikId);

            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int SaveProjectLavanvitPragati(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_PRAGATI_LAVANVIT");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_MAHILA", DbType.Int32, objComProjectBo.LavanbitMahila);
            db.AddInParameter(cmd, "V_BALBALIKA", DbType.String, objComProjectBo.LavanbitBalBalika);
            db.AddInParameter(cmd, "V_AADIBASI_JANAJATI", DbType.String, objComProjectBo.LavanbitJanajati);
            db.AddInParameter(cmd, "V_DALIT", DbType.String, objComProjectBo.LavanbitDalit);
            db.AddInParameter(cmd, "V_MADHESI", DbType.String, objComProjectBo.LavanbitMadheshi);
            db.AddInParameter(cmd, "V_MUSLIM", DbType.Int32, objComProjectBo.LavanbitMuslim);
            db.AddInParameter(cmd, "V_ANYA", DbType.Int32, objComProjectBo.Anya);
            db.AddInParameter(cmd, "V_CHAUMASIK_ID", DbType.Int32, objComProjectBo.ChaumasikId);

            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateProjectLavanvitPragati(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_LAVANVIT_PRAGATI", objComProjectBo.ProjectId, objComProjectBo.ChaumasikId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateProjectListRpt(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PRJDETAIL_RPT", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int ClearAayojanaPramukh(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_AAYOJANA_PRAMUKH");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int SaveAayojanaPramukh(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_AAYOJANA_PRAMUKH");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_PRAMUKH_START_DATE", DbType.String, objComProjectBo.PramukhStartDate);
            db.AddInParameter(cmd, "V_PRAMUKH_NAME", DbType.String, objComProjectBo.PramukhName);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateAayojanaPramukh(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_AAYOJANA_PRAMUKH", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateStatusProblemsAndEffortsForReport(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_PROBLEMS_RPT", objComProjectBo.MinistryId, objComProjectBo.Priority, objComProjectBo.ChaumasikId, objComProjectBo.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateProjectSamastigatReport(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_PROJECT_SAMASTIGAT_RPT", objComProjectBo.MinistryId, objComProjectBo.Priority, objComProjectBo.ChaumasikId, objComProjectBo.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateProjectSamastigatDashboard(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_PROJECT_SAMASTIGAT_DASH", objComProjectBo.ProjectId, objComProjectBo.ChaumasikId, objComProjectBo.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateThekkaSankhyaRakam(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_THEKKA_SANKHYA", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int ClearProjectThekkaSankhya(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_THEKKA_SANKHYA");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int SaveProjectThekkaSankhya(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_PROJECT_THEKKA_SANKHYA");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            db.AddInParameter(cmd, "V_THEKKA_SANKHYA", DbType.Int32, objComProjectBo.ThekkaSankhya);
            db.AddInParameter(cmd, "V_THEKKA_RAKAM", DbType.Decimal, objComProjectBo.ThekkaRakam);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateParamarshaSankhya(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PARAMARSHA_SANKHYA", objComProjectBo.ProjectId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int ClearParamarshaSankhya(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_PARAMARSHA_SANKHYA");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int SaveParamarshaSankhya(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_PARAMARSHA_SANKHYA");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            db.AddInParameter(cmd, "V_SWADESHI_SANKHYA", DbType.Int32, objComProjectBo.Swadeshi);
            db.AddInParameter(cmd, "V_BIDESHI_SANKHYA", DbType.Int32, objComProjectBo.Bideshi);
            db.AddInParameter(cmd, "V_SWADESHI_SHRAM_DIN", DbType.Decimal, objComProjectBo.SwadeshiShramDin);
            db.AddInParameter(cmd, "V_BIDESHI_SHRAM_DIN", DbType.Decimal, objComProjectBo.BideshiShramDin);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateChartData(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PRIORITY_DATA", objComProjectBo.MinistryId, objComProjectBo.FiscalYearId, objComProjectBo.Mode, objComProjectBo.ChaumasikId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int ClearProjectPratifal(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CLEAR_PROJECT_PRATIFAL");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int SaveProjectPratifal(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_SAVE_PROJECT_PRATIFAL");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            db.AddInParameter(cmd, "V_OUTPUT_ORDER", DbType.Int32, objComProjectBo.Order);
            db.AddInParameter(cmd, "V_OUTPUT", DbType.String, objComProjectBo.Output);
            db.AddInParameter(cmd, "V_UNIT_ID", DbType.Int32, objComProjectBo.UnitId);
            db.AddInParameter(cmd, "V_YEARLY_TARGET", DbType.Decimal, objComProjectBo.YearlyTarget);
            db.AddInParameter(cmd, "V_FIRST_QUARTER_TARGET", DbType.Decimal, objComProjectBo.FirstQuarterTarget);
            db.AddInParameter(cmd, "V_SECOND_QUARTER_TARGET", DbType.Decimal, objComProjectBo.SecondQuarterTarget);
            db.AddInParameter(cmd, "V_THIRD_QUARTER_TARGET", DbType.Decimal, objComProjectBo.ThirdQuarterTarget);
            db.AddInParameter(cmd, "V_OUTPUT_REMARKS", DbType.String, objComProjectBo.OutputRemarks);
            db.AddInParameter(cmd, "V_MODIFIED_BY", DbType.String, objComProjectBo.ModifiedBy);
            db.AddInParameter(cmd, "V_MODIFIED_DATE", DbType.DateTime, objComProjectBo.ModifiedDate);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateProjectOutput(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_PROJECT_OUTPUT", objComProjectBo.ProjectId, objComProjectBo.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateProjectByMinstryId(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_POP_PROJECT_BY_MINISTRY_ID", objComProjectBo.MinistryId, objComProjectBo.Lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateBarChartData(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_PROJECT_SAMASTIGAT_DASH_1", objComProjectBo.ProjectId, objComProjectBo.ChaumasikId, objComProjectBo.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateBarshikChart(ComProjectBO objComProjectBo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_PROJECT_BARSHIK_CHART", objComProjectBo.ProjectId, objComProjectBo.ChaumasikId, objComProjectBo.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable GetBudgetOrganizationMapDetails(int budgetHeadId)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_GET_MAP_DETAIL", budgetHeadId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int CheckLowerLevelVerification(int projectId, string level)
        {
            int retVal;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CHECK_VERIFICATION", projectId, level, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt != null && dt.Rows.Count > 0)
                retVal = 1;
            else
            {
                retVal = 0;
            }
            return retVal;
        }

        public int CheckLowerLevelReportVerification(ComProjectBO objComProjectBo)
        {
            int retVal;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CHECK_REPORT_VERIFICATION", objComProjectBo.ProjectId, objComProjectBo.FiscalYearId, objComProjectBo.ChaumasikId, objComProjectBo.Mode, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt != null && dt.Rows.Count > 0)
                retVal = 1;
            else
            {
                retVal = 0;
            }
            return retVal;
        }

        public int AddReportVerification(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_ADD_REPORT_VERIFICATION");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            db.AddInParameter(cmd, "V_CHAUMASIK_ID", DbType.Int32, objComProjectBo.ChaumasikId);
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int CheckLowerLevelProjectPratifalReport(ComProjectBO objComProjectBo)
        {
            int retVal;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CHECK_PP_VERIFICATION", objComProjectBo.ProjectId, objComProjectBo.FiscalYearId, objComProjectBo.ChaumasikId, objComProjectBo.Mode, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt != null && dt.Rows.Count > 0)
                retVal = 1;
            else
            {
                retVal = 0;
            }
            return retVal;
        }

        public int AddProjectPratifalReportVerification(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_ADD_PP_VERIFICATION");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            db.AddInParameter(cmd, "V_CHAUMASIK_ID", DbType.Int32, objComProjectBo.ChaumasikId);
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int AddProjectSamastigatReportVerification(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_ADD_PS_VERIFICATION");
            db.AddInParameter(cmd, "V_MINISTRY_ID", DbType.Int32, objComProjectBo.MinistryId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            db.AddInParameter(cmd, "V_CHAUMASIK_ID", DbType.Int32, objComProjectBo.ChaumasikId);
            db.AddInParameter(cmd, "V_PRIORITY_ID", DbType.Int32, objComProjectBo.Priority);
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int CheckLowerLevelProjectSamastigatReport(ComProjectBO objComProjectBo)
        {
            int retVal;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CHECK_PS_VERIFICATION", objComProjectBo.FiscalYearId, objComProjectBo.ChaumasikId, objComProjectBo.MinistryId, objComProjectBo.Priority, objComProjectBo.Mode, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt != null && dt.Rows.Count > 0)
                retVal = 1;
            else
            {
                retVal = 0;
            }
            return retVal;
        }

        public int CheckLowerLevelProjectStatusProblemEffortReport(ComProjectBO objComProjectBo)
        {
            int retVal;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CHECK_PSPE_VERIFICATION", objComProjectBo.FiscalYearId, objComProjectBo.ChaumasikId, objComProjectBo.MinistryId, objComProjectBo.Priority, objComProjectBo.Mode, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt != null && dt.Rows.Count > 0)
                retVal = 1;
            else
            {
                retVal = 0;
            }
            return retVal;
        }

        public int AddProjectStatusProblemEffortReportVerification(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_ADD_PSPE_VERIFICATION");
            db.AddInParameter(cmd, "V_MINISTRY_ID", DbType.Int32, objComProjectBo.MinistryId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            db.AddInParameter(cmd, "V_CHAUMASIK_ID", DbType.Int32, objComProjectBo.ChaumasikId);
            db.AddInParameter(cmd, "V_PRIORITY_ID", DbType.Int32, objComProjectBo.Priority);
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int CheckLowerLevelNewProjectVerification(ComProjectBO objComProjectBo)
        {
            int retVal;
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_CHECK_P_VERIFICATION", objComProjectBo.ProjectId, objComProjectBo.FiscalYearId, objComProjectBo.Mode, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt != null && dt.Rows.Count > 0)
                retVal = 1;
            else
            {
                retVal = 0;
            }
            return retVal;
        }

        public int AddNewProjectVerification(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_ADD_P_VERIFICATION");
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objComProjectBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objComProjectBo.FiscalYearId);
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public int AddEditRananiti(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_ADD_EDIT_RANANITI");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            db.AddInParameter(cmd, "V_RANANITI_ID", DbType.Int32, objComProjectBo.RananitiId);
            db.AddInParameter(cmd, "V_RANANITI_ENG_NAME", DbType.String, objComProjectBo.RananitiEngName);
            db.AddInParameter(cmd, "V_RANANITI_NEP_NAME", DbType.String, objComProjectBo.RananitiNepName);
            db.AddInParameter(cmd, "V_SUB_SECTOR_ID", DbType.Int16, objComProjectBo.SubSector);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }

        public DataTable PopulateAllRananitiBySubSectorId(int subSectorId, string lang)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_RANANITI", subSectorId, lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
           
            return dt;
        }

        public DataTable PopulateRananitiDetails(int rananitiId)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_RANANITI_DETAILS", rananitiId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return dt;
        }

        public DataTable PopulateAllRananiti(string lang)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_ALL_RANANITI", lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return dt;
        }


        public int AddEditKaryaniti(ComProjectBO objComProjectBo)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_ADD_EDIT_KARYANITI");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objComProjectBo.Mode);
            db.AddInParameter(cmd, "V_KARYANITI_ID", DbType.Int32, objComProjectBo.KaryanitiId);
            db.AddInParameter(cmd, "V_KARYANITI_ENG_NAME", DbType.String, objComProjectBo.KaryanitiEngName);
            db.AddInParameter(cmd, "V_KARYANITI_NEP_NAME", DbType.String, objComProjectBo.KaryanitiNepName);
            db.AddInParameter(cmd, "V_RANANITI_ID", DbType.Int16, objComProjectBo.RananitiId);
            i = db.ExecuteNonQuery(cmd);
            return i;
        }


        public DataTable PopulateKaryanitiDetails(int karyanitiId)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_KARYANITI_DETAILS", karyanitiId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return dt;
        }


        public DataTable PopulateAllKaryaniti(int rananitiId, string lang)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT.PR_POPULATE_ALL_KARYANITI", rananitiId, lang, OracleDbType.RefCursor);
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
