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