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

namespace JDT.Calidus.Common.Projects
{
    /// <summary>
    /// This interface is implemented by Calidus projects
    /// </summary>
    public interface ICalidusProject
    {
        /// <summary>
        /// Get the project file
        /// </summary>
        String GetProjectFile();
        /// <summary>
        /// Get or Set if assembly files should be ignored
        /// </summary>
        bool IgnoreAssemblyFiles { get; set; }
        /// <summary>
        /// Get or Set if the designer files should be ignored
        /// </summary>
        bool IgnoreDesignerFiles { get; set; }
        /// <summary>
        /// Get or Set if the Program.cs file should be ignored
        /// </summary>
        bool IgnoreProgramFiles { get; set; }
        /// <summary>
        /// Get the ignored source files
        /// </summary>
        IEnumerable<String> IgnoredFiles { get; }
        /// <summary>
        /// Gets the list of source files in the project that should be validated
        /// </summary>
        /// <returns>The files to validate</returns>
        IEnumerable<String> GetSourceFilesToValidate();
        /// <summary>
        /// Gets a list of all source files
        /// </summary>
        /// <returns>All files</returns>
        IEnumerable<String> GetAllSourceFiles();
        /// <summary>
        /// Ignores the specified file
        /// </summary>
        /// <param name="file">The file to ignore</param>
        void IgnoredFile(String file);
    }
}