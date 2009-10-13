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
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.GUI.Views
{
    /// <summary>
    /// This class is a forms-based source location view
    /// </summary>
    public partial class SourceLocationView : UserControl, ISourceLocationView
    {
        public SourceLocationView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises an event to notify that the source location has changed
        /// </summary>
        public event EventHandler<SourceLocationEventArgs> SourceLocationChanged;
        private void OnSouceLocationChanged(SourceLocationEventArgs e)
        {
            if (SourceLocationChanged != null)
                SourceLocationChanged(this, e);
        }

        /// <summary>
        /// Display the source location in the view
        /// </summary>
        /// <param name="location">The location</param>
        public void DisplaySourceLocation(String location)
        {
            lnkSourceDirectory.Text = location;
        }

        #region Events

            private void lnkSourceDirectory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                FolderBrowserDialog browseDirectory = new FolderBrowserDialog();
                browseDirectory.ShowNewFolderButton = false;
                browseDirectory.ShowDialog(this);

                String selectedDir = browseDirectory.SelectedPath;
                if (selectedDir.Equals(String.Empty) == false)
                {
                    OnSouceLocationChanged(new SourceLocationEventArgs(selectedDir));
                }
            }

        #endregion
    }
}
