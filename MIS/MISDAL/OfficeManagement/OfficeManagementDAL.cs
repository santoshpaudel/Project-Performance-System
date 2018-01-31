using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MISCOMMON;
using MISDAL.ConnectionHelper;
using Oracle.DataAccess.Client;

namespace MISDAL.OfficeManagement
{
   public class OfficeManagementDAL:BaseDB
    {

        /// <summary>
        /// Fetches the office hierarchy.
        /// </summary>
        /// <param name="officeId">The office identifier.</param>
        /// <returns></returns>
        public DataTable FetchOfficeHierarchy(int officeId)
        {

            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pr_select_office_hierarchy", officeId, OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// Adds the office.
        /// </summary>
        /// <param name="objComOffice">The object COM office.</param>
        /// <param name="entryMode">The entry mode.</param>
        /// <param name="officeId">The office identifier.</param>
        public int AddOffice(ComOffice objComOffice, int entryMode, int officeId)
        {
            int i = 0;

            if (entryMode == 0)//to insert office item
            {
                DbCommand cmd = null;

                cmd = db.GetStoredProcCommand("pkg_office.add_office");
                db.AddInParameter(cmd, "v_office_nep_name", DbType.String, objComOffice.officeNepaliName);
                db.AddInParameter(cmd, "v_office_eng_name", DbType.String, objComOffice.officeEnglishName);

                db.AddInParameter(cmd, "v_office_parent_id", DbType.Int16, objComOffice.officeParentId);
                db.AddInParameter(cmd, "v_office_type_id", DbType.Int16, objComOffice.officeTypeId);
                /*db.AddInParameter(cmd, "v_ministry_id", DbType.Int16, objComOffice.ministryId);*/
                db.AddInParameter(cmd, "v_vdc_mun_id", DbType.Int16, objComOffice.vdcMunId);
                db.AddInParameter(cmd, "v_district_id", DbType.Int16, objComOffice.districtId);
                db.AddInParameter(cmd, "v_isEnable", DbType.Int16, objComOffice.isEnable);
                db.AddInParameter(cmd, "v_entered_by", DbType.String, null);
                db.AddInParameter(cmd, "v_entered_date", DbType.String, DateTime.Today.ToString("dd-MM-yyyy"));
                db.AddInParameter(cmd, "v_updated_by", DbType.String, null);
                db.AddInParameter(cmd, "v_updated_date", DbType.String, DateTime.Today.ToString("dd-MM-yyyy"));
                i = db.ExecuteNonQuery(cmd);
            }
            else // to update office item
            {
                DbCommand cmd = null;

                cmd = db.GetStoredProcCommand("pkg_office.update_office");
                db.AddInParameter(cmd, "v_office_nep_name", DbType.String, objComOffice.officeNepaliName);
                db.AddInParameter(cmd, "v_office_eng_name", DbType.String, objComOffice.officeEnglishName);

                db.AddInParameter(cmd, "v_office_parent_id", DbType.Int16, objComOffice.officeParentId);
                db.AddInParameter(cmd, "v_office_type_id", DbType.Int16, objComOffice.officeTypeId);
                //db.AddInParameter(cmd, "v_ministry_id", DbType.Int16, objComOffice.ministryId);
                db.AddInParameter(cmd, "v_vdc_mun_id", DbType.Int16, objComOffice.vdcMunId);
                db.AddInParameter(cmd, "v_district_id", DbType.Int16, objComOffice.districtId);
                db.AddInParameter(cmd, "v_isEnable", DbType.Int16, objComOffice.isEnable);
                db.AddInParameter(cmd, "v_entered_by", DbType.String, null);
                db.AddInParameter(cmd, "v_entered_date", DbType.String, DateTime.Today.ToString("dd-MM-yyyy"));
                db.AddInParameter(cmd, "v_updated_by", DbType.String, null);
                db.AddInParameter(cmd, "v_updated_date", DbType.String, DateTime.Today.ToString("dd-MM-yyyy"));
                db.AddInParameter(cmd, "v_office_id", DbType.Int16, officeId);
                i = db.ExecuteNonQuery(cmd);
            }
            return i;
        }
        /// <summary>
        /// Populates the type of the office.
        /// </summary>
        /// <returns></returns>
        public DataTable populateOfficeType()
        {
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pr_select_all_office_type", OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// Populates the office details.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        public DataTable PopulateOfficeDetails(int i)
        {
            DataTable dt = null;
            DataSet ds = null;
            ds = db.ExecuteDataSet("pkg_office.select_office", i, OracleDbType.RefCursor);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable FetchAllOffice(string lang)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_SELECT_ALL_OFFICE", lang, OracleDbType.RefCursor);
            DataSet ds = null;
            DataTable dt = null;
            ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public void DeleteOffice(int officeId)
        {
            DbCommand cmd = null;
            cmd = db.GetStoredProcCommand("pkg_office.delete_office");
            db.AddInParameter(cmd, "v_office_id", DbType.Int16, officeId);
            db.ExecuteNonQuery(cmd);
        }
    }
}
