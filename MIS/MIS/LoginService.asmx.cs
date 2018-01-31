using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON.Entity;
using MISDAL.Login;

namespace MIS
{
    /// <summary>
    /// Summary description for LoginService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginService : BaseService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable CheckUserExistence(ComLogin objLogin)
        {
            Authentication();
            LoginDAL objDal = new LoginDAL();
            return objDal.CheckUserExistence(objLogin);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateFiscalYear(ComLogin objLogin)
        {
            Authentication();
            LoginDAL objDal = new LoginDAL();
            return objDal.PopulateFiscalYear(objLogin);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable GetParentOfficeId(int officeId)
        {
            Authentication();
            LoginDAL objDal = new LoginDAL();
            return objDal.GetParentOfficeId(officeId);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ChangePassword(ComLogin objLogin)
        {
            Authentication();
            LoginDAL objDal = new LoginDAL();
            return objDal.ChangePassword(objLogin);
        }
    }
}
