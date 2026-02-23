namespace Gym_Manager_System.Forms
{
    partial class InstructorDetailsForm
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
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.hireDateLabel = new System.Windows.Forms.Label();
            this.hireDatePicker = new System.Windows.Forms.DateTimePicker();
            this.certificationsLabel = new System.Windows.Forms.Label();
            this.certificationsTextBox = new System.Windows.Forms.TextBox();
            this.specializationsLabel = new System.Windows.Forms.Label();
            this.specializationsTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Location = new System.Drawing.Point(20, 20);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(150, 23);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First Name:";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(180, 20);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(300, 23);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Location = new System.Drawing.Point(20, 50);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(150, 23);
            this.lastNameLabel.TabIndex = 2;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(180, 50);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(300, 23);
            this.lastNameTextBox.TabIndex = 3;
            // 
            // emailLabel
            // 
            this.emailLabel.Location = new System.Drawing.Point(20, 80);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(150, 23);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(180, 80);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(300, 23);
            this.emailTextBox.TabIndex = 5;
            // 
            // phoneLabel
            // 
            this.phoneLabel.Location = new System.Drawing.Point(20, 110);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(150, 23);
            this.phoneLabel.TabIndex = 6;
            this.phoneLabel.Text = "Phone Number:";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(180, 110);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(300, 23);
            this.phoneTextBox.TabIndex = 7;
            // 
            // hireDateLabel
            // 
            this.hireDateLabel.Location = new System.Drawing.Point(20, 140);
            this.hireDateLabel.Name = "hireDateLabel";
            this.hireDateLabel.Size = new System.Drawing.Size(150, 23);
            this.hireDateLabel.TabIndex = 8;
            this.hireDateLabel.Text = "Hire Date:";
            // 
            // hireDatePicker
            // 
            this.hireDatePicker.Location = new System.Drawing.Point(180, 140);
            this.hireDatePicker.Name = "hireDatePicker";
            this.hireDatePicker.Size = new System.Drawing.Size(300, 23);
            this.hireDatePicker.TabIndex = 9;
            // 
            // certificationsLabel
            // 
            this.certificationsLabel.Location = new System.Drawing.Point(20, 170);
            this.certificationsLabel.Name = "certificationsLabel";
            this.certificationsLabel.Size = new System.Drawing.Size(150, 23);
            this.certificationsLabel.TabIndex = 10;
            this.certificationsLabel.Text = "Certifications:";
            // 
            // certificationsTextBox
            // 
            this.certificationsTextBox.Location = new System.Drawing.Point(180, 170);
            this.certificationsTextBox.Multiline = true;
            this.certificationsTextBox.Name = "certificationsTextBox";
            this.certificationsTextBox.Size = new System.Drawing.Size(300, 60);
            this.certificationsTextBox.TabIndex = 11;
            // 
            // specializationsLabel
            // 
            this.specializationsLabel.Location = new System.Drawing.Point(20, 240);
            this.specializationsLabel.Name = "specializationsLabel";
            this.specializationsLabel.Size = new System.Drawing.Size(150, 23);
            this.specializationsLabel.TabIndex = 12;
            this.specializationsLabel.Text = "Specializations:";
            // 
            // specializationsTextBox
            // 
            this.specializationsTextBox.Location = new System.Drawing.Point(180, 240);
            this.specializationsTextBox.Multiline = true;
            this.specializationsTextBox.Name = "specializationsTextBox";
            this.specializationsTextBox.Size = new System.Drawing.Size(300, 60);
            this.specializationsTextBox.TabIndex = 13;
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(20, 310);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(150, 23);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "Status:";
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Location = new System.Drawing.Point(180, 310);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(300, 23);
            this.statusComboBox.TabIndex = 15;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(180, 350);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(290, 350);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // InstructorDetailsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.specializationsTextBox);
            this.Controls.Add(this.specializationsLabel);
            this.Controls.Add(this.certificationsTextBox);
            this.Controls.Add(this.certificationsLabel);
            this.Controls.Add(this.hireDatePicker);
            this.Controls.Add(this.hireDateLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.firstNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstructorDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Instructor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label hireDateLabel;
        private System.Windows.Forms.DateTimePicker hireDatePicker;
        private System.Windows.Forms.Label certificationsLabel;
        private System.Windows.Forms.TextBox certificationsTextBox;
        private System.Windows.Forms.Label specializationsLabel;
        private System.Windows.Forms.TextBox specializationsTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}


