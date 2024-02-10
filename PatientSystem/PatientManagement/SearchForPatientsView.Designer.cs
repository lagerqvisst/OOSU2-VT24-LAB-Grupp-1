namespace PresentationLayer
{
    partial class SearchForPatientsView
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
            btnReturnToMenu = new Button();
            labelHeadingSearch = new Label();
            textBoxByName = new TextBox();
            labelName = new Label();
            dataGridViewSearchResults = new DataGridView();
            labelResults = new Label();
            btnSearchByName = new Button();
            textBoxPersonalNumber = new TextBox();
            textBoxAddress = new TextBox();
            textBoxPhoneNumber = new TextBox();
            textBoxEmailAddress = new TextBox();
            labelPersonalNumber = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSearchByPersonalNumber = new Button();
            btnSearchByAddress = new Button();
            btnSearchByPhoneNumber = new Button();
            btnSearchByEmailAddress = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSearchResults).BeginInit();
            SuspendLayout();
            // 
            // btnReturnToMenu
            // 
            btnReturnToMenu.Location = new Point(48, 393);
            btnReturnToMenu.Name = "btnReturnToMenu";
            btnReturnToMenu.Size = new Size(94, 23);
            btnReturnToMenu.TabIndex = 0;
            btnReturnToMenu.Text = "Return";
            btnReturnToMenu.UseVisualStyleBackColor = true;
            btnReturnToMenu.Click += btnReturnToMenu_Click;
            // 
            // labelHeadingSearch
            // 
            labelHeadingSearch.AutoSize = true;
            labelHeadingSearch.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelHeadingSearch.Location = new Point(37, 9);
            labelHeadingSearch.Name = "labelHeadingSearch";
            labelHeadingSearch.Size = new Size(171, 23);
            labelHeadingSearch.TabIndex = 1;
            labelHeadingSearch.Text = "Search for patients";
            // 
            // textBoxByName
            // 
            textBoxByName.Location = new Point(37, 96);
            textBoxByName.Name = "textBoxByName";
            textBoxByName.Size = new Size(274, 23);
            textBoxByName.TabIndex = 2;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(37, 78);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 15);
            labelName.TabIndex = 3;
            labelName.Text = "Name";
            // 
            // dataGridViewSearchResults
            // 
            dataGridViewSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSearchResults.Location = new Point(398, 96);
            dataGridViewSearchResults.Name = "dataGridViewSearchResults";
            dataGridViewSearchResults.Size = new Size(587, 289);
            dataGridViewSearchResults.TabIndex = 4;
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.Location = new Point(398, 78);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(79, 15);
            labelResults.TabIndex = 5;
            labelResults.Text = "Search results";
            // 
            // btnSearchByName
            // 
            btnSearchByName.Location = new Point(317, 96);
            btnSearchByName.Name = "btnSearchByName";
            btnSearchByName.Size = new Size(52, 23);
            btnSearchByName.TabIndex = 6;
            btnSearchByName.Text = "Search";
            btnSearchByName.UseVisualStyleBackColor = true;
            btnSearchByName.Click += btnSearchByName_Click;
            // 
            // textBoxPersonalNumber
            // 
            textBoxPersonalNumber.Location = new Point(37, 161);
            textBoxPersonalNumber.Name = "textBoxPersonalNumber";
            textBoxPersonalNumber.Size = new Size(274, 23);
            textBoxPersonalNumber.TabIndex = 7;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(37, 222);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(274, 23);
            textBoxAddress.TabIndex = 8;
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.Location = new Point(37, 276);
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.Size = new Size(274, 23);
            textBoxPhoneNumber.TabIndex = 9;
            // 
            // textBoxEmailAddress
            // 
            textBoxEmailAddress.Location = new Point(37, 335);
            textBoxEmailAddress.Name = "textBoxEmailAddress";
            textBoxEmailAddress.Size = new Size(274, 23);
            textBoxEmailAddress.TabIndex = 10;
            // 
            // labelPersonalNumber
            // 
            labelPersonalNumber.AutoSize = true;
            labelPersonalNumber.Location = new Point(37, 143);
            labelPersonalNumber.Name = "labelPersonalNumber";
            labelPersonalNumber.Size = new Size(99, 15);
            labelPersonalNumber.TabIndex = 11;
            labelPersonalNumber.Text = "Personal Number";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 204);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 12;
            label1.Text = "Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 258);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 13;
            label2.Text = "Phone Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 317);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 14;
            label3.Text = "Email Address";
            // 
            // btnSearchByPersonalNumber
            // 
            btnSearchByPersonalNumber.Location = new Point(317, 161);
            btnSearchByPersonalNumber.Name = "btnSearchByPersonalNumber";
            btnSearchByPersonalNumber.Size = new Size(52, 23);
            btnSearchByPersonalNumber.TabIndex = 15;
            btnSearchByPersonalNumber.Text = "Search";
            btnSearchByPersonalNumber.UseVisualStyleBackColor = true;
            btnSearchByPersonalNumber.Click += btnSearchByPersonalNumber_Click;
            // 
            // btnSearchByAddress
            // 
            btnSearchByAddress.Location = new Point(317, 219);
            btnSearchByAddress.Name = "btnSearchByAddress";
            btnSearchByAddress.Size = new Size(52, 26);
            btnSearchByAddress.TabIndex = 16;
            btnSearchByAddress.Text = "Search";
            btnSearchByAddress.UseVisualStyleBackColor = true;
            btnSearchByAddress.Click += btnSearchByAddress_Click;
            // 
            // btnSearchByPhoneNumber
            // 
            btnSearchByPhoneNumber.Location = new Point(317, 276);
            btnSearchByPhoneNumber.Name = "btnSearchByPhoneNumber";
            btnSearchByPhoneNumber.Size = new Size(52, 23);
            btnSearchByPhoneNumber.TabIndex = 17;
            btnSearchByPhoneNumber.Text = "Search";
            btnSearchByPhoneNumber.UseVisualStyleBackColor = true;
            btnSearchByPhoneNumber.Click += btnSearchByPhoneNumber_Click;
            // 
            // btnSearchByEmailAddress
            // 
            btnSearchByEmailAddress.Location = new Point(317, 333);
            btnSearchByEmailAddress.Name = "btnSearchByEmailAddress";
            btnSearchByEmailAddress.Size = new Size(52, 25);
            btnSearchByEmailAddress.TabIndex = 18;
            btnSearchByEmailAddress.Text = "Search";
            btnSearchByEmailAddress.UseVisualStyleBackColor = true;
            btnSearchByEmailAddress.Click += btnSearchByEmailAddress_Click;
            // 
            // SearchForPatientsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 450);
            Controls.Add(btnSearchByEmailAddress);
            Controls.Add(btnSearchByPhoneNumber);
            Controls.Add(btnSearchByAddress);
            Controls.Add(btnSearchByPersonalNumber);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelPersonalNumber);
            Controls.Add(textBoxEmailAddress);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxPersonalNumber);
            Controls.Add(btnSearchByName);
            Controls.Add(labelResults);
            Controls.Add(dataGridViewSearchResults);
            Controls.Add(labelName);
            Controls.Add(textBoxByName);
            Controls.Add(labelHeadingSearch);
            Controls.Add(btnReturnToMenu);
            Name = "SearchForPatientsView";
            Text = "SearchForPatientsView";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSearchResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReturnToMenu;
        private Label labelHeadingSearch;
        private TextBox textBoxByName;
        private Label labelName;
        private DataGridView dataGridViewSearchResults;
        private Label labelResults;
        private Button btnSearchByName;
        private TextBox textBoxPersonalNumber;
        private TextBox textBoxAddress;
        private TextBox textBoxPhoneNumber;
        private TextBox textBoxEmailAddress;
        private Label labelPersonalNumber;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSearchByPersonalNumber;
        private Button btnSearchByAddress;
        private Button btnSearchByPhoneNumber;
        private Button btnSearchByEmailAddress;
    }
}