namespace PresentationLayer
{
    partial class UpdateAppointmentView
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
            dataGridViewAppointments = new DataGridView();
            label1 = new Label();
            btnSelectAppToUpdate = new Button();
            btnRefreshGrid = new Button();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAppointments
            // 
            dataGridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAppointments.Location = new Point(37, 68);
            dataGridViewAppointments.Name = "dataGridViewAppointments";
            dataGridViewAppointments.Size = new Size(723, 267);
            dataGridViewAppointments.TabIndex = 0;
            dataGridViewAppointments.CellClick += dataGridViewAppointments_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 31);
            label1.Name = "label1";
            label1.Size = new Size(432, 23);
            label1.TabIndex = 1;
            label1.Text = "Select the appointment you want to update";
            // 
            // btnSelectAppToUpdate
            // 
            btnSelectAppToUpdate.BackColor = Color.LimeGreen;
            btnSelectAppToUpdate.Cursor = Cursors.Hand;
            btnSelectAppToUpdate.ForeColor = SystemColors.ActiveCaptionText;
            btnSelectAppToUpdate.Location = new Point(37, 352);
            btnSelectAppToUpdate.Name = "btnSelectAppToUpdate";
            btnSelectAppToUpdate.Size = new Size(151, 36);
            btnSelectAppToUpdate.TabIndex = 2;
            btnSelectAppToUpdate.Text = "SELECT APPOINTMENT";
            btnSelectAppToUpdate.UseVisualStyleBackColor = false;
            btnSelectAppToUpdate.Click += btnSelectAppToUpdate_Click;
            // 
            // btnRefreshGrid
            // 
            btnRefreshGrid.Location = new Point(662, 352);
            btnRefreshGrid.Name = "btnRefreshGrid";
            btnRefreshGrid.Size = new Size(98, 26);
            btnRefreshGrid.TabIndex = 3;
            btnRefreshGrid.Text = "Refresh data";
            btnRefreshGrid.UseVisualStyleBackColor = true;
            btnRefreshGrid.Click += btnRefreshGrid_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(43, 420);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(80, 22);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // UpdateAppointmentView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReturn);
            Controls.Add(btnRefreshGrid);
            Controls.Add(btnSelectAppToUpdate);
            Controls.Add(label1);
            Controls.Add(dataGridViewAppointments);
            Name = "UpdateAppointmentView";
            Text = "UpdateAppointmentView";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewAppointments;
        private Label label1;
        private Button btnSelectAppToUpdate;
        private Button btnRefreshGrid;
        private Button btnReturn;
    }
}