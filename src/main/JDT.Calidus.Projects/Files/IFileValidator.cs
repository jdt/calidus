using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Projects.Files
{
    /// <summary>
    /// This interface is implemented by classes that validate files to be checked
    /// by Calidus
    /// </summary>
    public interface IFileValidator
    {
        /// <summary>
        /// Checks if the file is valid
        /// </summary>
        /// <param name="file">The file to check</param>
        /// <returns>True if valid, otherwise false</returns>
        bool IsValidFile(String file);
    }
}
