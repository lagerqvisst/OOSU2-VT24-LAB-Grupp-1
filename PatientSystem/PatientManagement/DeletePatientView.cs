using BusinessLayer;
using EntityLayer;
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
    public partial class DeletePatientView : Form
    {
        PatientController patientController = new PatientController();
        Patient clickedPatient;
        public int patientId;

        public DeletePatientView()
        {
            InitializeComponent();
            RefreshPatientsDataGridView();
        }

        private void btnReturnFromDeleteView_Click(object sender, EventArgs e)
        {
            this.Close();
            RefreshPatientsDataGridView();
        }

        private void RefreshPatientsDataGridView()
        {
            
            dataGridView_PatientsToDelete.DataSource = new BindingList<Patient>(patientController.GetAllPatients());
            


        }

        private void dataGridView_PatientsToDelete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hämta värdet från primary key-kolumnen
            //patientId = (int)dataGridView_PatientsToDelete.Rows[e.RowIndex].Cells[0].Value;
            //clickedPatient = patientController.GetPatientById(patientId);


            if (e.RowIndex >= 0) // Kontrollera att det är en giltig rad
            {

                clickedPatient = dataGridView_PatientsToDelete.Rows[e.RowIndex].DataBoundItem as Patient;
                MessageBox.Show($"Patient: {clickedPatient.name} selected");
                
            }


        }


        private void btn_DeleteSelectedPatient_Click(object sender, EventArgs e)
        {
            if (clickedPatient != null)
            {
                patientController.PatientToRemove(clickedPatient);
                MessageBox.Show("Patient removed");
                RefreshPatientsDataGridView();
            }
            else
            {
                MessageBox.Show("No patient selected");
            }
        }
    }
}
