using System;
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
        Receptionist receptionist;
        Doctor doctor;
        Patient patient;
        DateTime appointmentDate;
        string appointmentReason;

        PatientController patientController = new PatientController();
        DoctorController doctorController = new DoctorController();
        AppointmentController appointmentController = new AppointmentController();
        public CreateAppointment(Receptionist receptionist)
        {
            InitializeComponent();
            this.receptionist = receptionist;
            RefreshPatientsDataGridView();
        }

        private void btnReturnFromCreate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshPatientsDataGridView()
        {

            dataGridViewPatients.DataSource = new BindingList<Patient>(patientController.GetAllPatients());
            dataGridViewDoctors.DataSource = new BindingList<Doctor>(doctorController.GetAllDoctors());

        }

        private void dataGridViewPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //patientId = (int)dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value;
            //patient = patientController.GetPatientById(patientId);

            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                patient = dataGridViewPatients.Rows[e.RowIndex].DataBoundItem as Patient;

            }

            MessageBox.Show($"Patient: {patient.name} selected");
        }

        private void dataGridViewDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Funkar utan att använda byID metod
            //doctorId = (int)dataGridViewDoctors.Rows[e.RowIndex].Cells[0].Value;
            //doctor = doctorController.GetDoctorById(doctorId);

            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                doctor = dataGridViewDoctors.Rows[e.RowIndex].DataBoundItem as Doctor;

            }

            MessageBox.Show($"Doctor: {doctor.name} selected");
        }

        private void btnScheduleAppointment_Click(object sender, EventArgs e)
        {
            appointmentDate = DateTime.Parse(textBoxDateAppointment.Text);
            appointmentDate = appointmentDate.Date;

            appointmentReason = textBoxReasonAppointment.Text;
            appointmentController.CreateNewAppointment(patient.patientId, appointmentDate, appointmentReason, doctor.doctorID, receptionist.receptionistId);
            MessageBox.Show("Appointment created"); 

            labelSummary.Text = $"Appointment created for {patient.name} with {doctor.name} on {appointmentDate} for {appointmentReason}";
        }



        



    }
}
