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
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Events;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// This class acts as a controller for a rule runner view
    /// </summary>
    public class RuleRunnerController
    {
        private IRuleRunnerView _view;
        private RuleRunner _runner;
        private CalidusProjectModel _project;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="runner">The runner to use</param>
        /// <param name="project">The projectmodel to use</param>
        public RuleRunnerController(IRuleRunnerView view, RuleRunner runner, CalidusProjectModel project)
        {
            _view = view;
            _view.RuleRunnerStart += new EventHandler<EventArgs>(_view_RuleRunnerStart);

            _runner = runner;
            _runner.FileCompleted += new RuleRunner.RuleRunnerFileCompleted(_runner_FileCompleted);

            _project = project;
        }

        private void _runner_FileCompleted(object source, FileCompletedEventArgs e)
        {
            int i = (int)Math.Truncate((double)e.CurrentFileNumber / (double)e.TotalFileNumbers * 100.0);
            _view.DisplayProgressPercentage(i); 
        }

        private void _view_RuleRunnerStart(object sender, EventArgs e)
        {
            _runner.Run(_project);
        }
    }
}
