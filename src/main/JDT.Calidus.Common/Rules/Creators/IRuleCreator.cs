using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Statements;

namespace JDT.Calidus.Common.Rules.Creators
{
    /// <summary>
    /// This interface is implemented by custom rule creators
    /// </summary>
    public interface IRuleCreator
    {
        /// <summary>
        /// Creates an instance of the rule specified or null if unable to create a rule
        /// </summary>
        /// <param name="aRule">The rule type</param>
        /// <returns>The rule</returns>
        StatementRuleBase CreateStatementRule(Type aRule);
    }
}