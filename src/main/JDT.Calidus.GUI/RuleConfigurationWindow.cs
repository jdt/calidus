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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Configuration;
using JDT.Calidus.GUI.Controls.Parameters;
using JDT.Calidus.Rules;

namespace JDT.Calidus.GUI
{
    public partial class RuleConfigurationWindow : Form
    {
        private static String RULE_NAME = "Rule: {0}";

        private CalidusRuleProvider _provider;
        private IDictionary<TreeNode, Type> _typeNodes;

        private EditParameterControl _currentParameterControl;
        private IDictionary<IRuleConfigurationParameter, EditParameterControl> _paramControls;

        public RuleConfigurationWindow()
        {
            InitializeComponent();

            _typeNodes = new Dictionary<TreeNode, Type>();
            _provider = new CalidusRuleProvider();

            HasChanges = false;

            DisplayProjectRules();
        }

        private void tvRules_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //reset parameter list
            _paramControls = new Dictionary<IRuleConfigurationParameter, EditParameterControl>();

            if (e.Node.Nodes.Count == 0)
            {
                mainContainer.Panel2.Enabled = true;

                IRuleConfiguration config =_provider.GetConfigurationFactoryFor(_typeNodes[e.Node]).Get(_typeNodes[e.Node]);

                //set values
                lblRuleName.Text = String.Format(RULE_NAME, config.GetType().Name);
                txtDescription.Text = config.Description;
                lstParameters.DataSource = config.Parameters.Select(p => p.Name).ToList<String>();

                //create parameter controls
                foreach(IRuleConfigurationParameter aParameter in config.Parameters)
                {
                    EditParameterControl paramControl = GetControlFor(aParameter);
                    paramControl.SetValue(aParameter.Value);
                    paramControl.ValueChanged += new EventHandler(paramControl_ValueChanged);

                    _paramControls.Add(aParameter, paramControl);
                }

                //register parameter control
                parameterLayoutPanel.Controls.Clear();

                //display parameter
                DisplayParameterDetails();

                //reset changes
                HasChanges = false;
            }
            else
            {
                mainContainer.Panel2.Enabled = false;

                lblRuleName.Text = String.Format(RULE_NAME, "");
                txtDescription.Text = String.Empty;
                lstParameters.DataSource = null;

                _currentParameterControl = null;
                parameterLayoutPanel.Controls.Clear();

                //reset changes
                HasChanges = false;
            }
        }

        private void paramControl_ValueChanged(object sender, EventArgs e)
        {
            HasChanges = true;
        }

        private void lstParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayParameterDetails();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveRule();
        }

        private void tvRules_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (WantsToChange() == false)
            {
                e.Cancel = true;
            }
            else
            {
                //unregister previous rules
                if (_paramControls != null)
                {
                    foreach (EditParameterControl ctrl in _paramControls.Values)
                        ctrl.ValueChanged -= new EventHandler(paramControl_ValueChanged);
                }
            }
        }
        
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            HasChanges = true;
        }

        private void RuleConfigurationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WantsToChange() == false)
                e.Cancel = true;
        }

        #region Properties

            private bool HasChanges
            {
                get { return cmdSave.Enabled; }
                set { cmdSave.Enabled = value; }
            }

        #endregion

        #region Methods

            private void DisplayParameterDetails()
            {              
                if (_paramControls.Count != 0 && lstParameters.SelectedValue != null)
                {
                    String paramName = lstParameters.SelectedValue.ToString();
                    _currentParameterControl = _paramControls.First(p => p.Key.Name.Equals(paramName)).Value;
                    parameterLayoutPanel.Controls.Clear();
                    parameterLayoutPanel.Controls.Add(_currentParameterControl);
                }
            }

            private bool WantsToChange()
            {
                if (HasChanges == false)
                {
                    return true;
                }
                else
                {
                    DialogResult change = MessageBox.Show(this, "There are unsaved changes, continue?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    return change == DialogResult.Yes;
                }
            }

            private void SaveRule()
            {
                IRuleConfiguration ruleConfig =_provider.GetConfigurationFactoryFor(_typeNodes[tvRules.SelectedNode]).Get(_typeNodes[tvRules.SelectedNode]);
                ruleConfig.Description = txtDescription.Text;

                foreach(IRuleConfigurationParameter param in ruleConfig.Parameters)
                {
                    param.Value = _paramControls[param].GetValue();
                }

                _provider.GetConfigurationFactoryFor(_typeNodes[tvRules.SelectedNode]).Set(ruleConfig);

                HasChanges = false;
            }

            private void DisplayProjectRules()
            {
                IEnumerable<IRule> rules = _provider.GetRules();

                foreach (String aCategory in rules.Select<IRule, String>(p => p.Category).Distinct())
                {
                    TreeNode category = new TreeNode(aCategory);
                    foreach (IRule aRule in rules.Where<IRule>(p => p.Category.Equals(aCategory)))
                    {
                        TreeNode ruleNode = new TreeNode(aRule.Name);
                        ruleNode.Checked = true;
                        category.Nodes.Add(ruleNode);

                        _typeNodes.Add(ruleNode, aRule.GetType());
                    }
                    category.Checked = true;
                    tvRules.Nodes.Add(category);
                }
            }

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
