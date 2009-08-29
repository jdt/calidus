using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tests;
using NUnit.Framework;
using JDT.Calidus.Resolvers.Declaration;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Modifiers;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Types;
using JDT.Calidus.Tokens.Common.Brackets;

namespace JDT.Calidus.ResolversTest.Declaration
{
    [TestFixture]
    public class MemberStatementResolverTest : CalidusTestBase
    {
        private MemberStatementResolver _resolver;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _resolver = new MemberStatementResolver();
        }

        [Test]
        public void MemberStatementResolverShouldResolveMemberCorrectly()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<SemiColonToken>());

            Assert.IsTrue(_resolver.CanResolve(input));
        }

        [Test]
        public void MemberStatementResolverShouldNotResolveClass()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<ClassToken>("class"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));

            Assert.IsFalse(_resolver.CanResolve(input));
        }

        [Test]
        public void MemberStatementResolverShouldNotResolveMethod()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("t"));
            input.Add(TokenCreator.Create<OpenRoundBracketToken>());
            input.Add(TokenCreator.Create<CloseRoundBracketToken>());

            Assert.IsFalse(_resolver.CanResolve(input));
        }
    }
}
