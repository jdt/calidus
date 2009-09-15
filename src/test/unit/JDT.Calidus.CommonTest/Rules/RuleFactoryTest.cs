using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Creators;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.CommonTest.Rules
{
    [TestFixture]
    public class RuleFactoryTest
    {
        [Test]
        public void FactoryShouldThrowExceptionForUnCreateableRules()
        {
            MockRepository mocker = new MockRepository();
            IRuleCreator creator = mocker.StrictMock<IRuleCreator>();
            Expect.Call(creator.CreateStatementRule(typeof(UnCreatableRule))).IgnoreArguments().Return(null).Repeat.Once();
            mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(GetType().Assembly, creator);

            Assert.Throws<CalidusException>(delegate
                                                {
                                                    factory.GetStatementRules();
                                                },
                                            "Found rule UnCreateableRule, but an instance could not be created because the ObjectFactoryRuleCreator did not register the rule and no default no-args constructor was found");

            mocker.VerifyAll();
        }

        [Test]
        public void FactoryShouldTryDefaultConstructorBeforeCustomCreator()
        {
            MockRepository mocker = new MockRepository();
            IRuleCreator creator = mocker.StrictMock<IRuleCreator>();
            Expect.Call(creator.CreateStatementRule(typeof(UnCreatableRule))).Return(new UnCreatableRule("test")).Repeat.Once();
            mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(GetType().Assembly, creator);
            factory.GetStatementRules();

            mocker.VerifyAll();
        }
    }
}