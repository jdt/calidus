using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JDT.Calidus.Tokens.Modifiers;

namespace JDT.Calidus.TokensTest.Modifiers
{
    [TestFixture]
    public class AccessModifierTokenTest
    {
        [Test]
        public void PrivateModifierTokenShouldBeAccessModifierToken()
        {
            PrivateModifierToken token = new PrivateModifierToken(1, 1, 1, "private");
            Assert.IsInstanceOf<AccessModifierToken>(token);
        }

        [Test]
        public void ProtectedModifierTokenShouldBeAccessModifierToken()
        {
            ProtectedModifierToken token = new ProtectedModifierToken(1, 1, 1, "protected");
            Assert.IsInstanceOf<AccessModifierToken>(token);
        }

        [Test]
        public void PublicModifierTokenShouldBeAccessModifierToken()
        {
            PublicModifierToken token = new PublicModifierToken(1, 1, 1, "public");
            Assert.IsInstanceOf<AccessModifierToken>(token);
        }
    }
}
