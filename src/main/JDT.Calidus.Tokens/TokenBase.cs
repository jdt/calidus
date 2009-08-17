using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Tokens
{
    /// <summary>
    /// This class is the base class for all tokens
    /// </summary>
    public abstract class TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        /// <param name="content">The content</param>
        protected TokenBase(int line, int column, int position, String content)
        {
            Line = line;
            Column = column;
            Position = position;
            Content = content;
        }

        /// <summary>
        /// Get the line the token starts on
        /// </summary>
        public int Line { get; private set; }
        /// <summary>
        /// Get the column the token starts on 
        /// </summary>
        public int Column { get; private set; }
        /// <summary>
        /// Get the position in the overall parsed text the token starts on
        /// </summary>
        public int Position { get; private set; }
        /// <summary>
        /// Get the content of the token
        /// </summary>
        public String Content { get; private set; }
    }
}
