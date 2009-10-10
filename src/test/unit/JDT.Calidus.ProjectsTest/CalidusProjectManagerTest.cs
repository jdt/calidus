using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Projects;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.ProjectsTest
{
    [TestFixture]
    public class CalidusProjectManagerTest
    {
        private CalidusProjectManager _manager;

        [SetUp]
        public void SetUp()
        {
            _manager = new CalidusProjectManager();
        }

        [Test]
        public void WriteShouldOnlyAllowWritersWritingUTF8()
        {
            MockRepository mocker = new MockRepository();
            ICalidusProject project = mocker.StrictMock<ICalidusProject>();

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
            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            bldr.Append(@"<calidusproject sourcelocation=""path\to\src\"">");
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

            MockRepository mocker = new MockRepository();
            ICalidusProject project = mocker.StrictMock<ICalidusProject>();
            Expect.Call(project.SourceLocation).Return(@"path\to\src\").Repeat.Once();
            Expect.Call(project.IgnoreAssemblyFiles).Return(true).Repeat.Once();
            Expect.Call(project.IgnoreDesignerFiles).Return(false).Repeat.Once();
            Expect.Call(project.IgnoreProgramFiles).Return(true).Repeat.Once();
            Expect.Call(project.IgnoredFiles).Return(fileList).Repeat.Once();

            mocker.ReplayAll();

            Stream destination = new MemoryStream();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            XmlWriter writer = XmlTextWriter.Create(destination, settings);

            _manager.WriteTo(project, writer);

            destination.Position = 0;
            StreamReader reader = new StreamReader(destination);

            Assert.AreEqual(bldr.ToString(), reader.ReadToEnd());

            mocker.VerifyAll();
        }

        [Test]
        public void ReadShouldReadProjectFromXml()
        {
            StringBuilder bldr = new StringBuilder();
            bldr.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            bldr.Append(@"<calidusproject sourcelocation=""path\to\src\"">");
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
            
            MockRepository mocker = new MockRepository();
            ICalidusProject expected = mocker.StrictMock<ICalidusProject>();
            Expect.Call(expected.SourceLocation).Return(@"path\to\src\").Repeat.Once();
            Expect.Call(expected.IgnoreAssemblyFiles).Return(true).Repeat.Once();
            Expect.Call(expected.IgnoreDesignerFiles).Return(false).Repeat.Once();
            Expect.Call(expected.IgnoreProgramFiles).Return(true).Repeat.Once();
            Expect.Call(expected.IgnoredFiles).Return(fileList).Repeat.Once();

            mocker.ReplayAll();

            Stream source = new MemoryStream();

            StreamWriter writer = new StreamWriter(source);
            writer.Write(bldr.ToString());
            writer.Flush();
            source.Position = 0;

            ICalidusProject actual = _manager.ReadFrom(new XmlTextReader(source));
            Assert.AreEqual(null, actual.Name);
            Assert.AreEqual(expected.SourceLocation, actual.SourceLocation);
            Assert.AreEqual(expected.IgnoreAssemblyFiles, actual.IgnoreAssemblyFiles);
            Assert.AreEqual(expected.IgnoreDesignerFiles, actual.IgnoreDesignerFiles);
            Assert.AreEqual(expected.IgnoreProgramFiles, actual.IgnoreProgramFiles);
            CollectionAssert.AreEquivalent(expected.IgnoredFiles, actual.IgnoredFiles);
        }
    }
}
