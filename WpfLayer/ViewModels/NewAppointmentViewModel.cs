using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
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

        private DateTime appointmentDate = DateTime.Now;
        private int selectedTimeIndex;
        private string newAppointmentReason;

        public Appointment newAppointment;
        public Doctor doctor; 
        public Patient patient; 

        private ObservableObject patientAppointmentHistory = new ObservableObject();
        public ICommand MakeNewAppointmentCmd { get; private set; }
        public ICommand ReturnToPreviousWindowCmd { get; private set; }
        public NewAppointmentViewModel(Doctor doctor, Patient patient)
        {
            this.doctor = doctor;
            this.patient = patient;

            MakeNewAppointmentCmd = new RelayCommand(MakeNewAppointment, CanMakeNewAppointment);
            ReturnToPreviousWindowCmd = new RelayCommand(CloseWidnow);

            
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
            //Messenger.Default.Send(new NewAppointmentScheduledMessage(patientAppointmentHistory));

            //patientAppointmentHistory.Add(newAppointment);
            MessageBox.Show("Appointment scheduled");
            NewAppointmentReason = "";

            CloseWidnow();
        }

        private void CloseWidnow()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }
    }
}
