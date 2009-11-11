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
using JDT.Calidus.Common.Projects;
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
        private MockRepository _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();
        }

        [Test]
        public void FactoryShouldThrowExceptionForUnCreateableRules()
        {
            RuleFactory<IRule> factory = new RuleFactory<IRule>(GetType().Assembly.GetTypes(), null, null);
            ICalidusProject project = _mocker.DynamicMock<ICalidusProject>();

            Expect.Call(project.GetProjectRuleConfigurations()).Return(new List<IRuleConfiguration>()).Repeat.Once();

            Assert.Throws<CalidusException>(delegate
                                                {
                                                    factory.GetStatementRules(project);
                                                },
                                            "Found rule UnCreatableRule, but an instance could not be created because the rule configuration does not match the constructor and no default no-args constructor was found"
                                            );
        }

        [Test]
        public void FactoryShouldUseArgumentArrayFromOverriddenRulesIfAvailableForStatement()
        {
            StatementRuleBase rule = _mocker.DynamicMock<StatementRuleBase>("test");
            IRuleConfiguration ruleConfig = _mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory ruleConfigurationFactory = _mocker.DynamicMock<IRuleConfigurationFactory>();
            IInstanceCreator instanceCreator = _mocker.DynamicMock<IInstanceCreator>();
            ICalidusProject project = _mocker.DynamicMock<ICalidusProject>();

            IList<IRuleConfiguration> overrides = new[] { ruleConfig };
            
            Expect.Call(project.GetProjectRuleConfigurations()).Return(overrides).Repeat.Once();
            Expect.Call(ruleConfig.Rule).Return(rule.GetType()).Repeat.Once();
            Expect.Call(ruleConfig.ArgumentArray).Return(new[] { "test" }).Repeat.Once();
            Expect.Call(instanceCreator.CreateInstanceOf<StatementRuleBase>(rule.GetType(), null)).IgnoreArguments().Return(rule).Repeat.Once();

            _mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(new[] { rule.GetType() }, instanceCreator, ruleConfigurationFactory);
            factory.GetStatementRules(project);

            _mocker.VerifyAll();
        }

        [Test]
        public void FactoryShouldUseArgumentArrayFromOverriddenRulesIfAvailableForBlock()
        {
            BlockRuleBase rule = _mocker.DynamicMock<BlockRuleBase>("test");
            IRuleConfiguration ruleConfig = _mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory ruleConfigurationFactory = _mocker.DynamicMock<IRuleConfigurationFactory>();
            IInstanceCreator instanceCreator = _mocker.DynamicMock<IInstanceCreator>();
            ICalidusProject project = _mocker.DynamicMock<ICalidusProject>();

            IList<IRuleConfiguration> overrides = new[] { ruleConfig };

            Expect.Call(project.GetProjectRuleConfigurations()).Return(overrides).Repeat.Once();
            Expect.Call(ruleConfig.Rule).Return(rule.GetType()).Repeat.Once();
            Expect.Call(ruleConfig.ArgumentArray).Return(new[] { "test" }).Repeat.Once();
            Expect.Call(instanceCreator.CreateInstanceOf<BlockRuleBase>(rule.GetType(), null)).IgnoreArguments().Return(rule).Repeat.Once();

            _mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(new[] { rule.GetType() }, instanceCreator, ruleConfigurationFactory);
            factory.GetBlockRules(project);

            _mocker.VerifyAll();
        }

        [Test]
        public void FactoryShouldUseArgumentArrayFromOverriddenRulesIfAvailableForLine()
        {
            LineRuleBase rule = _mocker.DynamicMock<LineRuleBase>("test");
            IRuleConfiguration ruleConfig = _mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory ruleConfigurationFactory = _mocker.DynamicMock<IRuleConfigurationFactory>();
            IInstanceCreator instanceCreator = _mocker.DynamicMock<IInstanceCreator>();
            ICalidusProject project = _mocker.DynamicMock<ICalidusProject>();

            IList<IRuleConfiguration> overrides = new[] { ruleConfig };

            Expect.Call(project.GetProjectRuleConfigurations()).Return(overrides).Repeat.Once();
            Expect.Call(ruleConfig.Rule).Return(rule.GetType()).Repeat.Once();
            Expect.Call(ruleConfig.ArgumentArray).Return(new[] { "test" }).Repeat.Once();
            Expect.Call(instanceCreator.CreateInstanceOf<LineRuleBase>(rule.GetType(), null)).IgnoreArguments().Return(rule).Repeat.Once();

            _mocker.ReplayAll();

            RuleFactory<IRule> factory = new RuleFactory<IRule>(new[] { rule.GetType() }, instanceCreator, ruleConfigurationFactory);
            factory.GetLineRules(project);

            _mocker.VerifyAll();
        }
    }
}