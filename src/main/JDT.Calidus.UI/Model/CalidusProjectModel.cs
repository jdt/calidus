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
using System.IO;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Projects;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UI.Model
{
    /// <summary>
    /// This class is a UI-optimized model used to display calidus projects
    /// </summary>
    public class CalidusProjectModel : ICalidusProjectModel
    {
        private ICalidusProject _project;

        public CalidusProjectModel(ICalidusProject project)
        {
            _project = project;
        }

        public String FileName
        {
            get
            {
                return Path.GetFileName(_project.GetProjectFile());
            }
        }

        #region ICalidusProject members
        
            /// <summary>
            /// Get the project file
            /// </summary>
            public String GetProjectFile()
            {
                return _project.GetProjectFile();
            }
            
            /// <summary>
            /// Get or Set if assembly files should be ignored
            /// </summary>
            public bool IgnoreAssemblyFiles
            {
                get
                {
                    return _project.IgnoreAssemblyFiles;
                }
                set
                {
                    _project.IgnoreAssemblyFiles = value;
                    OnIgnoreAssemblyFilesChanged(new CheckedEventArgs(IgnoreAssemblyFiles));
                }
            }

            /// <summary>
            /// Get or Set if the designer files should be ignored
            /// </summary>
            public bool IgnoreDesignerFiles
            {
                get
                {
                    return _project.IgnoreDesignerFiles;
                }
                set
                {
                    _project.IgnoreDesignerFiles = value;
                    OnIgnoreDesignerFilesChanged(new CheckedEventArgs(IgnoreDesignerFiles));
                }
            }

            /// <summary>
            /// Get or Set if the Program.cs file should be ignored
            /// </summary>
            public bool IgnoreProgramFiles
            {
                get
                {
                    return _project.IgnoreProgramFiles;
                }
                set
                {
                    _project.IgnoreProgramFiles = value;
                    OnIgnoreProgramFilesChanged(new CheckedEventArgs(IgnoreProgramFiles));
                }
            }

            /// <summary>
            /// Get the ignored source files
            /// </summary>
            public IEnumerable<String> IgnoredFiles
            {
                get
                {
                    return _project.IgnoredFiles;
                }
            }

            /// <summary>
            /// Gets the list of source files in the project that should be validated
            /// </summary>
            /// <returns>The files to validate</returns>
            public IEnumerable<String> GetSourceFilesToValidate()
            {
                return _project.GetSourceFilesToValidate();
            }

            /// <summary>
            /// Gets a list of all source files
            /// </summary>
            /// <returns>All files</returns>
            public IEnumerable<String> GetAllSourceFiles()
            {
                return _project.GetAllSourceFiles();
            }
        
            /// <summary>
            /// Ignores the specified file
            /// </summary>
            /// <param name="file">The file to ignore</param>
            public void IgnoredFile(String file)
            {
                _project.IgnoredFile(file);
                OnChanged();
            }

        #endregion

        #region Notification events

            /// <summary>
            /// Notifies that the designer files ignore property changed
            /// </summary>
            public event EventHandler<CheckedEventArgs> IgnoreDesignerFilesChanged;
            /// <summary>
            /// Notifies that the assembly files ignore property changed
            /// </summary>
            public event EventHandler<CheckedEventArgs> IgnoreAssemblyFilesChanged;
            /// <summary>
            /// Notifies that the program files ignore property changed
            /// </summary>
            public event EventHandler<CheckedEventArgs> IgnoreProgramFilesChanged;
            /// <summary>
            /// Notifies that something in the project changed
            /// </summary>
            public event EventHandler<EventArgs> Changed;
            /// <summary>
            /// Notifies that the project was set
            /// </summary>
            public event EventHandler<EventArgs> ProjectSet;

            private void OnIgnoreDesignerFilesChanged(CheckedEventArgs e)
            {
                if (IgnoreDesignerFilesChanged != null)
                    IgnoreDesignerFilesChanged(this, e);
                OnChanged();
            }

            private void OnIgnoreAssemblyFilesChanged(CheckedEventArgs e)
            {
                if (IgnoreAssemblyFilesChanged != null)
                    IgnoreAssemblyFilesChanged(this, e);
                OnChanged();
            }

            private void OnIgnoreProgramFilesChanged(CheckedEventArgs e)
            {
                if (IgnoreProgramFilesChanged != null)
                    IgnoreProgramFilesChanged(this, e);
                OnChanged();
            }

            private void OnChanged()
            {
                if (Changed != null)
                    Changed(this, new EventArgs());
            }

            private void OnProjectSet()
            {
                if (ProjectSet != null)
                    ProjectSet(this, new EventArgs());
            }

        #endregion

        /// <summary>
        /// Sets the project in the model
        /// </summary>
        /// <param name="project">The project</param>
        public void SetProject(ICalidusProject project)
        {
            ICalidusProject originalProject = _project;
            _project = project;

            OnProjectSet();

            if (originalProject.IgnoreAssemblyFiles != project.IgnoreAssemblyFiles)
                OnIgnoreAssemblyFilesChanged(new CheckedEventArgs(project.IgnoreAssemblyFiles));
            if (originalProject.IgnoreDesignerFiles != project.IgnoreDesignerFiles)
                OnIgnoreDesignerFilesChanged(new CheckedEventArgs(project.IgnoreDesignerFiles));
            if (originalProject.IgnoreProgramFiles != project.IgnoreProgramFiles)
                OnIgnoreProgramFilesChanged(new CheckedEventArgs(project.IgnoreProgramFiles));
        }
    }
}
