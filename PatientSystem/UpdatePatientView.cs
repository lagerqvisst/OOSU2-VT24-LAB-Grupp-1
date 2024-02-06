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
        int patientId;
        public UpdatePatientView()
        {
            InitializeComponent();
            RefreshPatientsDataGridView();
        }

        private void btnReturnFromUpdateview_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefreshPatientsDataGridView()
        {

            dataGridView_PatientsToUpdate.DataSource = new BindingList<Patient>(patientController.GetAllPatients());

        }

        private void dataGridView_PatientsToUpdate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            patientId = (int)dataGridView_PatientsToUpdate.Rows[e.RowIndex].Cells[0].Value;
            clickedPatient = patientController.GetPatientById(patientId);
        }

        private void btnSelectPatientToUpdate_Click(object sender, EventArgs e)
        {
            if (clickedPatient != null)
            {
                UpdateOptionsView updateOptionsView = new UpdateOptionsView(clickedPatient, patientId);
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
