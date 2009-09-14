using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.Common.Rules.RuleCreators
{
    /// <summary>
    /// This class is a utility class that uses the object factory to create instances of rules
    /// </summary>
    public class ObjectFactoryRuleCreator<TRuleType> : IRuleCreator<TRuleType> where TRuleType : IRule
    {
        /// <summary>
        /// Gets the rule from the object factory or null if not registered
        /// </summary>
        /// <param name="type">The rule type</param>
        /// <returns>The rule or null if not found</returns>
        public TRuleType CreateRule(Type type)
        {
            if (ObjectFactory.Has(type))
                return (TRuleType)ObjectFactory.Get(type);
            else
                return default(TRuleType);
        }
    }
}