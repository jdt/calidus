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
    public class ObjectFactoryRuleCreator : IRuleCreator 
    {
        /// <summary>
        /// Gets the rule from the object factory or null if not registered
        /// </summary>
        /// <typeparam name="TRuleType">The rule type</typeparam>
        /// <returns>The rule or null if not found</returns>
        public TRuleType CreateRule<TRuleType>() where TRuleType : IRule
        {
            if (ObjectFactory.Has(typeof(TRuleType)))
                return (TRuleType)ObjectFactory.Get(typeof(TRuleType));
            else
                return default(TRuleType);
        }
    }
}