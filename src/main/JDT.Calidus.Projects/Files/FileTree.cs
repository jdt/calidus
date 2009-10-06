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
using System.IO;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;

namespace JDT.Calidus.Projects.Files
{
    /// <summary>
    /// This class represents a file tree, a structure of files and directories
    /// with parent-child relations
    /// </summary>
    public class FileTree
    {
        private static readonly String SEPARATOR = Path.DirectorySeparatorChar.ToString();

        private IList<String> _files;
        private IFileValidator _validator;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="validator">The validator to use to validate files</param>
        public FileTree(IFileValidator validator)
        {
            _validator = validator;
            _files = new List<String>();
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public FileTree()
            : this(ObjectFactory.Get<IFileValidator>())
        {
        }

        /// <summary>
        /// Adds the list of files to the file tree
        /// </summary>
        /// <param name="files">The files to put in the tree</param>
        public void Add(IEnumerable<String> files)
        {
            foreach (String aLine in files)
            {
                Add(aLine);
            }
        }

        /// <summary>
        /// Adds a single file to the file tree
        /// </summary>
        /// <param name="file">The file to put in the tree</param>
        public void Add(String file)
        {
            if (_validator.IsValidFile(file) == false)
                throw new CalidusException("File " + file + " is not a valid file");

            _files.Add(file);
        }

        /// <summary>
        /// Gets the common root of all the files
        /// </summary>
        public FileTreeItem Root
        {
            get
            {
                if (_files.Count() == 0)
                    return new FileTreeItem(null, SEPARATOR);

                String root = Path.GetDirectoryName(_files.ElementAt(0));
                foreach(String aFile in _files)
                {
                    StringBuilder common = new StringBuilder();
                    int i = 0;
                    //while still in the string and the character matches
                    while (i < aFile.Length &&
                        i < root.Length
                        && aFile[i].Equals(root[i]))
                    {
                        //append the character
                        common.Append(aFile[i]);
                        i++;
                    }
                    root = common.ToString();
                }

                //return at least separator
                if (root.Length == 0)
                    return new FileTreeItem(null, SEPARATOR);
                else
                {
                    if (root.EndsWith(SEPARATOR) == false)
                        root = root + SEPARATOR;
                    return new FileTreeItem(null, root);
                }
            }
        }

        /// <summary>
        /// Gets the list of child elements of the path provided
        /// </summary>
        /// <param name="item">The parent item</param>
        /// <returns>The child list</returns>
        public IEnumerable<FileTreeItem> GetChildrenOf(FileTreeItem item)
        {
            IList<String> result = new List<String>();

            foreach(String aFile in _files)
            {
                if(aFile.StartsWith(item.Location))
                {
                    String child = item.Location;
                    int i = child.Length;
                    while(i < aFile.Length
                        && aFile[i].Equals(Path.DirectorySeparatorChar) == false)
                    {
                        child += aFile[i];
                        i++;
                    }

                    //add the last separator char 
                    if(i < aFile.Length)
                        child += aFile[i];

                    if (result.Contains(child) == false)
                        result.Add(child);
                }
            }

            if (result.Count == 1
                && result[0].Equals(item.Location))
                return new List<FileTreeItem>();
            else
            {
                IList<FileTreeItem> resultList = new List<FileTreeItem>();
                foreach(String aFile in result)
                {
                    resultList.Add(new FileTreeItem(item, aFile));
                }
                return resultList;
            }
        }
    }
}
