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
using System.Xml.Linq;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Projects.SectionManagers;
using JDT.Calidus.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.ProjectsTest.SectionManagers
{
    [TestFixture]
    public class RulesSectionManagerTest : CalidusTestBase
    {
        private RulesSectionManager _sectionManager;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _sectionManager = new RulesSectionManager();
        }

        [Test]
        public void RulesSectionManagerShouldWriteRulesSectionFromOverrideList()
        {
            IRule rule = Mocker.DynamicMock<IRule>();

            String paramOneName = "paramOne";
            String paramTwoName = "paramTwo";
            String paramOneValue = "one";
            String paramTwoValue = "two";

            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<root>");
            bldr.Append(@"<rules>");
            bldr.Append(@"<rule type=""" + rule.GetType().AssemblyQualifiedName + @""">");
            bldr.Append(@"<param name=""" + paramOneName + @""" type=""String"">" + paramOneValue + "</param>");
            bldr.Append(@"<param name=""" + paramTwoName + @""" type=""String"">" + paramTwoValue + "</param>");
            bldr.Append(@"</rule>");
            bldr.Append(@"</rules>");
            bldr.Append(@"</root>");

            IRuleConfigurationOverride overrideConfig = Mocker.DynamicMock<IRuleConfigurationOverride>();
            IRuleConfigurationParameter overrideParamOne = Mocker.DynamicMock<IRuleConfigurationParameter>();
            IRuleConfigurationParameter overrideParamTwo = Mocker.DynamicMock<IRuleConfigurationParameter>();

            IList<IRuleConfigurationOverride> overrides = new List<IRuleConfigurationOverride>();
            overrides.Add(overrideConfig);

            Expect.Call(overrideConfig.Rule).Return(rule.GetType()).Repeat.Once();
            Expect.Call(overrideConfig.Parameters).Return(new[] {overrideParamOne, overrideParamTwo}).Repeat.Once();
            Expect.Call(overrideParamOne.Name).Return(paramOneName).Repeat.Once();
            Expect.Call(overrideParamOne.Value).Return(paramOneValue).Repeat.Once();
            Expect.Call(overrideParamOne.ParameterType).Return(ParameterType.String).Repeat.Once();
            Expect.Call(overrideParamTwo.Name).Return(paramTwoName).Repeat.Once();
            Expect.Call(overrideParamTwo.Value).Return(paramTwoValue).Repeat.Once();
            Expect.Call(overrideParamTwo.ParameterType).Return(ParameterType.String).Repeat.Once();

            Mocker.ReplayAll();

            XElement parent = new XElement(XName.Get("root"));
            _sectionManager.WriteTo(overrides, parent);

            Assert.AreEqual(bldr.ToString(), parent.ToString(SaveOptions.DisableFormatting));

            Mocker.VerifyAll();
        }

        [Test]
        public void RulesSectionManagerShouldReadOverrideListFromRulesSection()
        {
            String paramOneName = "paramOne";
            String paramTwoName = "paramTwo";
            String paramOneValue = "one";
            String paramTwoValue = "two";

            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<root>");
            bldr.Append(@"<rules>");
            bldr.Append(@"<rule type=""" + typeof(String).AssemblyQualifiedName + @""">");
            bldr.Append(@"<param name=""" + paramOneName + @""" type=""String"">" + paramOneValue + "</param>");
            bldr.Append(@"<param name=""" + paramTwoName + @""" type=""String"">" + paramTwoValue + "</param>");
            bldr.Append(@"</rule>");
            bldr.Append(@"</rules>");
            bldr.Append(@"</root>");

            TextReader textReader = new StringReader(bldr.ToString());
            IEnumerable<IRuleConfigurationOverride> overrides = _sectionManager.ReadFrom(XDocument.Load(textReader));

            Assert.AreEqual(typeof(String), overrides.ElementAt(0).Rule);
            Assert.AreEqual(paramOneName, overrides.ElementAt(0).Parameters.ElementAt(0).Name);
            Assert.AreEqual(paramOneValue, overrides.ElementAt(0).Parameters.ElementAt(0).Value);
            Assert.AreEqual(ParameterType.String, overrides.ElementAt(0).Parameters.ElementAt(0).ParameterType);
            Assert.AreEqual(paramTwoName, overrides.ElementAt(0).Parameters.ElementAt(1).Name);
            Assert.AreEqual(paramTwoValue, overrides.ElementAt(0).Parameters.ElementAt(1).Value);
            Assert.AreEqual(ParameterType.String, overrides.ElementAt(0).Parameters.ElementAt(1).ParameterType);
        }
    }
}
