namespace JDT.Calidus.GUI.Views
{
    partial class ViolationListView
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
            this.lvViolations = new System.Windows.Forms.ListView();
            this.headerRule = new System.Windows.Forms.ColumnHeader();
            this.headerFile = new System.Windows.Forms.ColumnHeader();
            this.headerLine = new System.Windows.Forms.ColumnHeader();
            this.headerColumn = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvViolations
            // 
            this.lvViolations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerRule,
            this.headerFile,
            this.headerLine,
            this.headerColumn});
            this.lvViolations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvViolations.Location = new System.Drawing.Point(0, 0);
            this.lvViolations.MultiSelect = false;
            this.lvViolations.Name = "lvViolations";
            this.lvViolations.Size = new System.Drawing.Size(493, 150);
            this.lvViolations.TabIndex = 1;
            this.lvViolations.UseCompatibleStateImageBehavior = false;
            this.lvViolations.View = System.Windows.Forms.View.Details;
            this.lvViolations.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvViolations_MouseDoubleClick);
            // 
            // headerRule
            // 
            this.headerRule.Text = "Rule";
            this.headerRule.Width = 150;
            // 
            // headerFile
            // 
            this.headerFile.Text = "File";
            this.headerFile.Width = 253;
            // 
            // headerLine
            // 
            this.headerLine.Text = "Line";
            this.headerLine.Width = 32;
            // 
            // headerColumn
            // 
            this.headerColumn.Text = "Column";
            this.headerColumn.Width = 47;
            // 
            // ViolationListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvViolations);
            this.Name = "ViolationListView";
            this.Size = new System.Drawing.Size(493, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvViolations;
        private System.Windows.Forms.ColumnHeader headerRule;
        private System.Windows.Forms.ColumnHeader headerFile;
        private System.Windows.Forms.ColumnHeader headerLine;
        private System.Windows.Forms.ColumnHeader headerColumn;
    }
}
