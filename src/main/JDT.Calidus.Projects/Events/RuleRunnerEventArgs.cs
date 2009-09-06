using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;

namespace JDT.Calidus.Projects.Events
{
    /// <summary>
    /// This class represents the result of a rule runner complete run
    /// </summary>
    public class RuleRunnerEventArgs : EventArgs
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="violations">The list of violations</param>
        public RuleRunnerEventArgs(IEnumerable<RuleViolation> violations)
        {
            Violations = violations;
        }

        /// <summary>
        /// Gets a list of violations for the run
        /// </summary>
        public IEnumerable<RuleViolation> Violations { get; private set; }
    }
}
