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
    public class EndingTokenOccurenceTest : CalidusTestBase
    {
        private EndingTokenOccurence _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new EndingTokenOccurence(typeof(SemiColonToken));
        }

        [Test]
        public void EndingTokenOccurencePopFromShouldNotPopFromEmptyQueue()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();

            _occurence.PopFrom(input);

            Assert.AreEqual(0, input.Count);
        }

        [Test]
        public void EndingTokenOccurencePopFromShouldPopWhiteSpaceAtEnd()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SemiColonToken>());
            input.Enqueue(TokenCreator.Create<SpaceToken>());
            input.Enqueue(TokenCreator.Create<TabToken>());
            input.Enqueue(TokenCreator.Create<NewLineToken>());

            _occurence.PopFrom(input);

            Assert.AreEqual(1, input.Count);
        }

        [Test]
        public void EndingTokenOccurencePopFromShouldNotPopNonWhiteSpaceAtEnd()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SemiColonToken>());
            input.Enqueue(TokenCreator.Create<IdentifierToken>("test"));

            _occurence.PopFrom(input);

            Assert.AreEqual(2, input.Count);
        }
    }
}
