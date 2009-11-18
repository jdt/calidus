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

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="statementRuleProvider">The statement rule provider to use</param>
        /// <param name="blockRuleProvider">The block rule provider to use</param>
        /// <param name="lineRuleProvider">The line rule provider to use</param>
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
        /// Gets a list of all the rules with settings for the specified project
        /// </summary>
        /// <param name="configFactory">The configuration factory to use</param>
        /// <returns>The rules</returns>
        public IEnumerable<IRule> GetRules(ICalidusRuleConfigurationFactory configFactory)
        {
            IList<IRule> rules = new List<IRule>();

            foreach (StatementRuleBase aRule in GetStatementRules(configFactory))
                rules.Add(aRule);

            foreach (BlockRuleBase aRule in GetBlockRules(configFactory))
                rules.Add(aRule);

            foreach (LineRuleBase aRule in GetLineRules(configFactory))
                rules.Add(aRule);

            return rules;
        }

        /// <summary>
        /// Gets a  list of all statement rules with settings for the specified project
        /// </summary>
        /// <param name="configFactory">The configuration factory to use</param>
        /// <returns>The rules</returns>
        public IEnumerable<StatementRuleBase> GetStatementRules(ICalidusRuleConfigurationFactory configFactory)
        {
            IList<StatementRuleBase> statementRules = new List<StatementRuleBase>();

            foreach (IStatementRuleFactory aFactory in _statementRuleProvider.GetStatementRuleFactories())
            {
                foreach (StatementRuleBase aStatementRule in aFactory.GetStatementRules(configFactory))
                {
                    statementRules.Add(aStatementRule);
                }
            }

            return statementRules;
        }

        /// <summary>
        /// Gets a list of all block rules with settings for the specified project
        /// </summary>
        /// <param name="configFactory">The configuration factory to use</param>
        /// <returns>The rules</returns>
        public IEnumerable<BlockRuleBase> GetBlockRules(ICalidusRuleConfigurationFactory configFactory)
        {
            List<BlockRuleBase> blockRules = new List<BlockRuleBase>();

            foreach (IBlockRuleFactory aFactory in _blockRuleProvider.GetBlockRuleFactories())
            {
                foreach (BlockRuleBase aBlockRule in aFactory.GetBlockRules(configFactory))
                {
                    blockRules.Add(aBlockRule);
                }
            }

            return blockRules;
        }

        /// <summary>
        /// Gets a list of all line rules with settings for the specified project
        /// </summary>
        /// <param name="configFactory">The configuration factory to use</param>
        /// <returns>The rules</returns>
        public IEnumerable<LineRuleBase> GetLineRules(ICalidusRuleConfigurationFactory configFactory)
        {
            List<LineRuleBase> lineRules = new List<LineRuleBase>();

            foreach (ILineRuleFactory aFactory in _lineRuleProvider.GetLineRuleFactories())
            {
                foreach (LineRuleBase aLineRule in aFactory.GetLineRules(configFactory))
                {
                    lineRules.Add(aLineRule);
                }
            }

            return lineRules;
        }
    }
}
