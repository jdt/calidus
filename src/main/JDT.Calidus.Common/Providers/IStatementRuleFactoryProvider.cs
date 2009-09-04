using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Common.Providers
{
    /// <summary>
    /// This interface is implemented by providers of factories of statement rules
    /// </summary>
    public interface IStatementRuleFactoryProvider
    {        
        /// <summary>
        /// Loads the statement rule factories from the provider
        /// </summary>
        /// <returns>The factory</returns>
        IEnumerable<IStatementRuleFactory> GetStatementRules();
    }
}
