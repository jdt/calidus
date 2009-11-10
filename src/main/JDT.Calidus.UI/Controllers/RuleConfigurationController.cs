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
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.UI.Commands;
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Views;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.UI.Controllers
{
    /// <summary>
    /// This class acts as a controller for a rule configuration view
    /// </summary>
    public class RuleConfigurationController
    {
        private IRuleConfigurationView _view;
        private ICalidusRuleProvider _provider;
        private ICalidusProjectModel _project;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="view">The view to use</param>
        /// <param name="provider">The rule provider to use</param>
        /// <param name="project">The project</param>
        public RuleConfigurationController(IRuleConfigurationView view, ICalidusRuleProvider provider, ICalidusProjectModel project)
        {
            HasChanges = false;

            _project = project;

            _provider = provider;

            _view = view;
            _view.RuleTreeView.BeforeRuleSelectionChanged += new EventHandler<RuleChangeCancelEventArgs>(RuleTreeView_BeforeRuleSelectionChanged);
            _view.RuleTreeView.RuleSelectionChanged += new EventHandler<RuleEventArgs>(RuleTreeView_RuleSelectionChanged);
            _view.SelectedRuleParameterChanged += new EventHandler<RuleConfigurationParameterEventArgs>(_view_SelectedRuleParameterChanged);
            _view.RuleParameterSettingsChanged += new EventHandler<EventArgs>(_view_RuleParameterSettingsChanged);
            _view.Save += new EventHandler<RuleConfigurationChangeCommandEventArgs>(_view_Save);
            _view.Closing += new EventHandler<RuleChangeCancelEventArgs>(_view_Closing);

            IEnumerable<IRule> rules = _provider.GetRules(_project.GetProjectRuleConfigurations());
            _view.DisplayRules(rules);
        }

        /// <summary>
        /// Get or Set if the controller has unapplied changes
        /// </summary>
        private bool HasChanges { get; set; }
        /// <summary>
        /// Get or Set the current configuration
        /// </summary>
        private IRuleConfiguration CurrentConfiguration { get; set; }

        private void _view_RuleParameterSettingsChanged(object sender, EventArgs e)
        {
            HasChanges = true;
        }

        private void _view_SelectedRuleParameterChanged(object sender, RuleConfigurationParameterEventArgs e)
        {
            if(e.Parameter != null)
                _view.DisplayRuleConfigurationParameter(e.Parameter);
        }

        private void RuleTreeView_BeforeRuleSelectionChanged(object sender, RuleChangeCancelEventArgs e)
        {
            if (!HasChanges || _view.ConfirmRuleSelectionChanged())
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void RuleTreeView_RuleSelectionChanged(object sender, RuleEventArgs e)
        {
            if (e.SelectedRule != null)
            {
                IRuleConfiguration config = _provider.GetConfigurationFactoryFor(e.SelectedRule.GetType()).Get(e.SelectedRule.GetType());
                _view.DisplayRuleConfiguration(config);
                CurrentConfiguration = config;
            }
            else
            {
                _view.ClearRuleConfiguration();
                CurrentConfiguration = null;
            }

            HasChanges = false;
        }

        private void _view_Closing(object sender, RuleChangeCancelEventArgs e)
        {
            if (!HasChanges || _view.ConfirmRuleSelectionChanged())
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void _view_Save(object sender, RuleConfigurationChangeCommandEventArgs e)
        {
            CurrentConfiguration.Description = e.Description;
            foreach(IRuleConfigurationParameter aParam in CurrentConfiguration.Parameters)
                aParam.Value = e.ValueMap[aParam];
            _project.SetProjectRuleConfigurationTo(CurrentConfiguration);
            HasChanges = false;
        }
    }
}
