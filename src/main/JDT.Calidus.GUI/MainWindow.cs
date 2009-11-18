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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.GUI.Controls;
using JDT.Calidus.Projects;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.GUI
{
    /// <summary>
    /// This class is the forms-based implementation of the IMainView interface
    /// </summary>
    public partial class MainWindow : Form, IMainView
    {
        private static String _windowTitle = "Calidus GUI Runner - {0}";
        private static String _hasChanges = "*";

        private String _projectName;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Form events

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                //MainController controller = new MainController(this);
            }

            private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
            {
                QuitEventArgs quit = new QuitEventArgs();
                OnQuit(quit);
                e.Cancel = quit.Cancel;
            }

        #endregion

        #region Menu events

            private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
            {
                OnRuleConfiguration();                
            }

            private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                OnProjectConfiguration();
            }

            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                OnOpen();
            }

            private void saveToolStripMenuItem_Click(object sender, EventArgs e)
            {
                OnSave();
            }

            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Close();
            }

        #endregion

        /// <summary>
        /// Exits the application
        /// </summary>
        public void Exit()
        {
            Close();
        }

        /// <summary>
        /// Signals the beginning of a long-running operation
        /// </summary>
        public void BeginWait()
        {
            Cursor = Cursors.WaitCursor;
        }

        /// <summary>
        /// Signals the end of a long-running operation
        /// </summary>
        public void EndWait()
        {
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Marks changes to the project
        /// </summary>
        /// <param name="hasChanges">True if changed, otherwise false</param>
        public void ProjectHasChanges(bool hasChanges)
        {
            String name = "";
            if (hasChanges)
                name = String.Format(_projectName + "{0}", _hasChanges);
            else
                name = String.Format(_projectName + "{0}", String.Empty);

            Text = String.Format(_windowTitle, name);
        }

        /// <summary>
        /// Sets the current rpoject
        /// </summary>
        public String SelectedProject
        {
            set { _projectName = value; }
        }

        /// <summary>
        /// Prompts the UI to confirm saving changes
        /// </summary>
        /// <returns>The confirmation result</returns>
        public Confirm ConfirmSaveChanges()
        {
            DialogResult res = MessageBox.Show(this, "The project has unsaved changes. Do you want to save changes?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                return Confirm.Yes;
            if (res == DialogResult.No)
                return Confirm.No;

            return Confirm.Cancel;
        }

        /// <summary>
        /// Browses for a project file
        /// </summary>
        /// <returns>The result</returns>
        public FileBrowseResult OpenProjectFile()
        {
            return Dialogs.ShowOpenCalidusProjectFileDialog(this);
        }

        /// <summary>
        /// Displays the project configuration for the model
        /// </summary>
        /// <param name="model">The model to display for</param>
        public void ShowProjectConfiguration(ICalidusProjectModel model)
        {
            ProjectConfigurationWindow win = new ProjectConfigurationWindow(model);
            win.ShowDialog(this);
        }

        /// <summary>
        /// Displays the rule configuration
        /// </summary>
        /// <param name="model">The model to display for</param>
        public void ShowRuleConfiguration(ICalidusProjectModel model)
        {
            RuleConfigurationWindow win = new RuleConfigurationWindow(model, new CalidusProjectManager());
            win.ShowDialog(this);
        }

        #region Views

            /// <summary>
            /// Gets the status view
            /// </summary>
            public IStatusView StatusView
            {
                get { return statusView; }
            }

            /// <summary>
            /// Gets the rule runner view
            /// </summary>
            public IRuleRunnerView RuleRunnerView
            {
                get { return ruleRunnerView; }
            }

            /// <summary>
            /// Gets the source location view
            /// </summary>
            public ISourceLocationView SourceLocationView
            {
                get { return sourceLocationView; }
            }

            /// <summary>
            /// Gets the checkabel rule tree view
            /// </summary>
            public ICheckableRuleTreeView CheckableRuleTreeView
            {
                get { return checkableRuleTreeView; }
            }

            /// <summary>
            /// Gets the file list view
            /// </summary>
            public IFileTreeView FileListView
            {
                get { return fileListView; }
            }

            /// <summary>
            /// Gets the violation list view
            /// </summary>
            public IViolationListView ViolationListView
            {
                get { return violationListView; }
            }

        #endregion

        #region View Events

            /// <summary>
            /// Notifies that the quit was called
            /// </summary>
            public event EventHandler<QuitEventArgs> Quit;
            private void OnQuit(QuitEventArgs e)
            {
                if (Quit != null)
                    Quit(this, e);
            }

            /// <summary>
            /// Notifies that open was called
            /// </summary>
            public event EventHandler<EventArgs> Open;
            private void OnOpen()
            {
                if (Open != null)
                    Open(this, new EventArgs());
            }

            /// <summary>
            /// Notifies that save was called
            /// </summary>
            public event EventHandler<EventArgs> Save;
            private void OnSave()
            {
                if (Save != null)
                    Save(this, new EventArgs());
            }

            /// <summary>
            /// Notifies that project configuration was called
            /// </summary>
            public event EventHandler<EventArgs> ProjectConfiguration;
            private void OnProjectConfiguration()
            {
                if (ProjectConfiguration != null)
                    ProjectConfiguration(this, new EventArgs());
            }

            /// <summary>
            /// Notifies that rule configuration was called
            /// </summary>
            public event EventHandler<EventArgs> RuleConfiguration;
            private void OnRuleConfiguration()
            {
                if (RuleConfiguration != null)
                    RuleConfiguration(this, new EventArgs());
            }

        #endregion
    }
}