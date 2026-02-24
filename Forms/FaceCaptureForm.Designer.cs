namespace Gym_Manager_System.Forms
{
    partial class FaceCaptureForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.takePhotoButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.instructionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.SuspendLayout();
            //
            // instructionLabel
            //
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Location = new System.Drawing.Point(12, 9);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(280, 15);
            this.instructionLabel.TabIndex = 0;
            this.instructionLabel.Text = "Position the member's face in the frame, then click Take Photo.";
            //
            // previewPictureBox
            //
            this.previewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPictureBox.Location = new System.Drawing.Point(12, 30);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(480, 360);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPictureBox.TabIndex = 1;
            this.previewPictureBox.TabStop = false;
            //
            // takePhotoButton
            //
            this.takePhotoButton.Location = new System.Drawing.Point(12, 400);
            this.takePhotoButton.Name = "takePhotoButton";
            this.takePhotoButton.Size = new System.Drawing.Size(120, 28);
            this.takePhotoButton.TabIndex = 2;
            this.takePhotoButton.Text = "Take Photo";
            this.takePhotoButton.UseVisualStyleBackColor = true;
            this.takePhotoButton.Click += new System.EventHandler(this.TakePhotoButton_Click);
            //
            // cancelButton
            //
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(138, 400);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 28);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            //
            // FaceCaptureForm
            //
            this.AcceptButton = this.takePhotoButton;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(504, 441);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.takePhotoButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FaceCaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Capture face photo";
            this.Load += new System.EventHandler(this.FaceCaptureForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FaceCaptureForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.Button takePhotoButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label instructionLabel;
    }
}
