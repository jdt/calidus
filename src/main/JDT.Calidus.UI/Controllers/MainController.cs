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
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Projects;
using JDT.Calidus.Rules;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;
using JDT.Calidus.UI.Events;
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Common.Projects.Events;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// The controller for the main project
    /// </summary>
    public class MainController
    {
        private ICalidusProjectManager _projectManager;

        private IRuleRunner _runner;
        private ICalidusProjectModel _project;
        private IRuleViolationList _violationList;

        private IMainView _view;
        private bool _hasChanges;
        
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="project">The project</param>
        /// <param name="isNewProject">Indicates if the project was newly created</param>
        /// <param name="projectManager">The project manager to use</param>
        /// <param name="runner">The rule runner to use</param>
        /// <param name="violationList">The violation list to sue</param>
        public MainController(IMainView view, 
                                ICalidusProjectModel project, 
                                bool isNewProject, 
                                ICalidusProjectManager projectManager, 
                                IRuleRunner runner, 
                                IRuleViolationList violationList)
        {
            _view = view;

            _view.Open += new EventHandler<EventArgs>(_view_Open);
            _view.Save += new EventHandler<EventArgs>(_view_Save);
            _view.Quit += new EventHandler<QuitEventArgs>(_view_Quit);

            _view.ProjectConfiguration += new EventHandler<EventArgs>(_view_ProjectConfiguration);
            _view.RuleConfiguration += new EventHandler<EventArgs>(_view_RuleConfiguration);

            _projectManager = projectManager;

            _runner = runner;
            _runner.Started += new EventHandler<EventArgs>(_runner_Started);
            _runner.Completed += new EventHandler<RuleRunnerEventArgs>(_runner_Completed);

            _violationList = violationList;

            _project = project;
            _project.Changed += new EventHandler<EventArgs>(_project_Changed);
            _project.ProjectSet += new EventHandler<EventArgs>(_project_ProjectSet);

            //set project details
            _view.SelectedProject = _project.GetProjectFile();
            HasChanges = isNewProject;
        }

        private void _view_Open(object sender, EventArgs e)
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
                HasChanges = false;
            }
        }

        private void _view_Save(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void _view_Quit(object sender, QuitEventArgs e)
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

        private void _view_RuleConfiguration(object sender, EventArgs e)
        {
            _view.ShowRuleConfiguration();
        }

        private void _view_ProjectConfiguration(object sender, EventArgs e)
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
        
        private void _project_ProjectSet(object sender, EventArgs e)
        {
            _view.SelectedProject = _project.GetProjectFile();
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
