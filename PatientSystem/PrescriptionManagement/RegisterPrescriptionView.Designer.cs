namespace PresentationLayer.PrescriptionManagement
{
    partial class RegisterPrescriptionView
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
            dataGridviewDrugs = new DataGridView();
            label1 = new Label();
            dataGridViewPatients = new DataGridView();
            label2 = new Label();
            dataGridViewPrescribedDrugs = new DataGridView();
            label3 = new Label();
            btnCreatePrescription = new Button();
            labelSummary = new Label();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridviewDrugs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrescribedDrugs).BeginInit();
            SuspendLayout();
            // 
            // dataGridviewDrugs
            // 
            dataGridviewDrugs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridviewDrugs.Location = new Point(28, 290);
            dataGridviewDrugs.Name = "dataGridviewDrugs";
            dataGridviewDrugs.Size = new Size(532, 202);
            dataGridviewDrugs.TabIndex = 0;
            dataGridviewDrugs.CellClick += dataGridviewDrugs_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 271);
            label1.Name = "label1";
            label1.Size = new Size(364, 16);
            label1.TabIndex = 1;
            label1.Text = "Drugs from online database (Select to add to prescription)";
            // 
            // dataGridViewPatients
            // 
            dataGridViewPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPatients.Location = new Point(28, 69);
            dataGridViewPatients.Name = "dataGridViewPatients";
            dataGridViewPatients.Size = new Size(532, 180);
            dataGridViewPatients.TabIndex = 2;
            dataGridViewPatients.CellClick += dataGridViewPatients_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 50);
            label2.Name = "label2";
            label2.Size = new Size(101, 16);
            label2.TabIndex = 3;
            label2.Text = "Select a patient";
            // 
            // dataGridViewPrescribedDrugs
            // 
            dataGridViewPrescribedDrugs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPrescribedDrugs.Location = new Point(605, 71);
            dataGridViewPrescribedDrugs.Name = "dataGridViewPrescribedDrugs";
            dataGridViewPrescribedDrugs.Size = new Size(403, 141);
            dataGridViewPrescribedDrugs.TabIndex = 4;
            dataGridViewPrescribedDrugs.CellClick += dataGridViewPrescribedDrugs_CellClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(605, 52);
            label3.Name = "label3";
            label3.Size = new Size(222, 16);
            label3.TabIndex = 5;
            label3.Text = "Prescribed drugs (Click to remove)";
            // 
            // btnCreatePrescription
            // 
            btnCreatePrescription.BackColor = Color.LimeGreen;
            btnCreatePrescription.Cursor = Cursors.Hand;
            btnCreatePrescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreatePrescription.Location = new Point(605, 290);
            btnCreatePrescription.Name = "btnCreatePrescription";
            btnCreatePrescription.Size = new Size(403, 47);
            btnCreatePrescription.TabIndex = 6;
            btnCreatePrescription.Text = "REGISTER PRESCRIPTION";
            btnCreatePrescription.UseVisualStyleBackColor = false;
            btnCreatePrescription.Click += btnCreatePrescription_Click;
            // 
            // labelSummary
            // 
            labelSummary.AutoSize = true;
            labelSummary.Location = new Point(605, 353);
            labelSummary.Name = "labelSummary";
            labelSummary.Size = new Size(61, 15);
            labelSummary.TabIndex = 7;
            labelSummary.Text = "Summary:";
            // 
            // btnReturn
            // 
            btnReturn.BackColor = SystemColors.Info;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.Location = new Point(28, 514);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(101, 23);
            btnReturn.TabIndex = 8;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // RegisterPrescriptionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1151, 549);
            Controls.Add(btnReturn);
            Controls.Add(labelSummary);
            Controls.Add(btnCreatePrescription);
            Controls.Add(label3);
            Controls.Add(dataGridViewPrescribedDrugs);
            Controls.Add(label2);
            Controls.Add(dataGridViewPatients);
            Controls.Add(label1);
            Controls.Add(dataGridviewDrugs);
            Name = "RegisterPrescriptionView";
            Text = "RegisterPrescriptionView";
            ((System.ComponentModel.ISupportInitialize)dataGridviewDrugs).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrescribedDrugs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridviewDrugs;
        private Label label1;
        private DataGridView dataGridViewPatients;
        private Label label2;
        private DataGridView dataGridViewPrescribedDrugs;
        private Label label3;
        private Button btnCreatePrescription;
        private Label labelSummary;
        private Button btnReturn;
    }
}