using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;


namespace PresentationLayer
{
    public partial class DeleteAppointmentsView : Form
    {
        //Hämtar en kontroller samt en appointment
        AppointmentController appointmentController = new AppointmentController();
        Appointment appointment;

        //Konstruktor
        public DeleteAppointmentsView()
        {
            InitializeComponent();
            //Uppdaterar datagridview
            RefreshAppointmentsDataGridView();
        }
        //Navigeringsknapp tillbaka till föregående vy
        private void btnReturnFromDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Uppdaterar datagridview
        private void RefreshAppointmentsDataGridView()
        {
            dataGridViewAppointments.DataSource = new BindingList<Appointment>(appointmentController.GetAllAppointments());
            //Gömmer onödiga kolumner
            dataGridViewAppointments.Columns["doctor"].Visible = false;
            dataGridViewAppointments.Columns["patient"].Visible = false;
            dataGridViewAppointments.Columns["receptionist"].Visible = false;
        }
        //Hämtar appointment som valts i datagridview
        private void dataGridViewAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //appointmentId = (int)dataGridViewAppointments.Rows[e.RowIndex].Cells[0].Value;
            //appointment = appointmentController.GetAppointmentById(appointmentId);

            

            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {
                //Sätter appointment till den valda appointmenten
                appointment = dataGridViewAppointments.Rows[e.RowIndex].DataBoundItem as Appointment;
                MessageBox.Show($"Appointment: {appointment.appointmentId} selected");

            }

        }

        //Tar bort vald appointment
        private void btnDeleteSelectedAppointment_Click(object sender, EventArgs e)
        {
            if (appointment == null)
            {
                MessageBox.Show("Please select an appointment to delete");
                return;
            }
            else
            {
                appointmentController.AppointmentToDelete(appointment);
                MessageBox.Show("Appointment removed");
                //Uppdaterar datagridview efter borttagning
                RefreshAppointmentsDataGridView();
            }
 
        }
    }
}
