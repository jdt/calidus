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
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Lines;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Rules;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.RulesTest
{
    [TestFixture]
    public class CalidusRuleProviderTest
    {
        private MockRepository _mocker;
        private IStatementRuleFactoryProvider _ruleFactoryProvider;
        private IBlockRuleFactoryProvider _blockRuleFactoryProvider;
        private ILineRuleFactoryProvider _lineRuleFactoryProvider;
        private CalidusRuleProvider _provider;
            
        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();

            _ruleFactoryProvider = _mocker.StrictMock<IStatementRuleFactoryProvider>();
            _blockRuleFactoryProvider = _mocker.StrictMock<IBlockRuleFactoryProvider>();
            _lineRuleFactoryProvider = _mocker.StrictMock<ILineRuleFactoryProvider>();
            _provider = new CalidusRuleProvider(_ruleFactoryProvider, _blockRuleFactoryProvider, _lineRuleFactoryProvider);
        }

        [Test]
        public void GetRulesShouldCallStatementAndBlockRuleFactoryProvider()
        {
            MockRepository mocker = new MockRepository();
            IStatementRuleFactoryProvider ruleFactoryProvider = mocker.StrictMock<IStatementRuleFactoryProvider>();
            Expect.Call(ruleFactoryProvider.GetStatementRuleFactories()).Return(new List<IStatementRuleFactory>()).Repeat.Once();

            IBlockRuleFactoryProvider blockRuleFactoryProvider = mocker.StrictMock<IBlockRuleFactoryProvider>();
            Expect.Call(blockRuleFactoryProvider.GetBlockRuleFactories()).Return(new List<IBlockRuleFactory>()).Repeat.Once();

            ILineRuleFactoryProvider lineRuleFactoryProvider = mocker.StrictMock<ILineRuleFactoryProvider>();
            Expect.Call(lineRuleFactoryProvider.GetLineRuleFactories()).Return(new List<ILineRuleFactory>()).Repeat.Once();


            mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider, lineRuleFactoryProvider);
            provider.GetRules(new List<IRuleConfiguration>());

            mocker.VerifyAll();
        }

        [Test]
        public void GetConfigurationForShouldReturnConfigurationFromOverrideIfExists()
        {
            IRule rule = _mocker.DynamicMock<IRule>();
            IRuleConfiguration config = _mocker.DynamicMock<IRuleConfiguration>();

            Expect.Call(config.Rule).Return(rule.GetType()).Repeat.Once();

            _mocker.ReplayAll();

            Assert.AreEqual(config, _provider.GetConfigurationFor(rule, new[] {config}));

            _mocker.VerifyAll();
        }

        [Test]
        public void GetConfigurationForShouldCheckStatementRuleConfigurationFactoryIfRuleIsStatementRule()
        {
            StatementRuleBase rule = _mocker.DynamicMock<StatementRuleBase>("test");
            IRuleConfiguration config = _mocker.DynamicMock<IRuleConfiguration>();
            IStatementRuleFactory ruleFactory = _mocker.DynamicMock<IStatementRuleFactory>();
            IRuleConfigurationFactory ruleConfigFactory = _mocker.DynamicMock<IRuleConfigurationFactory>();

            Expect.Call(_ruleFactoryProvider.GetStatementRuleFactories()).Return(new[] { ruleFactory }).Repeat.Once();
            Expect.Call(ruleFactory.GetConfigurationFactory()).Return(ruleConfigFactory).Repeat.Once();
            Expect.Call(ruleFactory.GetStatementRules(new List<IRuleConfiguration>())).Return(new[] {rule});
            Expect.Call(ruleConfigFactory.Get(rule.GetType())).Return(config).Repeat.Once();

            _mocker.ReplayAll();

            Assert.AreEqual(config, _provider.GetConfigurationFor(rule, new List<IRuleConfiguration>()));

            _mocker.VerifyAll();
        }

        [Test]
        public void GetConfigurationForShouldCheckBlockRuleConfigurationFactoryIfRuleIsBlockRule()
        {
            BlockRuleBase rule = _mocker.DynamicMock<BlockRuleBase>("test");
            IRuleConfiguration config = _mocker.DynamicMock<IRuleConfiguration>();
            IBlockRuleFactory ruleFactory = _mocker.DynamicMock<IBlockRuleFactory>();
            IRuleConfigurationFactory ruleConfigFactory = _mocker.DynamicMock<IRuleConfigurationFactory>();

            Expect.Call(_blockRuleFactoryProvider.GetBlockRuleFactories()).Return(new[] { ruleFactory }).Repeat.Once();
            Expect.Call(ruleFactory.GetConfigurationFactory()).Return(ruleConfigFactory).Repeat.Once();
            Expect.Call(ruleFactory.GetBlockRules(new List<IRuleConfiguration>())).Return(new[] { rule });
            Expect.Call(ruleConfigFactory.Get(rule.GetType())).Return(config).Repeat.Once();

            _mocker.ReplayAll();

            Assert.AreEqual(config, _provider.GetConfigurationFor(rule, new List<IRuleConfiguration>()));

            _mocker.VerifyAll();
        }

        [Test]
        public void GetConfigurationForShouldCheckLineRuleConfigurationFactoryIfRuleIsLineRule()
        {
            LineRuleBase rule = _mocker.DynamicMock<LineRuleBase>("test");
            IRuleConfiguration config = _mocker.DynamicMock<IRuleConfiguration>();
            ILineRuleFactory ruleFactory = _mocker.DynamicMock<ILineRuleFactory>();
            IRuleConfigurationFactory ruleConfigFactory = _mocker.DynamicMock<IRuleConfigurationFactory>();

            Expect.Call(_lineRuleFactoryProvider.GetLineRuleFactories()).Return(new[] { ruleFactory }).Repeat.Once();
            Expect.Call(ruleFactory.GetConfigurationFactory()).Return(ruleConfigFactory).Repeat.Once();
            Expect.Call(ruleFactory.GetLineRules(new List<IRuleConfiguration>())).Return(new[] { rule });
            Expect.Call(ruleConfigFactory.Get(rule.GetType())).Return(config).Repeat.Once();

            _mocker.ReplayAll();

            Assert.AreEqual(config, _provider.GetConfigurationFor(rule, new List<IRuleConfiguration>()));

            _mocker.VerifyAll();
        }
    }
}
