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
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// This class represents a controller for a file tree
    /// </summary>
    public class FileTreeController
    {
        private IFileTreeView _view;
        private CalidusProjectModel _project;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="project">The project to use</param>
        public FileTreeController(IFileTreeView view, CalidusProjectModel project)
        {
            _view = view;

            _project = project;

            _view.DisplaySourceFiles(_project.GetAllSourceFiles());
        }
    }
}
