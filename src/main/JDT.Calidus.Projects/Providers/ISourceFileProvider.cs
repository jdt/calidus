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

namespace JDT.Calidus.Projects.Providers
{
    /// <summary>
    /// This interface is implemented by providers of source files
    /// </summary>
    public interface ISourceFileProvider
    {
        /// <summary>
        /// Gets the list of source files
        /// </summary>
        /// <returns>The files</returns>
        IEnumerable<String> GetFiles();
        /// <summary>
        /// Gets the location of the source files
        /// </summary>
        /// <returns>The location</returns>
        String GetLocation();
    }
}
