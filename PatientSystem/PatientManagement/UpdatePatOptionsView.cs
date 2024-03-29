﻿using System;
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
    public partial class UpdatePatOptionsView : Form
    {
        //Hämtar patient, controller och alla uppdateringsvärden
        Patient patientToUpdate;
        PatientController patientController = new PatientController();

        string nameToUpdate;
        string personalNumberToUpdate;
        string addressToUpdate;
        string phoneNumberToUpdate;
        string emailToUpdate;

        public UpdatePatOptionsView(Patient patient)
        {
            InitializeComponent();
            this.patientToUpdate = patient;

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

        //Uppdaterar patientens namn
        public void btnUpdateName_Click(object sender, EventArgs e)
        {
            //RefreshTextBoxes();
            nameToUpdate = textBox_namePatient.Text;
            patientController.UpdatePatientName(patientToUpdate, nameToUpdate);

            labelOptionsHeading.Text = $"Update options for {nameToUpdate}";

            MessageBox.Show("Name updated");
        }

        //Uppdaterar patientens personnummer
        public void btnUpdatePersonalNum_Click(object sender, EventArgs e)
        {
            personalNumberToUpdate = textBox_personalNumber.Text;
            patientController.UpdatePatientPersonalNumber(patientToUpdate, personalNumberToUpdate);

            MessageBox.Show("Personal number updated");
        }

        //Uppdaterar patientens adress
        public void btnUpdateAddress_Click(object sender, EventArgs e)
        {
            addressToUpdate = textBox_address.Text;
            patientController.UpdatePatientAddress(patientToUpdate, addressToUpdate);

            MessageBox.Show("Address updated");
        }

        //Uppdaterar patientens telefonnummer
        private void btnUpdatePhoneNumber_Click(object sender, EventArgs e)
        {
            phoneNumberToUpdate = textBox_phoneNumber.Text;
            patientController.UpdatePatientPhoneNumber(patientToUpdate, phoneNumberToUpdate);

            MessageBox.Show("Phone number updated");
        }

        //Uppdaterar patientens e-postadress
        private void btnUpdateEmailAddress_Click(object sender, EventArgs e)
        {
            emailToUpdate = textBox_emailaddress.Text;
            patientController.UpdatePatientEmail(patientToUpdate, emailToUpdate);

            MessageBox.Show("Email updated");

        }
    }
}
