namespace JDT.Calidus.GUI
{
    partial class RuleConfigurationWindow
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
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.tvRules = new System.Windows.Forms.TreeView();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.lstParameters = new System.Windows.Forms.ListBox();
            this.lblRuleName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.parameterLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.tvRules);
            this.mainContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.grpSettings);
            this.mainContainer.Panel2.Controls.Add(this.lblRuleName);
            this.mainContainer.Panel2.Controls.Add(this.txtDescription);
            this.mainContainer.Size = new System.Drawing.Size(679, 339);
            this.mainContainer.SplitterDistance = 226;
            this.mainContainer.TabIndex = 0;
            // 
            // tvRules
            // 
            this.tvRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRules.Location = new System.Drawing.Point(5, 5);
            this.tvRules.Name = "tvRules";
            this.tvRules.Size = new System.Drawing.Size(216, 329);
            this.tvRules.TabIndex = 0;
            this.tvRules.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRules_AfterSelect);
            this.tvRules.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvRules_BeforeSelect);
            // 
            // grpSettings
            // 
            this.grpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSettings.Controls.Add(this.parameterLayoutPanel);
            this.grpSettings.Controls.Add(this.cmdSave);
            this.grpSettings.Controls.Add(this.lstParameters);
            this.grpSettings.Location = new System.Drawing.Point(7, 106);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(430, 228);
            this.grpSettings.TabIndex = 2;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // lstParameters
            // 
            this.lstParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstParameters.FormattingEnabled = true;
            this.lstParameters.Location = new System.Drawing.Point(6, 19);
            this.lstParameters.Name = "lstParameters";
            this.lstParameters.Size = new System.Drawing.Size(120, 199);
            this.lstParameters.TabIndex = 5;
            this.lstParameters.SelectedIndexChanged += new System.EventHandler(this.lstParameters_SelectedIndexChanged);
            // 
            // lblRuleName
            // 
            this.lblRuleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRuleName.Location = new System.Drawing.Point(4, 9);
            this.lblRuleName.Name = "lblRuleName";
            this.lblRuleName.Size = new System.Drawing.Size(433, 13);
            this.lblRuleName.TabIndex = 1;
            this.lblRuleName.Text = "label1";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(7, 31);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(430, 76);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = global::JDT.Calidus.GUI.Properties.Resources.floppy_32x32;
            this.cmdSave.Location = new System.Drawing.Point(386, 180);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(38, 38);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // parameterLayoutPanel
            // 
            this.parameterLayoutPanel.Location = new System.Drawing.Point(133, 20);
            this.parameterLayoutPanel.Name = "parameterLayoutPanel";
            this.parameterLayoutPanel.Size = new System.Drawing.Size(291, 154);
            this.parameterLayoutPanel.TabIndex = 7;
            // 
            // RuleConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 339);
            this.Controls.Add(this.mainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RuleConfigurationWindow";
            this.Text = "Calidus Rule Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RuleConfigurationWindow_FormClosing);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            this.mainContainer.Panel2.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.grpSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.TreeView tvRules;
        private System.Windows.Forms.Label lblRuleName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.ListBox lstParameters;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.FlowLayoutPanel parameterLayoutPanel;
    }
}