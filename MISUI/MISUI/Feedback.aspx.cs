using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISUI
{
    public partial class Feedback : Base
    {
        string errorlogemail = ConfigurationSettings.AppSettings["EnableErrorLogEmail"];
        string adminemail = ConfigurationSettings.AppSettings["ErrorLogEmail"];
        string sitename = ConfigurationSettings.AppSettings["SiteName"];
        string adminpassword = ConfigurationSettings.AppSettings["AdminPassword"];
        string mailserver = ConfigurationSettings.AppSettings["MailServer"];
        string emailto = ConfigurationSettings.AppSettings["ReceiverEmail"];

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSend.Text = GetLabel("Send");
        }

        protected string[] Splitstring(String source, String[] splitseparator)
        {
            String[] result = source.Split(splitseparator, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string Name = string.Empty;
            string ContactNumber = string.Empty;
            string YourEmail = string.Empty;
            //string YourPassword = string.Empty;
            string Message = string.Empty;


            Name = txtName.Text;
            ContactNumber = txtContactNumber.Text;
            YourEmail = txtYourEmail.Text;
            // YourPassword = txtYourPassword.Text;
            Message = txtMessage.Text;

            //upload files
            //string allFiles = "";

            // objBo.ChaumasikFileName = allFiles;


            SendMail(Name, ContactNumber, YourEmail, Message);


        }

        private void SendMail(string Name, string ContactNumber, string YourEmail, string Message)
        {
            /*string email = YourEmail; 
              
            var loginInfo = new NetworkCredential(adminemail, adminpassword);
            var msg = new MailMessage();

            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            msg.From = new MailAddress(email);
            msg.To.Add(new MailAddress("spaudel77@gmail.com"));
            msg.Subject = "Feedback";
            msg.Body = Name + Environment.NewLine + Office + Environment.NewLine + ContactNumber +
                       Environment.NewLine + Message;
            msg.IsBodyHtml = true;

            smtpClient.Timeout = 10000;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);*/

            /* MailMessage mail = new MailMessage();
             MailAddress from = new MailAddress(YourEmail);
             SmtpClient clientobj = new SmtpClient("npcnepal.gov.np");
             mail.From = from;
             mail.To.Add(new MailAddress("spaudel77@gmail.com"));
             mail.Subject = "Feedback";
             mail.Body = Name + Environment.NewLine + Office + Environment.NewLine + ContactNumber +
                        Environment.NewLine + Message;
             mail.IsBodyHtml = true;
             clientobj.Credentials = new System.Net.NetworkCredential("webmaster@npc.gov.np", "web@master");
             clientobj.Port = 25;
             clientobj.EnableSsl = true;
             clientobj.Send(mail);*/

            MailMessage mail = new MailMessage();
            mail.Subject = "Feedback ";
            mail.From = new MailAddress(txtYourEmail.Text);
            //mail.Body = Name + "\r\n" + Session["office_name"].ToString() + "\r\n" + ContactNumber +
            //                "\r\n" + Message;
            mail.To.Add("ppiss.npc@gmail.com");
            mail.IsBodyHtml = true;

            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("नाम: " + Name + ",  " + Session["office_name"].ToString());
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("सम्पर्क नं (मोवाइल) : " + ContactNumber);
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("इमेल ठेगाना : " + YourEmail);
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("सुझाव : " + Message);
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("<br/><br/>");
            mail.Body = sbEmailBody.ToString();

            Attachment Data = null;
            if (fileFeedback.HasFile) // CHECK IF ANY FILE HAS BEEN SELECTED.
            {
                HttpFileCollection hfc = Request.Files;


                for (int f = 0; f <= hfc.Count - 1; f++)
                {
                    HttpPostedFile hpf = hfc[f];
                    if (hpf.ContentLength > 0)
                    {
                        string fileName;
                        fileName = DateTime.Now + hpf.FileName;
                        string ext = System.IO.Path.GetExtension(hpf.FileName);
                        var splitseparator = new string[] { ext };
                        var result = Splitstring(fileName, splitseparator);
                        String source = result[0];
                        string str = source + ext;
                        str = Regex.Replace(str, @"/", "_");
                        str = Regex.Replace(str, @":", "_");
                        str = Regex.Replace(str, @" ", "_");
                        str = Regex.Replace(str, @",", "_");
                        String newfolder = Server.MapPath("~") + @"FeedBackFiles\";
                        String path = newfolder + str;
                        hpf.SaveAs(path);
                        Data = new Attachment(path, MediaTypeNames.Application.Octet);
                        mail.Attachments.Add(Data);
                    }
                }
            }


            try
            {
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.Port = 587;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.EnableSsl = true;
                //NetworkCredential nc = new NetworkCredential("info@npc.gov.np", "ofni");
                NetworkCredential nc = new NetworkCredential("ppiss.npc@gmail.com", "Kathmandu@2016");

                SmtpServer.Credentials = nc;
                SmtpServer.Send(mail);
                lblSuccess.Text = " तपाइको सुझाव सफलतापूर्वक पेश भएको छ।";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to send email. Please try again.");
            }
        }
    }
}