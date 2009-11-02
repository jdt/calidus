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
            this.lblGenericToken = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblGenericStatement = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.tabBlocks = new System.Windows.Forms.TabPage();
            this.lstBlockDetails = new System.Windows.Forms.ListBox();
            this.lstBlockList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabLines = new System.Windows.Forms.TabPage();
            this.lstLineDetails = new System.Windows.Forms.ListBox();
            this.lstLineList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.windowContainer.Panel1.SuspendLayout();
            this.windowContainer.Panel2.SuspendLayout();
            this.windowContainer.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.tabTokens.SuspendLayout();
            this.tabStatements.SuspendLayout();
            this.tabBlocks.SuspendLayout();
            this.tabLines.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.lblGenericToken,
            this.lblGenericStatement});
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
            // lblGenericToken
            // 
            this.lblGenericToken.Name = "lblGenericToken";
            this.lblGenericToken.Size = new System.Drawing.Size(0, 17);
            // 
            // lblGenericStatement
            // 
            this.lblGenericStatement.Name = "lblGenericStatement";
            this.lblGenericStatement.Size = new System.Drawing.Size(0, 17);
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
            this.windowContainer.SplitterDistance = 856;
            this.windowContainer.TabIndex = 11;
            // 
            // rtSource
            // 
            this.rtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtSource.Location = new System.Drawing.Point(0, 0);
            this.rtSource.Name = "rtSource";
            this.rtSource.Size = new System.Drawing.Size(856, 531);
            this.rtSource.TabIndex = 9;
            this.rtSource.Text = resources.GetString("rtSource.Text");
            this.rtSource.SelectionChanged += new System.EventHandler(this.rtSource_SelectionChanged);
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.tabTokens);
            this.tabDisplay.Controls.Add(this.tabStatements);
            this.tabDisplay.Controls.Add(this.tabBlocks);
            this.tabDisplay.Controls.Add(this.tabLines);
            this.tabDisplay.Location = new System.Drawing.Point(8, 36);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.SelectedIndex = 0;
            this.tabDisplay.Size = new System.Drawing.Size(220, 492);
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
            this.tabTokens.Size = new System.Drawing.Size(212, 466);
            this.tabTokens.TabIndex = 0;
            this.tabTokens.Text = "Tokens";
            this.tabTokens.UseVisualStyleBackColor = true;
            // 
            // lstTokenDetails
            // 
            this.lstTokenDetails.FormattingEnabled = true;
            this.lstTokenDetails.Location = new System.Drawing.Point(6, 365);
            this.lstTokenDetails.Name = "lstTokenDetails";
            this.lstTokenDetails.Size = new System.Drawing.Size(200, 95);
            this.lstTokenDetails.TabIndex = 18;
            // 
            // lstTokenList
            // 
            this.lstTokenList.DisplayMember = "Type";
            this.lstTokenList.FormattingEnabled = true;
            this.lstTokenList.Location = new System.Drawing.Point(6, 6);
            this.lstTokenList.Name = "lstTokenList";
            this.lstTokenList.Size = new System.Drawing.Size(200, 342);
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
            this.tabStatements.Size = new System.Drawing.Size(212, 466);
            this.tabStatements.TabIndex = 1;
            this.tabStatements.Text = "Statements";
            this.tabStatements.UseVisualStyleBackColor = true;
            // 
            // lstStatementDetails
            // 
            this.lstStatementDetails.FormattingEnabled = true;
            this.lstStatementDetails.Location = new System.Drawing.Point(6, 365);
            this.lstStatementDetails.Name = "lstStatementDetails";
            this.lstStatementDetails.Size = new System.Drawing.Size(200, 95);
            this.lstStatementDetails.TabIndex = 21;
            // 
            // lstStatementList
            // 
            this.lstStatementList.DisplayMember = "Type";
            this.lstStatementList.FormattingEnabled = true;
            this.lstStatementList.Location = new System.Drawing.Point(6, 6);
            this.lstStatementList.Name = "lstStatementList";
            this.lstStatementList.Size = new System.Drawing.Size(200, 342);
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
            // tabBlocks
            // 
            this.tabBlocks.Controls.Add(this.lstBlockDetails);
            this.tabBlocks.Controls.Add(this.lstBlockList);
            this.tabBlocks.Controls.Add(this.label3);
            this.tabBlocks.Location = new System.Drawing.Point(4, 22);
            this.tabBlocks.Name = "tabBlocks";
            this.tabBlocks.Size = new System.Drawing.Size(212, 466);
            this.tabBlocks.TabIndex = 2;
            this.tabBlocks.Text = "Blocks";
            this.tabBlocks.UseVisualStyleBackColor = true;
            // 
            // lstBlockDetails
            // 
            this.lstBlockDetails.FormattingEnabled = true;
            this.lstBlockDetails.Location = new System.Drawing.Point(5, 365);
            this.lstBlockDetails.Name = "lstBlockDetails";
            this.lstBlockDetails.Size = new System.Drawing.Size(202, 95);
            this.lstBlockDetails.TabIndex = 24;
            // 
            // lstBlockList
            // 
            this.lstBlockList.DisplayMember = "Type";
            this.lstBlockList.FormattingEnabled = true;
            this.lstBlockList.Location = new System.Drawing.Point(5, 6);
            this.lstBlockList.Name = "lstBlockList";
            this.lstBlockList.Size = new System.Drawing.Size(202, 342);
            this.lstBlockList.TabIndex = 22;
            this.lstBlockList.SelectedIndexChanged += new System.EventHandler(this.lstBlockList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Block details:";
            // 
            // tabLines
            // 
            this.tabLines.Controls.Add(this.lstLineDetails);
            this.tabLines.Controls.Add(this.lstLineList);
            this.tabLines.Controls.Add(this.label4);
            this.tabLines.Location = new System.Drawing.Point(4, 22);
            this.tabLines.Name = "tabLines";
            this.tabLines.Size = new System.Drawing.Size(212, 466);
            this.tabLines.TabIndex = 3;
            this.tabLines.Text = "Lines";
            this.tabLines.UseVisualStyleBackColor = true;
            // 
            // lstLineDetails
            // 
            this.lstLineDetails.FormattingEnabled = true;
            this.lstLineDetails.Location = new System.Drawing.Point(6, 365);
            this.lstLineDetails.Name = "lstLineDetails";
            this.lstLineDetails.Size = new System.Drawing.Size(202, 95);
            this.lstLineDetails.TabIndex = 27;
            // 
            // lstLineList
            // 
            this.lstLineList.DisplayMember = "Type";
            this.lstLineList.FormattingEnabled = true;
            this.lstLineList.Location = new System.Drawing.Point(6, 6);
            this.lstLineList.Name = "lstLineList";
            this.lstLineList.Size = new System.Drawing.Size(202, 342);
            this.lstLineList.TabIndex = 25;
            this.lstLineList.SelectedIndexChanged += new System.EventHandler(this.lstLineList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Line details:";
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
            this.tabBlocks.ResumeLayout(false);
            this.tabBlocks.PerformLayout();
            this.tabLines.ResumeLayout(false);
            this.tabLines.PerformLayout();
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
        private System.Windows.Forms.TabPage tabBlocks;
        private System.Windows.Forms.ListBox lstBlockDetails;
        private System.Windows.Forms.ListBox lstBlockList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabLines;
        private System.Windows.Forms.ListBox lstLineDetails;
        private System.Windows.Forms.ListBox lstLineList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel lblGenericToken;
        private System.Windows.Forms.ToolStripStatusLabel lblGenericStatement;
    }
}