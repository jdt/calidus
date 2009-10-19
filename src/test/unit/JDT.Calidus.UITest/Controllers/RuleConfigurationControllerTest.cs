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
using JDT.Calidus.Common.Rules;
using JDT.Calidus.UI.Views;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.UI.Events;
using JDT.Calidus.Common.Rules.Configuration.Factories;
using JDT.Calidus.UI.Commands;

namespace JDT.Calidus.UITest.Controllers
{
    [TestFixture]
    public class RuleConfigurationControllerTest
    {
        private MockRepository _mocker;

        private IRuleTreeView _ruleTreeView;
        private IRuleConfigurationView _view;
        private ICalidusRuleProvider _provider;

        [SetUp]
        public void SetUp()
        {
            _mocker = new MockRepository();

            _ruleTreeView = _mocker.DynamicMock<IRuleTreeView>();
            _view = _mocker.DynamicMock<IRuleConfigurationView>();
            _provider = _mocker.DynamicMock<ICalidusRuleProvider>();

            Expect.Call(_view.RuleTreeView).Return(_ruleTreeView).Repeat.Any();
        }

        [Test]
        public void RuleConfigurationControllerShouldDisplayRules()
        {
            MockRepository mocker = new MockRepository();

            IRuleTreeView ruleTreeView = mocker.DynamicMock<IRuleTreeView>();
            IRuleConfigurationView view = mocker.DynamicMock<IRuleConfigurationView>();
            ICalidusRuleProvider provider = mocker.DynamicMock<ICalidusRuleProvider>();

            Expect.Call(view.RuleTreeView).Return(ruleTreeView).Repeat.Any();
            Expect.Call(() => view.DisplayRules(new List<IRule>())).Repeat.Once();
            Expect.Call(provider.GetRules()).Return(new List<IRule>()).Repeat.Once();

            mocker.ReplayAll();

            RuleConfigurationController controller = new RuleConfigurationController(view, provider);

            mocker.VerifyAll();
        }

        [Test]
        public void RuleConfigurationControllerShouldDisplayRuleConfigurationParameterOnSelectedRuleParameterChanged()
        {
            IRuleConfigurationParameter config = _mocker.DynamicMock<IRuleConfigurationParameter>();

            Expect.Call(() => _view.DisplayRuleConfigurationParameter(config)).Repeat.Once();
            
            _mocker.ReplayAll();

            RuleConfigurationController controller = new RuleConfigurationController(_view, _provider);
            _view.Raise(x => x.SelectedRuleParameterChanged += null, this, new RuleConfigurationParameterEventArgs(config));

            _mocker.VerifyAll();
        }

        [Test]
        public void RuleConfigurationControllerShouldNotDisplayRuleConfigurationParameterOnSelectedRuleParameterChangedIfParameterIsNull()
        {
            IRuleConfigurationParameter config = _mocker.DynamicMock<IRuleConfigurationParameter>();

            Expect.Call(() => _view.DisplayRuleConfigurationParameter(config)).Repeat.Never();
            
            _mocker.ReplayAll();

            RuleConfigurationController controller = new RuleConfigurationController(_view, _provider);
            _view.Raise(x => x.SelectedRuleParameterChanged += null, this, new RuleConfigurationParameterEventArgs(null));

            _mocker.VerifyAll();
        }

        [Test]
        public void RuleConfigurationControllerShouldNotCancelBeforeSelectionChangedIfNoChanges()
        {
            RuleChangeCancelEventArgs cancelArgs = new RuleChangeCancelEventArgs();

            _mocker.ReplayAll();

            RuleConfigurationController controller = new RuleConfigurationController(_view, _provider);
            _view.RuleTreeView.Raise(x => x.BeforeRuleSelectionChanged += null, this, cancelArgs);

            Assert.IsFalse(cancelArgs.Cancel);
            _mocker.VerifyAll();
        }

