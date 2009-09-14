using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Parsers.Tokens;
using JDT.Calidus.Projects.Events;
using JDT.Calidus.Rules;

namespace JDT.Calidus.Projects
{
    /// <summary>
    /// This class is the main runner that validates rules by parsing files
    /// </summary>
    public class RuleRunner
    {
        /// <summary>
        /// Starts the runner
        /// </summary>
        /// <param name="project">The project to run against</param>
        public void Run(CalidusProject project)
        {
            //raise started
            if (Started != null)
                Started(this, new EventArgs());

            IList<RuleViolation> violations = new List<RuleViolation>();

            CalidusTokenParser parser = new CalidusTokenParser();
            CalidusStatementParser statementParser = new CalidusStatementParser();

            CalidusRuleProvider ruleProvider = new CalidusRuleProvider();

            IEnumerable<String> filesToCheck = project.GetSourceFilesToValidate();

            int currentFile = 0;
            int totalFiles = filesToCheck.Count();

            foreach (String aFile in filesToCheck)
            {
                currentFile++;
                IEnumerable<TokenBase> parsedTokens = parser.Parse(File.ReadAllText(aFile));
                IEnumerable<StatementBase> parsedStatements = statementParser.Parse(parsedTokens);
                IList<RuleViolation> currentFileViolations = new List<RuleViolation>();

                foreach (StatementRuleBase aStatementRule in ruleProvider.GetStatementRules())
                {
                    foreach (StatementBase aStatement in parsedStatements)
                    {
                        if (aStatementRule.Validates(aStatement))
                        {
                            if (aStatementRule.IsValidFor(aStatement) == false)
                                currentFileViolations.Add(new RuleViolation(aFile, aStatementRule, aStatement));
                        }
                    }
                }

                //raise file completed
                FileCompletedEventArgs args = new FileCompletedEventArgs(aFile, currentFile, totalFiles, currentFileViolations);
                if (FileCompleted != null)
                    FileCompleted(this, args);

                //add violations to whole list
                foreach (RuleViolation aViolation in currentFileViolations)
                    violations.Add(aViolation);
            }
            //raise completed
            if (Completed != null)
                Completed(this, new RuleRunnerEventArgs(violations));
        }

        /// <summary>
        /// Event handler for the completion of the runner
        /// </summary>
        /// <param name="source">The event source</param>
        /// <param name="e">The event arguments</param>
        public delegate void RuleRunnerCompletedHandler(object source, RuleRunnerEventArgs e);
        /// <summary>
        /// This event is raised upon completion of the runner
        /// </summary>
        public event RuleRunnerCompletedHandler Completed;

        /// <summary>
        /// Event handler for the start of the runner
        /// </summary>
        /// <param name="source">The event source</param>
        /// <param name="e">The event arguments</param>
        public delegate void RuleRunnerStartedHandler(object source, EventArgs e);
        /// <summary>
        /// This event is raised on the start of the runner
        /// </summary>
        public event RuleRunnerStartedHandler Started;

        /// <summary>
        /// Event handler for the completion of operations on a file
        /// </summary>
        /// <param name="source">The event source</param>
        /// <param name="e">The event arguments</param>
        public delegate void RuleRunnerFileCompleted(object source, FileCompletedEventArgs e);
        /// <summary>
        /// This event is raised when a single file is parsed
        /// </summary>
        public event RuleRunnerFileCompleted FileCompleted;
    }
}