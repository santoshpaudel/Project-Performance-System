using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON.Entity;
using MISDAL.BarsikKaryekram;
using MISDAL.Project;

namespace MIS
{
    /// <summary>
    /// Summary description for BarsikKaryekramService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BarsikKaryekramService :BaseService
    {
       protected BarsikKaryekramDAL objBarsikDal 
       {
           get { return new BarsikKaryekramDAL(); }
       }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int InsertUpdateProjectBudgDetail(ProjectBudgetDetailBO objProjectDetail)
        {
            Authentication();
            return objBarsikDal.InsertUpdateProjectBudgetDetail(objProjectDetail);

        }
        
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBudgDetail(ProjectBudgetDetailBO objProjectBudgetDetail)
        {
            Authentication();
            return objBarsikDal.PopulateBudgDetail(objProjectBudgetDetail);
        }
        
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBarsikThekaParamarsa(ProjectBudgetDetailBO objProjectBudgetDetail)
        {
            Authentication();
            return objBarsikDal.PopulateBarsikThekaParamarsa(objProjectBudgetDetail);
        }

         [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int InsertUpdateProjectBarsikThekaParamarsa(ProjectBarsikThekaParamarsaBO objProjectBarsikThekaParamarsa)
        {
             Authentication();
            return objBarsikDal.InsertUpdateProjectBarsikThekaParamarsa(objProjectBarsikThekaParamarsa);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
         public int InsertUpdateProjectBhautikBPragati(ProjectBhautikBPragatiBO objProjectBhautikBPragati)
         {
             Authentication();
            return objBarsikDal.InsertUpdateProjectBhautikBPragati(objProjectBhautikBPragati);
         }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int InsertUpdateProjectOutputTBarsik(ProjectOutputTBarsikBO objOutputTarget)
        {
            Authentication();
            return objBarsikDal.InsertUpdateProjectOutputTBarsik(objOutputTarget);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int InsertUpdateProjectOutputProgress(ProjectOutputTBarsikBO objOutputTarget)
        {
            Authentication();
            return objBarsikDal.InsertUpdateProjectOutputProgress(objOutputTarget);
        }


        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int InsertUpdateBarshikBharit(BarsikBharitBo objBarsikBharitBo)
        {
            Authentication();
            return objBarsikDal.InsertUpdateBarshikBharit(objBarsikBharitBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBarshikBharit(BarsikBharitBo objBarsikBharitBo)
        {
            Authentication();
            return objBarsikDal.PopulateBarshikBharit(objBarsikBharitBo);
        }


        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectTargetsBarsik(ProjectOutputTBarsikBO objOutputTarget)
        {
            Authentication();
            return objBarsikDal.PopulateProjectTargetsBarsik(objOutputTarget);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectTargetsBarsikRpt(ProjectOutputTBarsikBO objOutputTarget)
        {
            Authentication();
            return objBarsikDal.PopulateProjectTargetsBarsikRpt(objOutputTarget);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int InsertUpdateBarshikFile(ProjectBarsikThekaParamarsaBO obj)
        {
            Authentication();
            return objBarsikDal.InsertUpdateBarshikFile(obj);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBarshikFile(ProjectBarsikThekaParamarsaBO obj)
        {
            Authentication();
            return objBarsikDal.PopulateBarshikFile(obj);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int InsertUpdateChaumasikFile(ProjectBarsikThekaParamarsaBO obj)
        {
            Authentication();
            return objBarsikDal.InsertUpdateChaumasikFile(obj);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateChaumasikFile(ProjectBarsikThekaParamarsaBO obj)
        {
            Authentication();
            return objBarsikDal.PopulateChaumasikFile(obj);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int InsertUpdateProjectUpalabdhi(ProjectUpalabdhiBO objProjectUpalabdhi)
        {
            Authentication();
            return objBarsikDal.InsertUpdateProjectUpalabdhi(objProjectUpalabdhi);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateUpalabdhi(ProjectUpalabdhiBO obj)
        {
            Authentication();
            return objBarsikDal.PopulateUpalabdhi(obj);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectProgress(ProjectOutputTBarsikBO obj)
        {
            Authentication();
            return objBarsikDal.PopulateProjectProgress(obj);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectProgressRpt(ProjectOutputTBarsikBO obj)
        {
            Authentication();
            return objBarsikDal.PopulateProjectProgressRpt(obj);
        }

        //barshik anya
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int InsertUpdateBarshikAnya(ProjectBarshikAnyaBO objProjectBarshikAnyaBo)
        {
            Authentication();
            return objBarsikDal.InsertUpdateBarshikAnya(objProjectBarshikAnyaBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBarshikAnya(ProjectBarshikAnyaBO objProjectBarshikAnyaBo)
        {
            Authentication();
            return objBarsikDal.PopulateBarshikAnya(objProjectBarshikAnyaBo);
        }
    }
}
