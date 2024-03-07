namespace PresentationLayer
{
    partial class ManagePatients
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
            btnCreateNewPatient = new Button();
            btnUpdatePatient = new Button();
            btnViewPatients = new Button();
            btnDeletePatient = new Button();
            label1 = new Label();
            btnReturnToMainMenu = new Button();
            btnSearchPatients = new Button();
            SuspendLayout();
            // 
            // btnCreateNewPatient
            // 
            btnCreateNewPatient.BackColor = SystemColors.Info;
            btnCreateNewPatient.Cursor = Cursors.Hand;
            btnCreateNewPatient.Location = new Point(87, 96);
            btnCreateNewPatient.Name = "btnCreateNewPatient";
            btnCreateNewPatient.Size = new Size(143, 32);
            btnCreateNewPatient.TabIndex = 0;
            btnCreateNewPatient.Text = "CREATE NEW PATIENT";
            btnCreateNewPatient.UseVisualStyleBackColor = false;
            btnCreateNewPatient.Click += btnCreateNewPatient_Click;
            // 
            // btnUpdatePatient
            // 
            btnUpdatePatient.BackColor = SystemColors.Info;
            btnUpdatePatient.Cursor = Cursors.Hand;
            btnUpdatePatient.Location = new Point(87, 150);
            btnUpdatePatient.Name = "btnUpdatePatient";
            btnUpdatePatient.Size = new Size(143, 33);
            btnUpdatePatient.TabIndex = 1;
            btnUpdatePatient.Text = "UPDATE PATIENT";
            btnUpdatePatient.UseVisualStyleBackColor = false;
            btnUpdatePatient.Click += btnUpdatePatient_Click;
            // 
            // btnViewPatients
            // 
            btnViewPatients.BackColor = SystemColors.Info;
            btnViewPatients.Cursor = Cursors.Hand;
            btnViewPatients.Location = new Point(87, 200);
            btnViewPatients.Name = "btnViewPatients";
            btnViewPatients.Size = new Size(143, 34);
            btnViewPatients.TabIndex = 2;
            btnViewPatients.Text = "VIEW PATIENTS";
            btnViewPatients.UseVisualStyleBackColor = false;
            btnViewPatients.Click += btnViewPatients_Click;
            // 
            // btnDeletePatient
            // 
            btnDeletePatient.BackColor = SystemColors.Info;
            btnDeletePatient.Cursor = Cursors.Hand;
            btnDeletePatient.Location = new Point(87, 253);
            btnDeletePatient.Name = "btnDeletePatient";
            btnDeletePatient.Size = new Size(143, 36);
            btnDeletePatient.TabIndex = 3;
            btnDeletePatient.Text = "DELETE PATIENT";
            btnDeletePatient.UseVisualStyleBackColor = false;
            btnDeletePatient.Click += btnDeletePatient_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 54);
            label1.Name = "label1";
            label1.Size = new Size(135, 19);
            label1.TabIndex = 4;
            label1.Text = "Manage Patients";
            // 
            // btnReturnToMainMenu
            // 
            btnReturnToMainMenu.BackColor = SystemColors.Info;
            btnReturnToMainMenu.Cursor = Cursors.Hand;
            btnReturnToMainMenu.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnReturnToMainMenu.Location = new Point(2, 379);
            btnReturnToMainMenu.Name = "btnReturnToMainMenu";
            btnReturnToMainMenu.Size = new Size(118, 23);
            btnReturnToMainMenu.TabIndex = 5;
            btnReturnToMainMenu.Text = "Return to main menu";
            btnReturnToMainMenu.UseVisualStyleBackColor = false;
            btnReturnToMainMenu.Click += btnReturnToMainMenu_Click;
            // 
            // btnSearchPatients
            // 
            btnSearchPatients.BackColor = SystemColors.Info;
            btnSearchPatients.Cursor = Cursors.Hand;
            btnSearchPatients.Location = new Point(87, 311);
            btnSearchPatients.Name = "btnSearchPatients";
            btnSearchPatients.Size = new Size(143, 36);
            btnSearchPatients.TabIndex = 6;
            btnSearchPatients.Text = "SEARCH FOR PATIENTS";
            btnSearchPatients.UseVisualStyleBackColor = false;
            btnSearchPatients.Click += btnSearchPatients_Click;
            // 
            // ManagePatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 404);
            Controls.Add(btnSearchPatients);
            Controls.Add(btnReturnToMainMenu);
            Controls.Add(label1);
            Controls.Add(btnDeletePatient);
            Controls.Add(btnViewPatients);
            Controls.Add(btnUpdatePatient);
            Controls.Add(btnCreateNewPatient);
            Name = "ManagePatients";
            Text = "ManagePatients";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateNewPatient;
        private Button btnUpdatePatient;
        private Button btnViewPatients;
        private Button btnDeletePatient;
        private Label label1;
        private Button btnReturnToMainMenu;
        private Button btnSearchPatients;
    }
}