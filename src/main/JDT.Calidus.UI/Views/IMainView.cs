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
using JDT.Calidus.UI.Model;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UI.Views
{
    /// <summary>
    /// This interface is implemented by main project views
    /// </summary>
    public interface IMainView
    {
        /// <summary>
        /// Exits the application
        /// </summary>
        void Exit();
        /// <summary>
        /// Signals the beginning of a long-running operation
        /// </summary>
        void BeginWait();
        /// <summary>
        /// Signals the end of a long-running operation
        /// </summary>
        void EndWait();
        /// <summary>
        /// Marks changes to the project
        /// </summary>
        /// <param name="hasChanges">True if changed, otherwise false</param>
        void ProjectHasChanges(bool hasChanges);
        /// <summary>
        /// Prompts the UI to confirm saving changes
        /// </summary>
        /// <returns>The confirmation result</returns>
        Confirm ConfirmSaveChanges();
        /// <summary>
        /// Browses for a project file
        /// </summary>
        /// <returns>The result</returns>
        FileBrowseResult OpenProjectFile();
        /// <summary>
        /// Displays the project configuration for the model
        /// </summary>
        /// <param name="model">The model to display for</param>
        void ShowProjectConfiguration(CalidusProjectModel model);
        /// <summary>
        /// Displays the rule configuration
        /// </summary>
        void ShowRuleConfiguration();
        /// <summary>
        /// Sets the current rpoject
        /// </summary>
        String SelectedProject { set; }
        /// <summary>
        /// Gets the status view
        /// </summary>
        IStatusView StatusView { get; }
        /// <summary>
        /// Gets the rule runner view
        /// </summary>
        IRuleRunnerView RuleRunnerView { get; }
        /// <summary>
        /// Gets the source location view
        /// </summary>
        ISourceLocationView SourceLocationView { get; }
        /// <summary>
        /// Gets the checkabel rule tree view
        /// </summary>
        ICheckableRuleTreeView CheckableRuleTreeView { get; }
        /// <summary>
        /// Gets the file list view
        /// </summary>
        IFileTreeView FileListView { get; }
        /// <summary>
        /// Gets the violation list view
        /// </summary>
        IViolationListView ViolationListView { get; }
        /// <summary>
        /// Notifies that the quit was called
        /// </summary>
        event EventHandler<QuitEventArgs> Quit;
        /// <summary>
        /// Notifies that open was called
        /// </summary>
        event EventHandler<EventArgs> Open;
        /// <summary>
        /// Notifies that save was called
        /// </summary>
        event EventHandler<EventArgs> Save;
        /// <summary>
        /// Notifies that project configuration was called
        /// </summary>
        event EventHandler<EventArgs> ProjectConfiguration;
        /// <summary>
        /// Notifies that rule configuration was called
        /// </summary>
        event EventHandler<EventArgs> RuleConfiguration;
    }
}
