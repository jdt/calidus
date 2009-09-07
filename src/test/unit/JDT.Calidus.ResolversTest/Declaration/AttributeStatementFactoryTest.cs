using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Declaration;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;
using JDT.Calidus.Tokens.Constants;
using NUnit.Framework;

namespace JDT.Calidus.Statements.FactoriesTest.Declaration
{
    [TestFixture]
    public class AttributeStatementFactoryTest : CalidusTestBase
    {
        private AttributeStatementFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new AttributeStatementFactory();
        }

        [Test]
        public void SquareBracketDelimitedCodeShouldBeAttribute()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());

            Assert.IsTrue(_factory.CanCreateStatementFrom(input));
        }

        [Test]
        public void AttributeCanFollowWhiteSpace()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<NewLineToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<TabToken>());
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());

            Assert.IsTrue(_factory.CanCreateStatementFrom(input));
        }

        [Test]
        public void ArrayDeclarationShouldNotParseAsAttribute()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<EqualsToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<NewToken>("new"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<OpenSquareBracketToken>());
            input.Add(TokenCreator.Create<IntegerConstantToken>(2));
            input.Add(TokenCreator.Create<CloseSquareBracketToken>());
            input.Add(TokenCreator.Create<SemiColonToken>());

            Assert.IsFalse(_factory.CanCreateStatementFrom(input));
        }
    }
}
