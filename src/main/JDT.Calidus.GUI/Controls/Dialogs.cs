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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.UI.Views;

namespace JDT.Calidus.GUI.Controls
{
    /// <summary>
    /// This class contains a set of dialogs
    /// </summary>
    public static class Dialogs
    {
        /// <summary>
        /// Displays a dialog to open a calidus project file
        /// </summary>
        /// <param name="owner">The dialog owner</param>
        /// <returns>The dialog result</returns>
        public static FileBrowseResult ShowOpenCalidusProjectFileDialog(IWin32Window owner)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.AddExtension = true;
            openDialog.DefaultExt = ".calidus";
            openDialog.Filter = "Calidus Project|*.calidus";

            DialogResult dialogResult = openDialog.ShowDialog(owner);
            return new FileBrowseResult(dialogResult == DialogResult.OK, openDialog.FileName);
        }
        
        /// <summary>
        /// Displays a dialog to save a calidus project file
        /// </summary>
        /// <param name="owner">The dialog owner</param>
        /// <returns>The dialog result</returns>
        public static FileBrowseResult ShowSaveCalidusProjectFileDialog(IWin32Window owner)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".calidus";

            DialogResult dialogResult = saveDialog.ShowDialog(owner);
            return new FileBrowseResult(dialogResult == DialogResult.OK, saveDialog.FileName);
        }
    }
}
