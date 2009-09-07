using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Tokens.Constants
{
    /// <summary>
    /// This class represents an integer constant
    /// </summary>
    public class IntegerConstantToken : TokenBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="line">The line</param>
        /// <param name="column">The column</param>
        /// <param name="position">The position</param>
        /// <param name="value">The value</param>
        public IntegerConstantToken(int line, int column, int position, int value)
            : base(line, column, position, value.ToString())
        {
        }
    }
}