        [Test]
        public void RuleConfigurationControllerShouldNotCancelBeforeSelectionChangedIfConfirmed()
        {
            RuleChangeCancelEventArgs cancelArgs = new RuleChangeCancelEventArgs();

            Expect.Call(_view.ConfirmRuleSelectionChanged()).Return(true);

            _mocker.ReplayAll();

            RuleConfigurationController controller = new RuleConfigurationController(_view, _provider);
            //set changes
            _view.Raise(x => x.RuleParameterSettingsChanged += null, this, EventArgs.Empty);
            _view.RuleTreeView.Raise(x => x.BeforeRuleSelectionChanged += null, this, cancelArgs);

            Assert.IsFalse(cancelArgs.Cancel);
            _mocker.VerifyAll();
        }

        [Test]
        public void RuleConfigurationControllerShouldCancelIfChangesAndNotConfirmed()
        {
            RuleChangeCancelEventArgs cancelArgs = new RuleChangeCancelEventArgs();

            Expect.Call(_view.ConfirmRuleSelectionChanged()).Return(false);

            _mocker.ReplayAll();

            RuleConfigurationController controller = new RuleConfigurationController(_view, _provider);
            //set changes
            _view.Raise(x => x.RuleParameterSettingsChanged += null, this, EventArgs.Empty);
            _view.RuleTreeView.Raise(x => x.BeforeRuleSelectionChanged += null, this, cancelArgs);

            Assert.IsTrue(cancelArgs.Cancel);
            _mocker.VerifyAll();
        }

        [Test]
        public void RuleConfigurationControllerShouldGetAndDisplayRuleConfigurationOnRuleSelectionChanged()
        {
            IRule rule = _mocker.DynamicMock<IRule>();
            IRuleConfiguration ruleConfig = _mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory fct = _mocker.DynamicMock<IRuleConfigurationFactory>();

            Expect.Call(_provider.GetConfigurationFactoryFor(null)).IgnoreArguments().Return(fct).Repeat.Once();
            Expect.Call(fct.Get(null)).IgnoreArguments().Return(ruleConfig).Repeat.Once();
            Expect.Call(() => _view.DisplayRuleConfiguration(ruleConfig)).Repeat.Once();

            _mocker.ReplayAll();

            RuleConfigurationController controller = new RuleConfigurationController(_view, _provider);
            _view.RuleTreeView.Raise(x => x.RuleSelectionChanged += null, this, new RuleEventArgs(rule));

            _mocker.VerifyAll();
        }

        [Test]
        public void RuleConfigurationControllerClearRuleConfigurationOnRuleSelectionChangedWithNullRule()
        {
            Expect.Call(() => _view.ClearRuleConfiguration()).Repeat.Once();

            _mocker.ReplayAll();

            RuleConfigurationController controller = new RuleConfigurationController(_view, _provider);
            _view.RuleTreeView.Raise(x => x.RuleSelectionChanged += null, this, new RuleEventArgs(null));

            _mocker.VerifyAll();
        }

        [Test]
        public void RuleConfigurationControllerShouldSetConfigurationForCurrentRuleOnViewSave()
        {
            IRule rule = _mocker.DynamicMock<IRule>();
            IRuleConfiguration ruleConfig = _mocker.DynamicMock<IRuleConfiguration>();
            IRuleConfigurationFactory fct = _mocker.DynamicMock<IRuleConfigurationFactory>();

            Expect.Call(ruleConfig.Parameters).Return(new List<IRuleConfigurationParameter>()).Repeat.Once();
            Expect.Call(_provider.GetConfigurationFactoryFor(null)).IgnoreArguments().Return(fct).Repeat.Times(2);
            Expect.Call(fct.Get(null)).IgnoreArguments().Return(ruleConfig).Repeat.Once();
            Expect.Call(() => fct.Set(null)).IgnoreArguments().Repeat.Once();

            _mocker.ReplayAll();

            RuleConfigurationController controller = new RuleConfigurationController(_view, _provider);
            _view.RuleTreeView.Raise(x => x.RuleSelectionChanged += null, this, new RuleEventArgs(rule));
            _view.Raise(x => x.Save += null, this, new RuleConfigurationChangeCommandEventArgs(String.Empty, new Dictionary<IRuleConfigurationParameter, object>()));

            _mocker.VerifyAll();
        }
    }
}
