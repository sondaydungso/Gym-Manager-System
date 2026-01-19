namespace Gym_Manager_System.Forms
{
    partial class BookingsForm
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
            this.filterPanel = new System.Windows.Forms.Panel();
            this.memberFilterLabel = new System.Windows.Forms.Label();
            this.memberFilterComboBox = new System.Windows.Forms.ComboBox();
            this.bookingsGridView = new System.Windows.Forms.DataGridView();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.checkInButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGridView)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.memberFilterLabel);
            this.filterPanel.Controls.Add(this.memberFilterComboBox);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1200, 50);
            this.filterPanel.TabIndex = 0;
            // 
            // memberFilterLabel
            // 
            this.memberFilterLabel.AutoSize = true;
            this.memberFilterLabel.Location = new System.Drawing.Point(10, 15);
            this.memberFilterLabel.Name = "memberFilterLabel";
            this.memberFilterLabel.Size = new System.Drawing.Size(104, 15);
            this.memberFilterLabel.TabIndex = 0;
            this.memberFilterLabel.Text = "Filter by Member:";
            // 
            // memberFilterComboBox
            // 
            this.memberFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memberFilterComboBox.Location = new System.Drawing.Point(120, 12);
            this.memberFilterComboBox.Name = "memberFilterComboBox";
            this.memberFilterComboBox.Size = new System.Drawing.Size(200, 23);
            this.memberFilterComboBox.TabIndex = 1;
            this.memberFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.MemberFilterComboBox_SelectedIndexChanged);
            // 
            // bookingsGridView
            // 
            this.bookingsGridView.AllowUserToAddRows = false;
            this.bookingsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bookingsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookingsGridView.Location = new System.Drawing.Point(0, 50);
            this.bookingsGridView.Name = "bookingsGridView";
            this.bookingsGridView.ReadOnly = true;
            this.bookingsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bookingsGridView.Size = new System.Drawing.Size(1200, 500);
            this.bookingsGridView.TabIndex = 1;
            this.bookingsGridView.SelectionChanged += new System.EventHandler(this.BookingsGridView_SelectionChanged);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.addButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.checkInButton);
            this.buttonPanel.Controls.Add(this.refreshButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 550);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(1200, 50);
            this.buttonPanel.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(10, 10);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 30);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "New Booking";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(120, 10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel Booking";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelBookingButton_Click);
            // 
            // checkInButton
            // 
            this.checkInButton.Enabled = false;
            this.checkInButton.Location = new System.Drawing.Point(230, 10);
            this.checkInButton.Name = "checkInButton";
            this.checkInButton.Size = new System.Drawing.Size(100, 30);
            this.checkInButton.TabIndex = 2;
            this.checkInButton.Text = "Check In";
            this.checkInButton.UseVisualStyleBackColor = true;
            this.checkInButton.Click += new System.EventHandler(this.CheckInButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(340, 10);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // BookingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.bookingsGridView);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.filterPanel);
            this.Name = "BookingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bookings Management";
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGridView)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label memberFilterLabel;
        private System.Windows.Forms.ComboBox memberFilterComboBox;
        private System.Windows.Forms.DataGridView bookingsGridView;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button checkInButton;
        private System.Windows.Forms.Button refreshButton;
    }
}


