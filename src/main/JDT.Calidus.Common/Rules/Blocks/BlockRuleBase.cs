using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Blocks;

namespace JDT.Calidus.Common.Rules.Blocks
{
    /// <summary>
    /// This class is the base class for all block rules
    /// </summary>
    public abstract class BlockRuleBase : IRule
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="category">The rule category</param>
        protected BlockRuleBase(String category)
        {
            Category = category;
        }

        /// <summary>
        /// Gets the rule name
        /// </summary>
        public String Name
        {
            get
            {
                return GetType().Name;
            }
        }

        /// <summary>
        /// Gets the rule category
        /// </summary>
        public String Category { get; private set; }

        /// <summary>
        /// Checks if the rule validates the supplied block
        /// </summary>
        /// <param name="block">The block</param>
        /// <returns>True if validates, otherwise false</returns>
        public abstract bool Validates(BlockBase block);
        /// <summary>
        /// Checks if the rule is valid for the block
        /// </summary>
        /// <param name="block">The block</param>
        /// <returns>True if valid, otherwise false</returns>
        public abstract bool IsValidFor(BlockBase block);
    }
}