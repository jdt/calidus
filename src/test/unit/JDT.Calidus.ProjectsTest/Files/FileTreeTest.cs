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
        public void TreeRootShouldGetCommonRoot()
        {
            IList<String> files = new List<String>();
            files.Add(GetFile(new String[] { "the", "root", "one.cs"}));
            files.Add(GetFile(new String[] { "the", "root", "two.cs" }));
            files.Add(GetFile(new String[] { "the", "root", "three.cs" }));

            _fileTree.Add(files);
            Assert.AreEqual(GetRoot(new String[] { "the", "root"}), _fileTree.Root);
        }

        [Test]
        public void NoRootInCommonShouldGetPathSeparatorRoot()
        {
            IList<String> files = new List<String>();
            files.Add(GetFile(new String[] { "one", "root", "one.cs" }));
            files.Add(GetFile(new String[] { "two", "root", "two.cs" }));
            files.Add(GetFile(new String[] { "three", "root", "three.cs" }));

            _fileTree.Add(files);
            Assert.AreEqual(Path.DirectorySeparatorChar.ToString(), _fileTree.Root);
        }

        [Test]
        public void TreeRootShouldEndWithPathSeparator()
        {
            IList<String> files = new List<String>();
            files.Add(GetFile(new String[] { "the", "root", "one.cs" }));
            files.Add(GetFile(new String[] { "the", "root", "two.cs" }));
            files.Add(GetFile(new String[] { "the", "root", "three.cs" }));

            _fileTree.Add(files);
            Assert.AreEqual(GetRoot(new String[] { "the", "root" }), _fileTree.Root);
        }

        [Test]
        public void GetChildrenShouldReturnListOfChildren()
        {
            IList<String> files = new List<String>();
            files.Add(GetFile(new String[] { "the", "root", "one.cs" }));
            files.Add(GetFile(new String[] { "the", "root", "two.cs" }));
            files.Add(GetFile(new String[] { "the", "nonroot", "two.cs" }));

            _fileTree.Add(files);

            IList<String> theChildren = new List<String>();
            theChildren.Add(GetFile(new String[] { "the", "root" }));
            theChildren.Add(GetFile(new String[] { "the", "nonroot" }));

            CollectionAssert.AreEquivalent(theChildren, _fileTree.GetChildrenOf(_fileTree.Root));
        }

        private String GetFile(IEnumerable<String> parts)
        {
            StringBuilder result = new StringBuilder();
            foreach(String aPart in parts)
            {
                result.Append(Path.DirectorySeparatorChar + aPart);
            }
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
