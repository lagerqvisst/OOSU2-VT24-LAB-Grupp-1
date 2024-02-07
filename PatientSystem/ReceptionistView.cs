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
    public partial class ReceptionistView : Form
    {
        Receptionist receptionst;
        public ReceptionistView(Receptionist receptionist)
        {
            InitializeComponent();
            this.receptionst = receptionist;

            labelrecepview.Text = $"Sign in as {receptionist.name}";
        }

        private void btnBacktoSignin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnManagePatients_Click(object sender, EventArgs e)
        {
            ManagePatients managePatients = new ManagePatients(receptionst);
            managePatients.Show();
        }

        private void btnManageAppointments_Click(object sender, EventArgs e)
        {
            ManageAppointments manageAppointments = new ManageAppointments(receptionst);
            manageAppointments.Show();
        }
    }
}
