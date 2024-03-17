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

namespace PresentationLayer
{
    public partial class ViewAppointments : Form
    {
        //Hämtar en kontroller
        AppointmentController appointmentController = new AppointmentController();
        public ViewAppointments()
        {
            InitializeComponent();
            //Uppdaterar datagridview
            RefreshAppointmentsDataGridView();
        }

        //Navigeringsknapp tillbaka till föregående vy
        private void btnReturnFromViewApps_Click(object sender, EventArgs e)
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
    }
}
