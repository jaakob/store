using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Mail;
using PhoneStore.Models;
using System.Security.Policy;

namespace PhoneStore.BL.Email
{
    public static class EmailHelper
    {
        private const string fromAddress = "jacob.oleynik.team@gmail.com";
        private const string password = "04061992lmhz";
        private const string smtpServer = "smtp.gmail.com";
        private const string server = "localhost:49742";
        private static int port = 587;

        public async static Task SendMail(User user)
        {
            MailAddress from = new MailAddress(fromAddress, "Phone store registration");
            MailAddress to = new MailAddress(user.Email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Email confirmation";
            m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" +
                             "<a href=\"{0}\"title=\"Подтвердить регистрацию\">{0}</a>", $"http://{server}/Account/ConfirmEmail?token=" + user.Cookie);
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(smtpServer, port);
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(fromAddress, password);
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            await smtp.SendMailAsync(m);
        } 
    }
}