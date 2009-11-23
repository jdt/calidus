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

namespace JDT.Calidus.Common.Statements
{
    /// <summary>
    /// This class is the base class for classes representing a statement
    /// </summary>
    /// <remarks>
    /// A statement is the smallest standalone element, which is eiter a semicolon-terminated
    /// list of tokens or a compound statement such as an if, for or while
    /// </remarks>
    public abstract class StatementBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="tokens">The list of tokens in the statement</param>
        /// <param name="context">The context the statement is in</param>
        protected StatementBase(IEnumerable<TokenBase> tokens, IStatementContext context)
        {
            Tokens = tokens;
            Context = context;
        }

        /// <summary>
        /// Get the tokens contained in the statement
        /// </summary>
        public IEnumerable<TokenBase> Tokens { get; private set; }
        /// <summary>
        /// Get the statement context
        /// </summary>
        public IStatementContext Context { get; private set; }

        /// <summary>
        /// Gets the source code in the statement
        /// </summary>
        public String Source
        {
            get
            {
                StringBuilder res = new StringBuilder();
                foreach (TokenBase aToken in Tokens)
                    res.Append(aToken.Content);
                return res.ToString();
            }
        }

        /// <summary>
        /// Finds the first occurence of the specified token type or null if not found
        /// </summary>
        /// <typeparam name="TTokenType">The type to look for</typeparam>
        /// <returns>The token of type or null if not found</returns>
        protected TTokenType FindFirstOccurenceOf<TTokenType>() where TTokenType : TokenBase
        {
            foreach(TokenBase aToken in Tokens)
            {
                if (typeof(TTokenType).IsAssignableFrom(aToken.GetType()))
                    return (TTokenType)aToken;
            }
            return null;
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

            StatementBase theStatement = (StatementBase)obj;
            if (theStatement.Tokens.SequenceEqual(Tokens) == false) return false;
            if (theStatement.Context.Equals(Context) == false) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 33;
            hash ^= Tokens.GetHashCode();
            hash ^= Context.GetHashCode();
            return hash;
        }
    }
}