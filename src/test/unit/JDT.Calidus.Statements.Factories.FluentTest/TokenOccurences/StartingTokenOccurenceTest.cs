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
    [TestFixture]
    public class StartingTokenOccurenceTest : CalidusTestBase
    {
        private StartingTokenOccurence _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new StartingTokenOccurence(typeof(IdentifierToken));
        }

        [Test]
        public void StartingTokenOccurencePopFromShouldNotPopFromEmptyQueue()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();

            _occurence.PopFrom(input);
        }

        [Test]
        public void StartingTokenOccurencePopFromShouldPopWhiteSpace()
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
        public void StartingTokenOccurencePopFromShouldNotPopNonWhiteSpace()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SemiColonToken>());
            input.Enqueue(TokenCreator.Create<IdentifierToken>("test"));

            _occurence.PopFrom(input);

            Assert.AreEqual(2, input.Count);
        }
    }
}
