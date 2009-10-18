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
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.Common.Projects.Events
{
    /// <summary>
    /// This class represents event arguments for a file parsing completed event
    /// </summary>
    public class FileCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="currentFileNumber">The current file number</param>
        /// <param name="totalFiles">The total file numbers</param>
        /// <param name="violations">The violations</param>
        public FileCompletedEventArgs(String fileName, int currentFileNumber, int totalFiles, IEnumerable<RuleViolation> violations)
        {
            File = fileName;
            CurrentFileNumber = currentFileNumber;
            TotalFileNumbers = totalFiles;
            Violations = violations;
        }

        /// <summary>
        /// Get the file name
        /// </summary>
        public String File { get; private set; }
        /// <summary>
        /// Get the list of violations for the file
        /// </summary>
        public IEnumerable<RuleViolation> Violations { get; private set; }
        /// <summary>
        /// Gets the number of the file that was completed
        /// </summary>
        public int CurrentFileNumber { get; private set; }
        /// <summary>
        /// Gets the total number of files
        /// </summary>
        public int TotalFileNumbers { get; private set; }
    }
}
