#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Lines;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Rules
{
    /// <summary>
    /// This class is the main rule provider for Calidus
    /// </summary>
    public class CalidusRuleProvider : ICalidusRuleProvider
    {
        private IStatementRuleFactoryProvider _statementRuleProvider;
        private IBlockRuleFactoryProvider _blockRuleProvider;
        private ILineRuleFactoryProvider _lineRuleProvider;

        private IDictionary<StatementRuleBase, IRuleConfigurationFactory> _statementRules;
        private IDictionary<BlockRuleBase, IRuleConfigurationFactory> _blockRules;
        private IDictionary<LineRuleBase, IRuleConfigurationFactory> _lineRules;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="statementRuleProvider">The statement rule provider to use</param>
        /// <param name="blockRuleProvider">The block rule provider to use</param>
        public CalidusRuleProvider(IStatementRuleFactoryProvider statementRuleProvider, 
            IBlockRuleFactoryProvider blockRuleProvider,
            ILineRuleFactoryProvider lineRuleProvider
            )
        {
            _statementRuleProvider = statementRuleProvider;
            _blockRuleProvider = blockRuleProvider;
            _lineRuleProvider = lineRuleProvider;
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public CalidusRuleProvider()
            : this(ObjectFactory.Get<IStatementRuleFactoryProvider>(), ObjectFactory.Get<IBlockRuleFactoryProvider>(), ObjectFactory.Get<ILineRuleFactoryProvider>())
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

            foreach (BlockRuleBase aRule in GetBlockRules())
                rules.Add(aRule);

            foreach (LineRuleBase aRule in GetLineRules())
                rules.Add(aRule);

            return rules;
        }

        /// <summary>
        /// Gets a  list of all statement rules
        /// </summary>
        /// <returns>The rules</returns>
        public IEnumerable<StatementRuleBase> GetStatementRules()
        {
            if (_statementRules == null)
            {
                _statementRules = new Dictionary<StatementRuleBase, IRuleConfigurationFactory>();

                foreach (IStatementRuleFactory aFactory in _statementRuleProvider.GetStatementRuleFactories())
                {
                    IRuleConfigurationFactory configFactory = aFactory.GetConfigurationFactory();
                    foreach (StatementRuleBase aStatementRule in aFactory.GetStatementRules())
                    {
                        _statementRules.Add(aStatementRule, configFactory);
                    }
                }
            }

            return _statementRules.Keys.ToList();
        }

        /// <summary>
        /// Gets a list of all block rules
        /// </summary>
        /// <returns>The rules</returns>
        public IEnumerable<BlockRuleBase> GetBlockRules()
        {
            if (_blockRules == null)
            {
                _blockRules = new Dictionary<BlockRuleBase, IRuleConfigurationFactory>();

                foreach (IBlockRuleFactory aFactory in _blockRuleProvider.GetBlockRuleFactories())
                {
                    IRuleConfigurationFactory configFactory = aFactory.GetConfigurationFactory();
                    foreach (BlockRuleBase aBlockRule in aFactory.GetBlockRules())
                    {
                        _blockRules.Add(aBlockRule, configFactory);
                    }
                }
            }

            return _blockRules.Keys.ToList();
        }

        /// <summary>
        /// Gets a list of all line rules
        /// </summary>
        /// <returns>The rules</returns>
        public IEnumerable<LineRuleBase> GetLineRules()
        {
            if (_lineRules == null)
            {
                _lineRules = new Dictionary<LineRuleBase, IRuleConfigurationFactory>();

                foreach (ILineRuleFactory aFactory in _lineRuleProvider.GetLineRuleFactories())
                {
                    IRuleConfigurationFactory configFactory = aFactory.GetConfigurationFactory();
                    foreach (LineRuleBase aLineRule in aFactory.GetLineRules())
                    {
                        _lineRules.Add(aLineRule, configFactory);
                    }
                }
            }

            return _lineRules.Keys.ToList();
        }

        /// <summary>
        /// Gets the configuration factory for the specified rule
        /// </summary>
        /// <param name="type">The rule</param>
        /// <returns>The configuration</returns>
        public IRuleConfigurationFactory GetConfigurationFactoryFor(Type type)
        {
            foreach(StatementRuleBase aRule in _statementRules.Keys)
            {
                if (aRule.GetType().Equals(type))
                    return _statementRules[aRule];
            }

            foreach (BlockRuleBase aRule in _blockRules.Keys)
            {
                if (aRule.GetType().Equals(type))
                    return _blockRules[aRule];
            }

            foreach(LineRuleBase aRule in _lineRules.Keys)
            {
                if (aRule.GetType().Equals(type))
                    return _lineRules[aRule];
            }

            throw new CalidusException("Cannot find an appropriate IRuleConfigurationFactory for the supplied rule type");
        }
    }
}
