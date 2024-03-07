namespace PresentationLayer
{
    partial class UpdatePatientView
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
            btnReturnFromUpdateview = new Button();
            label1 = new Label();
            dataGridView_PatientsToUpdate = new DataGridView();
            btnSelectPatientToUpdate = new Button();
            btnRefreshData = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_PatientsToUpdate).BeginInit();
            SuspendLayout();
            // 
            // btnReturnFromUpdateview
            // 
            btnReturnFromUpdateview.BackColor = SystemColors.Info;
            btnReturnFromUpdateview.Cursor = Cursors.Hand;
            btnReturnFromUpdateview.Location = new Point(49, 386);
            btnReturnFromUpdateview.Name = "btnReturnFromUpdateview";
            btnReturnFromUpdateview.Size = new Size(119, 31);
            btnReturnFromUpdateview.TabIndex = 0;
            btnReturnFromUpdateview.Text = "Return";
            btnReturnFromUpdateview.UseVisualStyleBackColor = false;
            btnReturnFromUpdateview.Click += btnReturnFromUpdateview_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(49, 18);
            label1.Name = "label1";
            label1.Size = new Size(430, 23);
            label1.TabIndex = 1;
            label1.Text = "Begin by selecting the patient you wish to update.";
            // 
            // dataGridView_PatientsToUpdate
            // 
            dataGridView_PatientsToUpdate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_PatientsToUpdate.Location = new Point(49, 57);
            dataGridView_PatientsToUpdate.Name = "dataGridView_PatientsToUpdate";
            dataGridView_PatientsToUpdate.Size = new Size(679, 216);
            dataGridView_PatientsToUpdate.TabIndex = 2;
            dataGridView_PatientsToUpdate.CellClick += dataGridView_PatientsToUpdate_CellClick;
            // 
            // btnSelectPatientToUpdate
            // 
            btnSelectPatientToUpdate.BackColor = Color.LimeGreen;
            btnSelectPatientToUpdate.Cursor = Cursors.Hand;
            btnSelectPatientToUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectPatientToUpdate.Location = new Point(49, 313);
            btnSelectPatientToUpdate.Name = "btnSelectPatientToUpdate";
            btnSelectPatientToUpdate.Size = new Size(195, 34);
            btnSelectPatientToUpdate.TabIndex = 3;
            btnSelectPatientToUpdate.Text = "Click to see update options";
            btnSelectPatientToUpdate.UseVisualStyleBackColor = false;
            btnSelectPatientToUpdate.Click += btnSelectPatientToUpdate_Click;
            // 
            // btnRefreshData
            // 
            btnRefreshData.BackColor = SystemColors.Info;
            btnRefreshData.Cursor = Cursors.Hand;
            btnRefreshData.Location = new Point(633, 313);
            btnRefreshData.Name = "btnRefreshData";
            btnRefreshData.Size = new Size(95, 28);
            btnRefreshData.TabIndex = 4;
            btnRefreshData.Text = "Refresh Data";
            btnRefreshData.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnRefreshData.UseVisualStyleBackColor = false;
            btnRefreshData.Click += btnRefreshData_Click;
            // 
            // UpdatePatientView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefreshData);
            Controls.Add(btnSelectPatientToUpdate);
            Controls.Add(dataGridView_PatientsToUpdate);
            Controls.Add(label1);
            Controls.Add(btnReturnFromUpdateview);
            Name = "UpdatePatientView";
            Text = "UpdatePatientView";
            ((System.ComponentModel.ISupportInitialize)dataGridView_PatientsToUpdate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReturnFromUpdateview;
        private Label label1;
        private DataGridView dataGridView_PatientsToUpdate;
        private Button btnSelectPatientToUpdate;
        private Button btnRefreshData;
    }
}