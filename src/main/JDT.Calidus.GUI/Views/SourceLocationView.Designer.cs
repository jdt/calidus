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
            this.lblSourceDir = new System.Windows.Forms.Label();
            this.lblSourceDirectory = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // lblSourceDirectory
            // 
            this.lblSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSourceDirectory.Location = new System.Drawing.Point(54, 0);
            this.lblSourceDirectory.Name = "lblSourceDirectory";
            this.lblSourceDirectory.Size = new System.Drawing.Size(241, 20);
            this.lblSourceDirectory.TabIndex = 5;
            this.lblSourceDirectory.Text = "label1";
            // 
            // SourceLocationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSourceDirectory);
            this.Controls.Add(this.lblSourceDir);
            this.Name = "SourceLocationView";
            this.Size = new System.Drawing.Size(298, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourceDir;
        private System.Windows.Forms.Label lblSourceDirectory;
    }
}
