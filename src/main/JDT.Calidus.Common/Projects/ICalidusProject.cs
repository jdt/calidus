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
        /// Get the project file name
        /// </summary>
        String Name { get; }        
        /// <summary>
        /// Get the source location
        /// </summary>
        String SourceLocation { get; }
        /// <summary>
        /// Get or Set if assembly files should be ignored
        /// </summary>
        bool IgnoreAssemblyFiles { get; }
        /// <summary>
        /// Get or Set if the designer files should be ignored
        /// </summary>
        bool IgnoreDesignerFiles { get; }
        /// <summary>
        /// Get or Set if the Program.cs file should be ignored
        /// </summary>
        bool IgnoreProgramFiles { get; }
        /// <summary>
        /// Get the ignored source files
        /// </summary>
        IList<String> IgnoredFiles { get; }
        /// <summary>
        /// Gets the list of source files in the project that should be validated
        /// </summary>
        /// <returns></returns>
        IEnumerable<String> GetSourceFilesToValidate();
        /// <summary>
        /// Gets a list of all source files
        /// </summary>
        /// <returns></returns>
        IEnumerable<String> GetAllSourceFiles();
    }
}