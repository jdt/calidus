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
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Tokens.Access;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Common.Brackets;
using JDT.Calidus.Tokens.Types;

namespace JDT.Calidus.Statements.Factories.Declaration
{
    /// <summary>
    /// This class creates indexer statements
    /// </summary>
    public class IndexerStatementFactory : FluentStatementFactory<IndexerStatement>
    {
        protected override IndexerStatement BuildStatement(IEnumerable<TokenBase> input, IStatementContext context)
        {
            return new IndexerStatement(input, context);
        }

        protected override bool IsValidContext(IStatementContext context)
        {
            return context.Parents.FirstParentIsOfType<ClassStatement>();
        }

        protected override IStatementExpression Expression
        {
            get 
            {
                StatementExpression expression = new StatementExpression();
                expression.Contains<ThisToken>()
                    .FollowedBy<OpenSquareBracketToken>();
                return expression;
            }
        }
    }
}