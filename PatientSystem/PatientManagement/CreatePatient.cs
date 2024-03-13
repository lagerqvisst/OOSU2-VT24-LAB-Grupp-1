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
using BusinessLayer;

namespace PresentationLayer
{
    public partial class CreatePatient : Form
    {
        PatientController patientController = new PatientController();
        public CreatePatient()
        {
            InitializeComponent();
        }

        private void btnBackFromCreate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreatePatient_Click(object sender, EventArgs e)
        {
            patientController.CreateNewPatient(persNumber_textbox.Text, namePatient_textbox.Text, adress_textbox.Text, phonenumber_textbox.Text, emailAdress_textbox.Text);

            MessageBox.Show("Patient created");
            this.Close();
        }

    }
}
