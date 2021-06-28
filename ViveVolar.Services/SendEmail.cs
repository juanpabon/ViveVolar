using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Services
{
    public class SendEmail : ISendEmail
    {
        public SendEmail()
        {

        }
        public bool Send(string To, string Subject,string Mensaje, bool IsBodyHtml)
        {
            string From = "juanvivevolar@gmail.com";
            string Password = "Vivevolar123";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(From);
            mailMessage.To.Add(To);
            mailMessage.Subject = Subject;
            mailMessage.Body = Mensaje;
            mailMessage.IsBodyHtml = IsBodyHtml;

            SmtpClient smtpClient = new SmtpClient
            {
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(From, Password)
            };
           

            smtpClient.Send(mailMessage);
            smtpClient.Dispose();
            return true;
        }
    }
}
