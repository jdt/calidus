﻿#region License
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

namespace JDT.Calidus.Parsers.Statements
{
    /// <summary>
    /// This class is a statement context
    /// </summary>
    public class StatementContext : IStatementContext
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="parents">The statement parents</param>
        /// <param name="nextTokenFromPreviousStatement">The next token based on the previously parsed statement</param>
        public StatementContext(IEnumerable<StatementParent> parents, TokenBase nextTokenFromPreviousStatement)
        {
            Parents = parents;
            NextTokenFromCurrentStatement = nextTokenFromPreviousStatement;
        }

        /// <summary>
        /// Gets the statements that are parents of the current statement
        /// </summary>
        /// <example>
        /// When parsing for member statements, the context should provide the class and namespace statement as parent
        /// </example>
        public IEnumerable<StatementParent> Parents { get; private set; }
        /// <summary>
        /// Gets the next non-whitespace token after the current statement
        /// </summary>
        public TokenBase NextTokenFromCurrentStatement { get; private set; }

        /// <summary>
        /// Checks if the next token from previous statement is of the specified type
        /// </summary>
        /// <typeparam name="TTokenType">The type to check</typeparam>
        /// <returns>True if of that type, false if not</returns>
        public bool IsNextToken<TTokenType>() where TTokenType : TokenBase
        {
            if (NextTokenFromCurrentStatement == null)
                return false;
            else
                return NextTokenFromCurrentStatement.GetType().IsAssignableFrom(typeof(TTokenType));
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            StatementContext context = (StatementContext)obj;
            if (Parents.SequenceEqual(context.Parents) == false) return false;
            if (NextTokenFromCurrentStatement.Equals(context.NextTokenFromCurrentStatement) == false) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 3;
            hash ^= Parents.GetHashCode();
            hash ^= NextTokenFromCurrentStatement.GetHashCode();
            return hash;
        }
    }
}
