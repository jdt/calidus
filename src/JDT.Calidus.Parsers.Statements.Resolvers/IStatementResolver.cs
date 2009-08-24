using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Statements;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Parsers.Statements.Resolvers
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
        /// <returns>The statement or null if not found</returns>
        StatementBase Resolve(IList<TokenBase> input);
    }
}
