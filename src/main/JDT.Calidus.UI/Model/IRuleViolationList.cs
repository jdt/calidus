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
using JDT.Calidus.UI.Events;
using System.Collections.Generic;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.UI.Model
{
    /// <summary>
    /// This interface is implemented by a rule violation list
    /// </summary>
    public interface IRuleViolationList : IList<RuleViolation>
    {        
        /// <summary>
        /// Notifies that a violation was added to the list
        /// </summary>
        event EventHandler<RuleViolationEventArgs> ViolationAdded;
        /// <summary>
        /// Notifies that a violation was removed from the list
        /// </summary>
        event EventHandler<RuleViolationEventArgs> ViolationRemoved;
    }
}