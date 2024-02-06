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
        public string drugName { get; set; }
        public string dose { get; set; }
        public DateTime dateofPrescription { get; set; }

        public Prescription(int patientId, string drugName, string dose, DateTime dateofPrescription)
        {
            this.patientId = patientId;
            this.patient = patient;
            this.drugName = drugName;
            this.dose = dose;
            this.dateofPrescription = dateofPrescription.Date;
        }
    }
}
