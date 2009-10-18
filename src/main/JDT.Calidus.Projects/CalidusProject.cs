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
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Projects.Providers;

namespace JDT.Calidus.Projects
{
    /// <summary>
    /// This class represents a Calidus project
    /// </summary>
    public class CalidusProject : ICalidusProject
    {
        private ISourceFileProvider _provider;
        private IList<String> _ignoredFiles;

        private String _file;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="projectFile">The project file</param>
        /// <param name="provider">The source file provider</param>
        public CalidusProject(String projectFile, ISourceFileProvider provider)
        {
            _provider = provider;

            _file = projectFile;

            IgnoreAssemblyFiles = true;
            IgnoreDesignerFiles = true;
            IgnoreProgramFiles = true;

            _ignoredFiles = new List<String>();
        }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="projectFile">The project file</param>
        public CalidusProject(String projectFile)
            : this(projectFile, new FolderBasedSourceFileProvider(Path.GetDirectoryName(projectFile)))
        {
        }


        /// <summary>
        /// Get the project file
        /// </summary>
        public String GetProjectFile()
        {
            return _file;
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
        public IEnumerable<String> IgnoredFiles 
        {
            get
            {
                return _ignoredFiles;
            }
        }
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
        
        /// <summary>
        /// Ignores the specified file
        /// </summary>
        /// <param name="file">The file to ignore</param>
        public void IgnoredFile(String file)
        {
            String projectPath = Path.GetFullPath(GetProjectFile());
            String filePath = Path.GetFullPath(file);
            
            //split the file according to the path separator \
            String[] projectPathParts = projectPath.Split(Path.DirectorySeparatorChar);
            String[] filePathParts = filePath.Split(Path.DirectorySeparatorChar);

            //check each part
            int i = 0;
            while( i < projectPathParts.Count() && i < filePathParts.Count() && projectPathParts[i].Equals(filePathParts[i]))
            {
                i++;
            }

            StringBuilder relative = new StringBuilder();
            for (int j = i; j < filePathParts.Count(); j++)
            {
                relative.Append(Path.DirectorySeparatorChar + filePathParts[j]);    
            }

            _ignoredFiles.Add(relative.ToString());
        }

        /// <summary>
        /// Gets the list of ignored files
        /// </summary>
        public IList<String> IgnoredFileList
        {
            get { return _ignoredFiles; }
        }
    }
}
