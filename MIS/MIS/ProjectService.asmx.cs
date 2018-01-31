using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MISCOMMON.Entity;
using MISDAL.Project;

namespace MIS
{
    /// <summary>
    /// Summary description for ProjectService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        // [System.Web.Script.Services.ScriptService]
    public class ProjectService : BaseService
    {
        private ProjectDAL objProject
        {
            get { return new ProjectDAL(); }
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddEditProject(ComProjectBO objProjectDetail)
        {
            Authentication();

            return objProject.AddEditProject(objProjectDetail);
        }


        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateRananiti(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateRananiti(objProjectDetail);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateKaryaniti(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateKaryaniti(objProjectDetail);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateSahashrabdiBikashLakshya(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateSahashrabdiBikashLakshya(objProjectDetail);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateSahashrabdiBikashGantabya(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateSahashrabdiBikashGantabya(objProjectDetail);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateSahashrabdiBikashSuchak(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateSahashrabdiBikashSuchak(objProjectDetail);

        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateDigoBikashLakshya(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateDigoBikashLakshya(objProjectDetail);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateDigoBikashGantabya(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateDigoBikashGantabya(objProjectDetail);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateDigoBikashSuchak(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateDigoBikashSuchak(objProjectDetail);
        }


        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBhuktaniPrakar(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateBhuktaniPrakar(objProjectDetail);

        }
       

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateParamarsaBibaran(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateParamarsaBibaran(objProjectDetail);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAayojanaBadfad(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateAayojanaBadfad(objProjectDetail);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBarshikBadfad(ComProjectBO objProjectDetail)
        {
            Authentication();
            return objProject.PopulateBarshikBadfad(objProjectDetail);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateRananitiBySubSectorId(ComSubSector objComSubSector)
        {
            Authentication();

            return objProject.PopulateRananitiBySubSectorId(objComSubSector);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateKaryanitiByRananitiId(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateKaryanitiByRananitiId(objComProjectBO);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int CountMaxRows(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.CountMaxRows(objComProjectBO);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectByBudgetHead(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateProjectByBudgetHead(objComProjectBO);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearShrotgatBadfad(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.ClearShrotgatBadfad(objComProjectBO);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveShrotgatBudgetBadfad(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.SaveShrotgatBudgetBadfad(objComProjectBO);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveProjectCostingTiming(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.SaveProjectCostingTiming(objComProjectBO);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectCostingTiming(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateProjectCostingTiming(objComProjectBO);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAdministrativeDetails(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateAdministrativeDetails(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBhautikSamagri(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateBhautikSamagri(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateShrotgatAayojanaBadfad(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateShrotgatAayojanaBadfad(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveAdminDetails(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.SaveAdminDetails(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearBhautikSamagri(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.ClearBhautikSamagri(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveBhautikSamagri(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.SaveBhautikSamagri(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateOtherDetails(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateOtherDetails(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateParamarshaBibaran(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateParamarshaBibaran(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveOtherDetails(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.SaveOtherDetails(objComProjectBO);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearParamarshaDetails(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.ClearParamarshaDetails(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveParamarshaBibaran(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.SaveParamarshaBibaran(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectList(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateProjectList(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectListForReport(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateProjectListForReport(objComProjectBO);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectDetails(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateProjectDetails(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectSansodhan(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateProjectSansodhan(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearProjectSansodhan(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.ClearProjectSansodhan(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveProjectSansodhan(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.SaveProjectSansodhan(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearProjectProblems(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.ClearProjectProblems(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveProjectProblems(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.SaveProjectProblems(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectProblems(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateProjectProblems(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearProjectLavanvitPragati(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.ClearProjectLavanvitPragati(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveProjectLavanvitPragati(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.SaveProjectLavanvitPragati(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectLavanvitPragati(ComProjectBO objComProjectBO)
        {
            Authentication();
            return objProject.PopulateProjectLavanvitPragati(objComProjectBO);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectListRpt(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateProjectListRpt(objComProjectBo);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearAayojanaPramukh(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.ClearAayojanaPramukh(objComProjectBo);

        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveAayojanaPramukh(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.SaveAayojanaPramukh(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAayojanaPramukh(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateAayojanaPramukh(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateStatusProblemsAndEffortsForReport(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateStatusProblemsAndEffortsForReport(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectSamastigatReport(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateProjectSamastigatReport(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectSamastigatDashboard(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateProjectSamastigatDashboard(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateThekkaSankhyaRakam(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateThekkaSankhyaRakam(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearProjectThekkaSankhya(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.ClearProjectThekkaSankhya(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveProjectThekkaSankhya(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.SaveProjectThekkaSankhya(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateParamarshaSankhya(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateParamarshaSankhya(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearParamarshaSankhya(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.ClearParamarshaSankhya(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveParamarshaSankhya(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.SaveParamarshaSankhya(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateChartData(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateChartData(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBarChartData(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateBarChartData(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateBarshikChart(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateBarshikChart(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int ClearProjectPratifal(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.ClearProjectPratifal(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int SaveProjectPratifal(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.SaveProjectPratifal(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectOutput(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateProjectOutput(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateProjectByMinstryId(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.PopulateProjectByMinstryId(objComProjectBo);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable GetBudgetOrganizationMapDetails(int budgetHeadId)
        {
            Authentication();
            return objProject.GetBudgetOrganizationMapDetails(budgetHeadId);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int CheckLowerLevelVerification(int projectId, string level)
        {
            Authentication();
            return objProject.CheckLowerLevelVerification(projectId, level);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int CheckLowerLevelReportVerification(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.CheckLowerLevelReportVerification(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddReportVerification(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.AddReportVerification(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int CheckLowerLevelProjectPratifalReport(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.CheckLowerLevelProjectPratifalReport(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddProjectPratifalReportVerification(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.AddProjectPratifalReportVerification(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int CheckLowerLevelProjectSamastigatReport(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.CheckLowerLevelProjectSamastigatReport(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddProjectSamastigatReportVerification(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.AddProjectSamastigatReportVerification(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int CheckLowerLevelProjectStatusProblemEffortReport(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.CheckLowerLevelProjectStatusProblemEffortReport(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddProjectStatusProblemEffortReportVerification(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.AddProjectStatusProblemEffortReportVerification(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int CheckLowerLevelNewProjectVerification(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.CheckLowerLevelNewProjectVerification(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddNewProjectVerification(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.AddNewProjectVerification(objComProjectBo);
        }

        
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddEditRananiti(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.AddEditRananiti(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateRananitiDetails(int rananitiId)
        {
            Authentication();
            return objProject.PopulateRananitiDetails(rananitiId);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAllRananitiBySubSectorId(int subSectorId, string lang)
        {
            Authentication();
            return objProject.PopulateAllRananitiBySubSectorId(subSectorId, lang);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAllRananiti(string lang)
        {
            Authentication();
            return objProject.PopulateAllRananiti(lang);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public int AddEditKaryaniti(ComProjectBO objComProjectBo)
        {
            Authentication();
            return objProject.AddEditKaryaniti(objComProjectBo);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateKaryanitiDetails(int karyanitiId)
        {
            Authentication();
            return objProject.PopulateKaryanitiDetails(karyanitiId);
        }
        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public DataTable PopulateAllKaryaniti(int rananitiId, string lang)
        {
            Authentication();
            return objProject.PopulateAllKaryaniti(rananitiId, lang);
        }
    }
}
