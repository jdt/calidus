using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Statements.Factories.Fluent.TokenOccurences
{
    /// <summary>
    /// This class is a test for a single token 
    /// </summary>
    public class EndingTokenOccurence : TokenOccurence
    {
        /// <summary>
        /// Create a new instance of this object
        /// </summary>
        /// <param name="tokenType">The token type</param>
        public EndingTokenOccurence(Type tokenType)
            : base(tokenType, 1)
        {
        }
    }
}
