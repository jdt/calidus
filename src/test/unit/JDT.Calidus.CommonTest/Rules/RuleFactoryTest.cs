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
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;
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
            RuleFactory<IRule> factory = new RuleFactory<IRule>(GetType().Assembly);

            Assert.Throws<CalidusException>(delegate
                                                {
                                                    factory.GetStatementRules(new List<IRuleConfiguration>());
                                                },
                                            "Found rule UnCreatableRule, but an instance could not be created because the rule configuration does not match the constructor and no default no-args constructor was found"
                                            );
        }

        [Test]
        public void FactoryShouldUseArgumentArrayFromOverriddenRulesIfAvailable()
        {
            MockRepository mocker = new MockRepository();

            IRuleConfiguration unCreateableRule = mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory ruleConfigurationFactory = mocker.DynamicMock<IRuleConfigurationFactory>();
            IList<IRuleConfiguration> overrides = new[] {unCreateableRule};
          
            Expect.Call(unCreateableRule.Rule).Return(typeof(UnCreatableRule)).Repeat.Once();
            Expect.Call(unCreateableRule.ArgumentArray).Return(new[] {"test"}).Repeat.Once();

            mocker.ReplayAll();
            
            RuleFactory<IRule> factory = new RuleFactory<IRule>(GetType().Assembly, ruleConfigurationFactory);
            factory.GetStatementRules(overrides);

            mocker.VerifyAll();
        }
    }
}