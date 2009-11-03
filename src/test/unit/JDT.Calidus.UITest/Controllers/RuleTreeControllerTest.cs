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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.UI.Events;
using NUnit.Framework;
using JDT.Calidus.UI.Controllers;
using JDT.Calidus.UI.Views;
using JDT.Calidus.Common.Rules;
using Rhino.Mocks;

namespace JDT.Calidus.UITest.Controllers
{
    public class TreeViewImp : IRuleTreeView
    {
        private IList<IRule> _expected;

        public TreeViewImp(IList<IRule> expected)
        {
            _expected = expected;

            BeforeRuleSelectionChanged += new EventHandler<RuleChangeCancelEventArgs>(TreeViewImp_BeforeRuleSelectionChanged);
            RuleSelectionChanged += new EventHandler<RuleEventArgs>(TreeViewImp_RuleSelectionChanged);
        }

        private void TreeViewImp_BeforeRuleSelectionChanged(object sender, RuleChangeCancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TreeViewImp_RuleSelectionChanged(object sender, RuleEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DisplayRules(IEnumerable<IRule> rules)
        {
            CollectionAssert.AreEquivalent(_expected, rules);
        }

        public event EventHandler<RuleEventArgs> RuleSelectionChanged;
        public event EventHandler<RuleChangeCancelEventArgs> BeforeRuleSelectionChanged;
    }

    [TestFixture]
    public class RuleTreeControllerTest
    {
        [Test]
        public void RuleTreeControllerShouldDisplayRulesAlphabeticallyFromRuleProvider()
        {
            MockRepository mocker = new MockRepository();

            IRule ruleAlpha = mocker.DynamicMock<IRule>();
            IRule ruleBravo = mocker.DynamicMock<IRule>();

            IList<IRule> rules = new List<IRule>();
            rules.Add(ruleBravo);
            rules.Add(ruleAlpha);

            IList<IRule> rulesSorted = new List<IRule>();
            rulesSorted.Add(rules[1]);
            rulesSorted.Add(rules[0]);

            TreeViewImp view = new TreeViewImp(rulesSorted);
            ICalidusRuleProvider ruleProvider = mocker.DynamicMock<ICalidusRuleProvider>();

            Expect.Call(ruleAlpha.Category).Return("Alpha").Repeat.Any();
            Expect.Call(ruleBravo.Category).Return("Bravo").Repeat.Any();

            Expect.Call(ruleProvider.GetRules()).Return(rules).Repeat.Once();
            Expect.Call(() => view.DisplayRules(rulesSorted)).Repeat.Once();
            
            mocker.ReplayAll();

            RuleTreeController controller = new RuleTreeController(view, ruleProvider);

            mocker.VerifyAll();
        }
    }
}
