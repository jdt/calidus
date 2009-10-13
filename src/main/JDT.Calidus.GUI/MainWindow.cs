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
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Events;
using JDT.Calidus.Rules;
using JDT.Calidus.UI.Controllers;
using JDT.Calidus.UI.Model;

namespace JDT.Calidus.GUI
{
    public partial class MainWindow : Form
    {
        private RuleRunner _runner;

        private CalidusProjectModel _project;

        public MainWindow()
        {
            InitializeComponent();
            
            _runner = new RuleRunner();
            _runner.Started += new RuleRunner.RuleRunnerStartedHandler(_runner_Started);
            _runner.Completed += new RuleRunner.RuleRunnerCompletedHandler(_runner_Completed);

            _project = new CalidusProjectModel(CalidusProject.Create(Application.StartupPath));

            ViolationListController violationListController = new ViolationListController(violationListView, _runner);
            CheckableRuleTreeController checkableRuleListController = new CheckableRuleTreeController(checkableRuleTreeView, new CalidusRuleProvider());
            FileTreeController fileListController = new FileTreeController(fileListView, _project);
            SourceLocationController sourceLocationController = new SourceLocationController(sourceLocationView,_project);
            RuleRunnerController ruleRunnerController = new RuleRunnerController(ruleRunnerView, _runner, _project);
            StatusController statusController = new StatusController(statusView, _runner);
        }

        #region Runner events

            private void _runner_Started(object source, EventArgs e)
            {
                Cursor = Cursors.WaitCursor;
            }

            private void _runner_Completed(object source, RuleRunnerEventArgs e)
            {
                Cursor = Cursors.Default;
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

            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

        #endregion
    }
}