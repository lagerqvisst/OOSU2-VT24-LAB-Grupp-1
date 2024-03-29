﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class CreateAppointment : Form
    {
        //Hämtar alla värden som behövs för att skapa en ny appointment
        Receptionist receptionist;
        Doctor doctor;
        Patient patient;
        DateTime appointmentDate;
        string appointmentReason;

        //Hämtar alla kontroller som behövs 
        PatientController patientController = new PatientController();
        DoctorController doctorController = new DoctorController();
        AppointmentController appointmentController = new AppointmentController();

        //Konstruktor
        public CreateAppointment(Receptionist receptionist)
        {
            InitializeComponent();
            //Sätter den faktiska receptionisten
            this.receptionist = receptionist;
            //Uppdaterar datagridview
            RefreshPatientsDataGridView();
        }

        //Navigeringsknapp tillbaka till föregående vy
        private void btnReturnFromCreate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Uppdaterar alla datagridviews
        private void RefreshPatientsDataGridView()
        {

            dataGridViewPatients.DataSource = new BindingList<Patient>(patientController.GetAllPatients());
            dataGridViewDoctors.DataSource = new BindingList<Doctor>(doctorController.GetAllDoctors());

        }

        //Hämtar patienten som valts i datagridview
        private void dataGridViewPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //patientId = (int)dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value;
            //patient = patientController.GetPatientById(patientId);

            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                patient = dataGridViewPatients.Rows[e.RowIndex].DataBoundItem as Patient;
                MessageBox.Show($"Patient: {patient.name} selected");

            }

            
        }

        //Hämtar doktorn som valts i datagridview
        private void dataGridViewDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Funkar utan att använda byID metod
            //doctorId = (int)dataGridViewDoctors.Rows[e.RowIndex].Cells[0].Value;
            //doctor = doctorController.GetDoctorById(doctorId);

            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                doctor = dataGridViewDoctors.Rows[e.RowIndex].DataBoundItem as Doctor;
                MessageBox.Show($"Doctor: {doctor.name} selected");

            }

            
        }

        //Skapar en ny appointment
        private void btnScheduleAppointment_Click(object sender, EventArgs e)
        {

            if (DateTime.TryParse(textBoxDateAppointment.Text, out appointmentDate))
            {
                appointmentDate = appointmentDate.Date;
                string formattedDate = appointmentDate.ToString("yyyy-MM-dd");
                
            }

            appointmentReason = textBoxReasonAppointment.Text;
            appointmentController.CreateNewAppointment(patient.patientId, appointmentDate, appointmentReason, doctor.doctorID, receptionist.receptionistId);
            MessageBox.Show("Appointment created"); 

            labelSummary.Text = $"Appointment created for {patient.name} with {doctor.name} on {appointmentDate.ToString("yyyy-MM-dd")} for {appointmentReason}";
        }



        



    }
}
