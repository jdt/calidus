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
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.UI.Commands;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UI.Views
{
    /// <summary>
    /// This interface is implemented by views of rule configurations
    /// </summary>
    public interface IRuleConfigurationView
    {
        /// <summary>
        /// Gets the tree view that is used to display rules
        /// </summary>
        IRuleTreeView RuleTreeView { get; }
        /// <summary>
        /// Displays the rules in the view
        /// </summary>
        /// <param name="ruleList">The rules to display</param>
        void DisplayRules(IEnumerable<IRule> ruleList);
        /// <summary>
        /// Displays the configuration for the rule
        /// </summary>
        /// <param name="ruleConfig">The rule configuration to display</param>
        void DisplayRuleConfiguration(IRuleConfiguration ruleConfig);
        /// <summary>
        /// Clears the rule configuration from the view
        /// </summary>
        void ClearRuleConfiguration();
        /// <summary>
        /// Displays the rule configuration parameter
        /// </summary>
        /// <param name="parameter">The parameter to display</param>
        void DisplayRuleConfigurationParameter(IRuleConfigurationParameter parameter);
        /// <summary>
        /// Promps the view to confirm a rule selection change
        /// </summary>
        /// <returns>True if confirmed, otherwise false</returns>
        bool ConfirmRuleSelectionChanged();
        /// <summary>
        /// Notifies that a rule parameter has changed
        /// </summary>
        event EventHandler<RuleConfigurationParameterEventArgs> SelectedRuleParameterChanged;
        /// <summary>
        /// Notifies that a rule parameter setting has changed
        /// </summary>
        event EventHandler<EventArgs> RuleParameterSettingsChanged;
        /// <summary>
        /// Notifies that a save was called
        /// </summary>
        event EventHandler<RuleConfigurationChangeCommandEventArgs> Save;
        /// <summary>
        /// Notifies that the view is closing
        /// </summary>
        event EventHandler<RuleChangeCancelEventArgs> Closing;
    }
}
