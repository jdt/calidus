using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Tokens.Modifiers
{
    /// <summary>
    /// This class represents an access modifier token
    /// </summary>
    public abstract class AccessModifierToken : TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        /// <param name="content">The content</param>
        public AccessModifierToken(int line, int col, int pos, String content)
            : base(line, col, pos, content)
        {
        }
    }
}
