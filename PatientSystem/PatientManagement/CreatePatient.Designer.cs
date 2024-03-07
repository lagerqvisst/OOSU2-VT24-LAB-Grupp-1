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
            SuspendLayout();
            // 
            // persNumber_textbox
            // 
            persNumber_textbox.Location = new Point(58, 103);
            persNumber_textbox.Name = "persNumber_textbox";
            persNumber_textbox.PlaceholderText = "Personal number";
            persNumber_textbox.Size = new Size(216, 23);
            persNumber_textbox.TabIndex = 0;
            // 
            // namePatient_textbox
            // 
            namePatient_textbox.Location = new Point(58, 148);
            namePatient_textbox.Name = "namePatient_textbox";
            namePatient_textbox.PlaceholderText = "Name";
            namePatient_textbox.Size = new Size(216, 23);
            namePatient_textbox.TabIndex = 1;
            // 
            // adress_textbox
            // 
            adress_textbox.Location = new Point(58, 192);
            adress_textbox.Name = "adress_textbox";
            adress_textbox.PlaceholderText = "Address";
            adress_textbox.Size = new Size(216, 23);
            adress_textbox.TabIndex = 2;
            // 
            // phonenumber_textbox
            // 
            phonenumber_textbox.Location = new Point(58, 233);
            phonenumber_textbox.Name = "phonenumber_textbox";
            phonenumber_textbox.PlaceholderText = "Phone number";
            phonenumber_textbox.Size = new Size(216, 23);
            phonenumber_textbox.TabIndex = 3;
            // 
            // emailAdress_textbox
            // 
            emailAdress_textbox.Location = new Point(58, 276);
            emailAdress_textbox.Name = "emailAdress_textbox";
            emailAdress_textbox.PlaceholderText = "Email address";
            emailAdress_textbox.Size = new Size(216, 23);
            emailAdress_textbox.TabIndex = 4;
            // 
            // btnCreatePatient
            // 
            btnCreatePatient.BackColor = Color.LimeGreen;
            btnCreatePatient.Font = new Font("Arial Narrow", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnCreatePatient.Location = new Point(58, 325);
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
            label1.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 60);
            label1.Name = "label1";
            label1.Size = new Size(220, 15);
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
            // CreatePatient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 450);
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
    }
}