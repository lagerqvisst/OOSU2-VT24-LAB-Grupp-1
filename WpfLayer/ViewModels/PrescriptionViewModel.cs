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

namespace WpfLayer.ViewModels
{
    public class PrescriptionViewModel : ObservableObject
    {
        Patient patient;
        private string patientName;
        private string patientId;

        DrugController drugController = new DrugController();
        PrescriptionController prescriptionController = new PrescriptionController();
        public ObservableCollection<Drug> Drugs { get; set; } = new ObservableCollection<Drug>(); //DATAGRID

        public ObservableCollection<Drug> DrugsInPrescription { get; set; } = new ObservableCollection<Drug>(); //DATAGRID
        public ObservableCollection<Drug> SelectedDrugs { get; set; } = new ObservableCollection<Drug>(); //DATAGRID 

        public ObservableCollection<Prescription> prescriptionHistory;

        private Drug selectedDrug;
        private Drug selectedDrugToRemove;
        private Prescription selectedPrescription;
        public ICommand AddDrugCmd { get; private set; }
        public ICommand RemoveDrugCmd { get; private set; }
        public ICommand SavePrescriptionCmd { get; private set; }

        public ICommand ShowDrugsFromPrescriptionCmd { get; private set; }

        public PrescriptionViewModel(Patient patient)
        {
            this.patient = patient;
            patientName = $"Patient name: {patient.name}";
            patientId = $"Patient ID: {patient.patientId}";

            Drugs = new ObservableCollection<Drug>(drugController.GetAllDrugs());
            prescriptionHistory = new ObservableCollection<Prescription>(prescriptionController.GetPatientPrescriptionHistory(patient.patientId));

            AddDrugCmd = new RelayCommand(AddDrugToList, CanAddDrug);
            RemoveDrugCmd = new RelayCommand(RemoveDrug, CanRemoveDrug);
            SavePrescriptionCmd = new RelayCommand(CreatePrescription, CanCreatePrescription);
            ShowDrugsFromPrescriptionCmd = new RelayCommand(ShowDrugsFromPrescription, CanShowDrugsFromPrescription);
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

        private bool CanAddDrug()
        {
            return SelectedDrug != null;
        }

        private void AddDrugToList()
        {
            if(SelectedDrug != null)
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
            if(SelectedDrugToRemove != null)
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
            DateTime dateOfPrescription = DateTime.Now;

            // Skapa receptet asynkront
            Prescription precription = prescriptionController.CreatePrescription(patient.patientId, dateOfPrescription, SelectedDrugs);

            // Uppdatera recept historiken
            PrescriptionHistory.Add(precription);

            // Meddela gränssnittet om uppdateringen
            OnPropertyChanged(nameof(PrescriptionHistory));

            MessageBox.Show("Prescription has been created");

            

            SelectedDrugs.Clear(); // Ta bort befintliga element
        }


        public Prescription SelectedPrescription
        {
            get { return selectedPrescription; }
            set { selectedPrescription = value; OnPropertyChanged(); }
        }

        private bool CanShowDrugsFromPrescription()
        {
            return SelectedPrescription != null;
        }

        private void ShowDrugsFromPrescription()
        {
            if (SelectedPrescription != null)
            {
                var drugs = drugController.GetDrugsByPrescriptionId(SelectedPrescription.prescriptionId);

                DrugsInPrescription.Clear(); // Ta bort befintliga element

                foreach (var drug in drugs)
                {
                    DrugsInPrescription.Add(drug); // Lägg till nya element
                }

                OnPropertyChanged(nameof(DrugsInPrescription));
            }
        }

    }
}
