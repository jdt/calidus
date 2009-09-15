﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.RuleCreators;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.CommonTest.Rules.RuleCreators
{
    [TestFixture]
    public class ConfigRuleCreatorTest
    {
        [Test]
        public void RuleShouldUseFileConfiguration()
        {
            MockRepository mocker = new MockRepository();
            IRuleConfigurationFactory factory = mocker.StrictMock<IRuleConfigurationFactory>();
            IRuleConfiguration config = mocker.Stub<IRuleConfiguration>();
            Expect.Call(config.Matches(null)).IgnoreArguments().Return(true).Repeat.Once();
            Expect.Call(config.ArgumentArray).Return(new object[]{"test"}).Repeat.Once();

            Expect.Call(factory.Get(typeof(UnCreatableRule))).Return(config).Repeat.Once();
            mocker.ReplayAll();

            ConfigRuleCreator<UnCreatableRule> creator = new ConfigRuleCreator<UnCreatableRule>(factory);
            creator.CreateRule(typeof(UnCreatableRule));

            mocker.VerifyAll();
        }

        [Test]
        public void RuleNotRegisteredInFileShouldThrowException()
        {
            MockRepository mocker = new MockRepository();
            IRuleConfigurationFactory factory = mocker.StrictMock<IRuleConfigurationFactory>();
            IRuleConfiguration config = mocker.Stub<IRuleConfiguration>();

            Expect.Call(factory.Get(typeof(UnCreatableRule))).Return(config).Repeat.Once();
            mocker.ReplayAll();

            ConfigRuleCreator<UnCreatableRule> creator = new ConfigRuleCreator<UnCreatableRule>(factory);
            Assert.Throws<CalidusException>(delegate
                                                {
                                                    creator.CreateRule(typeof(UnCreatableRule));
                                                }
                , "Rule UnCreatableRule does not have a default constructor and no configuration information could be found that matches a constructor");

            mocker.VerifyAll();
        }
    }
}