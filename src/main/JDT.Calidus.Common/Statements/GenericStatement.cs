using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Common.Statements
{
    /// <summary>
    /// This class represents a generic , non-specific statement
    /// </summary>
    public class GenericStatement : StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The tokens in this statement</param>
        public GenericStatement(IEnumerable<TokenBase> tokens)
            : base(tokens)
        {
        }
    }
}