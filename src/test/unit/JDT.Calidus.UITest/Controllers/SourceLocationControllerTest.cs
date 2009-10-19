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
using JDT.Calidus.UI.Views;
using JDT.Calidus.UI.Model;

namespace JDT.Calidus.UITest.Controllers
{
    [TestFixture]
    public class SourceLocationControllerTest
    {
        [Test]
        public void SourceLocationControllerShouldDisplayProjectFileLocation()
        {
            MockRepository mocker = new MockRepository();

            ISourceLocationView view = mocker.DynamicMock<ISourceLocationView>();
            ICalidusProjectModel model = mocker.DynamicMock<ICalidusProjectModel>();

            Expect.Call(model.GetProjectFile()).Return("test.calidus").Repeat.Once();
            Expect.Call(() => view.DisplayProjectFileLocation("test.calidus")).Repeat.Once();

            mocker.ReplayAll();

            SourceLocationController controller = new SourceLocationController(view, model);

            mocker.VerifyAll();
        }
    }
}
