using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataLayer;
using EntityLayer.Junction;
using System.Collections.ObjectModel;

namespace BusinessLayer
{
    public class PrescriptionController
    {
        #region UnitOfWork
        // Skapar en instans av UnitOfWork för att kunna använda sig av metoder från UnitOfWork.
        UnitOfWork unitOfWork = new UnitOfWork();
        #endregion UnitOfWork

        // Instans av PatientController för att kunna använda sig av metoder från PatientController.
        PatientController patientController = new PatientController();

        #region Konstruktor
        //Skapar ett nytt Prescription och lägger till det i databasen. ObservableCollection används för att annars blir det konverteringsfel (exempelvis med en List <Drug> endast).
        public Prescription CreatePrescription(int patientId, DateTime dateofPrescription, ObservableCollection<Drug> drugs)
        {
            Prescription prescription = new Prescription(patientId, dateofPrescription);

            foreach (Drug drug in drugs)
            {
                PrescriptionDrug prescriptionDrug = new PrescriptionDrug(prescription.prescriptionId, drug.DrugId);
                prescription.PrescriptionDrugs.Add(prescriptionDrug);
            }

            // Använd patientId istället för att tilldela hela patientobjektet
            prescription.SetPatientName(patientController.GetPatientById(patientId).name);
            prescription.SetDrugCount(drugs.Count);

            unitOfWork.CreatePrescription(prescription);

            return prescription;
        }
        #endregion Konstruktor

        #region Prescription Lists
        //Returnera en lista med alla Prescriptions
        public List<Prescription> GetAllPrescriptions()
        {
            return unitOfWork.PrescriptionRepository.Find(unitOfWork => true).ToList(); 
        }

        //Returnera en lista med alla Prescriptions baserat på patientId
        public List<Prescription> GetPatientPrescriptionHistory(int patientId) 
        {
            return unitOfWork.PrescriptionRepository.Find(p => p.patientId == patientId).ToList();
        }

        //Returnerar en lista med Drugs baserat på PrescriptionId.
        public List<Drug> GetDrugsByPrescriptionId(int prescriptionId)
        {
            var prescriptionDrugs = unitOfWork.PrescriptionDrugRepository.Find(pd => pd.prescriptionId == prescriptionId).ToList();
            var drugIds = prescriptionDrugs.Select(pd => pd.drugId).ToList();
            return unitOfWork.DrugRepository.Find(d => drugIds.Contains(d.DrugId)).ToList();
        }
        #endregion Prescription Lists
    }
}
