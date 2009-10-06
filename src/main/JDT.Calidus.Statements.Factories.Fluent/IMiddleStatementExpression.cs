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
    /// This interface is implemented by middle parts of statement expressions
    /// </summary>
    public interface IMiddleStatementExpression : IStatementExpression
    {
        /// <summary>
        /// Verify that the previously token is at any point follwed by a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression followed loosely by the specified token</returns>
        IMiddleStatementExpression FollowedLooselyBy<TTokenType>() where TTokenType : TokenBase;
        /// <summary>
        /// Verify that the previously token is exactly follwed by a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression exactly followed by the specified token</returns>
        IMiddleStatementExpression FollowedByStrict<TTokenType>() where TTokenType : TokenBase;
        /// <summary>
        /// Verify that the previously token is follwed by any whitespace and a token of the supplied type
        /// </summary>
        /// <typeparam name="TTokenType">The type</typeparam>
        /// <returns>An expression followed by whitespace if applicable and the specified token</returns>
        IMiddleStatementExpression FollowedBy<TTokenType>() where TTokenType : TokenBase;
    }
}