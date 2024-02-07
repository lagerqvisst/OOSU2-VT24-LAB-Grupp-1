﻿namespace PresentationLayer
{
    partial class ManageAppointments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnCreateAppointView = new Button();
            btnDeleteAppointments = new Button();
            btnViewAllAppointmentsView = new Button();
            btnUpdateApps = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(239, 44);
            label1.Name = "label1";
            label1.Size = new Size(232, 23);
            label1.TabIndex = 1;
            label1.Text = "Manage Appointments";
            // 
            // btnCreateAppointView
            // 
            btnCreateAppointView.Location = new Point(239, 104);
            btnCreateAppointView.Name = "btnCreateAppointView";
            btnCreateAppointView.Size = new Size(232, 23);
            btnCreateAppointView.TabIndex = 2;
            btnCreateAppointView.Text = "CREATE APPOINTMENT";
            btnCreateAppointView.UseVisualStyleBackColor = true;
            btnCreateAppointView.Click += btnCreateAppointView_Click;
            // 
            // btnDeleteAppointments
            // 
            btnDeleteAppointments.Location = new Point(239, 188);
            btnDeleteAppointments.Name = "btnDeleteAppointments";
            btnDeleteAppointments.Size = new Size(232, 27);
            btnDeleteAppointments.TabIndex = 3;
            btnDeleteAppointments.Text = "DELETE APPOINTMENTS";
            btnDeleteAppointments.UseVisualStyleBackColor = true;
            btnDeleteAppointments.Click += btnDeleteAppointments_Click;
            // 
            // btnViewAllAppointmentsView
            // 
            btnViewAllAppointmentsView.Location = new Point(239, 147);
            btnViewAllAppointmentsView.Name = "btnViewAllAppointmentsView";
            btnViewAllAppointmentsView.Size = new Size(232, 23);
            btnViewAllAppointmentsView.TabIndex = 4;
            btnViewAllAppointmentsView.Text = "VIEW APPOINTMENTS";
            btnViewAllAppointmentsView.UseVisualStyleBackColor = true;
            btnViewAllAppointmentsView.Click += btnViewAllAppointmentsView_Click;
            // 
            // btnUpdateApps
            // 
            btnUpdateApps.Location = new Point(239, 239);
            btnUpdateApps.Name = "btnUpdateApps";
            btnUpdateApps.Size = new Size(232, 25);
            btnUpdateApps.TabIndex = 5;
            btnUpdateApps.Text = "UPDATE APPOINTMENTS";
            btnUpdateApps.UseVisualStyleBackColor = true;
            btnUpdateApps.Click += btnUpdateApps_Click;
            // 
            // ManageAppointments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdateApps);
            Controls.Add(btnViewAllAppointmentsView);
            Controls.Add(btnDeleteAppointments);
            Controls.Add(btnCreateAppointView);
            Controls.Add(label1);
            Name = "ManageAppointments";
            Text = "ManageAppointments";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btnCreateAppointView;
        private Button btnDeleteAppointments;
        private Button btnViewAllAppointmentsView;
        private Button btnUpdateApps;
    }
}