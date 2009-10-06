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

namespace JDT.Calidus.Projects.Files
{
    /// <summary>
    /// This class represents an item in a file tree
    /// </summary>
    public class FileTreeItem
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="parent">The parent of the item</param>
        /// <param name="location">The full location including the root</param>
        public FileTreeItem(FileTreeItem parent, String location)
        {
            Parent = parent;
            Location = location;
        }

        /// <summary>
        /// The root of the file tree
        /// </summary>
        public FileTreeItem Parent { get; private set; }
        /// <summary>
        /// Get the full location
        /// </summary>
        public String Location { get; private set; }

        /// <summary>
        /// Get the name of the item without the root
        /// </summary>
        public String GetItemName()
        {
            if (Parent == null)
                return Path.DirectorySeparatorChar.ToString();
            else
                return Location.Substring(Parent.Location.Length);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            FileTreeItem theItem = (FileTreeItem)obj;
            if ((theItem.Parent == null && Parent != null) ||
                (theItem.Parent != null && Parent == null))
                return false;
            if (Parent != null && theItem.Parent != null && theItem.Parent.Equals(Parent) == false) return false;
            if (theItem.Location.Equals(Location) == false) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 3;
            hash ^= Parent.GetHashCode();
            hash ^= Location.GetHashCode();

            return hash;
        }
    }
}
