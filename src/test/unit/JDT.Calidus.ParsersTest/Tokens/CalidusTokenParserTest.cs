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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tokens.Common;
using NUnit.Framework;
using JDT.Calidus.Parsers.Tokens;
using Rhino.Mocks;

namespace JDT.Calidus.ParsersTest.Tokens
{
    public class OtherParsersImpl : 
        IWhiteSpaceTokenParser, 
        IGenericsTokenParser
    {
        public OtherParsersImpl()
        {
            GenericsWasCalled = false;
            WhiteSpaceWasCalled = false;
        }

        public bool GenericsWasCalled { get; private set; }
        public bool WhiteSpaceWasCalled { get; private set; }

        IEnumerable<TokenBase> IWhiteSpaceTokenParser.Parse(String source, IEnumerable<TokenBase> previouslyParsed)
        {
            WhiteSpaceWasCalled = true;
            return previouslyParsed;
        }

        public IEnumerable<TokenBase> Parse(IEnumerable<TokenBase> input)
        {
            GenericsWasCalled = true;
            return input;
        }
    }

    [TestFixture]
    public class CalidusTokenParserTest
    {
        private OtherParsersImpl _otherImpl;

        [SetUp]
        public void SetUp()
        {
            _otherImpl = new OtherParsersImpl();
        }

        [Test]
        public void ParserShouldCheckWhiteSpaceBeforeCommentsBeforeGenerics()
        {
            MockRepository mocker = new MockRepository();
            ITokenParser parserImp = mocker.StrictMock<ITokenParser>();

            using (mocker.Ordered())
            {
                Expect.Call(parserImp.Parse("")).Return(new List<TokenBase>()).Repeat.Once();
                Expect.Call(parserImp.SupportsWhiteSpaceParsing).Return(true).Repeat.Once();
                Expect.Call(parserImp.SupportsGenericsParsing).Return(true).Repeat.Once();
            }

            mocker.ReplayAll();

            CalidusTokenParser parser = new CalidusTokenParser(parserImp, _otherImpl, _otherImpl);
            parser.Parse("");

            mocker.VerifyAll();
        }

        [Test]
        public void ParserShouldUseWhiteSpaceParserWhenPluggedParserDoesNotSupportWhiteSpace()
        {
            MockRepository mocker = new MockRepository();
            ITokenParser parserImp = mocker.StrictMock<ITokenParser>();

            Expect.Call(parserImp.Parse("")).Return(new List<TokenBase>()).Repeat.Once();
            Expect.Call(parserImp.SupportsWhiteSpaceParsing).Return(false).Repeat.Once();
            Expect.Call(parserImp.SupportsGenericsParsing).Return(true).Repeat.Once();
            
            mocker.ReplayAll();

            CalidusTokenParser parser = new CalidusTokenParser(parserImp, _otherImpl, _otherImpl);
            parser.Parse("");

            mocker.VerifyAll();
            Assert.IsTrue(_otherImpl.WhiteSpaceWasCalled);
        }

        [Test]
        public void ParserShouldUseGenericsParserWhenPluggedParserDoesNotSupportGenerics()
        {
            MockRepository mocker = new MockRepository();
            ITokenParser parserImp = mocker.StrictMock<ITokenParser>();

            Expect.Call(parserImp.Parse("")).Return(new List<TokenBase>()).Repeat.Once();
            Expect.Call(parserImp.SupportsWhiteSpaceParsing).Return(true).Repeat.Once();
            Expect.Call(parserImp.SupportsGenericsParsing).Return(false).Repeat.Once();
            
            mocker.ReplayAll();

            CalidusTokenParser parser = new CalidusTokenParser(parserImp, _otherImpl, _otherImpl);
            parser.Parse("");

            mocker.VerifyAll();
            Assert.IsTrue(_otherImpl.GenericsWasCalled);
        }
    }
}
