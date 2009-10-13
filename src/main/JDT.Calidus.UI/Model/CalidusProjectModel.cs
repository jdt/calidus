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
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Projects;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UI.Model
{
    /// <summary>
    /// This class is a UI-optimized model used to display calidus projects
    /// </summary>
    public class CalidusProjectModel : ICalidusProject
    {
        private CalidusProject _project;

        public CalidusProjectModel(CalidusProject project)
        {
            _project = project;
        }

        #region ICalidusProject members

            /// <summary>
            /// Get the project file name
            /// </summary>
            public string Name
            {
                get { throw new NotImplementedException(); }
            }

            /// <summary>
            /// Get the source location
            /// </summary>
            public string SourceLocation
            {
                get
                {
                    return _project.SourceLocation;
                }
                set 
                { 
                    _project.SourceLocation = value;
                    OnSourceLocationChanged(new SourceLocationEventArgs(value)); 
                }
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
            public IList<String> IgnoredFiles
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

        #endregion

        #region Notification events

            /// <summary>
            /// Notifies that the source location changed
            /// </summary>
            public event EventHandler<SourceLocationEventArgs> SourceLocationChanged;
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

            private void OnSourceLocationChanged(SourceLocationEventArgs e)
            {
                if (SourceLocationChanged != null)
                    SourceLocationChanged(this, e);
            }

            private void OnIgnoreDesignerFilesChanged(CheckedEventArgs e)
            {
                if (IgnoreDesignerFilesChanged != null)
                    IgnoreDesignerFilesChanged(this, e);
            }

            private void OnIgnoreAssemblyFilesChanged(CheckedEventArgs e)
            {
                if (IgnoreAssemblyFilesChanged != null)
                    IgnoreAssemblyFilesChanged(this, e);
            }

            private void OnIgnoreProgramFilesChanged(CheckedEventArgs e)
            {
                if (IgnoreProgramFilesChanged != null)
                    IgnoreProgramFilesChanged(this, e);
            }

        #endregion
    }
}
