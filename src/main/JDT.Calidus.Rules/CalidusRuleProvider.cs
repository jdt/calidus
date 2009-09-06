using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Rules
{
    /// <summary>
    /// This class is the main rule provider for Calidus
    /// </summary>
    public class CalidusRuleProvider
    {
        private IStatementRuleFactoryProvider _statementRuleProvider;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="provider">The provider to use</param>
        public CalidusRuleProvider(IStatementRuleFactoryProvider provider)
        {
            _statementRuleProvider = provider;
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public CalidusRuleProvider()
            : this(ObjectFactory.Get<IStatementRuleFactoryProvider>())
        {
        }

        /// <summary>
        /// Gets a list of all the rules
        /// </summary>
        /// <returns>The rules</returns>
        public IEnumerable<IRule> GetRules()
        {
            IList<IRule> rules = new List<IRule>();

            foreach (StatementRuleBase aRule in GetStatementRules())
                rules.Add(aRule);

            return rules;
        }

        /// <summary>
        /// Gets a  list of all statement rules
        /// </summary>
        /// <returns>The rules</returns>
        public IEnumerable<StatementRuleBase> GetStatementRules()
        {
            IList<StatementRuleBase> rules = new List<StatementRuleBase>();

            foreach (IStatementRuleFactory aFactory in _statementRuleProvider.GetStatementRuleFactories())
            {
                foreach (StatementRuleBase aStatementRule in aFactory.GetStatementRules())
                {
                    rules.Add(aStatementRule);
                }
            }

            return rules;
        }
    }
}
