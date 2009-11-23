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
using JDT.Calidus.Common.Projects.Events;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tests;
using JDT.Calidus.UI.Events;
using NUnit.Framework;
using JDT.Calidus.UI.Controllers;
using Rhino.Mocks;
using JDT.Calidus.UI.Views;
using JDT.Calidus.UI.Model;
using JDT.Calidus.Common.Projects;

namespace JDT.Calidus.UITest.Controllers
{
    [TestFixture]
    public class MainControllerTest : CalidusTestBase
    {
        private MainController _controller;

        private IMainView _view;
        private ICalidusProjectModel _projectModel;
        private ICalidusProjectManager _projectManager;
        private IRuleRunner _ruleRunner;
        private IRuleViolationList _violationList;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _view = Mocker.DynamicMock<IMainView>();

            _projectModel = Mocker.DynamicMultiMock<ICalidusProjectModel>();

            _projectManager = Mocker.DynamicMultiMock<ICalidusProjectManager>();
            _ruleRunner = Mocker.DynamicMock<IRuleRunner>();
            _violationList = Mocker.DynamicMultiMock<IRuleViolationList>();
        }

        [Test]
        public void MainControllerShouldSetViewSelectedProjectToProjectFileName()
        {
            IMainView view = Mocker.DynamicMock<IMainView>();
            ICalidusProjectModel projectModel = Mocker.DynamicMultiMock<ICalidusProjectModel>(typeof(ICalidusProject));
            ICalidusProjectManager projectManager = Mocker.DynamicMock<ICalidusProjectManager>();
            IRuleRunner ruleRunner = Mocker.DynamicMock<IRuleRunner>();
            IRuleViolationList violationList = Mocker.DynamicMock<IRuleViolationList>();

            //Expect.Call(view.SelectedProject = @"c:\test.calidus").Repeat.Once();
            Expect.Call(projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Once();

            Mocker.ReplayAll();

            MainController controller = new MainController(view, projectModel, false, projectManager, ruleRunner, violationList);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldConfirmSaveChangedWhenViewOpenCalledWithHasChanges()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.ConfirmSaveChanges()).Return(Confirm.Cancel);

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Open += null, this, EventArgs.Empty);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewOpenProjectFileOnViewOpen()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.OpenProjectFile()).Return(new FileBrowseResult(true, "")).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Open += null, this, EventArgs.Empty);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallSetProjectOnProjectModelOnViewOpen()
        {
            ICalidusProject theProject = Mocker.DynamicMock<ICalidusProject>();

            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(delegate { _projectModel.SetProject(theProject); }).Repeat.Once();
            Expect.Call(_view.OpenProjectFile()).Return(new FileBrowseResult(true, @"c:\test.calidus")).Repeat.Once();
            Expect.Call(_projectManager.ReadFrom("test")).IgnoreArguments().Return(theProject).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Open += null, this, EventArgs.Empty);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewSelectedProjectOnProjectSet()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.SelectedProject = @"c:\test.calidus").Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _projectModel.SetProject(null);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldSetViewProjectHasChangesToFalseOnViewOpen()
        {
            ICalidusProject theProject = Mocker.DynamicMock<ICalidusProject>();

            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.OpenProjectFile()).Return(new FileBrowseResult(true, @"c:\test.calidus")).Repeat.Once();
            Expect.Call(delegate { _view.ProjectHasChanges(false); }).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Open += null, this, EventArgs.Empty);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldSetProjectHasChangesToFalseOnViewSave()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(delegate { _view.ProjectHasChanges(false); }).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Save += null, this, EventArgs.Empty);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewConfirmChangesOnViewQuit()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.ConfirmSaveChanges()).Return(Confirm.Cancel).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Quit += null, this, new QuitEventArgs());

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewShowRuleConfigurationOnRuleConfiguration()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.ShowRuleConfiguration(_projectModel)).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.ShowRuleConfiguration(_projectModel);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewProjectConfigurationOnProjectConfiguration()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.ShowProjectConfiguration(_projectModel)).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.ShowProjectConfiguration(_projectModel);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewBeginWaitOnRunnerStarted()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.BeginWait()).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _ruleRunner.Raise(x => x.Started += null, this, EventArgs.Empty);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldClearViolationListOnRunnerStarted()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _violationList.Clear()).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _ruleRunner.Raise(x => x.Started += null, this, EventArgs.Empty);

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewEndWaitOnRunnerCompleted()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.EndWait()).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _ruleRunner.Raise(x => x.Completed += null, this, new RuleRunnerEventArgs(new List<RuleViolation>()));

            Mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldAddViolationsToViolationListOnRunnerCompleted()
        {
            IList<RuleViolation> vList = new List<RuleViolation>();
            vList.Add(new RuleViolation(null, null, new List<TokenBase>()));

            RuleViolationList expected = new RuleViolationList();
            foreach(RuleViolation v in vList)
                expected.Add(v);

            RuleViolationList actual = new RuleViolationList();

            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, actual);
            _ruleRunner.Raise(x => x.Completed += null, this, new RuleRunnerEventArgs(vList));

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void MainControllerShouldSetViewHasChangesOnProjectChanged()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.ProjectHasChanges(true)).Repeat.Once();

            Mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _projectModel.Raise(x => x.Changed += null, this, EventArgs.Empty);

            Mocker.VerifyAll();
        }
    }
}
