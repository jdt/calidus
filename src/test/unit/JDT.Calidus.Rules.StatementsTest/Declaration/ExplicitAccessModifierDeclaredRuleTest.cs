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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Rules.Statements.Declaration;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Types;
using NUnit.Framework;

namespace JDT.Calidus.Rules.StatementsTest.Declaration
{
    [TestFixture]
    public class ExplicitAccessModifierDeclaredRuleTest : CalidusTestBase
    {
        private ExplicitAccessModifierDeclaredRule _rule;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _rule = new ExplicitAccessModifierDeclaredRule();
        }

        [Test]
        public void ExplicitAccessModifierRuleShouldValidateClasses()
        {
            Assert.IsTrue(_rule.Validates(StatementCreator.CreateClassStatement()));
        }

        [Test]
        public void ExplicitAccessModifierRuleShouldValidateInterfaces()
        {
            Assert.IsTrue(_rule.Validates(StatementCreator.CreateInterfaceStatement()));

        }

        [Test]
        public void ExplicitAccessModifierRuleShouldValidateStructs()
        {
            Assert.IsTrue(_rule.Validates(StatementCreator.CreateStructStatement()));

        }

        [Test]
        public void ExplicitAccessModifierRuleShouldValidateMethods()
        {

            Assert.IsTrue(_rule.Validates(StatementCreator.CreateMethodStatement()));
        }

        [Test]
        public void ExplicitAccessModifierRuleShouldValidateMembers()
        {
            Assert.IsTrue(_rule.Validates(StatementCreator.CreateMemberStatement("test")));
        }

        [Test]
        public void RuleShouldBeValidForElementWithExplicitAccessModifier()
        {
            Assert.IsTrue(_rule.IsValidFor(StatementCreator.CreateClassStatement()));
        }

        [Test]
        public void RuleShouldNotBeValidForElementsWIthoutAccessModifier()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<ClassToken>("struct"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));
            Assert.IsFalse(_rule.IsValidFor(new ClassStatement(input)));
        }
    }
}
