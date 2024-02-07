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
        int doctorId;
        Patient patient;
        int patientId;

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
            patientId = (int)dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value;
            patient = patientController.GetPatientById(patientId);
        }

        private void dataGridViewDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            doctorId = (int)dataGridViewDoctors.Rows[e.RowIndex].Cells[0].Value;
            doctor = doctorController.GetDoctorById(doctorId);
        }

        private void btnScheduleAppointment_Click(object sender, EventArgs e)
        {
            appointmentDate = DateTime.Parse(textBoxDateAppointment.Text);
            appointmentDate = appointmentDate.Date;

            appointmentReason = textBoxReasonAppointment.Text;
            appointmentController.CreateNewAppointment(patient.patientId, appointmentDate, appointmentReason, doctor.doctorID, receptionist.receptionistId);
            MessageBox.Show("Appointment created"); 
        }



        



    }
}
