namespace Gym_Manager_System.Forms
{
    partial class MemberDetailsForm
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
            firstNameLabel = new Label();
            firstNameTextBox = new TextBox();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            phoneLabel = new Label();
            phoneTextBox = new TextBox();
            dobLabel = new Label();
            dateOfBirthPicker = new DateTimePicker();
            emergencyNameLabel = new Label();
            emergencyContactNameTextBox = new TextBox();
            emergencyPhoneLabel = new Label();
            emergencyContactPhoneTextBox = new TextBox();
            medicalNotesLabel = new Label();
            medicalNotesTextBox = new TextBox();
            statusLabel = new Label();
            statusComboBox = new ComboBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.Location = new Point(20, 20);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(150, 23);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name:";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(180, 20);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(300, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Location = new Point(20, 50);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(150, 23);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(180, 50);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(300, 23);
            lastNameTextBox.TabIndex = 3;
            // 
            // emailLabel
            // 
            emailLabel.Location = new Point(20, 80);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(150, 23);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(180, 80);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(300, 23);
            emailTextBox.TabIndex = 5;
            // 
            // phoneLabel
            // 
            phoneLabel.Location = new Point(20, 110);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(150, 23);
            phoneLabel.TabIndex = 6;
            phoneLabel.Text = "Phone Number:";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(180, 110);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(300, 23);
            phoneTextBox.TabIndex = 7;
            // 
            // dobLabel
            // 
            dobLabel.Location = new Point(20, 140);
            dobLabel.Name = "dobLabel";
            dobLabel.Size = new Size(150, 23);
            dobLabel.TabIndex = 8;
            dobLabel.Text = "Date of Birth:";
            // 
            // dateOfBirthPicker
            // 
            dateOfBirthPicker.Location = new Point(180, 140);
            dateOfBirthPicker.Name = "dateOfBirthPicker";
            dateOfBirthPicker.Size = new Size(300, 23);
            dateOfBirthPicker.TabIndex = 9;
            // 
            // emergencyNameLabel
            // 
            emergencyNameLabel.Location = new Point(20, 170);
            emergencyNameLabel.Name = "emergencyNameLabel";
            emergencyNameLabel.Size = new Size(150, 23);
            emergencyNameLabel.TabIndex = 10;
            emergencyNameLabel.Text = "Emergency Contact:";
            // 
            // emergencyContactNameTextBox
            // 
            emergencyContactNameTextBox.Location = new Point(180, 170);
            emergencyContactNameTextBox.Name = "emergencyContactNameTextBox";
            emergencyContactNameTextBox.Size = new Size(300, 23);
            emergencyContactNameTextBox.TabIndex = 11;
            // 
            // emergencyPhoneLabel
            // 
            emergencyPhoneLabel.Location = new Point(20, 200);
            emergencyPhoneLabel.Name = "emergencyPhoneLabel";
            emergencyPhoneLabel.Size = new Size(150, 23);
            emergencyPhoneLabel.TabIndex = 12;
            emergencyPhoneLabel.Text = "Emergency Phone:";
            // 
            // emergencyContactPhoneTextBox
            // 
            emergencyContactPhoneTextBox.Location = new Point(180, 200);
            emergencyContactPhoneTextBox.Name = "emergencyContactPhoneTextBox";
            emergencyContactPhoneTextBox.Size = new Size(300, 23);
            emergencyContactPhoneTextBox.TabIndex = 13;
            // 
            // medicalNotesLabel
            // 
            medicalNotesLabel.Location = new Point(20, 230);
            medicalNotesLabel.Name = "medicalNotesLabel";
            medicalNotesLabel.Size = new Size(150, 23);
            medicalNotesLabel.TabIndex = 14;
            medicalNotesLabel.Text = "Medical Notes:";
            // 
            // medicalNotesTextBox
            // 
            medicalNotesTextBox.Location = new Point(180, 230);
            medicalNotesTextBox.Multiline = true;
            medicalNotesTextBox.Name = "medicalNotesTextBox";
            medicalNotesTextBox.Size = new Size(300, 60);
            medicalNotesTextBox.TabIndex = 15;
            // 
            // statusLabel
            // 
            statusLabel.Location = new Point(20, 300);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(150, 23);
            statusLabel.TabIndex = 16;
            statusLabel.Text = "Status:";
            // 
            // statusComboBox
            // 
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.Location = new Point(180, 300);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(300, 23);
            statusComboBox.TabIndex = 17;
            // 
            // saveButton
            // 
            saveButton.DialogResult = DialogResult.OK;
            saveButton.Location = new Point(180, 350);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 23);
            saveButton.TabIndex = 18;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(290, 350);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 23);
            cancelButton.TabIndex = 19;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // MemberDetailsForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(500, 500);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(statusComboBox);
            Controls.Add(statusLabel);
            Controls.Add(medicalNotesTextBox);
            Controls.Add(medicalNotesLabel);
            Controls.Add(emergencyContactPhoneTextBox);
            Controls.Add(emergencyPhoneLabel);
            Controls.Add(emergencyContactNameTextBox);
            Controls.Add(emergencyNameLabel);
            Controls.Add(dateOfBirthPicker);
            Controls.Add(dobLabel);
            Controls.Add(phoneTextBox);
            Controls.Add(phoneLabel);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(firstNameLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MemberDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Member";
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.DateTimePicker dateOfBirthPicker;
        private System.Windows.Forms.Label emergencyNameLabel;
        private System.Windows.Forms.TextBox emergencyContactNameTextBox;
        private System.Windows.Forms.Label emergencyPhoneLabel;
        private System.Windows.Forms.TextBox emergencyContactPhoneTextBox;
        private System.Windows.Forms.Label medicalNotesLabel;
        private System.Windows.Forms.TextBox medicalNotesTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}



