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
