namespace JDT.Calidus.GUI.Views
{
    partial class ProjectConfigurationView
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
            this.chkIgnoreProgramFiles = new System.Windows.Forms.CheckBox();
            this.chkIgnoreAssembly = new System.Windows.Forms.CheckBox();
            this.chkIgnoreDesigner = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkIgnoreProgramFiles
            // 
            this.chkIgnoreProgramFiles.AutoSize = true;
            this.chkIgnoreProgramFiles.Location = new System.Drawing.Point(3, 51);
            this.chkIgnoreProgramFiles.Name = "chkIgnoreProgramFiles";
            this.chkIgnoreProgramFiles.Size = new System.Drawing.Size(180, 17);
            this.chkIgnoreProgramFiles.TabIndex = 5;
            this.chkIgnoreProgramFiles.Text = "Ignore program files (Program.cs)";
            this.chkIgnoreProgramFiles.UseVisualStyleBackColor = true;
            this.chkIgnoreProgramFiles.CheckedChanged += new System.EventHandler(this.chkIgnoreProgramFiles_CheckedChanged);
            // 
            // chkIgnoreAssembly
            // 
            this.chkIgnoreAssembly.AutoSize = true;
            this.chkIgnoreAssembly.Location = new System.Drawing.Point(3, 27);
            this.chkIgnoreAssembly.Name = "chkIgnoreAssembly";
            this.chkIgnoreAssembly.Size = new System.Drawing.Size(272, 17);
            this.chkIgnoreAssembly.TabIndex = 4;
            this.chkIgnoreAssembly.Text = "Ignore assembly configuration files (AssemblyInfo.cs)";
            this.chkIgnoreAssembly.UseVisualStyleBackColor = true;
            this.chkIgnoreAssembly.CheckedChanged += new System.EventHandler(this.chkIgnoreAssembly_CheckedChanged);
            // 
            // chkIgnoreDesigner
            // 
            this.chkIgnoreDesigner.AutoSize = true;
            this.chkIgnoreDesigner.Location = new System.Drawing.Point(3, 3);
            this.chkIgnoreDesigner.Name = "chkIgnoreDesigner";
            this.chkIgnoreDesigner.Size = new System.Drawing.Size(192, 17);
            this.chkIgnoreDesigner.TabIndex = 3;
            this.chkIgnoreDesigner.Text = "Ignore designer files (*.Designer.cs)";
            this.chkIgnoreDesigner.UseVisualStyleBackColor = true;
            this.chkIgnoreDesigner.CheckedChanged += new System.EventHandler(this.chkIgnoreDesigner_CheckedChanged);
            // 
            // ProjectConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkIgnoreProgramFiles);
            this.Controls.Add(this.chkIgnoreAssembly);
            this.Controls.Add(this.chkIgnoreDesigner);
            this.Name = "ProjectConfigurationView";
            this.Size = new System.Drawing.Size(278, 71);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIgnoreProgramFiles;
        private System.Windows.Forms.CheckBox chkIgnoreAssembly;
        private System.Windows.Forms.CheckBox chkIgnoreDesigner;
    }
}
