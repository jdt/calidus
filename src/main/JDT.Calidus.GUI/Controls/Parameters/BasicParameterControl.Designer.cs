namespace JDT.Calidus.GUI.Controls.Parameters
{
    partial class BasicParameterControl
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
            this.txtParameterValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtParameterValue
            // 
            this.txtParameterValue.Location = new System.Drawing.Point(3, 3);
            this.txtParameterValue.Name = "txtParameterValue";
            this.txtParameterValue.Size = new System.Drawing.Size(230, 20);
            this.txtParameterValue.TabIndex = 0;
            this.txtParameterValue.TextChanged += new System.EventHandler(this.txtParameterValue_TextChanged);
            // 
            // BasicParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtParameterValue);
            this.Name = "BasicParameterControl";
            this.Size = new System.Drawing.Size(238, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtParameterValue;
    }
}
