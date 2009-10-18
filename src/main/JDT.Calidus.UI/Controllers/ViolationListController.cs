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
using JDT.Calidus.Common;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Util;
using JDT.Calidus.UI.Commands;
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// This class acts as a controller for a violation list view
    /// </summary>
    public class ViolationListController
    {
        private IViolationListView _view;
        private ICalidusProjectModel _project;
        private IRuleViolationList _violationList;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="project">The project</param>
        /// <param name="violationList">The violation list to display</param>
        public ViolationListController(IViolationListView view, ICalidusProjectModel project, IRuleViolationList violationList)
        {
            _view = view;
            _project = project;
            _violationList = violationList;

            _view.RuleViolationDetails += new EventHandler<RuleViolationEventArgs>(_view_RuleViolationDetails);
            _view.IgnoreViolation += new EventHandler<JDT.Calidus.UI.Commands.RuleViolationIgnoreCommandEventArgs>(_view_IgnoreViolation);

            _violationList.ViolationAdded += new EventHandler<RuleViolationEventArgs>(_violationList_ViolationAdded);
            _violationList.ViolationRemoved += new EventHandler<RuleViolationEventArgs>(_violationList_ViolationRemoved);
        }

        private void _violationList_ViolationAdded(object sender, RuleViolationEventArgs e)
        {
            _view.AddViolation(e.Violation);
        }

        private void _violationList_ViolationRemoved(object sender, RuleViolationEventArgs e)
        {
            _view.RemoveViolation(e.Violation);
        }

        private void _view_IgnoreViolation(object sender, RuleViolationIgnoreCommandEventArgs e)
        {
            switch(e.IgnoreType)
            {
                case RuleViolationIgnoreType.File:
                    _project.IgnoredFile(e.Violation.File);
                    foreach(RuleViolation aViolation in new List<RuleViolation>(_violationList))
                    {
                        if (aViolation.File.Equals(e.Violation.File))
                        {
                            _violationList.Remove(aViolation);
                        }
                    }

                    break;
                default:
                    throw new CalidusException("Unrecognized ignore type " + e.IgnoreType);
            }
        }

        private void _view_RuleViolationDetails(object sender, RuleViolationEventArgs e)
        {
            IDEFileOpener.OpenWithVisualStudio(e.Violation.File, e.Violation.FirstToken.Line);
        }
    }
}
