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
            filterPanel = new Panel();
            memberFilterLabel = new Label();
            memberFilterComboBox = new ComboBox();
            bookingsGridView = new DataGridView();
            buttonPanel = new Panel();
            addButton = new Button();
            cancelButton = new Button();
            checkInButton = new Button();
            refreshButton = new Button();
            filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bookingsGridView).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // filterPanel
            // 
            filterPanel.Controls.Add(memberFilterLabel);
            filterPanel.Controls.Add(memberFilterComboBox);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(0, 0);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(1200, 50);
            filterPanel.TabIndex = 0;
            // 
            // memberFilterLabel
            // 
            memberFilterLabel.AutoSize = true;
            memberFilterLabel.Location = new Point(10, 15);
            memberFilterLabel.Name = "memberFilterLabel";
            memberFilterLabel.Size = new Size(100, 15);
            memberFilterLabel.TabIndex = 0;
            memberFilterLabel.Text = "Filter by Member:";
            // 
            // memberFilterComboBox
            // 
            memberFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            memberFilterComboBox.Location = new Point(120, 12);
            memberFilterComboBox.Name = "memberFilterComboBox";
            memberFilterComboBox.Size = new Size(200, 23);
            memberFilterComboBox.TabIndex = 1;
            memberFilterComboBox.SelectedIndexChanged += MemberFilterComboBox_SelectedIndexChanged;
            // 
            // bookingsGridView
            // 
            bookingsGridView.AllowUserToAddRows = false;
            bookingsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bookingsGridView.Dock = DockStyle.Fill;
            bookingsGridView.Location = new Point(0, 50);
            bookingsGridView.Name = "bookingsGridView";
            bookingsGridView.ReadOnly = true;
            bookingsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bookingsGridView.Size = new Size(1200, 500);
            bookingsGridView.TabIndex = 1;
            bookingsGridView.SelectionChanged += BookingsGridView_SelectionChanged;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(addButton);
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(checkInButton);
            buttonPanel.Controls.Add(refreshButton);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 550);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(1200, 50);
            buttonPanel.TabIndex = 2;
            // 
            // addButton
            // 
            addButton.Location = new Point(10, 10);
            addButton.Name = "addButton";
            addButton.Size = new Size(100, 30);
            addButton.TabIndex = 0;
            addButton.Text = "New Booking";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Enabled = false;
            cancelButton.Location = new Point(120, 10);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 30);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel Booking";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelBookingButton_Click;
            // 
            // checkInButton
            // 
            checkInButton.Enabled = false;
            checkInButton.Location = new Point(230, 10);
            checkInButton.Name = "checkInButton";
            checkInButton.Size = new Size(100, 30);
            checkInButton.TabIndex = 2;
            checkInButton.Text = "Check In";
            checkInButton.UseVisualStyleBackColor = true;
            checkInButton.Click += CheckInButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(340, 10);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(100, 30);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += RefreshButton_Click;
            // 
            // BookingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 600);
            Controls.Add(bookingsGridView);
            Controls.Add(buttonPanel);
            Controls.Add(filterPanel);
            Name = "BookingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bookings Management";
            Load += BookingsForm_Load;
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bookingsGridView).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
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



