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

            //patientMgmtContext.Appointments.Add(new Appointment(2, new DateTime(2022, 03, 25, 14, 30, 0), "leg injury", 1, 1));


            /*
            patientMgmtContext.Appointments.Add(new Appointment(1, 1, new DateTime(2022, 03, 25, 14, 30, 0), "reason", 1, 1));
            patientMgmtContext.Appointments.Add(new Appointment(2, 2, new DateTime(2024, 02, 10, 10, 00, 0), "Annual checkup", 2, 12));
            patientMgmtContext.Appointments.Add(new Appointment(3, 3, new DateTime(2024, 02, 11, 11, 30, 0), "Chest pain evaluation", 3, 13));
            patientMgmtContext.Appointments.Add(new Appointment(4, 4, new DateTime(2024, 02, 12, 15, 45, 0), "Skin rash treatment", 4, 14));
            patientMgmtContext.Appointments.Add(new Appointment(5, 5, new DateTime(2024, 02, 13, 09, 15, 0), "Prenatal checkup", 5, 15));
            patientMgmtContext.Appointments.Add(new Appointment(6, 6, new DateTime(2024, 02, 14, 12, 00, 0), "Headache consultation", 6, 16));
            patientMgmtContext.Appointments.Add(new Appointment(7, 7, new DateTime(2024, 02, 15, 14, 20, 0), "Knee injury assessment", 7, 17));
            patientMgmtContext.Appointments.Add(new Appointment(8, 8, new DateTime(2024, 02, 16, 16, 40, 0), "Chemotherapy session", 8, 18));
            patientMgmtContext.Appointments.Add(new Appointment(9, 9, new DateTime(2024, 02, 17, 08, 45, 0), "Psychological evaluation", 9, 19));
            patientMgmtContext.Appointments.Add(new Appointment(10, 10, new DateTime(2024, 02, 18, 13, 10, 0), "X-ray examination", 10, 20));
            patientMgmtContext.Appointments.Add(new Appointment(11, 11, new DateTime(2024, 02, 19, 15, 30, 0), "Prostate screening", 11, 21));



            patientMgmtContext.Diagnoses.Add(new Diagnosis(1, 1, "Broken leg", new DateTime(2021, 10, 15, 10, 0, 0), "Rest leg 6 months"));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(2, 2, "Hypertension", new DateTime(2024, 01, 05, 09, 15, 0), "Prescribed medication and lifestyle changes."));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(3, 3, "Seasonal allergies", new DateTime(2024, 01, 10, 11, 30, 0), "Recommended antihistamines."));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(4, 4, "Gastritis", new DateTime(2024, 01, 20, 14, 45, 0), "Prescribed proton pump inhibitors and dietary changes."));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(5, 5, "Migraine", new DateTime(2024, 02, 01, 10, 15, 0), "Prescribed pain relief medication and advised stress management."));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(6, 6, "Sprained ankle", new DateTime(2024, 02, 05, 12, 00, 0), "RICE protocol: Rest, Ice, Compression, Elevation."));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(7, 7, "Bronchitis", new DateTime(2024, 02, 10, 14, 20, 0), "Prescribed antibiotics and advised plenty of rest."));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(8, 8, "Breast cancer", new DateTime(2024, 02, 15, 16, 40, 0), "Scheduled for surgery and chemotherapy."));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(9, 9, "Anxiety disorder", new DateTime(2024, 02, 20, 08, 45, 0), "Referred to therapy and prescribed anxiolytics."));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(10, 10, "Fractured rib", new DateTime(2024, 02, 25, 13, 10, 0), "Advised pain management and restricted physical activity."));
            patientMgmtContext.Diagnoses.Add(new Diagnosis(11, 11, "Urinary tract infection", new DateTime(2024, 03, 01, 15, 30, 0), "Prescribed antibiotics and advised increased fluid intake."));



            patientMgmtContext.Prescriptions.Add(new Prescription(1, 1, "drug name", "dose", new DateTime(2021, 10, 15, 10, 0, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(2, 2, "Lisinopril", "10 mg once daily", new DateTime(2024, 01, 05, 09, 15, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(3, 3, "Flonase", "2 sprays in each nostril once daily", new DateTime(2024, 01, 10, 11, 30, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(4, 4, "Omeprazole", "20 mg once daily before breakfast", new DateTime(2024, 01, 20, 14, 45, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(5, 5, "Sumatriptan", "100 mg at onset of migraine", new DateTime(2024, 02, 01, 10, 15, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(6, 6, "Ibuprofen", "400 mg every 4-6 hours as needed for pain", new DateTime(2024, 02, 05, 12, 00, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(7, 7, "Azithromycin", "500 mg once daily for 5 days", new DateTime(2024, 02, 10, 14, 20, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(8, 8, "Tamoxifen", "20 mg once daily for 5 years", new DateTime(2024, 02, 15, 16, 40, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(9, 9, "Alprazolam", "0.5 mg twice daily as needed", new DateTime(2024, 02, 20, 08, 45, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(10, 10, "Acetaminophen", "650 mg every 6 hours as needed for pain", new DateTime(2024, 02, 25, 13, 10, 0)));
            patientMgmtContext.Prescriptions.Add(new Prescription(11, 11, "Ciprofloxacin", "500 mg twice daily for 7 days", new DateTime(2024, 03, 01, 15, 30, 0)));

            */



            patientMgmtContext.SaveChanges();
        }
    }
}
