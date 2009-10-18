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
using JDT.Calidus.Common.Projects;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UI.Model
{
    /// <summary>
    /// This interface is implemented by a calidus project model
    /// </summary>
    public interface ICalidusProjectModel : ICalidusProject
    {
        /// <summary>
        /// Notifies that the designer files ignore property changed
        /// </summary>
        event EventHandler<CheckedEventArgs> IgnoreDesignerFilesChanged;
        /// <summary>
        /// Notifies that the assembly files ignore property changed
        /// </summary>
        event EventHandler<CheckedEventArgs> IgnoreAssemblyFilesChanged;
        /// <summary>
        /// Notifies that the program files ignore property changed
        /// </summary>
        event EventHandler<CheckedEventArgs> IgnoreProgramFilesChanged;
        /// <summary>
        /// Notifies that something in the project changed
        /// </summary>
        event EventHandler<EventArgs> Changed;
        /// <summary>
        /// Notifies that the project was set
        /// </summary>
        event EventHandler<EventArgs> ProjectSet;
        /// <summary>
        /// Sets the project in the model
        /// </summary>
        /// <param name="project">The project</param>
        void SetProject(ICalidusProject project);
    }
}
