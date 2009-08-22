using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Common
{
    /// <summary>
    /// This exception is the main exception class for Calidus
    /// </summary>
    public class CalidusException : Exception
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="message">The message of the error</param>
        public CalidusException(String message)
            : base(message)
        {
        }
    }
}
