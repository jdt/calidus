﻿#region License
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
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Events;
using JDT.Calidus.Rules;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// The controller for the main project
    /// </summary>
    public class MainController
    {
        private IMainView _view;

        private CalidusProjectManager _projectManager;

        private RuleRunner _runner;
        private CalidusProjectModel _project;
        private RuleViolationList _violationList;

        private bool _hasChanges;
        
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        public MainController(IMainView view)
        {
            _view = view;

            _view.Open += new EventHandler<EventArgs>(_view_Open);
            _view.Save += new EventHandler<EventArgs>(_view_Save);
            _view.Quit += new EventHandler<QuitEventArgs>(_view_Quit);

            _view.ProjectConfiguration += new EventHandler<EventArgs>(_view_ProjectConfiguration);
            _view.RuleConfiguration += new EventHandler<EventArgs>(_view_RuleConfiguration);

            ProjectSelectionResult res = _view.SelectProject();
            if (res != null)
            {
                _view.SelectedProject = res.ProjectFile;
                _projectManager = new CalidusProjectManager();

                _runner = new RuleRunner();
                _runner.Started += new RuleRunner.RuleRunnerStartedHandler(_runner_Started);
                _runner.Completed += new RuleRunner.RuleRunnerCompletedHandler(_runner_Completed);

                _project = new CalidusProjectModel(_projectManager.ReadFrom(res.ProjectFile));
                _project.Changed += new EventHandler<EventArgs>(_project_Changed);

                _violationList = new RuleViolationList();

                HasChanges = res.IsNewProject;

                ViolationListController violationListController = new ViolationListController(_view.ViolationListView, _project, _violationList);
                CheckableRuleTreeController checkableRuleListController = new CheckableRuleTreeController(_view.CheckableRuleTreeView, new CalidusRuleProvider());
                FileTreeController fileListController = new FileTreeController(_view.FileListView, _project);
                SourceLocationController sourceLocationController = new SourceLocationController(_view.SourceLocationView, _project);
                RuleRunnerController ruleRunnerController = new RuleRunnerController(_view.RuleRunnerView, _runner, _project);
                StatusController statusController = new StatusController(_view.StatusView, _violationList);
            
            }
            else
            {
                _view.Exit();
            }
        }

        void _view_Open(object sender, EventArgs e)
        {
            if (HasChanges)
            {
                Confirm confirm = _view.ConfirmSaveChanges();
                if (confirm == Confirm.Yes)
                    SaveProject();

                if (confirm == Confirm.Cancel)
                    return;
            }

            FileBrowseResult openResult = _view.OpenProjectFile();
            if (openResult.IsOk && !String.IsNullOrEmpty(openResult.SelectedFile))
            {
                _project.SetProject(_projectManager.ReadFrom(openResult.SelectedFile));
                _view.SelectedProject = _project.ProjectFile;
                HasChanges = false;
            }
        }

        void _view_Save(object sender, EventArgs e)
        {
            SaveProject();
        }

        void _view_Quit(object sender, QuitEventArgs e)
        {
            Confirm confirm = Confirm.No;
            if(HasChanges)
                confirm = _view.ConfirmSaveChanges();
            
            //first check: if yes confirm save
            if (confirm == Confirm.Yes)
                SaveProject();

            if (confirm != Confirm.Cancel)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        void _view_RuleConfiguration(object sender, EventArgs e)
        {
            _view.ShowRuleConfiguration();
        }

        void _view_ProjectConfiguration(object sender, EventArgs e)
        {
            _view.ShowProjectConfiguration(_project);
        }
        
        private void _runner_Started(object source, EventArgs e)
        {
            _view.BeginWait();
            _violationList.Clear();
        }

        private void _runner_Completed(object source, RuleRunnerEventArgs e)
        {
            _view.EndWait();
            foreach (RuleViolation aViolation in e.Violations)
                _violationList.Add(aViolation);
        }

        private void _project_Changed(object sender, EventArgs e)
        {
            HasChanges = true;
        }

        private bool HasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                _hasChanges = value;
                _view.ProjectHasChanges(_hasChanges);
            }
        }

        private void SaveProject()
        {
            _projectManager.Write(_project);
            _view.ProjectHasChanges(false);
            HasChanges = false;
        }
    }
}