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
    public partial class UpdateOptionsView : Form
    {
        Patient patientToUpdate;
        int patientId;
        PatientController patientController = new PatientController();

        string nameToUpdate;
        string personalNumberToUpdate;
        string addressToUpdate;
        string phoneNumberToUpdate;
        string emailToUpdate;

        public UpdateOptionsView(Patient patient, int patientId)
        {
            InitializeComponent();
            this.patientToUpdate = patient;
            this.patientId = patientId;
            labelOptionsHeading.Text = $"Update options for {patientToUpdate.name}";
            //RefreshTextBoxes();
        }

        private void btnReturnFromUpdateOptions_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public void RefreshTextBoxes()
        {
            textBox_address.Text = patientToUpdate.address;
            textBox_emailaddress.Text = patientToUpdate.emailaddress;
            textBox_namePatient.Text = patientToUpdate.name;
            textBox_personalNumber.Text = patientToUpdate.personalNumber;
            textBox_phoneNumber.Text = patientToUpdate.phonenumber;

        }

        private void textBox_phoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        public void btnUpdateName_Click(object sender, EventArgs e)
        {
            //RefreshTextBoxes();
            nameToUpdate = textBox_namePatient.Text;
            patientController.UpdatePatientName(patientToUpdate, nameToUpdate);

            labelOptionsHeading.Text = $"Update options for {nameToUpdate}";

            MessageBox.Show("Name updated");
        }

        public void btnUpdatePersonalNum_Click(object sender, EventArgs e)
        {
            personalNumberToUpdate = textBox_personalNumber.Text;
            patientController.UpdatePatientPersonalNumber(patientToUpdate, personalNumberToUpdate);

            MessageBox.Show("Personal number updated");
        }

        public void btnUpdateAddress_Click(object sender, EventArgs e)
        {
            addressToUpdate = textBox_address.Text;
            patientController.UpdatePatientAddress(patientToUpdate, addressToUpdate);

            MessageBox.Show("Address updated");
        }

        private void btnUpdatePhoneNumber_Click(object sender, EventArgs e)
        {
            phoneNumberToUpdate = textBox_phoneNumber.Text;
            patientController.UpdatePatientPhoneNumber(patientToUpdate, phoneNumberToUpdate);

            MessageBox.Show("Phone number updated");
        }

        private void btnUpdateEmailAddress_Click(object sender, EventArgs e)
        {
            emailToUpdate = textBox_emailaddress.Text;
            patientController.UpdatePatientEmail(patientToUpdate, emailToUpdate);

            MessageBox.Show("Email updated");

        }
    }
}
