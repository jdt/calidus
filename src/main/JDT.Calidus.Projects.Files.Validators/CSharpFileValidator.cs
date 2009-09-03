using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Projects.Files.Validators
{
    /// <summary>
    /// Default implementation of the IFileValidator class that checks for
    /// file existance and extension
    /// </summary>
    public class CSharpFileValidator : IFileValidator
    {
        /// <summary>
        /// Checks if the file is valid
        /// </summary>
        /// <param name="file">The file to check</param>
        /// <returns>True if valid, otherwise false</returns>
        public bool IsValidFile(String file)
        {
            return File.Exists(file) && file.EndsWith(".cs", StringComparison.OrdinalIgnoreCase);
        }
    }
}
