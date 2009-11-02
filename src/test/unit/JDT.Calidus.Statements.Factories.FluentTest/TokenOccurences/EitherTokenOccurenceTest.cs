#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent.TokenOccurences;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Types;
using NUnit.Framework;

namespace JDT.Calidus.Statements.Factories.FluentTest.TokenOccurences
{
    [TestFixture]
    public class EitherTokenOccurenceTest : CalidusTestBase
    {
        private EitherTokenOccurence _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new EitherTokenOccurence(typeof(IdentifierToken), typeof(ValueTypeToken));
        }

        [Test]
        public void TokenOccurencePopFromShouldNotPopFromEmptyQueue()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            _occurence.PopFrom(input);

            Assert.AreEqual(0, input.Count);
        }

        [Test]
        public void TokenOccurencePopFromShouldPopWhiteSpaceUntilFirstToken()
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
        public void TokenOccurencePopFromShouldPopWhiteSpaceUntilSecondToken()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SpaceToken>());
            input.Enqueue(TokenCreator.Create<TabToken>());
            input.Enqueue(TokenCreator.Create<NewLineToken>());
            input.Enqueue(TokenCreator.Create<ValueTypeToken>("test"));

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

        [Test]
        public void NextTokenOccurenceTestIsValidShouldBeTrueForMatchingTokenOne()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<IdentifierToken>("test"));

            Assert.IsTrue(_occurence.IsValidFor(input));
        }

        [Test]
        public void NextTokenOccurenceTestIsValidShouldBeTrueForMatchingTokenTwo()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<ValueTypeToken>("test"));

            Assert.IsTrue(_occurence.IsValidFor(input));
        }
    }
}
