using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Common.Statements
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

        /// <summary>
        /// Gets the source code in the statement
        /// </summary>
        public String Source
        {
            get
            {
                StringBuilder res = new StringBuilder();
                foreach (TokenBase aToken in Tokens)
                    res.Append(aToken.Content);
                return res.ToString();
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            StatementBase theStatement = (StatementBase)obj;
            if (theStatement.Tokens.SequenceEqual(Tokens) == false) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 33;
            hash ^= Tokens.GetHashCode();
            return hash;
        }
    }
}