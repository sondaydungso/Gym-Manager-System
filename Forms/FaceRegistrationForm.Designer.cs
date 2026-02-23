namespace Gym_Manager_System.Forms
{
    partial class FaceRegistrationForm
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
            picCamera = new PictureBox();
            btnCapture = new Button();
            btnClose = new Button();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)picCamera).BeginInit();
            SuspendLayout();
            // 
            // picCamera
            // 
            picCamera.Location = new Point(85, 124);
            picCamera.Name = "picCamera";
            picCamera.Size = new Size(310, 180);
            picCamera.SizeMode = PictureBoxSizeMode.StretchImage;
            picCamera.TabIndex = 0;
            picCamera.TabStop = false;
            // 
            // btnCapture
            // 
            btnCapture.Location = new Point(130, 330);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(75, 23);
            btnCapture.TabIndex = 1;
            btnCapture.Text = "Capture";
            btnCapture.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(258, 330);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(118, 101);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(230, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Position face in front of camera";
            // 
            // FaceRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(btnClose);
            Controls.Add(btnCapture);
            Controls.Add(picCamera);
            Name = "FaceRegistrationForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picCamera).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picCamera;
        private Button btnCapture;
        private Button btnClose;
        private Label lblStatus;
    }
}