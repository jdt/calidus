using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Common;

namespace JDT.Calidus.Statements.Factories.Fluent
{
    /// <summary>
    /// Fluent implementation of an IStatementFactory
    /// </summary>
    public abstract class FluentStatementFactory<TStatementType>
        : IStatementFactory
        where TStatementType : StatementBase
    {
        /// <summary>
        /// Resolves the token list as a statement and returns the statement
        /// </summary>
        /// <param name="input">The tokens to parse</param>
        /// <returns>The statement</returns>
        public StatementBase Create(IList<TokenBase> input)
        {
            if (CanCreateStatementFrom(input))
                return BuildStatement(input);
            else
                throw new CalidusException("The factory cannot parse the token list into a statement");
        }

        /// <summary>
        /// Checks to see if the current factory is able to create a statement from the token list
        /// </summary>
        /// <param name="tokenList">The tokens to try to parse as a statement</param>
        /// <returns>True if able to parse, otherwise false</returns>
        public bool CanCreateStatementFrom(IList<TokenBase> tokenList)
        {
            bool res = Expression.Matches(tokenList);
            return res;
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