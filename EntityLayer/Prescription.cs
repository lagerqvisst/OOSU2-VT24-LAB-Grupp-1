using EntityLayer.Junction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Prescription
    {
        public int prescriptionId { get; set; }
        public int patientId { get; set; }  // FK för Patient
        public Patient patient { get; set; }

        public string patientName { get; set; }
        public DateTime dateofPrescription { get; set; }

        public List<Drug> drugs { get; set; }

        public int drugCount { get; set; }

        public List<PrescriptionDrug> PrescriptionDrugs { get; set; } = new List<PrescriptionDrug>();



        public Prescription(int patientId,DateTime dateofPrescription)
        {
            this.patientId = patientId;
            this.patient = patient;
            this.dateofPrescription = dateofPrescription.Date;
            drugs = new List<Drug>();

             
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
