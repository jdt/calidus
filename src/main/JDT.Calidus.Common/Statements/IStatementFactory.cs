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
        /// <returns>The statement</returns>
        StatementBase Create(IList<TokenBase> input);
        /// <summary>
        /// Checks to see if the current factory is able to create a statement from the token list
        /// </summary>
        /// <param name="tokenList">The tokens to try to parse as a statement</param>
        /// <returns>True if able to parse, otherwise false</returns>
        bool CanCreateStatementFrom(IList<TokenBase> tokenList);
    }
}