using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules.Configuration;
using NUnit.Framework;

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

            IDictionary<String, String> param = new Dictionary<String, String>();
            param.Add("arg", "argumentValue");

            _config.Parameters = param;
        }

        [Test]
        public void MatchesShouldReturnTrueForMatchingConstructorParameters()
        {
            Assert.IsTrue(_config.Matches(typeof(UnCreatableRule).GetConstructors().ElementAt(0)));
        }

        [Test]
        public void MatchesShouldReturnFalseForNoneMatchingConstructorParameters()
        {
            Assert.IsFalse(_config.Matches(typeof(CreatableRule).GetConstructors().ElementAt(0)));
        }

        [Test]
        public void ArgumentArrayShouldGetArrayOfArguments()
        {
            object[] expected = { "argumentValue" };
            CollectionAssert.AreEquivalent(expected, _config.ArgumentArray);
        }
    }
}
