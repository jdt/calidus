using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Statements;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Parsers.Statements
{
    /// <summary>
    /// This interface is implemented by 
    /// </summary>
    public interface IStatementResolver
    {
        /// <summary>
        /// Resolves the token list as a statement and returns the statement
        /// </summary>
        /// <param name="input">The tokens to parse</param>
        /// <returns>The statement</returns>
        StatementBase Resolve(IList<TokenBase> input);
        /// <summary>
        /// Checks to see if the current resolver is able to resolve the token list
        /// </summary>
        /// <param name="tokenList">The tokens to try to resolve</param>
        /// <returns>True if able to resolve, otherwise false</returns>
        bool CanResolve(IList<TokenBase> tokenList);
    }
}
