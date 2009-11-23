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
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Providers;
using JDT.Calidus.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.ProjectsTest
{
    [TestFixture]
    public class CalidusProjectTest : CalidusTestBase
    {
        private ISourceFileProvider _provider;
        private CalidusProject _project;
        private IList<String> _files;
        
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _provider = Mocker.DynamicMock<ISourceFileProvider>();

            _files = new List<String>();
            _files.Add(@"C:\src\main\Alpha.cs");
            _files.Add(@"C:\src\main\Bravo.cs");
            _files.Add(@"C:\src\main\Program.cs");
            _files.Add(@"C:\src\main\AssemblyInfo.cs");
            _files.Add(@"C:\src\test\Test.Designer.cs");
        }

        [Test]
        public void ProjectIgnoringAssemblyFilesShouldNotReturnAssemblyFilesInSourcesToValidate()
        {
            _project = new CalidusProject(@"C:\src\test.project", _provider);

            Expect.Call(_provider.GetFiles()).Return(_files).Repeat.Once();

            Mocker.ReplayAll();

            _project.IgnoreAssemblyFiles = true;
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"C:\src\main\AssemblyInfo.cs");
            Mocker.VerifyAll();
        }

        [Test]
        public void ProjectIgnoringDesigerFilesShouldNotReturnDesignerFilesinSourcesToValidate()
        {
            _project = new CalidusProject(@"C:\src\test.project", _provider);

            Expect.Call(_provider.GetFiles()).Return(_files).Repeat.Once();

            Mocker.ReplayAll();

            _project.IgnoreDesignerFiles = true;
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"C:\src\test\Test.Designer.cs");
            
            Mocker.VerifyAll();
        }

        [Test]
        public void ProjectIgnoringProgramFilesShouldNotReturnProgramFilesInSourcesToValidate()
        {
            _project = new CalidusProject(@"C:\src\test.project", _provider);

            Expect.Call(_provider.GetFiles()).Return(_files).Repeat.Once();

            Mocker.ReplayAll();

            _project.IgnoreProgramFiles = true;
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"C:\src\main\Program.cs");
            
            Mocker.VerifyAll();
        }

        [Test]
        public void ProjectGetAllSourceFilesShouldReturnIgnoredCsFiles()
        {
            _project = new CalidusProject(@"C:\src\test.project", _provider);

            Expect.Call(_provider.GetFiles()).Return(_files).Repeat.Once();

            Mocker.ReplayAll();

            _project.IgnoredFileList.Add(@"\src\main\Bravo.cs");
            CollectionAssert.Contains(_project.GetAllSourceFiles(), @"C:\src\main\Bravo.cs");
            
            Mocker.VerifyAll();
        }

        [Test]
        public void ProjectGetSourcesToValidateShouldNotReturnIgnoredCsFiles()
        {
            _project = new CalidusProject(@"C:\src\test.project", _provider);

            Expect.Call(_provider.GetFiles()).Return(_files).Repeat.Once();

            Mocker.ReplayAll();

            _project.IgnoredFileList.Add(@"\src\main\Bravo.cs");
            CollectionAssert.DoesNotContain(_project.GetSourceFilesToValidate(), @"C:\src\main\Bravo.cs");
            
            Mocker.VerifyAll();
        }

        [Test]
        public void ProjectAddIgnoreFileShouldMakeFileRelative()
        {
            _project = new CalidusProject(@"C:\src\test.project", _provider);

            Mocker.ReplayAll();

            _project.IgnoredFile(@"\src\main\Bravo.cs");
            CollectionAssert.Contains(_project.IgnoredFileList, @"\main\Bravo.cs");

            Mocker.VerifyAll();
        }

        [Test]
        public void ProjectSetProjectRuleConfigurationOverrideShouldAddOverrides()
        {
            _project = new CalidusProject(@"C:\src\test.project", _provider);
            //need to make sure to have different rule types
            StatementRuleBase ruleOne = Mocker.DynamicMock<StatementRuleBase>("test");
            BlockRuleBase ruleTwo = Mocker.DynamicMock<BlockRuleBase>("test");

            IRuleConfigurationOverride one = Mocker.DynamicMock<IRuleConfigurationOverride>();
            IRuleConfigurationOverride two = Mocker.DynamicMock<IRuleConfigurationOverride>();

            Expect.Call(one.Rule).Return(ruleOne.GetType()).Repeat.Once();
            Expect.Call(two.Rule).Return(ruleTwo.GetType()).Repeat.Once();

            Mocker.ReplayAll();

            Assert.AreEqual(0, _project.GetProjectRuleConfigurationOverrides().Count());
            _project.SetProjectRuleConfigurationOverrideTo(one);
            Assert.AreEqual(1, _project.GetProjectRuleConfigurationOverrides().Count());
            _project.SetProjectRuleConfigurationOverrideTo(two);
            Assert.AreEqual(2, _project.GetProjectRuleConfigurationOverrides().Count());
            
            Mocker.VerifyAll();
        }

        [Test]
        public void ProjectSetProjectRuleConfigurationOverrideShouldReplaceExisting()
        {
            _project = new CalidusProject(@"C:\src\test.project", _provider);

            IRule rule = Mocker.DynamicMock<IRule>();
            IRuleConfigurationOverride one = Mocker.DynamicMock<IRuleConfigurationOverride>();

            Expect.Call(one.Rule).Return(rule.GetType()).Repeat.Twice();

            Mocker.ReplayAll();

            _project.SetProjectRuleConfigurationOverrideTo(one);
            Assert.AreEqual(1, _project.GetProjectRuleConfigurationOverrides().Count());
            _project.SetProjectRuleConfigurationOverrideTo(one);
            Assert.AreEqual(1, _project.GetProjectRuleConfigurationOverrides().Count());

            Mocker.VerifyAll();
        }
    }
}
