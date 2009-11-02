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
    /// This interface is implemented by statement contexts
    /// </summary>
    public interface IStatementContext
    {
        /// <summary>
        /// Gets the statements that are parents of the current statement
        /// </summary>
        /// <example>
        /// When parsing for member statements, the context should provide the class and namespace statement as parent
        /// </example>
        IEnumerable<StatementParent> Parents { get; }        
        /// <summary>
        /// Gets the next non-whitespace token after the current statement
        /// </summary>
        TokenBase NextTokenFromCurrentStatement { get; }
        /// <summary>
        /// Checks if the next token from previous statement is of the specified type
        /// </summary>
        /// <typeparam name="TTokenType">The type to check</typeparam>
        /// <returns>True if of that type, false if not</returns>
        bool IsNextToken<TTokenType>() where TTokenType : TokenBase;
    }
}
