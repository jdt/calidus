namespace JDT.Calidus.Util.TokenVisualiser
{
    partial class Visualiser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualiser));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdParse = new System.Windows.Forms.Button();
            this.windowContainer = new System.Windows.Forms.SplitContainer();
            this.rtSource = new System.Windows.Forms.RichTextBox();
            this.tabDisplay = new System.Windows.Forms.TabControl();
            this.tabTokens = new System.Windows.Forms.TabPage();
            this.lstTokenDetails = new System.Windows.Forms.ListBox();
            this.lstTokenList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabStatements = new System.Windows.Forms.TabPage();
            this.lstStatementDetails = new System.Windows.Forms.ListBox();
            this.lstStatementList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.windowContainer.Panel1.SuspendLayout();
            this.windowContainer.Panel2.SuspendLayout();
            this.windowContainer.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.tabTokens.SuspendLayout();
            this.tabStatements.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 531);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1091, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // cmdParse
            // 
            this.cmdParse.Location = new System.Drawing.Point(8, 7);
            this.cmdParse.Name = "cmdParse";
            this.cmdParse.Size = new System.Drawing.Size(75, 23);
            this.cmdParse.TabIndex = 9;
            this.cmdParse.Text = "Parse";
            this.cmdParse.UseVisualStyleBackColor = true;
            this.cmdParse.Click += new System.EventHandler(this.cmdParse_Click);
            // 
            // windowContainer
            // 
            this.windowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.windowContainer.Location = new System.Drawing.Point(0, 0);
            this.windowContainer.Name = "windowContainer";
            // 
            // windowContainer.Panel1
            // 
            this.windowContainer.Panel1.Controls.Add(this.rtSource);
            // 
            // windowContainer.Panel2
            // 
            this.windowContainer.Panel2.Controls.Add(this.tabDisplay);
            this.windowContainer.Panel2.Controls.Add(this.cmdParse);
            this.windowContainer.Size = new System.Drawing.Size(1091, 531);
            this.windowContainer.SplitterDistance = 886;
            this.windowContainer.TabIndex = 11;
            // 
            // rtSource
            // 
            this.rtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtSource.Location = new System.Drawing.Point(0, 0);
            this.rtSource.Name = "rtSource";
            this.rtSource.Size = new System.Drawing.Size(886, 531);
            this.rtSource.TabIndex = 9;
            this.rtSource.Text = resources.GetString("rtSource.Text");
            this.rtSource.SelectionChanged += new System.EventHandler(this.rtSource_SelectionChanged);
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.tabTokens);
            this.tabDisplay.Controls.Add(this.tabStatements);
            this.tabDisplay.Location = new System.Drawing.Point(8, 36);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.SelectedIndex = 0;
            this.tabDisplay.Size = new System.Drawing.Size(190, 492);
            this.tabDisplay.TabIndex = 10;
            this.tabDisplay.SelectedIndexChanged += new System.EventHandler(this.tabDisplay_SelectedIndexChanged);
            // 
            // tabTokens
            // 
            this.tabTokens.Controls.Add(this.lstTokenDetails);
            this.tabTokens.Controls.Add(this.lstTokenList);
            this.tabTokens.Controls.Add(this.label1);
            this.tabTokens.Location = new System.Drawing.Point(4, 22);
            this.tabTokens.Name = "tabTokens";
            this.tabTokens.Padding = new System.Windows.Forms.Padding(3);
            this.tabTokens.Size = new System.Drawing.Size(182, 466);
            this.tabTokens.TabIndex = 0;
            this.tabTokens.Text = "Tokens";
            this.tabTokens.UseVisualStyleBackColor = true;
            // 
            // lstTokenDetails
            // 
            this.lstTokenDetails.FormattingEnabled = true;
            this.lstTokenDetails.Location = new System.Drawing.Point(6, 365);
            this.lstTokenDetails.Name = "lstTokenDetails";
            this.lstTokenDetails.Size = new System.Drawing.Size(173, 95);
            this.lstTokenDetails.TabIndex = 18;
            // 
            // lstTokenList
            // 
            this.lstTokenList.DisplayMember = "Type";
            this.lstTokenList.FormattingEnabled = true;
            this.lstTokenList.Location = new System.Drawing.Point(6, 6);
            this.lstTokenList.Name = "lstTokenList";
            this.lstTokenList.Size = new System.Drawing.Size(173, 342);
            this.lstTokenList.TabIndex = 16;
            this.lstTokenList.SelectedIndexChanged += new System.EventHandler(this.lstTokens_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Token details:";
            // 
            // tabStatements
            // 
            this.tabStatements.Controls.Add(this.lstStatementDetails);
            this.tabStatements.Controls.Add(this.lstStatementList);
            this.tabStatements.Controls.Add(this.label2);
            this.tabStatements.Location = new System.Drawing.Point(4, 22);
            this.tabStatements.Name = "tabStatements";
            this.tabStatements.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatements.Size = new System.Drawing.Size(182, 466);
            this.tabStatements.TabIndex = 1;
            this.tabStatements.Text = "Statements";
            this.tabStatements.UseVisualStyleBackColor = true;
            // 
            // lstStatementDetails
            // 
            this.lstStatementDetails.FormattingEnabled = true;
            this.lstStatementDetails.Location = new System.Drawing.Point(6, 365);
            this.lstStatementDetails.Name = "lstStatementDetails";
            this.lstStatementDetails.Size = new System.Drawing.Size(173, 95);
            this.lstStatementDetails.TabIndex = 21;
            // 
            // lstStatementList
            // 
            this.lstStatementList.DisplayMember = "Type";
            this.lstStatementList.FormattingEnabled = true;
            this.lstStatementList.Location = new System.Drawing.Point(6, 6);
            this.lstStatementList.Name = "lstStatementList";
            this.lstStatementList.Size = new System.Drawing.Size(173, 342);
            this.lstStatementList.TabIndex = 19;
            this.lstStatementList.SelectedIndexChanged += new System.EventHandler(this.lstStatementList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Statement details:";
            // 
            // Visualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 553);
            this.Controls.Add(this.windowContainer);
            this.Controls.Add(this.statusStrip);
            this.Name = "Visualiser";
            this.Text = "Visualiser";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.windowContainer.Panel1.ResumeLayout(false);
            this.windowContainer.Panel2.ResumeLayout(false);
            this.windowContainer.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            this.tabTokens.ResumeLayout(false);
            this.tabTokens.PerformLayout();
            this.tabStatements.ResumeLayout(false);
            this.tabStatements.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button cmdParse;
        private System.Windows.Forms.SplitContainer windowContainer;
        private System.Windows.Forms.RichTextBox rtSource;
        private System.Windows.Forms.TabControl tabDisplay;
        private System.Windows.Forms.TabPage tabTokens;
        private System.Windows.Forms.ListBox lstTokenDetails;
        private System.Windows.Forms.ListBox lstTokenList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabStatements;
        private System.Windows.Forms.ListBox lstStatementDetails;
        private System.Windows.Forms.ListBox lstStatementList;
        private System.Windows.Forms.Label label2;
    }
}