using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent.TokenOccurences;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using NUnit.Framework;

namespace JDT.Calidus.Statements.Factories.FluentTest.TokenOccurences
{
    [TestFixture]
    public class TokenOccurenceTest : CalidusTestBase
    {
        private TokenOccurence _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new TokenOccurence(typeof(IdentifierToken));
        }

        [Test]
        public void TokenOccurencePopFromShouldNotPopFromEmptyQueue()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            _occurence.PopFrom(input);

            Assert.AreEqual(0, input.Count);
        }

        [Test]
        public void TokenOccurencePopFromShouldPopWhiteSpace()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SpaceToken>());
            input.Enqueue(TokenCreator.Create<TabToken>());
            input.Enqueue(TokenCreator.Create<NewLineToken>());
            input.Enqueue(TokenCreator.Create<IdentifierToken>("test"));

            _occurence.PopFrom(input);

            Assert.AreEqual(1, input.Count);
        }

        [Test]
        public void TokenOccurencePopFromShouldNotPopNonWhiteSpace()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SemiColonToken>());
            input.Enqueue(TokenCreator.Create<IdentifierToken>("test"));

            _occurence.PopFrom(input);

            Assert.AreEqual(2, input.Count);
        }
    }
}
