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
    public class IsTokenOccurenceTest : CalidusTestBase
    {
        private IsTokenOccurence _is;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _is = new IsTokenOccurence(typeof (ForwardSlashToken));
        }
        
        [Test]
        public void IsTokenOccurencePopFromShouldNotPopEmptyList()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();

            _is.PopFrom(input);

            Assert.AreEqual(0, input.Count);
        }

        [Test]
        public void IsTokenOccurenceShouldPopUntilTokenTypeEncountered()
        {
            Queue<TokenBase> input = new Queue<TokenBase>();
            input.Enqueue(TokenCreator.Create<SpaceToken>());
            input.Enqueue(TokenCreator.Create<TabToken>());
            input.Enqueue(TokenCreator.Create<ForwardSlashToken>());

            _is.PopFrom(input);

            Assert.AreEqual(1, input.Count);
        }
    }
}
