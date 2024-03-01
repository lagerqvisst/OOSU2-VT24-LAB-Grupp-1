namespace PresentationLayer
{
    partial class DoctorViewWinforms
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
            doctorviewLabel = new Label();
            label2 = new Label();
            btnManagePrescriptions = new Button();
            btnReturn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(176, 28);
            label1.Name = "label1";
            label1.Size = new Size(109, 23);
            label1.TabIndex = 0;
            label1.Text = "Main Menu";
            // 
            // doctorviewLabel
            // 
            doctorviewLabel.AutoSize = true;
            doctorviewLabel.Location = new Point(192, 77);
            doctorviewLabel.Name = "doctorviewLabel";
            doctorviewLabel.Size = new Size(69, 15);
            doctorviewLabel.TabIndex = 1;
            doctorviewLabel.Text = "doctor view";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(147, 137);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 2;
            label2.Text = "Register prescription for patients";
            // 
            // btnManagePrescriptions
            // 
            btnManagePrescriptions.BackColor = Color.Gold;
            btnManagePrescriptions.Location = new Point(147, 155);
            btnManagePrescriptions.Name = "btnManagePrescriptions";
            btnManagePrescriptions.Size = new Size(176, 27);
            btnManagePrescriptions.TabIndex = 3;
            btnManagePrescriptions.Text = "Manage Prescriptions";
            btnManagePrescriptions.UseVisualStyleBackColor = false;
            btnManagePrescriptions.Click += btnManagePrescriptions_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(176, 247);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(109, 28);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "Sign out";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // DoctorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 315);
            Controls.Add(btnReturn);
            Controls.Add(btnManagePrescriptions);
            Controls.Add(label2);
            Controls.Add(doctorviewLabel);
            Controls.Add(label1);
            Name = "DoctorView";
            Text = "DoctorView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label doctorviewLabel;
        private Label label2;
        private Button btnManagePrescriptions;
        private Button btnReturn;
    }
}