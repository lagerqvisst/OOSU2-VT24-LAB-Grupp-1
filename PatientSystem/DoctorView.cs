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
using PresentationLayer.PrescriptionManagement;

namespace PresentationLayer
{
    public partial class DoctorView : Form
    {
        Doctor doctor;
        public DoctorView(Doctor doctor)
        {
            InitializeComponent();
            this.doctor = doctor;
            doctorviewLabel.Text = $"Sign in as {doctor.name}";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnManagePrescriptions_Click(object sender, EventArgs e)
        {
            ManagePrescriptionsView managePrescriptionsView = new ManagePrescriptionsView(doctor);
            managePrescriptionsView.Show();
        }
    }
}
