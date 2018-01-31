using System;
using System.Data;

namespace MISUICOMMON.HelperClass
{
    public static class FrameworkHelper
    {
        public static void Throw(this Exception ex, Exception exception)
        {
            //throw new CustomException("",ex);
            throw new Exception("",ex);
        }

        public static bool ValidateDT(this DataTable dt)
        {
            bool result = dt != null && dt.Rows.Count > 0;
            return result;
        }
        public static bool ValidateDS(this DataSet ds)
        {
            bool result = ds != null && ds.Tables.Count > 0;
            return result;
        }

    }
    
}
