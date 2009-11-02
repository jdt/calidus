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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Statements.Common;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
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
            _manager.Encountered(new[] { classStatement}, TokenCreator.Created().Count(), TokenCreator.Created());
            Assert.AreEqual(0, _manager.GetContext(classStatement.Tokens).Parents.Count());

            OpenBlockStatement openBlock = StatementCreator.CreateOpenBlockStatement();
            _manager.Encountered(new[] { openBlock }, TokenCreator.Created().Count(), TokenCreator.Created());
            Assert.AreEqual(new [] { new StatementParent(new[] {classStatement}, openBlock) }, _manager.GetContext(openBlock.Tokens).Parents);
        }
 
        [Test]
        public void CloseBlockStatementShouldEndParentContext()
        {
            ClassStatement classStatement = StatementCreator.CreateClassStatement();
            _manager.Encountered(new[] { classStatement }, TokenCreator.Created().Count(), TokenCreator.Created());
            Assert.AreEqual(0, _manager.GetContext(classStatement.Tokens).Parents.Count());
            
            OpenBlockStatement openBlock = StatementCreator.CreateOpenBlockStatement();
            _manager.Encountered(new[] { openBlock }, TokenCreator.Created().Count(), TokenCreator.Created());
            Assert.AreEqual(new[] { new StatementParent(new[] { classStatement }, openBlock) }, _manager.GetContext(openBlock.Tokens).Parents);

            CloseBlockStatement closeBlock = StatementCreator.CreateCloseBlockStatement();
            _manager.Encountered(new[] { closeBlock }, TokenCreator.Created().Count(), TokenCreator.Created());
            Assert.AreEqual(0, _manager.GetContext(closeBlock.Tokens).Parents.Count());
        }

        [Test]
        public void CloseBlockStatementShouldSetParentToTopParent()
        {
            ClassStatement classStatement = StatementCreator.CreateClassStatement();
            _manager.Encountered(new[] { classStatement }, TokenCreator.Created().Count(), TokenCreator.Created());
            
            OpenBlockStatement openBlock = StatementCreator.CreateOpenBlockStatement();
            _manager.Encountered(new[] { openBlock }, TokenCreator.Created().Count(), TokenCreator.Created());

            ClassStatement internalClassStatement = StatementCreator.CreateClassStatement();
            _manager.Encountered(new[] { internalClassStatement }, TokenCreator.Created().Count(), TokenCreator.Created());

            OpenBlockStatement secondOpenBlock = StatementCreator.CreateOpenBlockStatement();
            _manager.Encountered(new[] { secondOpenBlock }, TokenCreator.Created().Count(), TokenCreator.Created());

            CloseBlockStatement closeBlock = StatementCreator.CreateCloseBlockStatement();
            CollectionAssert.AreEquivalent(new[] { new StatementParent(new[] { classStatement }, openBlock), new StatementParent(new[] { internalClassStatement }, secondOpenBlock) }, _manager.GetContext(closeBlock.Tokens).Parents);
            _manager.Encountered(new[] { closeBlock }, TokenCreator.Created().Count(), TokenCreator.Created());

            CollectionAssert.AreEquivalent(new[] { new StatementParent(new[] { classStatement }, openBlock) }, _manager.GetContext(openBlock.Tokens).Parents);
            _manager.Encountered(new[] { closeBlock }, TokenCreator.Created().Count(), TokenCreator.Created());
        }

        [Test]
        public void NextTokenShouldNotReturnWhiteSpaceToken()
        {
            TokenBase identifier = TokenCreator.Create<IdentifierToken>("test");
            TokenBase space = TokenCreator.Create<SpaceToken>();

            StatementBase classStatement = StatementCreator.CreateClassStatement();
            StatementBase memberStatement = StatementCreator.CreateMemberStatement("test");

            IList<TokenBase> totalList = new List<TokenBase>();
            foreach (TokenBase aToken in classStatement.Tokens)
                totalList.Add(aToken);
            foreach (TokenBase aToken in memberStatement.Tokens)
                totalList.Add(aToken);
            totalList.Add(space);
            totalList.Add(identifier);

            IList<TokenBase> identifierList = new List<TokenBase>();
            identifierList.Add(space);
            identifierList.Add(identifier);

            _manager.Encountered(new[] { classStatement }, classStatement.Tokens.Count(), totalList);
            Assert.AreEqual(identifier, _manager.GetContext(memberStatement.Tokens).NextTokenFromCurrentStatement);
        }

        [Test]
        public void ManagerWithNoEncounteredCalledShouldReturnNextNull()
        {
            Assert.IsNull(_manager.GetContext(new TokenBase[] { }).NextTokenFromCurrentStatement);
        }
    }
}