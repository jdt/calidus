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
using JDT.Calidus.Blocks.Factories.Common;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Tests;
using NUnit.Framework;

namespace JDT.Calidus.Blocks.FactoriesTest.Common
{
    [TestFixture]
    public class FileBlockFactoryTest : CalidusTestBase
    {
        private FileBlockFactory _factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new FileBlockFactory();
        }

        [Test]
        public void FileBlockFactoryReturnedBlockStatementsShouldBeAllStatements()
        {
            IList<StatementBase> input = new List<StatementBase>();
            input.Add(StatementCreator.CreateMemberStatement("_this"));
            input.Add(StatementCreator.CreateMemberStatement("_that"));

            CollectionAssert.AreEquivalent(input, _factory.Create(input).ElementAt(0).Statements);
        }
    }
}
