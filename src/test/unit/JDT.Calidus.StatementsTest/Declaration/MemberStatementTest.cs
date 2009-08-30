using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Modifiers;
using NUnit.Framework;

namespace JDT.Calidus.StatementsTest.Declaration
{
    [TestFixture]
    public class MemberStatementTest : CalidusTestBase
    {
        private MemberStatement _statement;

        [SetUp]
        public override void SetUp()
        {
 	         base.SetUp();
            _statement = StatementCreator.CreateMemberStatement("member");
        }

        [Test]
        public void MemberNameTokenPropertyShouldReturnMemberNameToken()
        {
            TokenBase expected = TokenCreator.Create<IdentifierToken>("memberName");

            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<PrivateModifierToken>("private"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("String"));
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(expected);
            input.Add(TokenCreator.Create<SemiColonToken>());

            MemberStatement statement = new MemberStatement(input);
            Assert.AreEqual(expected, statement.MemberNameToken);
        }
    }
}
