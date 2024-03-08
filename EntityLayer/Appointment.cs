using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EntityLayer
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public int patientId { get; set; } //FK
        public string patientName { get; set; }

        public Patient patient { get; set; }
        public DateTime appointmentDate { get; set; }
        public string appointmentReason { get; set; }

        public string ? doctorsNote { get; set; }

        public Doctor doctor { get; set; }
        public int doctorID { get; set; } //FK
        public string doctorName { get; set; }

        public Receptionist receptionist { get; set; }
        public int? receptionistId { get; set; } //FK
        public string? receptionistName { get; set; }

        public Appointment(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID, int? receptionistId)
        {
            this.patientId = patientId;
            //this.appointmentDate = appointmentDate.Date;
            this.appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentDate.Hour, appointmentDate.Minute, 0);
            this.appointmentReason = appointmentReason;
            this.doctorID = doctorID;
            this.receptionistId = receptionistId;
            doctorsNote = "N/A";
        }

        public Appointment(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID)
        {
            this.patientId = patientId;
            //this.appointmentDate = appointmentDate.Date;
            this.appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentDate.Hour, appointmentDate.Minute, 0);
            this.appointmentReason = appointmentReason;
            this.doctorID = doctorID;
            doctorsNote = "N/A";
        }



        public void SetNames(Patient patient, Doctor doctor, Receptionist receptionist)
        {
            patientName = patient.name;
            doctorName = doctor.name;

            
           receptionistName = receptionist.name;
           
          
        }
        public void SetNames(Patient patient, Doctor doctor)
        {
            patientName = patient.name;
            doctorName = doctor.name;


            


        }



    }


}
