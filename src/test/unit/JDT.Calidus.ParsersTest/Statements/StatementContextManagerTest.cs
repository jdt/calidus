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
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Statements.Common;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tests;
using NUnit.Framework;

namespace JDT.Calidus.ParsersTest.Statements
{
    [TestFixture]
    public class StatementContextManagerTest : CalidusTestBase
    {
        private StatementContextManager _manager;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _manager = new StatementContextManager();
        }

        [Test]
        public void OpenBlockStatementForClassShouldSetParentContextToClass()
        {
            ClassStatement classStatement = StatementCreator.CreateClassStatement();
            OpenBlockStatement openBlock = StatementCreator.CreateOpenBlockStatement();

            _manager.Encountered(new[] { classStatement });
            Assert.AreEqual(0, _manager.GetContext().Parents.Count());
            _manager.Encountered(new[] { openBlock });
            Assert.AreEqual(new [] { new StatementParent(new[] {classStatement}, openBlock) }, _manager.GetContext().Parents);
        }
 
        [Test]
        public void CloseBlockStatementShouldEndParentContext()
        {
            ClassStatement classStatement = StatementCreator.CreateClassStatement();
            OpenBlockStatement openBlock = StatementCreator.CreateOpenBlockStatement();
            CloseBlockStatement closeBlock = StatementCreator.CreateCloseBlockStatement();

            _manager.Encountered(new[] { classStatement });
            Assert.AreEqual(0, _manager.GetContext().Parents.Count());
            _manager.Encountered(new[] { openBlock });
            Assert.AreEqual(new[] { new StatementParent(new[] { classStatement }, openBlock) }, _manager.GetContext().Parents);
            _manager.Encountered(new[] { closeBlock });
            Assert.AreEqual(0, _manager.GetContext().Parents.Count());
        }

        [Test]
        public void CloseBlockStatementShouldSetParentToTopParent()
        {
            ClassStatement classStatement = StatementCreator.CreateClassStatement();
            OpenBlockStatement openBlock = StatementCreator.CreateOpenBlockStatement();
            CloseBlockStatement closeBlock = StatementCreator.CreateCloseBlockStatement();
            ClassStatement internalClassStatement = StatementCreator.CreateClassStatement();

            _manager.Encountered(new[] { classStatement });
            _manager.Encountered(new[] { openBlock }); 
            Assert.AreEqual(new[] { new StatementParent(new[] { classStatement }, openBlock) }, _manager.GetContext().Parents);
            _manager.Encountered(new[] { internalClassStatement });
            _manager.Encountered(new[] { openBlock });
            Assert.AreEqual(new[] { new StatementParent(new[] { classStatement }, openBlock), new StatementParent(new[] { internalClassStatement }, openBlock) }, _manager.GetContext().Parents);
            _manager.Encountered(new[] { closeBlock });
            Assert.AreEqual(new[] { new StatementParent(new[] { classStatement }, openBlock) }, _manager.GetContext().Parents);
            _manager.Encountered(new[] { closeBlock });
        }
    }
}