namespace PresentationLayer
{
    partial class ViewPatients
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
            dataGridView_Patients = new DataGridView();
            returnFromView = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Patients).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_Patients
            // 
            dataGridView_Patients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Patients.Location = new Point(22, 70);
            dataGridView_Patients.Name = "dataGridView_Patients";
            dataGridView_Patients.Size = new Size(766, 305);
            dataGridView_Patients.TabIndex = 0;
            // 
            // returnFromView
            // 
            returnFromView.BackColor = SystemColors.Info;
            returnFromView.Cursor = Cursors.Hand;
            returnFromView.Location = new Point(22, 395);
            returnFromView.Name = "returnFromView";
            returnFromView.Size = new Size(104, 27);
            returnFromView.TabIndex = 1;
            returnFromView.Text = "Return";
            returnFromView.UseVisualStyleBackColor = false;
            returnFromView.Click += returnFromView_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 32);
            label1.Name = "label1";
            label1.Size = new Size(223, 23);
            label1.TabIndex = 2;
            label1.Text = "Patients stored in system";
            // 
            // ViewPatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 459);
            Controls.Add(label1);
            Controls.Add(returnFromView);
            Controls.Add(dataGridView_Patients);
            Name = "ViewPatients";
            Text = "ViewPatients";
            ((System.ComponentModel.ISupportInitialize)dataGridView_Patients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_Patients;
        private Button returnFromView;
        private Label label1;
    }
}