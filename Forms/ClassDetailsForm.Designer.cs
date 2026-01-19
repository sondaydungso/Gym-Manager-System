namespace Gym_Manager_System.Forms
{
    partial class ClassDetailsForm
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
            this.classDateLabel = new System.Windows.Forms.Label();
            this.classDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.instructorLabel = new System.Windows.Forms.Label();
            this.instructorComboBox = new System.Windows.Forms.ComboBox();
            this.roomLabel = new System.Windows.Forms.Label();
            this.roomComboBox = new System.Windows.Forms.ComboBox();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.capacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // classDateLabel
            // 
            this.classDateLabel.Location = new System.Drawing.Point(20, 20);
            this.classDateLabel.Name = "classDateLabel";
            this.classDateLabel.Size = new System.Drawing.Size(150, 23);
            this.classDateLabel.TabIndex = 0;
            this.classDateLabel.Text = "Class Date:";
            // 
            // classDatePicker
            // 
            this.classDatePicker.Location = new System.Drawing.Point(180, 20);
            this.classDatePicker.Name = "classDatePicker";
            this.classDatePicker.Size = new System.Drawing.Size(300, 23);
            this.classDatePicker.TabIndex = 1;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.Location = new System.Drawing.Point(20, 60);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(150, 23);
            this.startTimeLabel.TabIndex = 2;
            this.startTimeLabel.Text = "Start Time:";
            // 
            // startTimePicker
            // 
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(180, 60);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(300, 23);
            this.startTimePicker.TabIndex = 3;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.Location = new System.Drawing.Point(20, 100);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(150, 23);
            this.endTimeLabel.TabIndex = 4;
            this.endTimeLabel.Text = "End Time:";
            // 
            // endTimePicker
            // 
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTimePicker.Location = new System.Drawing.Point(180, 100);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(300, 23);
            this.endTimePicker.TabIndex = 5;
            // 
            // instructorLabel
            // 
            this.instructorLabel.Location = new System.Drawing.Point(20, 140);
            this.instructorLabel.Name = "instructorLabel";
            this.instructorLabel.Size = new System.Drawing.Size(150, 23);
            this.instructorLabel.TabIndex = 6;
            this.instructorLabel.Text = "Instructor:";
            // 
            // instructorComboBox
            // 
            this.instructorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.instructorComboBox.Location = new System.Drawing.Point(180, 140);
            this.instructorComboBox.Name = "instructorComboBox";
            this.instructorComboBox.Size = new System.Drawing.Size(300, 23);
            this.instructorComboBox.TabIndex = 7;
            // 
            // roomLabel
            // 
            this.roomLabel.Location = new System.Drawing.Point(20, 180);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(150, 23);
            this.roomLabel.TabIndex = 8;
            this.roomLabel.Text = "Room:";
            // 
            // roomComboBox
            // 
            this.roomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomComboBox.Location = new System.Drawing.Point(180, 180);
            this.roomComboBox.Name = "roomComboBox";
            this.roomComboBox.Size = new System.Drawing.Size(300, 23);
            this.roomComboBox.TabIndex = 9;
            // 
            // capacityLabel
            // 
            this.capacityLabel.Location = new System.Drawing.Point(20, 220);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(150, 23);
            this.capacityLabel.TabIndex = 10;
            this.capacityLabel.Text = "Capacity:";
            // 
            // capacityNumericUpDown
            // 
            this.capacityNumericUpDown.Location = new System.Drawing.Point(180, 220);
            this.capacityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.capacityNumericUpDown.Name = "capacityNumericUpDown";
            this.capacityNumericUpDown.Size = new System.Drawing.Size(300, 23);
            this.capacityNumericUpDown.TabIndex = 11;
            this.capacityNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(20, 260);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(150, 23);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "Status:";
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Location = new System.Drawing.Point(180, 260);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(300, 23);
            this.statusComboBox.TabIndex = 13;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(180, 300);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(290, 300);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ClassDetailsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.capacityNumericUpDown);
            this.Controls.Add(this.capacityLabel);
            this.Controls.Add(this.roomComboBox);
            this.Controls.Add(this.roomLabel);
            this.Controls.Add(this.instructorComboBox);
            this.Controls.Add(this.instructorLabel);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.classDatePicker);
            this.Controls.Add(this.classDateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Class";
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label classDateLabel;
        private System.Windows.Forms.DateTimePicker classDatePicker;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label instructorLabel;
        private System.Windows.Forms.ComboBox instructorComboBox;
        private System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.ComboBox roomComboBox;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.NumericUpDown capacityNumericUpDown;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}

