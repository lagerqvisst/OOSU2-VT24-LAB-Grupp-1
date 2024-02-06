using EntityLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork
    {
        public PatientMgmtContext patientMgmtContext;
        public Repository<Diagnosis> DiagnosisRepository
        {
            get; private set;
        }


        public Repository<Doctor> DoctorRepository
        {
            get; private set;
        }

        public Repository<Appointment> AppointmentRepository
        {
            get; private set;
        }

        public Repository<Prescription> PrescriptionRepository
        {
            get; private set;
        }

        public Repository<Receptionist> ReceptionistRepository
        {
            get; private set;
        }
        public Repository<Patient> PatientRepository
        {
            get; private set;
        }

        /// <summary>
        ///  Create a new instance.
        /// </summary>
        public UnitOfWork()
        {
            patientMgmtContext = new PatientMgmtContext(); // Initialisera patientMgmtContext

            DiagnosisRepository = new Repository<Diagnosis>();
            PrescriptionRepository = new Repository<Prescription>();
            PatientRepository = new Repository<Patient>();
            AppointmentRepository = new Repository<Appointment>();
            DoctorRepository = new Repository<Doctor>();
            ReceptionistRepository = new Repository<Receptionist>();

            //Initialize the tables if this is the first UnitOfWork.
            if (PatientRepository.IsEmpty())
            {
                Fill();
            }
        }

        /// <summary>
        ///  Save the changes made.
        /// </summary>
        public void Save()
        {
            patientMgmtContext.SaveChanges();
        }


        private void Fill()
        {

            var patientsFromDb = patientMgmtContext.Patients.ToList();
            var doctorsFromDb = patientMgmtContext.Doctors.ToList();
            var receptionistsFromDb = patientMgmtContext.Receptionists.ToList();
            var appointmentsFromDb = patientMgmtContext.Appointments.ToList();
            var diagnosesFromDb = patientMgmtContext.Diagnoses.ToList();
            var prescriptionsFromDb = patientMgmtContext.Prescriptions.ToList();

            foreach (var patient in patientsFromDb)
            {
                PatientRepository.Add(patient);
            }

            foreach (var doctor in doctorsFromDb)
            {
                DoctorRepository.Add(doctor);
            }

            foreach (var receptionist in receptionistsFromDb)
            {
                ReceptionistRepository.Add(receptionist);
            }

            foreach (var appointment in appointmentsFromDb)
            {
                AppointmentRepository.Add(appointment);
            }

            foreach (var diagnosis in diagnosesFromDb)
            {
                DiagnosisRepository.Add(diagnosis);
            }

            foreach (var prescription in prescriptionsFromDb)
            {
                PrescriptionRepository.Add(prescription);
            }

            
        }

        public void CreatePatient(Patient patient)
        {
          
            // Lägg till den nya patienten i repository
            PatientRepository.Add(patient);
            patientMgmtContext.Patients.Add(patient);

            // Spara ändringar till databasen
            Save();
        }

        public void DeletePatient(Patient patient)
        {
            // Ta bort patienten från repository
            PatientRepository.Remove(patient);
            patientMgmtContext.Patients.Remove(patient);

            // Spara ändringar till databasen
            Save();
        }

        public void UpdatePatientName(Patient patient, string newName)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            patientToUpdate.name = newName;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).name = newName;

            // Spara ändringar till databasen
            Save();
            
      
        }

        public void UpdatePatientAddress(Patient patient, string newAddress)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            patientToUpdate.address = newAddress;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).address = newAddress;

            // Spara ändringar till databasen
            Save();
        }

        public void UpdatePatientPhoneNumber(Patient patient, string newPhoneNumber)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            patientToUpdate.phonenumber = newPhoneNumber;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).phonenumber = newPhoneNumber;

            // Spara ändringar till databasen
            Save();
        }

        public void UpdatePatientEmail(Patient patient, string newEmail)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            patientToUpdate.emailaddress = newEmail;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).emailaddress = newEmail;

            // Spara ändringar till databasen
            Save();
        }

        public void UpdatePatientPersonalNumber(Patient patient, string newPersonalNumber)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            patientToUpdate.personalNumber = newPersonalNumber;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).personalNumber = newPersonalNumber;

            
            Save();
           
        }








    }
}