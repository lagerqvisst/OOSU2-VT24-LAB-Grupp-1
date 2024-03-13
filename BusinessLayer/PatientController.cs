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
        // Skapar en instans av UnitOfWork för att kunna använda sig av metoder från UnitOfWork.
        UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        #region CRUD Operations

        //Skapa / Lägg till patient
        public Patient CreateNewPatient(string personalNumber, string name, string address, string phonenumber, string emailaddress)
        {
            Patient patient = new Patient(personalNumber, name, address, phonenumber, emailaddress);
            unitOfWork.CreatePatient(patient);
            return patient;
        }

        //Hämta patient baserat på patientId
        public Patient GetPatientById(int id)
        {
            return unitOfWork.PatientRepository.FirstOrDefault(p => p.patientId == id);
        }

        // Ta bort patient
        public Patient PatientToRemove(Patient patient)
        {
            unitOfWork.DeletePatient(patient);
            return patient;
        }

        #endregion CRUD Operations

        #region List metoder för att hämta patienter beroende på olika kriterier

        //Returnera en lista med alla patients
        public List<Patient> GetAllPatients()
        {
            return unitOfWork.PatientRepository.Find(p => true).ToList();
        }

        //Returnera en lista med patients baserat på namn
        public List<Patient> GetPatientsByName(string name)
        {
            return unitOfWork.GetPatientByName(name);
        }

        //Returnera en lista med patients baserat på personnummer
        public List<Patient> GetPatientsByPersonalNum(string personalNumber)
        {
            return unitOfWork.GetPatientByPersonalNumber(personalNumber);
        }

        // Returnera en lista med patients baserat på adress
        public List<Patient> GetPatientsByAddress(string address)
        {
            return unitOfWork.GetPatientByAddress(address);
        }

        // Returnera en lista med patients baserat på email
        public List<Patient> GetPatientsByEmailAddress(string email)
        {
            return unitOfWork.GetPatientsByEmailAddress(email);
        }
         // Returnera en lista med patients baserat på telefonnummer
        public List<Patient> GetPatientsByPhoneNumber(string phoneNumber)
        {
            return unitOfWork.GetPatientByPhoneNumber(phoneNumber);
        }

        #endregion

        //Update methods - användes i LABB2 för att uppfylla kravet full CRUD
        #region Update methods

        //Uppdaterar en särskild patient med ett nytt namn.
        public void UpdatePatientName(Patient patient , string name)
        {
           unitOfWork.UpdatePatientName(patient, name);
        }

        // Uppdaterar en särskild patient med en ny adress.
        public void UpdatePatientAddress(Patient patient, string address)
        {
            unitOfWork.UpdatePatientAddress(patient, address);
        }

        //Uppdaterar en särskild patient med ett nytt telefonnummer.
        public void UpdatePatientPhoneNumber(Patient patient, string phoneNumber)
        {
            unitOfWork.UpdatePatientPhoneNumber(patient, phoneNumber);
        }

        //Uppdaterar en särskild patient med en ny email.
        public void UpdatePatientEmail(Patient patient, string email)
        {
            unitOfWork.UpdatePatientEmail(patient, email);
        }

        //Uppdaterar en särskild patient med ett nytt personnummer.
        public void UpdatePatientPersonalNumber(Patient patient, string personalNumber)
        {
            unitOfWork.UpdatePatientPersonalNumber(patient, personalNumber);
        }
        #endregion
    }
}
