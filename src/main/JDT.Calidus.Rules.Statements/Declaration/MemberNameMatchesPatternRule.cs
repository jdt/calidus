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
using System.Text.RegularExpressions;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Statements.Declaration;

namespace JDT.Calidus.Rules.Statements.Declaration
{
    /// <summary>
    /// This class implements a rule to check if the member name
    /// of a member declaration matches a certain pattern
    /// </summary>
    public class MemberNameMatchesPatternRule 
        : StatementRuleBase
    {
        private Regex _expression;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="pattern">The pattern to match with</param>
        public MemberNameMatchesPatternRule(String pattern)
            : this(new Regex(pattern))
        {
        }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="expression">The expression to match with</param>
        public MemberNameMatchesPatternRule(Regex expression)
            : base(RuleCategories.Naming)
        {
            _expression = expression;
        }

        /// <summary>
        /// Checks if the rule validates the supplied statement
        /// </summary>
        /// <param name="statement">The statement</param>
        /// <returns>True if validates, otherwise false</returns>
        public override bool Validates(StatementBase statement)
        {
            return statement is MemberStatement;
        }

        /// <summary>
        /// Checks if the rule is valid for the statement
        /// </summary>
        /// <param name="statement">The statement</param>
        /// <returns>True if valid, otherwise false</returns>
        public override bool IsValidFor(StatementBase statement)
        {
            MemberStatement memberStatement = (MemberStatement) statement;
            return _expression.IsMatch(memberStatement.MemberNameToken.Content);
        }
    }
}