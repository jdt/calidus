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

namespace JDT.Calidus.Common.Statements
{
    /// <summary>
    /// This class contains utility methods for statement parents
    /// </summary>
    public static class StatementParentUtils
    {
        /// <summary>
        /// Checks that a first parent contains a statement of a certain type
        /// </summary>
        /// <param name="parents">The parents</param>
        /// <typeparam name="TStatement">The statement type</typeparam>
        /// <returns>True if a statement of type was found, otherwise false</returns>
        public static bool FirstParentIsOfType<TStatement>(this IEnumerable<StatementParent> parents)
            where TStatement : StatementBase
        {
            if (parents.Count() == 0)
                return false;

            StatementParent firstParent = parents.Last();
            return firstParent.Statements.Count(p => p.GetType().Equals(typeof(TStatement))) > 0;
        }
    }
}
