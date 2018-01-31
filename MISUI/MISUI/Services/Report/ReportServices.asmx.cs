using System.Web.Services;
using System.Web.Script.Serialization;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

namespace MISUI.Services.Report
{
    /// <summary>
    /// Summary description for ReportServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ReportServices : System.Web.Services.WebService
    {

        public ReportServices()
        {
            //return "Hello World";
        }

        private JavaScriptSerializer serializer = null;
        public JavaScriptSerializer Serializer
        {
            get
            {
                if (serializer == null)
                    serializer = new JavaScriptSerializer();
                return serializer;
            }
        }

        public ReportDocument GetReport(ReportDocument repDoc, CrystalReportViewer viewer)
        {

            // rpt.SetDatabaseLogon("projects", "tribikramdhungana", "orcl", "");
            viewer.HasToggleGroupTreeButton = false;
            viewer.HasToggleParameterPanelButton = false;
            viewer.HasCrystalLogo = false;
            viewer.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;



            SetConnectionInfo(repDoc);
            return (repDoc);


        }

        public void SetConnectionInfo(ReportDocument reportSource)
        {

            setLogonInfo(reportSource);
        }

        public void setLogonInfo(ReportDocument reportDoc)
        {
            if (!reportDoc.IsSubreport)
            {
                foreach (ReportDocument rptSubDoc in reportDoc.Subreports)
                {
                    setLogonInfo(rptSubDoc);

                }
            }

            CrystalDecisions.Shared.ConnectionInfo conInfo = new CrystalDecisions.Shared.ConnectionInfo();
           /* conInfo.ServerName = "202.45.144.159";//ConfigurationManager.AppSettings["DBServer"];
            conInfo.UserID = "mis"; //ConfigurationManager.AppSettings["DBUserID"];
            conInfo.Password = "mis123";// ConfigurationManager.AppSettings["DBPassword"];
            conInfo.DatabaseName = "ORCLDATABASE"; //ConfigurationManager.AppSettings["DBNAME"];*/

            conInfo.ServerName = "wbrs";//ConfigurationManager.AppSettings["DBServer"];
            conInfo.UserID = "MIS"; //ConfigurationManager.AppSettings["DBUserID"];
            conInfo.Password = "MIS123";// ConfigurationManager.AppSettings["DBPassword"];

            //conInfo.DatabaseName = "ORCLDATABASE"; //ConfigurationManager.AppSettings["DBNAME"];
            //conInfo.IntegratedSecurity = false;


            foreach (CrystalDecisions.CrystalReports.Engine.Table tb in reportDoc.Database.Tables)
            {
                CrystalDecisions.Shared.TableLogOnInfo tblInfo = tb.LogOnInfo;
                tblInfo.ConnectionInfo = conInfo;

                tb.ApplyLogOnInfo(tblInfo);
            }

        }
    }
}
