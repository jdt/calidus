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
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Rules;
using JDT.Calidus.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.RulesTest
{
    [TestFixture]
    public class CalidusRuleProviderTest : CalidusTestBase
    {
        private IStatementRuleFactoryProvider _ruleFactoryProvider;
        private IBlockRuleFactoryProvider _blockRuleFactoryProvider;
        private ILineRuleFactoryProvider _lineRuleFactoryProvider;
        private CalidusRuleProvider _provider;
            
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _ruleFactoryProvider = Mocker.StrictMock<IStatementRuleFactoryProvider>();
            _blockRuleFactoryProvider = Mocker.StrictMock<IBlockRuleFactoryProvider>();
            _lineRuleFactoryProvider = Mocker.StrictMock<ILineRuleFactoryProvider>();
            _provider = new CalidusRuleProvider(_ruleFactoryProvider, _blockRuleFactoryProvider, _lineRuleFactoryProvider);
        }

        [Test]
        public void GetRulesShouldCallStatementBlockAndLineRuleFactoryProvider()
        {
            IStatementRuleFactoryProvider ruleFactoryProvider = Mocker.StrictMock<IStatementRuleFactoryProvider>();
            IBlockRuleFactoryProvider blockRuleFactoryProvider = Mocker.StrictMock<IBlockRuleFactoryProvider>();
            ILineRuleFactoryProvider lineRuleFactoryProvider = Mocker.StrictMock<ILineRuleFactoryProvider>();
            ICalidusRuleConfigurationFactory configFactory = Mocker.DynamicMock<ICalidusRuleConfigurationFactory>();

            Expect.Call(ruleFactoryProvider.GetStatementRuleFactories()).Return(new List<IStatementRuleFactory>()).Repeat.Once();
            Expect.Call(blockRuleFactoryProvider.GetBlockRuleFactories()).Return(new List<IBlockRuleFactory>()).Repeat.Once();
            Expect.Call(lineRuleFactoryProvider.GetLineRuleFactories()).Return(new List<ILineRuleFactory>()).Repeat.Once();
            
            Mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider, lineRuleFactoryProvider);
            provider.GetRules(configFactory);

            Mocker.VerifyAll();
        }

        [Test]
        public void GetStatementRulesShouldCallStatementRuleFactoryProvider()
        {
            IStatementRuleFactoryProvider ruleFactoryProvider = Mocker.StrictMock<IStatementRuleFactoryProvider>();
            IBlockRuleFactoryProvider blockRuleFactoryProvider = Mocker.StrictMock<IBlockRuleFactoryProvider>();
            ILineRuleFactoryProvider lineRuleFactoryProvider = Mocker.StrictMock<ILineRuleFactoryProvider>();
            ICalidusRuleConfigurationFactory configFactory = Mocker.DynamicMock<ICalidusRuleConfigurationFactory>();

            Expect.Call(ruleFactoryProvider.GetStatementRuleFactories()).Return(new List<IStatementRuleFactory>()).Repeat.Once();
            
            Mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider, lineRuleFactoryProvider);
            provider.GetStatementRules(configFactory);

            Mocker.VerifyAll();
        }

        [Test]
        public void GetBlockRulesShouldCallBlockRuleFactoryProvider()
        {
            IStatementRuleFactoryProvider ruleFactoryProvider = Mocker.StrictMock<IStatementRuleFactoryProvider>();
            IBlockRuleFactoryProvider blockRuleFactoryProvider = Mocker.StrictMock<IBlockRuleFactoryProvider>();
            ILineRuleFactoryProvider lineRuleFactoryProvider = Mocker.StrictMock<ILineRuleFactoryProvider>();
            ICalidusRuleConfigurationFactory configFactory = Mocker.DynamicMock<ICalidusRuleConfigurationFactory>();

            Expect.Call(blockRuleFactoryProvider.GetBlockRuleFactories()).Return(new List<IBlockRuleFactory>()).Repeat.Once();
            
            Mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider, lineRuleFactoryProvider);
            provider.GetBlockRules(configFactory);

            Mocker.VerifyAll();
        }

        [Test]
        public void GetLineRulesShouldCallLineRuleFactoryProvider()
        {
            IStatementRuleFactoryProvider ruleFactoryProvider = Mocker.StrictMock<IStatementRuleFactoryProvider>();
            IBlockRuleFactoryProvider blockRuleFactoryProvider = Mocker.StrictMock<IBlockRuleFactoryProvider>();
            ILineRuleFactoryProvider lineRuleFactoryProvider = Mocker.StrictMock<ILineRuleFactoryProvider>();
            ICalidusRuleConfigurationFactory configFactory = Mocker.DynamicMock<ICalidusRuleConfigurationFactory>();

            Expect.Call(lineRuleFactoryProvider.GetLineRuleFactories()).Return(new List<ILineRuleFactory>()).Repeat.Once();

            Mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider, lineRuleFactoryProvider);
            provider.GetLineRules(configFactory);

            Mocker.VerifyAll();
        }
    }
}
