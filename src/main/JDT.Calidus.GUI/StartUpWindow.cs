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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.GUI.Controls;
using JDT.Calidus.Projects;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.GUI
{
    public partial class StartUpWindow : Form
    {
        public StartUpWindow()
        {
            InitializeComponent();
            IsNewProject = false;
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            FileBrowseResult res = Dialogs.ShowSaveCalidusProjectFileDialog(this);
            if (res.IsOk)
            {
                SelectedProjectFile = res.SelectedFile;
                IsNewProject = true;

                File.Delete(res.SelectedFile);
                CalidusProjectManager projectManager = new CalidusProjectManager();
                projectManager.Write(new CalidusProject(res.SelectedFile));

                DisplayMainWindow(res.SelectedFile, true);
            }
        }

        private void cmdExisting_Click(object sender, EventArgs e)
        {
            FileBrowseResult res = Dialogs.ShowOpenCalidusProjectFileDialog(this);
            if (res.IsOk)
            {
                SelectedProjectFile = res.SelectedFile;
                DisplayMainWindow(res.SelectedFile, false);
            }
        }

        private void DisplayMainWindow(String file, bool isNew)
        {
            SelectedProjectFile = file;
            IsNewProject = isNew;
            DialogResult = DialogResult.OK;
            Close();
        }

        public String SelectedProjectFile { get; private set; }
        public bool IsNewProject { get; private set; }
    }
}
