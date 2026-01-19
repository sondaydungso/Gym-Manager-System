namespace Gym_Manager_System.Forms
{
    partial class MembershipPlanDetailsForm
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
            this.planNameLabel = new System.Windows.Forms.Label();
            this.planNameTextBox = new System.Windows.Forms.TextBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.durationMonthsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxClassesLabel = new System.Windows.Forms.Label();
            this.maxClassesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.durationMonthsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxClassesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // planNameLabel
            // 
            this.planNameLabel.Location = new System.Drawing.Point(20, 20);
            this.planNameLabel.Name = "planNameLabel";
            this.planNameLabel.Size = new System.Drawing.Size(150, 23);
            this.planNameLabel.TabIndex = 0;
            this.planNameLabel.Text = "Plan Name:";
            // 
            // planNameTextBox
            // 
            this.planNameTextBox.Location = new System.Drawing.Point(180, 20);
            this.planNameTextBox.Name = "planNameTextBox";
            this.planNameTextBox.Size = new System.Drawing.Size(300, 23);
            this.planNameTextBox.TabIndex = 1;
            // 
            // durationLabel
            // 
            this.durationLabel.Location = new System.Drawing.Point(20, 50);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(150, 23);
            this.durationLabel.TabIndex = 2;
            this.durationLabel.Text = "Duration (Months):";
            // 
            // durationMonthsNumericUpDown
            // 
            this.durationMonthsNumericUpDown.Location = new System.Drawing.Point(180, 50);
            this.durationMonthsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.durationMonthsNumericUpDown.Name = "durationMonthsNumericUpDown";
            this.durationMonthsNumericUpDown.Size = new System.Drawing.Size(300, 23);
            this.durationMonthsNumericUpDown.TabIndex = 3;
            this.durationMonthsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // priceLabel
            // 
            this.priceLabel.Location = new System.Drawing.Point(20, 80);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(150, 23);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "Price:";
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.DecimalPlaces = 2;
            this.priceNumericUpDown.Location = new System.Drawing.Point(180, 80);
            this.priceNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(300, 23);
            this.priceNumericUpDown.TabIndex = 5;
            // 
            // maxClassesLabel
            // 
            this.maxClassesLabel.Location = new System.Drawing.Point(20, 110);
            this.maxClassesLabel.Name = "maxClassesLabel";
            this.maxClassesLabel.Size = new System.Drawing.Size(150, 23);
            this.maxClassesLabel.TabIndex = 6;
            this.maxClassesLabel.Text = "Max Classes/Month:";
            // 
            // maxClassesNumericUpDown
            // 
            this.maxClassesNumericUpDown.Location = new System.Drawing.Point(180, 110);
            this.maxClassesNumericUpDown.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.maxClassesNumericUpDown.Name = "maxClassesNumericUpDown";
            this.maxClassesNumericUpDown.Size = new System.Drawing.Size(300, 23);
            this.maxClassesNumericUpDown.TabIndex = 7;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(20, 140);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(150, 23);
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(180, 140);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(300, 100);
            this.descriptionTextBox.TabIndex = 9;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(180, 260);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(290, 260);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // MembershipPlanDetailsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.maxClassesNumericUpDown);
            this.Controls.Add(this.maxClassesLabel);
            this.Controls.Add(this.priceNumericUpDown);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.durationMonthsNumericUpDown);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.planNameTextBox);
            this.Controls.Add(this.planNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MembershipPlanDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Membership Plan";
            ((System.ComponentModel.ISupportInitialize)(this.durationMonthsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxClassesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label planNameLabel;
        private System.Windows.Forms.TextBox planNameTextBox;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.NumericUpDown durationMonthsNumericUpDown;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.NumericUpDown priceNumericUpDown;
        private System.Windows.Forms.Label maxClassesLabel;
        private System.Windows.Forms.NumericUpDown maxClassesNumericUpDown;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}

