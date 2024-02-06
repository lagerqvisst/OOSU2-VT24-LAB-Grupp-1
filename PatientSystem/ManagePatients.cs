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

namespace PresentationLayer
{
    public partial class ManagePatients : Form
    {
        Receptionist receptionst;
        public ManagePatients(Receptionist receptionst)
        {
            InitializeComponent();
        }

        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateNewPatient_Click(object sender, EventArgs e)
        {
            CreatePatient createPatient = new CreatePatient(receptionst);
            createPatient.Show();
        }

        private void btnViewPatients_Click(object sender, EventArgs e)
        {
            ViewPatients viewPatients = new ViewPatients();
            viewPatients.Show();
        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            DeletePatientView deletePatientView = new DeletePatientView();
            deletePatientView.Show();
        }

        private void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            UpdatePatientView updatePatientView = new UpdatePatientView();
            updatePatientView.Show();
        }
    }
}
