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

        [Test]
        public void InternalModifierTokenShouldBeAccessModifierToken()
        {
            InternalModifierToken token = new InternalModifierToken(1, 1, 1, "internal");
            Assert.IsInstanceOf<AccessModifierToken>(token);
        }
    }
}
