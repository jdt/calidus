using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Statements.Resolvers.TokenOccurences;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Statements.ResolversTest.TokenOccurences
{
    [TestFixture]
    public class TokenOccurenceTest
    {
        private TokenOccurence _occurence;

        [SetUp]
        public void SetUp()
        {
            _occurence = new TokenOccurence(typeof(SpaceToken), 2);
        }

        [Test]
        public void TokenOccurenceShouldReturnTrueForMatchingCount()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new SpaceToken(1, 1, 0));
            input.Add(new SpaceToken(1, 2, 1));

            Assert.IsTrue(_occurence.Matches(input));
        }

        [Test]
        public void TokenOccurenceShouldReturnFalseForLesserMatchingCount()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new SpaceToken(1, 1, 0));

            Assert.IsFalse(_occurence.Matches(input));
        }

        [Test]
        public void TokenOccurenceShouldReturnTrueForBiggerMatchingCount()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new SpaceToken(1, 1, 0));
            input.Add(new SpaceToken(1, 2, 1));
            input.Add(new SpaceToken(1, 3, 2));

            Assert.IsFalse(_occurence.Matches(input));
        }
    }
}
