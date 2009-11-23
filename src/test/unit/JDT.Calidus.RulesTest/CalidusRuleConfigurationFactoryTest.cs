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
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.Rules;
using JDT.Calidus.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.RulesTest
{
    [TestFixture]
    public class CalidusRuleConfigurationFactoryTest : CalidusTestBase
    {
        private CalidusRuleConfigurationFactory _configFactory;
        private ICalidusProject _project;
        private ICalidusProjectManager _manager;
        private IRuleConfigurationFactoryProvider _provider;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _project = Mocker.DynamicMock<ICalidusProject>();
            _manager = Mocker.DynamicMock<ICalidusProjectManager>();
            _provider = Mocker.DynamicMock<IRuleConfigurationFactoryProvider>();
            _configFactory = new CalidusRuleConfigurationFactory(_project, _manager, _provider);
        }

        [Test]
        public void ConfigurationFactoryShouldThrowExceptionForRuleWithoutDefaultConfiguration()
        {
            IRule rule = Mocker.DynamicMock<IRule>();

            Assert.Throws<CalidusException>(() =>
                                                {
                                                    _configFactory.GetRuleConfigurationFor(rule.GetType());
                                                }, 
                                            "No default configuration could be loaded for rule " + rule.GetType().FullName
                                            );
        }

        [Test]
        public void ConfigurationFactoryShouldReturnConfigurationFromConfigurationFactoryProvider()
        {
            IRule rule = Mocker.DynamicMock<IRule>();
            IRuleConfiguration config = Mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory factory = Mocker.DynamicMock<IRuleConfigurationFactory>();

            Expect.Call(_provider.GetRuleConfigurationFactoryFor(rule.GetType())).Return(factory).Repeat.Once();
            Expect.Call(factory.Get(rule.GetType())).Return(config).Repeat.Once();
            Expect.Call(_project.GetProjectRuleConfigurationOverrides()).Return(new IRuleConfigurationOverride[] {}).Repeat.Once();

            Mocker.ReplayAll();

            Assert.AreEqual(config, _configFactory.GetRuleConfigurationFor(rule.GetType()));

            Mocker.VerifyAll();
        }

        [Test]
        public void ConfigurationFactoryShouldReturnOverriddenRulesIfAvailable()
        {
            //TODO: this test was difficult to write, is difficult to read and therefore can use some refactoring 
            String name = "parameterName";
            ParameterType type = ParameterType.MultilineString;
            String value = "parameterValue";

            IRule rule = Mocker.DynamicMock<IRule>();
            IRuleConfiguration config = Mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory factory = Mocker.DynamicMock<IRuleConfigurationFactory>();
            IRuleConfigurationOverride ruleOverride = Mocker.DynamicMock<IRuleConfigurationOverride>();

            IRuleConfigurationParameter defaultParameter = Mocker.DynamicMock<IRuleConfigurationParameter>();
            IRuleConfigurationParameter ruleOverrideParameter = Mocker.DynamicMock<IRuleConfigurationParameter>();

            IList<IRuleConfigurationOverride> overrides = new[] { ruleOverride };
            IList<IRuleConfigurationParameter> parameters = new[] { ruleOverrideParameter };
            IList<IRuleConfigurationParameter> actuals = new[] { defaultParameter };

            Expect.Call(_provider.GetRuleConfigurationFactoryFor(rule.GetType())).Return(factory).Repeat.Once();
            Expect.Call(factory.Get(rule.GetType())).Return(config).Repeat.Once();
            Expect.Call(config.Parameters).Return(actuals).Repeat.Once();
            Expect.Call(_project.GetProjectRuleConfigurationOverrides()).Return(overrides).Repeat.Once();

            Expect.Call(ruleOverride.Parameters).Return(parameters).Repeat.Once();
            
            Expect.Call(defaultParameter.Name).Return(name).Repeat.Twice();
            Expect.Call(defaultParameter.ParameterType).Return(type).Repeat.Once();

            Expect.Call(ruleOverride.Rule).Return(rule.GetType()).Repeat.Once();
            Expect.Call(ruleOverrideParameter.Name).Return(name).Repeat.Once();
            Expect.Call(ruleOverrideParameter.Value).Return(value).Repeat.Once();

            Mocker.ReplayAll();

            IRuleConfiguration actual = _configFactory.GetRuleConfigurationFor(rule.GetType());
            Assert.AreEqual(name, actual.Parameters[0].Name);
            Assert.AreEqual(type, actual.Parameters[0].ParameterType);
            Assert.AreEqual(value, actual.Parameters[0].Value);
            
            Mocker.VerifyAll();
            
        }

        [Test]
        public void ConfigurationFactoryShouldSetOverrideToProject()
        {
            IRuleConfigurationOverride overrideConfig = Mocker.DynamicMock<IRuleConfigurationOverride>();
            Expect.Call(() => _project.SetProjectRuleConfigurationOverrideTo(overrideConfig)).Repeat.Once();
            Expect.Call(() => _manager.Write(_project)).Repeat.Once();

            Mocker.ReplayAll();

            _configFactory.SetRuleConfiguration(overrideConfig);

            Mocker.VerifyAll();
        }
    }
}
