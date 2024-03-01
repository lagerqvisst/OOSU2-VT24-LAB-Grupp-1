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
        //Textbindings 

        private string patientName;
        private string patientId;
        private string appointmentId;
        private string appointmentReason;


        //CONTROLLER KLASSER 
        public AppointmentController appointmentController = new AppointmentController();
        public DoctorController doctorController = new DoctorController();
        public PatientController patientController = new PatientController();
        public DiagnosisController diagnosisController = new DiagnosisController();

        //LISTOR SOM KOMMER VISAS I DATAGRIDS 

        public ObservableCollection<Appointment> appointments { get; set; } = new ObservableCollection<Appointment>();

        public Appointment appointment;
        public Diagnosis diagnosis;
        public Patient patient;


        public ICommand MakeNoteCmd { get; private set; }
        public ICommand MakeDiagnosisCmd { get; private set; }

        public ICommand OpenPrescriptionMgmtCmd { get; private set; }

        public AppMgmtViewModel(Appointment appointment)
        {
            this.appointment = appointment;
            patient = patientController.GetPatientById(appointment.patientId);
            MakeNoteCmd = new RelayCommand(MakeNote, CanMakeNote);
            MakeDiagnosisCmd = new RelayCommand(MakeDiagnosis, CanMakeDiagnosis);
            OpenPrescriptionMgmtCmd = new RelayCommand(OpenPrescriptionView, CanOpenPrescriptionView);

            patientName = $"Patient name: {patient.name}";
            patientId = $"Patient ID: {patient.patientId}";
            appointmentId = $"Appointment ID: {appointment.appointmentId}";
            appointmentReason = $"Appointment reason: {appointment.appointmentReason}";


        }

        //START DOCTORS NOTE FUNKTIONALITET
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
                MessageBox.Show("Doktorsnoteringen har uppdaterats");
            }

        }
        //SLUT DOCTORS NOTE FUNKTIONALITET


        //START DIAGNOS FUNKTIONALITET
        private string _diagnosisDescription;
        public string DiagnosisDescription
        {
            get { return _diagnosisDescription; }
            set
            {
                _diagnosisDescription = value;
                OnPropertyChanged(); // Förutsatt att du har implementerat INotifyPropertyChanged
            }
        }

        private string _treatmentSuggestion;
        public string TreatmentSuggestion
        {
            get { return _treatmentSuggestion; }
            set
            {
                _treatmentSuggestion = value;
                OnPropertyChanged(); // Förutsatt att du har implementerat INotifyPropertyChanged
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

            MessageBox.Show("Diagnos har lagts till");

        }
        //SLUT DIAGNOSIS COMMAND 

        //START ÖPPNA PRESCRIPTION COMMAND 

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
            prescriptionView.Show();
        }

        //TEXT LÄNGST UPP MED INFO OM PATIENTEN OCH APPOINTMENT

        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; OnPropertyChanged(); }
        }

        public string PatientName { 
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
    }
}

