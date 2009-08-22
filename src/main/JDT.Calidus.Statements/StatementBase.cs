using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Statements
{
    /// <summary>
    /// This class is the base class for classes representing a statement
    /// </summary>
    /// <remarks>
    /// A statement is the smallest standalone element, which is eiter a semicolon-terminated
    /// list of tokens or a compound statement such as an if, for or while
    /// </remarks>
    public abstract class StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        protected StatementBase(IEnumerable<TokenBase> tokens)
        {
            Tokens = tokens;
        }

        /// <summary>
        /// Get the tokens contained in the statement
        /// </summary>
        public IEnumerable<TokenBase> Tokens { get; private set; }
    }
}
