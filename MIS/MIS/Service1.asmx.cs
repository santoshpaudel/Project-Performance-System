using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON;
using MISDAL;
using MISDAL.Budget;

namespace MIS
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : BaseService
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
        public DataTable PopulateMinistryDetails(int ministryId)
        {
            Authentication();
            Base objDal = new Base();
            return objDal.PopulateMinistryDetails(ministryId);
        }
        [WebMethod]
        public int AddMinistry(ComMinistry objComMinistry, int ministryId)
        {
            Base objDal = new Base();
            return objDal.AddMinistry(objComMinistry, ministryId);
        }

        [WebMethod]
        public DataTable PopulateAllMinistries(string lang)
        {
            Base objDal = new Base();
            return objDal.PopulateAllMinistries(lang);
        }
        [WebMethod]
        public DataTable PopulateMinistries()
        {
            Base objDal = new Base();
            return objDal.PopulateMinistries();
        }
        [WebMethod]
        public DataTable PopulateMinistriesForMap()
        {
            Base objDal = new Base();
            return objDal.PopulateMinistriesForMap();
        }
        [WebMethod]
        public void deleteMinistry(int ministryId)
        {
            Base objDal = new Base();
            objDal.deleteMinistry(ministryId);
        }
       
        [WebMethod]
        public DataTable PopulateAllBudgetHeads(string lang, int ministryId)
        {
            Base objDal = new Base();
            return objDal.PopulateAllBudgetHeads(lang, ministryId);
        }
        [WebMethod]
        public DataTable PopulateAllProjectsByMinistryId(string lang, int ministryId, int chaumasikId, int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulateAllProjectsByMinistryId(lang, ministryId, chaumasikId, fiscalYearId);
        }
        [WebMethod]
        public DataTable PopulateAllProjectsByUserId(string lang, int userId, int chaumasikId, int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulateAllProjectsByUserId(lang, userId, chaumasikId, fiscalYearId);
        }

        [WebMethod]
        public DataTable PopulatePPByMinistryId(string lang, int ministryId, int chaumasikId, int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulatePPByMinistryId(lang, ministryId, chaumasikId, fiscalYearId);
        }
        [WebMethod]
        public DataTable PopulatePPByUserId(string lang, int userId, int chaumasikId, int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulatePPByUserId(lang, userId, chaumasikId, fiscalYearId);
        }
        [WebMethod]
        public DataTable PopulatePSByMinistryId(int ministryId, int chaumasikId, int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulatePSByMinistryId( ministryId, chaumasikId, fiscalYearId);
        }
        /*[WebMethod]
        public DataTable PopulatePSByUserId(int userId, int chaumasikId, int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulatePSByUserId( userId, chaumasikId, fiscalYearId);
        }*/

        [WebMethod]
        public DataTable PopulatePSPEByMinistryId(int ministryId, int chaumasikId, int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulatePSPEByMinistryId( ministryId, chaumasikId, fiscalYearId);
        }
       /* [WebMethod]
        public DataTable PopulatePSPEByUserId(string lang, int userId, int chaumasikId, int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulatePSPEByUserId(lang, userId, chaumasikId, fiscalYearId);
        }*/

        [WebMethod]
        public DataTable PopulatePBasicByMinistryId(string lang, int ministryId,  int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulatePBasicByMinistryId(lang, ministryId, fiscalYearId);
        }
        [WebMethod]
        public DataTable PopulatePBasicByUserId(string lang, int userId, int fiscalYearId)
        {
            Base objDal = new Base();
            return objDal.PopulatePBasicByUserId(lang, userId, fiscalYearId);
        }

        [WebMethod]
        public DataTable PopulateAllBudgetHeadsByOfficeId(string lang, int officeId)
        {
            Base objDal = new Base();
            return objDal.PopulateAllBudgetHeadsByOfficeId(lang, officeId);
        }
        [WebMethod]
        public DataTable PopulateAllBudgetHeadsByUserId(string lang, int userId)
        {
            Base objDal = new Base();
            return objDal.PopulateAllBudgetHeadsByUserId(lang, userId);
        }
        [WebMethod]
        public void deleteBudgetHead(int budgetHeadId)
        {
            Base objDal = new Base();
            objDal.deleteBudgetHead(budgetHeadId);
        }
        [WebMethod]
        public DataTable PopulateBudgetHeadDetails(int budgetHeadId)
        {
            Base objDal = new Base();
            return objDal.PopulateBudgetHeadDetails(budgetHeadId);
        }

      
        [WebMethod]
        public DataTable FetchDistrict(string lang)
        {
            Base objDal = new Base();
            return objDal.FetchDistrict(lang);
        }
      

      
        [WebMethod]
        public DataTable FetchAllRole()
        {
            Base objDal = new Base();
            return objDal.FetchAllRole();
        }
      
       
        [WebMethod]
        public DataTable populateDistrict(string lang)
        {
            Base objDal = new Base();
            return objDal.populateDistrict(lang);
        }

     
        [WebMethod]
        public int AddEditBudgetHead(ComBudgetHeadBO objBudget)
        {
            Base objDal = new Base();
            return objDal.AddEditBudgetHead(objBudget);
        }
        [WebMethod]
        public DataTable PopulateFiscalYear()
        {
            Base objDal = new Base();
            return objDal.PopulateFiscalYear();
        }
        [WebMethod]
        public int LockBudgetHead(int budgetHeadId)
        {
            Base objDal = new Base();
            return objDal.LockBudgetHead(budgetHeadId);
        }
        [WebMethod]
        public int UnlockBudgetHead(int budgetHeadId)
        {
            Base objDal = new Base();
            return objDal.UnLockBudgetHead(budgetHeadId);
        }
        [WebMethod]
        public int ClearBudgetOrganizationMap(int budgetHeadId)
        {
            Base objDal = new Base();
            return objDal.ClearBudgetOrganizationMap(budgetHeadId);
        }
        [WebMethod]
        public int InsertBudgetOrganizationMap(int budgetHeadId, int officeId)
        {
            Base objDal = new Base();
            return objDal.InsertBudgetOrganizationMap(budgetHeadId, officeId);
        }
        [WebMethod]
        public DataTable PopulateBudgetOrganizationMap(int budgetHeadId)
        {
            Base objDal = new Base();
            return objDal.PopulateBudgetOrganizationMap(budgetHeadId);
        }
        [WebMethod]
        public DataTable PopulateAllOffices(int ministryId)
        {
            Base objDal = new Base();
            return objDal.PopulateAllOffices(ministryId);
        }

        [WebMethod]
        public int ClearBudgetUserMap(int officeId, int budgetHeadId, int ministryId)
        {
            Base objDal = new Base();
            return objDal.ClearBudgetUserMap(officeId, budgetHeadId, ministryId );
        }
        [WebMethod]
        public int InsertBudgetUserMap(int budgetHeadId, int ministryId, int officeId, int userId)
        {
            Base objDal = new Base();
            return objDal.InsertBudgetUserMap(budgetHeadId, ministryId, officeId, userId);
        }
        [WebMethod]
        public DataTable PopulateBudgetUserMap(int budgetHeadId)
        {
            Base objDal = new Base();
            return objDal.PopulateBudgetUserMap(budgetHeadId);
        }
        [WebMethod]
        public DataTable PopulateAllUsersByOfficeId(int officeId)
        {
            Base objDal = new Base();
            return objDal.PopulateAllUsersByOfficeId(officeId);
        }
    }
}