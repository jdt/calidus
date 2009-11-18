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
using JDT.Calidus.Common.Rules.Configuration;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.CommonTest.Rules.Configuration
{
    [TestFixture]
    public class DefaultRuleConfigurationTest
    {
        private DefaultRuleConfiguration _config;

        [SetUp]
        public void SetUp()
        {
            _config = new DefaultRuleConfiguration();
            _config.Description = "Description";
            _config.Rule = typeof(UnCreatableRule);

            DefaultRuleConfigurationParameter param = new DefaultRuleConfigurationParameter();
            param.Name = "arg";
            param.Value = "argumentValue";
            param.ParameterType = ParameterType.String;

            _config.Parameters = new DefaultRuleConfigurationParameter[]{param};
        }

        [Test]
        public void MatchesShouldReturnTrueForMatchingConstructorParameters()
        {
            Assert.IsTrue(_config.Matches(typeof(UnCreatableRule).GetConstructors().ElementAt(0)));
        }

        [Test]
        public void MatchesShouldReturnFalseForNoneMatchingConstructorParameters()
        {
            Assert.IsFalse(_config.Matches(typeof(CreateableRule).GetConstructors().ElementAt(0)));
        }

        [Test]
        public void ArgumentArrayShouldGetArrayOfArguments()
        {
            object[] expected = { "argumentValue" };
            CollectionAssert.AreEquivalent(expected, _config.ArgumentArray);
        }
    }
}
