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
    public partial class UpdatePatientView : Form
    {
        
        PatientController patientController = new PatientController();
        Patient clickedPatient;
        public UpdatePatientView()
        {
            InitializeComponent();
            RefreshPatientsDataGridView();
        }

        
        private void btnReturnFromUpdateview_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Uppdaterar datagridview med patienter
        private void RefreshPatientsDataGridView()
        {

            dataGridView_PatientsToUpdate.DataSource = new BindingList<Patient>(patientController.GetAllPatients());

        }

        private void dataGridView_PatientsToUpdate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //patientId = (int)dataGridView_PatientsToUpdate.Rows[e.RowIndex].Cells[0].Value;
            //clickedPatient = patientController.GetPatientById(patientId);

            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                clickedPatient = dataGridView_PatientsToUpdate.Rows[e.RowIndex].DataBoundItem as Patient;
                MessageBox.Show($"Patient: {clickedPatient.name} selected");
            }
        }

        //Uppdatera den valda patienten
        private void btnSelectPatientToUpdate_Click(object sender, EventArgs e)
        {
            if (clickedPatient != null)
            {
                UpdatePatOptionsView updateOptionsView = new UpdatePatOptionsView(clickedPatient);
                updateOptionsView.Show();
            }
            else
            {
                MessageBox.Show("No patient selected");
            }

        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            RefreshPatientsDataGridView();
        }
    }
}
