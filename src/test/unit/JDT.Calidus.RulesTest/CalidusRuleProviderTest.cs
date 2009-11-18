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
        public void GetRulesShouldCallStatementBlockAndLineRuleFactoryProvider()
        {
            MockRepository mocker = new MockRepository();
            
            IStatementRuleFactoryProvider ruleFactoryProvider = mocker.StrictMock<IStatementRuleFactoryProvider>();
            IBlockRuleFactoryProvider blockRuleFactoryProvider = mocker.StrictMock<IBlockRuleFactoryProvider>();
            ILineRuleFactoryProvider lineRuleFactoryProvider = mocker.StrictMock<ILineRuleFactoryProvider>();
            ICalidusRuleConfigurationFactory configFactory = mocker.DynamicMock<ICalidusRuleConfigurationFactory>();

            Expect.Call(ruleFactoryProvider.GetStatementRuleFactories()).Return(new List<IStatementRuleFactory>()).Repeat.Once();
            Expect.Call(blockRuleFactoryProvider.GetBlockRuleFactories()).Return(new List<IBlockRuleFactory>()).Repeat.Once();
            Expect.Call(lineRuleFactoryProvider.GetLineRuleFactories()).Return(new List<ILineRuleFactory>()).Repeat.Once();
            
            mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider, lineRuleFactoryProvider);
            provider.GetRules(configFactory);

            mocker.VerifyAll();
        }

        [Test]
        public void GetStatementRulesShouldCallStatementRuleFactoryProvider()
        {
            MockRepository mocker = new MockRepository();

            IStatementRuleFactoryProvider ruleFactoryProvider = mocker.StrictMock<IStatementRuleFactoryProvider>();
            IBlockRuleFactoryProvider blockRuleFactoryProvider = mocker.StrictMock<IBlockRuleFactoryProvider>();
            ILineRuleFactoryProvider lineRuleFactoryProvider = mocker.StrictMock<ILineRuleFactoryProvider>();
            ICalidusRuleConfigurationFactory configFactory = mocker.DynamicMock<ICalidusRuleConfigurationFactory>();

            Expect.Call(ruleFactoryProvider.GetStatementRuleFactories()).Return(new List<IStatementRuleFactory>()).Repeat.Once();
            
            mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider, lineRuleFactoryProvider);
            provider.GetStatementRules(configFactory);

            mocker.VerifyAll();
        }

        [Test]
        public void GetBlockRulesShouldCallBlockRuleFactoryProvider()
        {
            MockRepository mocker = new MockRepository();

            IStatementRuleFactoryProvider ruleFactoryProvider = mocker.StrictMock<IStatementRuleFactoryProvider>();
            IBlockRuleFactoryProvider blockRuleFactoryProvider = mocker.StrictMock<IBlockRuleFactoryProvider>();
            ILineRuleFactoryProvider lineRuleFactoryProvider = mocker.StrictMock<ILineRuleFactoryProvider>();
            ICalidusRuleConfigurationFactory configFactory = mocker.DynamicMock<ICalidusRuleConfigurationFactory>();

            Expect.Call(blockRuleFactoryProvider.GetBlockRuleFactories()).Return(new List<IBlockRuleFactory>()).Repeat.Once();
            
            mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider, lineRuleFactoryProvider);
            provider.GetBlockRules(configFactory);

            mocker.VerifyAll();
        }

        [Test]
        public void GetLineRulesShouldCallLineRuleFactoryProvider()
        {
            MockRepository mocker = new MockRepository();

            IStatementRuleFactoryProvider ruleFactoryProvider = mocker.StrictMock<IStatementRuleFactoryProvider>();
            IBlockRuleFactoryProvider blockRuleFactoryProvider = mocker.StrictMock<IBlockRuleFactoryProvider>();
            ILineRuleFactoryProvider lineRuleFactoryProvider = mocker.StrictMock<ILineRuleFactoryProvider>();
            ICalidusRuleConfigurationFactory configFactory = mocker.DynamicMock<ICalidusRuleConfigurationFactory>();

            Expect.Call(lineRuleFactoryProvider.GetLineRuleFactories()).Return(new List<ILineRuleFactory>()).Repeat.Once();

            mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider, lineRuleFactoryProvider);
            provider.GetLineRules(configFactory);

            mocker.VerifyAll();
        }
    }
}
