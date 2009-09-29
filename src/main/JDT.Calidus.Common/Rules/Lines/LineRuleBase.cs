using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;

namespace JDT.Calidus.Common.Rules.Lines
{
    /// <summary>
    /// This class is the base class for all line rules
    /// </summary>
    public abstract class LineRuleBase : IRule
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="category">The rule category</param>
        protected LineRuleBase(String category)
        {
            Category = category;
        }

        /// <summary>
        /// Gets the rule name
        /// </summary>
        public String Name
        {
            get
            {
                return GetType().Name;
            }
        }

        /// <summary>
        /// Gets the rule category
        /// </summary>
        public String Category { get; private set; }

        /// <summary>
        /// Checks if the rule validates the supplied line
        /// </summary>
        /// <param name="line">The line</param>
        /// <returns>True if validates, otherwise false</returns>
        public abstract bool Validates(LineBase line);
        /// <summary>
        /// Checks if the rule is valid for the line
        /// </summary>
        /// <param name="line">The line</param>
        /// <returns>True if valid, otherwise false</returns>
        public abstract bool IsValidFor(LineBase line);
    }
}
