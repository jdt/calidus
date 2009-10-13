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
using System.ComponentModel;
using System.Linq;
using System.Text;
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// This class is a controller for a source location view
    /// </summary>
    public class SourceLocationController
    {
        private ISourceLocationView _view;
        private CalidusProjectModel _model;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="model">The model to use</param>
        public SourceLocationController(ISourceLocationView view, CalidusProjectModel model)
        {
            _view = view;
            _view.SourceLocationChanged += new EventHandler<SourceLocationEventArgs>(_view_SourceLocationChanged);

            _model = model;
            _model.SourceLocationChanged += new EventHandler<SourceLocationEventArgs>(_model_SourceLocationChanged);

            _view.DisplaySourceLocation(_model.SourceLocation);
        }

        private void _model_SourceLocationChanged(object sender, SourceLocationEventArgs e)
        {
            _view.DisplaySourceLocation(e.SourceLocation);
        }

        private void _view_SourceLocationChanged(object sender, SourceLocationEventArgs e)
        {
            _model.SourceLocation = e.SourceLocation;
            _view.DisplaySourceLocation(e.SourceLocation);
        }
    }
}
