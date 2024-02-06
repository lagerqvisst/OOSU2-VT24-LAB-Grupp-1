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
            SuspendLayout();
            // 
            // btnCreateNewPatient
            // 
            btnCreateNewPatient.Location = new Point(87, 108);
            btnCreateNewPatient.Name = "btnCreateNewPatient";
            btnCreateNewPatient.Size = new Size(143, 32);
            btnCreateNewPatient.TabIndex = 0;
            btnCreateNewPatient.Text = "CREATE NEW PATIENT";
            btnCreateNewPatient.UseVisualStyleBackColor = true;
            btnCreateNewPatient.Click += btnCreateNewPatient_Click;
            // 
            // btnUpdatePatient
            // 
            btnUpdatePatient.Location = new Point(87, 157);
            btnUpdatePatient.Name = "btnUpdatePatient";
            btnUpdatePatient.Size = new Size(143, 33);
            btnUpdatePatient.TabIndex = 1;
            btnUpdatePatient.Text = "UPDATE PATIENT";
            btnUpdatePatient.UseVisualStyleBackColor = true;
            btnUpdatePatient.Click += btnUpdatePatient_Click;
            // 
            // btnViewPatients
            // 
            btnViewPatients.Location = new Point(87, 207);
            btnViewPatients.Name = "btnViewPatients";
            btnViewPatients.Size = new Size(143, 34);
            btnViewPatients.TabIndex = 2;
            btnViewPatients.Text = "VIEW PATIENTS";
            btnViewPatients.UseVisualStyleBackColor = true;
            btnViewPatients.Click += btnViewPatients_Click;
            // 
            // btnDeletePatient
            // 
            btnDeletePatient.Location = new Point(87, 264);
            btnDeletePatient.Name = "btnDeletePatient";
            btnDeletePatient.Size = new Size(143, 36);
            btnDeletePatient.TabIndex = 3;
            btnDeletePatient.Text = "DELETE PATIENT";
            btnDeletePatient.UseVisualStyleBackColor = true;
            btnDeletePatient.Click += btnDeletePatient_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 54);
            label1.Name = "label1";
            label1.Size = new Size(145, 18);
            label1.TabIndex = 4;
            label1.Text = "Manage Patients";
            // 
            // btnReturnToMainMenu
            // 
            btnReturnToMainMenu.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnReturnToMainMenu.Location = new Point(100, 369);
            btnReturnToMainMenu.Name = "btnReturnToMainMenu";
            btnReturnToMainMenu.Size = new Size(118, 23);
            btnReturnToMainMenu.TabIndex = 5;
            btnReturnToMainMenu.Text = "Return to main menu";
            btnReturnToMainMenu.UseVisualStyleBackColor = true;
            btnReturnToMainMenu.Click += btnReturnToMainMenu_Click;
            // 
            // ManagePatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 404);
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
    }
}