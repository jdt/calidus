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

namespace JDT.Calidus.UI.Views
{
    /// <summary>
    /// This class contains the result of a file select
    /// </summary>
    public class FileBrowseResult
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="isOk">The result</param>
        /// <param name="file">The selected file</param>
        public FileBrowseResult(bool isOk, String file)
        {
            IsOk = isOk;
            SelectedFile = file;
        }

        /// <summary>
        /// Get the dialog result
        /// </summary>
        public bool IsOk { get; private set; }
        /// <summary>
        /// Get the selected file or null if not set
        /// </summary>
        public String SelectedFile { get; private set; }
    }
}
