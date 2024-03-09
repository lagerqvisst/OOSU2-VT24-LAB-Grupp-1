using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer
{
    public class Seed
    {
        public static void SeedData(PatientMgmtContext patientMgmtContext)
        {

            #region Patients
            patientMgmtContext.Patients.Add(new Patient("1999-02-01-2288", "John Doe", "Doey Street 5", "0701337420", "domaster@glocalnet.com"));
            patientMgmtContext.Patients.Add(new Patient("1985-07-15-1234", "Alice Smith", "123 Main Street", "0701234567", "alice@example.com"));
            patientMgmtContext.Patients.Add(new Patient("1976-11-30-7890", "Bob Johnson", "456 Elm Street", "0709876543", "bob@example.com"));
            patientMgmtContext.Patients.Add(new Patient("1990-04-22-5678", "Emily Brown", "789 Oak Avenue", "0705556789", "emily@example.com"));
            patientMgmtContext.Patients.Add(new Patient("1982-09-08-4321", "Michael Davis", "1010 Pine Road", "0707778888", "michael@example.com"));
            patientMgmtContext.Patients.Add(new Patient("1995-12-03-8765", "Sophia Wilson", "2020 Maple Lane", "0709990000", "sophia@example.com"));
            patientMgmtContext.Patients.Add(new Patient("1978-06-18-2468", "Olivia Miller", "3030 Cedar Drive", "0702223333", "olivia@example.com"));
            patientMgmtContext.Patients.Add(new Patient("1988-01-25-1357", "Jacob Martinez", "4040 Birch Street", "0704445555", "jacob@example.com"));
            patientMgmtContext.Patients.Add(new Patient("1993-08-10-9876", "Emma Garcia", "5050 Walnut Avenue", "0706667777", "emma@example.com"));
            patientMgmtContext.Patients.Add(new Patient("1972-03-05-3698", "Liam Hernandez", "6060 Cedar Lane", "0708889999", "liam@example.com"));
            patientMgmtContext.Patients.Add(new Patient("1987-10-20-2469", "Mia Lopez", "7070 Elm Drive", "0700001111", "mia@example.com"));
            #endregion

            #region Doctors
            patientMgmtContext.Doctors.Add(new Doctor("Tom Crane", "wowdoctorimgood123", "Surgeon"));
            patientMgmtContext.Doctors.Add(new Doctor("Ella Thompson", "passcode123", "Pediatrician"));
            patientMgmtContext.Doctors.Add(new Doctor("William Clark", "password456", "Cardiologist"));
            patientMgmtContext.Doctors.Add(new Doctor("Sophie Johnson", "securepass789", "Dermatologist"));
            patientMgmtContext.Doctors.Add(new Doctor("Daniel White", "p@ssw0rd!@", "Gynecologist"));
            patientMgmtContext.Doctors.Add(new Doctor("Isabella Harris", "doctorpass123", "Neurologist"));
            patientMgmtContext.Doctors.Add(new Doctor("James Turner", "passw0rd123", "Orthopedic Surgeon"));
            patientMgmtContext.Doctors.Add(new Doctor("Ava Martin", "password!@#", "Oncologist"));
            patientMgmtContext.Doctors.Add(new Doctor("Oliver Evans", "doctorpass456", "Psychiatrist"));
            patientMgmtContext.Doctors.Add(new Doctor("Charlotte Martinez", "secure123pass", "Radiologist"));
            patientMgmtContext.Doctors.Add(new Doctor("Alexander King", "medic123", "Urologist"));
            #endregion

            #region Receptionists
            patientMgmtContext.Receptionists.Add(new Receptionist("Rebecca Smith", "receptionistpass123"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Natalie Wilson", "receptionistpass456"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Ethan Brown", "receptionistpass789"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Chloe Taylor", "receptionistpass999"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Dylan Miller", "receptionistpass111"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Grace Thomas", "receptionistpass222"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Owen Adams", "receptionistpass333"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Zoe Turner", "receptionistpass444"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Leo Scott", "receptionistpass555"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Hannah Evans", "receptionistpass666"));
            patientMgmtContext.Receptionists.Add(new Receptionist("Logan Hughes", "receptionistpass777"));
            #endregion

            patientMgmtContext.SaveChanges();
        }
    }
}
