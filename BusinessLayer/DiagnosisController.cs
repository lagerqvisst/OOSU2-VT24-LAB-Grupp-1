using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class DiagnosisController
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public Diagnosis AddDiagnosis(int patientId, string diagnosisDescription, DateTime dateOfDiagnosis, string treatmentSuggestion)
        {
            Diagnosis diagnosis = new Diagnosis(patientId, diagnosisDescription, dateOfDiagnosis, treatmentSuggestion);
            unitOfWork.CreateDiagnosis(diagnosis);
            return diagnosis;
        }

        public List<Diagnosis> PatientDiagnosis(Patient patient)
        {
            return unitOfWork.DiagnosisRepository.Find(d => d.patientId == patient.patientId).ToList(); 
        }
    }
}
