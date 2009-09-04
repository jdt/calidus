﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using NUnit.Framework;

namespace JDT.Calidus.CommonTest.Tokens
{
    [TestFixture]
    public class TokenBaseTest
    {
        [Test]
        public void TokenBaseInheritorsShouldBeEqualWhenNotAddingAdditionalProperties()
        {
            TokenBaseImpl alpha = new TokenBaseImpl();
            TokenBaseImpl bravo = new TokenBaseImpl();

            Assert.AreEqual(alpha, bravo);
        }
    }

    public class TokenBaseImpl : TokenBase
    {
        public TokenBaseImpl()
            : base(2, 1, 15, "implContent")
        {
        }
    }
}