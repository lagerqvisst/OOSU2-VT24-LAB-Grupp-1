namespace PresentationLayer
{
    partial class DeleteAppointmentsView
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
            btnReturnFromDelete = new Button();
            dataGridViewAppointments = new DataGridView();
            btnDeleteSelectedAppointment = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).BeginInit();
            SuspendLayout();
            // 
            // btnReturnFromDelete
            // 
            btnReturnFromDelete.Location = new Point(45, 378);
            btnReturnFromDelete.Name = "btnReturnFromDelete";
            btnReturnFromDelete.Size = new Size(75, 23);
            btnReturnFromDelete.TabIndex = 0;
            btnReturnFromDelete.Text = "Return";
            btnReturnFromDelete.UseVisualStyleBackColor = true;
            btnReturnFromDelete.Click += btnReturnFromDelete_Click;
            // 
            // dataGridViewAppointments
            // 
            dataGridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAppointments.Location = new Point(45, 65);
            dataGridViewAppointments.Name = "dataGridViewAppointments";
            dataGridViewAppointments.Size = new Size(570, 211);
            dataGridViewAppointments.TabIndex = 1;
            dataGridViewAppointments.CellClick += dataGridViewAppointments_CellClick;
            // 
            // btnDeleteSelectedAppointment
            // 
            btnDeleteSelectedAppointment.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteSelectedAppointment.ForeColor = Color.IndianRed;
            btnDeleteSelectedAppointment.Location = new Point(47, 310);
            btnDeleteSelectedAppointment.Name = "btnDeleteSelectedAppointment";
            btnDeleteSelectedAppointment.Size = new Size(151, 30);
            btnDeleteSelectedAppointment.TabIndex = 2;
            btnDeleteSelectedAppointment.Text = "DELETE APPOINTMENT";
            btnDeleteSelectedAppointment.UseVisualStyleBackColor = true;
            btnDeleteSelectedAppointment.Click += btnDeleteSelectedAppointment_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(45, 28);
            label1.Name = "label1";
            label1.Size = new Size(360, 23);
            label1.TabIndex = 3;
            label1.Text = "Select an appointment you want to delete";
            // 
            // DeleteAppointmentsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnDeleteSelectedAppointment);
            Controls.Add(dataGridViewAppointments);
            Controls.Add(btnReturnFromDelete);
            Name = "DeleteAppointmentsView";
            Text = "DeleteAppointmentsView";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReturnFromDelete;
        private DataGridView dataGridViewAppointments;
        private Button btnDeleteSelectedAppointment;
        private Label label1;
    }
}