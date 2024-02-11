using BusinessLayer;
using EntityLayer;
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
using System.Windows.Forms.VisualStyles;

namespace PresentationLayer
{
    public partial class UpdateAppointmentView : Form
    {
        AppointmentController appointmentController = new AppointmentController();
        Appointment appointment;


        public UpdateAppointmentView()
        {
            InitializeComponent();
            RefreshAppointmentsDataGridView();
        }

        private void RefreshAppointmentsDataGridView()
        {
           

            dataGridViewAppointments.DataSource = new BindingList<Appointment>(appointmentController.GetAllAppointments());
            //Gömmer onödiga kolumner
            dataGridViewAppointments.Columns["doctor"].Visible = false;
            dataGridViewAppointments.Columns["receptionist"].Visible = false;
            dataGridViewAppointments.Columns["patient"].Visible = false;


        }



        private void dataGridViewAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //appointmentId = (int)dataGridViewAppointments.Rows[e.RowIndex].Cells[0].Value;
            //appointment = appointmentController.GetAppointmentById(appointmentId);

   

            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                appointment = dataGridViewAppointments.Rows[e.RowIndex].DataBoundItem as Appointment;
                MessageBox.Show($"Appointment: {appointment.appointmentId} selected");  

            }
        }

        private void btnSelectAppToUpdate_Click(object sender, EventArgs e)
        {
            if (appointment == null)
            {
                MessageBox.Show("Please select an appointment to update");
                return;
            }
            else
            {
                UpdateAppsOptionsView updateAppsOptionsView = new UpdateAppsOptionsView(appointment);
                updateAppsOptionsView.Show();
            }
            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            RefreshAppointmentsDataGridView();
        }
    }
}
