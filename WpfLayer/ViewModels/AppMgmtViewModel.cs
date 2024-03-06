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
        private Appointment selectedAppointment;
        private string selectedAppointmentDoctorsNote;
        private string selectedAppointmentReason;
        private Diagnosis selectedDiagnosis;
        private string selectedDiagnosisDescription;
        private string selectedTreatmentSuggestion;
        private int selectedTimeIndex;
        private string medicalCondition;
        private string selectedMedicalCondition;

        //Collections that are binded in XAML through DataGrids
        public ObservableCollection<Appointment> appointments { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Appointment> patientAppointmentHistory { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<Diagnosis> diagnosisHistory { get; set; } = new ObservableCollection<Diagnosis>();

        public ObservableCollection<String> medicalConditions { get; set; } = new ObservableCollection<String>();

        //Objects that help to call on controller methods and set values to properties bounded in XAML
        public Appointment appointment;
        public Appointment newAppointment;
        public Diagnosis diagnosis;
        public Patient patient;
        public Doctor doctor;

        // Commands
        public ICommand MakeNoteCmd { get; private set; }
        public ICommand MakeDiagnosisCmd { get; private set; }
        public ICommand OpenPrescriptionMgmtCmd { get; private set; }
        public ICommand MakeNewAppointmentCmd { get; private set; }
        public ICommand CloseWindowCmd { get; private set; }
        public ICommand DataGridShowDoctorsNoteCmd { get; private set; }
        public ICommand DataGridShowReasonCmd { get; private set; }
        public ICommand DataGridShowDetailsNoteReasonCmd { get; private set; }
        public ICommand DataGridShowDiagnosisCmd { get; private set; }
        public ICommand DataGridShowTreatmentCmd { get; private set; }
        public ICommand DataGridShowDetailsDiagnosisTreatCmd { get; private set; }

        public ICommand ApiExplained { get; private set; }

        public ICommand OpenDiagnosisHelperCmd { get; private set; }

        public ICommand OpenAppScheduleView { get; private set; }

        

        public AppMgmtViewModel(Appointment appointment)
        {
            //Initialize commands
            MakeNoteCmd = new RelayCommand(MakeNote, CanMakeNote);
            MakeDiagnosisCmd = new RelayCommand(MakeDiagnosis, CanMakeDiagnosis);
            OpenPrescriptionMgmtCmd = new RelayCommand(OpenPrescriptionView, CanOpenPrescriptionView);
            MakeNewAppointmentCmd = new RelayCommand(MakeNewAppointment, CanMakeNewAppointment);
            CloseWindowCmd = new RelayCommand(CloseWidnow);
            ApiExplained = new RelayCommand(ApiExplaination);
            OpenDiagnosisHelperCmd = new RelayCommand(OpenDiagnosisHelper);
            OpenAppScheduleView = new RelayCommand(OpenAppScheduleViewer);
            DataGridShowDetailsNoteReasonCmd = new RelayCommand(OpenExpandedDetailsNoteReason, CanOpenExpandedDetailsNoteReason);
            DataGridShowDetailsDiagnosisTreatCmd = new RelayCommand(OpenExpandedDetailsDiagnosisTreat, CanOpenExpandedDetailsDiagnosisTreat);

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
            medicalConditions = new ObservableCollection<String>(diagnosisController.ExtractMedicalConditionsFromApi());

            

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

        public int SelectedTimeIndex
        {
            get { return selectedTimeIndex; }
            set
            {
                selectedTimeIndex = value;
                OnPropertyChanged(nameof(SelectedTimeIndex)); // Säkerställ att ändringen notifieras till vyn
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

        public string SelectedDiagnosisDescription
        {
            get { return selectedDiagnosisDescription; }
            set { selectedDiagnosisDescription = value; OnPropertyChanged(); }
        }

        public string SelectedTreatmentSuggestion
        {
            get { return selectedTreatmentSuggestion; }
            set { selectedTreatmentSuggestion = value; OnPropertyChanged(); }
        }

        public Diagnosis SelectedDiagnosis
        {
            get { return selectedDiagnosis; }
            set { selectedDiagnosis = value; OnPropertyChanged(); }
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

        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
            set { selectedAppointment = value; OnPropertyChanged(); }
        }

        public string SelectedAppointmentDoctorsNote
        {
            get { return selectedAppointmentDoctorsNote; }
            set { selectedAppointmentDoctorsNote = value; OnPropertyChanged(); }
        }

        public string SelectedAppointmentReason
        {
            get { return selectedAppointmentReason; }
            set { selectedAppointmentReason = value; OnPropertyChanged(); }
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

        public ObservableCollection<Appointment> PatientAppointmentHistory
        {
            get { return patientAppointmentHistory; }
            set { patientAppointmentHistory = value; OnPropertyChanged(); }
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

        public string MedicalCondition
        {
            get { return medicalCondition; }
            set { medicalCondition = value; OnPropertyChanged(); }
        }

        public ObservableCollection<String> MedicalConditions
        {
            get { return medicalConditions; }
            set { medicalConditions = value; OnPropertyChanged(); }
        }

        public string SelectedMedicalCondition
        {
            get { return selectedMedicalCondition; }
            set { selectedMedicalCondition = value; OnPropertyChanged(); }
        }

        // Methos that are binded to the commands
        private bool CanMakeNote()
        {
            // Implementera logik för att avgöra om inloggning är möjlig
            return !string.IsNullOrEmpty(DoctorsNote);
        }

        //kommentar för att testa så att gitten funkar :D
        // den funkar inte lolz

        private void MakeNote()
        {
            if (appointment != null)
            {
                appointmentController.UpdateAppointmentDoctorsNote(appointment, DoctorsNote);
                // Rensa befintliga objekt i patientAppointmentHistory
                patientAppointmentHistory.Clear();
                // Lägg till uppdaterade objekt till patientAppointmentHistory
                appointmentController.GetPatientAppointments(patient).ToList().ForEach(patientAppointmentHistory.Add);
                MessageBox.Show("Doktorsnoteringen har uppdaterats");
                DoctorsNote = "";
            }
        }



        private bool CanMakeDiagnosis()
        {
            // Kan skapa diagnos om man valt från dropdown eller skrivit i fritext
            return !string.IsNullOrEmpty(DiagnosisDescription) !=null && SelectedMedicalCondition != null && !string.IsNullOrEmpty(TreatmentSuggestion); 
        }


        private void MakeDiagnosis()
        {
            DateTime dateOfDiagnosis = DateTime.Now;

            DiagnosisDescription = SelectedMedicalCondition + ": " + DiagnosisDescription;

            diagnosis = diagnosisController.AddDiagnosis(appointment.patientId, DiagnosisDescription, dateOfDiagnosis, TreatmentSuggestion);
            // Lägg till den nya diagnosen i diagnosisHistory
            diagnosisHistory.Add(diagnosis);
            MessageBox.Show("Diagnos har lagts till");
            DiagnosisDescription = "";

            // Uppdatera gränssnittet genom att meddela att en egenskap har ändrats
            OnPropertyChanged(nameof(diagnosisHistory));
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


        private void OpenDiagnosisHelper()
        {
            DiagnosisHelperView diagnosisHelperView = new DiagnosisHelperView();
            diagnosisHelperView.ShowDialog();
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
        }

        private bool CanOpenExpandedDetailsNoteReason()
        {
            return SelectedAppointment != null;
        }

        private void OpenExpandedDetailsNoteReason()
        {
            if (SelectedAppointment != null)
            {
                MessageBox.Show($"Doctors note: {SelectedAppointment.doctorsNote}\n\nReason for appointment: {SelectedAppointment.appointmentReason}");
            }
        }

        private bool CanOpenExpandedDetailsDiagnosisTreat()
        {
            return SelectedDiagnosis != null;
        }

        public void OpenExpandedDetailsDiagnosisTreat()
        {
            if (SelectedDiagnosis != null)
            {
                MessageBox.Show($"Diagnosis description: {SelectedDiagnosis.diagnosisDescription}\n\nTreatment suggestion: {SelectedDiagnosis.treatmentSuggestion}");
            }
        }
        public void OpenAppScheduleViewer()
        {
            NewAppointmentView appScheduleView = new NewAppointmentView(doctor, patient, UpdateAppointmentHistory);
            appScheduleView.ShowDialog();
        }

        private void UpdateAppointmentHistory(ObservableCollection<Appointment> updatedAppointments)
        {
            // Uppdatera appointmentHistory här
            PatientAppointmentHistory.Clear();
            foreach (var appointment in updatedAppointments)
            {
                PatientAppointmentHistory.Add(appointment);
            }
        }


        //Other Methods for navigation
        private void CloseWidnow()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }

        private void ApiExplaination()
        {
            MessageBox.Show("API Explanation:\n\nThe API retrieves medical conditions from an external source (https://clinicaltables.nlm.nih.gov/apidoc/conditions/v3/doc.html#params).\n\nIt utilizes the LHC FHIR Tools Clinical Table Search Service, allowing users to search for medical conditions using partial or complete terms.\n\nThe API fetches a list of over 2,400 medical conditions along with associated codes and terms. However, due to constraints, it retrieves a maximum of 500 conditions per query.\n\nUsers can search for conditions using various parameters and receive detailed information including ICD-10-CM codes, ICD-9-CM codes, synonyms, and more.\n\nWe have only utilized the API to extract examples of medical conditions.\n\nThe idea is for the doctor to choose a general classification for the condition and the to add a more detailed description for the specific patient.\r\n");
        }


    }
}

