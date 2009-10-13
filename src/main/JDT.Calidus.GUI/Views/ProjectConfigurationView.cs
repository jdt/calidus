#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.GUI.Views
{
    /// <summary>
    /// This class is a forms-based project configuration view
    /// </summary>
    public partial class ProjectConfigurationView : UserControl, IProjectConfigurationView
    {
        public ProjectConfigurationView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Notifies that the assembly file ignore option was changed
        /// </summary>
        public event EventHandler<CheckedEventArgs> IgnoreAssemblyFilesChanged;
        /// <summary>
        /// Notifies that the ignore program files option was changed
        /// </summary>
        public event EventHandler<CheckedEventArgs> IgnoreProgramFilesChanged;
        /// <summary>
        /// Notifies that the ignore designer files option was changed
        /// </summary>
        public event EventHandler<CheckedEventArgs> IgnoreDesignerFilesChanged;

        /// <summary>
        /// Get or Set if assembly files are ignored
        /// </summary>
        public bool IgnoreAssemblyFiles
        {
            get
            {
                return chkIgnoreAssembly.Checked;
            }
            set
            {
                chkIgnoreAssembly.Checked = value;
                OnIgnoreAssemblyFilesChanged();
            }
        }

        /// <summary>
        /// Get or Set if program files are ignored
        /// </summary>
        public bool IgnoreProgramFiles
        {
            get
            {
                return chkIgnoreProgramFiles.Checked;
            }
            set
            {
                chkIgnoreProgramFiles.Checked = value;
                OnIgnoreProgramFilesChanged();
            }
        }

        /// <summary>
        /// Get or Set if designer files are ignored
        /// </summary>
        public bool IgnoreDesignerFiles
        {
            get
            {
                return chkIgnoreDesigner.Checked;
            }
            set
            {
                chkIgnoreDesigner.Checked = value;
                OnIgnoreDesignerFilesChanged();
            }
        }

        #region Events

            private void chkIgnoreDesigner_CheckedChanged(object sender, EventArgs e)
            {
                IgnoreDesignerFiles = chkIgnoreDesigner.Checked;
            }

            private void chkIgnoreAssembly_CheckedChanged(object sender, EventArgs e)
            {
                IgnoreAssemblyFiles = chkIgnoreAssembly.Checked;
            }

            private void chkIgnoreProgramFiles_CheckedChanged(object sender, EventArgs e)
            {
                IgnoreProgramFiles = chkIgnoreProgramFiles.Checked;
            }

            private void OnIgnoreAssemblyFilesChanged()
            {
                if (IgnoreAssemblyFilesChanged != null)
                    IgnoreAssemblyFilesChanged(this, new CheckedEventArgs(IgnoreAssemblyFiles));
            }

            private void OnIgnoreProgramFilesChanged()
            {
                if (IgnoreProgramFilesChanged != null)
                    IgnoreProgramFilesChanged(this, new CheckedEventArgs(IgnoreProgramFiles));
            }

            private void OnIgnoreDesignerFilesChanged()
            {
                if (IgnoreDesignerFilesChanged != null)
                    IgnoreDesignerFilesChanged(this, new CheckedEventArgs(IgnoreDesignerFiles));
            }

        #endregion
    }
}
