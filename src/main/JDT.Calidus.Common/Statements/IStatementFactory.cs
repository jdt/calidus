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

namespace JDT.Calidus.Common.Statements
{
    /// <summary>
    /// This interface is implemented by statement factories that attempt to
    /// create a statement from a list of tokens
    /// </summary>
    public interface IStatementFactory
    {
        /// <summary>
        /// Resolves the token list as a statement and returns the statement
        /// </summary>
        /// <param name="input">The tokens to parse</param>
        /// <param name="context">The context for the stamement</param>
        /// <returns>The statement</returns>
        StatementBase Create(IEnumerable<TokenBase> input, IStatementContext context);
        /// <summary>
        /// Checks to see if the current factory is able to create a statement from the token list
        /// </summary>
        /// <param name="tokenList">The tokens to try to parse as a statement</param>
        /// <param name="context">The statement context</param>
        /// <returns>True if able to parse, otherwise false</returns>
        bool CanCreateStatementFrom(IEnumerable<TokenBase> tokenList, IStatementContext context);
    }
}