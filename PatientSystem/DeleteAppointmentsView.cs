﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;


namespace PresentationLayer
{
    public partial class DeleteAppointmentsView : Form
    {
        AppointmentController appointmentController = new AppointmentController();
        Appointment appointment;
        int appointmentId;
        public DeleteAppointmentsView()
        {
            InitializeComponent();
            RefreshAppointmentsDataGridView();
        }

        private void btnReturnFromDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshAppointmentsDataGridView()
        {
            dataGridViewAppointments.DataSource = new BindingList<Appointment>(appointmentController.GetAllAppointments());
            dataGridViewAppointments.Columns["doctor"].Visible = false;
            dataGridViewAppointments.Columns["patient"].Visible = false;
            dataGridViewAppointments.Columns["receptionist"].Visible = false;
        }

        private void dataGridViewAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            appointmentId = (int)dataGridViewAppointments.Rows[e.RowIndex].Cells[0].Value;
            appointment = appointmentController.GetAppointmentById(appointmentId);
        }

        private void btnDeleteSelectedAppointment_Click(object sender, EventArgs e)
        {
            appointmentController.AppointmentToDelete(appointment);
            MessageBox.Show("Appointment removed");
            RefreshAppointmentsDataGridView();
        }
    }
}
