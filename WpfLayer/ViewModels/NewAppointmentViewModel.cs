using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfLayer.Models;

namespace WpfLayer.ViewModels
{
    public class NewAppointmentViewModel : ObservableObject
    {
        AppointmentController appointmentController = new AppointmentController();
        EmailService emailService = new EmailService();

        private DateTime appointmentDate = DateTime.Now;
        private int selectedTimeIndex;
        private string newAppointmentReason;
        private string statusbarMessage;
        private string email; 


        public ObservableCollection<Appointment> patientAppointmentHistory { get; set; } = new ObservableCollection<Appointment>();

        public Appointment newAppointment;
        public Doctor doctor; 
        public Patient patient; 

        
        public ICommand MakeNewAppointmentCmd { get; private set; }
        public ICommand ReturnToPreviousWindowCmd { get; private set; }

        public ICommand SendEmailCmd { get; private set; }

        public ICommand CloseWindowCmd { get; private set; }

        private Action<ObservableCollection<Appointment>> _updateAppointmentHistoryCallback;
        public NewAppointmentViewModel(Doctor doctor, Patient patient, Action<ObservableCollection<Appointment>> updateAppointmentHistoryCallback)
        {
            this.doctor = doctor;
            this.patient = patient;

            statusbarMessage = $"Appointment Scheduler activated.\n\nNew appointment for Doctor: {doctor.name} (ID: {doctor.doctorID})\n\nPatient: {patient.name} ({patient.patientId})";

            MakeNewAppointmentCmd = new RelayCommand(MakeNewAppointment, CanMakeNewAppointment);
            ReturnToPreviousWindowCmd = new RelayCommand(CloseWidnow);
            SendEmailCmd = new RelayCommand(SendEmailConfirmation, CanSendEmailConfirmation);
            CloseWindowCmd = new RelayCommand(CloseWidnow);

            patientAppointmentHistory = new ObservableCollection<Appointment>(appointmentController.GetPatientAppointments(patient));

            _updateAppointmentHistoryCallback = updateAppointmentHistoryCallback;

            

        }

        public DateTime AppointmentDate
        {
            get { return appointmentDate; }
            set
            {
                appointmentDate = value;
                OnPropertyChanged("AppointmentDate");
            }
        }
        public int SelectedTimeIndex
        {
            get { return selectedTimeIndex; }
            set
            {
                selectedTimeIndex = value;
                OnPropertyChanged("SelectedTimeIndex");
            }
        }

        public string NewAppointmentReason
        {
            get { return newAppointmentReason; }
            set
            {
                newAppointmentReason = value;
                OnPropertyChanged("NewAppointmentReason");
            }
        }

        public string StatusbarMessage
        {
            get { return statusbarMessage; }
            set
            {
                statusbarMessage = value;
                OnPropertyChanged("StatusbarMessage");
            }
        }

        public Appointment NewAppointment
        {
            get { return newAppointment; }
            set
            {
                newAppointment = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private bool CanMakeNewAppointment()
        {
            // Kontrollera att NewAppointmentReason är ifyllt och att AppointmentDate är i framtiden eller nuet
            return !string.IsNullOrEmpty(NewAppointmentReason) &&
                   AppointmentDate != null && SelectedTimeIndex != null;
        }

        private void MakeNewAppointment()
        {
            if (AppointmentDate < DateTime.Now)
            {
                MessageBox.Show("Unable to schedule appointments for dates earlier than today");
                return;
            }

            // Hämta vald tid från ComboBox
            var selectedTime = SelectedTimeIndex switch
            {
                0 => TimeSpan.FromHours(8),   // 08:00 AM
                1 => TimeSpan.FromHours(9),   // 09:00 AM
                2 => TimeSpan.FromHours(10),
                3 => TimeSpan.FromHours(11),
                4 => TimeSpan.FromHours(12),
                5 => TimeSpan.FromHours(13),
                6 => TimeSpan.FromHours(14),
                7 => TimeSpan.FromHours(15),
                8 => TimeSpan.FromHours(16),
                9 => TimeSpan.FromHours(17),
                10 => TimeSpan.FromHours(18),
                // Lägg till fler alternativ efter behov

            };

            // Kombinera valt datum och tid för att skapa ett DateTime-objekt
            DateTime appointmentDateTime = AppointmentDate.Date + selectedTime;

            newAppointment = appointmentController.NewAppointmentByDoctor(patient.patientId, appointmentDateTime, NewAppointmentReason, doctor.doctorID);

            patientAppointmentHistory.Add(newAppointment);
            MessageBox.Show("Appointment scheduled");
            NewAppointmentReason = "";

            _updateAppointmentHistoryCallback(patientAppointmentHistory);

            //CloseWidnow();
        }

        private bool CanSendEmailConfirmation()
        {
            return !string.IsNullOrEmpty(Email) && NewAppointment != null;
        }


        private void SendEmailConfirmation()
        {
            string fromMail = "medicalsystemcommunications@gmail.com";
            string fromPassword = "vczz pwba wlxe gnik";

            string to = Email;
            string subject = "Your Appointment Confirmation";

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
                    <p>Your appointment with Dr. {doctor.name} has been scheduled for {NewAppointment.appointmentDate}.</p>
                    <p>Appointment Reason: {NewAppointment.appointmentReason}</p>
                    <p>Best regards,<br />Medical System</p>
                </div>
            </body>
            </html>";

            emailService.SendEmail(fromMail, fromPassword, to, subject, body);

            MessageBox.Show("Email sent");
        }


        private void CloseWidnow()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }
    }
}
