using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace PhoneStore.BL.Service
{
    public static class EmailService
    {
        public static async Task SendEmailAsync(string receiverEmail, string token)
        {
            MailAddress from = new MailAddress("jvmphonestore@gmail.com", "JVM Phone store");
            MailAddress to = new MailAddress(receiverEmail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "JVM Phone Store registration link";
            message.Body = "Registration link: http://localhost:49742/Register/Confirm/" + token;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("jvmphonestore@gmail.com", "qwerty123~");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);            
        }
    }
}