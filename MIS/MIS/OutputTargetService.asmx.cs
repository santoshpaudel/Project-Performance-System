using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON.Entity;
using MISDAL.OutputTargetManagement;

namespace MIS
{
    /// <summary>
    /// Summary description for OutputTargetService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OutputTargetService : BaseService
    {

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable SelectTarget(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.SelectTarget(objOutputTarget);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAllTargets(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.PopulateAllTargets(objOutputTarget);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectTargets(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.PopulateProjectTargets(objOutputTarget);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateTargetById(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.SelectTargetById(objOutputTarget);

        }



        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddTarget(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.AddTarget(objOutputTarget);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
           public int AddProjectOutputTarget(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.AddProjectOutputTarget(objOutputTarget);

        }
         [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable SelectFramework()
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.SelectFramework();

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable SelectOutput(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.SelectOutput(objOutputTarget);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable populateOutputType(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.populateOutputType(objOutputTarget);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAllOutputs(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.PopulateAllOutputs(objOutputTarget);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateOutputById(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.SelectOutputById(objOutputTarget);

        }



        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddOutput(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.AddOutput(objOutputTarget);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable populateSubSector(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.populateSubSector(objOutputTarget);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateSectorsToFilter(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.PopulateSectorsToFilter(objOutputTarget);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateSubSectorsToFilter(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.PopulateSubSectorsToFilter(objOutputTarget);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAllActivitiesToFilter(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.PopulateAllActivitiesToFilter(objOutputTarget);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateOffice(OutputTarget objOutputTarget)
        {
            Authentication();
            OutputTargetManagementDAL objDAL = new OutputTargetManagementDAL();
            return objDAL.PopulateOffice(objOutputTarget);

        }
    }
}
