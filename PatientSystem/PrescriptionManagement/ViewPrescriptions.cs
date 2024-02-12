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
using DataLayer;
using BusinessLayer;

namespace PresentationLayer.PrescriptionManagement
{
    public partial class ViewPrescriptions : Form
    {
        PrescriptionController prescriptionController = new PrescriptionController();
        public ViewPrescriptions()
        {
            InitializeComponent();
            RefreshDataGridview();  
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void RefreshDataGridview()
        {
            dataGridViewPrescriptions.DataSource = new BindingList<Prescription>(prescriptionController.GetAllPrescriptions());
            dataGridViewPrescriptions.Columns["patient"].Visible = false;
        }
    }
}
