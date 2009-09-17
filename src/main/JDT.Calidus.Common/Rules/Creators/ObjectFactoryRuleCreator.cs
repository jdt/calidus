using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Statements;

namespace JDT.Calidus.Common.Rules.Creators
{
    /// <summary>
    /// This class is a utility class that uses the object factory to create instances of rules
    /// </summary>
    public class ObjectFactoryRuleCreator : IRuleCreator 
    {
        /// <summary>
        /// Gets the rule from the object factory or null if not registered
        /// </summary>
        /// <returns>The rule or null if not found</returns>
        public StatementRuleBase CreateStatementRule(Type type)
        {
            if (ObjectFactory.Has(type))
                return (StatementRuleBase)ObjectFactory.Get(type);
            else
                return null;
        }

        /// <summary>
        /// Create an instance of the rule specified or null if unable to create a rule
        /// </summary>
        /// <param name="type">The rule type</param>
        /// <returns>The rule</returns>
        public BlockRuleBase CreateBlockRule(Type type)
        {
            if (ObjectFactory.Has(type))
                return (BlockRuleBase)ObjectFactory.Get(type);
            else
                return null;
        }
    }
}