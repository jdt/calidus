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
    public class ContainsTokenOccurenceTest : CalidusTestBase
    {
        private ContainsTokenOccurence _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new ContainsTokenOccurence(typeof(SemiColonToken));
        }

        [Test]
        public void ContainsTokenOccurencePopFromShouldNotPopEmptyList()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();

            _occurence.PopFrom(input);

            Assert.AreEqual(0, input.Count);
        }

        [Test]
        public void ContainsTokenOccurenceShouldPopUntilTokenTypeEncountered()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SpaceToken>());
            input.Enqueue(TokenCreator.Create<ForwardSlashToken>());
            input.Enqueue(TokenCreator.Create<SemiColonToken>());

            _occurence.PopFrom(input);

            Assert.AreEqual(1, input.Count);
        }
    }
}
