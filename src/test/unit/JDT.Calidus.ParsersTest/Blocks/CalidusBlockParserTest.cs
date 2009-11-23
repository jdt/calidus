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
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Parsers.Blocks;
using JDT.Calidus.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.ParsersTest.Blocks
{
    [TestFixture]
    public class CalidusBlockParserTest : CalidusTestBase
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }
        
        [Test]
        public void ParserShouldCallSBlockFactoryWhenParsingStatements()
        {
            IList<StatementBase> input = new List<StatementBase>();
            input.Add(StatementCreator.CreateMemberStatement("_someString"));

            IBlockFactory factory = Mocker.StrictMock<IBlockFactory>();
            Expect.Call(factory.Create(input)).Return(new [] { new BlockBaseImpl(input) }).Repeat.Once();

            StubBlockFactoryProvider provider = new StubBlockFactoryProvider(factory);

            CalidusBlockParser parser = new CalidusBlockParser(provider);
            Mocker.ReplayAll();

            parser.Parse(input);

            Mocker.VerifyAll();
        }
    }

    public class StubBlockFactoryProvider : IBlockFactoryProvider
    {
        private IList<IBlockFactory> _factories;

        public StubBlockFactoryProvider(IBlockFactory fct)
        {
            _factories = new List<IBlockFactory>();
            _factories.Add(fct);
        }
        
        public IEnumerable<IBlockFactory> GetFactories()
        {
            return _factories;
        }
    }

}
