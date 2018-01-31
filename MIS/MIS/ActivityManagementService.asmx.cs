using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON.Entity;
using MISDAL.ActivityManagement;
using MISDAL.RoleManagement;

namespace MIS
{
    /// <summary>
    /// Summary description for ActivityManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ActivityManagementService : BaseService
    {
        private ActivityManagementDAL objActivity
        {
            get
            {
                return new ActivityManagementDAL();
            }
        }
        #region activity detail
        #endregion
        #region activity output map
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateActivityOutputMapDetail(ActivityOutputMapBO objActivityOutputMap)
        {
            Authentication();

            return objActivity.SelectActivityOutputMapDetail(objActivityOutputMap);
        }
        #endregion
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateActivityDetail(ActivityDetailBO objActivityDetail)
        {
            Authentication();

            return objActivity.SelectActivityDetail(objActivityDetail);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable SelectActivityDetailById(ActivityDetailBO objActivityDetail)
        {
            Authentication();
            return objActivity.SelectActivityDetailById(objActivityDetail);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ActivityDetail(ActivityDetailBO objActivityDetail)
        {
            Authentication();
            return objActivity.ActivityDetail(objActivityDetail);

        }
          [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable SelectActivityUnit(ActivityDetailBO objActivityDetail)
        {
            Authentication();
            return objActivity.SelectActivityUnit(objActivityDetail);

        }
         [WebMethod, SoapHeader("spAuthenticationHeader")]
          public int ActivityOutputMap(ActivityOutputMapBO objActivityMapBo)
        {
            Authentication();
            return objActivity.ActivityOutputMap(objActivityMapBo);

        }
         [WebMethod, SoapHeader("spAuthenticationHeader")]
         public DataTable SelectActivityOutputById(ActivityOutputMapBO objActivityDetail)
         {
             Authentication();
             return objActivity.SelectActivityOutputById(objActivityDetail);

         }
         [WebMethod, SoapHeader("spAuthenticationHeader")]
         public DataTable SelectActivityDetailBySector(ActivityDetailBO objActivityDetail)
         {
             Authentication();
             return objActivity.SelectActivityDetailBySector(objActivityDetail);

         }
          [WebMethod, SoapHeader("spAuthenticationHeader")]
         public DataTable SelectActivityOutputBySector(ActivityDetailBO objActivityDetail)
         {
             Authentication();
             return objActivity.SelectActivityOutputBySector(objActivityDetail);

         }
        
        
        
    }
}
