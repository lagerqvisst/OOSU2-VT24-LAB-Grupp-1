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
        //Hämtar en kontroller samt en appointment
        AppointmentController appointmentController = new AppointmentController();
        Appointment appointment;


        //Konstruktor
        public UpdateAppointmentView()
        {
            InitializeComponent();
            //Uppdaterar datagridview
            RefreshAppointmentsDataGridView();
        }

        public UpdateAppsOptionsView UpdateAppsOptionsView
        {
            get => default;
            set
            {
            }
        }

        //Uppdaterar datagridview
        private void RefreshAppointmentsDataGridView()
        {
           

            dataGridViewAppointments.DataSource = new BindingList<Appointment>(appointmentController.GetAllAppointments());
            //Gömmer onödiga kolumner
            dataGridViewAppointments.Columns["doctor"].Visible = false;
            dataGridViewAppointments.Columns["receptionist"].Visible = false;
            dataGridViewAppointments.Columns["patient"].Visible = false;


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

        //Knapp för att navigera till UpdateAppsOptionsView med vald appointment
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

        //Navigeringsknapp tillbaka till föregående vy
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Knapp för att uppdatera datagridview
        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            RefreshAppointmentsDataGridView();
        }
    }
}
