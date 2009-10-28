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

        /// <summary>
        /// Gets the spacing category
        /// </summary>
        public static String Spacing
        {
            get
            {
                return "Spacing";
            }
        }

        /// <summary>
        /// Gets the maintainability category
        /// </summary>
        public static String Maintainability
        {
            get
            {
                return "Maintainability";
            }
        }
    }
}
