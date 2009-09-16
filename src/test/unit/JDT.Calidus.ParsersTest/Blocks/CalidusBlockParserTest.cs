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
        [Test]
        public void ParserShouldCallSBlockFactoryWhenParsingStatements()
        {
            IList<StatementBase> input = new List<StatementBase>();
            input.Add(StatementCreator.CreateMemberStatement("_someString"));

            MockRepository mocker = new MockRepository();
            IBlockFactory factory = mocker.StrictMock<IBlockFactory>();
            Expect.Call(factory.Create(input)).Return(new [] { new BlockBaseImpl(input) }).Repeat.Once();

            StubBlockFactoryProvider provider = new StubBlockFactoryProvider(factory);

            CalidusBlockParser parser = new CalidusBlockParser(provider);
            mocker.ReplayAll();

            parser.Parse(input);

            mocker.VerifyAll();
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
