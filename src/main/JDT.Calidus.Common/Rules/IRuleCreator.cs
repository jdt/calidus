using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This interface is implemented by custom rule creators
    /// </summary>
    public interface IRuleCreator<TRuleType> where TRuleType : IRule
    {
        /// <summary>
        /// Creates an instance of the rule specified or null if unable to create a rule
        /// </summary>
        /// <param name="aType">The type to create an instance of</param>
        /// <returns>The rule</returns>
        TRuleType CreateRule(Type aType);
    }
}
