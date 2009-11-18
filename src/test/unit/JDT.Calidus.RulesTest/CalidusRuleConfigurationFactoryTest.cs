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
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.RulesTest
{
    [TestFixture]
    public class CalidusRuleConfigurationFactoryTest
    {
        private CalidusRuleConfigurationFactory _configFactory;
        private ICalidusProject _project;
        private ICalidusProjectManager _manager;
        private IRuleConfigurationFactoryProvider _provider;

        private MockRepository _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();

            _project = _mocker.DynamicMock<ICalidusProject>();
            _manager = _mocker.DynamicMock<ICalidusProjectManager>();
            _provider = _mocker.DynamicMock<IRuleConfigurationFactoryProvider>();
            _configFactory = new CalidusRuleConfigurationFactory(_project, _manager, _provider);
        }

        [Test]
        public void ConfigurationFactoryShouldThrowExceptionForRuleWithoutDefaultConfiguration()
        {
            IRule rule = _mocker.DynamicMock<IRule>();

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
            IRule rule = _mocker.DynamicMock<IRule>();
            IRuleConfiguration config = _mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory factory = _mocker.DynamicMock<IRuleConfigurationFactory>();

            Expect.Call(_provider.GetRuleConfigurationFactoryFor(rule.GetType())).Return(factory).Repeat.Once();
            Expect.Call(factory.Get(rule.GetType())).Return(config).Repeat.Once();
            Expect.Call(_project.GetProjectRuleConfigurationOverrides()).Return(new IRuleConfigurationOverride[] {}).Repeat.Once();

            _mocker.ReplayAll();

            Assert.AreEqual(config, _configFactory.GetRuleConfigurationFor(rule.GetType()));

            _mocker.VerifyAll();
        }

        [Test]
        public void ConfigurationFactoryShouldReturnOverriddenRulesIfAvailable()
        {
            //TODO: this test was difficult to write, is difficult to read and therefore can use some refactoring 
            String name = "parameterName";
            ParameterType type = ParameterType.MultilineString;
            String value = "parameterValue";

            IRule rule = _mocker.DynamicMock<IRule>();
            IRuleConfiguration config = _mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory factory = _mocker.DynamicMock<IRuleConfigurationFactory>();
            IRuleConfigurationOverride ruleOverride = _mocker.DynamicMock<IRuleConfigurationOverride>();

            IRuleConfigurationParameter defaultParameter = _mocker.DynamicMock<IRuleConfigurationParameter>();
            IRuleConfigurationParameter ruleOverrideParameter = _mocker.DynamicMock<IRuleConfigurationParameter>();

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

            _mocker.ReplayAll();

            IRuleConfiguration actual = _configFactory.GetRuleConfigurationFor(rule.GetType());
            Assert.AreEqual(name, actual.Parameters[0].Name);
            Assert.AreEqual(type, actual.Parameters[0].ParameterType);
            Assert.AreEqual(value, actual.Parameters[0].Value);
            
            _mocker.VerifyAll();
            
        }

        [Test]
        public void ConfigurationFactoryShouldSetOverrideToProject()
        {
            IRuleConfigurationOverride overrideConfig = _mocker.DynamicMock<IRuleConfigurationOverride>();
            Expect.Call(() => _project.SetProjectRuleConfigurationOverrideTo(overrideConfig)).Repeat.Once();
            Expect.Call(() => _manager.Write(_project)).Repeat.Once();

            _mocker.ReplayAll();

            _configFactory.SetRuleConfiguration(overrideConfig);

            _mocker.VerifyAll();
        }
    }
}
