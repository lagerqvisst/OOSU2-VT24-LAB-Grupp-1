using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLayer.Models;
using BusinessLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using EntityLayer.Junction;

namespace WpfLayer.ViewModels
{
    //EJ GJORD MED KOMMENTARER ÄNNU
    public class PrescriptionViewModel : ObservableObject
    {

        Patient patient; //Local variable that passes patient object from the previous view, see constructor for assignemnt.

        //Controller classes to extract and create data from the database
        DrugController drugController = new DrugController();
        PrescriptionController prescriptionController = new PrescriptionController();

        // Properties that are binded in XAML
        #region Lists bound in XAML as datagrids
        public ObservableCollection<Drug> Drugs { get; set; } = new ObservableCollection<Drug>(); //DATAGRID
        public ObservableCollection<Drug> DrugsInPrescription { get; set; } = new ObservableCollection<Drug>(); //DATAGRID
        public ObservableCollection<Drug> SelectedDrugs { get; set; } = new ObservableCollection<Drug>(); //DATAGRID 

        private ObservableCollection<Prescription> prescriptionHistory;
        #endregion


        #region Properties bound in XAML
        private int totalDrugsOfAllPrescriptions { get; set; }
        private string patientName;
        private string patientId;
        private string statusBarPatientInfo;
        #endregion

        // Objects that help to call on controller methods and set values to properties bounded in XAML
        private Drug selectedDrug;
        private Drug selectedDrugToRemove;
        private Prescription selectedPrescription;

        // Commands 
        #region Commands
        public ICommand AddDrugCmd { get; private set; }
        public ICommand RemoveDrugCmd { get; private set; }
        public ICommand SavePrescriptionCmd { get; private set; }
        public ICommand ShowDrugsFromPrescriptionCmd { get; private set; }
        public ICommand CloseWindowCmd { get; private set; }
        #endregion

        public PrescriptionViewModel(Patient patient)
        {
            //Assigning the patient object to the local variable
            this.patient = patient;

            //Initialize commands
            #region Commands initialization
            AddDrugCmd = new RelayCommand(AddDrugToList, CanAddDrug);
            RemoveDrugCmd = new RelayCommand(RemoveDrug, CanRemoveDrug);
            SavePrescriptionCmd = new RelayCommand(CreatePrescription, CanCreatePrescription);
            ShowDrugsFromPrescriptionCmd = new RelayCommand(ShowDrugsFromPrescription, CanShowDrugsFromPrescription);
            CloseWindowCmd = new RelayCommand(CloseWidnow);
            #endregion

            //Setting the patient's name and ID to the properties that are binded in XAML
            #region statusbar info
            patientName = $"Patient name: {patient.name}";
            patientId = $"Patient ID: {patient.patientId}";
            statusBarPatientInfo = $"Currently managing prescription for Patient: {patient.name} - ID: {patient.patientId}";
            #endregion

            //Assigning the drugs and prescription from the database to the ObservableCollection
            #region Assigning drugs and prescription from the database to the ObservableCollection
            Drugs = new ObservableCollection<Drug>(drugController.GetAllDrugs());
            prescriptionHistory = new ObservableCollection<Prescription>(prescriptionController.GetPatientPrescriptionHistory(patient.patientId));

            //Assigning the total number of drugs from all prescriptions to the property that is binded in XAML in warning textblock
            foreach(var prescription in prescriptionHistory)
            {
                totalDrugsOfAllPrescriptions += prescription.drugCount;
            }
            #endregion

        }

