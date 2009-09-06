using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Projects
{
    /// <summary>
    /// This class represents a Calidus project
    /// </summary>
    public class CalidusProject
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="sourceLocation"></param>
        /// <param name="projectLocation"></param>
        public CalidusProject(String sourceLocation, String projectLocation)
        {
            SourceLocation = sourceLocation;
            ProjectLocation = projectLocation;
        }

        /// <summary>
        /// Get the source location
        /// </summary>
        public String SourceLocation { get; private set; }
        /// <summary>
        /// Get the project file location
        /// </summary>
        public String ProjectLocation { get; private set; }
        /// <summary>
        /// Get the project file name
        /// </summary>
        public String Name
        {
            get
            {
                return Path.GetFileName(ProjectLocation);
            }
        }

        /// <summary>
        /// Gets the list of source files in the project that should be validated
        /// </summary>
        /// <returns></returns>
        public IEnumerable<String> GetSourceFilesToValidate()
        {
            return GetAllSourceFiles();
        }

        /// <summary>
        /// Gets a list of all source files
        /// </summary>
        /// <returns></returns>
        public IEnumerable<String> GetAllSourceFiles()
        {
            return Directory.GetFiles(SourceLocation, "*.cs", SearchOption.AllDirectories);
        }
    }
}
