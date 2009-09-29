using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Parsers.Lines;
using JDT.Calidus.Tests;
using JDT.Calidus.Tokens.Common;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.ParsersTest.Lines
{
    [TestFixture]
    public class CalidusLineParserTest : CalidusTestBase
    {
        [Test]
        public void ParseTokensOnDifferentLinesShouldParseAsDifferentLines()
        {
            IList<TokenBase> firstLine = new List<TokenBase>();
            firstLine.Add(TokenCreator.Create<IdentifierToken>("test1"));

            TokenCreator.NewLine(1);

            IList<TokenBase> secondLine = new List<TokenBase>();
            secondLine.Add(TokenCreator.Create<IdentifierToken>("test2"));

            MockRepository mocker = new MockRepository();
            ILineFactory factory = mocker.StrictMock<ILineFactory>();
            Expect.Call(factory.Create(firstLine)).Return(new Line(firstLine)).Repeat.Once();
            Expect.Call(factory.Create(secondLine)).Return(new Line(secondLine)).Repeat.Once();

            StubLineFactoryProvider provider = new StubLineFactoryProvider(factory);
            CalidusLineParser parser = new CalidusLineParser(provider);
            
            IList<LineBase> expected = new List<LineBase>();
            expected.Add(new Line(firstLine));
            expected.Add(new Line(secondLine));

            IList<TokenBase> toParse = new List<TokenBase>();
            toParse.Add(firstLine[0]);
            toParse.Add(secondLine[0]);

            factory.Replay();

            IEnumerable<LineBase> actual = parser.Parse(toParse);
            CollectionAssert.AreEquivalent(expected, actual);

            mocker.VerifyAll();
        }
    }
}
