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
            files.Add(@"C:\src\main\Alpha.cs");
            files.Add(@"C:\src\main\Bravo.cs");
            files.Add(@"C:\src\main\Program.cs");
            files.Add(@"C:\src\main\AssemblyInfo.cs");
            files.Add(@"C:\src\test\Test.Designer.cs");

            ISourceFileProvider provider = _mocker.StrictMock<ISourceFileProvider>();
            Expect.Call(provider.GetFiles()).Return(files).Repeat.Once();

            _project = new CalidusProject(@"C:\src\test.project", provider);

            _mocker.ReplayAll();
        }

        [Test]
        public void ProjectIgnoringAssemblyFilesShouldNotReturnAssemblyFilesInSourcesToValidate()
        {
            _project.IgnoreAssemblyFiles = true;
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"C:\src\main\AssemblyInfo.cs");
            _mocker.VerifyAll();
        }

        [Test]
        public void ProjectIgnoringDesigerFilesShouldNotReturnDesignerFilesinSourcesToValidate()
        {
            _project.IgnoreDesignerFiles = true;
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"C:\src\test\Test.Designer.cs");
            _mocker.VerifyAll();
        }

        [Test]
        public void ProjectIgnoringProgramFilesShouldNotReturnProgramFilesInSourcesToValidate()
        {
            _project.IgnoreProgramFiles = true;
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"C:\src\main\Program.cs");
            _mocker.VerifyAll();
        }

        [Test]
        public void ProjectGetAllSourceFilesShouldReturnIgnoredCsFiles()
        {
            _project.IgnoredFileList.Add(@"\src\main\Bravo.cs");
            CollectionAssert.Contains(_project.GetAllSourceFiles(), @"C:\src\main\Bravo.cs");
            _mocker.VerifyAll();
        }

        [Test]
        public void ProjectGetSourcesToValidateShouldNotReturnIgnoredCsFiles()
        {
            _project.IgnoredFileList.Add(@"\src\main\Bravo.cs");
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"C:\src\main\Bravo.cs");
            _mocker.VerifyAll();
        }

        [Test]
        public void ProjectAddIgnoreFileShouldMakeFileRelative()
        {
            _project.IgnoredFile(@"\src\main\Bravo.cs");
            CollectionAssert.Contains(_project.IgnoredFileList, @"\main\Bravo.cs");
        }
    }
}
