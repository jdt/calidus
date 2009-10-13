namespace JDT.Calidus.GUI.Views
{
    partial class RuleConfigurationView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdSave = new System.Windows.Forms.Button();
            this.ruleTreeView = new JDT.Calidus.GUI.Views.RuleTreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lstParameters = new System.Windows.Forms.ListBox();
            this.parameterLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
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
            this.mainContainer.Panel1.Controls.Add(this.panel2);
            this.mainContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.panel1);
            this.mainContainer.Size = new System.Drawing.Size(687, 341);
            this.mainContainer.SplitterDistance = 226;
            this.mainContainer.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdSave);
            this.panel2.Controls.Add(this.ruleTreeView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 331);
            this.panel2.TabIndex = 7;
            // 
            // cmdSave
            // 
            this.cmdSave.Image = global::JDT.Calidus.GUI.Properties.Resources.floppy_32x32;
            this.cmdSave.Location = new System.Drawing.Point(3, 3);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(36, 36);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // ruleTreeView
            // 
            this.ruleTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ruleTreeView.Location = new System.Drawing.Point(3, 45);
            this.ruleTreeView.Name = "ruleTreeView";
            this.ruleTreeView.Size = new System.Drawing.Size(207, 281);
            this.ruleTreeView.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.grpSettings);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 341);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Rule description";
            // 
            // grpSettings
            // 
            this.grpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSettings.Controls.Add(this.splitContainer);
            this.grpSettings.Location = new System.Drawing.Point(3, 74);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(451, 262);
            this.grpSettings.TabIndex = 8;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 16);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lstParameters);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.parameterLayoutPanel);
            this.splitContainer.Size = new System.Drawing.Size(445, 243);
            this.splitContainer.SplitterDistance = 145;
            this.splitContainer.TabIndex = 11;
            // 
            // lstParameters
            // 
            this.lstParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstParameters.FormattingEnabled = true;
            this.lstParameters.Location = new System.Drawing.Point(0, 0);
            this.lstParameters.Name = "lstParameters";
            this.lstParameters.Size = new System.Drawing.Size(145, 238);
            this.lstParameters.TabIndex = 8;
            this.lstParameters.SelectedIndexChanged += new System.EventHandler(this.lstParameters_SelectedIndexChanged);
            // 
            // parameterLayoutPanel
            // 
            this.parameterLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parameterLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.parameterLayoutPanel.Name = "parameterLayoutPanel";
            this.parameterLayoutPanel.Size = new System.Drawing.Size(296, 243);
            this.parameterLayoutPanel.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(3, 29);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(451, 39);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // RuleConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainContainer);
            this.Name = "RuleConfigurationView";
            this.Size = new System.Drawing.Size(687, 341);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            this.mainContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox lstParameters;
        private System.Windows.Forms.FlowLayoutPanel parameterLayoutPanel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel panel2;
        private RuleTreeView ruleTreeView;
        private System.Windows.Forms.Label label1;
    }
}
