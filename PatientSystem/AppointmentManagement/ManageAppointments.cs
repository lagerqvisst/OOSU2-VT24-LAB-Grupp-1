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

namespace PresentationLayer
{
    public partial class ManageAppointments : Form
    {
        //Hämtar en receptionist
        Receptionist receptionist;

        //Konstruktor
        public ManageAppointments(Receptionist receptionist)
        {
            InitializeComponent();
            this.receptionist = receptionist;
        }
        //Navigeringsknapp till CreateAppointment som tar med sig receptionisten
        private void btnCreateAppointView_Click(object sender, EventArgs e)
        {
            
            CreateAppointment createAppointment = new CreateAppointment(receptionist);
            createAppointment.Show();
        }

        //Navigeringsknapp till DeleteAppointmentsView
        private void btnDeleteAppointments_Click(object sender, EventArgs e)
        {
            DeleteAppointmentsView deleteAppointmentsView = new DeleteAppointmentsView();
            deleteAppointmentsView.Show();
        }

        //Navigeringsknapp till ViewAppointments
        private void btnViewAllAppointmentsView_Click(object sender, EventArgs e)
        {
            ViewAppointments viewAppointments = new ViewAppointments();
            viewAppointments.Show();
        }

        //Navigeringsknapp till UpdateAppointmentView
        private void btnUpdateApps_Click(object sender, EventArgs e)
        {
            UpdateAppointmentView updateAppointmentView = new UpdateAppointmentView();
            updateAppointmentView.Show();
        }

        //Navigeringsknapp tillbaka till föregående vy
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
