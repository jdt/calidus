using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Common.Tokens
{
    /// <summary>
    /// This interface is implemented by generics token parser, used to parse
    /// generic information into identifier tokens
    /// </summary>
    public interface IGenericsTokenParser
    {        
        /// <summary>
        /// Parses the tokenlist and returns the modified list
        /// </summary>
        /// <param name="input">The list</param>
        /// <returns>The list with generics parsed</returns>
        IEnumerable<TokenBase> Parse(IEnumerable<TokenBase> input);
    }
}