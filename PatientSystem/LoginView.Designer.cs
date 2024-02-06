namespace PatientSystem
{
    partial class SignIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userNameField = new TextBox();
            userPasswordField = new TextBox();
            BtnSignIn = new Button();
            signInFormTitle = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // userNameField
            // 
            userNameField.ForeColor = SystemColors.Desktop;
            userNameField.Location = new Point(121, 171);
            userNameField.Name = "userNameField";
            userNameField.Size = new Size(241, 23);
            userNameField.TabIndex = 0;
            userNameField.Text = "Rebecca Smith";
            // 
            // userPasswordField
            // 
            userPasswordField.ForeColor = SystemColors.Desktop;
            userPasswordField.Location = new Point(121, 218);
            userPasswordField.Name = "userPasswordField";
            userPasswordField.Size = new Size(241, 23);
            userPasswordField.TabIndex = 1;
            userPasswordField.Text = "receptionistpass123";
            // 
            // BtnSignIn
            // 
            BtnSignIn.Location = new Point(121, 267);
            BtnSignIn.Name = "BtnSignIn";
            BtnSignIn.Size = new Size(241, 31);
            BtnSignIn.TabIndex = 2;
            BtnSignIn.Text = "SIGN IN";
            BtnSignIn.UseVisualStyleBackColor = true;
            BtnSignIn.Click += BtnSignIn_Click;
            // 
            // signInFormTitle
            // 
            signInFormTitle.AutoSize = true;
            signInFormTitle.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signInFormTitle.Location = new Point(141, 122);
            signInFormTitle.Name = "signInFormTitle";
            signInFormTitle.Size = new Size(190, 23);
            signInFormTitle.TabIndex = 3;
            signInFormTitle.Text = "PATIENT SYSTEM";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PresentationLayer.Properties.Resources.usernameicon;
            pictureBox1.Location = new Point(78, 171);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 23);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = PresentationLayer.Properties.Resources.password_icon;
            pictureBox2.Location = new Point(78, 218);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(33, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 450);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(signInFormTitle);
            Controls.Add(BtnSignIn);
            Controls.Add(userPasswordField);
            Controls.Add(userNameField);
            Name = "SignIn";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userNameField;
        private TextBox userPasswordField;
        private Button BtnSignIn;
        private Label signInFormTitle;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
