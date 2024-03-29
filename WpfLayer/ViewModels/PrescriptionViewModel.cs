﻿using EntityLayer;
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
    public class PrescriptionViewModel : ObservableObject
    {
        //Lokal variabel som skickar patientobjekt från föregående vy, se konstruktor för tilldelning.
        Patient patient; 

        //Kontrollerklasser för att hämta relevanta metoder
        DrugController drugController = new DrugController();
        PrescriptionController prescriptionController = new PrescriptionController();

        // Listor som är bundna in XAML
        #region Lists bound in XAML as datagrids
        public ObservableCollection<Drug> Drugs { get; set; } = new ObservableCollection<Drug>(); //DATAGRID
        public ObservableCollection<Drug> DrugsInPrescription { get; set; } = new ObservableCollection<Drug>(); //DATAGRID
        public ObservableCollection<Drug> SelectedDrugs { get; set; } = new ObservableCollection<Drug>(); //DATAGRID 

        private ObservableCollection<Prescription> prescriptionHistory;
        #endregion

        //Properties som är bundna i XAML
        #region Properties bound in XAML
        private int totalDrugsOfAllPrescriptions { get; set; }
        private string patientName;
        private string patientId;
        private string statusBarPatientInfo;
        #endregion

        //Objekt som hjälper till att anropa kontrollermetoder och sätta värden till egenskaper som är bundna i XAML
        private Drug selectedDrug;
        private Drug selectedDrugToRemove;
        private Prescription selectedPrescription;

        #region Commands
        public ICommand AddDrugCmd { get; private set; }
        public ICommand RemoveDrugCmd { get; private set; }
        public ICommand SavePrescriptionCmd { get; private set; }
        public ICommand ShowDrugsFromPrescriptionCmd { get; private set; }
        public ICommand CloseWindowCmd { get; private set; }
        #endregion

        public PrescriptionViewModel(Patient patient)
        {
            //Tilldelar patientobjektet till den lokala variabeln
            this.patient = patient;

            #region Commands initialization
            AddDrugCmd = new RelayCommand(AddDrugToList, CanAddDrug);
            RemoveDrugCmd = new RelayCommand(RemoveDrug, CanRemoveDrug);
            SavePrescriptionCmd = new RelayCommand(CreatePrescription, CanCreatePrescription);
            ShowDrugsFromPrescriptionCmd = new RelayCommand(ShowDrugsFromPrescription, CanShowDrugsFromPrescription);
            CloseWindowCmd = new RelayCommand(CloseWidnow);
            #endregion

            //Sätter patientens namn och ID till egenskaperna som är bundna i XAML
            #region statusbar info
            patientName = $"Patient name: {patient.name}";
            patientId = $"Patient ID: {patient.patientId}";
            statusBarPatientInfo = $"Currently managing prescription for Patient: {patient.name} - ID: {patient.patientId}";
            #endregion

            #region Assigning drugs and prescription from the database to the ObservableCollection
            Drugs = new ObservableCollection<Drug>(drugController.GetAllDrugs());
            prescriptionHistory = new ObservableCollection<Prescription>(prescriptionController.GetPatientPrescriptionHistory(patient.patientId));

            //Tilldelar totala antalet läkemedel från alla recept till egenskapen som är bunden i XAML i varningstextblocket
            foreach(var prescription in prescriptionHistory)
            {
                // += gör att det ökar för varje recept som läggs till, samt minns det som redan finns i totalDrugsOfAllPrescriptions
                totalDrugsOfAllPrescriptions += prescription.drugCount;
            }
            #endregion
        }

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

        // Metoder som binder till commands
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
            //Varnar bara om det finns befintliga recept
            if (prescriptionHistory.Count > 0) 
            {
                MessageBoxResult result = MessageBox.Show($"Patient {patient.name} has {prescriptionHistory.Count} prescriptions on record, totaling {TotalDrugsOfAllPrescriptions}" +
                    $" drugs prescribed.\n\nBefore proceeding, have you ensured that the current prescription does not contraindicate with any existing or concurrent prescriptions?\n\n" +
                    $"Please review the Prescription History for further information. \n\nThis can help reduce the risk of unwanted side effects.", "Drug Interaction Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);

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

            OnPropertyChanged(nameof(TotalDrugsOfAllPrescriptions));

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
