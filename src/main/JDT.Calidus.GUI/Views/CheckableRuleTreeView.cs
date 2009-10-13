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
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.GUI.Views
{
    /// <summary>
    /// This class is a forms-based checkable rule tree view
    /// </summary>
    public partial class CheckableRuleTreeView : RuleTreeView, ICheckableRuleTreeView
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public CheckableRuleTreeView()
        {
            InitializeComponent();

            TreeView.CheckBoxes = true;
            TreeView.AfterCheck += new TreeViewEventHandler(TreeView_AfterCheck);
        }

        #region Events

            private void TreeView_AfterCheck(object sender, TreeViewEventArgs e)
            {
                foreach (TreeNode aNode in e.Node.Nodes)
                    aNode.Checked = e.Node.Checked;
            }

        #endregion
    }
}
