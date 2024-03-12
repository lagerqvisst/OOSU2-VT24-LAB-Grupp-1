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
        UnitOfWork unitOfWork = new UnitOfWork();
        PatientController patientController = new PatientController();

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

        public List<Prescription> GetAllPrescriptions()
        {
            return unitOfWork.PrescriptionRepository.Find(unitOfWork => true).ToList(); 
        }
        public List<Prescription> GetPatientPrescriptionHistory(int patientId) 
        {
            return unitOfWork.PrescriptionRepository.Find(p => p.patientId == patientId).ToList();
        }
        public List<Drug> GetDrugsByPrescriptionId(int prescriptionId)
        {
            var prescriptionDrugs = unitOfWork.PrescriptionDrugRepository.Find(pd => pd.prescriptionId == prescriptionId).ToList();
            var drugIds = prescriptionDrugs.Select(pd => pd.drugId).ToList();
            return unitOfWork.DrugRepository.Find(d => drugIds.Contains(d.DrugId)).ToList();
        }


    }
}
