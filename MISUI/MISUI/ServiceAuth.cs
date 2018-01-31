using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MISUI.ServiceMenuOffice;
using MISUICOMMON.Constants;

namespace MISUI
{
    public static class ServiceAuth
    {

        public static AuthSoapHd ServiceAuthentication()
        {
            AuthSoapHd objAuth = new AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceMenu.AuthSoapHd ServiceAuthenticationMenu()
        {
            ServiceMenu.AuthSoapHd objAuth = new ServiceMenu.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        //
        public static ServiceOfficeMgmt.AuthSoapHd ServiceAuthenticationOffice()
        {
            ServiceOfficeMgmt.AuthSoapHd objAuth = new ServiceOfficeMgmt.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceUserMgmt.AuthSoapHd ServiceAuthenticationUser()
        {
            ServiceUserMgmt.AuthSoapHd objAuth = new ServiceUserMgmt.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceBudgetDonar.AuthSoapHd ServiceAuthenticationBudgetDonar()
        {
            ServiceBudgetDonar.AuthSoapHd objAuth = new ServiceBudgetDonar.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceVdcMun.AuthSoapHd ServiceAuthenticationVdcMun()
        {
            ServiceVdcMun.AuthSoapHd objAuth = new ServiceVdcMun.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceRoleMgmt.AuthSoapHd ServiceAuthenticationRole()
        {
            ServiceRoleMgmt.AuthSoapHd objAuth = new ServiceRoleMgmt.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceActivityMgmt.AuthSoapHd ServiceAuthenticationActivity()
        {
            ServiceActivityMgmt.AuthSoapHd objAuth = new ServiceActivityMgmt.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceSectorMgmt.AuthSoapHd ServiceAuthenticationSector()
        {
            ServiceSectorMgmt.AuthSoapHd objAuth = new ServiceSectorMgmt.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceOutputTarget.AuthSoapHd ServiceAuthenticationOutputTarget()
        {
            ServiceOutputTarget.AuthSoapHd objAuth = new ServiceOutputTarget.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceLogin.AuthSoapHd ServiceAuthenticationLogin()
        {
            ServiceLogin.AuthSoapHd objAuth = new ServiceLogin.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceProject.AuthSoapHd ServiceAuthenticationProject()
        {
            ServiceProject.AuthSoapHd objAuth = new ServiceProject.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceBarsikKaryekram.AuthSoapHd ServiceAuthenticationBarsikKaryekram()
        {
            ServiceBarsikKaryekram.AuthSoapHd objAuth = new ServiceBarsikKaryekram.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        public static ServiceFrameworkMgmt.AuthSoapHd ServiceAuthenticationFramework()
        {
            ServiceFrameworkMgmt.AuthSoapHd objAuth = new ServiceFrameworkMgmt.AuthSoapHd();
            objAuth.strUserName = Constants.ServiceUserName;
            objAuth.strPassword = Constants.ServicePassword;
            return objAuth;
        }
        
    }
}