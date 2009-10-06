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
using System.Runtime.InteropServices;
using System.Text;
using EnvDTE;

namespace JDT.Calidus.Projects.Util
{
    /// <summary>
    /// This class contains utility methods to open files in an IDE
    /// </summary>
    public static class IDEFileOpener
    {
        public static void OpenWithVisualStudio(String file, int lineNumber)
        {
            DTE vsDTE = null;
            try
            {
                //check for running instance
                vsDTE = (DTE)Marshal.GetActiveObject("VisualStudio.DTE");
            }
            catch
            {
                //no running instance, create one
                Type DTEType = Type.GetTypeFromProgID("VisualStudio.DTE");
                vsDTE = (DTE)Activator.CreateInstance(DTEType);
            }

            //make VS visible and not close when the application closes
            vsDTE.MainWindow.Visible = true;
            vsDTE.UserControl = true;

            //open file and select line
            Window window = vsDTE.ItemOperations.OpenFile(file, Constants.vsViewKindTextView);
            TextSelection selection = (TextSelection)vsDTE.ActiveDocument.Selection;
            
            selection.GotoLine(lineNumber, true);
        }
    }
}
