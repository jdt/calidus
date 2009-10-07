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
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Providers;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.ProjectsTest
{
    [TestFixture]
    public class CalidusProjectTest
    {
        private CalidusProject _project;
        
        private MockRepository _mocker;
        
        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();

            IList<String> files = new List<String>();
            files.Add(@"c:\src\main\Alpha.cs");
            files.Add(@"c:\src\main\Bravo.cs");
            files.Add(@"c:\src\main\Program.cs");
            files.Add(@"c:\src\main\AssemblyInfo.cs");
            files.Add(@"c:\src\test\Test.Designer.cs");

            ISourceFileProvider provider = _mocker.StrictMock<ISourceFileProvider>();
            Expect.Call(provider.GetFiles()).Return(files).Repeat.Once();

            _project = new CalidusProject("TestProject", provider);

            _mocker.ReplayAll();
        }

        [TearDown]
        public void TearDown()
        {
            _mocker.VerifyAll();
        }

        [Test]
        public void ProjectIgnoringAssemblyFilesShouldNotReturnAssemblyFilesInSourcesToValidate()
        {
            _project.IgnoreAssemblyFiles = true;
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"c:\src\main\AssemblyInfo.cs");
        }

        [Test]
        public void ProjectIgnoringDesigerFilesShouldNotReturnDesignerFilesinSourcesToValidate()
        {
            _project.IgnoreDesignerFiles = true;
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"c:\src\test\Test.Designer.cs");
        }

        [Test]
        public void ProjectIgnoringProgramFilesShouldNotReturnProgramFilesInSourcesToValidate()
        {
            _project.IgnoreProgramFiles = true;
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"c:\src\main\Program.cs");
        }

        [Test]
        public void ProjectGetAllSourceFilesShouldReturnIgnoredCsFiles()
        {
            _project.IgnoredFiles.Add(@"\src\main\Bravo.cs");
            CollectionAssert.Contains(_project.GetAllSourceFiles(), @"c:\src\main\Bravo.cs");
        }

        [Test]
        public void ProjectGetSourcesToValidateShouldNotReturnIgnoredCsFiles()
        {
            _project.IgnoredFiles.Add(@"\src\main\Bravo.cs");
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"c:\src\main\Bravo.cs");
        }
    }
}
