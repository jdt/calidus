using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tokens.Common;

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

        /// <summary>
        /// Gets the token that contains the member name in the statement
        /// </summary>
        public IdentifierToken MemberNameToken
        {
            get
            {
                for(int i = Tokens.Count() - 1; i >= 0; i--)
                {
                    if(Tokens.ElementAt(i) is IdentifierToken)
                        return (IdentifierToken)Tokens.ElementAt(i);
                }

                throw new CalidusException("Could not find a valid member name token");
            }
        }
    }
}
