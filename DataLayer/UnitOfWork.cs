using EntityLayer;
using EntityLayer.Junction;
using Microsoft.EntityFrameworkCore;
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

        public Repository<Drug> DrugRepository
        {
            get; private set;
        }

        public Repository<PrescriptionDrug> PrescriptionDrugRepository
        {
            get; private set;
        }


        public UnitOfWork()
        {
            patientMgmtContext = new PatientMgmtContext(); // Initialisera patientMgmtContext
            DiagnosisRepository = new Repository<Diagnosis>();
            PrescriptionRepository = new Repository<Prescription>();
            PatientRepository = new Repository<Patient>();
            AppointmentRepository = new Repository<Appointment>();
            DoctorRepository = new Repository<Doctor>();
            ReceptionistRepository = new Repository<Receptionist>();
            DrugRepository = new Repository<Drug>();
            PrescriptionDrugRepository = new Repository<PrescriptionDrug>();

            
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

            //Sparar ner alla objekt från databasen som listor.
            #region tempLists from the database
            var patientsFromDb = patientMgmtContext.Patients.ToList();
            var doctorsFromDb = patientMgmtContext.Doctors.ToList();
            var receptionistsFromDb = patientMgmtContext.Receptionists.ToList();
            var appointmentsFromDb = patientMgmtContext.Appointments.ToList();
            var diagnosesFromDb = patientMgmtContext.Diagnoses.ToList();
            var prescriptionsFromDb = patientMgmtContext.Prescriptions.ToList();
            var drugsFromDb = patientMgmtContext.Drugs.ToList();
            var prescriptionDrugsFromDb = patientMgmtContext.PrescriptionDrugs.ToList();
            #endregion

            //Loops för varje objekt i listorna för att lägga till dem i respektive repository.
            //Eftersom varje repository faktiskt är tom vid varje ny körning så körs denna metod varje gång programmet startas.
            //Då fylls repositories med objekt från databasen. Repositories används sedan för att kunna göra CRUD-operationer på objekten i gränssnittet
            #region for each loop to add the objects to the repositories
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
            foreach(var drug in drugsFromDb)
            {
                DrugRepository.Add(drug);
            }

            foreach (var prescriptionDrug in prescriptionDrugsFromDb)
            {
                PrescriptionDrugRepository.Add(prescriptionDrug);
            }
            #endregion

        }

        //Metoder som sparar objekt till databasen.
        //Vi sparar både i DB och repository under run-time så att ex. datagrids ska uppdateras.
        #region Create methods
        public void CreatePrescription(Prescription prescription)
        {
            PrescriptionRepository.Add(prescription);
            patientMgmtContext.Prescriptions.Add(prescription);

            foreach (var prescriptionDrug in prescription.PrescriptionDrugs)
            {
                PrescriptionDrugRepository.Add(prescriptionDrug);
                patientMgmtContext.PrescriptionDrugs.Add(prescriptionDrug);
            }

            Save();
        }



        public void CreatePatient(Patient patient)
        {
          
            // Lägg till den nya patienten i repository
            PatientRepository.Add(patient);
            patientMgmtContext.Patients.Add(patient);

            // Spara ändringar till databasen
            Save();
        }

        public void CreateDiagnosis(Diagnosis diagnosis)
        {
            // Lägg till den nya patienten i repository
            DiagnosisRepository.Add(diagnosis);
            patientMgmtContext.Diagnoses.Add(diagnosis);

            // Spara ändringar till databasen
            Save();
        }

        public void CreateAppointment(Appointment appointment)
        {
            // Lägg till den nya patienten i repository

            AppointmentRepository.Add(appointment);
            patientMgmtContext.Appointments.Add(appointment);

            // Spara ändringar till databasen
            Save();
        }

        #endregion

        //Metoder som tar bort objekt från databasen.
        #region Delete methods
        public void DeletePatient(Patient patient)
        {
            // Ta bort patienten från repository
            PatientRepository.Remove(patient);
            patientMgmtContext.Patients.Remove(patient);

            // Spara ändringar till databasen
            Save();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            // Ta bort appointment från repository
            AppointmentRepository.Remove(appointment);
            //Ta bort appointment från tabellen i databasen
            patientMgmtContext.Appointments.Remove(appointment);

            // Spara ändringar till databasen
            Save();
        }
        #endregion

        #region Update methods
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

        public void UpdateAppointmentDate(Appointment appointment, DateTime newDate)
        {
            // Hitta det befintliga Appointment-objektet med hjälp av appointmentId
            var appointmentToUpdate = patientMgmtContext.Appointments.FirstOrDefault(a => a.appointmentId == appointment.appointmentId);
            
            appointmentToUpdate.appointmentDate = newDate;
            AppointmentRepository.FirstOrDefault(a => a.appointmentId == appointment.appointmentId).appointmentDate = newDate;

            // Spara ändringar till databasen
            Save();
        }

        public void UpdateAppointmentReason(Appointment appointment, string newReason)
        {
            // Hitta det befintliga Appointment-objektet med hjälp av appointmentId
            var appointmentToUpdate = patientMgmtContext.Appointments.FirstOrDefault(a => a.appointmentId == appointment.appointmentId);

            appointmentToUpdate.appointmentReason = newReason;
            AppointmentRepository.FirstOrDefault(a => a.appointmentId == appointment.appointmentId).appointmentReason = newReason;

            // Spara ändringar till databasen
            Save();
        }

        //LÖS BUGGARNA I DENNA METOD
        public void UpdateAppointmentDoctor(Appointment appointment, Doctor newDoctor)
        {
            // Hitta det befintliga Appointment-objektet med hjälp av appointmentId
            var appointmentToUpdate = patientMgmtContext.Appointments.FirstOrDefault(a => a.appointmentId == appointment.appointmentId);

            // Hämta den nya doktorn från databasen om den inte redan är spårad
            var newDocInDb = patientMgmtContext.Doctors.FirstOrDefault(d => d.doctorID == newDoctor.doctorID);

            // Uppdatera läkaren för mötet
            appointmentToUpdate.doctorID = newDoctor.doctorID;
            appointmentToUpdate.doctorName = newDoctor.name;

            // Spara ändringar till databasen
            Save();
        }

        public void UpdateAppointmentDoctorsNote(Appointment appointment, string newNote)
        {
            // Hitta det befintliga Appointment-objektet med hjälp av appointmentId
            var appointmentToUpdate = patientMgmtContext.Appointments.FirstOrDefault(a => a.appointmentId == appointment.appointmentId);

            appointmentToUpdate.doctorsNote = newNote;
            AppointmentRepository.FirstOrDefault(a => a.appointmentId == appointment.appointmentId).doctorsNote = newNote;

            // Spara ändringar till databasen
            Save();
        }

        #endregion


        /// <summary>
        /// Dessa metoder är egentligen lite onödiga då vi kan använda repository direkt för att hämta data.
        /// Men vi ville öva på att använda LINQ i LABB2 direkt mot databasen.
        /// </summary>

        #region Search methods
        public List<Patient> GetPatientByName(string name)
        {
            //Alternativt: return patientMgmtContext.Patients.Where(patient => patient.Name == name).ToList(); - FRÅN JOHANNES MEJL 
            var result = from p in patientMgmtContext.Patients
                         where p.name.Contains(name)
                         select p;

            List<Patient> patients  = new List<Patient>();
            Patient patient;

            foreach(var patientInDb in result)
            {
                patient = new Patient(patientInDb.personalNumber, patientInDb.name, patientInDb.address, patientInDb.phonenumber, patientInDb.emailaddress);
                patients.Add(patient);
            }

            return patients;
          
        }

        public List<Patient> GetPatientByPersonalNumber(string personalNumber)
        {
            var result = from p in patientMgmtContext.Patients
                         where p.personalNumber.Contains(personalNumber)
                         select p;

            List<Patient> patients = new List<Patient>();
            Patient patient;

            foreach (var patientInDb in result)
            {
                patient = new Patient(patientInDb.personalNumber, patientInDb.name, patientInDb.address, patientInDb.phonenumber, patientInDb.emailaddress);
                patients.Add(patient);
            }

            return patients;
        }

        public List<Patient> GetPatientByAddress(string address)
        {
            var result = from p in patientMgmtContext.Patients
                         where p.address.Contains(address)
                         select p;

            List<Patient> patients = new List<Patient>();
            Patient patient;

            foreach (var patientInDb in result)
            {
                patient = new Patient(patientInDb.personalNumber, patientInDb.name, patientInDb.address, patientInDb.phonenumber, patientInDb.emailaddress);
                patients.Add(patient);
            }

            return patients;
        }   

        public List<Patient> GetPatientByPhoneNumber(string phoneNumber)
        {
            var result = from p in patientMgmtContext.Patients
                         where p.phonenumber.Contains(phoneNumber)
                         select p;

            List<Patient> patients = new List<Patient>();
            Patient patient;

            foreach (var patientInDb in result)
            {
                patient = new Patient(patientInDb.personalNumber, patientInDb.name, patientInDb.address, patientInDb.phonenumber, patientInDb.emailaddress);
                patients.Add(patient);
            }

            return patients;
        }

        public List<Patient> GetPatientsByEmailAddress(string emailAddress)
        {
            var result = from p in patientMgmtContext.Patients
                         where p.emailaddress.Contains(emailAddress)
                         select p;

            List<Patient> patients = new List<Patient>();
            Patient patient;

            foreach (var patientInDb in result)
            {
                patient = new Patient(patientInDb.personalNumber, patientInDb.name, patientInDb.address, patientInDb.phonenumber, patientInDb.emailaddress);
                patients.Add(patient);
            }

            return patients;
        }
        #endregion

        public void SeedDBDrugs()
        {
            // Hämta alla läkemedel från repository
            var allDrugs = DrugRepository.Find(drug => true); // Här används en lambda-funktion för att få alla läkemedel

            // Loopa igenom varje läkemedel och lägg till eller uppdatera i kontexten
            foreach (var drug in allDrugs)
            {
                
                patientMgmtContext.Drugs.Add(drug);
                
            }

            // Spara ändringar till databasen
            Save();
        }









    }
}