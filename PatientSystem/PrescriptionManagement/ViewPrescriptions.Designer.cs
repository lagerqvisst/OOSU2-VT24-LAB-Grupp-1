namespace PresentationLayer.PrescriptionManagement
{
    partial class ViewPrescriptions
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
            dataGridViewPrescriptions = new DataGridView();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrescriptions).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 46);
            label1.Name = "label1";
            label1.Size = new Size(243, 23);
            label1.TabIndex = 0;
            label1.Text = "Prescriptions in system";
            // 
            // dataGridViewPrescriptions
            // 
            dataGridViewPrescriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPrescriptions.Location = new Point(23, 117);
            dataGridViewPrescriptions.Name = "dataGridViewPrescriptions";
            dataGridViewPrescriptions.Size = new Size(702, 180);
            dataGridViewPrescriptions.TabIndex = 1;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(33, 363);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(68, 29);
            btnReturn.TabIndex = 2;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // ViewPrescriptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReturn);
            Controls.Add(dataGridViewPrescriptions);
            Controls.Add(label1);
            Name = "ViewPrescriptions";
            Text = "ViewPrescriptions";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrescriptions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewPrescriptions;
        private Button btnReturn;
    }
}