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
            RuleFactory factory = new RuleFactory(GetType().Assembly.GetTypes(), null, null);
            ICalidusRuleConfigurationFactory configFactory = _mocker.DynamicMock<ICalidusRuleConfigurationFactory>();

            Assert.Throws<CalidusException>(delegate
                                                {
                                                    factory.GetStatementRules(configFactory);
                                                },
                                            "Found rule UnCreatableRule, but an instance could not be created because the rule configuration does not match the constructor and no default no-args constructor was found"
                                            );
        }
    }
}