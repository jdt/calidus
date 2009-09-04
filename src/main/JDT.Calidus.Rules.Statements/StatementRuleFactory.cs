using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Rules.Statements
{
    /// <summary>
    /// This class is the main calidus statement rule factory
    /// </summary>
    public class StatementRuleFactory : IStatementRuleFactory
    {
        /// <summary>
        /// Gets the list of statement rules
        /// </summary>
        /// <returns>The rules</returns>
        public IList<StatementRuleBase> GetStatementRules()
        {
            List<StatementRuleBase> result = new List<StatementRuleBase>();

            return result;
        }
    }
}
