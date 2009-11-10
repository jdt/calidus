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
    public class MainControllerTest
    {
        private MainController _controller;
        private MockRepository _mocker;

        private IMainView _view;
        private ICalidusProjectModel _projectModel;
        private ICalidusProjectManager _projectManager;
        private IRuleRunner _ruleRunner;
        private IRuleViolationList _violationList;

        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();

            _view = _mocker.DynamicMock<IMainView>();

            _projectModel = _mocker.DynamicMultiMock<ICalidusProjectModel>();

            _projectManager = _mocker.DynamicMultiMock<ICalidusProjectManager>();
            _ruleRunner = _mocker.DynamicMock<IRuleRunner>();
            _violationList = _mocker.DynamicMultiMock<IRuleViolationList>();
        }

        [Test]
        public void MainControllerShouldSetViewSelectedProjectToProjectFileName()
        {
            IMainView view = _mocker.DynamicMock<IMainView>();
            ICalidusProjectModel projectModel = _mocker.DynamicMultiMock<ICalidusProjectModel>(typeof(ICalidusProject));
            ICalidusProjectManager projectManager = _mocker.DynamicMock<ICalidusProjectManager>();
            IRuleRunner ruleRunner = _mocker.DynamicMock<IRuleRunner>();
            IRuleViolationList violationList = _mocker.DynamicMock<IRuleViolationList>();

            //Expect.Call(view.SelectedProject = @"c:\test.calidus").Repeat.Once();
            Expect.Call(projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Once();

            _mocker.ReplayAll();

            MainController controller = new MainController(view, projectModel, false, projectManager, ruleRunner, violationList);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldConfirmSaveChangedWhenViewOpenCalledWithHasChanges()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.ConfirmSaveChanges()).Return(Confirm.Cancel);

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Open += null, this, EventArgs.Empty);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewOpenProjectFileOnViewOpen()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.OpenProjectFile()).Return(new FileBrowseResult(true, "")).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Open += null, this, EventArgs.Empty);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallSetProjectOnProjectModelOnViewOpen()
        {
            ICalidusProject theProject = _mocker.DynamicMock<ICalidusProject>();

            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(delegate { _projectModel.SetProject(theProject); }).Repeat.Once();
            Expect.Call(_view.OpenProjectFile()).Return(new FileBrowseResult(true, @"c:\test.calidus")).Repeat.Once();
            Expect.Call(_projectManager.ReadFrom("test")).IgnoreArguments().Return(theProject).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Open += null, this, EventArgs.Empty);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewSelectedProjectOnProjectSet()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.SelectedProject = @"c:\test.calidus").Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _projectModel.SetProject(null);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldSetViewProjectHasChangesToFalseOnViewOpen()
        {
            ICalidusProject theProject = _mocker.DynamicMock<ICalidusProject>();

            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.OpenProjectFile()).Return(new FileBrowseResult(true, @"c:\test.calidus")).Repeat.Once();
            Expect.Call(delegate { _view.ProjectHasChanges(false); }).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Open += null, this, EventArgs.Empty);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldSetProjectHasChangesToFalseOnViewSave()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(delegate { _view.ProjectHasChanges(false); }).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Save += null, this, EventArgs.Empty);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewConfirmChangesOnViewQuit()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(_view.ConfirmSaveChanges()).Return(Confirm.Cancel).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.Raise(x => x.Quit += null, this, new QuitEventArgs());

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewShowRuleConfigurationOnRuleConfiguration()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.ShowRuleConfiguration(_projectModel)).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.ShowRuleConfiguration(_projectModel);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewProjectConfigurationOnProjectConfiguration()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.ShowProjectConfiguration(_projectModel)).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _view.ShowProjectConfiguration(_projectModel);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewBeginWaitOnRunnerStarted()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.BeginWait()).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _ruleRunner.Raise(x => x.Started += null, this, EventArgs.Empty);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldClearViolationListOnRunnerStarted()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _violationList.Clear()).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _ruleRunner.Raise(x => x.Started += null, this, EventArgs.Empty);

            _mocker.VerifyAll();
        }

        [Test]
        public void MainControllerShouldCallViewEndWaitOnRunnerCompleted()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.EndWait()).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _ruleRunner.Raise(x => x.Completed += null, this, new RuleRunnerEventArgs(new List<RuleViolation>()));

            _mocker.VerifyAll();
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

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, actual);
            _ruleRunner.Raise(x => x.Completed += null, this, new RuleRunnerEventArgs(vList));

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void MainControllerShouldSetViewHasChangesOnProjectChanged()
        {
            Expect.Call(_projectModel.GetProjectFile()).Return(@"c:\test.calidus").Repeat.Times(1);
            Expect.Call(() => _view.ProjectHasChanges(true)).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new MainController(_view, _projectModel, true, _projectManager, _ruleRunner, _violationList);
            _projectModel.Raise(x => x.Changed += null, this, EventArgs.Empty);

            _mocker.VerifyAll();
        }
    }
}
