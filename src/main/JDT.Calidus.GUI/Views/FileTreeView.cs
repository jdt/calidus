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
using JDT.Calidus.Projects.Files;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.GUI.Views
{
    /// <summary>
    /// This class is a forms-based file tree view
    /// </summary>
    public partial class FileTreeView : UserControl, IFileTreeView
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public FileTreeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display the list of files
        /// </summary>
        /// <param name="files">The file list</param>
        public void DisplaySourceFiles(IEnumerable<String> files)
        {
            tvFiles.Nodes.Clear();

            FileTree tree = new FileTree();
            foreach (String aFile in files)
            {
                tree.Add(aFile);
            }

            TreeNode root = new TreeNode(tree.Root.GetItemName());
            FillNode(tree, tree.Root, root);
            tvFiles.Nodes.Add(root);
        }

        #region Utility methods

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
    }
}
