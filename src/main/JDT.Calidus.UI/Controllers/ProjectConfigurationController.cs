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
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// This class acts as a controller for a project configuration view
    /// </summary>
    public class ProjectConfigurationController
    {
        private IProjectConfigurationView _view;
        private CalidusProjectModel _model;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="model">The model to use</param>
        public ProjectConfigurationController(IProjectConfigurationView view, CalidusProjectModel model)
        {
            _model = model;
            _view = view;

            _view.IgnoreAssemblyFiles = _model.IgnoreAssemblyFiles;
            _view.IgnoreDesignerFiles = _model.IgnoreDesignerFiles;
            _view.IgnoreProgramFiles = _model.IgnoreProgramFiles;

            _view.IgnoreAssemblyFilesChanged += new EventHandler<CheckedEventArgs>(_view_IgnoreAssemblyFilesChanged);
            _view.IgnoreDesignerFilesChanged += new EventHandler<CheckedEventArgs>(_view_IgnoreDesignerFilesChanged);
            _view.IgnoreProgramFilesChanged += new EventHandler<CheckedEventArgs>(_view_IgnoreProgramFilesChanged);
        }

        private void _view_IgnoreProgramFilesChanged(object sender, CheckedEventArgs e)
        {
            _model.IgnoreProgramFiles = e.IsChecked;
        }

        private void _view_IgnoreDesignerFilesChanged(object sender, CheckedEventArgs e)
        {
            _model.IgnoreDesignerFiles = e.IsChecked;
        }

        private void _view_IgnoreAssemblyFilesChanged(object sender, CheckedEventArgs e)
        {
            _model.IgnoreAssemblyFiles = e.IsChecked;
        }
    }
}
