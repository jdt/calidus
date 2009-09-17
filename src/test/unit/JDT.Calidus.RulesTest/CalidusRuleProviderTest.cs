using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Blocks;
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


            mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider, blockRuleFactoryProvider);
            provider.GetRules();

            mocker.VerifyAll();
        }
    }
}
