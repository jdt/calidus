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
using NUnit.Framework;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Common;

namespace JDT.Calidus.Statements.Factories.FluentTest.TokenOccurences
{
    public class TokenOccurenceImpl : TokenOccurenceBase
    {
        public TokenOccurenceImpl(Type type)
            : base(type)
        {
        }


        public override void PopFrom(Queue<TokenBase> tokens)
        {
            throw new NotImplementedException();
        }

        protected override bool Validate(Queue<TokenBase> tokens)
        {
            throw new NotImplementedException();
        }

        protected override void PopValidated(Queue<TokenBase> tokens)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class TokenOccurenceBaseTest : CalidusTestBase
    {
        private TokenOccurenceImpl _occurence;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _occurence = new TokenOccurenceImpl(typeof(SpaceToken));
        }

        [Test]
        public void ConstructorShouldNotThrowExceptionWhenTokenTypesIsTokenBase()
        {
            new TokenOccurenceImpl(typeof(TokenBase));
            Assert.Pass();
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenTokenTypesIsNotTokenBase()
        {
            Assert.Throws<CalidusException>(delegate { new TokenOccurenceImpl(typeof(String)); }, "The type passed to the token occurence must be a subclass of " + typeof(TokenBase).Name);
        }
    }
}