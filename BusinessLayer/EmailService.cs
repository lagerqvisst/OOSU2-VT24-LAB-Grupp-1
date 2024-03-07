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
        public void SendEmail(string to, string subject, string body)
        {
            string fromMail = "medicalsystemcommunications@gmail.com";
            string fromPassword = "vczz pwba wlxe gnik";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
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
                Credentials = new System.Net.NetworkCredential(fromMail, fromPassword)
            };

            smtp.Send(message);
        }


        public static string GenerateAppointmentConfirmationEmail(string doctorName, string patientName, int appointmentId, DateTime appointmentDate, string appointmentReason)
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
                                        <p>Dear {patientName},</p>
                                        <p>Your appointment with Dr. {doctorName} has been scheduled for {appointmentDate.ToShortDateString()} at {appointmentDate.ToShortTimeString()}.</p>
                                        <p>Appointment Reason: {appointmentReason}</p>
                                        <p>Your appointment ID is: {appointmentId}</p>
                                        <p>Best regards,<br />Medical System</p>
                                    </div>
                                </body>

                            </html>";

            return body;
        }


    }
}
