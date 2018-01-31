using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON;
using MISDAL;
using MISDAL.Budget;

namespace MIS
{
    /// <summary>
    /// Summary description for ServiceBudgetDonar
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BudgetDonarService : BaseService
    {
        [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public string HelloWorld()
        {
            //to assign soap header from calling app
            // LocationServiceWeb.Service1 objLocationService=new Service1();
            //LocationServiceWeb.AuthSoapHd objAuth = new AuthSoapHd();
            //objAuth.strUserName = "123";
            //objAuth.strPassword = "345";
            //objLocationService.AuthSoapHdValue = objAuth;


            //objLocationService.HelloWorld();
            Authentication();
            return "Hello World";
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateDonarDetails(int donarId)
        {
            Authentication();
            BudgetDonar objDal = new BudgetDonar();
            return objDal.PopulateDonarDetails(donarId);
        }
       [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddDonar(ComBudgetDonar objComBudgetDonar, int donarId)
        {
            Authentication();
            BudgetDonar objDal = new BudgetDonar();
            return objDal.AddDonar(objComBudgetDonar, donarId);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAllDonars(string lang)
        {
            Authentication();
            BudgetDonar objDal = new BudgetDonar();
            return objDal.PopulateAllDonars(lang);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public void deleteDonar(int donarId)
        {
            Authentication();
            BudgetDonar objDal = new BudgetDonar();
            objDal.DeleteDonar(donarId);
        }
       [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int LockBudgetDonar(int donarId)
        {
            Authentication();
            BudgetDonar objDal = new BudgetDonar();
            return objDal.LockBudgetDonar(donarId);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int UnlockBudgetDonar(int donarId)
        {
            Authentication();
            BudgetDonar objDal = new BudgetDonar();
            return objDal.UnlockBudgetDonar(donarId);
        }
    }
}
