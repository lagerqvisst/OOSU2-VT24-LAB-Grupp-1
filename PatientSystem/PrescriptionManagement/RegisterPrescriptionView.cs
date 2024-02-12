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

namespace PresentationLayer.PrescriptionManagement
{
    public partial class RegisterPrescriptionView : Form
    {
        DrugController drugController = new DrugController();
        PatientController patientController = new PatientController();
        PrescriptionController prescriptionController = new PrescriptionController();

        Prescription prescription;
        Drug drug;
        List<Drug> drugs = new List<Drug>(); //Gör så att man kan lägga till flera läkemedel i samma recept + confirmation av varje klickat läkemedel + ett gridview som visar vilka läkemedel som är tillagda 
        Patient patient;
        public RegisterPrescriptionView()
        {
            InitializeComponent();
            RefreshDataGridview();
        }

        public void RefreshDataGridview()
        {
            dataGridviewDrugs.DataSource = new BindingList<Drug>(drugController.GetAllDrugs());
            dataGridviewDrugs.Columns["DrugName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridviewDrugs.Columns["prescriptionId"].Visible = false;
            //dataGridviewDrugs.Columns["Prescription"].Visible = false;

            dataGridViewPatients.DataSource = new BindingList<Patient>(patientController.GetAllPatients());
        }

        private void dataGridViewPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                patient = dataGridViewPatients.Rows[e.RowIndex].DataBoundItem as Patient;
                MessageBox.Show($"Patient: {patient.name} selected");

            }
        }

        private void dataGridviewDrugs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                drug = dataGridviewDrugs.Rows[e.RowIndex].DataBoundItem as Drug;
                MessageBox.Show($"Drug: {drug.DrugName} selected");
                drugs.Add(drug);
                RefreshPrescribedDrugsList();

            }
        }

        public void RefreshPrescribedDrugsList()
        {
            dataGridViewPrescribedDrugs.DataSource = new BindingList<Drug>(drugs);
            dataGridViewPrescribedDrugs.Columns["DrugName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridViewPrescribedDrugs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                drug = dataGridViewPrescribedDrugs.Rows[e.RowIndex].DataBoundItem as Drug;
                drugs.Remove(drug);
                MessageBox.Show($"Drug: {drug.DrugName} removed");
                RefreshPrescribedDrugsList();

            }
        }

        private void btnCreatePrescription_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            prescriptionController.CreatePrescription(patient.patientId, date, drugs);

            labelSummary.Text = $"Prescription registered for {patient.name} at {date} with {drugs.Count} drugs.";

            //drugs.Clear();
            RefreshPrescribedDrugsList();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
