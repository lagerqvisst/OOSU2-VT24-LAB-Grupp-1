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

        private UnitOfWork unitOfWork = new UnitOfWork();
        private PatientController patientController = new PatientController();

        #endregion UnitOfWork

        /// <summary>
        /// Skapar och returnerar ett nytt recept med angiven patient, datum och lista av läkemedel.
        /// Lägger även till läkemedlen i receptet och uppdaterar patientens namn och antalet läkemedel.
        /// </summary>

        #region Methods

        public Prescription CreatePrescription(int patientId, DateTime dateofPrescription, ObservableCollection<Drug> drugs)
        {
            // Skapar ett nytt recept.
            Prescription prescription = new Prescription(patientId, dateofPrescription);

            // Loopar igenom varje läkemedel och skapar en koppling till receptet.
            foreach (Drug drug in drugs)
            {
                PrescriptionDrug prescriptionDrug = new PrescriptionDrug(prescription.prescriptionId, drug.DrugId);
                prescription.PrescriptionDrugs.Add(prescriptionDrug);
            }

            // Sätter patientens namn och antalet läkemedel i receptet.
            prescription.SetPatientName(patientController.GetPatientById(patientId).name);
            prescription.SetDrugCount(drugs.Count);

            // Skapar receptet i databasen genom UnitOfWork.
            unitOfWork.CreatePrescription(prescription);

            return prescription;
        }

        /// <summary>
        /// Hämtar alla recept från databasen.
        /// </summary>
        public List<Prescription> GetAllPrescriptions()
        {
            return unitOfWork.PrescriptionRepository.Find(unitOfWork => true).ToList();
        }

        /// <summary>
        /// Hämtar receptshistoriken för en specifik patient.
        /// </summary>
        public List<Prescription> GetPatientPrescriptionHistory(int patientId)
        {
            return unitOfWork.PrescriptionRepository.Find(p => p.patientId == patientId).ToList();
        }

        /// <summary>
        /// Hämtar läkemedel baserat på receptets ID.
        /// </summary>
        public List<Drug> GetDrugsByPrescriptionId(int prescriptionId)
        {
            // Hämtar alla kopplingar mellan receptet och läkemedel.
            var prescriptionDrugs = unitOfWork.PrescriptionDrugRepository.Find(pd => pd.prescriptionId == prescriptionId).ToList();

            // Hämtar alla läkemedel baserat på de unika ID:n från kopplingarna.
            var drugIds = prescriptionDrugs.Select(pd => pd.drugId).ToList();
            return unitOfWork.DrugRepository.Find(d => drugIds.Contains(d.DrugId)).ToList();
        }
    }

    #endregion Methods

}
