using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDT.Calidus.GUI
{
    public partial class ProjectConfigurationWindow : Form
    {
        public ProjectConfigurationWindow()
        {
            InitializeComponent();

            chkIgnoreAssembly.Checked = Current.Project.IgnoreAssemblyFiles;
            chkIgnoreDesigner.Checked = Current.Project.IgnoreDesignerFiles;
            chkIgnoreProgramFiles.Checked = Current.Project.IgnoreProgramFiles;
        }

        private void chkIgnoreDesigner_CheckedChanged(object sender, EventArgs e)
        {
            Current.Project.IgnoreDesignerFiles = chkIgnoreDesigner.Checked;
        }

        private void chkIgnoreAssembly_CheckedChanged(object sender, EventArgs e)
        {
            Current.Project.IgnoreAssemblyFiles = chkIgnoreAssembly.Checked;
        }

        private void chkIgnoreProgramFiles_CheckedChanged(object sender, EventArgs e)
        {
            Current.Project.IgnoreProgramFiles = chkIgnoreProgramFiles.Checked;
        }
    }
}
