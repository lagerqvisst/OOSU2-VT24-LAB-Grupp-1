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
        #region Context
        public PatientMgmtContext patientMgmtContext;
        #endregion
        #region Repositories
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
        #endregion

        #region Konstruktor 
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

            
          
            
            // Om det inte finns några patienter i databasen så fylls den med exempeldata.
            if (PatientRepository.IsEmpty())
            {
                Fill();
            }
            
           
        }
        #endregion

        
        //Spara alla ändringar till databasen.
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
            #region för varje loop läggs objekt till i respektive repository
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
            // Lägg till den nya prescription i repository
            PrescriptionRepository.Add(prescription);
            //Lägg till den nya prescription i tabellen i databasen.
            patientMgmtContext.Prescriptions.Add(prescription);

           //Iterera över alla PrescriptionDrugs i prescription och lägg till dem i PrescriptionDrugRepository och i tabellen i databasen.
            foreach (var prescriptionDrug in prescription.PrescriptionDrugs)
            {
                PrescriptionDrugRepository.Add(prescriptionDrug);
                patientMgmtContext.PrescriptionDrugs.Add(prescriptionDrug);
            }
            //Spara ändringar till databasen
            Save();
        }


        //Skapar en ny patient
        public void CreatePatient(Patient patient)
        {
          
            // Lägg till den nya patienten i repository
            PatientRepository.Add(patient);
            //Lägg till den nya patienten i tabellen i databasen.
            patientMgmtContext.Patients.Add(patient);

            // Spara ändringar till databasen
            Save();
        }
        //Skapar en ny Diagnosis
        public void CreateDiagnosis(Diagnosis diagnosis)
        {
            // Lägg till den nya Diagnosis i repository
            DiagnosisRepository.Add(diagnosis);
            //Lägg till den nya Diagnosis i tabellen i databasen.
            patientMgmtContext.Diagnoses.Add(diagnosis);

            // Spara ändringar till databasen
            Save();
        }
        //Skapar en ny Appointment
        public void CreateAppointment(Appointment appointment)
        {
            // Lägg till den nya appointmenten i repository
            AppointmentRepository.Add(appointment);
            //Lägg till den nya appointmenten i tabellen i databasen.
            patientMgmtContext.Appointments.Add(appointment);

            // Spara ändringar till databasen
            Save();
        }

        #endregion

        //Metoder som tar bort objekt från databasen.
        #region Delete methods

        //Tar bort en specifik patient från databasen.
        public void DeletePatient(Patient patient)
        {
            // Ta bort patienten från repository
            PatientRepository.Remove(patient);
            //Ta bort patienten från tabellen i databasen
            patientMgmtContext.Patients.Remove(patient);

            // Spara ändringar till databasen
            Save();
        }
        //Tar bort en specifik appointment från databasen.
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

        //Metoder som uppdaterar objekt i databasen.
        #region Update methods

        //Uppdaterar en specifik patient med nytt namn.
        public void UpdatePatientName(Patient patient, string newName)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            //Sätt det gamla namnet till det nya.
            patientToUpdate.name = newName;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).name = newName;

            // Spara ändringar till databasen
            Save();
            
      
        }

        //Uppdaterar en specifik patient med ny adress.
        public void UpdatePatientAddress(Patient patient, string newAddress)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            //Sätt den gamla adressen till den nya.
            patientToUpdate.address = newAddress;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).address = newAddress;

            // Spara ändringar till databasen
            Save();
        }

        //Uppdaterar en specifik patient med nytt telefonnummer.
        public void UpdatePatientPhoneNumber(Patient patient, string newPhoneNumber)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            //Sätt det gamla telefonnumret till det nya.
            patientToUpdate.phonenumber = newPhoneNumber;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).phonenumber = newPhoneNumber;

            // Spara ändringar till databasen
            Save();
        }

        //Uppdaterar en specifik patient med ny email.
        public void UpdatePatientEmail(Patient patient, string newEmail)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            //Sätt det gamla email till det nya.
            patientToUpdate.emailaddress = newEmail;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).emailaddress = newEmail;

            // Spara ändringar till databasen
            Save();
        }

        //Uppdaterar en specifik patient med nytt personnummer.
        public void UpdatePatientPersonalNumber(Patient patient, string newPersonalNumber)
        {
            // Hitta det befintliga Patient-objektet med hjälp av patientId
            var patientToUpdate = patientMgmtContext.Patients.FirstOrDefault(p => p.patientId == patient.patientId);

            //Sätt det gamla personnumret till det nya.
            patientToUpdate.personalNumber = newPersonalNumber;
            PatientRepository.FirstOrDefault(p => p.patientId == patient.patientId).personalNumber = newPersonalNumber;

            
            Save();
           
        }
        //Uppdaterar ett specifikt appointment med ett nytt datum.
        public void UpdateAppointmentDate(Appointment appointment, DateTime newDate)
        {
            // Hitta det befintliga Appointment-objektet med hjälp av appointmentId
            var appointmentToUpdate = patientMgmtContext.Appointments.FirstOrDefault(a => a.appointmentId == appointment.appointmentId);
            
            //Sätt det gamla till det nya datumet.
            appointmentToUpdate.appointmentDate = newDate;
            AppointmentRepository.FirstOrDefault(a => a.appointmentId == appointment.appointmentId).appointmentDate = newDate;

            // Spara ändringar till databasen
            Save();
        }
        //Uppdaterar ett specifikt appointment med ny reason.
        public void UpdateAppointmentReason(Appointment appointment, string newReason)
        {
            // Hitta det befintliga Appointment-objektet med hjälp av appointmentId
            var appointmentToUpdate = patientMgmtContext.Appointments.FirstOrDefault(a => a.appointmentId == appointment.appointmentId);

            //Sätter den gamla reason till den nya
            appointmentToUpdate.appointmentReason = newReason;
            AppointmentRepository.FirstOrDefault(a => a.appointmentId == appointment.appointmentId).appointmentReason = newReason;

            // Spara ändringar till databasen
            Save();
        }

        //Uppdaterar specifik appointment med ny doctor.
        public void UpdateAppointmentDoctor(Appointment appointment, Doctor newDoctor)
        {
            // Hitta det befintliga Appointment-objektet med hjälp av appointmentId
            var appointmentToUpdate = patientMgmtContext.Appointments.FirstOrDefault(a => a.appointmentId == appointment.appointmentId);

            // Hämta den nya doktorn från databasen om den inte redan är spårad
            var newDocInDb = patientMgmtContext.Doctors.FirstOrDefault(d => d.doctorID == newDoctor.doctorID);

            // Uppdatera läkaren för mötet
            appointmentToUpdate.doctorID = newDoctor.doctorID;
            appointmentToUpdate.doctorName = newDoctor.name;

            AppointmentRepository.FirstOrDefault(a => a.appointmentId == appointment.appointmentId).doctorID = newDoctor.doctorID;
            AppointmentRepository.FirstOrDefault(a => a.appointmentId == appointment.appointmentId).doctorName = newDoctor.name;

            // Spara ändringar till databasen
            Save();
        }

        //Uppdaterar specifik appointment med ny doctorsnote.
        public void UpdateAppointmentDoctorsNote(Appointment appointment, string newNote)
        {
            // Hitta det befintliga Appointment-objektet med hjälp av appointmentId
            var appointmentToUpdate = patientMgmtContext.Appointments.FirstOrDefault(a => a.appointmentId == appointment.appointmentId);

            //Sätter gamla doctorsnote till det nya.
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

        //Hämtar alla patienter från databasen baserat på namn.
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
                patient.patientId = patientInDb.patientId;
                patients.Add(patient);
            }

            return patients;
          
        }

        //Hämtar alla patienter från databasen baserat på personnummer.
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
                patient.patientId = patientInDb.patientId;
                patients.Add(patient);
            }

            return patients;
        }

        //Hämtar alla patienter från databasen baserat på adress.
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
                patient.patientId = patientInDb.patientId;
                patients.Add(patient);
            }

            return patients;
        }   

        //Hämtar alla patienter från databasen baserat på telefonnummer.
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
                patient.patientId = patientInDb.patientId;
                patients.Add(patient);
            }

            return patients;
        }

        //Hämtar alla patienter från databasen baserat på email.
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
                patient.patientId = patientInDb.patientId;
                patients.Add(patient);
            }

            return patients;
        }
        #endregion

        //Hämtar alla drugs i databasen.
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