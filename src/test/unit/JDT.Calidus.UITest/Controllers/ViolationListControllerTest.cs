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
using Rhino.Mocks;
using JDT.Calidus.UI.Controllers;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.UI.Events;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.UI.Commands;

namespace JDT.Calidus.UITest.Controllers
{
    [TestFixture]
    public class ViolationListControllerTest
    {
        private MockRepository _mocker;

        private ViolationListController _controller;
        private IViolationListView _view;
        private ICalidusProjectModel _projectModel;
        private IRuleViolationList _violationList;

        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();

            _view = _mocker.DynamicMock<IViolationListView>();
            _projectModel = _mocker.DynamicMock<ICalidusProjectModel>();
            _violationList = _mocker.DynamicMock<IRuleViolationList>();
        }

        [Test]
        public void ViolationListControllerShouldAddViolationToViewWhenViolationListViolationAdded()
        {
            RuleViolation violation = new RuleViolation(String.Empty, null, new List<TokenBase>());

            Expect.Call(() => _view.AddViolation(violation)).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new ViolationListController(_view, _projectModel, _violationList);
            _violationList.Raise(x => x.ViolationAdded += null, this, new RuleViolationEventArgs(violation));

            _mocker.VerifyAll();
        }

        [Test]
        public void ViolationListControllerShouldRemoveViolationFromViewWhenViolationListViolationRemoved()
        {
            RuleViolation violation = new RuleViolation(String.Empty, null, new List<TokenBase>());

            Expect.Call(() => _view.RemoveViolation(violation)).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new ViolationListController(_view, _projectModel, _violationList);
            _violationList.Raise(x => x.ViolationRemoved += null, this, new RuleViolationEventArgs(violation));

            _mocker.VerifyAll();
        }


        [Test]
        public void ViolationListControllerShouldIgnoreFileAndRemoveViolationsFromViolationListOnViewIgnoreViolationFile()
        {
            RuleViolation violation = new RuleViolation("file.cs", null, new List<TokenBase>());

            Expect.Call(() => _projectModel.IgnoredFile("file.cs")).Repeat.Once();

            _mocker.ReplayAll();

            _controller = new ViolationListController(_view, _projectModel, _violationList);
            _view.Raise(x => x.IgnoreViolation += null, this, new RuleViolationIgnoreCommandEventArgs(violation, RuleViolationIgnoreType.File));

            _mocker.VerifyAll();
        }
    }
}
