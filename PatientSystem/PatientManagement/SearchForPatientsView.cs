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
using EntityLayer;

namespace PresentationLayer
{
    public partial class SearchForPatientsView : Form
    {
        PatientController patientController = new PatientController();
        string searchValue;
        public SearchForPatientsView()
        {
            InitializeComponent();
        }

        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sök efter patienter med namn
        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            searchValue = textBoxByName.Text;
            List<Patient> patients = patientController.GetPatientsByName(searchValue);
            dataGridViewSearchResults.DataSource = new BindingList<Patient>(patients);
        }

        // Sök efter patienter med personnummer
        private void btnSearchByPersonalNumber_Click(object sender, EventArgs e)
        {
            searchValue = textBoxPersonalNumber.Text;
            List<Patient> patients = patientController.GetPatientsByPersonalNum(searchValue);
            dataGridViewSearchResults.DataSource = new BindingList<Patient>(patients);
        }

        // Sök efter patienter med adress
        private void btnSearchByAddress_Click(object sender, EventArgs e)
        {
            searchValue = textBoxAddress.Text;
            List<Patient> patients = patientController.GetPatientsByAddress(searchValue);
            dataGridViewSearchResults.DataSource = new BindingList<Patient>(patients);
        }

        // Sök efter patienter med telefonnummer
        private void btnSearchByPhoneNumber_Click(object sender, EventArgs e)
        {
            searchValue = textBoxPhoneNumber.Text;
            List<Patient> patients = patientController.GetPatientsByPhoneNumber(searchValue);
            dataGridViewSearchResults.DataSource = new BindingList<Patient>(patients);
        }

        // Sök efter patienter med e-postadress
        private void btnSearchByEmailAddress_Click(object sender, EventArgs e)
        {
            searchValue = textBoxEmailAddress.Text;
            List<Patient> patients = patientController.GetPatientsByEmailAddress(searchValue);
            dataGridViewSearchResults.DataSource = new BindingList<Patient>(patients);
        }
    }
}
