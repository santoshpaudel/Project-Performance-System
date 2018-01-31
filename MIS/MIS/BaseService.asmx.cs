using System;
using System.Configuration;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace MIS
{
    /// <summary>
    /// Summary description for BaseService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        // [System.Web.Script.Services.ScriptService]
    public class BaseService : System.Web.Services.WebService
    {

        public AuthSoapHd spAuthenticationHeader;
        public class AuthSoapHd : SoapHeader
        {
            public string strUserName;
            public string strPassword;
        }
      
        protected bool Authentication()
        {
            string username = ConfigurationManager.AppSettings["sysname"].ToString();
            string password = ConfigurationManager.AppSettings["sysvalue"].ToString();
            bool result=false ;
            if (spAuthenticationHeader!=null && spAuthenticationHeader.strUserName == username &&
               spAuthenticationHeader.strPassword == password )
            {
                result = true;
            }
            else
            {
                 result = false;
            }
            if(result==false)
            {
                throw new Exception("Authentication failed");
            }
            return result;

        }
        protected BaseService()
        {
            //Authentication();
        }
       

    }
}
