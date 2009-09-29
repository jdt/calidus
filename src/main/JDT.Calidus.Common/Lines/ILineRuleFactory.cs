using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Lines;

namespace JDT.Calidus.Common.Lines
{
    /// <summary>
    /// This interface is implemented by line rule factories
    /// </summary>
    public interface ILineRuleFactory
    {
        /// <summary>
        /// Gets the list of line rules
        /// </summary>
        /// <returns>The rules</returns>
        IEnumerable<LineRuleBase> GetLineRules();
        /// <summary>
        /// Gets the configuration factory that provides configuration information for the line rules in this factory
        /// </summary>
        /// <returns></returns>
        IRuleConfigurationFactory GetConfigurationFactory();
    }
}
