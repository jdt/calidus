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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.GUI.Controls.Parameters;
using JDT.Calidus.UI.Commands;
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.GUI.Views
{
    /// <summary>
    /// This class is a forms-based rule configuration view
    /// </summary>
    public partial class RuleConfigurationView : UserControl, IRuleConfigurationView
    {
        private IRuleTreeView _ruleTreeView;

        private IDictionary<IRuleConfigurationParameter, EditParameterControl> _currentRuleParameterControl;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RuleConfigurationView()
        {
            InitializeComponent();

            Load += new EventHandler(RuleConfigurationView_Load);

            _ruleTreeView = ruleTreeView;
            _currentRuleParameterControl = new Dictionary<IRuleConfigurationParameter, EditParameterControl>();
        }

        private void RuleConfigurationView_Load(object sender, EventArgs e)
        {
            //need to wire this in the load to prevent null-issues
            ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }

        /// <summary>
        /// Gets the tree view that is used to display rules
        /// </summary>
        public IRuleTreeView RuleTreeView
        {
            get { return ruleTreeView; }
        }

        /// <summary>
        /// Displays the rules in the view
        /// </summary>
        /// <param name="ruleList">The rules to display</param>
        public void DisplayRules(IEnumerable<IRule> ruleList)
        {
            _ruleTreeView.DisplayRules(ruleList);
        }

        /// <summary>
        /// Displays the configuration for the rule
        /// </summary>
        /// <param name="ruleConfig">The rule configuration to display</param>
        public void DisplayRuleConfiguration(IRuleConfiguration ruleConfig)
        {
            parameterLayoutPanel.Controls.Clear();
            mainContainer.Panel2.Enabled = true;

            //create parameter controls
            _currentRuleParameterControl.Clear();
            foreach (IRuleConfigurationParameter aParameter in ruleConfig.Parameters)
            {
                EditParameterControl paramControl = GetControlFor(aParameter);
                paramControl.SetValue(aParameter.Value);
                paramControl.ValueChanged += new EventHandler(paramControl_ValueChanged);

                _currentRuleParameterControl.Add(aParameter, paramControl);
            }

            txtDescription.Text = ruleConfig.Description;
            lstParameters.DataSource = ruleConfig.Parameters;
            lstParameters.DisplayMember = "Name";
        }

        /// <summary>
        /// Clears the rule configuration from the view
        /// </summary>
        public void ClearRuleConfiguration()
        {
            mainContainer.Panel2.Enabled = false;

            txtDescription.Clear();
            lstParameters.DataSource = null;
        }

        /// <summary>
        /// Displays the rule configuration parameter
        /// </summary>
        /// <param name="parameter">The parameter to display</param>
        public void DisplayRuleConfigurationParameter(IRuleConfigurationParameter parameter)
        {
            parameterLayoutPanel.Controls.Clear();
            parameterLayoutPanel.Controls.Add(_currentRuleParameterControl[parameter]);
        }

        /// <summary>
        /// Promps the view to confirm a rule selection change
        /// </summary>
        /// <returns>True if confirmed, otherwise false</returns>
        public bool ConfirmRuleSelectionChanged()
        {
            DialogResult res = MessageBox.Show(this, "Rule has unsaved changes, discard them and continue?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            return res == DialogResult.Yes;
        }

        /// <summary>
        /// Notifies that a rule parameter has changed
        /// </summary>
        public event EventHandler<RuleConfigurationParameterEventArgs> SelectedRuleParameterChanged;
        private void OnSelectedRuleParameterChanged(RuleConfigurationParameterEventArgs e)
        {
            if (SelectedRuleParameterChanged != null)
                SelectedRuleParameterChanged(this, e);
        }

        /// <summary>
        /// Notifies that a rule parameter setting has changed
        /// </summary>
        public event EventHandler<EventArgs> RuleParameterSettingsChanged;
        private void OnRuleParameterSettingsChanged(EventArgs e)
        {
            if (RuleParameterSettingsChanged != null)
                RuleParameterSettingsChanged(this, e);
        }

        /// <summary>
        /// Notifies that a save was called
        /// </summary>
        public event EventHandler<RuleConfigurationChangeCommandEventArgs> Save;
        private void OnSave(RuleConfigurationChangeCommandEventArgs e)
        {
            if (Save != null)
                Save(this, e);
        }

        /// <summary>
        /// Notifies that the view is closing
        /// </summary>
        public event EventHandler<RuleChangeCancelEventArgs> Closing;
        private void OnClosing(RuleChangeCancelEventArgs e)
        {
            if (Closing != null)
                Closing(this, e);
        }

        #region Events

            private void paramControl_ValueChanged(object sender, EventArgs e)
            {
                OnRuleParameterSettingsChanged(new EventArgs());
            }
            
            private void txtDescription_TextChanged(object sender, EventArgs e)
            {
                OnRuleParameterSettingsChanged(new EventArgs());
            }


            private void lstParameters_SelectedIndexChanged(object sender, EventArgs e)
            {
                OnSelectedRuleParameterChanged(new RuleConfigurationParameterEventArgs((IRuleConfigurationParameter)lstParameters.SelectedValue));
            }

            private void cmdSave_Click(object sender, EventArgs e)
            {
                String desc = txtDescription.Text;
                IDictionary<IRuleConfigurationParameter, Object> valueMap = new Dictionary<IRuleConfigurationParameter, Object>();
                foreach (IRuleConfigurationParameter aParam in _currentRuleParameterControl.Keys)
                {
                    valueMap.Add(aParam, _currentRuleParameterControl[aParam].GetValue());
                }

                RuleConfigurationChangeCommandEventArgs args = new RuleConfigurationChangeCommandEventArgs(desc, valueMap);
                OnSave(args);
            }

            private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                RuleChangeCancelEventArgs args = new RuleChangeCancelEventArgs();
                OnClosing(args);
                e.Cancel = args.Cancel;
            }

        #endregion

        #region Utility methods

            private EditParameterControl GetControlFor(IRuleConfigurationParameter param)
            {
                if (param.ParameterType == ParameterType.MultilineString)
                    return new MultilineParameterControl();
                else if (param.ParameterType == ParameterType.Boolean)
                    return new BooleanParameterControl();
                else
                    return new BasicParameterControl();
            }

        #endregion
    }
}
