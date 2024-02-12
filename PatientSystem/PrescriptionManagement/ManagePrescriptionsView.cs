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

namespace PresentationLayer.PrescriptionManagement
{
    public partial class ManagePrescriptionsView : Form
    {
        Doctor doctor;
        public ManagePrescriptionsView(Doctor doctor)
        {
            InitializeComponent();
            this.doctor = doctor;
        }

        private void btnRegNewPrescrip_Click(object sender, EventArgs e)
        {
            RegisterPrescriptionView registerPrescriptionView = new RegisterPrescriptionView();
            registerPrescriptionView.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewPrescriptions_Click(object sender, EventArgs e)
        {
            ViewPrescriptions viewPrescriptions = new ViewPrescriptions();  
            viewPrescriptions.Show();   
        }
    }
}
