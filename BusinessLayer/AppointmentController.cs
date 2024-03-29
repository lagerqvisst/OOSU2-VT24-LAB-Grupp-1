﻿using System;
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

        #region Create
        //Skapar nytt appointment med patientId, datum, reason, doktorId och receptionistId.
        public Appointment CreateNewAppointment(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID, int receptionistId)
        {
            Appointment appointment = new Appointment(patientId, appointmentDate, appointmentReason, doctorID, receptionistId);

            //För att sätta namnen på patient, doktor och receptionist där namnen är kopplade med faktiska objekt och inte lösa strängar i appointment
            //Se SetNames-metoden i Appointment-klassen. 
            //Denna lösning används eftersom att EF inte kan lagra objekt som inte är kopplade till databasen.
            appointment.SetNames(unitOfWork.PatientRepository.FirstOrDefault(p => p.patientId == patientId),
                                unitOfWork.DoctorRepository.FirstOrDefault(d => d.doctorID == doctorID),
                                unitOfWork.ReceptionistRepository.FirstOrDefault(r => r.receptionistId == receptionistId));

            unitOfWork.CreateAppointment(appointment);
            return appointment;
        }

        //Denna metod används för att skapa en ny appointment från doktor-vyn. Då behöver vi inte skicka med receptionistId eftersom att det är doktorn som skapar tiden.
        public Appointment NewAppointmentByDoctor(int patientId, DateTime appointmentDate, string appointmentReason, int doctorID)
        {
            appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentDate.Hour, appointmentDate.Minute, 0);

            Appointment appointment = new Appointment(patientId, appointmentDate, appointmentReason, doctorID);

            //För att sätta namnen på patient, doktor och receptionist där namnen är kopplade med faktiska objekt och inte lösa strängar i appointment
            //Denna tar endast patientId och doctorID eftersom att det är doktorn som skapar tiden och då behöver vi inte sätta receptionist.
            appointment.SetNames(unitOfWork.PatientRepository.FirstOrDefault(p => p.patientId == patientId),
                                                unitOfWork.DoctorRepository.FirstOrDefault(d => d.doctorID == doctorID));

            unitOfWork.CreateAppointment(appointment);
            return appointment;
        }
        #endregion

        #region Read
        //Skriver ut alla Appointments
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

        //Använd denna för att hämta alla appointments genom att använda appointmentId.
        public Appointment GetAppointmentById(int id)
        {
            return unitOfWork.AppointmentRepository.FirstOrDefault(a => a.appointmentId == id);
        }

        //Hämtar alla appointments för en specifik patient
        public List<Appointment> GetPatientAppointments(Patient patient)
        {
            return unitOfWork.AppointmentRepository.Find(a => a.patientId == patient.patientId).ToList();
        }
        #endregion

        #region Update
        //Plockar med en appointment för att sedan ta bort den från databasen
        public Appointment AppointmentToDelete(Appointment appointment)
        {
            unitOfWork.DeleteAppointment(appointment);
            return appointment;
        }

        //Uppdaterar en särskild appointment med ett nytt datum
        public void UpdateAppointmentDate(Appointment appointment, DateTime newDate)
        {
            unitOfWork.UpdateAppointmentDate(appointment, newDate);
        }

        //Uppdaterar en särskild appointment med en ny reason
        public void UpdateAppointmentReason(Appointment appointment, string newReason)
        {
            unitOfWork.UpdateAppointmentReason(appointment, newReason);
        }

        //Uppdaterar en särskild appointment med en ny doktor
        public void UpdateAppointmentDoctor(Appointment apppointment, Doctor newDoctor)
        {
            apppointment.doctorName = newDoctor.name;
            apppointment.doctorID = newDoctor.doctorID;
            unitOfWork.UpdateAppointmentDoctor(apppointment, newDoctor);
        }

        //Uppdaterar en särskild appointment med en uppdaterad doctorsnote.
        public void UpdateAppointmentDoctorsNote(Appointment appointment, string newNote)
        {
            unitOfWork.UpdateAppointmentDoctorsNote(appointment, newNote);
        }
        #endregion
    }

}
