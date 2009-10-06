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
            IgnoreAssemblyFiles = true;
            IgnoreDesignerFiles = true;
            IgnoreProgramFiles = true;
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
        /// Get or Set if assembly files should be ignored
        /// </summary>
        public bool IgnoreAssemblyFiles { get; set; }
        /// <summary>
        /// Get or Set if the designer files should be ignored
        /// </summary>
        public bool IgnoreDesignerFiles { get; set; }
        /// <summary>
        /// Get or Set if the Program.cs file should be ignored
        /// </summary>
        public bool IgnoreProgramFiles { get; set; }

        /// <summary>
        /// Gets the list of source files in the project that should be validated
        /// </summary>
        /// <returns></returns>
        public IEnumerable<String> GetSourceFilesToValidate()
        {
            IList<String> res = new List<String>();

            IList<String> files = new List<String>(GetAllSourceFiles());
            foreach(String aFile in files)
            {
                if(!(IgnoreAssemblyFiles && aFile.EndsWith("\\AssemblyInfo.cs"))
                    && !(IgnoreDesignerFiles && aFile.EndsWith(".Designer.cs"))
                    && !(IgnoreProgramFiles && aFile.EndsWith("\\Program.cs"))
                    )
                {
                    res.Add(aFile);
                }
            }

            return res;
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
