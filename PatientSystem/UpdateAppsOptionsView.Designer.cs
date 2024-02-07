namespace PresentationLayer
{
    partial class UpdateAppsOptionsView
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
            textBox_Date = new TextBox();
            label1 = new Label();
            textBoxReason = new TextBox();
            label2 = new Label();
            dataGridViewDoctors = new DataGridView();
            label3 = new Label();
            btnUpdateDate = new Button();
            btnUpdateReason = new Button();
            btnReturnFromAppUpdateOps = new Button();
            btnUpdateDoctor = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctors).BeginInit();
            SuspendLayout();
            // 
            // textBox_Date
            // 
            textBox_Date.Location = new Point(25, 74);
            textBox_Date.Name = "textBox_Date";
            textBox_Date.PlaceholderText = "yyyy-mm-dd";
            textBox_Date.Size = new Size(286, 23);
            textBox_Date.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 56);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "Change Date";
            // 
            // textBoxReason
            // 
            textBoxReason.Location = new Point(25, 140);
            textBoxReason.Name = "textBoxReason";
            textBoxReason.PlaceholderText = "eg. ear infection";
            textBoxReason.Size = new Size(286, 23);
            textBoxReason.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 122);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 3;
            label2.Text = "Change reason for appointment";
            // 
            // dataGridViewDoctors
            // 
            dataGridViewDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDoctors.Location = new Point(25, 212);
            dataGridViewDoctors.Name = "dataGridViewDoctors";
            dataGridViewDoctors.Size = new Size(276, 97);
            dataGridViewDoctors.TabIndex = 4;
            dataGridViewDoctors.CellClick += dataGridViewDoctors_CellClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 194);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 5;
            label3.Text = "Change Doctor";
            // 
            // btnUpdateDate
            // 
            btnUpdateDate.Location = new Point(317, 73);
            btnUpdateDate.Name = "btnUpdateDate";
            btnUpdateDate.Size = new Size(93, 24);
            btnUpdateDate.TabIndex = 6;
            btnUpdateDate.Text = "Update";
            btnUpdateDate.UseVisualStyleBackColor = true;
            btnUpdateDate.Click += btnUpdateDate_Click;
            // 
            // btnUpdateReason
            // 
            btnUpdateReason.Location = new Point(317, 140);
            btnUpdateReason.Name = "btnUpdateReason";
            btnUpdateReason.Size = new Size(93, 23);
            btnUpdateReason.TabIndex = 7;
            btnUpdateReason.Text = "Update";
            btnUpdateReason.UseVisualStyleBackColor = true;
            btnUpdateReason.Click += btnUpdateReason_Click;
            // 
            // btnReturnFromAppUpdateOps
            // 
            btnReturnFromAppUpdateOps.Location = new Point(31, 398);
            btnReturnFromAppUpdateOps.Name = "btnReturnFromAppUpdateOps";
            btnReturnFromAppUpdateOps.Size = new Size(71, 25);
            btnReturnFromAppUpdateOps.TabIndex = 8;
            btnReturnFromAppUpdateOps.Text = "Return";
            btnReturnFromAppUpdateOps.UseVisualStyleBackColor = true;
            btnReturnFromAppUpdateOps.Click += btnReturnFromAppUpdateOps_Click;
            // 
            // btnUpdateDoctor
            // 
            btnUpdateDoctor.Location = new Point(317, 212);
            btnUpdateDoctor.Name = "btnUpdateDoctor";
            btnUpdateDoctor.Size = new Size(93, 24);
            btnUpdateDoctor.TabIndex = 9;
            btnUpdateDoctor.Text = "Update";
            btnUpdateDoctor.UseVisualStyleBackColor = true;
            btnUpdateDoctor.Click += btnUpdateDoctor_Click;
            // 
            // UpdateAppsOptionsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 450);
            Controls.Add(btnUpdateDoctor);
            Controls.Add(btnReturnFromAppUpdateOps);
            Controls.Add(btnUpdateReason);
            Controls.Add(btnUpdateDate);
            Controls.Add(label3);
            Controls.Add(dataGridViewDoctors);
            Controls.Add(label2);
            Controls.Add(textBoxReason);
            Controls.Add(label1);
            Controls.Add(textBox_Date);
            Name = "UpdateAppsOptionsView";
            Text = "UpdateAppsOptionsView";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_Date;
        private Label label1;
        private TextBox textBoxReason;
        private Label label2;
        private DataGridView dataGridViewDoctors;
        private Label label3;
        private Button btnUpdateDate;
        private Button btnUpdateReason;
        private Button btnReturnFromAppUpdateOps;
        private Button btnUpdateDoctor;
    }
}