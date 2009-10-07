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
using JDT.Calidus.Projects.Providers;

namespace JDT.Calidus.Projects
{
    /// <summary>
    /// This class represents a Calidus project
    /// </summary>
    public class CalidusProject
    {
        private ISourceFileProvider _provider;

        #region Static methods
        
            /// <summary>
            /// Creates a new calidus project
            /// </summary>
            /// <param name="targetDir">The directory to use</param>
            /// <returns>A Calidus project for the directory</returns>
            public static CalidusProject Create(String targetDir)
            {
                return new CalidusProject(Path.GetFullPath(targetDir).Substring(Path.GetDirectoryName(targetDir).Length + 1),
                                          new FolderBasedSourceFileProvider(Path.GetFullPath(targetDir))
                                          );
            }

        #endregion

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="name">The project name</param>
        /// <param name="provider">The source file provider</param>
        public CalidusProject(String name, ISourceFileProvider provider)
        {
            _provider = provider;

            Name = name;

            IgnoreAssemblyFiles = true;
            IgnoreDesignerFiles = true;
            IgnoreProgramFiles = true;

            IgnoredFiles = new List<String>();
        }

        /// <summary>
        /// Get the source location
        /// </summary>
        public String SourceLocation
        {
            get
            {
                return _provider.GetLocation();
            }
        }
        /// <summary>
        /// Get the project file name
        /// </summary>
        public String Name
        {
            get;
            private set;
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
        /// Get the ignored source files
        /// </summary>
        public IList<String> IgnoredFiles { get; private set; }
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
                if(!(IgnoreAssemblyFiles && (aFile.EndsWith("\\AssemblyInfo.cs") || aFile.Equals("AssemblyInfo.cs")))
                    && !(IgnoreDesignerFiles && aFile.EndsWith(".Designer.cs"))
                    && !(IgnoreProgramFiles && (aFile.EndsWith("\\Program.cs") || aFile.Equals("Program.cs")))
                    && !(IgnoredFiles.Contains(aFile) || IgnoredFiles.Count(p => aFile.EndsWith(p)) > 0)
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
            return _provider.GetFiles();
        }
    }
}
