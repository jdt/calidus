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
using JDT.Calidus.Projects.Files;
using JDT.Calidus.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace JDT.Calidus.ProjectsTest.Files
{
    [TestFixture]
    public class FileTreeTest
    {
        private FileTree _fileTree;

        [SetUp]
        public void SetUp()
        {
            _fileTree = new FileTree(new StubFileValidator());
        }

        [Test]
        public void FileTreeAddShouldCallValidatorForEachFilePassed()
        {
            IList<String> files = new List<String>();
            files.Add("one.cs");
            files.Add("two.cs");
            files.Add("three.cs");

            MockRepository mocker = new MockRepository();
            IFileValidator validator = mocker.StrictMock<IFileValidator>();
            foreach(String aFile in files)
                Expect.Call(validator.IsValidFile(aFile)).Return(true).Repeat.Once();
            
            mocker.ReplayAll();

            FileTree fileTree = new FileTree(validator);
            fileTree.Add(files);

            mocker.VerifyAll();
        }

        [Test]
        public void CommonRootShouldBeFileSeparator()
        {
            Assert.AreEqual(Path.DirectorySeparatorChar.ToString(), _fileTree.Root.Location);
        }

        [Test]
        public void CommonRootShouldHaveNullParent()
        {
            Assert.AreEqual(null, _fileTree.Root.Parent);
        }


        [Test]
        public void NoRootInCommonShouldGetPathSeparatorRoot()
        {
            _fileTree.Add(GetFile(new String[] {"one", "two", "three.cs"}));
            _fileTree.Add(GetFile(new String[] { "four", "five", "six.cs" }));
            
            Assert.AreEqual(Path.DirectorySeparatorChar.ToString(), _fileTree.Root.Location);
        }

        [Test]
        public void TreeRootShouldEndWithPathSeparator()
        {
            _fileTree.Add(GetFile(new String[] { "one", "two", "three.cs" }));
            _fileTree.Add(GetFile(new String[] { "one", "two", "four.cs" }));

            Assert.IsTrue(_fileTree.Root.Location.EndsWith(Path.DirectorySeparatorChar.ToString()));
        }

        [Test]
        public void GetChildrenShouldReturnListOfChildren()
        {
            _fileTree.Add(GetFile(new String[] { "one", "two", "three.cs" }));
            _fileTree.Add(GetFile(new String[] { "one", "two", "four.cs" }));

            StringBuilder path = new StringBuilder();
            path.Append(Path.DirectorySeparatorChar);

            FileTreeItem root = new FileTreeItem(null, path.ToString());
            path.Append("one" + Path.DirectorySeparatorChar);
            FileTreeItem one = new FileTreeItem(root, path.ToString());
            path.Append("two" + Path.DirectorySeparatorChar);
            FileTreeItem two = new FileTreeItem(one, path.ToString());

            FileTreeItem three = new FileTreeItem(two, path.ToString() + "three.cs");
            FileTreeItem four = new FileTreeItem(two, path.ToString() + "four.cs");
            
            IList<FileTreeItem> expected = new List<FileTreeItem>();
            expected.Add(three);
            expected.Add(four);

            IList<FileTreeItem> actual = new List<FileTreeItem>(_fileTree.GetChildrenOf(two));

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void GetChildrenShouldReturnEmptyListOfChildrenIfNoChildren()
        {
            _fileTree.Add(GetFile(new String[] { "one", "two" }));

            StringBuilder path = new StringBuilder();
            path.Append(Path.DirectorySeparatorChar);

            FileTreeItem root = new FileTreeItem(null, path.ToString());
            path.Append("one" + Path.DirectorySeparatorChar);
            FileTreeItem one = new FileTreeItem(root, path.ToString());
            path.Append("two" + Path.DirectorySeparatorChar);
            FileTreeItem two = new FileTreeItem(one, path.ToString());

            IList<FileTreeItem> expected = new List<FileTreeItem>();
            IList<FileTreeItem> actual = new List<FileTreeItem>(_fileTree.GetChildrenOf(two));

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private String GetFile(IEnumerable<String> parts)
        {
            StringBuilder result = new StringBuilder();
            foreach(String aPart in parts)
            {
                result.Append(Path.DirectorySeparatorChar + aPart);
            }

            if (parts.Last().EndsWith(".cs") == false)
                result.Append(Path.DirectorySeparatorChar);
            return result.ToString();
        }

        private String GetRoot(IEnumerable<String> parts)
        {
            StringBuilder result = new StringBuilder();
            foreach (String aPart in parts)
            {
                result.Append(Path.DirectorySeparatorChar + aPart);
            }
            result.Append(Path.DirectorySeparatorChar);
            return result.ToString();
        }
    }
}
