using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Diagnosis
    {
        public int diagnosisId { get; set; } // PK
        public int patientId { get; set; }  // FK för Patient
        public Patient patient { get; set; }
        public string diagnosisDescription { get; set; }
        public DateTime dateOfDiagnosis { get; set; }
        public string treatmentSuggestion { get; set; }

        public Diagnosis(int patientId, string diagnosisDescription, DateTime dateOfDiagnosis, string treatmentSuggestion)
        {
            this.patientId = patientId;
            this.patient = patient;
            this.diagnosisDescription = diagnosisDescription;
            this.dateOfDiagnosis = dateOfDiagnosis.Date;
            this.treatmentSuggestion = treatmentSuggestion;
        }
    }
}
