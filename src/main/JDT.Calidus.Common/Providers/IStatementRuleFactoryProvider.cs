using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Statements;

namespace JDT.Calidus.Common.Providers
{
    /// <summary>
    /// This interface is implemented by factories of statement rules
    /// </summary>
    public interface IStatementRuleFactoryProvider
    {        
        /// <summary>
        /// Loads the statement rules from the factory
        /// </summary>
        /// <returns>The rules</returns>
        IEnumerable<StatementRuleBase> GetStatementRules();
    }
}
