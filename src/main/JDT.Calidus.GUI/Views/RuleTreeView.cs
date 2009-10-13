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
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.GUI.Views
{
    /// <summary>
    /// This class is a forms-based rule tree view
    /// </summary>
    public partial class RuleTreeView : UserControl, IRuleTreeView
    {
        private IDictionary<TreeNode, IRule> _ruleNodeMap;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RuleTreeView()
        {
            InitializeComponent();
            _ruleNodeMap = new Dictionary<TreeNode, IRule>();
        }

        /// <summary>
        /// Displays the list of rules in a tree
        /// </summary>
        /// <param name="rules">The list of rules</param>
        public void DisplayRules(IEnumerable<IRule> rules)
        {
            _ruleNodeMap.Clear();
            foreach (String aCategory in rules.Select<IRule, String>(p => p.Category).Distinct())
            {
                TreeNode category = new TreeNode(aCategory);
                foreach (IRule aRule in rules.Where<IRule>(p => p.Category.Equals(aCategory)))
                {
                    TreeNode ruleNode = new TreeNode(aRule.Name);
                    ruleNode.Checked = true;

                    category.Nodes.Add(ruleNode);
                    _ruleNodeMap.Add(ruleNode, aRule);
                }
                category.Checked = true;
                
                tvRules.Nodes.Add(category);
                _ruleNodeMap.Add(category, null);
            }
        }

        /// <summary>
        /// Notifies that a rule selection has changed
        /// </summary>
        public event EventHandler<RuleEventArgs> RuleSelectionChanged;
        private void OnRuleSelectionChanged(RuleEventArgs e)
        {
            if (RuleSelectionChanged != null)
                RuleSelectionChanged(this, e);
        }

        /// <summary>
        /// Notifies that a rule selection change was requested
        /// </summary>
        public event EventHandler<RuleChangeCancelEventArgs> BeforeRuleSelectionChanged;
        private void OnBeforeRuleSelectionChanged(RuleChangeCancelEventArgs e)
        {
            if (BeforeRuleSelectionChanged != null)
                BeforeRuleSelectionChanged(this, e);
        }

        #region Properties

            /// <summary>
            /// Gets the tree view
            /// </summary>
            protected TreeView TreeView { get { return tvRules; } }

        #endregion

        #region Events

            private void tvRules_AfterSelect(object sender, TreeViewEventArgs e)
            {
                RuleEventArgs args = new RuleEventArgs(null);
                if(e.Node.Nodes.Count == 0)
                {
                    args = new RuleEventArgs(_ruleNodeMap[e.Node]);
                }

                OnRuleSelectionChanged(args);
            }

            private void tvRules_BeforeSelect(object sender, TreeViewCancelEventArgs e)
            {
                RuleChangeCancelEventArgs args = new RuleChangeCancelEventArgs();
                OnBeforeRuleSelectionChanged(args);

                e.Cancel = args.Cancel;
            }

        #endregion
    }
}
