namespace Gym_Manager_System.Forms
{
    partial class RoomDetailsForm
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
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.capacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.equipmentAvailableLabel = new System.Windows.Forms.Label();
            this.equipmentAvailableTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.Location = new System.Drawing.Point(20, 20);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(150, 23);
            this.roomNameLabel.TabIndex = 0;
            this.roomNameLabel.Text = "Room Name:";
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.Location = new System.Drawing.Point(180, 20);
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.Size = new System.Drawing.Size(300, 23);
            this.roomNameTextBox.TabIndex = 1;
            // 
            // capacityLabel
            // 
            this.capacityLabel.Location = new System.Drawing.Point(20, 50);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(150, 23);
            this.capacityLabel.TabIndex = 2;
            this.capacityLabel.Text = "Capacity:";
            // 
            // capacityNumericUpDown
            // 
            this.capacityNumericUpDown.Location = new System.Drawing.Point(180, 50);
            this.capacityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.capacityNumericUpDown.Name = "capacityNumericUpDown";
            this.capacityNumericUpDown.Size = new System.Drawing.Size(300, 23);
            this.capacityNumericUpDown.TabIndex = 3;
            this.capacityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // equipmentAvailableLabel
            // 
            this.equipmentAvailableLabel.Location = new System.Drawing.Point(20, 80);
            this.equipmentAvailableLabel.Name = "equipmentAvailableLabel";
            this.equipmentAvailableLabel.Size = new System.Drawing.Size(150, 23);
            this.equipmentAvailableLabel.TabIndex = 4;
            this.equipmentAvailableLabel.Text = "Equipment Available:";
            // 
            // equipmentAvailableTextBox
            // 
            this.equipmentAvailableTextBox.Location = new System.Drawing.Point(180, 80);
            this.equipmentAvailableTextBox.Multiline = true;
            this.equipmentAvailableTextBox.Name = "equipmentAvailableTextBox";
            this.equipmentAvailableTextBox.Size = new System.Drawing.Size(300, 100);
            this.equipmentAvailableTextBox.TabIndex = 5;
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(20, 190);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(150, 23);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Status:";
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Location = new System.Drawing.Point(180, 190);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(300, 23);
            this.statusComboBox.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(180, 230);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(290, 230);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // RoomDetailsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(500, 280);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.equipmentAvailableTextBox);
            this.Controls.Add(this.equipmentAvailableLabel);
            this.Controls.Add(this.capacityNumericUpDown);
            this.Controls.Add(this.capacityLabel);
            this.Controls.Add(this.roomNameTextBox);
            this.Controls.Add(this.roomNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Room";
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.TextBox roomNameTextBox;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.NumericUpDown capacityNumericUpDown;
        private System.Windows.Forms.Label equipmentAvailableLabel;
        private System.Windows.Forms.TextBox equipmentAvailableTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}

