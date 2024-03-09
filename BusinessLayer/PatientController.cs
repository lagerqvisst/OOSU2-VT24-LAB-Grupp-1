﻿using System;
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
        UnitOfWork unitOfWork = new UnitOfWork();

        public Patient CreateNewPatient(string personalNumber, string name, string address, string phonenumber, string emailaddress)
        {
            Patient patient = new Patient(personalNumber, name, address, phonenumber, emailaddress);
            unitOfWork.CreatePatient(patient);
            return patient;
        }
        public Patient GetPatientById(int id)
        {
            return unitOfWork.PatientRepository.FirstOrDefault(p => p.patientId == id);
        }

        public Patient PatientToRemove(Patient patient)
        {
            unitOfWork.DeletePatient(patient);
            return patient;
        }

        #region List metoder för att hämta patienter beroende på olika kriterier

        public List<Patient> GetAllPatients()
        {
            return unitOfWork.PatientRepository.Find(p => true).ToList();

        }

        public List<Patient> GetPatientsByName(string name)
        {
            return unitOfWork.GetPatientByName(name);
        }

        public List<Patient> GetPatientsByPersonalNum(string personalNumber)
        {
            
            return unitOfWork.GetPatientByPersonalNumber(personalNumber);
        }

        public List<Patient> GetPatientsByAddress(string address)
        {
            return unitOfWork.GetPatientByAddress(address);
        }

        public List<Patient> GetPatientsByEmailAddress(string email)
        {
            return unitOfWork.GetPatientsByEmailAddress(email);
        }

        public List<Patient> GetPatientsByPhoneNumber(string phoneNumber)
        {
            return unitOfWork.GetPatientByPhoneNumber(phoneNumber);
        }

        #endregion

        //Update methods - användes i LABB2 för att uppfylla kravet full CRUD
        #region Update methods
        public void UpdatePatientName(Patient patient , string name)
        {

           unitOfWork.UpdatePatientName(patient, name);
        }

        public void UpdatePatientAddress(Patient patient, string address)
        {
            unitOfWork.UpdatePatientAddress(patient, address);
        }

        public void UpdatePatientPhoneNumber(Patient patient, string phoneNumber)
        {
            unitOfWork.UpdatePatientPhoneNumber(patient, phoneNumber);
        }

        public void UpdatePatientEmail(Patient patient, string email)
        {
            unitOfWork.UpdatePatientEmail(patient, email);
        }

        public void UpdatePatientPersonalNumber(Patient patient, string personalNumber)
        {
            unitOfWork.UpdatePatientPersonalNumber(patient, personalNumber);
        }

        #endregion

    }
}
