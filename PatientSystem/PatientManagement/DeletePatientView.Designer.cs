namespace PresentationLayer
{
    partial class DeletePatientView
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
            btnReturnFromDeleteView = new Button();
            textselecttodelte = new Label();
            dataGridView_PatientsToDelete = new DataGridView();
            btn_DeleteSelectedPatient = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_PatientsToDelete).BeginInit();
            SuspendLayout();
            // 
            // btnReturnFromDeleteView
            // 
            btnReturnFromDeleteView.BackColor = SystemColors.Info;
            btnReturnFromDeleteView.Cursor = Cursors.Hand;
            btnReturnFromDeleteView.Location = new Point(26, 392);
            btnReturnFromDeleteView.Name = "btnReturnFromDeleteView";
            btnReturnFromDeleteView.Size = new Size(119, 46);
            btnReturnFromDeleteView.TabIndex = 0;
            btnReturnFromDeleteView.Text = "Return";
            btnReturnFromDeleteView.UseVisualStyleBackColor = false;
            btnReturnFromDeleteView.Click += btnReturnFromDeleteView_Click;
            // 
            // textselecttodelte
            // 
            textselecttodelte.AutoSize = true;
            textselecttodelte.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textselecttodelte.Location = new Point(26, 20);
            textselecttodelte.Name = "textselecttodelte";
            textselecttodelte.Size = new Size(303, 23);
            textselecttodelte.TabIndex = 1;
            textselecttodelte.Text = "Select a patient to remove from system";
            // 
            // dataGridView_PatientsToDelete
            // 
            dataGridView_PatientsToDelete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_PatientsToDelete.Location = new Point(26, 87);
            dataGridView_PatientsToDelete.Name = "dataGridView_PatientsToDelete";
            dataGridView_PatientsToDelete.Size = new Size(569, 173);
            dataGridView_PatientsToDelete.TabIndex = 2;
            dataGridView_PatientsToDelete.CellClick += dataGridView_PatientsToDelete_CellClick;
            // 
            // btn_DeleteSelectedPatient
            // 
            btn_DeleteSelectedPatient.BackColor = Color.LimeGreen;
            btn_DeleteSelectedPatient.Cursor = Cursors.Hand;
            btn_DeleteSelectedPatient.Font = new Font("Arial", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btn_DeleteSelectedPatient.ForeColor = Color.Black;
            btn_DeleteSelectedPatient.Location = new Point(26, 301);
            btn_DeleteSelectedPatient.Name = "btn_DeleteSelectedPatient";
            btn_DeleteSelectedPatient.Size = new Size(230, 42);
            btn_DeleteSelectedPatient.TabIndex = 3;
            btn_DeleteSelectedPatient.Text = "DELETE SELECTED PATIENT";
            btn_DeleteSelectedPatient.UseVisualStyleBackColor = false;
            btn_DeleteSelectedPatient.Click += btn_DeleteSelectedPatient_Click;
            // 
            // DeletePatientView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_DeleteSelectedPatient);
            Controls.Add(dataGridView_PatientsToDelete);
            Controls.Add(textselecttodelte);
            Controls.Add(btnReturnFromDeleteView);
            Name = "DeletePatientView";
            Text = "DeletePatientView";
            ((System.ComponentModel.ISupportInitialize)dataGridView_PatientsToDelete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReturnFromDeleteView;
        private Label textselecttodelte;
        private DataGridView dataGridView_PatientsToDelete;
        private Button btn_DeleteSelectedPatient;
    }
}