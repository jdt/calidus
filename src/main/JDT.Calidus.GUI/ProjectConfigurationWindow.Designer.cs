namespace JDT.Calidus.GUI
{
    partial class ProjectConfigurationWindow
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
            this.projectConfigurationView = new JDT.Calidus.GUI.Views.ProjectConfigurationView();
            this.SuspendLayout();
            // 
            // projectConfigurationView
            // 
            this.projectConfigurationView.IgnoreAssemblyFiles = false;
            this.projectConfigurationView.IgnoreDesignerFiles = false;
            this.projectConfigurationView.IgnoreProgramFiles = false;
            this.projectConfigurationView.Location = new System.Drawing.Point(5, 12);
            this.projectConfigurationView.Name = "projectConfigurationView";
            this.projectConfigurationView.Size = new System.Drawing.Size(278, 71);
            this.projectConfigurationView.TabIndex = 0;
            // 
            // ProjectConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 93);
            this.Controls.Add(this.projectConfigurationView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectConfigurationWindow";
            this.Text = "Calidus Project Configuration";
            this.ResumeLayout(false);

        }

        #endregion

        private JDT.Calidus.GUI.Views.ProjectConfigurationView projectConfigurationView;

    }
}