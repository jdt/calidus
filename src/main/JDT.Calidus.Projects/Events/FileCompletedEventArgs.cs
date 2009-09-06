using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.Projects.Events
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
