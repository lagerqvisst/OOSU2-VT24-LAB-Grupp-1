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

            //För att sätta namnen på patient, doktor och receptionist där namnen är kopplade med faktiska objekt och inte lösa strängar i appointment
            appointment.SetNames(unitOfWork.PatientRepository.FirstOrDefault(p => p.patientId == patientId),
                                unitOfWork.DoctorRepository.FirstOrDefault(d => d.doctorID == doctorID),
                                unitOfWork.ReceptionistRepository.FirstOrDefault(r => r.receptionistId == receptionistId));
            
           

            unitOfWork.CreateAppointment(appointment);
            return appointment;
        }

        public Appointment NewAppointmentByDoctor(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID)
        {
            appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentDate.Hour, appointmentDate.Minute, 0);

            Appointment appointment = new Appointment(patientId, appointmentDate, appointmentReason, doctorID);

            //För att sätta namnen på patient, doktor och receptionist där namnen är kopplade med faktiska objekt och inte lösa strängar i appointment
            appointment.SetNames(unitOfWork.PatientRepository.FirstOrDefault(p => p.patientId == patientId),
                                               unitOfWork.DoctorRepository.FirstOrDefault(d => d.doctorID == doctorID));



            unitOfWork.CreateAppointment(appointment);
            return appointment;
        }

        public List<Appointment> GetAllAppointments()
        {
            return unitOfWork.AppointmentRepository.Find(a => true).ToList();
        }

        //Använd denna i viewmodel i WPF för att visa appointments för en specifik doktor som är inloggad.
        public List<Appointment> GetDoctorSpecificAppointmentsTodayAndFuture(Doctor doctor)
        {
            return unitOfWork.AppointmentRepository
                .Find(a => a.doctorID == doctor.doctorID && a.appointmentDate >= DateTime.Today)
                .ToList();
        }


        //Onödig metod, använd hela objekt istället... 
        public Appointment GetAppointmentById(int id)
        {
            return unitOfWork.AppointmentRepository.FirstOrDefault(a => a.appointmentId == id);
        }

        public List<Appointment> GetPatientAppointments(Patient patient)
        {
            return unitOfWork.AppointmentRepository.Find(a => a.patientId == patient.patientId).ToList();
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
        public void UpdateAppointmentDoctorsNote(Appointment appointment, string newNote)
        {
            unitOfWork.UpdateAppointmentDoctorsNote(appointment, newNote);
        }
    }
}
