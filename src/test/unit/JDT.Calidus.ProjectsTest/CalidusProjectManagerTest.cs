﻿#region License
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
using JDT.Calidus.Common;
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.SectionManagers;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.ProjectsTest
{
    [TestFixture]
    public class CalidusProjectManagerTest
    {
        private CalidusProjectManager _manager;
        private IRulesSectionManager _rulesSectionManager;

        private MockRepository _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();
            _rulesSectionManager = _mocker.DynamicMock<IRulesSectionManager>();
            
            _manager = new CalidusProjectManager(_rulesSectionManager);
        }

        [Test]
        public void WriteShouldOnlyAllowWritersWritingUTF8()
        {
            ICalidusProject project = _mocker.StrictMock<ICalidusProject>();

            Stream destination = new MemoryStream();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF32;
            XmlWriter writer = XmlTextWriter.Create(destination, settings);

            Assert.Throws<CalidusException>(delegate
                                                {
                                                    _manager.WriteTo(project, writer);
                                                }, 
                                            "The target XmlWriter must be set to write to UTF8");
        }

        [Test]
        public void WriteShouldOnlyAllowWritersWithWriterSettings()
        {
            MockRepository mocker = new MockRepository();
            ICalidusProject project = mocker.StrictMock<ICalidusProject>();

            Stream destination = new MemoryStream();
            XmlWriter writer = new XmlTextWriter(destination, null);

            Assert.Throws<CalidusException>(delegate
                                            {
                                                _manager.WriteTo(project, writer);
                                            },
                                            "The target XmlWriter must be set to write to UTF8");
        }

        [Test]
        public void WriteToShouldWriteXmlToDestination()
        {
            IRule rule = _mocker.StrictMock<IRule>();

            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            bldr.Append(@"<calidusproject>");
            bldr.Append("<settings>");
            bldr.Append(@"<IgnoreAssemblyFiles>true</IgnoreAssemblyFiles>");
            bldr.Append(@"<IgnoreDesignerFiles>false</IgnoreDesignerFiles>");
            bldr.Append(@"<IgnoreProgramFiles>true</IgnoreProgramFiles>");
            bldr.Append("</settings>");
            bldr.Append("<ignore>");
            bldr.Append(@"<file path=""main\file1.cs"" />");
            bldr.Append(@"<file path=""test\testfile.cs"" />");
            bldr.Append("</ignore>");
            bldr.Append("</calidusproject>");

            IList<String> fileList = new List<String>();
            fileList.Add(@"main\file1.cs");
            fileList.Add(@"test\testfile.cs");

            ICalidusProject project = _mocker.StrictMock<ICalidusProject>();
            Expect.Call(project.IgnoreAssemblyFiles).Return(true).Repeat.Once();
            Expect.Call(project.IgnoreDesignerFiles).Return(false).Repeat.Once();
            Expect.Call(project.IgnoreProgramFiles).Return(true).Repeat.Once();
            Expect.Call(project.IgnoredFiles).Return(fileList).Repeat.Once();

            Expect.Call(project.GetProjectRuleConfigurationOverrides()).Return(new IRuleConfigurationOverride[] {}).Repeat.Once();
            
            _mocker.ReplayAll();

            Stream destination = new MemoryStream();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            XmlWriter writer = XmlTextWriter.Create(destination, settings);

            _manager.WriteTo(project, writer);

            destination.Position = 0;
            StreamReader reader = new StreamReader(destination);

            Assert.AreEqual(bldr.ToString(), reader.ReadToEnd());

            _mocker.VerifyAll();
        }

        [Test]
        public void ReadShouldReadProjectFromXml()
        {
            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            bldr.Append(@"<calidusproject>");
            bldr.Append("<settings>");
            bldr.Append(@"<IgnoreAssemblyFiles>true</IgnoreAssemblyFiles>");
            bldr.Append(@"<IgnoreDesignerFiles>false</IgnoreDesignerFiles>");
            bldr.Append(@"<IgnoreProgramFiles>true</IgnoreProgramFiles>");
            bldr.Append("</settings>");
            bldr.Append("<ignore>");
            bldr.Append(@"<file path=""main\file1.cs"" />");
            bldr.Append(@"<file path=""test\testfile.cs"" />");
            bldr.Append("</ignore>");
            bldr.Append("</calidusproject>");

            IList<String> fileList = new List<String>();
            fileList.Add(@"main\file1.cs");
            fileList.Add(@"test\testfile.cs");

            ICalidusProject expected = _mocker.StrictMock<ICalidusProject>();
            Expect.Call(expected.IgnoreAssemblyFiles).Return(true).Repeat.Once();
            Expect.Call(expected.IgnoreDesignerFiles).Return(false).Repeat.Once();
            Expect.Call(expected.IgnoreProgramFiles).Return(true).Repeat.Once();
            Expect.Call(expected.IgnoredFiles).Return(fileList).Repeat.Once();

            Expect.Call(_rulesSectionManager.ReadFrom(null)).IgnoreArguments().Return(new IRuleConfigurationOverride[]{}).Repeat.Once();

            _mocker.ReplayAll();

            Stream source = new MemoryStream();

            StreamWriter writer = new StreamWriter(source);
            writer.Write(bldr.ToString());
            writer.Flush();
            source.Position = 0;

            ICalidusProject actual = _manager.ReadFrom("test", new XmlTextReader(source));
            Assert.AreEqual(expected.IgnoreAssemblyFiles, actual.IgnoreAssemblyFiles);
            Assert.AreEqual(expected.IgnoreDesignerFiles, actual.IgnoreDesignerFiles);
            Assert.AreEqual(expected.IgnoreProgramFiles, actual.IgnoreProgramFiles);
            CollectionAssert.AreEquivalent(expected.IgnoredFiles, actual.IgnoredFiles);

            _mocker.VerifyAll();
        }

        [Test]
        public void WriteShouldCallRulesSectionManagerToWriteRuleOverrides()
        {
            ICalidusProject project = _mocker.DynamicMock<ICalidusProject>();
            IRuleConfigurationOverride config = _mocker.DynamicMock<IRuleConfigurationOverride>();

            Expect.Call(project.IgnoredFiles).Return(new String[] {}).Repeat.Once();
            Expect.Call(project.GetProjectRuleConfigurationOverrides()).Return(new[] { config }).Repeat.Once();
            Expect.Call(() => _rulesSectionManager.WriteTo(new[] {config}, null)).IgnoreArguments().Repeat.Once();

            _mocker.ReplayAll();

            MemoryStream stream = new MemoryStream();
            XmlWriter writer = XmlTextWriter.Create(stream);
            _manager.WriteTo(project, writer);

            _mocker.VerifyAll();
        }
    }
}
