using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.RuleCreators;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Rules.Statements
{
    /// <summary>
    /// This class provides the builtin Calidus statement rules
    /// </summary>
    public class StatementRuleFactory : IStatementRuleFactory
    {
        private RuleFactory<StatementRuleBase> _factory;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public StatementRuleFactory()
        {
            _factory = new RuleFactory<StatementRuleBase>(GetType().Assembly, new ObjectFactoryRuleCreator<StatementRuleBase>());
        }

        /// <summary>
        /// Gets the list of statement rules
        /// </summary>
        /// <returns>The rules</returns>
        public IList<StatementRuleBase> GetStatementRules()
        {
            return _factory.GetRules();
        }
    }
}
