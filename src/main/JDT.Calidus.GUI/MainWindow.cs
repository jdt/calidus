using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Events;
using JDT.Calidus.Projects.Files;
using JDT.Calidus.Rules;

namespace JDT.Calidus.GUI
{
    public partial class MainWindow : Form
    {
        private const String NOT_SET = "<Not Set>";
        private const String TITLE = "Calidus GUI Test Runner - [{0}]";
        private const String UNSAVED_PROJECT = "Unsaved Project";

        private RuleRunner _runner;
       
        public MainWindow()
        {
            InitializeComponent();

            CurrentProject = new CalidusProject(null, null);

            lstViolations.DisplayMember = "File";

            DisplayProjectDetails();
            DisplayProjectRules();
            
            _runner = new RuleRunner();
            _runner.Started += new RuleRunner.RuleRunnerStartedHandler(_runner_Started);
            _runner.FileCompleted += new RuleRunner.RuleRunnerFileCompleted(_runner_FileCompleted);
            _runner.Completed += new RuleRunner.RuleRunnerCompletedHandler(_runner_Completed);
        }

        #region Runner events

        private void _runner_Started(object source, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            lstViolations.DataSource = new List<RuleViolation>();
        }

        private void _runner_FileCompleted(object source, FileCompletedEventArgs e)
        {
            int i = (int) Math.Truncate((double)e.CurrentFileNumber/(double)e.TotalFileNumbers*100.0);
            prgProgress.Value = i;
            //update violation list
            if (e.Violations.Count() != 0)
            {
                IList<RuleViolation> violations =
                    new List<RuleViolation>((IEnumerable<RuleViolation>) lstViolations.DataSource);
                foreach (RuleViolation aViolation in e.Violations)
                    violations.Add(aViolation);
                lstViolations.DataSource = violations;
                lstViolations.Refresh();
            }
        }

        private void _runner_Completed(object source, RuleRunnerEventArgs e)
        {
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
                CurrentProject = new CalidusProject(selectedDir, null);
                DisplayProjectDetails();
            }
        }

        private void tvRules_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode aNode in e.Node.Nodes)
                aNode.Checked = e.Node.Checked;
        }

        private void cmdRun_Click(object sender, EventArgs e)
        {
            _runner.Run(CurrentProject);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Methods

        private void DisplayProjectDetails()
        {
            String projectName = UNSAVED_PROJECT;
            if (CurrentProject.ProjectLocation != null)
                projectName = CurrentProject.Name;

            Text = String.Format(TITLE, projectName);

            String projectLocation = NOT_SET;
            if (CurrentProject.SourceLocation != null)
                projectLocation = CurrentProject.SourceLocation;

            lnkSourceDirectory.Text = projectLocation;

            if (CurrentProject.SourceLocation != null)
            {
                FileTree tree = new FileTree();
                foreach (String aFile in CurrentProject.GetAllSourceFiles())
                {
                    tree.Add(aFile);
                }

                TreeNode root = new TreeNode(tree.Root.GetItemName());
                FillNode(tree, tree.Root, root);
                tvFiles.Nodes.Add(root);
            }

            if (CurrentProject.SourceLocation != null)
                cmdRun.Enabled = true;
            else
                cmdRun.Enabled = false;
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

        #endregion

        #region Properties

        private CalidusProject CurrentProject { get; set; }

        #endregion
    }
}