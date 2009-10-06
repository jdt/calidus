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
