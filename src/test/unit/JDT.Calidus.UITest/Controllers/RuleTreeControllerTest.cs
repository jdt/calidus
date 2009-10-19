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
using JDT.Calidus.UI.Views;
using JDT.Calidus.Common.Rules;
using Rhino.Mocks;

namespace JDT.Calidus.UITest.Controllers
{
    [TestFixture]
    public class RuleTreeControllerTest
    {
        [Test]
        public void RuleTreeControllerShouldDisplayRulesFromRuleProvider()
        {
            MockRepository mocker = new MockRepository();

            IRule rule = mocker.DynamicMock<IRule>();
            IRuleTreeView view = mocker.DynamicMock<IRuleTreeView>();
            ICalidusRuleProvider ruleProvider = mocker.DynamicMock<ICalidusRuleProvider>();

            IList<IRule> rules = new List<IRule>();
            rules.Add(rule);

            Expect.Call(() => view.DisplayRules(rules)).Repeat.Once();
            Expect.Call(ruleProvider.GetRules()).Return(rules).Repeat.Once();

            mocker.ReplayAll();

            RuleTreeController controller = new RuleTreeController(view, ruleProvider);

            mocker.VerifyAll();
        }
    }
}
