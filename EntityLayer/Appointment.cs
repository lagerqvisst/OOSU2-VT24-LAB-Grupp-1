using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EntityLayer
{
    public class Appointment

        #region Appointment properties
    {
        public int appointmentId { get; set; }  //Primärnyckel för Appointment
        public int patientId { get; set; } //Främmande nyckel för att koppla till en patient
        public string patientName { get; set; } //Får patients namn genom att sätta det i SetNames-metoden

        public Patient patient { get; set; } //Är ett objekt av klassen Patient
        public DateTime appointmentDate { get; set; } //Datum och tid för Appointment
        public string appointmentReason { get; set; } //Anledning för Appointment

        public string ? doctorsNote { get; set; } //Kan vara null om läkaren inte har skrivit något samt att när en receptionist skapar en tid så är det null.

        public Doctor doctor { get; set; } //Är ett objekt av klassen Doctor
        public int doctorID { get; set; } //Främmande nyckel för att koppla till en doktor
        public string doctorName { get; set; } //Får doktorns namn genom att sätta det i SetNames-metoden

        public Receptionist receptionist { get; set; } //Är ett objekt av klassen Receptionist
        public int? receptionistId { get; set; } //Främmande nyckel för att koppla till en receptionist (Kan vara null)
        public string? receptionistName { get; set; } //Får receptionistens namn genom att sätta det i SetNames-metoden (Kan vara null)

        #endregion Appointment properties

        #region Constructors

        //Constructorn är overloaded för att kunna skapa en appointment med eller utan receptionistId.
        //Overloadingen togs med i LABB3 då ett krav var att en läkare skulle kunna skapa en ny tid. 
        //Tidigare i LAB2 var det endaste receptionisten som kunde skapa en tid och då behövdes inte överlagringen.

        //Med receptionist (kan ändå vara NULL dock)
        public Appointment(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID, int? receptionistId)
        {
            this.patientId = patientId;
            this.appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentDate.Hour, appointmentDate.Minute, 0);
            this.appointmentReason = appointmentReason;
            this.doctorID = doctorID;
            this.receptionistId = receptionistId;
        }

        //Utan receptionist
        public Appointment(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID)
        {
            this.patientId = patientId;
            this.appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentDate.Hour, appointmentDate.Minute, 0);
            this.appointmentReason = appointmentReason;
            this.doctorID = doctorID;
        }

        #endregion Constructors

        #region Methods

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

        #endregion Methods
    }
}
