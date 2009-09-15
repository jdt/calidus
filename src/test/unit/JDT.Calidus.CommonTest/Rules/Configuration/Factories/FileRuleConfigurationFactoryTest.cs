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
    [TestFixture]
    public class FileRuleConfigurationFactoryTest
    {
        private FileRuleConfigurationFactory _builder;

        [SetUp]
        public void SetUp()
        {
            _builder = new FileRuleConfigurationFactory();
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
            bldr.Append(@"<param name=""param1"" value=""theValue"" />");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            IEnumerable<IRuleConfiguration> actual = _builder.ParseRules(reader);

            IDictionary<String, String> expectedParam = new Dictionary<String, String>();
            expectedParam.Add("param1", "theValue");

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual("Description text", actual.ElementAt(0).Description);
            Assert.AreEqual(Type.GetType("JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"), actual.ElementAt(0).Rule);
            CollectionAssert.AreEquivalent(expectedParam, actual.ElementAt(0).Parameters);
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
            bldr.Append(@"<param name=""param1"" value=""theValue"" />");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            IEnumerable<IRuleConfiguration> actual = _builder.ParseRules(reader);

            IDictionary<String, String> expectedParam = new Dictionary<String, String>();
            expectedParam.Add("param1", "theValue");

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual("Description text", actual.ElementAt(0).Description);
            Assert.AreEqual(Type.GetType("JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"), actual.ElementAt(0).Rule);
            CollectionAssert.AreEquivalent(expectedParam, actual.ElementAt(0).Parameters);
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
            bldr.Append(@"<param name=""param1"" value=""theValue"" />");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            Assert.Throws<TypeLoadException>(
                delegate
                    {
                        _builder.ParseRules(reader);
                    }
                );
        }
    }
}