using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON.Entity;
using MISDAL;
using MISDAL.RoleManagement;

namespace MIS
{
    /// <summary>
    /// Summary description for RoleManagement
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RoleManagement : BaseService
    {

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateRole(Roles objRoles)
        {
            Authentication();
            RoleManagementDAL objDAL = new RoleManagementDAL();
            return objDAL.SelectRole(objRoles);
            
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateRoleById(Roles objRoles)
        {
            Authentication();
            RoleManagementDAL objDAL = new RoleManagementDAL();
            return objDAL.SelectRoleById(objRoles);

        }



        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddRole(Roles objRoles)
        {
            Authentication();
            RoleManagementDAL objDAL = new RoleManagementDAL();
            return objDAL.AddRoles(objRoles);
           
        }

    }
}
