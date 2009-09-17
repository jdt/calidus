using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Blocks.Common
{
    /// <summary>
    /// This class represents a block containing all the statements in a file
    /// </summary>
    public class FileBlock : BlockBase
    {
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="statements">The statements in the block</param>
        public FileBlock(IEnumerable<StatementBase> statements)
            : base(statements)
        {
        }
    }
}
