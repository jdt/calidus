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
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Common.Rules.Lines;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Util;
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
            RuleFactory<IRule> factory = new RuleFactory<IRule>(GetType().Assembly.GetTypes(), null, null);

            Assert.Throws<CalidusException>(delegate
                                                {
                                                    factory.GetStatementRules(new List<IRuleConfiguration>());
                                                },
                                            "Found rule UnCreatableRule, but an instance could not be created because the rule configuration does not match the constructor and no default no-args constructor was found"
                                            );
        }

        [Test]
        public void FactoryShouldUseArgumentArrayFromOverriddenRulesIfAvailableForStatement()
        {
            MockRepository mocker = new MockRepository();

            StatementRuleBase rule = mocker.DynamicMock<StatementRuleBase>("test");
            IRuleConfiguration ruleConfig = mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory ruleConfigurationFactory = mocker.DynamicMock<IRuleConfigurationFactory>();
            IInstanceCreator instanceCreator = mocker.DynamicMock<IInstanceCreator>();

            IList<IRuleConfiguration> overrides = new[] { ruleConfig };

            Expect.Call(ruleConfig.Rule).Return(rule.GetType()).Repeat.Once();
            Expect.Call(ruleConfig.ArgumentArray).Return(new[] { "test" }).Repeat.Once();
            Expect.Call(instanceCreator.CreateInstanceOf<StatementRuleBase>(rule.GetType(), null)).IgnoreArguments().Return(rule).Repeat.Once();

            mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(new[] { rule.GetType() }, instanceCreator, ruleConfigurationFactory);
            factory.GetStatementRules(overrides);

            mocker.VerifyAll();
        }

        [Test]
        public void FactoryShouldUseArgumentArrayFromOverriddenRulesIfAvailableForBlock()
        {
            MockRepository mocker = new MockRepository();

            BlockRuleBase rule = mocker.DynamicMock<BlockRuleBase>("test");
            IRuleConfiguration ruleConfig = mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory ruleConfigurationFactory = mocker.DynamicMock<IRuleConfigurationFactory>();
            IInstanceCreator instanceCreator = mocker.DynamicMock<IInstanceCreator>();

            IList<IRuleConfiguration> overrides = new[] { ruleConfig };

            Expect.Call(ruleConfig.Rule).Return(rule.GetType()).Repeat.Once();
            Expect.Call(ruleConfig.ArgumentArray).Return(new[] { "test" }).Repeat.Once();
            Expect.Call(instanceCreator.CreateInstanceOf<BlockRuleBase>(rule.GetType(), null)).IgnoreArguments().Return(rule).Repeat.Once();

            mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(new[] { rule.GetType() }, instanceCreator, ruleConfigurationFactory);
            factory.GetBlockRules(overrides);

            mocker.VerifyAll();
        }

        [Test]
        public void FactoryShouldUseArgumentArrayFromOverriddenRulesIfAvailableForLine()
        {
            MockRepository mocker = new MockRepository();

            LineRuleBase rule = mocker.DynamicMock<LineRuleBase>("test");
            IRuleConfiguration ruleConfig = mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory ruleConfigurationFactory = mocker.DynamicMock<IRuleConfigurationFactory>();
            IInstanceCreator instanceCreator = mocker.DynamicMock<IInstanceCreator>();

            IList<IRuleConfiguration> overrides = new[] { ruleConfig };

            Expect.Call(ruleConfig.Rule).Return(rule.GetType()).Repeat.Once();
            Expect.Call(ruleConfig.ArgumentArray).Return(new[] { "test" }).Repeat.Once();
            Expect.Call(instanceCreator.CreateInstanceOf<LineRuleBase>(rule.GetType(), null)).IgnoreArguments().Return(rule).Repeat.Once();

            mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(new[] { rule.GetType() }, instanceCreator, ruleConfigurationFactory);
            factory.GetLineRules(overrides);

            mocker.VerifyAll();
        }
    }
}