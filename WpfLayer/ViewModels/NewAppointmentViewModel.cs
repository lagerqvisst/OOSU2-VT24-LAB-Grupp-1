﻿using BusinessLayer;
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
using static BusinessLayer.EmailService;

namespace WpfLayer.ViewModels
{
    //Klassen ärver från ObservableObject som är en klass som implementerar INotifyPropertyChanged
    public class NewAppointmentViewModel : ObservableObject
    {
        AppointmentController appointmentController = new AppointmentController();
        EmailService emailService = new EmailService();

        #region properties
        private DateTime appointmentDate = DateTime.Now;
        private int selectedTimeIndex;
        private string newAppointmentReason;
        private string statusbarMessage;
        private string email; 
        #endregion


        //Uppdateras av callback från AppointmentManagementViewModel eftersom när fönstret stängs manuellt av användaren och inte öppnas på nytt kan inte objektet skickas med som parameter
        public ObservableCollection<Appointment> patientAppointmentHistory { get; set; } = new ObservableCollection<Appointment>();

        public Appointment newAppointment;
        public Doctor doctor; 
        public Patient patient;

        #region Commands
        public ICommand MakeNewAppointmentCmd { get; private set; }
        public ICommand ReturnToPreviousWindowCmd { get; private set; }
        public ICommand SendEmailCmd { get; private set; }
        public ICommand CloseWindowCmd { get; private set; }
        #endregion

        // Vi gör en Action som tar en ObservableCollection<Appointment> som parameter och döper den till updateAppointmentHistoryCallback
        private Action<ObservableCollection<Appointment>> _updateAppointmentHistoryCallback;

        //Konstruktor som är lite special pga att vi behöver skicka med en callback för att uppdatera listan med patientens tidigare bokade tider.
        public NewAppointmentViewModel(Doctor doctor, Patient patient, Action<ObservableCollection<Appointment>> updateAppointmentHistoryCallback)
        {
            this.doctor = doctor;
            this.patient = patient;

            statusbarMessage = $"Appointment Scheduler activated.\n\nNew appointment for Doctor: {doctor.name} (ID: {doctor.doctorID})\n\nPatient: {patient.name} ({patient.patientId})";

            #region Commands initialization
            MakeNewAppointmentCmd = new RelayCommand(MakeNewAppointment, CanMakeNewAppointment);
            ReturnToPreviousWindowCmd = new RelayCommand(CloseWidnow);
            SendEmailCmd = new RelayCommand(SendEmailConfirmation, CanSendEmailConfirmation);
            CloseWindowCmd = new RelayCommand(CloseWidnow);
            #endregion

            //Hämtar patientens tidigare bokade tider från databasen
            patientAppointmentHistory = new ObservableCollection<Appointment>(appointmentController.GetPatientAppointments(patient));

            //Tilldelas från förra vyn som en metod som uppdaterar listan med patientens tidigare bokade tider
            _updateAppointmentHistoryCallback = updateAppointmentHistoryCallback;
        }

        #region Properties bound in XAML

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
        #endregion

        #region Methods bound to the commands

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
            DateTime appointmentDateTime = AppointmentDate  + selectedTime;

            //Skapar nytt appointment på inloggad doktor.
            newAppointment = appointmentController.NewAppointmentByDoctor(patient.patientId, appointmentDateTime, NewAppointmentReason, doctor.doctorID);

            patientAppointmentHistory.Add(newAppointment);
            MessageBox.Show("Appointment scheduled");
            NewAppointmentReason = "";

            //Uppdaterar listan i tidigare vy.
            _updateAppointmentHistoryCallback(patientAppointmentHistory);
        }

        private bool CanSendEmailConfirmation()
        {
            return !string.IsNullOrEmpty(Email) && NewAppointment != null;
        }

        private void SendEmailConfirmation()
        {
            // Kontrollera att e-postadressen är giltig, se EmailService i affärslagret för en förklaring.
            if (!regex.IsMatch(Email))
            {
                MessageBox.Show("Invalid email address");
                return;
            }
            else
            {
                string subject = "Your Appointment Confirmation";

                string body = EmailService.GenerateAppointmentConfirmationEmail(doctor.name, patient.name, NewAppointment.appointmentId, NewAppointment.appointmentDate, NewAppointment.appointmentReason);

                emailService.SendEmail(Email, subject, body);

                MessageBox.Show("Email sent, returning to appointment management view");

                CloseWidnow();
            }
        }

        private void CloseWidnow()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }
        #endregion
    }
}
