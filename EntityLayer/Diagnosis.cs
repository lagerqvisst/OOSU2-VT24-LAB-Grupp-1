using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Diagnosis
    {

        #region Diagnosis properties
        public int diagnosisId { get; set; } // Primärnyckel för diagnosen.
        public int patientId { get; set; }  // Främmande nyckel för att koppla till en patient.
        public Patient patient { get; set; } // Navigationsegenskap för att referera till patienten.

        public string diagnosisDescription { get; set; } // Beskrivning av diagnosen.
        public DateTime dateOfDiagnosis { get; set; } // Datum då diagnosen ställdes.
        public string treatmentSuggestion { get; set; } // Förslag på behandling för diagnosen.
        #endregion Diagnosis properties

        #region Constructor
        public Diagnosis(int patientId, string diagnosisDescription, DateTime dateOfDiagnosis, string treatmentSuggestion)
        {
            
            this.patientId = patientId;
            this.patient = patient;
            this.diagnosisDescription = diagnosisDescription;
            this.dateOfDiagnosis = dateOfDiagnosis.Date;
            this.treatmentSuggestion = treatmentSuggestion;
        }
        #endregion Constructor
    }
}
