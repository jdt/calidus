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
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// This class represents a controller for a status view
    /// </summary>
    public class StatusController
    {
        private IStatusView _view;
        private RuleViolationList _list;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="list">The violation list</param>
        public StatusController(IStatusView view, RuleViolationList list)
        {
            _view = view;

            _list = list;
            _list.ViolationAdded += new EventHandler<RuleViolationEventArgs>(_list_ViolationAdded);
            _list.ViolationRemoved += new EventHandler<RuleViolationEventArgs>(_list_ViolationRemoved);
            
            _view.DisplayViolationCount(_list.Count);
        }

        private void _list_ViolationRemoved(object sender, RuleViolationEventArgs e)
        {
            _view.DisplayViolationCount(_list.Count);
        }

        private void _list_ViolationAdded(object sender, RuleViolationEventArgs e)
        {
            _view.DisplayViolationCount(_list.Count);
        }
    }
}
