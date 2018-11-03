namespace ezCryptor.Forms
{
    partial class MainForm
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
            this.mainStatusBar = new System.Windows.Forms.StatusStrip();
            this.mainProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.algorithmsCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chunkSizeCombo = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.keySizeCombo = new System.Windows.Forms.ComboBox();
            this.paddingCombo = new System.Windows.Forms.ComboBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusBar
            // 
            this.mainStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainProgressBar,
            this.mainStatus});
            this.mainStatusBar.Location = new System.Drawing.Point(0, 391);
            this.mainStatusBar.Name = "mainStatusBar";
            this.mainStatusBar.Size = new System.Drawing.Size(520, 22);
            this.mainStatusBar.TabIndex = 0;
            this.mainStatusBar.Text = "statusStrip1";
            // 
            // mainProgressBar
            // 
            this.mainProgressBar.Name = "mainProgressBar";
            this.mainProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // mainStatus
            // 
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(61, 17);
            this.mainStatus.Text = "Running...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.topPanel);
            this.panel1.Controls.Add(this.mainTabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 367);
            this.panel1.TabIndex = 1;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.panel6);
            this.topPanel.Controls.Add(this.panel5);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(520, 65);
            this.topPanel.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.algorithmsCombo);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.chunkSizeCombo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(259, 65);
            this.panel6.TabIndex = 23;
            // 
            // algorithmsCombo
            // 
            this.algorithmsCombo.DisplayMember = "Name";
            this.algorithmsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithmsCombo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.algorithmsCombo.FormattingEnabled = true;
            this.algorithmsCombo.Location = new System.Drawing.Point(73, 5);
            this.algorithmsCombo.Name = "algorithmsCombo";
            this.algorithmsCombo.Size = new System.Drawing.Size(163, 21);
            this.algorithmsCombo.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Algorithm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Chunk Size: ";
            // 
            // chunkSizeCombo
            // 
            this.chunkSizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chunkSizeCombo.FormattingEnabled = true;
            this.chunkSizeCombo.Items.AddRange(new object[] {
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192",
            "16384",
            "32768",
            "65536",
            "131072",
            "262144",
            "524288",
            "1048576"});
            this.chunkSizeCombo.Location = new System.Drawing.Point(73, 38);
            this.chunkSizeCombo.Name = "chunkSizeCombo";
            this.chunkSizeCombo.Size = new System.Drawing.Size(163, 21);
            this.chunkSizeCombo.TabIndex = 25;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.keySizeCombo);
            this.panel5.Controls.Add(this.paddingCombo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(265, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(255, 65);
            this.panel5.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Key Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Padding:";
            // 
            // keySizeCombo
            // 
            this.keySizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keySizeCombo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.keySizeCombo.FormattingEnabled = true;
            this.keySizeCombo.Location = new System.Drawing.Point(79, 5);
            this.keySizeCombo.Name = "keySizeCombo";
            this.keySizeCombo.Size = new System.Drawing.Size(163, 21);
            this.keySizeCombo.TabIndex = 27;
            // 
            // paddingCombo
            // 
            this.paddingCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paddingCombo.Enabled = false;
            this.paddingCombo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.paddingCombo.FormattingEnabled = true;
            this.paddingCombo.Items.AddRange(new object[] {
            "PKCS1",
            "ANSI",
            "NONE"});
            this.paddingCombo.Location = new System.Drawing.Point(79, 38);
            this.paddingCombo.Name = "paddingCombo";
            this.paddingCombo.Size = new System.Drawing.Size(163, 21);
            this.paddingCombo.TabIndex = 26;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Location = new System.Drawing.Point(0, 65);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(520, 302);
            this.mainTabControl.TabIndex = 2;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(520, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolBtn});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolBtn
            // 
            this.aboutToolBtn.Name = "aboutToolBtn";
            this.aboutToolBtn.Size = new System.Drawing.Size(107, 22);
            this.aboutToolBtn.Text = "&About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 413);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainStatusBar);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(520, 38);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easy Cryptor v0.1 BETA";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainStatusBar.ResumeLayout(false);
            this.mainStatusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusBar;
        private System.Windows.Forms.ToolStripProgressBar mainProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel mainStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox algorithmsCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox chunkSizeCombo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox keySizeCombo;
        private System.Windows.Forms.ComboBox paddingCombo;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.ToolStripMenuItem aboutToolBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

