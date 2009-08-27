using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class MemberStatementResolverTest
    {
        private MemberStatementResolver _resolver;

        [SetUp]
        public void SetUp()
        {
            _resolver = new MemberStatementResolver();
        }

        [Test]
        public void MemberStatementResolverShouldResolveMemberCorrectly()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new PrivateModifierToken(1, 1, 0, "private"));
            input.Add(new SpaceToken(1, 8, 7));
            input.Add(new IdentifierToken(1, 9, 8, "String"));
            input.Add(new SpaceToken(1, 15, 14));
            input.Add(new IdentifierToken(1, 16, 15, "t"));
            input.Add(new SemiColonToken(1, 17, 16));

            Assert.IsTrue(_resolver.CanResolve(input));
        }

        [Test]
        public void MemberStatementResolverShouldNotResolveClass()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new PrivateModifierToken(1, 1, 0, "private"));
            input.Add(new SpaceToken(1, 8, 7));
            input.Add(new ClassToken(1, 9, 8, "class"));
            input.Add(new SpaceToken(1, 14, 13));
            input.Add(new IdentifierToken(1, 15, 14, "t"));

            Assert.IsFalse(_resolver.CanResolve(input));
        }

        [Test]
        public void MemberStatementResolverShouldNotResolveMethod()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(new PrivateModifierToken(1, 1, 0, "private"));
            input.Add(new SpaceToken(1, 8, 7));
            input.Add(new IdentifierToken(1, 9, 8, "String"));
            input.Add(new SpaceToken(1, 15, 14));
            input.Add(new IdentifierToken(1, 16, 15, "t"));
            input.Add(new OpenRoundBracketToken(1, 17, 16));
            input.Add(new CloseRoundBracketToken(1, 18, 17));

            Assert.IsFalse(_resolver.CanResolve(input));
        }
    }
}
