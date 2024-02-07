namespace PresentationLayer
{
    partial class CreateAppointment
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
            btnReturnFromCreate = new Button();
            dataGridViewPatients = new DataGridView();
            dataGridViewDoctors = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            textBoxDateAppointment = new TextBox();
            label3 = new Label();
            textBoxReasonAppointment = new TextBox();
            textBoxReason = new Label();
            btnScheduleAppointment = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctors).BeginInit();
            SuspendLayout();
            // 
            // btnReturnFromCreate
            // 
            btnReturnFromCreate.Location = new Point(23, 515);
            btnReturnFromCreate.Name = "btnReturnFromCreate";
            btnReturnFromCreate.Size = new Size(162, 50);
            btnReturnFromCreate.TabIndex = 0;
            btnReturnFromCreate.Text = "Return";
            btnReturnFromCreate.UseVisualStyleBackColor = true;
            btnReturnFromCreate.Click += btnReturnFromCreate_Click;
            // 
            // dataGridViewPatients
            // 
            dataGridViewPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPatients.Location = new Point(23, 49);
            dataGridViewPatients.Name = "dataGridViewPatients";
            dataGridViewPatients.Size = new Size(507, 192);
            dataGridViewPatients.TabIndex = 1;
            dataGridViewPatients.CellClick += dataGridViewPatients_CellClick;
            // 
            // dataGridViewDoctors
            // 
            dataGridViewDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDoctors.Location = new Point(23, 295);
            dataGridViewDoctors.Name = "dataGridViewDoctors";
            dataGridViewDoctors.Size = new Size(507, 151);
            dataGridViewDoctors.TabIndex = 2;
            dataGridViewDoctors.CellClick += dataGridViewDoctors_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 31);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 3;
            label1.Text = "Select patient";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 277);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 4;
            label2.Text = "Select doctor";
            // 
            // textBoxDateAppointment
            // 
            textBoxDateAppointment.Location = new Point(619, 49);
            textBoxDateAppointment.Name = "textBoxDateAppointment";
            textBoxDateAppointment.PlaceholderText = "Format: \"yyyy-mm-dd\"";
            textBoxDateAppointment.Size = new Size(371, 23);
            textBoxDateAppointment.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(619, 31);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 6;
            label3.Text = "Enter a date";
            // 
            // textBoxReasonAppointment
            // 
            textBoxReasonAppointment.Location = new Point(619, 133);
            textBoxReasonAppointment.Multiline = true;
            textBoxReasonAppointment.Name = "textBoxReasonAppointment";
            textBoxReasonAppointment.PlaceholderText = "Eg. ear drum rapture";
            textBoxReasonAppointment.Size = new Size(371, 108);
            textBoxReasonAppointment.TabIndex = 7;
            // 
            // textBoxReason
            // 
            textBoxReason.AutoSize = true;
            textBoxReason.Location = new Point(619, 115);
            textBoxReason.Name = "textBoxReason";
            textBoxReason.Size = new Size(135, 15);
            textBoxReason.TabIndex = 8;
            textBoxReason.Text = "Reason for appointment";
            // 
            // btnScheduleAppointment
            // 
            btnScheduleAppointment.Location = new Point(619, 358);
            btnScheduleAppointment.Name = "btnScheduleAppointment";
            btnScheduleAppointment.Size = new Size(359, 46);
            btnScheduleAppointment.TabIndex = 9;
            btnScheduleAppointment.Text = "Schedule Appointment";
            btnScheduleAppointment.UseVisualStyleBackColor = true;
            btnScheduleAppointment.Click += btnScheduleAppointment_Click;
            // 
            // CreateAppointment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 602);
            Controls.Add(btnScheduleAppointment);
            Controls.Add(textBoxReason);
            Controls.Add(textBoxReasonAppointment);
            Controls.Add(label3);
            Controls.Add(textBoxDateAppointment);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewDoctors);
            Controls.Add(dataGridViewPatients);
            Controls.Add(btnReturnFromCreate);
            Name = "CreateAppointment";
            Text = "CreateAppointment";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReturnFromCreate;
        private DataGridView dataGridViewPatients;
        private DataGridView dataGridViewDoctors;
        private Label label1;
        private Label label2;
        private TextBox textBoxDateAppointment;
        private Label label3;
        private TextBox textBoxReasonAppointment;
        private Label textBoxReason;
        private Button btnScheduleAppointment;
    }
}