using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;


namespace ModelCompetencyAssessment
{
    public class UserNotification
    {
        public static string SendGeneric_Mail(string to, string from, string subject, string msg)
        {
            string message = string.Empty;
            try
            {
                MailMessage mm = new MailMessage(from, to);
                mm.Subject = subject;
                mm.Body = msg;
                mm.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                NetworkCredential obj = new NetworkCredential("tryemail740@gmail.com", "admin@1234");
                smtp.Credentials = obj;

                smtp.Send(mm);

                message = "Email Sent!!";

                return message;
                // In case security restriction is there in account settings of GMAIL ID then access this link and enable setting after logging into your mail box
                // https://myaccount.google.com/lesssecureapps
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return message;
            }
        }
    }
}
