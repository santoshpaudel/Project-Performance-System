using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON;
using MISDAL;
using MISDAL.UserManagement;

namespace MIS
{
    /// <summary>
    /// Summary description for UserManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserManagementService : BaseService
    {
        UserManagementDAL objUserDal
        {
            get { return new UserManagementDAL(); }
        }
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
       [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public int InsertUser(Users userBo)
        {
            Authentication();
            return objUserDal.InsertUser(userBo);

        }
        [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public DataTable FetchUserList(string lang)
        {
            Authentication();
            return objUserDal.FetchUserList(lang);
        }
         [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public DataTable FetchAllUserType()
        {
            Authentication();
            return objUserDal.FetchAllUserType();
        }

        [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public DataTable FetchUserDetailsById(string id)
        {
            Authentication();
            return objUserDal.FetchUserDetailsById(id);
        }


          [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public int DeleteUserById(int id)
        {
            Authentication();
            return objUserDal.DeleteUserById(id);
        }
         [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public DataTable SearchUserByOfficeId(Users uBo)
        {
            Authentication();
            return objUserDal.SearchUserByOfficeId(uBo);
        }
         [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public int UpdateUserById(Users UserBo)
        {
            Authentication();
            return objUserDal.UpdateUserById(UserBo);
        }
         [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
         public int UnlockUser(int userId)
         {
             Authentication();
             return objUserDal.UnlockUser(userId);
         }
         [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
         public int LockUser(int userId)
         {
             Authentication();
             return objUserDal.LockUser(userId);
         }
    }
}
