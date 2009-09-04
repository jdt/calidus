using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void GetRulesShouldCallStatementRuleFactoryProvider()
        {
            MockRepository mocker = new MockRepository();
            IStatementRuleFactoryProvider ruleFactoryProvider = mocker.StrictMock<IStatementRuleFactoryProvider>();
            Expect.Call(ruleFactoryProvider.GetStatementRuleFactories()).Return(new List<IStatementRuleFactory>()).Repeat.Once();

            mocker.ReplayAll();

            CalidusRuleProvider provider = new CalidusRuleProvider(ruleFactoryProvider);
            provider.GetRules();

            mocker.VerifyAll();
        }
    }
}
