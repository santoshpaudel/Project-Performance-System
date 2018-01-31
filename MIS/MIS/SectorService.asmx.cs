using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON.Entity;
using MISDAL.SectorManagement;

namespace MIS
{
    /// <summary>
    /// Summary description for SectorService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SectorService : BaseService
    {

       [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAllSubSectors(ComSubSector objComSubSector)
        {
            Authentication();
            SectorManagementDAL objDAL = new SectorManagementDAL();
            return objDAL.SelectSubSector(objComSubSector);

        }

       [WebMethod, SoapHeader("spAuthenticationHeader")]
       public DataTable PopulateAllSectors(ComSubSector objComSubSector)
       {
           Authentication();
           SectorManagementDAL objDAL = new SectorManagementDAL();
           return objDAL.PopulateAllSectors(objComSubSector);

       }

       [WebMethod, SoapHeader("spAuthenticationHeader")]
       public DataTable PopulateSubSectorById(ComSubSector objComSubSector)
       {
           Authentication();
           SectorManagementDAL objDAL = new SectorManagementDAL();
           return objDAL.SelectSubSectorById(objComSubSector);

       }



       [WebMethod, SoapHeader("spAuthenticationHeader")]
       public int AddSubSector(ComSubSector objComSubSector)
       {
           Authentication();
           SectorManagementDAL objDAL = new SectorManagementDAL();
           return objDAL.AddSubSector(objComSubSector);

       }
       [WebMethod, SoapHeader("spAuthenticationHeader")]
       public DataTable PopulateSubSectorsBySectorId(ComSubSector objComSubSector)
       {
           Authentication();
           SectorManagementDAL objDAL = new SectorManagementDAL();
           return objDAL.PopulateSubSectorsBySectorId(objComSubSector);

       }
       
    }
}
