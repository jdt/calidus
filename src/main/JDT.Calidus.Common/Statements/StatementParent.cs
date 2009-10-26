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
    /// This class represents a statement parent
    /// </summary>
    public class StatementParent
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="statements">The statements</param>
        /// <param name="delimiter">The delimiter</param>
        public StatementParent(IEnumerable<StatementBase> statements, StatementBase delimiter)
        {
            Statements = statements;
            Delimiter = delimiter;
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="statement">The statement</param>
        /// <param name="delimiter">The delimiter</param>
        public StatementParent(StatementBase statement, StatementBase delimiter)
            : this(new[]{statement}, delimiter)
        {
        }

        /// <summary>
        /// The statements parsed from the parent list of tokens
        /// </summary>
        public IEnumerable<StatementBase> Statements { get; private set; }
        /// <summary>
        /// The delimiter used
        /// </summary>
        public StatementBase Delimiter { get; private set; }

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

            StatementParent parent = (StatementParent)obj;
            if (Statements.SequenceEqual(parent.Statements) == false) return false;
            if (StatementBase.Equals(Delimiter, parent.Delimiter) == false) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 7;
            hash ^= Statements.GetHashCode();
            hash ^= Delimiter.GetHashCode();
            return hash;
        }
    }
}
