using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent.TokenOccurences;
using JDT.Calidus.Tests;
using NUnit.Framework;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Common;

namespace JDT.Calidus.Statements.Factories.FluentTest.TokenOccurences
{
    public class TokenOccurenceImpl : TokenOccurenceBase
    {
        public TokenOccurenceImpl(Type type)
            : base(type)
        {
        }

        protected override bool IsValidMatch(IEnumerable<TokenBase> tokenList)
        {
            return true;
        }
    }

    [TestFixture]
    public class TokenOccurenceBaseTest : CalidusTestBase
    {
        private TokenOccurenceImpl _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new TokenOccurenceImpl(typeof(SpaceToken));
        }

        [Test]
        public void MatchingShouldThrowExceptionWhenTokenTypesAreNotEqual()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<SemiColonToken>());

            Assert.Throws<CalidusException>(delegate { _occurence.Matches(input); }, "Token occurence can only match a list of same-type tokens of type " + typeof(SpaceToken).Name);
        }

        [Test]
        public void MatchingShouldNotThrowExceptionWhenTokenTypesAreSubclassOfType()
        {
            TokenOccurenceImpl occurence = new TokenOccurenceImpl(typeof(WhiteSpaceToken));

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<TabToken>());
            occurence.Matches(input);

            Assert.Pass();
        }

        [Test]
        public void ConstructorShouldNotThrowExceptionWhenTokenTypesIsTokenBase()
        {
            new TokenOccurenceImpl(typeof(TokenBase));
            Assert.Pass();
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenTokenTypesIsNotTokenBase()
        {
            Assert.Throws<CalidusException>(delegate { new TokenOccurenceImpl(typeof(String)); }, "The type passed to the token occurence must be a subclass of " + typeof(TokenBase).Name);
        }

        [Test]
        public void WhenMatchedWasMatchedShouldReturnTrue()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());

            Assert.AreEqual(_occurence.Matches(input), _occurence.WasMatched);
        }

        [Test]
        public void DefaultWasMatchedShouldReturnFalse()
        {
            Assert.IsFalse(_occurence.WasMatched);
        }
    }
}