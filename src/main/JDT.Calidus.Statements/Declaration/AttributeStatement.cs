using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Statements.Declaration
{
    /// <summary>
    /// This class represents an attribute declaration statement
    /// </summary>
    public class AttributeStatement : StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        public AttributeStatement(IEnumerable<TokenBase> tokens)
            : base(tokens)
        {
        }
    }
}
