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
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Common.Lines
{
    /// <summary>
    /// This interface is implemented by line factories that attempt to
    /// create a line from a list of tokens
    /// </summary>
    public interface ILineFactory
    {
        /// <summary>
        /// Resolves the token list as a line and returns the line
        /// </summary>
        /// <param name="input">The tokens to parse</param>
        /// <returns>The line</returns>
        LineBase Create(IEnumerable<TokenBase> input);
    }
}
