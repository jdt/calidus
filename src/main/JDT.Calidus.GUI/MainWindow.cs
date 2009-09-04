using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Projects;
using JDT.Calidus.Projects.Files;
using JDT.Calidus.Rules;

namespace JDT.Calidus.GUI
{
    public partial class MainWindow : Form
    {
        private const String NOT_SET = "<Not Set>";
        private const String TITLE = "Calidus GUI Test Runner - [{0}]";
        private const String NEW_PROJECT = "New Project";
        private const String UNSAVED_PROJECT = "Unsaved Project";

        public MainWindow()
        {
            InitializeComponent();

            CurrentProject = null;

            DisplayProjectDetails();
            DisplayProjectRules();
        }

        #region Events

        private void lnkSourceDirectory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog browseDirectory = new FolderBrowserDialog();
            browseDirectory.ShowNewFolderButton = false;
            browseDirectory.ShowDialog(this);

            String selectedDir = browseDirectory.SelectedPath;
            if(selectedDir.Equals(String.Empty) == false)
            {
                CurrentProject = new CalidusProject(selectedDir, null);
                DisplayProjectDetails();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Methods

        private void DisplayProjectDetails()
        {
            if(CurrentProject == null)
            {
                Text = String.Format(TITLE, NEW_PROJECT);
                lnkSourceDirectory.Text = NOT_SET;
            }
            else
            {
                String projectName = UNSAVED_PROJECT;
                if (CurrentProject.ProjectLocation != null)
                    projectName = CurrentProject.Name;

                Text = String.Format(TITLE, projectName);
                lnkSourceDirectory.Text = CurrentProject.SourceLocation;

                FileTree tree = new FileTree();
                foreach(String aFile in Directory.GetFiles(CurrentProject.SourceLocation, "*.cs", SearchOption.AllDirectories))
                {
                    tree.Add(aFile);
                }

                TreeNode root = new TreeNode(tree.Root.GetItemName());
                FillNode(tree, tree.Root, root);
                tvFiles.Nodes.Add(root);
            }
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
                    category.Nodes.Add(ruleNode);
                }
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