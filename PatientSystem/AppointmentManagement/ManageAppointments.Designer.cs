namespace PresentationLayer
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
            btnReturn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(76, 50);
            label1.Name = "label1";
            label1.Size = new Size(232, 23);
            label1.TabIndex = 1;
            label1.Text = "Manage Appointments";
            // 
            // btnCreateAppointView
            // 
            btnCreateAppointView.BackColor = SystemColors.Info;
            btnCreateAppointView.Location = new Point(76, 110);
            btnCreateAppointView.Name = "btnCreateAppointView";
            btnCreateAppointView.Size = new Size(232, 23);
            btnCreateAppointView.TabIndex = 2;
            btnCreateAppointView.Text = "CREATE APPOINTMENT";
            btnCreateAppointView.UseVisualStyleBackColor = false;
            btnCreateAppointView.Click += btnCreateAppointView_Click;
            // 
            // btnDeleteAppointments
            // 
            btnDeleteAppointments.BackColor = SystemColors.Info;
            btnDeleteAppointments.Location = new Point(76, 194);
            btnDeleteAppointments.Name = "btnDeleteAppointments";
            btnDeleteAppointments.Size = new Size(232, 27);
            btnDeleteAppointments.TabIndex = 3;
            btnDeleteAppointments.Text = "DELETE APPOINTMENTS";
            btnDeleteAppointments.UseVisualStyleBackColor = false;
            btnDeleteAppointments.Click += btnDeleteAppointments_Click;
            // 
            // btnViewAllAppointmentsView
            // 
            btnViewAllAppointmentsView.BackColor = SystemColors.Info;
            btnViewAllAppointmentsView.Location = new Point(76, 153);
            btnViewAllAppointmentsView.Name = "btnViewAllAppointmentsView";
            btnViewAllAppointmentsView.Size = new Size(232, 23);
            btnViewAllAppointmentsView.TabIndex = 4;
            btnViewAllAppointmentsView.Text = "VIEW APPOINTMENTS";
            btnViewAllAppointmentsView.UseVisualStyleBackColor = false;
            btnViewAllAppointmentsView.Click += btnViewAllAppointmentsView_Click;
            // 
            // btnUpdateApps
            // 
            btnUpdateApps.BackColor = SystemColors.Info;
            btnUpdateApps.Location = new Point(76, 245);
            btnUpdateApps.Name = "btnUpdateApps";
            btnUpdateApps.Size = new Size(232, 25);
            btnUpdateApps.TabIndex = 5;
            btnUpdateApps.Text = "UPDATE APPOINTMENTS";
            btnUpdateApps.UseVisualStyleBackColor = false;
            btnUpdateApps.Click += btnUpdateApps_Click;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = SystemColors.Info;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.Location = new Point(12, 410);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(151, 28);
            btnReturn.TabIndex = 6;
            btnReturn.Text = "Return to main menu";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // ManageAppointments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 450);
            Controls.Add(btnReturn);
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
        private Button btnReturn;
    }
}