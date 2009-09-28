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