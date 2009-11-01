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
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Factories.Fluent;
using JDT.Calidus.Statements.Namespace;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Namespace;

namespace JDT.Calidus.Statements.Factories.Namespace
{
    /// <summary>
    /// This class creates namespace statements
    /// </summary>
    public class NameSpaceStatementFactory : FluentStatementFactory<NameSpaceStatement>
    {
        protected override NameSpaceStatement BuildStatement(IEnumerable<TokenBase> input)
        {
            return new NameSpaceStatement(input);
        }

        protected override bool IsValidContext(IStatementContext context)
        {
            return true;
        }

        protected override IStatementExpression Expression
        {
            get
            {
                StatementExpression expression = new StatementExpression();
                expression.StartsWith<NameSpaceToken>();

                return expression;
            }
        }
    }
}
