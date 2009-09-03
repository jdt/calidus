using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JDT.Calidus.Projects.Files;
using NUnit.Framework;

namespace JDT.Calidus.ProjectsTest.Files
{
    [TestFixture]
    public class FileTreeItemTest
    {
        private FileTreeItem _item;

        [SetUp]
        public void SetUp()
        {
            String root = Path.DirectorySeparatorChar + "theroot" + Path.DirectorySeparatorChar;
            _item = new FileTreeItem(new FileTreeItem(null, root), root + "thefile.cs");
        }

        [Test]
        public void FileTreeItemItemNameShouldReturnLocationWithoutRoot()
        {
            Assert.AreEqual("thefile.cs", _item.GetItemName());
        }

        [Test]
        public void EqualFileTreeItemsShouldBeEqual()
        {
            FileTreeItem expected = new FileTreeItem(_item.Parent, _item.Location);

            Assert.AreEqual(expected, _item);
        }
    }
}
