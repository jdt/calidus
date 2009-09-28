﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Common;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using NUnit.Framework;

namespace JDT.Calidus.Statements.FactoriesTest.Common
{
    [TestFixture]
    public class LineCommentStatementFactoryTest : CalidusTestBase
    {
        private LineCommentStatementFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new LineCommentStatementFactory();
        }

        [Test]
        public void LineCommentTokenShouldBeLineComment()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<LineCommentToken>("Test"));

            Assert.IsTrue(_factory.CanCreateStatementFrom(input));
        }

        [Test]
        public void TwoForwardSlashTokensShouldNotBeLineComment()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<ForwardSlashToken>());
            input.Add(TokenCreator.Create<ForwardSlashToken>());
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));

            Assert.IsFalse(_factory.CanCreateStatementFrom(input));
        }
    }
}
