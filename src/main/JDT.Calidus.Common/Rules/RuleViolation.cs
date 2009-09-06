using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public RuleViolation(String file, IRule violatedRule)
        {
            File = file;
            ViolatedRule = violatedRule;
        }

        /// <summary>
        /// Get the file the violation occured in
        /// </summary>
        public String File { get; private set; }
        /// <summary>
        /// Get the rule the violation occured in
        /// </summary>
        public IRule ViolatedRule { get; private set; }    
    }
}
