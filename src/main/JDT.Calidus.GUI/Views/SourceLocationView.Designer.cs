namespace JDT.Calidus.GUI.Views
{
    partial class SourceLocationView
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
            this.lnkSourceDirectory = new System.Windows.Forms.LinkLabel();
            this.lblSourceDir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lnkSourceDirectory
            // 
            this.lnkSourceDirectory.AutoSize = true;
            this.lnkSourceDirectory.Location = new System.Drawing.Point(71, 0);
            this.lnkSourceDirectory.Name = "lnkSourceDirectory";
            this.lnkSourceDirectory.Size = new System.Drawing.Size(55, 13);
            this.lnkSourceDirectory.TabIndex = 5;
            this.lnkSourceDirectory.TabStop = true;
            this.lnkSourceDirectory.Text = "<Not Set>";
            this.lnkSourceDirectory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSourceDirectory_LinkClicked);
            // 
            // lblSourceDir
            // 
            this.lblSourceDir.AutoSize = true;
            this.lblSourceDir.Location = new System.Drawing.Point(3, 0);
            this.lblSourceDir.Name = "lblSourceDir";
            this.lblSourceDir.Size = new System.Drawing.Size(44, 13);
            this.lblSourceDir.TabIndex = 4;
            this.lblSourceDir.Text = "Source:";
            // 
            // SourceLocationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkSourceDirectory);
            this.Controls.Add(this.lblSourceDir);
            this.Name = "SourceLocationView";
            this.Size = new System.Drawing.Size(298, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkSourceDirectory;
        private System.Windows.Forms.Label lblSourceDir;
    }
}
