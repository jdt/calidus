using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using NUnit.Framework;

namespace JDT.Calidus.CommonTest.Rules.Configuration.Factories
{
    public class TestStreamProvider : IFileRuleConfigurationFactoryStreamProvider
    {
        private XmlReader _reader;
        private XmlWriter _writer;

        public TestStreamProvider(XmlReader reader, XmlWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public XmlReader GetReader()
        {
            return _reader;
        }

        public XmlWriter GetWriter()
        {
            return _writer;
        }
    }

    [TestFixture]
    public class FileRuleConfigurationFactoryTest
    {
        private XmlWriter GetEmptyWriter()
        {
            return new XmlTextWriter(new MemoryStream(), Encoding.Default);
        }

        [Test]
        public void ParsingStreamWithRegistrationShouldReturnInformation()
        {
            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
            bldr.Append("<rules>");
            bldr.Append(@"<rule type=""JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"">");
            bldr.Append("<description>");
            bldr.Append("Description text");
            bldr.Append("</description>");
            bldr.Append("<params>");
            bldr.Append(@"<param name=""param1"">");
            bldr.Append("theValue");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            FileRuleConfigurationFactory builder = new FileRuleConfigurationFactory(new TestStreamProvider(reader, GetEmptyWriter()));
            IRuleConfiguration actual = builder.Get(typeof(UnCreatableRule));

            IDictionary<String, String> expectedParam = new Dictionary<String, String>();
            expectedParam.Add("param1", "theValue");

            Assert.AreEqual("Description text", actual.Description);
            Assert.AreEqual(Type.GetType("JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"), actual.Rule);
            CollectionAssert.AreEquivalent(expectedParam, actual.Parameters);
        }

        [Test]
        public void ParsingStreamWithRegistrationShouldSupportDescriptionCData()
        {
            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
            bldr.Append("<rules>");
            bldr.Append(@"<rule type=""JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"">");
            bldr.Append("<description>");
            bldr.Append("<![CDATA[Description text]]>");
            bldr.Append("</description>");
            bldr.Append("<params>");
            bldr.Append(@"<param name=""param1"">");
            bldr.Append("theValue");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            FileRuleConfigurationFactory builder = new FileRuleConfigurationFactory(new TestStreamProvider(reader, GetEmptyWriter()));
            IRuleConfiguration actual = builder.Get(typeof(UnCreatableRule));

            IDictionary<String, String> expectedParam = new Dictionary<String, String>();
            expectedParam.Add("param1", "theValue");

            Assert.AreEqual("Description text", actual.Description);
            Assert.AreEqual(Type.GetType("JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"), actual.Rule);
            CollectionAssert.AreEquivalent(expectedParam, actual.Parameters);
        }

        [Test]
        public void RuleTypeDeclarationOfInvalidRuleTypeShouldThrowException()
        {
            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
            bldr.Append("<rules>");
            bldr.Append(@"<rule type=""NonExistingRule, JDT.Calidus.CommonTest"">");
            bldr.Append("<description>");
            bldr.Append("<![CDATA[Description text]]>");
            bldr.Append("</description>");
            bldr.Append("<params>");
            bldr.Append(@"<param name=""param1"">");
            bldr.Append("theValue");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            Assert.Throws<TypeLoadException>(
                delegate
                {
                    FileRuleConfigurationFactory builder = new FileRuleConfigurationFactory(new TestStreamProvider(reader, GetEmptyWriter()));
                }
                );
        }

        [Test]
        public void AddingRuleTypeShouldWriteDocumentToXmlWriter()
        {
            StringBuilder empty = new StringBuilder();
            empty.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            empty.Append("<rules>");
            empty.Append("</rules>");

            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            bldr.Append("<rules>");
            bldr.Append(@"<rule type=""JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"">");
            bldr.Append("<description>");
            bldr.Append("Description text");
            bldr.Append("</description>");
            bldr.Append("<params>");
            bldr.Append(@"<param name=""param1"">");
            bldr.Append("theValue");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream writerStream = new MemoryStream();

            XmlReader reader = new XmlTextReader(new StringReader(empty.ToString()));
            XmlWriter writer = XmlTextWriter.Create(writerStream, new XmlWriterSettings());

            Type type = Type.GetType("JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest");
            String desc = "Description text";
            IDictionary<String, String> param = new Dictionary<String, String>();
            param.Add("param1", "theValue");

            FileRuleConfigurationFactory builder = new FileRuleConfigurationFactory(new TestStreamProvider(reader, writer));
            builder.Set(type, desc, param);

            writerStream.Seek(0, SeekOrigin.Begin);
            TextReader actualReader = new StreamReader(writerStream);
            String actual = actualReader.ReadToEnd();

            Assert.AreEqual(bldr.ToString(), actual);
        }
    }
}