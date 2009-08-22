using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Parsers
{
    /// <summary>
    /// This class represents a parse exception
    /// </summary>
    public class ParseException : Exception
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="message">The exception message</param>
        public ParseException(String message)
            : base(message)
        {
        }
    }
}
