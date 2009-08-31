using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Statements;

namespace JDT.Calidus.Common.Providers
{
    /// <summary>
    /// This interface is implemented by providers of statement rules
    /// </summary>
    public interface IStatementRuleProvider
    {        
        /// <summary>
        /// Loads the statement rules from the provider
        /// </summary>
        /// <returns>The rules</returns>
        IEnumerable<StatementRuleBase> GetStatementRules();
    }
}
