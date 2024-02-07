namespace PresentationLayer
{
    partial class ReceptionistView
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
            labelrecepview = new Label();
            mainLabelRecepview = new Label();
            btnManagePatients = new Button();
            btnManageAppointments = new Button();
            label1 = new Label();
            label2 = new Label();
            btnBacktoSignin = new Button();
            SuspendLayout();
            // 
            // labelrecepview
            // 
            labelrecepview.AutoSize = true;
            labelrecepview.Location = new Point(168, 84);
            labelrecepview.Name = "labelrecepview";
            labelrecepview.Size = new Size(93, 15);
            labelrecepview.TabIndex = 0;
            labelrecepview.Text = "receptionst view";
            // 
            // mainLabelRecepview
            // 
            mainLabelRecepview.AutoSize = true;
            mainLabelRecepview.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainLabelRecepview.Location = new Point(168, 26);
            mainLabelRecepview.Name = "mainLabelRecepview";
            mainLabelRecepview.Size = new Size(109, 23);
            mainLabelRecepview.TabIndex = 1;
            mainLabelRecepview.Text = "Main Menu";
            // 
            // btnManagePatients
            // 
            btnManagePatients.BackColor = Color.YellowGreen;
            btnManagePatients.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManagePatients.Location = new Point(25, 176);
            btnManagePatients.Name = "btnManagePatients";
            btnManagePatients.Size = new Size(368, 24);
            btnManagePatients.TabIndex = 2;
            btnManagePatients.Text = "Manage Patients";
            btnManagePatients.UseVisualStyleBackColor = false;
            btnManagePatients.Click += btnManagePatients_Click;
            // 
            // btnManageAppointments
            // 
            btnManageAppointments.BackColor = Color.RosyBrown;
            btnManageAppointments.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageAppointments.Location = new Point(25, 262);
            btnManageAppointments.Name = "btnManageAppointments";
            btnManageAppointments.Size = new Size(368, 26);
            btnManageAppointments.TabIndex = 3;
            btnManageAppointments.Text = "Manage Appointsments";
            btnManageAppointments.UseVisualStyleBackColor = false;
            btnManageAppointments.Click += btnManageAppointments_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(45, 146);
            label1.Name = "label1";
            label1.Size = new Size(336, 15);
            label1.TabIndex = 4;
            label1.Text = "Register new patients to the system or manage stored patients.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 236);
            label2.Name = "label2";
            label2.Size = new Size(368, 13);
            label2.TabIndex = 5;
            label2.Text = "Create new appointments or make changes to already booked appointments.";
            // 
            // btnBacktoSignin
            // 
            btnBacktoSignin.Location = new Point(168, 333);
            btnBacktoSignin.Name = "btnBacktoSignin";
            btnBacktoSignin.Size = new Size(82, 25);
            btnBacktoSignin.TabIndex = 6;
            btnBacktoSignin.Text = "Sign out";
            btnBacktoSignin.UseVisualStyleBackColor = true;
            btnBacktoSignin.Click += btnBacktoSignin_Click;
            // 
            // ReceptionistView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 383);
            Controls.Add(btnBacktoSignin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnManageAppointments);
            Controls.Add(btnManagePatients);
            Controls.Add(mainLabelRecepview);
            Controls.Add(labelrecepview);
            Name = "ReceptionistView";
            Text = "ReceptionistView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelrecepview;
        private Label mainLabelRecepview;
        private Button btnManagePatients;
        private Button btnManageAppointments;
        private Label label1;
        private Label label2;
        private Button btnBacktoSignin;
    }
}