namespace PresentationLayer
{
    partial class ViewAppointments
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
            btnReturnFromViewApps = new Button();
            dataGridViewAppointments = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).BeginInit();
            SuspendLayout();
            // 
            // btnReturnFromViewApps
            // 
            btnReturnFromViewApps.Location = new Point(59, 383);
            btnReturnFromViewApps.Name = "btnReturnFromViewApps";
            btnReturnFromViewApps.Size = new Size(75, 23);
            btnReturnFromViewApps.TabIndex = 0;
            btnReturnFromViewApps.Text = "Return";
            btnReturnFromViewApps.UseVisualStyleBackColor = true;
            btnReturnFromViewApps.Click += btnReturnFromViewApps_Click;
            // 
            // dataGridViewAppointments
            // 
            dataGridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAppointments.Location = new Point(59, 96);
            dataGridViewAppointments.Name = "dataGridViewAppointments";
            dataGridViewAppointments.Size = new Size(649, 199);
            dataGridViewAppointments.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 41);
            label1.Name = "label1";
            label1.Size = new Size(250, 23);
            label1.TabIndex = 2;
            label1.Text = "Appointments in system";
            // 
            // ViewAppointments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dataGridViewAppointments);
            Controls.Add(btnReturnFromViewApps);
            Name = "ViewAppointments";
            Text = "ViewAppointments";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReturnFromViewApps;
        private DataGridView dataGridViewAppointments;
        private Label label1;
    }
}