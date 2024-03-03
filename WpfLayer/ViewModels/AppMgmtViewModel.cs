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
using WpfLayer.Commands;
using WpfLayer.Models;
using WpfLayer.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WpfLayer.ViewModels
{
    public class AppMgmtViewModel : ObservableObject
    {
        //Controller classes used to extract and create data from repoisitories
        public AppointmentController appointmentController = new AppointmentController();
        public DoctorController doctorController = new DoctorController();
        public PatientController patientController = new PatientController();
        public DiagnosisController diagnosisController = new DiagnosisController();

        // Properties that are binded in XAML
        private string patientName;
        private string patientId;
        private string appointmentId;
        private string appointmentReason;
        private string newAppointmentReason;
        private DateTime appointmentDate = DateTime.Now;
        private string statusBarMessage;
        private string _diagnosisDescription;
        private string _treatmentSuggestion;

        //Collections that are binded in XAML through DataGrids
        public ObservableCollection<Appointment> appointments { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Appointment> patientAppointmentHistory { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Diagnosis> diagnosisHistory { get; set; } = new ObservableCollection<Diagnosis>();

        //Objects that help to call on controller methods and set values to properties bounded in XAML
        public Appointment appointment;
        public Diagnosis diagnosis;
        public Patient patient;
        public Doctor doctor;

        // Commands
        public ICommand MakeNoteCmd { get; private set; }
        public ICommand MakeDiagnosisCmd { get; private set; }
        public ICommand OpenPrescriptionMgmtCmd { get; private set; }
        public ICommand MakeNewAppointmentCmd { get; private set; }
        public ICommand CloseWindowCmd { get; private set; }

        public AppMgmtViewModel(Appointment appointment)
        {
            //Initialize commands
            MakeNoteCmd = new RelayCommand(MakeNote, CanMakeNote);
            MakeDiagnosisCmd = new RelayCommand(MakeDiagnosis, CanMakeDiagnosis);
            OpenPrescriptionMgmtCmd = new RelayCommand(OpenPrescriptionView, CanOpenPrescriptionView);
            MakeNewAppointmentCmd = new RelayCommand(MakeNewAppointment, CanMakeNewAppointment);
            CloseWindowCmd = new RelayCommand(CloseWidnow);

            //Property values assigned.
            this.appointment = appointment;
            patient = patientController.GetPatientById(appointment.patientId);
            doctor = doctorController.GetDoctorById(appointment.doctorID);

            //XAML bounded properties assigned values
            patientName = $"Patient name: {patient.name}";
            patientId = $"Patient ID: {patient.patientId}";
            appointmentId = $"Appointment ID: {appointment.appointmentId}";
            appointmentReason = $"Appointment reason: {appointment.appointmentReason}";
            statusBarMessage = $"Currently managing appointment for Patient: {patient.name} - ID: {patient.patientId}\n" +
                $"Date for appointment: {appointment.appointmentDate}, Reason: {appointment.appointmentReason}";

            //Collections assigned values through controller methods
            patientAppointmentHistory = new ObservableCollection<Appointment>(appointmentController.GetPatientAppointments(patient));
            diagnosisHistory = new ObservableCollection<Diagnosis>(diagnosisController.PatientDiagnosis(patient));
        }

        // Properties that are binded in XAML
        private string _doctorsNote;
        public string DoctorsNote
        {
            get { return _doctorsNote; }
            set
            {
                _doctorsNote = value;
                OnPropertyChanged(); // Förutsatt att du har implementerat INotifyPropertyChanged
            }
        }

        public string StatusBarMessage
        {
            get { return statusBarMessage; }
            set
            {
                statusBarMessage = value;
                OnPropertyChanged();
            }
        }

        public string DiagnosisDescription
        {
            get { return _diagnosisDescription; }
            set
            {
                _diagnosisDescription = value;
                OnPropertyChanged(); // Förutsatt att du har implementerat INotifyPropertyChanged
            }
        }


        public string TreatmentSuggestion
        {
            get { return _treatmentSuggestion; }
            set
            {
                _treatmentSuggestion = value;
                OnPropertyChanged(); // Förutsatt att du har implementerat INotifyPropertyChanged
            }
        }

        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; OnPropertyChanged(); }
        }

        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; OnPropertyChanged(); }
        }

        public string AppId
        {
            get { return appointmentId; }
            set { AppId = value; OnPropertyChanged(); }
        }

        public string AppointmentReason
        {
            get { return appointmentReason; }
            set { AppointmentReason = value; OnPropertyChanged(); }
        }

        public DateTime AppointmentDate
        {
            get { return appointmentDate; }
            set { appointmentDate = value; OnPropertyChanged(); }
        }

        public string NewAppointmentReason
        {
            get { return newAppointmentReason; }
            set { newAppointmentReason = value; OnPropertyChanged(); }
        }

        // Methos that are binded to the commands
        private bool CanMakeNote()
        {
            // Implementera logik för att avgöra om inloggning är möjlig
            return !string.IsNullOrEmpty(DoctorsNote);
        }

        private void MakeNote()
        {
            // Implementera logik för inloggning
            if (appointment != null)
            {
                appointmentController.UpdateAppointmentDoctorsNote(appointment, DoctorsNote);
                patientAppointmentHistory = new ObservableCollection<Appointment>(appointmentController.GetPatientAppointments(patient));
                
                MessageBox.Show("Doktorsnoteringen har uppdaterats");
                DoctorsNote = "";   
            }

        }


        private bool CanMakeDiagnosis()
        {
            return !string.IsNullOrEmpty(DiagnosisDescription) && !string.IsNullOrEmpty(TreatmentSuggestion);
        }

        private void MakeDiagnosis()
        {
            DateTime dateOfDiagnosis = DateTime.Now;

            diagnosis = diagnosisController.AddDiagnosis(appointment.patientId, DiagnosisDescription, dateOfDiagnosis, TreatmentSuggestion);
            diagnosisHistory.Add(diagnosis);
            MessageBox.Show("Diagnos har lagts till");
            DiagnosisDescription = "";

        }

        private bool CanOpenPrescriptionView()
        {
            if (patient != null)
            {
                return true;
            }
            else return false;
        }
        private void OpenPrescriptionView()
        {
            PrescriptionView prescriptionView = new PrescriptionView(patient);
            prescriptionView.ShowDialog();
        }

 

 
        
        private bool CanMakeNewAppointment()
        {
            return !string.IsNullOrEmpty(NewAppointmentReason) && AppointmentDate != null;
        }

        private void MakeNewAppointment()
        {
            appointmentController.NewAppointmentByDoctor(patient.patientId, AppointmentDate, NewAppointmentReason, doctor.doctorID);

            MessageBox.Show("Ny tid har bokats");
            NewAppointmentReason = "";
        }

        //Other Methods for navigation
        private void CloseWidnow()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }


    }
}

