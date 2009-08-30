using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Common;

namespace JDT.Calidus.Statements.Resolvers
{
    /// <summary>
    /// Fluent implementation of an IStatementResolver
    /// </summary>
    public abstract class FluentStatementResolver<TStatementType>
        : IStatementResolver
        where TStatementType : StatementBase
    {
        /// <summary>
        /// Resolves the token list as a statement and returns the statement
        /// </summary>
        /// <param name="input">The tokens to parse</param>
        /// <returns>The statement</returns>
        public StatementBase Resolve(IList<TokenBase> input)
        {
            if (CanResolve(input))
                return BuildStatement(input);
            else
                throw new CalidusException("The resolver cannot resolve the token list to a statement");
        }

        /// <summary>
        /// Checks to see if the current resolver is able to resolve the token list
        /// </summary>
        /// <param name="tokenList">The tokens to try to resolve</param>
        /// <returns>True if able to resolve, otherwise false</returns>
        public bool CanResolve(IList<TokenBase> tokenList)
        {
            return Expression.Matches(tokenList);
        }

        /// <summary>
        /// Builds the appropriate statement for the token list
        /// </summary>
        /// <param name="input">The token list</param>
        /// <returns>The statement</returns>
        protected abstract TStatementType BuildStatement(IList<TokenBase> input);
        /// <summary>
        /// Gets the expression used to validate token lists
        /// </summary>
        protected abstract IStatementExpression Expression { get; }
    }
}
