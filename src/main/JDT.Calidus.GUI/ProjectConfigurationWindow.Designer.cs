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
            this.chkIgnoreDesigner = new System.Windows.Forms.CheckBox();
            this.chkIgnoreAssembly = new System.Windows.Forms.CheckBox();
            this.chkIgnoreProgramFiles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkIgnoreDesigner
            // 
            this.chkIgnoreDesigner.AutoSize = true;
            this.chkIgnoreDesigner.Location = new System.Drawing.Point(13, 13);
            this.chkIgnoreDesigner.Name = "chkIgnoreDesigner";
            this.chkIgnoreDesigner.Size = new System.Drawing.Size(192, 17);
            this.chkIgnoreDesigner.TabIndex = 0;
            this.chkIgnoreDesigner.Text = "Ignore designer files (*.Designer.cs)";
            this.chkIgnoreDesigner.UseVisualStyleBackColor = true;
            this.chkIgnoreDesigner.CheckedChanged += new System.EventHandler(this.chkIgnoreDesigner_CheckedChanged);
            // 
            // chkIgnoreAssembly
            // 
            this.chkIgnoreAssembly.AutoSize = true;
            this.chkIgnoreAssembly.Location = new System.Drawing.Point(13, 37);
            this.chkIgnoreAssembly.Name = "chkIgnoreAssembly";
            this.chkIgnoreAssembly.Size = new System.Drawing.Size(272, 17);
            this.chkIgnoreAssembly.TabIndex = 1;
            this.chkIgnoreAssembly.Text = "Ignore assembly configuration files (AssemblyInfo.cs)";
            this.chkIgnoreAssembly.UseVisualStyleBackColor = true;
            this.chkIgnoreAssembly.CheckedChanged += new System.EventHandler(this.chkIgnoreAssembly_CheckedChanged);
            // 
            // chkIgnoreProgramFiles
            // 
            this.chkIgnoreProgramFiles.AutoSize = true;
            this.chkIgnoreProgramFiles.Location = new System.Drawing.Point(13, 61);
            this.chkIgnoreProgramFiles.Name = "chkIgnoreProgramFiles";
            this.chkIgnoreProgramFiles.Size = new System.Drawing.Size(180, 17);
            this.chkIgnoreProgramFiles.TabIndex = 2;
            this.chkIgnoreProgramFiles.Text = "Ignore program files (Program.cs)";
            this.chkIgnoreProgramFiles.UseVisualStyleBackColor = true;
            this.chkIgnoreProgramFiles.CheckedChanged += new System.EventHandler(this.chkIgnoreProgramFiles_CheckedChanged);
            // 
            // ProjectConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 119);
            this.Controls.Add(this.chkIgnoreProgramFiles);
            this.Controls.Add(this.chkIgnoreAssembly);
            this.Controls.Add(this.chkIgnoreDesigner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectConfigurationWindow";
            this.Text = "Calidus Project Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIgnoreDesigner;
        private System.Windows.Forms.CheckBox chkIgnoreAssembly;
        private System.Windows.Forms.CheckBox chkIgnoreProgramFiles;
    }
}