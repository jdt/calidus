using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using JDT.Calidus.Rules.Statements.Declaration;
using JDT.Calidus.Tests;
using NUnit.Framework;

namespace JDT.Calidus.Rules.StatementsTest.Declaration
{
    [TestFixture]
    public class MemberNameMatchesPatternRuleTest : CalidusTestBase
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        [Test]
        public void RuleShouldValidateStatements()
        {
            MemberNameMatchesPatternRule rule = new MemberNameMatchesPatternRule(new Regex(""));
            Assert.IsTrue(rule.Validates(StatementCreator.CreateMemberStatement("member")));
        }

        [Test]
        public void RuleShouldReturnValidForStatementsThatMatchThePattern()
        {
            MemberNameMatchesPatternRule rule = new MemberNameMatchesPatternRule(new Regex("^_[a-z]+"));
            Assert.IsTrue(rule.IsValidFor(StatementCreator.CreateMemberStatement("_aTest")));
        }

        [Test]
        public void RuleShouldReturnInvalidForStatementsThatDoNotMatchThePattern()
        {
            MemberNameMatchesPatternRule rule = new MemberNameMatchesPatternRule(new Regex("^_[a-z]+"));
            Assert.IsFalse(rule.IsValidFor(StatementCreator.CreateMemberStatement("ATest")));
        }
    }
}