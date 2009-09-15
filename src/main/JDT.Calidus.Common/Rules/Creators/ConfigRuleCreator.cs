using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;

namespace JDT.Calidus.Common.Rules.Creators
{
    /// <summary>
    /// This class is a utility class that uses a standardized rule configuration to create rules
    /// </summary>
    public class ConfigRuleCreator : IRuleCreator
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
        /// <typeparam name="TRuleType">The rule type</typeparam>
        /// <returns>The rule</returns>
        public TRuleType CreateRule<TRuleType>() where TRuleType : IRule
        {
            IRuleConfiguration configFor = _configFactory.Get(typeof(TRuleType));

            foreach(ConstructorInfo ctor in typeof(TRuleType).GetConstructors())
            {
                if (configFor.Matches(ctor))
                    return (TRuleType)Activator.CreateInstance(typeof(TRuleType), configFor.ArgumentArray);
            }

            throw new CalidusException("Rule " + typeof(TRuleType).Name + " does not have a default constructor and no configuration information could be found that matches a constructor");
        }
    }
}