namespace PresentationLayer
{
    partial class CreatePatient
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
            persNumber_textbox = new TextBox();
            namePatient_textbox = new TextBox();
            adress_textbox = new TextBox();
            phonenumber_textbox = new TextBox();
            emailAdress_textbox = new TextBox();
            btnCreatePatient = new Button();
            label1 = new Label();
            btnBackFromCreate = new Button();
            lblPersNmr = new Label();
            lblName = new Label();
            lblAddress = new Label();
            lblPhoneNmr = new Label();
            lblEmailAddress = new Label();
            SuspendLayout();
            // 
            // persNumber_textbox
            // 
            persNumber_textbox.Location = new Point(59, 73);
            persNumber_textbox.Name = "persNumber_textbox";
            persNumber_textbox.Size = new Size(216, 23);
            persNumber_textbox.TabIndex = 0;
            // 
            // namePatient_textbox
            // 
            namePatient_textbox.Location = new Point(57, 136);
            namePatient_textbox.Name = "namePatient_textbox";
            namePatient_textbox.Size = new Size(216, 23);
            namePatient_textbox.TabIndex = 1;
            // 
            // adress_textbox
            // 
            adress_textbox.Location = new Point(57, 189);
            adress_textbox.Name = "adress_textbox";
            adress_textbox.Size = new Size(216, 23);
            adress_textbox.TabIndex = 2;
            // 
            // phonenumber_textbox
            // 
            phonenumber_textbox.Location = new Point(57, 242);
            phonenumber_textbox.Name = "phonenumber_textbox";
            phonenumber_textbox.Size = new Size(216, 23);
            phonenumber_textbox.TabIndex = 3;
            // 
            // emailAdress_textbox
            // 
            emailAdress_textbox.Location = new Point(59, 304);
            emailAdress_textbox.Name = "emailAdress_textbox";
            emailAdress_textbox.Size = new Size(216, 23);
            emailAdress_textbox.TabIndex = 4;
            // 
            // btnCreatePatient
            // 
            btnCreatePatient.BackColor = Color.LimeGreen;
            btnCreatePatient.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnCreatePatient.Location = new Point(59, 354);
            btnCreatePatient.Name = "btnCreatePatient";
            btnCreatePatient.Size = new Size(220, 41);
            btnCreatePatient.TabIndex = 5;
            btnCreatePatient.Text = "CREATE PATIENT";
            btnCreatePatient.UseVisualStyleBackColor = false;
            btnCreatePatient.Click += btnCreatePatient_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 9);
            label1.Name = "label1";
            label1.Size = new Size(214, 15);
            label1.TabIndex = 6;
            label1.Text = "Enter details to create a new patient.";
            // 
            // btnBackFromCreate
            // 
            btnBackFromCreate.BackColor = SystemColors.Info;
            btnBackFromCreate.Cursor = Cursors.Hand;
            btnBackFromCreate.Location = new Point(12, 415);
            btnBackFromCreate.Name = "btnBackFromCreate";
            btnBackFromCreate.Size = new Size(75, 23);
            btnBackFromCreate.TabIndex = 7;
            btnBackFromCreate.Text = "Return";
            btnBackFromCreate.UseVisualStyleBackColor = false;
            btnBackFromCreate.Click += btnBackFromCreate_Click;
            // 
            // lblPersNmr
            // 
            lblPersNmr.AutoSize = true;
            lblPersNmr.Location = new Point(57, 45);
            lblPersNmr.Name = "lblPersNmr";
            lblPersNmr.Size = new Size(97, 15);
            lblPersNmr.TabIndex = 8;
            lblPersNmr.Text = "Personal number";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(57, 109);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 9;
            lblName.Text = "Name";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(57, 162);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(49, 15);
            lblAddress.TabIndex = 10;
            lblAddress.Text = "Address";
            lblAddress.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPhoneNmr
            // 
            lblPhoneNmr.AutoSize = true;
            lblPhoneNmr.Location = new Point(57, 215);
            lblPhoneNmr.Name = "lblPhoneNmr";
            lblPhoneNmr.Size = new Size(86, 15);
            lblPhoneNmr.TabIndex = 11;
            lblPhoneNmr.Text = "Phone number";
            // 
            // lblEmailAddress
            // 
            lblEmailAddress.AutoSize = true;
            lblEmailAddress.Location = new Point(57, 277);
            lblEmailAddress.Name = "lblEmailAddress";
            lblEmailAddress.Size = new Size(79, 15);
            lblEmailAddress.TabIndex = 12;
            lblEmailAddress.Text = "Email address";
            // 
            // CreatePatient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 450);
            Controls.Add(lblEmailAddress);
            Controls.Add(lblPhoneNmr);
            Controls.Add(lblAddress);
            Controls.Add(lblName);
            Controls.Add(lblPersNmr);
            Controls.Add(btnBackFromCreate);
            Controls.Add(label1);
            Controls.Add(btnCreatePatient);
            Controls.Add(emailAdress_textbox);
            Controls.Add(phonenumber_textbox);
            Controls.Add(adress_textbox);
            Controls.Add(namePatient_textbox);
            Controls.Add(persNumber_textbox);
            Name = "CreatePatient";
            Text = "CreatePatient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox persNumber_textbox;
        private TextBox namePatient_textbox;
        private TextBox adress_textbox;
        private TextBox phonenumber_textbox;
        private TextBox emailAdress_textbox;
        private Button btnCreatePatient;
        private Label label1;
        private Button btnBackFromCreate;
        private Label lblPersNmr;
        private Label lblName;
        private Label lblAddress;
        private Label lblPhoneNmr;
        private Label lblEmailAddress;
    }
}