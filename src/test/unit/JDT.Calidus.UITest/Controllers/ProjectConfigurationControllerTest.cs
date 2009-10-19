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
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UITest.Controllers
{
    [TestFixture]
    public class ProjectConfigurationControllerTest
    {
        private MockRepository _mocker;
        private IProjectConfigurationView _view;
        private ICalidusProjectModel _model;

        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();

            _view = _mocker.DynamicMock<IProjectConfigurationView>();
            _model = _mocker.DynamicMock<ICalidusProjectModel>();

            Expect.Call(_model.IgnoreAssemblyFiles).Return(true).Repeat.Once();
            Expect.Call(_model.IgnoreDesignerFiles).Return(true).Repeat.Once();
            Expect.Call(_model.IgnoreProgramFiles).Return(true).Repeat.Once();

            Expect.Call(_view.IgnoreAssemblyFiles = true).Repeat.Once();
            Expect.Call(_view.IgnoreDesignerFiles = true).Repeat.Once();
            Expect.Call(_view.IgnoreProgramFiles = true).Repeat.Once();
        }

        [Test]
        public void ProjectConfigurationControllerShouldSetViewIgnore()
        {
            MockRepository mocker = new MockRepository();

            IProjectConfigurationView view = mocker.DynamicMock<IProjectConfigurationView>();
            ICalidusProjectModel model = mocker.DynamicMock<ICalidusProjectModel>();

            Expect.Call(model.IgnoreAssemblyFiles).Return(true).Repeat.Once();
            Expect.Call(model.IgnoreDesignerFiles).Return(true).Repeat.Once();
            Expect.Call(model.IgnoreProgramFiles).Return(true).Repeat.Once();

            Expect.Call(view.IgnoreAssemblyFiles = true).Repeat.Once();
            Expect.Call(view.IgnoreDesignerFiles = true).Repeat.Once();
            Expect.Call(view.IgnoreProgramFiles = true).Repeat.Once();

            mocker.ReplayAll();

            ProjectConfigurationController controller = new ProjectConfigurationController(view, model);

            mocker.VerifyAll();
        }

        [Test]
        public void ProjectConfigurationControllerShouldSetModelIgnoreProgramFilesChangedOnViewIgnoreProgramFilesChanged()
        {
            bool value = true;
            Expect.Call(_model.IgnoreProgramFiles = value).Repeat.Once();

            _mocker.ReplayAll();

            ProjectConfigurationController controller = new ProjectConfigurationController(_view, _model);
            _view.Raise(x => x.IgnoreProgramFilesChanged += null, this, new CheckedEventArgs(value));

            _mocker.VerifyAll();
        }

        [Test]
        public void ProjectConfigurationControllerShouldSetModelIgnoreDesignerFilesChangedOnViewIgnoreDesignerFilesChanged()
        {
            bool value = true;
            Expect.Call(_model.IgnoreDesignerFiles = value).Repeat.Once();

            _mocker.ReplayAll();

            ProjectConfigurationController controller = new ProjectConfigurationController(_view, _model);
            _view.Raise(x => x.IgnoreDesignerFilesChanged += null, this, new CheckedEventArgs(value));

            _mocker.VerifyAll();
        }

        [Test]
        public void ProjectConfigurationControllerShouldSetModelIgnorePAssemblyFilesChangedOnViewIgnoreAssemblyFilesChanged()
        {
            bool value = true;
            Expect.Call(_model.IgnoreAssemblyFiles = value).Repeat.Once();

            _mocker.ReplayAll();

            ProjectConfigurationController controller = new ProjectConfigurationController(_view, _model);
            _view.Raise(x => x.IgnoreAssemblyFilesChanged += null, this, new CheckedEventArgs(value));

            _mocker.VerifyAll();
        }
    }
}
