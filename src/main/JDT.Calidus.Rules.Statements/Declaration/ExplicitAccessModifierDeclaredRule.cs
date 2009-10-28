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
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Statements.Declaration;

namespace JDT.Calidus.Rules.Statements.Declaration
{
    /// <summary>
    /// This class validates that elements with access modifiers have explicit 
    /// access modifiers declared
    /// </summary>
    public class ExplicitAccessModifierDeclaredRule 
        : StatementRuleBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public ExplicitAccessModifierDeclaredRule()
            : base(RuleCategories.Maintainability)
        {
        }

        /// <summary>
        /// Checks if the rule validates the supplied statement
        /// </summary>
        /// <param name="statement">The statement</param>
        /// <returns>True if validates, otherwise false</returns>
        public override bool Validates(StatementBase statement)
        {
            return statement is AccessModifierStatement;
        }

        /// <summary>
        /// Checks if the rule is valid for the statement
        /// </summary>
        /// <param name="statement">The statement</param>
        /// <returns>True if valid, otherwise false</returns>
        public override bool IsValidFor(StatementBase statement)
        {
            AccessModifierStatement theStatement = (AccessModifierStatement)statement;
            return theStatement.AccessModifierToken != null;
        }
    }
}
