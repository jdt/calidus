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

namespace JDT.Calidus.Common.Tokens
{
    /// <summary>
    /// This interface is implemented by token parsers
    /// </summary>
    public interface ITokenParser
    {
        /// <summary>
        /// Parses the source into a list of tokens and returns true if it succeeded, otherwise false
        /// </summary>
        /// <param name="source">The source to parse</param>
        /// <param name="source">The tokenlist to put tokens in</param>
        /// <returns>True if succeeded, otherwise false</returns>
        IEnumerable<TokenBase> Parse(String source);
        /// <summary>
        /// Gets if the parser supports whitespace parsing
        /// </summary>
        bool SupportsWhiteSpaceParsing { get; }
        /// <summary>
        /// Gets if the parser supports generics parsing
        /// </summary>
        bool SupportsGenericsParsing { get; }
    }
}