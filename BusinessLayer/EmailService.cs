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
        public void SendEmail(string from, string password, string to, string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.Subject = subject;
            message.To.Add(new MailAddress(to));
            message.Body = body;
            message.IsBodyHtml = true;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(from, password)
            };

            smtp.Send(message);
        }

        public class EmailTemplateManager
        {
            public static string GenerateAppointmentConfirmationEmail(string doctorName, DateTime appointmentDate, string appointmentReason)
            {
                string body = $@"
            <html>
            <head>
                <style>
                    /* Här kan du lägga till CSS för att formatera mejlet */
                    body {{
                        font-family: Arial, sans-serif;
                        font-size: 14px;
                    }}
                    .container {{
                        max-width: 600px;
                        margin: 0 auto;
                        padding: 20px;
                        border: 1px solid #ccc;
                        border-radius: 5px;
                        background-color: #f9f9f9;
                    }}
                    h2 {{
                        color: #007bff;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h2>Your Appointment Confirmation</h2>
                    <p>Dear Patient,</p>
                    <p>Your appointment with Dr. {doctorName} has been scheduled for {appointmentDate}.</p>
                    <p>Appointment Reason: {appointmentReason}</p>
                    <p>Best regards,<br />Medical System</p>
                </div>
            </body>
            </html>";

                return body;
            }
        }

    }
}
