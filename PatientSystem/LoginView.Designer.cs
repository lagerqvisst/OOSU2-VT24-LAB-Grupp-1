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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            userNameField = new TextBox();
            userPasswordField = new TextBox();
            BtnSignIn = new Button();
            signInFormTitle = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
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
            userNameField.Text = "Tom Crane";
            // 
            // userPasswordField
            // 
            userPasswordField.ForeColor = SystemColors.Desktop;
            userPasswordField.Location = new Point(121, 218);
            userPasswordField.Name = "userPasswordField";
            userPasswordField.Size = new Size(241, 23);
            userPasswordField.TabIndex = 1;
            userPasswordField.Text = "wowdoctorimgood123";
            // 
            // BtnSignIn
            // 
            BtnSignIn.Location = new Point(121, 257);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 397);
            label1.Name = "label1";
            label1.Size = new Size(143, 15);
            label1.TabIndex = 6;
            label1.Text = "username: Rebecca Smith";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 412);
            label2.Name = "label2";
            label2.Size = new Size(166, 15);
            label2.TabIndex = 7;
            label2.Text = "password: receptionistpass123";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 447);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 8;
            label3.Text = "username: Tom Crane";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 462);
            label4.Name = "label4";
            label4.Size = new Size(183, 15);
            label4.TabIndex = 9;
            label4.Text = "password: wowdoctorimgood123";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 370);
            label5.Name = "label5";
            label5.Size = new Size(205, 18);
            label5.TabIndex = 10;
            label5.Text = "Example users to sign in with";
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(503, 486);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
