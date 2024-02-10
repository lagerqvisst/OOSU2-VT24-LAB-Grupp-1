using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace PresentationLayer
{
    public partial class UpdateAppsOptionsView : Form
    {
        Appointment appointment;
        Doctor doctor;

        DoctorController doctorController = new DoctorController();
        AppointmentController appointmentController = new AppointmentController();

        public UpdateAppsOptionsView(Appointment appointment)
        {
            InitializeComponent();
            this.appointment = appointment;
            RefreshDoctorDataGridview();
        }

        private void RefreshDoctorDataGridview()
        {
            dataGridViewDoctors.DataSource = new BindingList<Doctor>(doctorController.GetAllDoctors());
            dataGridViewDoctors.Columns["doctorId"].Visible = false;
            dataGridViewDoctors.Columns["password"].Visible = false;


        }

        private void dataGridViewDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //doctorId = (int)dataGridViewDoctors.Rows[e.RowIndex].Cells[0].Value;
            //doctor = doctorController.GetDoctorById(doctorId);

            doctor = dataGridViewDoctors.SelectedRows[0].DataBoundItem as Doctor;
        }

        private void btnReturnFromAppUpdateOps_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateDate_Click(object sender, EventArgs e)
        {
            DateTime newDate = DateTime.Parse(textBox_Date.Text);
            newDate = newDate.Date;

            appointmentController.UpdateAppointmentDate(appointment, newDate);
            MessageBox.Show("Date updated");
        }

        private void btnUpdateReason_Click(object sender, EventArgs e)
        {
            string newReason = textBoxReason.Text;
            appointmentController.UpdateAppointmentReason(appointment, newReason);
            MessageBox.Show("Reason updated");
        }

        private void btnUpdateDoctor_Click(object sender, EventArgs e)
        {
            if(doctor == null)
            {
                MessageBox.Show("Please select a doctor to update");
                return;
            }
            else
            {
                appointmentController.UpdateAppointmentDoctor(appointment, doctor);
                MessageBox.Show("Doctor updated");
            }
            
        }
    }
}
