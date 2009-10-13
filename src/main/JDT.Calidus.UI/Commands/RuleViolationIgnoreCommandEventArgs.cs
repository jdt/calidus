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

namespace JDT.Calidus.UI.Commands
{
    /// <summary>
    /// This class represents a violation ignore command
    /// </summary>
    public class RuleViolationIgnoreCommandEventArgs : EventArgs
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="violation">The violation</param>
        /// <param name="ignoreType">The ignore type</param>
        public RuleViolationIgnoreCommandEventArgs(RuleViolation violation, RuleViolationIgnoreType ignoreType)
        {
            Violation = violation;
            IgnoreType = ignoreType;
        }

        /// <summary>
        /// Get the violation
        /// </summary>
        public RuleViolation Violation { get; private set; }
        /// <summary>
        /// Get the rule violation ignore type
        /// </summary>
        public RuleViolationIgnoreType IgnoreType { get; private set; }
    }
}
