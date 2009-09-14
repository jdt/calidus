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
