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
            this.ruleConfigurationView = new JDT.Calidus.GUI.Views.RuleConfigurationView();
            this.SuspendLayout();
            // 
            // ruleConfigurationView
            // 
            this.ruleConfigurationView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ruleConfigurationView.Location = new System.Drawing.Point(0, 0);
            this.ruleConfigurationView.Name = "ruleConfigurationView";
            this.ruleConfigurationView.Size = new System.Drawing.Size(688, 336);
            this.ruleConfigurationView.TabIndex = 0;
            // 
            // RuleConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 336);
            this.Controls.Add(this.ruleConfigurationView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RuleConfigurationWindow";
            this.Text = "Calidus Rule Configuration";
            this.ResumeLayout(false);

        }

        #endregion

        private JDT.Calidus.GUI.Views.RuleConfigurationView ruleConfigurationView;

    }
}