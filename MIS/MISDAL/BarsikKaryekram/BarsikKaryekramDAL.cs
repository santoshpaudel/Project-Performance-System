using System.Data;
using System.Data.Common;
using MISCOMMON.Entity;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.BarsikKaryekram
{
    public class BarsikKaryekramDAL : BaseDB
    {
        public DataTable PopulateBudgDetail(ProjectBudgetDetailBO objProjectBudgetDetail)
        {
            // db = DatabaseFactory.CreateDatabase("connStr");

            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet("PKG_PROJECT_BARSIK_KARYEKRAM.PR_POPULATE_BUDGET_BADFAD", objProjectBudgetDetail.ProjectId, objProjectBudgetDetail.FiscalYearId, OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public DataTable PopulateBarsikThekaParamarsa(ProjectBudgetDetailBO objProjectBudgetDetail)
        {
            // db = DatabaseFactory.CreateDatabase("connStr");

            DataSet ds = null;
            DataTable dt = null;
            /*ds = db.ExecuteDataSet("PKG_PROJECT_BARSIK_KARYEKRAM.PR_POPULATE_PARAMARSA_BIBARAN",
                                   objProjectBudgetDetail.ProjectId, objProjectBudgetDetail.FiscalYearId,
                                   OracleDbType.RefCursor);*/
            ds = db.ExecuteDataSet("PKG_PROJECT_BARSIK_KARYEKRAM.PR_POPULATE_PARAMARSA_THEKKA",
                                   objProjectBudgetDetail.ProjectId, objProjectBudgetDetail.FiscalYearId,
                                   OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int InsertUpdateProjectBudgetDetail(ProjectBudgetDetailBO objProjectBudgetDetail)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_PROJECT_BUDGET_DETAIL");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objProjectBudgetDetail.Mode);
            db.AddInParameter(cmd, "V_BUDG_BADFAD_ID", DbType.Decimal, objProjectBudgetDetail.BudgBadfadId);
            db.AddInParameter(cmd, "V_BADFAD_ID", DbType.Decimal, objProjectBudgetDetail.BadfadId);
            db.AddInParameter(cmd, "V_FIRST_T_RAKAM", DbType.Decimal, objProjectBudgetDetail.FirstTRakam);
            db.AddInParameter(cmd, "V_SECOND_T_RAKAM", DbType.Decimal, objProjectBudgetDetail.SecondTRakam);
            db.AddInParameter(cmd, "V_THIRD_C_RAKAM", DbType.Decimal, objProjectBudgetDetail.ThirdCRakam);
            db.AddInParameter(cmd, "V_FIRST_P_RAKAM", DbType.Decimal, objProjectBudgetDetail.FirstPRakam);
            db.AddInParameter(cmd, "V_SECOND_P_RAKAM", DbType.Decimal, objProjectBudgetDetail.SecondPRakam);
            db.AddInParameter(cmd, "V_THIRD_P_RAKAM", DbType.Decimal, objProjectBudgetDetail.ThirdPRakam);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Decimal, objProjectBudgetDetail.FiscalYearId);
            db.AddInParameter(cmd, "V_S_BH_MAG_GARNE_F", DbType.Decimal, objProjectBudgetDetail.SBhMagGarneF);
            db.AddInParameter(cmd, "V_S_BH_MAG_GARNE_S", DbType.Decimal, objProjectBudgetDetail.SBhMagGarneS);
            db.AddInParameter(cmd, "V_S_BH_MAG_GARNE_T", DbType.Decimal, objProjectBudgetDetail.SBhMagGarneT);
            db.AddInParameter(cmd, "V_S_BH_HAL_SAMMA_MAG_F", DbType.Decimal, objProjectBudgetDetail.SBhHalSammaMagF);
            db.AddInParameter(cmd, "V_S_BH_HAL_SAMMA_MAG_S", DbType.Decimal, objProjectBudgetDetail.SBhHalSammaMagS);
            db.AddInParameter(cmd, "V_S_BH_HAL_SAMMA_MAG_T", DbType.Decimal, objProjectBudgetDetail.SBhHalSammaMagT);
            db.AddInParameter(cmd, "V_S_BH_HAL_SAMMA_PRAPTA_F", DbType.Decimal, objProjectBudgetDetail.SBhHalSammaPraptaF);
            db.AddInParameter(cmd, "V_S_BH_HAL_SAMMA_PRAPTA_S", DbType.Decimal, objProjectBudgetDetail.SBhHalSammaPraptaS);
            db.AddInParameter(cmd, "V_S_BH_HAL_SAMMA_PRAPTA_T", DbType.Decimal, objProjectBudgetDetail.SBhHalSammaPraptaT);
            return db.ExecuteNonQuery(cmd);
        }
        public int InsertUpdateProjectBarsikThekaParamarsa(ProjectBarsikThekaParamarsaBO objProjectBarsikThekaParamarsa)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_PRJ_BARSIK_THEKA_PARAMARSA");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objProjectBarsikThekaParamarsa.Mode);
            db.AddInParameter(cmd, "V_BARSIK_THEKA_P_ID", DbType.Decimal, objProjectBarsikThekaParamarsa.BarsikThekaPId);
            db.AddInParameter(cmd, "V_THEKA_F_T_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaFTNo);
            db.AddInParameter(cmd, "V_THEKA_F_T_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaFTRakam);
            db.AddInParameter(cmd, "V_P_F_T_SWADESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PFTSwadeshiNo);
            db.AddInParameter(cmd, "V_P_F_T_BIDESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PFTBideshiNo);
            db.AddInParameter(cmd, "V_P_F_T_SWADESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PFTSwadeshiRakam);
            db.AddInParameter(cmd, "V_P_F_T_BIDESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PFTBideshiRakam);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Decimal, objProjectBarsikThekaParamarsa.FiscalYearId);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Decimal, objProjectBarsikThekaParamarsa.ProjectId);
            db.AddInParameter(cmd, "V_THEKA_S_T_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaSTNo);
            db.AddInParameter(cmd, "V_THEKA_S_T_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaSTRakam);
            db.AddInParameter(cmd, "V_THEKA_T_T_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaTTNo);
            db.AddInParameter(cmd, "V_THEKA_T_T_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaTTRakam);
            db.AddInParameter(cmd, "V_P_S_T_SWADESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PSTSwadeshiNo);
            db.AddInParameter(cmd, "V_P_S_T_SWADESI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PSTSwadesiRakam);
            db.AddInParameter(cmd, "V_P_S_T_BIDESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PSTBideshiNo);
            db.AddInParameter(cmd, "V_P_S_T_BIDESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PSTBideshiRakam);
            db.AddInParameter(cmd, "V_P_T_T_SWADESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PTTSwadeshiNo);
            db.AddInParameter(cmd, "V_P_T_T_SWADESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PTTSwadeshiRakam);
            db.AddInParameter(cmd, "V_P_T_T_BIDESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PTTBideshiNo);
            db.AddInParameter(cmd, "V_P_T_T_BIDESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PTTBideshiRakam);
            db.AddInParameter(cmd, "V_THEKA_F_P_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaFPNo);
            db.AddInParameter(cmd, "V_THEKA_F_P_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaFPRakam);
            db.AddInParameter(cmd, "V_P_F_P_SWADESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PFPSwadeshiNo);
            db.AddInParameter(cmd, "V_P_F_P_BIDESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PFPBideshiNo);
            db.AddInParameter(cmd, "V_P_F_P_SWADESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PFPSwadeshiRakam);
            db.AddInParameter(cmd, "V_P_F_P_BIDESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PFPBideshiRakam);
            db.AddInParameter(cmd, "V_THEKA_S_P_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaSPNo);
            db.AddInParameter(cmd, "V_THEKA_S_P_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaSPRakam);
            db.AddInParameter(cmd, "V_THEKA_T_P_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaTPNo);
            db.AddInParameter(cmd, "V_THEKA_T_P_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.ThekaTPRakam);
            db.AddInParameter(cmd, "V_P_S_P_SWADESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PSPSwadeshiNo);
            db.AddInParameter(cmd, "V_P_S_P_SWADESI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PSPSwadesiRakam);
            db.AddInParameter(cmd, "V_P_S_P_BIDESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PSPBideshiNo);
            db.AddInParameter(cmd, "V_P_S_P_BIDESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PSPBideshiRakam);
            db.AddInParameter(cmd, "V_P_T_P_SWADESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PTPSwadeshiNo);
            db.AddInParameter(cmd, "V_P_T_P_SWADESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PTPSwadeshiRakam);
            db.AddInParameter(cmd, "V_P_T_P_BIDESHI_NO", DbType.Decimal, objProjectBarsikThekaParamarsa.PTPBideshiNo);
            db.AddInParameter(cmd, "V_P_T_P_BIDESHI_RAKAM", DbType.Decimal, objProjectBarsikThekaParamarsa.PTPBideshiRakam);
            db.AddInParameter(cmd, "V_MODIFIED_DATE", DbType.DateTime, objProjectBarsikThekaParamarsa.ModifiedDate);
            db.AddInParameter(cmd, "V_MODIFIED_BY", DbType.String, objProjectBarsikThekaParamarsa.ModifiedBy);
            return db.ExecuteNonQuery(cmd);
        }

        //barshik anya
        public int InsertUpdateBarshikAnya(ProjectBarshikAnyaBO objProjectBarshikAnyaBo)
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_PROJECT_BARSHIK_ANYA");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objProjectBarshikAnyaBo.Mode);
            db.AddInParameter(cmd, "V_BARSHIK_ANYA_ID", DbType.Int32, objProjectBarshikAnyaBo.BarshikAnyaID);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objProjectBarshikAnyaBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Decimal, objProjectBarshikAnyaBo.FiscalYearId);
            db.AddInParameter(cmd, "V_FIRST_RAKAM_ANYA", DbType.Decimal, objProjectBarshikAnyaBo.FirstRakamAnya);
            db.AddInParameter(cmd, "V_SECOND_RAKAM_ANYA", DbType.Decimal, objProjectBarshikAnyaBo.SecondRakamAnya);
            db.AddInParameter(cmd, "V_THIRD_RAKAM_ANYA", DbType.Decimal, objProjectBarshikAnyaBo.ThirdRakamAnya);
            db.AddInParameter(cmd, "V_REMARKS_ANYA", DbType.String, objProjectBarshikAnyaBo.RemarksAnya);
            db.AddInParameter(cmd, "V_FIRST_ANYA_PRAGATI", DbType.Decimal, objProjectBarshikAnyaBo.FirstAnyaPragati);
            db.AddInParameter(cmd, "V_SECOND_ANYA_PRAGATI", DbType.Decimal, objProjectBarshikAnyaBo.SecondAnyaPragati);
            db.AddInParameter(cmd, "V_THIRD_ANYA_PRAGATI", DbType.Decimal, objProjectBarshikAnyaBo.ThirdAnyaPragati);
            return db.ExecuteNonQuery(cmd);
        }

        public int InsertUpdateBarshikBharit(BarsikBharitBo objBarshikBharitBo)
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_PROJECT_BHARIT_LAKSHYA");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objBarshikBharitBo.Mode);
            db.AddInParameter(cmd, "V_BARSHIK_BHARIT_LAKSHYA_ID", DbType.Int32, objBarshikBharitBo.BarshikBharitId);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, objBarshikBharitBo.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, objBarshikBharitBo.FiscalYearId);
            db.AddInParameter(cmd, "V_BARSHIK_BHARIT_LAKSHYA", DbType.Decimal, objBarshikBharitBo.BarshikBharitLakshya);
            db.AddInParameter(cmd, "V_FIRST_BHARIT_LAKSHYA", DbType.Decimal, objBarshikBharitBo.FirstBharitLakshya);
            db.AddInParameter(cmd, "V_SECOND_BHARIT_LAKSHYA", DbType.Decimal, objBarshikBharitBo.SecondBharitLakshya);
            db.AddInParameter(cmd, "V_THIRD_BHARIT_LAKSHYA", DbType.Decimal, objBarshikBharitBo.ThirdBharitLakshya);

            return db.ExecuteNonQuery(cmd);
        }

        public DataTable PopulateBarshikBharit(BarsikBharitBo objBarshikBharitBo)
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_POPULATE_BHARIT_LAKSHYA",
                objBarshikBharitBo.ProjectId, objBarshikBharitBo.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateBarshikAnya(ProjectBarshikAnyaBO objProjectBarshikAnyaBo)
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_POPULATE_BARSHIK_ANYA",
                objProjectBarshikAnyaBo.ProjectId, objProjectBarshikAnyaBo.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        //natija barsik
        public DataTable PopulateProjectTargetsBarsik(ProjectOutputTBarsikBO objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_POPULATE_P_TARGET_BARSIK",
                                                    objOutputTarget.Lang, objOutputTarget.ProjectId, objOutputTarget.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateProjectTargetsBarsikRpt(ProjectOutputTBarsikBO objOutputTarget)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_POPULATE_TARGET_BARSIK_RPT",
                                                    objOutputTarget.Lang, objOutputTarget.ProjectId, objOutputTarget.FiscalYearId, objOutputTarget.ChaumasikId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int InsertUpdateProjectOutputTBarsik(ProjectOutputTBarsikBO objProjectOutputTBarsik)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_PROJECT_OUTPUT_T_BARSIK");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objProjectOutputTBarsik.Mode);
            db.AddInParameter(cmd, "V_P_TARGET_B_ID", DbType.Decimal, objProjectOutputTBarsik.PTargetBId);
            db.AddInParameter(cmd, "V_P_TARGET_FIRST_C", DbType.String, objProjectOutputTBarsik.PTargetFirstC);
            db.AddInParameter(cmd, "V_P_TARGET_SECOND_C", DbType.String, objProjectOutputTBarsik.PTargetSecondC);
            db.AddInParameter(cmd, "V_P_TARGET_THIRD_C", DbType.String, objProjectOutputTBarsik.PTargetThirdC);
            db.AddInParameter(cmd, "V_P_TARGET_FIRST_P", DbType.String, objProjectOutputTBarsik.PTargetFirstP);
            db.AddInParameter(cmd, "V_P_TARGET_SECOND_P", DbType.String, objProjectOutputTBarsik.PTargetSecondP);
            db.AddInParameter(cmd, "V_P_TARGET_THIRD_P", DbType.String, objProjectOutputTBarsik.PTargetThirdP);
            db.AddInParameter(cmd, "V_P_TARGET_ID", DbType.Decimal, objProjectOutputTBarsik.PTargetId);
            db.AddInParameter(cmd, "V_ENTRY_DATE", DbType.String, objProjectOutputTBarsik.EntryDate);
            db.AddInParameter(cmd, "V_ISENABLE", DbType.Decimal, objProjectOutputTBarsik.Isenable);
            db.AddInParameter(cmd, "V_ISLOCKED", DbType.Decimal, objProjectOutputTBarsik.Islocked);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Decimal, objProjectOutputTBarsik.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Decimal, objProjectOutputTBarsik.FiscalYearId);
            return db.ExecuteNonQuery(cmd);
        }

        public int InsertUpdateProjectOutputProgress(ProjectOutputTBarsikBO objProjectOutputTBarsik)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_PROJECT_OUTPUT_PROGRESS");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objProjectOutputTBarsik.Mode);
            db.AddInParameter(cmd, "V_PROJECT_OUTPUT_ID", DbType.Int32, objProjectOutputTBarsik.ProjectOutputId);
            db.AddInParameter(cmd, "V_P_TARGET_FIRST_P", DbType.String, objProjectOutputTBarsik.PTargetFirstP);
            db.AddInParameter(cmd, "V_P_TARGET_SECOND_P", DbType.String, objProjectOutputTBarsik.PTargetSecondP);
            db.AddInParameter(cmd, "V_P_TARGET_THIRD_P", DbType.String, objProjectOutputTBarsik.PTargetThirdP);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Decimal, objProjectOutputTBarsik.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Decimal, objProjectOutputTBarsik.FiscalYearId);
            db.AddInParameter(cmd, "V_OP_MODIFIED_BY", DbType.String, objProjectOutputTBarsik.ModifiedBy);
            db.AddInParameter(cmd, "V_OP_MODIFIED_DATE", DbType.DateTime, objProjectOutputTBarsik.ModifiedDate);
            return db.ExecuteNonQuery(cmd);
        }

        //

        //pragati
        public int InsertUpdateProjectBhautikBPragati(ProjectBhautikBPragatiBO objProjectBhautikBPragati)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_PROJECT_BHAUTIK_B_PRAGATI");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objProjectBhautikBPragati.Mode);
            db.AddInParameter(cmd, "V_PRAGATI_B_ID", DbType.Decimal, objProjectBhautikBPragati.PragatiBId);
            db.AddInParameter(cmd, "V_FIRST_BHAUTIK_P", DbType.Decimal, objProjectBhautikBPragati.FirstBhautikP);
            db.AddInParameter(cmd, "V_SECOND_BHAUTIK_P", DbType.Decimal, objProjectBhautikBPragati.SecondBhautikP);
            db.AddInParameter(cmd, "V_THIRD_BHAUTIK_P", DbType.Decimal, objProjectBhautikBPragati.ThirdBhautikP);
            db.AddInParameter(cmd, "V_FIRST_BITIYE_P", DbType.Decimal, objProjectBhautikBPragati.FirstBitiyeP);
            db.AddInParameter(cmd, "V_SECOND_BITIYE_P", DbType.Decimal, objProjectBhautikBPragati.SecondBitiyeP);
            db.AddInParameter(cmd, "V_THIRD_BITIYE_P", DbType.Decimal, objProjectBhautikBPragati.ThirdBitiyeP);
            db.AddInParameter(cmd, "V_YES_ABADHI_SAMMA_BHAUTIK", DbType.Decimal, objProjectBhautikBPragati.YesAbadhiSammaBhautik);
            db.AddInParameter(cmd, "V_YES_ABADI_SAMMA_BITIYE", DbType.Decimal, objProjectBhautikBPragati.YesAbadiSammaBitiye);
            db.AddInParameter(cmd, "V_BITEKO_ABADHI", DbType.Decimal, objProjectBhautikBPragati.BitekoAbadhi);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Decimal, objProjectBhautikBPragati.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Decimal, objProjectBhautikBPragati.FiscalYearId);
            db.AddInParameter(cmd, "V_YES_ABADHI_SAMMA_BHAUTIK_S", DbType.Decimal, objProjectBhautikBPragati.YesAbadhiSammaBhautikS);
            db.AddInParameter(cmd, "V_YES_ABADHI_SAMMA_BHAUTIK_T", DbType.Decimal, objProjectBhautikBPragati.YesAbadhiSammaBhautikT);
            db.AddInParameter(cmd, "V_BITEKO_ABADHI_S", DbType.Decimal, objProjectBhautikBPragati.BitekoAbadhiS);
            db.AddInParameter(cmd, "V_BITEKO_ABADHI_T", DbType.Decimal, objProjectBhautikBPragati.BitekoAbadhiT);
            db.AddInParameter(cmd, "V_YES_ABADI_SAMMA_BITIYE_S", DbType.Decimal, objProjectBhautikBPragati.YesAbadhiSammaBitiyeS);
            db.AddInParameter(cmd, "V_YES_ABADI_SAMMA_BITIYE_T", DbType.Decimal, objProjectBhautikBPragati.YesAbadhiSammaBitiyeT);
            db.AddInParameter(cmd, "V_MODIFIED_BY", DbType.String, objProjectBhautikBPragati.ModifiedBy);
            db.AddInParameter(cmd, "V_MODIFIED_DATE", DbType.DateTime, objProjectBhautikBPragati.ModifiedDate);

            return db.ExecuteNonQuery(cmd);
        }
        //
        public int InsertUpdateBarshikFile(ProjectBarsikThekaParamarsaBO obj)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_INSERT_BARSHIK_FILE");
            db.AddInParameter(cmd, "V_BARSHIK_FILE_NAME", DbType.String, obj.BarshikFileName);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, obj.FiscalYearId);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, obj.ProjectId);
            return db.ExecuteNonQuery(cmd);
        }

        public DataTable PopulateBarshikFile(ProjectBarsikThekaParamarsaBO obj)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_POPULATE_BARSHIK_FILE", obj.ProjectId, obj.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int InsertUpdateChaumasikFile(ProjectBarsikThekaParamarsaBO obj)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_INSERT_CHAUMASIK_FILE");
            db.AddInParameter(cmd, "V_CHAUMASIK_FILE_NAME", DbType.String, obj.ChaumasikFileName);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Int32, obj.FiscalYearId);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Int32, obj.ProjectId);
            db.AddInParameter(cmd, "V_CHAUMASIK_ID", DbType.Int32, obj.ChaumasikId);
            return db.ExecuteNonQuery(cmd);
        }

        public DataTable PopulateChaumasikFile(ProjectBarsikThekaParamarsaBO obj)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_POPULATE_CHAUMASIK_FILE", obj.ProjectId, obj.FiscalYearId, obj.ChaumasikId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public int InsertUpdateProjectUpalabdhi(ProjectUpalabdhiBO objProjectUpalabdhi)
        {
            int i = 0;
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_PROJECT_UPALABDHI");
            db.AddInParameter(cmd, "V_MODE", DbType.String, objProjectUpalabdhi.Mode);
            db.AddInParameter(cmd, "V_UPLABDHI_ID", DbType.Decimal, objProjectUpalabdhi.UplabdhiId);
            db.AddInParameter(cmd, "V_PROJECT_ID", DbType.Decimal, objProjectUpalabdhi.ProjectId);
            db.AddInParameter(cmd, "V_FISCAL_YEAR_ID", DbType.Decimal, objProjectUpalabdhi.FiscalYearId);
            db.AddInParameter(cmd, "V_FIRST_C_DESC", DbType.String, objProjectUpalabdhi.FirstCDesc);
            db.AddInParameter(cmd, "V_SECOND_C_DESC", DbType.String, objProjectUpalabdhi.SecondCDesc);
            db.AddInParameter(cmd, "V_THIRD_C_DESC", DbType.String, objProjectUpalabdhi.ThirdCDesc);
            return db.ExecuteNonQuery(cmd);
        }
        public DataTable PopulateUpalabdhi(ProjectUpalabdhiBO obj)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_SELECT_PRJ_UPALABDHI", obj.ProjectId, obj.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateProjectProgress(ProjectOutputTBarsikBO obj)
        {
            DbCommand cmd = db.GetStoredProcCommand("PKG_PROJECT_BARSIK_KARYEKRAM.PR_POPULATE_PROJECT_PROGRESS", obj.ProjectId, obj.FiscalYearId, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable PopulateProjectProgressRpt(ProjectOutputTBarsikBO obj)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_POPULATE_PROGRESS_RPT", obj.ProjectId, obj.FiscalYearId, obj.ChaumasikId, OracleDbType.RefCursor);
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
