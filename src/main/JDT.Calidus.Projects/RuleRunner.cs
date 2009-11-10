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
using System.IO;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Lines;
using JDT.Calidus.Common.Projects;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.Common.Rules.Blocks;
using JDT.Calidus.Common.Rules.Lines;
using JDT.Calidus.Common.Rules.Statements;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Parsers.Blocks;
using JDT.Calidus.Parsers.Lines;
using JDT.Calidus.Parsers.Statements;
using JDT.Calidus.Parsers.Tokens;
using JDT.Calidus.Rules;
using JDT.Calidus.Common.Projects.Events;

namespace JDT.Calidus.Projects
{
    /// <summary>
    /// This class is the main runner that validates rules by parsing files
    /// </summary>
    public class RuleRunner : IRuleRunner
    {
        /// <summary>
        /// Starts the runner
        /// </summary>
        /// <param name="project">The project to run against</param>
        public void Run(ICalidusProject project)
        {
            //raise started
            if (Started != null)
                Started(this, new EventArgs());

            IList<RuleViolation> violations = new List<RuleViolation>();

            CalidusTokenParser parser = new CalidusTokenParser();
            CalidusStatementParser statementParser = new CalidusStatementParser();
            CalidusBlockParser blockParser = new CalidusBlockParser();
            CalidusLineParser lineParser = new CalidusLineParser();

            CalidusRuleProvider ruleProvider = new CalidusRuleProvider();

            IEnumerable<String> filesToCheck = project.GetSourceFilesToValidate();

            int currentFile = 0;
            int totalFiles = filesToCheck.Count();

            foreach (String aFile in filesToCheck)
            {
                currentFile++;
                IEnumerable<TokenBase> parsedTokens = parser.Parse(File.ReadAllText(aFile));
                IEnumerable<StatementBase> parsedStatements = statementParser.Parse(parsedTokens);
                IEnumerable<BlockBase> parsedBlocks = blockParser.Parse(parsedStatements);
                IEnumerable<LineBase> parsedLines = lineParser.Parse(parsedTokens);

                IList<RuleViolation> currentFileViolations = new List<RuleViolation>();

                foreach (StatementRuleBase aStatementRule in ruleProvider.GetStatementRules(project.GetProjectRuleConfigurations()))
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

                foreach (BlockRuleBase aBlockRule in ruleProvider.GetBlockRules(project.GetProjectRuleConfigurations()))
                {
                    foreach (BlockBase aBlock in parsedBlocks)
                    {
                        if (aBlockRule.Validates(aBlock))
                        {
                            if (aBlockRule.IsValidFor(aBlock) == false)
                                currentFileViolations.Add(new RuleViolation(aFile, aBlockRule, aBlock.Statements.ElementAt(0)));
                        }
                    }
                }

                foreach (LineRuleBase aLineRule in ruleProvider.GetLineRules(project.GetProjectRuleConfigurations()))
                {
                    foreach (LineBase aLine in parsedLines)
                    {
                        if (aLineRule.Validates(aLine))
                        {
                            if (aLineRule.IsValidFor(aLine) == false)
                                currentFileViolations.Add(new RuleViolation(aFile, aLineRule, aLine.Tokens));
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
        /// This event is raised upon completion of the runner
        /// </summary>
        public event EventHandler<RuleRunnerEventArgs> Completed;
        /// <summary>
        /// This event is raised on the start of the runner
        /// </summary>
        public event EventHandler<EventArgs> Started;
        /// <summary>
        /// This event is raised when a single file is parsed
        /// </summary>
        public event EventHandler<FileCompletedEventArgs> FileCompleted;
    }
}