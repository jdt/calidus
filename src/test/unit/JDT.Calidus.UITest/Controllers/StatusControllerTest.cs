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
using JDT.Calidus.Tests;
using NUnit.Framework;
using JDT.Calidus.UI.Controllers;
using Rhino.Mocks;
using JDT.Calidus.UI.Views;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UITest.Controllers
{
    [TestFixture]
    public class StatusControllerTest : CalidusTestBase
    {
        private IStatusView _view;
        private IRuleViolationList _list;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _view = Mocker.DynamicMock<IStatusView>();
            _list = Mocker.DynamicMock<IRuleViolationList>();
        }

        [Test]
        public void StatusControllerShouldDisplayViolationListViolationCount()
        {
            IStatusView view = Mocker.DynamicMock<IStatusView>();
            IRuleViolationList list = Mocker.DynamicMock<IRuleViolationList>();

            Expect.Call(list.Count).Return(0).Repeat.Once();

            Mocker.ReplayAll();

            StatusController controller = new StatusController(view, list);

            Mocker.VerifyAll();
        }

        [Test]
        public void StatusControllerShouldUpdateViolationCountOnListRemove()
        {
            Expect.Call(_list.Count).Return(0).Repeat.Once();
            Expect.Call(_list.Count).Return(1).Repeat.Once();
            Expect.Call(() => _view.DisplayViolationCount(0)).Repeat.Once();
            Expect.Call(() => _view.DisplayViolationCount(1)).Repeat.Once();

            Mocker.ReplayAll();

            StatusController controller = new StatusController(_view, _list);
            _list.Raise(x => x.ViolationAdded += null, this, new RuleViolationEventArgs(null));

            Mocker.VerifyAll();
        }

        [Test]
        public void StatusControllerShouldUpdateViolationCountOnListAdd()
        {
            Expect.Call(_list.Count).Return(4).Repeat.Once();
            Expect.Call(_list.Count).Return(3).Repeat.Once();
            Expect.Call(() => _view.DisplayViolationCount(4)).Repeat.Once();
            Expect.Call(() => _view.DisplayViolationCount(3)).Repeat.Once();

            Mocker.ReplayAll();

            StatusController controller = new StatusController(_view, _list);
            _list.Raise(x => x.ViolationRemoved += null, this, new RuleViolationEventArgs(null));

            Mocker.VerifyAll();
        }
    }
}
