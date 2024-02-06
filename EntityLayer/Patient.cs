using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Patient
    {
        public int patientId { get; set; }
        public string personalNumber { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public string emailaddress { get; set; }
        public List<Diagnosis> patientDiagnosis { get; set; }
        public List<Appointment> patientAppointments { get; set; }
        public List<Prescription> patientPrescriptions { get; set; }

        public Patient(string personalNumber, string name, string address, string phonenumber, string emailaddress)
        {
            this.personalNumber = personalNumber;
            this.name = name;
            this.address = address;
            this.phonenumber = phonenumber;
            this.emailaddress = emailaddress;
            patientDiagnosis = new List<Diagnosis>();
            patientAppointments = new List<Appointment>();
            patientPrescriptions = new List<Prescription>();
        }
    }
}