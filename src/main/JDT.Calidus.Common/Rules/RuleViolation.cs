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
        /// <param name="violatingTokens">The list of tokens that violate the rule</param>
        public RuleViolation(String file, IRule violatedRule, IEnumerable<TokenBase> violatingTokens)
        {
            File = file;
            ViolatedRule = violatedRule;
            ViolatingTokens = violatingTokens;
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="violatedRule">The violated rule</param>
        /// <param name="statement">The statement that violates the rule</param>
        public RuleViolation(String file, IRule violatedRule, StatementBase statement)
        {
            File = file;
            ViolatedRule = violatedRule;
            ViolatingTokens = statement.Tokens;
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
        /// Get the list of tokens that violated the rule
        /// </summary>
        public IEnumerable<TokenBase> ViolatingTokens { get; private set; }
        
        /// <summary>
        /// Gets the first token in the violating statement
        /// </summary>
        public TokenBase FirstToken
        {
            get
            {
                return ViolatingTokens.ElementAt(0);
            }
        }
    }
}
