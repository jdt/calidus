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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Events;
using JDT.Calidus.Projects.Files;
using JDT.Calidus.Projects.Util;
using JDT.Calidus.Rules;

namespace JDT.Calidus.GUI
{
    public partial class MainWindow : Form
    {
        private const String NOT_SET = "<Not Set>";
        private const String TITLE = "Calidus GUI Test Runner - [{0}]";
        private const String UNSAVED_PROJECT = "Unsaved Project";

        private RuleRunner _runner;
        private IList<RuleViolation> _violations;

        public MainWindow()
        {
            InitializeComponent();

            DisplayProjectDetails();
            DisplayProjectRules();

            _violations = new List<RuleViolation>();
            
            _runner = new RuleRunner();
            _runner.Started += new RuleRunner.RuleRunnerStartedHandler(_runner_Started);
            _runner.FileCompleted += new RuleRunner.RuleRunnerFileCompleted(_runner_FileCompleted);
            _runner.Completed += new RuleRunner.RuleRunnerCompletedHandler(_runner_Completed);

            DisplayViolationCount();
        }

        #region Runner events

            private void _runner_Started(object source, EventArgs e)
            {
                Cursor = Cursors.WaitCursor;
                _violations.Clear();
                DisplayViolations(_violations);
            }

            private void _runner_FileCompleted(object source, FileCompletedEventArgs e)
            {
                int i = (int) Math.Truncate((double)e.CurrentFileNumber/(double)e.TotalFileNumbers*100.0);
                prgProgress.Value = i; 
                
                foreach (RuleViolation aViolation in e.Violations)
                    _violations.Add(aViolation);
                
                DisplayViolationCount();
            }

            private void _runner_Completed(object source, RuleRunnerEventArgs e)
            {
                DisplayViolations(new List<RuleViolation>(_violations));
                lvViolations.Refresh();
                DisplayViolationCount();
                Cursor = Cursors.Default;
            }

        #endregion

        #region Events

            private void lnkSourceDirectory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                FolderBrowserDialog browseDirectory = new FolderBrowserDialog();
                browseDirectory.ShowNewFolderButton = false;
                browseDirectory.ShowDialog(this);

                String selectedDir = browseDirectory.SelectedPath;
                if (selectedDir.Equals(String.Empty) == false)
                {
                    Current.Project = CalidusProject.Create(selectedDir);
                    DisplayProjectDetails();
                }
            }

            private void tvRules_AfterCheck(object sender, TreeViewEventArgs e)
            {
                foreach (TreeNode aNode in e.Node.Nodes)
                    aNode.Checked = e.Node.Checked;
            }

            private void lvViolations_DoubleClick(object sender, EventArgs e)
            {
                if (lvViolations.SelectedItems.Count != 0)
                {
                    ListViewItem item = lvViolations.SelectedItems[0];
                    IDEFileOpener.OpenWithVisualStudio(item.SubItems[1].Text, Int32.Parse(item.SubItems[2].Text));
                }
            }

            private void cmdRun_Click(object sender, EventArgs e)
            {
                _runner.Run(Current.Project);
            }

        #endregion

        #region Menu events

            private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
            {
                RuleConfigurationWindow config = new RuleConfigurationWindow();
                config.ShowDialog();
            }

            private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ProjectConfigurationWindow config = new ProjectConfigurationWindow();
                config.ShowDialog();
            }

            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

        #endregion

        #region Methods

            private void DisplayViolationCount()
            {
                lblViolations.Text = String.Format("Found {0} violations", _violations.Count);
                stripStatus.Refresh();
            }

            private void DisplayProjectDetails()
            {
                String projectName = UNSAVED_PROJECT;
                String projectTitle = NOT_SET;

                if (Current.Project != null)
                {
                    projectName = Current.Project.Name;
                    projectTitle = Current.Project.SourceLocation;

                    FileTree tree = new FileTree();
                    foreach (String aFile in Current.Project.GetAllSourceFiles())
                    {
                        tree.Add(aFile);
                    }

                    TreeNode root = new TreeNode(tree.Root.GetItemName());
                    FillNode(tree, tree.Root, root);
                    tvFiles.Nodes.Add(root);

                    cmdRun.Enabled = true;
                }
                else
                {
                    cmdRun.Enabled = false;
                }

                lnkSourceDirectory.Text = projectTitle;
                Text = String.Format(TITLE, projectName);
            }

            private void DisplayProjectRules()
            {
                CalidusRuleProvider ruleProvider = new CalidusRuleProvider();
                IEnumerable<IRule> rules = ruleProvider.GetRules();

                foreach (String aCategory in rules.Select<IRule, String>(p => p.Category).Distinct())
                {
                    TreeNode category = new TreeNode(aCategory);
                    foreach (IRule aRule in rules.Where<IRule>(p => p.Category.Equals(aCategory)))
                    {
                        TreeNode ruleNode = new TreeNode(aRule.Name);
                        ruleNode.Checked = true;
                        category.Nodes.Add(ruleNode);
                    }
                    category.Checked = true;
                    tvRules.Nodes.Add(category);
                }
            }

            private void FillNode(FileTree treeToAddFrom, FileTreeItem parent, TreeNode nodeToAddTo)
            {
                foreach (FileTreeItem aChild in treeToAddFrom.GetChildrenOf(parent))
                {
                    TreeNode childNode = new TreeNode(aChild.GetItemName());
                    if (treeToAddFrom.GetChildrenOf(aChild).Count() != 0)
                        FillNode(treeToAddFrom, aChild, childNode);
                    nodeToAddTo.Nodes.Add(childNode);
                }
            }

            private void DisplayViolations(IEnumerable<RuleViolation> violations)
            {
                lvViolations.Items.Clear();
                foreach(RuleViolation aViolation in violations)
                {
                    String[] entry = new String[4];
                    entry[0] = aViolation.ViolatedRule.Name;
                    entry[1] = aViolation.File;
                    entry[2] = aViolation.FirstToken.Line.ToString();
                    entry[3] = aViolation.FirstToken.Column.ToString();

                    lvViolations.Items.Add(new ListViewItem(entry));
                }
            }

        #endregion
    }
}