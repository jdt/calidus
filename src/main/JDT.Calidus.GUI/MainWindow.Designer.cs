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
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitRulesViolations = new System.Windows.Forms.SplitContainer();
            this.statusView = new JDT.Calidus.GUI.Views.StatusView();
            this.fileListView = new JDT.Calidus.GUI.Views.FileTreeView();
            this.sourceLocationView = new JDT.Calidus.GUI.Views.SourceLocationView();
            this.ruleRunnerView = new JDT.Calidus.GUI.Views.RuleRunnerView();
            this.violationListView = new JDT.Calidus.GUI.Views.ViolationListView();
            this.checkableRuleTreeView = new JDT.Calidus.GUI.Views.CheckableRuleTreeView();
            this.menuMain.SuspendLayout();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitRulesViolations.Panel1.SuspendLayout();
            this.splitRulesViolations.Panel2.SuspendLayout();
            this.splitRulesViolations.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(833, 24);
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
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.rulesToolStripMenuItem.Text = "Rules";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            this.splitMain.Panel1.Controls.Add(this.fileListView);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.panel1);
            this.splitMain.Panel2.Controls.Add(this.splitRulesViolations);
            this.splitMain.Size = new System.Drawing.Size(833, 386);
            this.splitMain.SplitterDistance = 209;
            this.splitMain.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.sourceLocationView);
            this.panel1.Controls.Add(this.ruleRunnerView);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 103);
            this.panel1.TabIndex = 2;
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
            this.splitRulesViolations.Panel1.Controls.Add(this.checkableRuleTreeView);
            // 
            // splitRulesViolations.Panel2
            // 
            this.splitRulesViolations.Panel2.Controls.Add(this.violationListView);
            this.splitRulesViolations.Size = new System.Drawing.Size(614, 274);
            this.splitRulesViolations.SplitterDistance = 136;
            this.splitRulesViolations.TabIndex = 1;
            // 
            // statusView
            // 
            this.statusView.Location = new System.Drawing.Point(0, 416);
            this.statusView.Name = "statusView";
            this.statusView.Size = new System.Drawing.Size(833, 22);
            this.statusView.TabIndex = 2;
            this.statusView.Text = "statusView1";
            // 
            // fileListView
            // 
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.Location = new System.Drawing.Point(0, 0);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(209, 386);
            this.fileListView.TabIndex = 0;
            // 
            // sourceLocationView
            // 
            this.sourceLocationView.Location = new System.Drawing.Point(79, 8);
            this.sourceLocationView.Name = "sourceLocationView";
            this.sourceLocationView.Size = new System.Drawing.Size(298, 20);
            this.sourceLocationView.TabIndex = 1;
            // 
            // ruleRunnerView
            // 
            this.ruleRunnerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ruleRunnerView.Location = new System.Drawing.Point(0, 0);
            this.ruleRunnerView.Name = "ruleRunnerView";
            this.ruleRunnerView.Size = new System.Drawing.Size(612, 101);
            this.ruleRunnerView.TabIndex = 2;
            // 
            // violationListView
            // 
            this.violationListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.violationListView.Location = new System.Drawing.Point(0, 0);
            this.violationListView.Name = "violationListView";
            this.violationListView.Size = new System.Drawing.Size(614, 134);
            this.violationListView.TabIndex = 0;
            // 
            // checkableRuleTreeView
            // 
            this.checkableRuleTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkableRuleTreeView.Location = new System.Drawing.Point(0, 0);
            this.checkableRuleTreeView.Name = "checkableRuleTreeView";
            this.checkableRuleTreeView.Size = new System.Drawing.Size(614, 136);
            this.checkableRuleTreeView.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 438);
            this.Controls.Add(this.statusView);
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
            this.panel1.ResumeLayout(false);
            this.splitRulesViolations.Panel1.ResumeLayout(false);
            this.splitRulesViolations.Panel2.ResumeLayout(false);
            this.splitRulesViolations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitRulesViolations;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private JDT.Calidus.GUI.Views.ViolationListView violationListView;
        private JDT.Calidus.GUI.Views.FileTreeView fileListView;
        private System.Windows.Forms.Panel panel1;
        private JDT.Calidus.GUI.Views.SourceLocationView sourceLocationView;
        private JDT.Calidus.GUI.Views.RuleRunnerView ruleRunnerView;
        private JDT.Calidus.GUI.Views.StatusView statusView;
        private JDT.Calidus.GUI.Views.CheckableRuleTreeView checkableRuleTreeView;
    }
}