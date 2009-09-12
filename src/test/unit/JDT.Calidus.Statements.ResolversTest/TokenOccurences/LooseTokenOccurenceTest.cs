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
    public class LooseTokenOccurenceTest : CalidusTestBase
    {
        private LooseTokenOccurence _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new LooseTokenOccurence(typeof(SemiColonToken));
        }

        [Test]
        public void LooseTokenOccurencePopFromShouldNotPopFromEmptyQueue()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();

            _occurence.PopFrom(input);

            Assert.AreEqual(0, input.Count);
        }

        [Test]
        public void LooseTokenOccurencePopFromShouldPopWhiteSpace()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SpaceToken>());
            input.Enqueue(TokenCreator.Create<TabToken>());
            input.Enqueue(TokenCreator.Create<NewLineToken>());
            input.Enqueue(TokenCreator.Create<SemiColonToken>());

            _occurence.PopFrom(input);

            Assert.AreEqual(1, input.Count);
        }

        [Test]
        public void LooseTokenOccurencePopFromShouldPopUntilTokenTypeEncountered()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<IdentifierToken>("test"));
            input.Enqueue(TokenCreator.Create<ForwardSlashToken>());
            input.Enqueue(TokenCreator.Create<SemiColonToken>());

            _occurence.PopFrom(input);

            Assert.AreEqual(1, input.Count);
        }
    }
}
