using EntityLayer.Junction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Prescription
    {
        public int prescriptionId { get; set; }
        public int patientId { get; set; }  // FK för Patient

        public string patientName { get; set; }
        public DateTime dateofPrescription { get; set; }

        public ObservableCollection<Drug> drugs { get; set; } = new ObservableCollection<Drug>();

        public int drugCount { get; set; }

        public List<PrescriptionDrug> PrescriptionDrugs { get; set; } = new List<PrescriptionDrug>();



        public Prescription(int patientId,DateTime dateofPrescription)
        {
            this.patientId = patientId;
            this.dateofPrescription = dateofPrescription.Date;
            drugs = new ObservableCollection<Drug>();
            PrescriptionDrugs = new List<PrescriptionDrug>();
            patientName = "";


        }
        public void SetPatientName(string patientName)
        {
            this.patientName = patientName;
        }
        public void SetDrugCount(int drugCount)
        {
            this.drugCount = drugCount;
        }
  

    }
}
