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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Events;
using JDT.Calidus.Rules;
using JDT.Calidus.UI.Controllers;
using JDT.Calidus.UI.Model;

namespace JDT.Calidus.GUI
{
    public partial class MainWindow : Form
    {
        private static String WINDOW_TITLE = "Calidus GUI Runner - {0}";
        private static String HAS_CHANGES = "*";

        private CalidusProjectManager _projectManager;

        private RuleRunner _runner;
        private CalidusProjectModel _project;
        private RuleViolationList _violationList;

        private bool _hasChanges;

        public MainWindow()
        {
            InitializeComponent();

            _projectManager = new CalidusProjectManager();

            _runner = new RuleRunner();
            _runner.Started += new RuleRunner.RuleRunnerStartedHandler(_runner_Started);
            _runner.Completed += new RuleRunner.RuleRunnerCompletedHandler(_runner_Completed);

            _project = new CalidusProjectModel(CalidusProject.Create(Application.StartupPath));
            _project.Changed += new EventHandler<EventArgs>(_project_Changed);

            _violationList = new RuleViolationList();

            HasChanges = true;

            ViolationListController violationListController = new ViolationListController(violationListView, _project, _violationList);
            CheckableRuleTreeController checkableRuleListController = new CheckableRuleTreeController(checkableRuleTreeView, new CalidusRuleProvider());
            FileTreeController fileListController = new FileTreeController(fileListView, _project);
            SourceLocationController sourceLocationController = new SourceLocationController(sourceLocationView,_project);
            RuleRunnerController ruleRunnerController = new RuleRunnerController(ruleRunnerView, _runner, _project);
            StatusController statusController = new StatusController(statusView, _violationList);
        }

        private void _project_Changed(object sender, EventArgs e)
        {
            HasChanges = true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasChanges)
            {
                DialogResult res = MessageBox.Show(this, "The project has unsaved changes. Save before close?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
                else if (res == DialogResult.Yes)
                    SaveProject();
            }
        }

        #region Properties

            private bool HasChanges
            {
                get
                {
                    return _hasChanges;
                }
                set
                {
                    _hasChanges = value;
                    
                    String name;
                    if(HasChanges)
                        name = String.Format(_project.Name + "{0}", HAS_CHANGES);
                    else
                        name = String.Format(_project.Name + "{0}", String.Empty);

                    Text = String.Format(WINDOW_TITLE, name);
                }
            }
            
            private String ProjectLocation { get; set; }

        #endregion

        #region Runner events

            private void _runner_Started(object source, EventArgs e)
            {
                Cursor = Cursors.WaitCursor;
                _violationList.Clear();
            }

            private void _runner_Completed(object source, RuleRunnerEventArgs e)
            {
                Cursor = Cursors.Default;
                foreach (RuleViolation aViolation in e.Violations)
                    _violationList.Add(aViolation);
            }

        #endregion

        #region Menu events

            private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
            {
                RuleConfigurationWindow config = new RuleConfigurationWindow();
                config.ShowDialog();
            }

            private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ProjectConfigurationWindow config = new ProjectConfigurationWindow(_project);
                config.ShowDialog();
            }

            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                bool canceledSaveRequest = false;

                DialogResult res = MessageBox.Show(this, "The project has unsaved changes. Save before opening another project?","Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (ProjectLocation == null && saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        ProjectLocation = saveFileDialog.FileName;
                    }

                    if (ProjectLocation != null)
                        _projectManager.WriteTo(_project, ProjectLocation);
                    else
                        canceledSaveRequest = true;
                }
                
                if (res != DialogResult.Cancel && !canceledSaveRequest)
                {
                    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        ProjectLocation = openFileDialog.FileName;
                        //re-initialize project
                        _project.SetProject(_projectManager.ReadFrom(ProjectLocation));

                        HasChanges = false;
                    }
                }
            }

            private void saveToolStripMenuItem_Click(object sender, EventArgs e)
            {
                SaveProject();               
                //re-initialize project
                _project.SetProject(_projectManager.ReadFrom(ProjectLocation));
                
                HasChanges = false;
            }

            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

        #endregion

        #region Methods

            private void SaveProject()
            {
                if (ProjectLocation == null && saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    ProjectLocation = saveFileDialog.FileName;
                }
                _projectManager.WriteTo(_project, ProjectLocation);
            }

        #endregion
    }
}