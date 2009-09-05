namespace JDT.Calidus.GUI
{
    partial class MainWindow
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.splitRulesViolations = new System.Windows.Forms.SplitContainer();
            this.tvRules = new System.Windows.Forms.TreeView();
            this.lstViolations = new System.Windows.Forms.ListBox();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.lnkSourceDirectory = new System.Windows.Forms.LinkLabel();
            this.lblSourceDir = new System.Windows.Forms.Label();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.cmdRun = new System.Windows.Forms.Button();
            this.stripStatus = new System.Windows.Forms.StatusStrip();
            this.menuMain.SuspendLayout();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.splitRulesViolations.Panel1.SuspendLayout();
            this.splitRulesViolations.Panel2.SuspendLayout();
            this.splitRulesViolations.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(741, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // splitMain
            // 
            this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitMain.Location = new System.Drawing.Point(0, 27);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.tvFiles);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitRulesViolations);
            this.splitMain.Panel2.Controls.Add(this.pnlControl);
            this.splitMain.Size = new System.Drawing.Size(741, 415);
            this.splitMain.SplitterDistance = 245;
            this.splitMain.TabIndex = 1;
            // 
            // tvFiles
            // 
            this.tvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFiles.Location = new System.Drawing.Point(3, 3);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.Size = new System.Drawing.Size(239, 409);
            this.tvFiles.TabIndex = 0;
            // 
            // splitRulesViolations
            // 
            this.splitRulesViolations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitRulesViolations.Location = new System.Drawing.Point(3, 109);
            this.splitRulesViolations.Name = "splitRulesViolations";
            this.splitRulesViolations.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRulesViolations.Panel1
            // 
            this.splitRulesViolations.Panel1.Controls.Add(this.tvRules);
            // 
            // splitRulesViolations.Panel2
            // 
            this.splitRulesViolations.Panel2.Controls.Add(this.lstViolations);
            this.splitRulesViolations.Size = new System.Drawing.Size(486, 303);
            this.splitRulesViolations.SplitterDistance = 151;
            this.splitRulesViolations.TabIndex = 1;
            // 
            // tvRules
            // 
            this.tvRules.CheckBoxes = true;
            this.tvRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRules.Location = new System.Drawing.Point(0, 0);
            this.tvRules.Name = "tvRules";
            this.tvRules.Size = new System.Drawing.Size(486, 151);
            this.tvRules.TabIndex = 0;
            this.tvRules.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvRules_AfterCheck);
            // 
            // lstViolations
            // 
            this.lstViolations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViolations.FormattingEnabled = true;
            this.lstViolations.Location = new System.Drawing.Point(0, 0);
            this.lstViolations.Name = "lstViolations";
            this.lstViolations.Size = new System.Drawing.Size(486, 147);
            this.lstViolations.TabIndex = 0;
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.lnkSourceDirectory);
            this.pnlControl.Controls.Add(this.lblSourceDir);
            this.pnlControl.Controls.Add(this.prgProgress);
            this.pnlControl.Controls.Add(this.cmdRun);
            this.pnlControl.Location = new System.Drawing.Point(3, 3);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(486, 100);
            this.pnlControl.TabIndex = 0;
            // 
            // lnkSourceDirectory
            // 
            this.lnkSourceDirectory.AutoSize = true;
            this.lnkSourceDirectory.Location = new System.Drawing.Point(164, 9);
            this.lnkSourceDirectory.Name = "lnkSourceDirectory";
            this.lnkSourceDirectory.Size = new System.Drawing.Size(55, 13);
            this.lnkSourceDirectory.TabIndex = 3;
            this.lnkSourceDirectory.TabStop = true;
            this.lnkSourceDirectory.Text = "<Not Set>";
            this.lnkSourceDirectory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSourceDirectory_LinkClicked);
            // 
            // lblSourceDir
            // 
            this.lblSourceDir.AutoSize = true;
            this.lblSourceDir.Location = new System.Drawing.Point(96, 9);
            this.lblSourceDir.Name = "lblSourceDir";
            this.lblSourceDir.Size = new System.Drawing.Size(44, 13);
            this.lblSourceDir.TabIndex = 2;
            this.lblSourceDir.Text = "Source:";
            // 
            // prgProgress
            // 
            this.prgProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgProgress.Location = new System.Drawing.Point(15, 36);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(451, 49);
            this.prgProgress.TabIndex = 1;
            // 
            // cmdRun
            // 
            this.cmdRun.Location = new System.Drawing.Point(15, 4);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 26);
            this.cmdRun.TabIndex = 0;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = true;
            // 
            // stripStatus
            // 
            this.stripStatus.Location = new System.Drawing.Point(0, 445);
            this.stripStatus.Name = "stripStatus";
            this.stripStatus.Size = new System.Drawing.Size(741, 22);
            this.stripStatus.TabIndex = 2;
            this.stripStatus.Text = "statusStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 467);
            this.Controls.Add(this.stripStatus);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainWindow";
            this.Text = "Calidus GUI Runner";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            this.splitRulesViolations.Panel1.ResumeLayout(false);
            this.splitRulesViolations.Panel2.ResumeLayout(false);
            this.splitRulesViolations.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.TreeView tvFiles;
        private System.Windows.Forms.StatusStrip stripStatus;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.SplitContainer splitRulesViolations;
        private System.Windows.Forms.ProgressBar prgProgress;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.ListBox lstViolations;
        private System.Windows.Forms.Label lblSourceDir;
        private System.Windows.Forms.LinkLabel lnkSourceDirectory;
        private System.Windows.Forms.TreeView tvRules;
    }
}