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

namespace JDT.Calidus.Statements.Factories.Fluent
{
    /// <summary>
    /// This interface is implemented by statement expressions
    /// </summary>
    public interface IStatementExpression
    {
        /// <summary>
        /// Checks if the list of tokens matches the expression
        /// </summary>
        /// <param name="tokenList">The list to match against</param>
        /// <returns>True if matches, otherwise false</returns>
        bool Matches(IEnumerable<TokenBase> tokenList);
        /// <summary>
        /// Verify that the token list starts with a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression starting with the specified type</returns>
        IMiddleStatementExpression StartsWith<TTokenType>() where TTokenType : TokenBase;
        /// <summary>
        /// Verify that the statement ends with a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression ending with the specified token type</returns>
        IEndingStatementExpression EndsWith<TTokenType>() where TTokenType : TokenBase;
        /// <summary>
        /// Verify that the statement contains a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression containing the specified token type</returns>
        IMiddleStatementExpression Contains<TTokenType>() where TTokenType : TokenBase;
        /// <summary>
        /// Verify that the statement is of a single token type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression of the specified token type</returns>
        IEndingStatementExpression Is<TTokenType>() where TTokenType : TokenBase;
    }
}