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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using NUnit.Framework;

namespace JDT.Calidus.CommonTest.Rules.Configuration.Factories
{
    public class FileRuleConfigurationFactoryImpl: FileRuleConfigurationFactory
    {
        private XmlWriter _writer;
        private XmlReader _reader;

        public FileRuleConfigurationFactoryImpl(XmlReader reader, XmlWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        protected override XmlWriter GetWriter()
        {
            return _writer;
        }

        protected override XmlReader GetReader()
        {
            return _reader;
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
            bldr.Append(@"<param name=""param1"" type=""String"">");
            bldr.Append("theValue1");
            bldr.Append(@"</param>");
            bldr.Append(@"<param name=""param2"" type=""String"">");
            bldr.Append("theValue2");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            FileRuleConfigurationFactory builder = new FileRuleConfigurationFactoryImpl(reader, GetEmptyWriter());
            IRuleConfiguration actual = builder.Get(typeof(UnCreatableRule));

            IList<IRuleConfigurationParameter> paramList = new List<IRuleConfigurationParameter>();
            DefaultRuleConfigurationParameter param1 = new DefaultRuleConfigurationParameter();
            param1.ParameterType = ParameterType.String;
            param1.Name = "param1";
            param1.Value = "theValue1";
            paramList.Add(param1);

            DefaultRuleConfigurationParameter param2 = new DefaultRuleConfigurationParameter();
            param2.ParameterType = ParameterType.String;
            param2.Name = "param2";
            param2.Value = "theValue2";
            paramList.Add(param2);

            Assert.AreEqual("Description text", actual.Description);
            Assert.AreEqual(Type.GetType("JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"), actual.Rule);
            CollectionAssert.AreEquivalent(paramList, actual.Parameters);
        }

        [Test]
        public void BooleanTypeParameterShouldParseAsBoolean()
        {
            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
            bldr.Append("<rules>");
            bldr.Append(@"<rule type=""JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"">");
            bldr.Append("<description>");
            bldr.Append("Description text");
            bldr.Append("</description>");
            bldr.Append("<params>");
            bldr.Append(@"<param name=""param1"" type=""Boolean"">");
            bldr.Append("false");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            FileRuleConfigurationFactory builder = new FileRuleConfigurationFactoryImpl(reader, GetEmptyWriter());
            IRuleConfiguration actual = builder.Get(typeof(UnCreatableRule));

            IList<IRuleConfigurationParameter> paramList = new List<IRuleConfigurationParameter>();
            DefaultRuleConfigurationParameter param = new DefaultRuleConfigurationParameter();
            param.ParameterType = ParameterType.Boolean;
            param.Name = "param1";
            param.Value = false;
            paramList.Add(param);

            Assert.AreEqual("Description text", actual.Description);
            Assert.AreEqual(Type.GetType("JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"), actual.Rule);
            CollectionAssert.AreEquivalent(paramList, actual.Parameters);
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
            bldr.Append(@"<param name=""param1"" type=""String"">");
            bldr.Append("theValue");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            FileRuleConfigurationFactory builder = new FileRuleConfigurationFactoryImpl(reader, GetEmptyWriter());
            IRuleConfiguration actual = builder.Get(typeof(UnCreatableRule));

            IList<IRuleConfigurationParameter> paramList = new List<IRuleConfigurationParameter>();
            DefaultRuleConfigurationParameter param = new DefaultRuleConfigurationParameter();
            param.ParameterType = ParameterType.String;
            param.Name = "param1";
            param.Value = "theValue";
            paramList.Add(param);

            Assert.AreEqual("Description text", actual.Description);
            Assert.AreEqual(Type.GetType("JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"), actual.Rule);
            CollectionAssert.AreEquivalent(paramList, actual.Parameters);
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
            bldr.Append(@"<param name=""param1"" type=""String"">");
            bldr.Append("theValue");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            FileRuleConfigurationFactory builder = new FileRuleConfigurationFactoryImpl(reader, GetEmptyWriter());

            Assert.Throws<TypeLoadException>(
                    delegate
                    {

                        IRuleConfiguration config = builder.Get(GetType());
                    }
                );
        }

        [Test]
        public void ModifyingRuleSettingsShouldWriteDocumentToXmlWriter()
        {
            StringBuilder before = new StringBuilder();
            before.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            before.Append("<rules>");
            before.Append(@"<rule type=""JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"">");
            before.Append("<description>");
            before.Append("Set description text");
            before.Append("</description>");
            before.Append("<params>");
            before.Append(@"<param name=""param1"" type=""String"">");
            before.Append("Set parameter value");
            before.Append(@"</param>");
            before.Append("</params>");
            before.Append("</rule>");
            before.Append("</rules>");

            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            bldr.Append("<rules>");
            bldr.Append(@"<rule type=""JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"">");
            bldr.Append("<description>");
            bldr.Append("Description text");
            bldr.Append("</description>");
            bldr.Append("<params>");
            bldr.Append(@"<param name=""param1"" type=""String"">");
            bldr.Append("theValue");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream writerStream = new MemoryStream();

            XmlReader reader = new XmlTextReader(new StringReader(before.ToString()));
            XmlWriter writer = XmlTextWriter.Create(writerStream, new XmlWriterSettings());

            Type type = Type.GetType("JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest");
            String desc = "Description text";

            FileRuleConfigurationFactory builder = new FileRuleConfigurationFactoryImpl(reader, writer);

            IRuleConfiguration config = builder.Get(type);
            config.Description = desc;
            config.Parameters[0].Value = "theValue";

            builder.Set(config);

            writerStream.Seek(0, SeekOrigin.Begin);
            TextReader actualReader = new StreamReader(writerStream);
            String actual = actualReader.ReadToEnd();

            Assert.AreEqual(bldr.ToString(), actual);
        }

        [Test]
        public void ParsingStreamWithRegistrationShouldSupportMultipleRules()
        {
            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
            bldr.Append("<rules>");
            bldr.Append(@"<rule type=""JDT.Calidus.CommonTest.Rules.UnCreatableRule, JDT.Calidus.CommonTest"">");
            bldr.Append("<description>");
            bldr.Append("Description text");
            bldr.Append("</description>");
            bldr.Append("<params>");
            bldr.Append(@"<param name=""param1"" type=""String"">");
            bldr.Append("theValue1");
            bldr.Append(@"</param>");
            bldr.Append(@"<param name=""param2"" type=""String"">");
            bldr.Append("theValue2");
            bldr.Append(@"</param>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append(@"<rule type=""JDT.Calidus.CommonTest.CreatableRule, JDT.Calidus.CommonTest"">");
            bldr.Append("<description>");
            bldr.Append("Description text");
            bldr.Append("</description>");
            bldr.Append("<params>");
            bldr.Append("</params>");
            bldr.Append("</rule>");
            bldr.Append("</rules>");

            Stream stream = new MemoryStream(Encoding.Default.GetBytes(bldr.ToString()));
            XmlReader reader = new XmlTextReader(stream);

            FileRuleConfigurationFactory builder = new FileRuleConfigurationFactoryImpl(reader, GetEmptyWriter());
            IRuleConfiguration one = builder.Get(typeof(UnCreatableRule));
            IRuleConfiguration two = builder.Get(typeof(CreatableRule));

            Assert.IsNotNull(one);
            Assert.IsNotNull(two);
        }
    }
}