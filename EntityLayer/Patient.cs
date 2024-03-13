using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Patient

    #region Patient properties
    {
        public int patientId { get; set; } // Primärnyckel för patienten.
        public string personalNumber { get; set; } // Personnummer för patienten.
        public string name { get; set; } // Namn på patienten.
        public string address { get; set; } // Adress för patienten.
        public string phonenumber { get; set; } // Telefonnummer för patienten.
        public string emailaddress { get; set; } // E-postadress för patienten.

        #endregion Patient properties

        #region Listor
        public List<Diagnosis> patientDiagnosis { get; set; } // Lista för patientens diagnoser.
        public List<Appointment> patientAppointments { get; set; } // Lista för patientens bokade tider.
        public List<Prescription> patientPrescriptions { get; set; } // Lista för patientens recept.
        #endregion Listor

        public Patient(string personalNumber, string name, string address, string phonenumber, string emailaddress)

        #region Initialisering och listhantering
        {
            this.personalNumber = personalNumber;
            this.name = name;
            this.address = address;
            this.phonenumber = phonenumber;
            this.emailaddress = emailaddress;

            // Listor för att hålla reda på patientens diagnoser, recept och bokade tider
            patientDiagnosis = new List<Diagnosis>();
            patientAppointments = new List<Appointment>();
            patientPrescriptions = new List<Prescription>();
        }


        #endregion Initialisering och listhantering
    }
}
