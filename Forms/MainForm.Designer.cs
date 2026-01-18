namespace Gym_Manager_System.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membersMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMembersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingsMenu;
        private System.Windows.Forms.ToolStripMenuItem viewBookingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesMenu;
        private System.Windows.Forms.ToolStripMenuItem viewClassesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem viewSubscriptionsMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label welcomeLabel;

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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.membersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMembersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBookingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewClassesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSubscriptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.membersMenu,
            this.bookingsMenu,
            this.classesMenu,
            this.subscriptionsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // membersMenu
            // 
            this.membersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMembersMenuItem});
            this.membersMenu.Name = "membersMenu";
            this.membersMenu.Size = new System.Drawing.Size(65, 20);
            this.membersMenu.Text = "Members";
            // 
            // viewMembersMenuItem
            // 
            this.viewMembersMenuItem.Name = "viewMembersMenuItem";
            this.viewMembersMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewMembersMenuItem.Text = "View Members";
            this.viewMembersMenuItem.Click += new System.EventHandler(this.ViewMembersMenuItem_Click);
            // 
            // bookingsMenu
            // 
            this.bookingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewBookingsMenuItem});
            this.bookingsMenu.Name = "bookingsMenu";
            this.bookingsMenu.Size = new System.Drawing.Size(66, 20);
            this.bookingsMenu.Text = "Bookings";
            // 
            // viewBookingsMenuItem
            // 
            this.viewBookingsMenuItem.Name = "viewBookingsMenuItem";
            this.viewBookingsMenuItem.Size = new System.Drawing.Size(151, 22);
            this.viewBookingsMenuItem.Text = "View Bookings";
            this.viewBookingsMenuItem.Click += new System.EventHandler(this.ViewBookingsMenuItem_Click);
            // 
            // classesMenu
            // 
            this.classesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewClassesMenuItem});
            this.classesMenu.Name = "classesMenu";
            this.classesMenu.Size = new System.Drawing.Size(54, 20);
            this.classesMenu.Text = "Classes";
            // 
            // viewClassesMenuItem
            // 
            this.viewClassesMenuItem.Name = "viewClassesMenuItem";
            this.viewClassesMenuItem.Size = new System.Drawing.Size(139, 22);
            this.viewClassesMenuItem.Text = "View Classes";
            this.viewClassesMenuItem.Click += new System.EventHandler(this.ViewClassesMenuItem_Click);
            // 
            // subscriptionsMenu
            // 
            this.subscriptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSubscriptionsMenuItem});
            this.subscriptionsMenu.Name = "subscriptionsMenu";
            this.subscriptionsMenu.Size = new System.Drawing.Size(87, 20);
            this.subscriptionsMenu.Text = "Subscriptions";
            // 
            // viewSubscriptionsMenuItem
            // 
            this.viewSubscriptionsMenuItem.Name = "viewSubscriptionsMenuItem";
            this.viewSubscriptionsMenuItem.Size = new System.Drawing.Size(172, 22);
            this.viewSubscriptionsMenuItem.Text = "View Subscriptions";
            this.viewSubscriptionsMenuItem.Click += new System.EventHandler(this.ViewSubscriptionsMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 776);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 24);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 19);
            this.statusLabel.Text = "Ready";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcomeLabel.Location = new System.Drawing.Point(50, 100);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(456, 37);
            this.welcomeLabel.TabIndex = 2;
            this.welcomeLabel.Text = "Welcome to Gym Management System";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gym Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

