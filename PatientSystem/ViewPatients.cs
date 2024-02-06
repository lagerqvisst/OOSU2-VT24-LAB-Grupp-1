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
    public partial class ViewPatients : Form
    {
        PatientController patientController = new PatientController();
        public ViewPatients()
        {

            InitializeComponent();
            RefreshPatientsDataGridView();
        }

        private void RefreshPatientsDataGridView()
        {

            dataGridView_Patients.DataSource = new BindingList<Patient>(patientController.GetAllPatients());

        }

        private void returnFromView_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
