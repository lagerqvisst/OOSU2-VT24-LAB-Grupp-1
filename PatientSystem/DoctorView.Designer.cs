namespace PresentationLayer
{
    partial class DoctorView
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
            labelSignedInAs = new Label();
            label2 = new Label();
            btnManagePrescriptions = new Button();
            labeltreatment = new Label();
            btnManageTreatments = new Button();
            btnSignOutDoctor = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(152, 25);
            label1.Name = "label1";
            label1.Size = new Size(109, 23);
            label1.TabIndex = 0;
            label1.Text = "Main Menu";
            // 
            // labelSignedInAs
            // 
            labelSignedInAs.AutoSize = true;
            labelSignedInAs.Location = new Point(152, 76);
            labelSignedInAs.Name = "labelSignedInAs";
            labelSignedInAs.Size = new Size(69, 15);
            labelSignedInAs.TabIndex = 1;
            labelSignedInAs.Text = "doctor view";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(88, 120);
            label2.Name = "label2";
            label2.Size = new Size(252, 15);
            label2.TabIndex = 2;
            label2.Text = "Register and manage prescriptions for patients";
            // 
            // btnManagePrescriptions
            // 
            btnManagePrescriptions.BackColor = Color.Gold;
            btnManagePrescriptions.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManagePrescriptions.Location = new Point(83, 168);
            btnManagePrescriptions.Name = "btnManagePrescriptions";
            btnManagePrescriptions.Size = new Size(263, 25);
            btnManagePrescriptions.TabIndex = 3;
            btnManagePrescriptions.Text = "Manage Prescriptions";
            btnManagePrescriptions.UseVisualStyleBackColor = false;
            btnManagePrescriptions.Click += btnManagePrescriptions_Click;
            // 
            // labeltreatment
            // 
            labeltreatment.AutoSize = true;
            labeltreatment.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labeltreatment.Location = new Point(88, 230);
            labeltreatment.Name = "labeltreatment";
            labeltreatment.Size = new Size(243, 15);
            labeltreatment.TabIndex = 4;
            labeltreatment.Text = "Register and manage treatments for patients";
            // 
            // btnManageTreatments
            // 
            btnManageTreatments.BackColor = Color.SkyBlue;
            btnManageTreatments.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageTreatments.Location = new Point(88, 261);
            btnManageTreatments.Name = "btnManageTreatments";
            btnManageTreatments.Size = new Size(256, 29);
            btnManageTreatments.TabIndex = 5;
            btnManageTreatments.Text = "Manage Treatments";
            btnManageTreatments.UseVisualStyleBackColor = false;
            // 
            // btnSignOutDoctor
            // 
            btnSignOutDoctor.Location = new Point(152, 333);
            btnSignOutDoctor.Name = "btnSignOutDoctor";
            btnSignOutDoctor.Size = new Size(121, 24);
            btnSignOutDoctor.TabIndex = 6;
            btnSignOutDoctor.Text = "Sign out";
            btnSignOutDoctor.UseVisualStyleBackColor = true;
            // 
            // DoctorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 387);
            Controls.Add(btnSignOutDoctor);
            Controls.Add(btnManageTreatments);
            Controls.Add(labeltreatment);
            Controls.Add(btnManagePrescriptions);
            Controls.Add(label2);
            Controls.Add(labelSignedInAs);
            Controls.Add(label1);
            Name = "DoctorView";
            Text = "DoctorView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelSignedInAs;
        private Label label2;
        private Button btnManagePrescriptions;
        private Label labeltreatment;
        private Button btnManageTreatments;
        private Button btnSignOutDoctor;
    }
}