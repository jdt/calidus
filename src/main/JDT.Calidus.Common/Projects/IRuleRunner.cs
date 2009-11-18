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
using JDT.Calidus.Common.Projects.Events;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.Common.Projects
{
    /// <summary>
    /// This interface is implemented by rule runners
    /// </summary>
    public interface IRuleRunner
    {        
        /// <summary>
        /// Starts the runner
        /// </summary>
        /// <param name="configFactory">The configuration factory</param>
        /// <param name="project">The project to run against</param>
        void Run(ICalidusRuleConfigurationFactory configFactory, ICalidusProject project);
        /// <summary>
        /// This event is raised upon completion of the runner
        /// </summary>
        event EventHandler<RuleRunnerEventArgs> Completed;
        /// <summary>
        /// This event is raised on the start of the runner
        /// </summary>
        event EventHandler<EventArgs> Started;
        /// <summary>
        /// This event is raised when a single file is parsed
        /// </summary>
        event EventHandler<FileCompletedEventArgs> FileCompleted;
    }
}
