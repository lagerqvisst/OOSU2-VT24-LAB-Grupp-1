using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;    
using EntityLayer;

namespace BusinessLayer
{
    public class AppointmentController
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public Appointment CreateNewAppointment(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID, int receptionistId)
        {
            Appointment appointment = new Appointment(patientId, appointmentDate, appointmentReason, doctorID, receptionistId);

            appointment.SetNames(unitOfWork.PatientRepository.FirstOrDefault(p => p.patientId == patientId),
                                unitOfWork.DoctorRepository.FirstOrDefault(d => d.doctorID == doctorID),
                                unitOfWork.ReceptionistRepository.FirstOrDefault(r => r.receptionistId == receptionistId));
            

            unitOfWork.CreateAppointment(appointment);
            return appointment;
        }

        public List<Appointment> GetAllAppointments()
        {
            return unitOfWork.AppointmentRepository.Find(a => true).ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return unitOfWork.AppointmentRepository.FirstOrDefault(a => a.appointmentId == id);
        }

        public Appointment AppointmentToDelete(Appointment appointment)
        {
            unitOfWork.DeleteAppointment(appointment);
            return appointment;
        }

        public void UpdateAppointmentDate(Appointment appointment, DateTime newDate)
        {
            unitOfWork.UpdateAppointmentDate(appointment, newDate);
        }

        public void UpdateAppointmentReason(Appointment appointment, string newReason)
        {
            unitOfWork.UpdateAppointmentReason(appointment, newReason);
        }

        public void UpdateAppointmentDoctor(Appointment apppointment, Doctor newDoctor)
        {
            apppointment.doctorName = newDoctor.name;
            apppointment.doctorID = newDoctor.doctorID;
            unitOfWork.UpdateAppointmentDoctor(apppointment, newDoctor);
           
            
        }
    }
}
