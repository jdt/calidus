﻿#region License
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
using JDT.Calidus.Statements.Factories.Common;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;
using NUnit.Framework;

namespace JDT.Calidus.Statements.FactoriesTest.Common
{
    [TestFixture]
    public class OpenBlockStatementFactoryTest : CalidusTestBase
    {
        private OpenBlockStatementFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new OpenBlockStatementFactory();
        }

        [Test]
        public void OpenCurlyBracketTokenShouldBeOpenBlockStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<SpaceToken>());
            input.Add(TokenCreator.Create<OpenCurlyBracketToken>());
            input.Add(TokenCreator.Create<TabToken>());

            Assert.IsTrue(_factory.CanCreateStatementFrom(input, null));
        }

        [Test]
        public void OnlyOpenCurlyBracketTokenShouldBeOpenBlockStatement()
        {
            IList<TokenBase> input = new List<TokenBase>();
            input.Add(TokenCreator.Create<IdentifierToken>("Test"));
            input.Add(TokenCreator.Create<OpenCurlyBracketToken>());
            input.Add(TokenCreator.Create<TabToken>());

            Assert.IsFalse(_factory.CanCreateStatementFrom(input, null));
        }
    }
}
