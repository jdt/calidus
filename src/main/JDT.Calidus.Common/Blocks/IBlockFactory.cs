using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Common.Blocks
{
    /// <summary>
    /// This interface is implemented by block factories that create blocks from a list of statements
    /// </summary>
    public interface IBlockFactory
    {
        /// <summary>
        /// Resolves the statement list into blocks
        /// </summary>
        /// <param name="input">The statements to parse</param>
        /// <returns>The blocks</returns>
        IEnumerable<BlockBase> Create(IEnumerable<StatementBase> input);
    }
}
