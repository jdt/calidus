using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Rules;
using NUnit.Framework;

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
                                                    factory.GetStatementRules();
                                                },
                                            "Found rule UnCreatableRule, but an instance could not be created because the rule configuration does not match the constructor and no default no-args constructor was found"
                                            );
        }
    }
}