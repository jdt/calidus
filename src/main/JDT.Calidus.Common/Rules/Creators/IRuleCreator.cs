using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Common.Rules.Creators
{
    /// <summary>
    /// This interface is implemented by custom rule creators
    /// </summary>
    public interface IRuleCreator
    {
        /// <summary>
        /// Creates an instance of the rule specified or null if unable to create a rule
        /// </summary>
        /// <typeparam name="TRule">The rule type</typeparam>
        /// <returns>The rule</returns>
        TRule CreateRule<TRule>() where TRule : IRule;
    }
}