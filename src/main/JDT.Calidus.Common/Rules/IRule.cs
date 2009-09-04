using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This class is implemented by all rules
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Gets the rule name
        /// </summary>
        String Name { get; }
        /// <summary>
        /// Gets the rule category
        /// </summary>
        String Category { get; }
    }
}
