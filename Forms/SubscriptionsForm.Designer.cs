namespace Gym_Manager_System.Forms
{
    partial class SubscriptionsForm
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
            subscriptionsGridView = new DataGridView();
            buttonPanel = new Panel();
            addButton = new Button();
            renewButton = new Button();
            cancelButton = new Button();
            refreshButton = new Button();
            filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)subscriptionsGridView).BeginInit();
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
            // subscriptionsGridView
            // 
            subscriptionsGridView.AllowUserToAddRows = false;
            subscriptionsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            subscriptionsGridView.Dock = DockStyle.Fill;
            subscriptionsGridView.Location = new Point(0, 50);
            subscriptionsGridView.Name = "subscriptionsGridView";
            subscriptionsGridView.ReadOnly = true;
            subscriptionsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            subscriptionsGridView.Size = new Size(1200, 500);
            subscriptionsGridView.TabIndex = 1;
            subscriptionsGridView.SelectionChanged += SubscriptionsGridView_SelectionChanged;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(addButton);
            buttonPanel.Controls.Add(renewButton);
            buttonPanel.Controls.Add(cancelButton);
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
            addButton.Size = new Size(120, 30);
            addButton.TabIndex = 0;
            addButton.Text = "New Subscription";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // renewButton
            // 
            renewButton.Enabled = false;
            renewButton.Location = new Point(140, 10);
            renewButton.Name = "renewButton";
            renewButton.Size = new Size(100, 30);
            renewButton.TabIndex = 1;
            renewButton.Text = "Renew";
            renewButton.UseVisualStyleBackColor = true;
            renewButton.Click += RenewButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Enabled = false;
            cancelButton.Location = new Point(250, 10);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 30);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(360, 10);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(100, 30);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += RefreshButton_Click;
            // 
            // SubscriptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 600);
            Controls.Add(subscriptionsGridView);
            Controls.Add(buttonPanel);
            Controls.Add(filterPanel);
            Name = "SubscriptionsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Subscriptions Management";
            Load += SubscriptionsForm_Load;
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)subscriptionsGridView).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label memberFilterLabel;
        private System.Windows.Forms.ComboBox memberFilterComboBox;
        private System.Windows.Forms.DataGridView subscriptionsGridView;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button renewButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button refreshButton;
    }
}



