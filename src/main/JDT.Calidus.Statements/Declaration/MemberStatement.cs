using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Statements.Declaration
{
    /// <summary>
    /// This class represents a member statement
    /// </summary>
    public class MemberStatement : StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        public MemberStatement(IEnumerable<TokenBase> tokens)
            : base(tokens)
        {
        }
    }
}
