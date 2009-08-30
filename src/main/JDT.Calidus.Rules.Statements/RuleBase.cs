using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Statements;

namespace JDT.Calidus.Rules.Statements
{
    /// <summary>
    /// This class is the base class for all statement rules
    /// </summary>
    public abstract class RuleBase
    {
        /// <summary>
        /// Checks if the rule validates the supplied statement
        /// </summary>
        /// <param name="statement">The statement</param>
        /// <returns>True if validates, otherwise false</returns>
        public abstract bool Validates(StatementBase statement);
        /// <summary>
        /// Checks if the rule is valid for the statement
        /// </summary>
        /// <param name="statement">The statement</param>
        /// <returns>True if valid, otherwise false</returns>
        public abstract bool IsValidFor(StatementBase statement);
    }
}