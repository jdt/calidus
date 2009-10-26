namespace JDT.Calidus.GUI
{
    partial class StartUpWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUpWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdExisting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select an existing Calidus project file or create a new file to begin";
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(12, 29);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(75, 75);
            this.cmdNew.TabIndex = 1;
            this.cmdNew.Text = "New Project";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdExisting
            // 
            this.cmdExisting.Location = new System.Drawing.Point(93, 29);
            this.cmdExisting.Name = "cmdExisting";
            this.cmdExisting.Size = new System.Drawing.Size(75, 75);
            this.cmdExisting.TabIndex = 2;
            this.cmdExisting.Text = "Existing Project";
            this.cmdExisting.UseVisualStyleBackColor = true;
            this.cmdExisting.Click += new System.EventHandler(this.cmdExisting_Click);
            // 
            // StartUpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 112);
            this.Controls.Add(this.cmdExisting);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartUpWindow";
            this.Text = "Select a project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdExisting;
    }
}