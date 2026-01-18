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
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            membersMenu = new ToolStripMenuItem();
            viewMembersMenuItem = new ToolStripMenuItem();
            bookingsMenu = new ToolStripMenuItem();
            viewBookingsMenuItem = new ToolStripMenuItem();
            classesMenu = new ToolStripMenuItem();
            viewClassesMenuItem = new ToolStripMenuItem();
            subscriptionsMenu = new ToolStripMenuItem();
            viewSubscriptionsMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, membersMenu, bookingsMenu, classesMenu, subscriptionsMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1200, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { exitMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "File";
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(92, 22);
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += ExitMenuItem_Click;
            // 
            // membersMenu
            // 
            membersMenu.DropDownItems.AddRange(new ToolStripItem[] { viewMembersMenuItem });
            membersMenu.Name = "membersMenu";
            membersMenu.Size = new Size(69, 20);
            membersMenu.Text = "Members";
            // 
            // viewMembersMenuItem
            // 
            viewMembersMenuItem.Name = "viewMembersMenuItem";
            viewMembersMenuItem.Size = new Size(152, 22);
            viewMembersMenuItem.Text = "View Members";
            viewMembersMenuItem.Click += ViewMembersMenuItem_Click;
            // 
            // bookingsMenu
            // 
            bookingsMenu.DropDownItems.AddRange(new ToolStripItem[] { viewBookingsMenuItem });
            bookingsMenu.Name = "bookingsMenu";
            bookingsMenu.Size = new Size(68, 20);
            bookingsMenu.Text = "Bookings";
            // 
            // viewBookingsMenuItem
            // 
            viewBookingsMenuItem.Name = "viewBookingsMenuItem";
            viewBookingsMenuItem.Size = new Size(151, 22);
            viewBookingsMenuItem.Text = "View Bookings";
            viewBookingsMenuItem.Click += ViewBookingsMenuItem_Click;
            // 
            // classesMenu
            // 
            classesMenu.DropDownItems.AddRange(new ToolStripItem[] { viewClassesMenuItem });
            classesMenu.Name = "classesMenu";
            classesMenu.Size = new Size(57, 20);
            classesMenu.Text = "Classes";
            // 
            // viewClassesMenuItem
            // 
            viewClassesMenuItem.Name = "viewClassesMenuItem";
            viewClassesMenuItem.Size = new Size(140, 22);
            viewClassesMenuItem.Text = "View Classes";
            viewClassesMenuItem.Click += ViewClassesMenuItem_Click;
            // 
            // subscriptionsMenu
            // 
            subscriptionsMenu.DropDownItems.AddRange(new ToolStripItem[] { viewSubscriptionsMenuItem });
            subscriptionsMenu.Name = "subscriptionsMenu";
            subscriptionsMenu.Size = new Size(90, 20);
            subscriptionsMenu.Text = "Subscriptions";
            // 
            // viewSubscriptionsMenuItem
            // 
            viewSubscriptionsMenuItem.Name = "viewSubscriptionsMenuItem";
            viewSubscriptionsMenuItem.Size = new Size(173, 22);
            viewSubscriptionsMenuItem.Text = "View Subscriptions";
            viewSubscriptionsMenuItem.Click += ViewSubscriptionsMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 778);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1200, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 17);
            statusLabel.Text = "Ready";
            // 
            
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gym Management System";
            WindowState = FormWindowState.Maximized;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

