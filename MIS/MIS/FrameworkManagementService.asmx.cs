using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON.Entity;
using MISDAL.FrameworkManagement;

namespace MIS
{
    /// <summary>
    /// Summary description for FrameworkManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FrameworkManagementService :BaseService
    {

        private FrameworkDAL objFramework
        {
            get { return new FrameworkDAL(); }
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddEditFramework(FrameworkBO objFrameworkBO)
        {
            Authentication();
            return objFramework.AddEditFramework(objFrameworkBO);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateFrameworkDetails(FrameworkBO objFrameworkBO)
        {
            Authentication();
            return objFramework.PopulateFrameworkDetails(objFrameworkBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAllFrameworks()
        {
            Authentication();
            return objFramework.PopulateAllFrameworks();
        }
    }
}
