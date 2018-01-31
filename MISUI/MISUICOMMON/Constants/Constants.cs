using System.Configuration;

namespace MISUICOMMON.Constants
{
    public class Constants
    {
        public const string app = "1";
        private static string consPath = string.Empty;
        private static string serviceUsername = string.Empty;
        private static string servicePassword = string.Empty;
        //constant application path.Change it accordingly in web.config
        public static string ConstantAppPath
        {
            get { 
                consPath = ConfigurationManager.AppSettings["CONSTANTPATH"];
                return consPath;
            }
        }
        public static string ServiceUserName
        {
            get
            {
                consPath = ConfigurationManager.AppSettings["servicename"];
                return consPath;
            }
        }
        public static string ServicePassword
        {
            get
            {
                consPath = ConfigurationManager.AppSettings["servicevalue"];
                return consPath;
            }
        }
    }
    
}
