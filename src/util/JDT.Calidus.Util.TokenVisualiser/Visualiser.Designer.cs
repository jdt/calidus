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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdParse = new System.Windows.Forms.Button();
            this.windowContainer = new System.Windows.Forms.SplitContainer();
            this.rtSource = new System.Windows.Forms.RichTextBox();
            this.lstDetails = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstTokens = new System.Windows.Forms.ListBox();
            this.statusStrip.SuspendLayout();
            this.windowContainer.Panel1.SuspendLayout();
            this.windowContainer.Panel2.SuspendLayout();
            this.windowContainer.SuspendLayout();
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
            this.windowContainer.Panel2.Controls.Add(this.lstDetails);
            this.windowContainer.Panel2.Controls.Add(this.label2);
            this.windowContainer.Panel2.Controls.Add(this.label1);
            this.windowContainer.Panel2.Controls.Add(this.cmdParse);
            this.windowContainer.Panel2.Controls.Add(this.lstTokens);
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
            this.rtSource.Text = "";
            this.rtSource.SelectionChanged += new System.EventHandler(this.rtSource_SelectionChanged);
            // 
            // lstDetails
            // 
            this.lstDetails.FormattingEnabled = true;
            this.lstDetails.Location = new System.Drawing.Point(8, 268);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(181, 95);
            this.lstDetails.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Token list:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Token details:";
            // 
            // lstTokens
            // 
            this.lstTokens.DisplayMember = "Type";
            this.lstTokens.FormattingEnabled = true;
            this.lstTokens.Location = new System.Drawing.Point(8, 49);
            this.lstTokens.Name = "lstTokens";
            this.lstTokens.Size = new System.Drawing.Size(181, 199);
            this.lstTokens.TabIndex = 7;
            this.lstTokens.SelectedIndexChanged += new System.EventHandler(this.lstTokens_SelectedIndexChanged);
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
            this.windowContainer.Panel2.PerformLayout();
            this.windowContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button cmdParse;
        private System.Windows.Forms.SplitContainer windowContainer;
        private System.Windows.Forms.RichTextBox rtSource;
        private System.Windows.Forms.ListBox lstTokens;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstDetails;
    }
}