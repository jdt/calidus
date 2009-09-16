using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;

namespace JDT.Calidus.Common.Blocks
{
    /// <summary>
    /// This class is the base class for classes representing a block
    /// </summary>
    /// <remarks>
    /// A block is a collection of statements that make up a list statements that have something in common
    /// </remarks>
    public abstract class BlockBase
    {
        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="statements">The list of statments in the blocks</param>
        protected BlockBase(IEnumerable<StatementBase> statements)
        {
            Statements = statements;
        }

        /// <summary>
        /// Get the statements contained in the block
        /// </summary>
        public IEnumerable<StatementBase> Statements { get; private set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            BlockBase theBlock = (BlockBase)obj;
            if (theBlock.Statements.SequenceEqual(Statements) == false) return false;
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 33;
            hash ^= Statements.GetHashCode();
            return hash;
        }
    }
}