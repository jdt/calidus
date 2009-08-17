using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Tokens.Common
{
    /// <summary>
    /// This class represents a generic, non-specific token
    /// </summary>
    public class GenericToken : TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        /// <param name="content">The content</param>
        /// <param name="hint">An additional 'hint'</param>
        public GenericToken(int line, int column, int position, String content, object hint)
            : base(line, column, position, content)
        {
            Hint = hint;
        }

        /// <summary>
        /// Get the 'hint' which allows a generic token to hint at what kind of token it actually contains
        /// </summary>
        public object Hint { get; private set; }
    }
}
