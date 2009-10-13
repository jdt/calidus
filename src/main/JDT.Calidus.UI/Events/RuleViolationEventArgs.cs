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

namespace JDT.Calidus.UI.Events
{
    /// <summary>
    /// This class represents event arguments for rule violations
    /// </summary>
    public class RuleViolationEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="violation">The violation of the event</param>
        public RuleViolationEventArgs(RuleViolation violation)
        {
            Violation = violation;
        }

        /// <summary>
        /// Get the violation in the event
        /// </summary>
        public RuleViolation Violation { get; private set; }
    }
}
