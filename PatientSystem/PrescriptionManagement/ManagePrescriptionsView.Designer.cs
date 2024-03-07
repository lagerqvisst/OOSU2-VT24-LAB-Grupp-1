namespace PresentationLayer.PrescriptionManagement
{
    partial class ManagePrescriptionsView
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
            btnRegNewPrescrip = new Button();
            label1 = new Label();
            btnViewPrescriptions = new Button();
            btnReturn = new Button();
            SuspendLayout();
            // 
            // btnRegNewPrescrip
            // 
            btnRegNewPrescrip.BackColor = SystemColors.Info;
            btnRegNewPrescrip.Cursor = Cursors.Hand;
            btnRegNewPrescrip.Location = new Point(122, 103);
            btnRegNewPrescrip.Name = "btnRegNewPrescrip";
            btnRegNewPrescrip.Size = new Size(225, 25);
            btnRegNewPrescrip.TabIndex = 0;
            btnRegNewPrescrip.Text = "REGISTER PRESCRIPTION";
            btnRegNewPrescrip.UseVisualStyleBackColor = false;
            btnRegNewPrescrip.Click += btnRegNewPrescrip_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(122, 57);
            label1.Name = "label1";
            label1.Size = new Size(214, 22);
            label1.TabIndex = 1;
            label1.Text = "Manage Prescriptions";
            // 
            // btnViewPrescriptions
            // 
            btnViewPrescriptions.BackColor = SystemColors.Info;
            btnViewPrescriptions.Cursor = Cursors.Hand;
            btnViewPrescriptions.Location = new Point(122, 158);
            btnViewPrescriptions.Name = "btnViewPrescriptions";
            btnViewPrescriptions.Size = new Size(225, 26);
            btnViewPrescriptions.TabIndex = 2;
            btnViewPrescriptions.Text = "VIEW PRESCRIPTIONS";
            btnViewPrescriptions.UseVisualStyleBackColor = false;
            btnViewPrescriptions.Click += btnViewPrescriptions_Click;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = SystemColors.Info;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.Location = new Point(12, 412);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(152, 26);
            btnReturn.TabIndex = 3;
            btnReturn.Text = "Return to main menu";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // ManagePrescriptionsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 450);
            Controls.Add(btnReturn);
            Controls.Add(btnViewPrescriptions);
            Controls.Add(label1);
            Controls.Add(btnRegNewPrescrip);
            Name = "ManagePrescriptionsView";
            Text = "ManagePrescriptionsView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegNewPrescrip;
        private Label label1;
        private Button btnViewPrescriptions;
        private Button btnReturn;
    }
}