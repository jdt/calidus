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

        private IEnumerable<String> _files;
        private IFileValidator _validator;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="validator">The validator to use to validate files</param>
        public FileTree(IFileValidator validator)
        {
            _validator = validator;
        }

        /// <summary>
        /// Adds the list of files to the file tree
        /// </summary>
        /// <param name="files">The files to put in the tree</param>
        public void Add(IEnumerable<String> files)
        {
            foreach(String aLine in files)
            {
                if (_validator.IsValidFile(aLine) == false)
                    throw new CalidusException("File " + aLine + " is not a valid file");
            }

            _files = files;
        }

        /// <summary>
        /// Gets the common root of all the files
        /// </summary>
        public String Root
        {
            get
            {
                if (_files.Count() == 0)
                    return SEPARATOR;

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
                    return SEPARATOR;
                else
                {
                    //append at least the start and end
                    if (root.StartsWith(SEPARATOR) == false)
                        root = SEPARATOR + root;
                    if (root.EndsWith(SEPARATOR) == false)
                        root = root + SEPARATOR;
                    return root;
                }
            }
        }

        /// <summary>
        /// Gets the list of child elements of the path provided
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The child list</returns>
        public IEnumerable<String> GetChildrenOf(String path)
        {
            IList<String> result = new List<String>();

            foreach(String aFile in _files)
            {
                if(aFile.StartsWith(path))
                {
                    String child = path;
                    int i = path.Length;
                    while(i < aFile.Length
                        && aFile[i].Equals(Path.DirectorySeparatorChar) == false)
                    {
                        child += aFile[i];
                        i++;
                    }

                    if (result.Contains(child) == false)
                        result.Add(child);
                }
            }

            return result;
        }
    }
}
