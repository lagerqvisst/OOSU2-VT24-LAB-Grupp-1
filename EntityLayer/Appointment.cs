using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EntityLayer
{
    public class Appointment
    {
        public int appointmentId { get; set; }  //PK
        public int patientId { get; set; } //FK
        public string patientName { get; set; }

        public Patient patient { get; set; }
        public DateTime appointmentDate { get; set; }
        public string appointmentReason { get; set; }

        public string ? doctorsNote { get; set; } //Kan vara null om läkaren inte har skrivit något samt att när en receptionist skapar en tid så är det null.

        public Doctor doctor { get; set; }
        public int doctorID { get; set; } //FK
        public string doctorName { get; set; }

        public Receptionist receptionist { get; set; }
        public int? receptionistId { get; set; } //FK
        public string? receptionistName { get; set; }


        //Constructorn är overloaded för att kunna skapa en appointment med eller utan receptionistId.
        //Overloadingen togs med i LABB3 då ett krav var att en läkare skulle kunna skapa en ny tid. 
        //Tidigare i LABB2 var det endaste receptionisten som kunde skapa en tid och då behövdes inte överlagringen.
        public Appointment(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID, int? receptionistId)
        {
            this.patientId = patientId;
            this.appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentDate.Hour, appointmentDate.Minute, 0);
            this.appointmentReason = appointmentReason;
            this.doctorID = doctorID;
            this.receptionistId = receptionistId;
            //doctorsNote = "N/A";
        }

        public Appointment(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID)
        {
            this.patientId = patientId;
            this.appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentDate.Hour, appointmentDate.Minute, 0);
            this.appointmentReason = appointmentReason;
            this.doctorID = doctorID;
            //doctorsNote = "N/A";
        }

        /// <summary>
        /// Märk att attributen för doktor och receptionist INTE är kopplade till objekt utan lösa strängar.
        /// Därav skapades denna lösning som en workaround för att kunna visa namnen på doktor och receptionist i WPF.
        /// Se AppointmentController för hur detta används.
        /// </summary>


        public void SetNames(Patient patient, Doctor doctor, Receptionist receptionist)
        {
            patientName = patient.name;
            doctorName = doctor.name;  
            receptionistName = receptionist.name;
           
          
        }

        //Overloaded SetNames-metod för att kunna sätta namn på patient och doktor utan att behöva skicka med receptionist.
        public void SetNames(Patient patient, Doctor doctor)
        {
            patientName = patient.name;
            doctorName = doctor.name;


 

        }



    }


}
