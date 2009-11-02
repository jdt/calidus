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
    /// This interface is implemented by classes that provide statement context
    /// </summary>
    public interface IStatementContextManager
    {
        /// <summary>
        /// Notifies the manager that a list of tokens was parsed into a number of statements
        /// </summary>
        /// <param name="statements">The list of statements</param>
        /// <param name="lastIndex">The last index of a token in the whole list that was parsed into a statement</param>
        /// <param name="tokens">The whole token list</param>
        void Encountered(IEnumerable<StatementBase> statements, int lastIndex, IEnumerable<TokenBase> tokens);
        /// <summary>
        /// Gets the current context
        /// </summary>
        /// <param name="currentStatementTokens">The current statement tokens the context is used for</param>
        /// <returns>The context</returns>
        IStatementContext GetContext(IEnumerable<TokenBase> currentStatementTokens);
    }
}
