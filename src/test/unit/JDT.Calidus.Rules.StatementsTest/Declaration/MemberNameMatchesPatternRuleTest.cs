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
using System.Text.RegularExpressions;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Rules.Statements.Declaration;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;
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
            MemberNameMatchesPatternRule rule = new MemberNameMatchesPatternRule(new Regex(""), false);
            Assert.IsTrue(rule.Validates(StatementCreator.CreateMemberStatement("member")));
        }

        [Test]
        public void RuleShouldReturnValidForStatementsThatMatchThePattern()
        {
            MemberNameMatchesPatternRule rule = new MemberNameMatchesPatternRule(new Regex("^_[a-z]+"), false);
            Assert.IsTrue(rule.IsValidFor(StatementCreator.CreateMemberStatement("_aTest")));
        }

        [Test]
        public void RuleShouldReturnInvalidForStatementsThatDoNotMatchThePattern()
        {
            MemberNameMatchesPatternRule rule = new MemberNameMatchesPatternRule(new Regex("^_[a-z]+"), false);
            Assert.IsFalse(rule.IsValidFor(StatementCreator.CreateMemberStatement("ATest")));
        }

        [Test]
        public void RuleShouldReturnValidForStatementsThatDoNotMatchThePatternButArePublicStatic()
        {
            MemberNameMatchesPatternRule rule = new MemberNameMatchesPatternRule(new Regex("^_[a-z]+"), true);

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PublicModifierToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<StaticToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            MemberStatement member = new MemberStatement(input, null);

            Assert.IsTrue(rule.IsValidFor(member));
        }
    }
}