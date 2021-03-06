﻿#region License
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
