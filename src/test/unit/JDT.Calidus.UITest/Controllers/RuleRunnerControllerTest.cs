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
using System.Linq;
using System.Text;
using JDT.Calidus.Tests;
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
    public class RuleRunnerControllerTest : CalidusTestBase
    {
        private IRuleRunnerView _view;
        private IRuleRunner _runner;
        private ICalidusProjectModel _projectModel;
        private ICalidusRuleConfigurationFactory _configFactory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _view = Mocker.DynamicMock<IRuleRunnerView>();
            _runner = Mocker.DynamicMock<IRuleRunner>();
            _projectModel = Mocker.DynamicMock<ICalidusProjectModel>();
            _configFactory = Mocker.DynamicMock<ICalidusRuleConfigurationFactory>();
        }

        [Test]
        public void RuleRunnerControllerShouldDisplayProgressPercentageOnFileCompleted()
        {
            Expect.Call(() => _view.DisplayProgressPercentage(25)).Repeat.Once();

            Mocker.ReplayAll();

            RuleRunnerController controller = new RuleRunnerController(_view, _runner, _projectModel, _configFactory);
            _runner.Raise(x => x.FileCompleted += null, this, new FileCompletedEventArgs(String.Empty, 1, 4, new List<RuleViolation>()));

            Mocker.VerifyAll();
        }

        [Test]
        public void RuleRunnerControllerShouldStartRunnerOnViewRunnerStart()
        {
            Expect.Call(() => _runner.Run(_configFactory, _projectModel)).Repeat.Once();

            Mocker.ReplayAll();

            RuleRunnerController controller = new RuleRunnerController(_view, _runner, _projectModel, _configFactory);
            _view.Raise(x => x.RuleRunnerStart += null, this, EventArgs.Empty);

            Mocker.VerifyAll();
        }
    }
}
