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
        //Hämtar en appointment samt en doctor
        Appointment appointment;
        Doctor doctor;

        //Hämtar kontroller
        DoctorController doctorController = new DoctorController();
        AppointmentController appointmentController = new AppointmentController();

        //Konstruktor
        public UpdateAppsOptionsView(Appointment appointment)
        {
            InitializeComponent();
            this.appointment = appointment;
            //Uppdaterar datagridview
            RefreshDoctorDataGridview();
        }

        //Uppdaterar datagridview
        private void RefreshDoctorDataGridview()
        {
            dataGridViewDoctors.DataSource = new BindingList<Doctor>(doctorController.GetAllDoctors());
            //Gömmer onödiga kolumner
            dataGridViewDoctors.Columns["doctorId"].Visible = false;
            dataGridViewDoctors.Columns["password"].Visible = false;


        }

        //Hämtar doctor som valts i datagridview
        private void dataGridViewDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //doctorId = (int)dataGridViewDoctors.Rows[e.RowIndex].Cells[0].Value;
            //doctor = doctorController.GetDoctorById(doctorId);

           
            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {
                //Sätter doctor till den valda doktorn
                doctor = dataGridViewDoctors.Rows[e.RowIndex].DataBoundItem as Doctor;
                MessageBox.Show($"Doctor: {doctor.name} selected");

            }

        }

        //Navigeringsknapp tillbaka till föregående vy
        private void btnReturnFromAppUpdateOps_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Uppdaterar datum på appointment
        private void btnUpdateDate_Click(object sender, EventArgs e)
        {
            DateTime newDate = DateTime.Parse(textBox_Date.Text);
            newDate = newDate.Date;

            appointmentController.UpdateAppointmentDate(appointment, newDate);
            MessageBox.Show("Date updated");
        }

        //Uppdaterar reason på appointment
        private void btnUpdateReason_Click(object sender, EventArgs e)
        {
            string newReason = textBoxReason.Text;
            appointmentController.UpdateAppointmentReason(appointment, newReason);
            MessageBox.Show("Reason updated");
        }

        //Uppdaterar doctor på appointment
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
