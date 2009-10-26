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
using JDT.Calidus.Statements.Factories.Fluent.ExpressionOccurences;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using NUnit.Framework;

namespace JDT.Calidus.Statements.Factories.FluentTest.ExpressionOccurences
{
    [TestFixture]
    public class ContainsNoTokenOccurenceTest : CalidusTestBase
    {
        private ContainsNoTokenOccurence _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new ContainsNoTokenOccurence(typeof(SemiColonToken));
        }

        [Test]
        public void ContainsNoTokenOccurenceShouldBeValidForListNotContainingToken()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<ForwardSlashToken>());

            Assert.IsTrue(_occurence.IsValidFor(input));
        }

        [Test]
        public void ContainsNoTokenOccurenceShouldBeInValidForListContainingToken()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<ForwardSlashToken>());
            input.Add(TokenCreator.Create<SemiColonToken>());

            Assert.IsFalse(_occurence.IsValidFor(input));
        }
    }
}