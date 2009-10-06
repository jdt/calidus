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
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Rules;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.RulesTest
{
    [TestFixture]
    public class CalidusRuleProviderTest
    {
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
            provider.GetRules();

            mocker.VerifyAll();
        }
    }
}
