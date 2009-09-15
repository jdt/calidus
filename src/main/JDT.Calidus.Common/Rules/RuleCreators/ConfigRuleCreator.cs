using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;

namespace JDT.Calidus.Common.Rules.RuleCreators
{
    /// <summary>
    /// This class is a utility class that uses a standardized rule configuration to create rules
    /// </summary>
    public class ConfigRuleCreator<TRuleType> : IRuleCreator<TRuleType> where TRuleType : IRule
    {
        private IRuleConfigurationFactory _configFactory;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="configFactory">The config factory to use</param>
        public ConfigRuleCreator(IRuleConfigurationFactory configFactory)
        {
            _configFactory = configFactory;
        }

        /// <summary>
        /// Creates an instance of the rule, checking for parameters in the configuration
        /// </summary>
        /// <param name="type">The rule type</param>
        /// <returns>The rule</returns>
        public TRuleType CreateRule(Type type)
        {
            IRuleConfiguration configFor = _configFactory.Get(type);

            foreach(ConstructorInfo ctor in type.GetConstructors())
            {
                if (configFor.Matches(ctor))
                    return (TRuleType)Activator.CreateInstance(type, configFor.ArgumentArray);
            }

            throw new CalidusException("Rule " + type.Name + " does not have a default constructor and no configuration information could be found that matches a constructor");
        }
    }
}