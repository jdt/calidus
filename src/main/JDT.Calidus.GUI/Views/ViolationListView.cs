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
using JDT.Calidus.UI.Commands;
using JDT.Calidus.UI.Events;
using JDT.Calidus.UI.Views;
using System.IO;

namespace JDT.Calidus.GUI.Views
{
    /// <summary>
    /// This class is a forms-based violation list view
    /// </summary>
    public partial class ViolationListView : UserControl, IViolationListView
    {
        private static String IGNORE_FILE = "Ignore {1} in {0}";

        private IDictionary<ListViewItem, RuleViolation> _violationMap;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public ViolationListView()
        {
            InitializeComponent();

            _violationMap = new Dictionary<ListViewItem, RuleViolation>();
        }

        /// <summary>
        /// Adds a violation to the view
        /// </summary>
        /// <param name="aViolation">The violation to add</param>
        public void AddViolation(RuleViolation aViolation)
        {
            String[] entry = new String[4];
            entry[0] = aViolation.ViolatedRule.Name;
            entry[1] = aViolation.File;
            entry[2] = aViolation.FirstToken.Line.ToString();
            entry[3] = aViolation.FirstToken.Column.ToString();

            ListViewItem theItem = new ListViewItem(entry);

            lvViolations.Items.Add(theItem);
            _violationMap.Add(theItem, aViolation);
        }        
        
        /// <summary>
        /// Removes a violation from the view
        /// </summary>
        /// <param name="aViolation">The violation to remove</param>
        public void RemoveViolation(RuleViolation aViolation)
        {
            ListViewItem item = _violationMap.First(p => p.Value.Equals(aViolation)).Key;

            lvViolations.Items.Remove(item);
            _violationMap.Remove(item);
        }

        /// <summary>
        /// Clears all violations from the view
        /// </summary>
        public void ClearViolations()
        {
            lvViolations.Items.Clear();
            _violationMap.Clear();
        }

        /// <summary>
        /// Notifies that the view requested rule violation details
        /// </summary>
        public event EventHandler<RuleViolationEventArgs> RuleViolationDetails;
        private void OnRuleViolationDetails(RuleViolationEventArgs e)
        {
            if (RuleViolationDetails != null)
                RuleViolationDetails(this, e);
        }

        /// <summary>
        /// Notifies that the view requested that a violation be ignored
        /// </summary>
        public event EventHandler<RuleViolationIgnoreCommandEventArgs> IgnoreViolation;
        private void OnIgnoreViolation(RuleViolationIgnoreCommandEventArgs e)
        {
            if (IgnoreViolation != null)
                IgnoreViolation(this, e);
        }

        #region Events

            private void lvViolations_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                ListViewItem selectedItem = lvViolations.SelectedItems[0];
                OnRuleViolationDetails(new RuleViolationEventArgs(_violationMap[selectedItem]));
            }

            private void lvViolations_MouseClick(object sender, MouseEventArgs e)
            {
                if(e.Button == MouseButtons.Right)
                {
                    ListViewItem selectedItem = lvViolations.SelectedItems[0];
                    Object[] data = { Path.GetFileName(_violationMap[selectedItem].File), "all violations"};
                    ignoreFileToolStripMenuItem.Text = String.Format(IGNORE_FILE, data);
                    contextMenuStrip.Show(lvViolations, e.X, e.Y);
                }
            }

            private void ignoreFileToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ListViewItem selectedItem = lvViolations.SelectedItems[0];
                OnIgnoreViolation(new RuleViolationIgnoreCommandEventArgs(_violationMap[selectedItem],
                                                                          RuleViolationIgnoreType.File));
            }

        #endregion
    }
}
