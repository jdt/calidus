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
using NUnit.Framework;
using JDT.Calidus.UI.Controllers;
using Rhino.Mocks;
using JDT.Calidus.UI.Views;
using JDT.Calidus.Common.Projects;
using JDT.Calidus.UI.Model;
using JDT.Calidus.Common.Projects.Events;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.UITest.Controllers
{
    [TestFixture]
    public class RuleRunnerControllerTest
    {
        private MockRepository _mocker;

        private IRuleRunnerView _view;
        private IRuleRunner _runner;
        private ICalidusProjectModel _projectModel;

        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();

            _view = _mocker.DynamicMock<IRuleRunnerView>();
            _runner = _mocker.DynamicMock<IRuleRunner>();
            _projectModel = _mocker.DynamicMock<ICalidusProjectModel>();
        }

        [Test]
        public void RuleRunnerControllerShouldDisplayProgressPercentageOnFileCompleted()
        {
            Expect.Call(() => _view.DisplayProgressPercentage(25)).Repeat.Once();

            _mocker.ReplayAll();

            RuleRunnerController controller = new RuleRunnerController(_view, _runner, _projectModel);
            _runner.Raise(x => x.FileCompleted += null, this, new FileCompletedEventArgs(String.Empty, 1, 4, new List<RuleViolation>()));

            _mocker.VerifyAll();
        }

        [Test]
        public void RuleRunnerControllerShouldStartRunnerOnViewRunnerStart()
        {
            Expect.Call(() => _runner.Run(_projectModel)).Repeat.Once();

            _mocker.ReplayAll();

            RuleRunnerController controller = new RuleRunnerController(_view, _runner, _projectModel);
            _view.Raise(x => x.RuleRunnerStart += null, this, EventArgs.Empty);

            _mocker.VerifyAll();
        }
    }
}
