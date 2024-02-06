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
        public int patientId { get; set; }
        public Patient patient { get; set; }
        public DateTime appointmentDate { get; set; }
        public string appointmentReason { get; set; }
        public int responsibleDoctorId { get; set; }
        public Doctor responsibleDoctor { get; set; }
        public int responsibleReceptionistId { get; set; }
        public Receptionist responsibleReceptionist { get; set; }

        public Appointment(int patientId, DateTime appointmentDate, string appointmentReason, int responsibleDoctorId, int responsibleReceptionistId)
        {
            this.patientId = patientId;
            this.appointmentDate = appointmentDate.Date;
            this.appointmentReason = appointmentReason;
            this.responsibleDoctorId = responsibleDoctorId;
            this.responsibleReceptionistId = responsibleReceptionistId;
        }
    }


}
