﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmailService
    {
        /// <summary>
        /// Denna klass och funktionalitet är helt frivillig och frånkopplad från labben och dess krav.
        /// Detta används i vyn där en läkare kan boka ett nytt appointment. 
        /// Där kan man mata in en frivillig mejl som får en bekräftelse på den bokade tiden med information om tiden.
        /// Den är fullt fungerande och skickar mejl till angiven adress.
        /// </summary>
        /// 

        #region Email Validation

        //Kontrollerar att e-postadressen innehåller minst en teckenföljd följt av "@"-tecknet, följt av en annan teckenföljd, följt av ett punkttecken och en slutlig teckenföljd (t.ex. ".com", ".org", etc.).
        public static string emailRegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public static Regex regex = new Regex(emailRegexPattern);

        #endregion Email Validation

        #region Email Sending
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

        #endregion Email Sending

        #region Email Template Generation

        //Denna metod används för att generera en template med HTML/CSS för att skicka en bekräftelse på en bokad tid.
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
                                        <p>Best regards,<br />Oasis Medical Center</p>
                                    </div>
                                </body>

                            </html>";

            return body;
        }

        #endregion Email Template Generation

    }
}
