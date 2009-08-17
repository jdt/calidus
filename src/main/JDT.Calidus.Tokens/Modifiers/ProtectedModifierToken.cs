using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Tokens.Modifiers
{
    /// <summary>
    /// This class represents a protected modifier token
    /// </summary>
    public class ProtectedModifierToken : TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        /// <param name="content">The content</param>
        public ProtectedModifierToken(int line, int col, int pos, String content)
            : base(line, col, pos, content)
        {
        }
    }
}
