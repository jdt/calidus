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

namespace JDT.Calidus.UI.Views
{
    /// <summary>
    /// This interface is implemented by views of project configuration
    /// </summary>
    public interface IProjectConfigurationView
    {
        /// <summary>
        /// Get or Set if assembly files are ignored
        /// </summary>
        bool IgnoreAssemblyFiles { get; set; }
        /// <summary>
        /// Get or Set if program files are ignored
        /// </summary>
        bool IgnoreProgramFiles { get; set; }
        /// <summary>
        /// Get or Set if designer files are ignored
        /// </summary>
        bool IgnoreDesignerFiles { get; set; }
        /// <summary>
        /// Notifies that the assembly file ignore option was changed
        /// </summary>
        event EventHandler<CheckedEventArgs> IgnoreAssemblyFilesChanged;
        /// <summary>
        /// Notifies that the ignore program files option was changed
        /// </summary>
        event EventHandler<CheckedEventArgs> IgnoreProgramFilesChanged;
        /// <summary>
        /// Notifies that the ignore designer files option was changed
        /// </summary>
        event EventHandler<CheckedEventArgs> IgnoreDesignerFilesChanged;
    }
}
