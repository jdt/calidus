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
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Statements.Declaration;
using JDT.Calidus.Statements.Factories.Fluent;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens.Types;

namespace JDT.Calidus.Statements.Factories.Declaration
{
    /// <summary>
    /// This class creates struct statements
    /// </summary>
    public class StructStatementFactory : FluentStatementFactory<StructStatement>
    {
        protected override StructStatement BuildStatement(IList<TokenBase> input)
        {
            return new StructStatement(input);
        }

        protected override IStatementExpression Expression
        {
            get
            {
                StatementExpression expression = new StatementExpression();
                expression.Contains<StructToken>()
                    .FollowedBy<IdentifierToken>();

                return expression;
            }
        }
    }
}