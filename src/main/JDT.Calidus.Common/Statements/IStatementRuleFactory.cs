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

namespace JDT.Calidus.Common.Statements
{
    /// <summary>
    /// This interface is implemented by statement rule factories
    /// </summary>
    public interface IStatementRuleFactory
    {
        /// <summary>
        /// Gets the list of statement rules in the specified project
        /// </summary>
        /// <param name="configFactory">The configuration factory to use</param>
        /// <returns>The rules</returns>
        IEnumerable<StatementRuleBase> GetStatementRules(ICalidusRuleConfigurationFactory configFactory);
    }
}
