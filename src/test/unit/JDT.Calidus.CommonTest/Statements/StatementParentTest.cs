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
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.CommonTest.Statements
{
    [TestFixture]
    public class StatementParentTest : CalidusTestBase
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        [Test]
        public void StatementParentsShouldBeEqual()
        {
            StatementBase alphaStatement = StatementCreator.CreateMemberStatement("test");
            StatementBase alphaDelimiter = StatementCreator.CreateOpenBlockStatement();
            TokenCreator.Reset();
            StatementBase bravoStatement = StatementCreator.CreateMemberStatement("test");
            StatementBase bravoDelimiter = StatementCreator.CreateOpenBlockStatement();

            StatementParent alpha = new StatementParent(new[] {alphaStatement}, alphaDelimiter);
            StatementParent bravo = new StatementParent(new[] {bravoStatement}, bravoDelimiter);

            Assert.AreEqual(alpha, bravo);
        }
    }
}
