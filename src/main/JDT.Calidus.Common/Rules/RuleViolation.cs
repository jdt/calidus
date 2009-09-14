using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Common.Rules
{
    /// <summary>
    /// This class represents a rule violation
    /// </summary>
    public class RuleViolation
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="violatedRule">The violated rule</param>
        /// <param name="violatingStatement">The statement that violates the rule</param>
        public RuleViolation(String file, IRule violatedRule, StatementBase violatingStatement)
        {
            File = file;
            ViolatedRule = violatedRule;
            ViolatingStatement = violatingStatement;
        }

        /// <summary>
        /// Get the file the violation occured in
        /// </summary>
        public String File { get; private set; }
        /// <summary>
        /// Get the rule the violation occured in
        /// </summary>
        public IRule ViolatedRule { get; private set; }
        /// <summary>
        /// Get the statement that violated the rule
        /// </summary>
        public StatementBase ViolatingStatement { get; private set; }
        
        /// <summary>
        /// Gets the first token in the violating statement
        /// </summary>
        public TokenBase FirstToken
        {
            get
            {
                return ViolatingStatement.Tokens.ElementAt(0);
            }
        }
    }
}
