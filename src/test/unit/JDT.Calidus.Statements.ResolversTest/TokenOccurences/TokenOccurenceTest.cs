﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent.TokenOccurences;
using JDT.Calidus.Tests;
using NUnit.Framework;
using JDT.Calidus.Tokens.Common;

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
            _occurence = new TokenOccurence(typeof(SpaceToken), 2);
        }

        [Test]
        public void TokenOccurenceShouldReturnTrueForMatchingCount()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<SpaceToken>());

            Assert.IsTrue(_occurence.Matches(input));
        }

        [Test]
        public void TokenOccurenceShouldReturnFalseForLesserMatchingCount()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());

            Assert.IsFalse(_occurence.Matches(input));
        }

        [Test]
        public void TokenOccurenceShouldReturnTrueForBiggerMatchingCount()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<SpaceToken>());

            Assert.IsFalse(_occurence.Matches(input));
        }
    }
}