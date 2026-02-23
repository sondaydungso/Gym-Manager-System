namespace Gym_Manager_System.Forms
{
    partial class BookingDetailsForm
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
            memberLabel = new Label();
            memberComboBox = new ComboBox();
            classLabel = new Label();
            classComboBox = new ComboBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // memberLabel
            // 
            memberLabel.Location = new Point(20, 20);
            memberLabel.Name = "memberLabel";
            memberLabel.Size = new Size(150, 23);
            memberLabel.TabIndex = 0;
            memberLabel.Text = "Member:";
            // 
            // memberComboBox
            // 
            memberComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            memberComboBox.Location = new Point(180, 20);
            memberComboBox.Name = "memberComboBox";
            memberComboBox.Size = new Size(300, 23);
            memberComboBox.TabIndex = 1;
            // 
            // classLabel
            // 
            classLabel.Location = new Point(20, 60);
            classLabel.Name = "classLabel";
            classLabel.Size = new Size(150, 23);
            classLabel.TabIndex = 2;
            classLabel.Text = "Class:";
            // 
            // classComboBox
            // 
            classComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            classComboBox.Location = new Point(180, 60);
            classComboBox.Name = "classComboBox";
            classComboBox.Size = new Size(300, 23);
            classComboBox.TabIndex = 3;
            // 
            // saveButton
            // 
            saveButton.DialogResult = DialogResult.OK;
            saveButton.Location = new Point(180, 120);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 23);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(290, 120);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 23);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // BookingDetailsForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(500, 200);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(classComboBox);
            Controls.Add(classLabel);
            Controls.Add(memberComboBox);
            Controls.Add(memberLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookingDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Booking";
            Load += BookingDetailsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label memberLabel;
        private System.Windows.Forms.ComboBox memberComboBox;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}



