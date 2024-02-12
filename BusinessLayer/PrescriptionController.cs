using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataLayer;
using EntityLayer.Junction;

namespace BusinessLayer
{
    public class PrescriptionController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        PatientController patientController = new PatientController();  

        public void CreatePrescription(int patientId, DateTime dateofPrescription, List<Drug> drugs)
        {
            Prescription prescription = new Prescription(patientId, dateofPrescription);

            foreach(Drug drug in drugs)
            {
                PrescriptionDrug prescriptionDrug = new PrescriptionDrug(prescription.prescriptionId, drug.DrugId);
                prescription.PrescriptionDrugs.Add(prescriptionDrug);
            }

            prescription.SetDrugCount(drugs.Count);
            prescription.SetPatientName(patientController.GetPatientById(patientId).name);
            unitOfWork.CreatePrescription(prescription);
            
        }
        public List<Prescription> GetAllPrescriptions()
        {
            return unitOfWork.PrescriptionRepository.Find(unitOfWork => true).ToList(); 
        }
    }
}
