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
using JDT.Calidus.Projects.Events;
using JDT.Calidus.Projects.Util;
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// This class acts as a controller for a violation list view
    /// </summary>
    public class ViolationListController
    {
        private IViolationListView _view;
        private RuleRunner _runner;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="runner">The runner to use</param>
        public ViolationListController(IViolationListView view, RuleRunner runner)
        {
            _view = view;
            _runner = runner;

            _view.RuleViolationDetails += new EventHandler<RuleViolationEventArgs>(_view_RuleViolationDetails);

            _runner.Started += new RuleRunner.RuleRunnerStartedHandler(_runner_Started);
            _runner.FileCompleted += new RuleRunner.RuleRunnerFileCompleted(_runner_FileCompleted);
        }

        private void _view_RuleViolationDetails(object sender, RuleViolationEventArgs e)
        {
            IDEFileOpener.OpenWithVisualStudio(e.Violation.File, e.Violation.FirstToken.Line);
        }

        private void _runner_FileCompleted(object source, FileCompletedEventArgs e)
        {
            foreach (RuleViolation aViolation in e.Violations)
                _view.AddViolation(aViolation);
        }

        private void _runner_Started(object source, EventArgs e)
        {
            _view.ClearViolations();
        }
    }
}
