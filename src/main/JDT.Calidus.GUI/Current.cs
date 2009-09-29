using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Projects;

namespace JDT.Calidus.GUI
{
    /// <summary>
    /// This class contains application-wide shared objects
    /// </summary>
    public static class Current
    {
        /// <summary>
        /// Get or Set the current project
        /// </summary>
        public static CalidusProject Project {get;set;}
    }
}
