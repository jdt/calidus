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
using JDT.Calidus.Statements.Common;

namespace JDT.Calidus.Parsers.Statements
{
    /// <summary>
    /// This class is the default implementation of a statement context manager
    /// </summary>
    public class StatementContextManager : IStatementContextManager
    {
        private IList<StatementParent> _parentList;

        private IEnumerable<StatementBase> _previousEncounters;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public StatementContextManager()
        {
            _parentList = new List<StatementParent>();
        }

        /// <summary>
        /// Notifies the manager that a list of tokens was parsed into a number of statements
        /// </summary>
        /// <param name="statements">The list of statements</param>
        public void Encountered(IEnumerable<StatementBase> statements)
        {
            StatementBase openBlock = statements.SingleOrDefault(p => p.GetType().Equals(typeof(OpenBlockStatement)));
            StatementBase closeBlock = statements.SingleOrDefault(p => p.GetType().Equals(typeof(CloseBlockStatement)));

            if(openBlock != null)
                _parentList.Add(new StatementParent(_previousEncounters, openBlock));
            if (closeBlock != null)
                _parentList.RemoveAt(_parentList.Count - 1);

            _previousEncounters = statements;
        }

        /// <summary>
        /// Gets the current context
        /// </summary>
        /// <returns>The context</returns>
        public IStatementContext GetContext()
        {
            return new StatementContext(_parentList);
        }
    }
}