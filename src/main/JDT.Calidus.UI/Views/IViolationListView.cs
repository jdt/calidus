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
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UI.Views
{
    /// <summary>
    /// This interface is implemented by views of violation lists
    /// </summary>
    public interface IViolationListView
    {
        /// <summary>
        /// Notifies that the view requested rule violation details
        /// </summary>
        event EventHandler<RuleViolationEventArgs> RuleViolationDetails;
        /// <summary>
        /// Adds a violation to the view
        /// </summary>
        /// <param name="aViolation">The violation to add</param>
        void AddViolation(RuleViolation aViolation);
        /// <summary>
        /// Clears all violations from the view
        /// </summary>
        void ClearViolations();
    }
}
