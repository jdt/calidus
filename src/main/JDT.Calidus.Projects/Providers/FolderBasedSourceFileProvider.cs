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

namespace JDT.Calidus.Projects.Providers
{
    /// <summary>
    /// This class is a folder-based source file provider
    /// </summary>
    public class FolderBasedSourceFileProvider : ISourceFileProvider
    {
        private String _location;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="location">The source file base location</param>
        public FolderBasedSourceFileProvider(String location)
        {
            _location = location;
        }

        /// <summary>
        /// Gets the list of source files
        /// </summary>
        /// <returns>The files</returns>
        public IEnumerable<String> GetFiles()
        {
            return Directory.GetFiles(_location, "*.cs", SearchOption.AllDirectories);
        }
        
        /// <summary>
        /// Gets the location of the source files
        /// </summary>
        /// <returns>The location</returns>
        public String GetLocation()
        {
            return _location;
        }
    }
}
