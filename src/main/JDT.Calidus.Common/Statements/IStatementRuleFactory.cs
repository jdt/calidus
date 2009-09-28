using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Statements;

namespace JDT.Calidus.Common.Statements
{
    /// <summary>
    /// This interface is implemented by statement rule factories
    /// </summary>
    public interface IStatementRuleFactory
    {
        /// <summary>
        /// Gets the list of statement rules
        /// </summary>
        /// <returns>The rules</returns>
        IEnumerable<StatementRuleBase> GetStatementRules();
        /// <summary>
        /// Gets the configuration factory that provides configuration information for the statement rules in this factory
        /// </summary>
        /// <returns></returns>
        IRuleConfigurationFactory GetConfigurationFactory();
    }
}
