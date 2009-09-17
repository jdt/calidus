using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This class provides a set of builtin rule categories
    /// </summary>
    public static class RuleCategories
    {
        /// <summary>
        /// Get the naming category
        /// </summary>
        public static String Naming
        {
            get
            {
                return "Naming";
            }
        }

        /// <summary>
        /// Gets the documentation category
        /// </summary>
        public static String Documentation
        {
            get
            {
                return "Documentation";
            }
        }
    }
}
