namespace Gym_Manager_System.Forms
{
    partial class SubscriptionDetailsForm
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
            this.memberLabel = new System.Windows.Forms.Label();
            this.memberComboBox = new System.Windows.Forms.ComboBox();
            this.planLabel = new System.Windows.Forms.Label();
            this.planComboBox = new System.Windows.Forms.ComboBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // memberLabel
            // 
            this.memberLabel.Location = new System.Drawing.Point(20, 20);
            this.memberLabel.Name = "memberLabel";
            this.memberLabel.Size = new System.Drawing.Size(150, 23);
            this.memberLabel.TabIndex = 0;
            this.memberLabel.Text = "Member:";
            // 
            // memberComboBox
            // 
            this.memberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memberComboBox.Location = new System.Drawing.Point(180, 20);
            this.memberComboBox.Name = "memberComboBox";
            this.memberComboBox.Size = new System.Drawing.Size(300, 23);
            this.memberComboBox.TabIndex = 1;
            // 
            // planLabel
            // 
            this.planLabel.Location = new System.Drawing.Point(20, 60);
            this.planLabel.Name = "planLabel";
            this.planLabel.Size = new System.Drawing.Size(150, 23);
            this.planLabel.TabIndex = 2;
            this.planLabel.Text = "Plan:";
            // 
            // planComboBox
            // 
            this.planComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.planComboBox.Location = new System.Drawing.Point(180, 60);
            this.planComboBox.Name = "planComboBox";
            this.planComboBox.Size = new System.Drawing.Size(300, 23);
            this.planComboBox.TabIndex = 3;
            // 
            // startDateLabel
            // 
            this.startDateLabel.Location = new System.Drawing.Point(20, 100);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(150, 23);
            this.startDateLabel.TabIndex = 4;
            this.startDateLabel.Text = "Start Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(180, 100);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(300, 23);
            this.startDatePicker.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(180, 160);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(290, 160);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // SubscriptionDetailsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.planComboBox);
            this.Controls.Add(this.planLabel);
            this.Controls.Add(this.memberComboBox);
            this.Controls.Add(this.memberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubscriptionDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Subscription";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label memberLabel;
        private System.Windows.Forms.ComboBox memberComboBox;
        private System.Windows.Forms.Label planLabel;
        private System.Windows.Forms.ComboBox planComboBox;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}


