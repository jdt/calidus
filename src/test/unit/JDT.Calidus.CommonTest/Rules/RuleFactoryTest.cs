using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Rules;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.CommonTest.Rules
{
    public class UnCreatableRule : IRule
    {
        public UnCreatableRule(String arg){}

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string Category
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class CreatableRule : IRule
    {
        public CreatableRule() { }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string Category
        {
            get { throw new NotImplementedException(); }
        }
    }
    [TestFixture]
    public class RuleFactoryTest
    {
        [Test]
        public void FactoryShouldThrowExceptionForUnCreateableRules()
        {
            MockRepository mocker = new MockRepository();
            IRuleCreator<IRule> creator = mocker.StrictMock<IRuleCreator<IRule>>();
            Expect.Call(creator.CreateRule(GetType())).IgnoreArguments().Return(null).Repeat.Once();
            mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(GetType().Assembly, creator);

            Assert.Throws<CalidusException>(delegate
                                                {
                                                    factory.GetRules();
                                                },
                                            "Found rule UnCreateableRule, but an instance could not be created because the ObjectFactoryRuleCreator did not register the rule and no default no-args constructor was found");

            mocker.VerifyAll();
        }

        [Test]
        public void FactoryShouldTryDefaultConstructorBeforeCustomCreator()
        {
            MockRepository mocker = new MockRepository();
            IRuleCreator<IRule> creator = mocker.StrictMock<IRuleCreator<IRule>>();
            Expect.Call(creator.CreateRule(typeof(UnCreatableRule))).Return(new UnCreatableRule("test")).Repeat.Once();
            mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(GetType().Assembly, creator);
            factory.GetRules();

            mocker.VerifyAll();
        }
    }
}