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
    public class StrictTokenOccurenceTest : CalidusTestBase
    {
        private StrictTokenOccurence _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new StrictTokenOccurence(typeof(SpaceToken));
        }

        [Test]
        public void StrictTokenOccurencePopFromShouldNeverPop()
        {
            Queue<TokenBase> tokens = new Queue<TokenBase>();
            tokens.Enqueue(TokenCreator.Create<SpaceToken>());

            _occurence.PopFrom(tokens);

            Assert.AreEqual(1, tokens.Count);
        }
    }
}
