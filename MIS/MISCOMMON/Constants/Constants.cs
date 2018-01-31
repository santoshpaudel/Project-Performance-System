using System.Configuration;

namespace MISCOMMON.Constants
{
    public class Constants
    {
        public const string app = "1";
        private static string consPath = string.Empty;
        //constant application path.Change it accordingly in web.config
        public static string ConstantAppPath
        {
            get { 
                consPath = ConfigurationManager.AppSettings["CONSTANTPATH"];
                return consPath;
            }
        }
        public static string UserName = "kshitizudan@gmail.com";
        public static string Password = "Udansoftware";
        public static string SmtpHost = "smtp.gmail.com";
        public static int SmtpPort = 587;
        public static string CcMail = "ujjwal.mishra@udansoftware.com.np";
    }
    
}
