using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmailService
    {
        public void SendEmail(string to, string body)
        {
            string fromMail = "lagerqvistmusik@gmail.com";
            string fromPassword = "knzh ibgg eofl ouwh";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Your Appointment Confirmation";
            message.To.Add(new MailAddress(to));
            message.Body = $"<html><body>{body}</body></html>";
            message.IsBodyHtml = true;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromMail, fromPassword)
            };

            smtp.Send(message);
        }
    }
}
