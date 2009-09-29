using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Lines;

namespace JDT.Calidus.Rules.Lines
{
    /// <summary>
    /// This class provides the Calidus line rules
    /// </summary>
    public class LineRuleFactory : ILineRuleFactory
    {
        private RuleFactory<LineRuleBase> _factory;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public LineRuleFactory()
        {
            _factory = new RuleFactory<LineRuleBase>(GetType().Assembly);
        }

        /// <summary>
        /// Gets the list of line rules
        /// </summary>
        /// <returns>The rules</returns>
        public IEnumerable<LineRuleBase> GetLineRules()
        {
            return _factory.GetLineRules();
        }

        /// <summary>
        /// Gets the configuration factory that provides configuration information for the line rules in this factory
        /// </summary>
        /// <returns></returns>
        public IRuleConfigurationFactory GetConfigurationFactory()
        {
            return _factory.GetConfigurationFactory();
        }
    }
}
