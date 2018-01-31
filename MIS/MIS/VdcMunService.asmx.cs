using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON;
using MISDAL;
using MISDAL.DirectoryManagement;

namespace MIS
{
    /// <summary>
    /// Summary description for VdcMunService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VdcMunService : BaseService
    {

        [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public string HelloWorld()
        {
            Authentication();
            return "Hello World";
        }
        [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public int InsertVdcMun(VdcMun obj)
        {
            Authentication();
            VdcMunManagementDAL objDal = new VdcMunManagementDAL();
            return objDal.InsertVdcMun(obj);
        }

       [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
        public int DeleteVdcMunById(int id)
        {
            Authentication();
            VdcMunManagementDAL objDal = new VdcMunManagementDAL();
            return objDal.DeleteVdcMunById(id);
        }
       [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
       public DataTable SearchVdcMunByDistrict(Users uBo)
       {
           Authentication();
           VdcMunManagementDAL objDal = new VdcMunManagementDAL();
           return objDal.SearchVdcMunByDistrict(uBo);
       }
       [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
       public DataTable FetchMunVdcDetailsById(string id)
       {
           Authentication();
           VdcMunManagementDAL objDal = new VdcMunManagementDAL();
           return objDal.FetchMunVdcDetailsById(id);
       }
       [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
       public int UpdateVdcMunById(VdcMun obj)
       {
           Authentication();
           VdcMunManagementDAL objDal = new VdcMunManagementDAL();
           return objDal.UpdateVdcMunById(obj);
       }
       [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
       public DataTable FetchAllVdcMun(string lang)
       {
           Authentication();
           VdcMunManagementDAL objDal = new VdcMunManagementDAL();
           return objDal.FetchAllVdcMun(lang);
       }
     [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")] 
       public DataTable populateVdcMun(int disId)
       {
           Authentication();
           VdcMunManagementDAL objDal = new VdcMunManagementDAL();
           return objDal.populateVdcMun(disId);
       }
     [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
     public int LockVdcMun(int vdcMunId)
     {
         Authentication();
         VdcMunManagementDAL objDal = new VdcMunManagementDAL();
         return objDal.LockVdcMun(vdcMunId);
     }

     [WebMethod(EnableSession = true), SoapHeader("spAuthenticationHeader")]
     public int UnlockVdcMun(int vdcMunId)
     {
         Authentication();
         VdcMunManagementDAL objDal = new VdcMunManagementDAL();
         return objDal.UnlockVdcMun(vdcMunId);
     }
    }
}
