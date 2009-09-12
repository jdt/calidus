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
    public class NextTokenOccurenceImpl : NextTokenOccurenceBase
    {
        public NextTokenOccurenceImpl(Type tokenType)
            : base(tokenType)
        {
            
        }

        public override void PopFrom(Queue<TokenBase> tokens)
        {
            
        }
    }

    [TestFixture]
    public class NextTokenOccurenceTest : CalidusTestBase
    {
        private NextTokenOccurenceImpl _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new NextTokenOccurenceImpl(typeof(IdentifierToken));
        }

        [Test]
        public void NextTokenOccurenceTestIsValidShouldBeFalseForEmptyQueue()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();

            Assert.IsFalse(_occurence.IsValidFor(input));
        }

        [Test]
        public void NextTokenOccurenceTestIsValidShouldBeFalseForWrongToken()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SemiColonToken>());

            Assert.IsFalse(_occurence.IsValidFor(input));
        }

        [Test]
        public void NextTokenOccurenceTestIsValidShouldBeTrueForMatchingToken()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<IdentifierToken>("test"));

            Assert.IsTrue(_occurence.IsValidFor(input));
        }
    }
}
