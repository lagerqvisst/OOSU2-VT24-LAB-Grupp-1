using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class PatientController
    {
        #region UnitOfWork
        private UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        /// <summary>
        /// Metoder i PatientController används för att skapa en ny patient,
        /// hämta en befintlig patient baserat på patientens ID och markera en patient för borttagning
        /// genom att använda UnitOfWork för att interagera med databasen.
        /// </summary>

        #region Methods
        /// <summary>
        /// Skapar och returnerar en ny patient med angiven personnummer, namn, adress, telefonnummer och e-postadress.
        /// Lägger även till patienten i databasen.
        /// </summary>
        public Patient CreateNewPatient(string personalNumber, string name, string address, string phonenumber, string emailaddress)
        {
            Patient patient = new Patient(personalNumber, name, address, phonenumber, emailaddress);
            unitOfWork.CreatePatient(patient);
            return patient;
        }

        /// <summary>
        /// Hämtar en patient baserat på patientens ID.
        /// </summary>
        public Patient GetPatientById(int id)
        {
            return unitOfWork.PatientRepository.FirstOrDefault(p => p.patientId == id);
        }

        /// <summary>
        /// Markera en patient för borttagning och returnera den markerade patienten.
        /// </summary>
        public Patient PatientToRemove(Patient patient)
        {
            unitOfWork.DeletePatient(patient);
            return patient;
        }
        #endregion Methods
    }
}
