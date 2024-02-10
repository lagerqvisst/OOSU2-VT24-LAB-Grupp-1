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
        Receptionist receptionist;

        public ManageAppointments(Receptionist receptionist)
        {
            InitializeComponent();
            this.receptionist = receptionist;
        }

        private void btnCreateAppointView_Click(object sender, EventArgs e)
        {
            CreateAppointment createAppointment = new CreateAppointment(receptionist);
            createAppointment.Show();
        }

        private void btnDeleteAppointments_Click(object sender, EventArgs e)
        {
            DeleteAppointmentsView deleteAppointmentsView = new DeleteAppointmentsView();
            deleteAppointmentsView.Show();
        }

        private void btnViewAllAppointmentsView_Click(object sender, EventArgs e)
        {
            ViewAppointments viewAppointments = new ViewAppointments();
            viewAppointments.Show();
        }

        private void btnUpdateApps_Click(object sender, EventArgs e)
        {
            UpdateAppointmentView updateAppointmentView = new UpdateAppointmentView();
            updateAppointmentView.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
