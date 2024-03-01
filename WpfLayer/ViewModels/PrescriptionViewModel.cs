using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLayer.Models;
using BusinessLayer;
using System.Collections.ObjectModel;

namespace WpfLayer.ViewModels
{
    public class PrescriptionViewModel : ObservableObject
    {
        Patient patient;
        private string patientName;
        private string patientId;

        DrugController drugController = new DrugController();
        public ObservableCollection<Drug> Drugs { get; set; } = new ObservableCollection<Drug>();


        public PrescriptionViewModel(Patient patient)
        {
            this.patient = patient;
            patientName = $"Patient name: {patient.name}";
            patientId = $"Patient ID: {patient.patientId}";

            Drugs = new ObservableCollection<Drug>(drugController.GetAllDrugs());
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
        


    }
}