        // Properties that are binded in XAML
        #region Properties bound in XAML
        public string StatusBarPatientInfo
        {
            get { return statusBarPatientInfo; }
            set
            {
                statusBarPatientInfo = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Prescription> PrescriptionHistory
        {
            get { return prescriptionHistory; }
            set
            {
                prescriptionHistory = value;
                OnPropertyChanged();
            }
        }

        public string PatientName
        {
            get { return patientName; }
            set
            {
                patientName = value;
                OnPropertyChanged();
            }
        }

        public string PatientId
        {
            get { return patientId; }
            set
            {
                patientId = value;
                OnPropertyChanged();
            }
        }

        
        public Drug SelectedDrug
        {
            get { return selectedDrug; }
            set { selectedDrug = value; OnPropertyChanged(); }
        }   
        public Drug SelectedDrugToRemove
        {
            get { return selectedDrugToRemove; }
            set { selectedDrugToRemove = value; OnPropertyChanged(); }
        }

        
        public Prescription SelectedPrescription
        {
            get { return selectedPrescription; }
            set { selectedPrescription = value; OnPropertyChanged(); }
        }

        public int TotalDrugsOfAllPrescriptions
        {
            get { return totalDrugsOfAllPrescriptions; }
            set { totalDrugsOfAllPrescriptions = value; OnPropertyChanged(); }
        }
        #endregion

        // Methos that are binded to the commands

        #region Methods bound to the commands
        private bool CanAddDrug()
        {
            return SelectedDrug != null;
        }

        private void AddDrugToList()
        {
            if (SelectedDrug != null)
            {
                SelectedDrugs.Add(SelectedDrug);
            }

        }

        private bool CanRemoveDrug()
        {
            return SelectedDrugToRemove != null;
        }

        private void RemoveDrug()
        {
            if (SelectedDrugToRemove != null)
            {
                SelectedDrugs.Remove(SelectedDrugToRemove);
            }
        }

        private bool CanCreatePrescription()
        {
            return SelectedDrugs.Count > 0;
        }

        private void CreatePrescription()
        {
            if(prescriptionHistory.Count > 0) //Warning only prompts if there are existing prescriptions
            {
                MessageBoxResult result = MessageBox.Show($"Patient {patient.name} has {prescriptionHistory.Count} prescriptions on record, totaling {TotalDrugsOfAllPrescriptions} drugs prescribed.\n\nBefore proceeding, have you ensured that the current prescription does not contraindicate with any existing or concurrent prescriptions?\n\nPlease review the Prescription History for further information. \n\nThis can help reduce the risk of unwanted side effects.", "Drug Interaction Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    AddPrescription();
                }

            }
            else
            {
                AddPrescription();
            }



        }

        private void AddPrescription()
        {
            DateTime dateOfPrescription = DateTime.Now;

            // Skapa receptet asynkront
            Prescription prescription = prescriptionController.CreatePrescription(patient.patientId, dateOfPrescription, SelectedDrugs);

            // Uppdatera recept historiken
            prescriptionHistory.Add(prescription);
            

            // Uppdatera gränssnittet genom att meddela att en egenskap har ändrats
            OnPropertyChanged(nameof(PrescriptionHistory));


            totalDrugsOfAllPrescriptions += prescription.drugCount;
            

            OnPropertyChanged(nameof(TotalDrugsOfAllPrescriptions)); //FUNGERAR INTE ATT UPPDATERA. 

            MessageBox.Show($"Prescription has been created.\n{prescription.drugCount} drugs were prescribed to patient.");
            

            SelectedDrugs.Clear(); // Ta bort befintliga element
        }



        private bool CanShowDrugsFromPrescription()
        {
            return SelectedPrescription != null;
        }

        private void ShowDrugsFromPrescription()
        {
            if (SelectedPrescription != null)
            {
                // Rensa befintliga droger innan du lägger till nya
                DrugsInPrescription.Clear();

                // Hämta läkemedel för det valda recept-ID
                List<Drug> drugs = prescriptionController.GetDrugsByPrescriptionId(SelectedPrescription.prescriptionId);

                // Lägg till de hämtade läkemedlen i DrugsInPrescription-listan
                foreach (Drug drug in drugs)
                {
                    DrugsInPrescription.Add(drug);
                }

                OnPropertyChanged(nameof(DrugsInPrescription));
            }
        }



        //Other Methods for navigation
        private void CloseWidnow()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }

        #endregion

    }
}
