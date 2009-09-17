using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Blocks.Common;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Blocks.Factories.Common
{
    /// <summary>
    /// This class acts as a factory for file blocks
    /// </summary>
    public class FileBlockFactory : IBlockFactory
    {        
        /// <summary>
        /// Resolves the statement list into blocks
        /// </summary>
        /// <param name="input">The statements to parse</param>
        /// <returns>The blocks</returns>
        public IEnumerable<BlockBase> Create(IEnumerable<StatementBase> input)
        {
            return new[] {new FileBlock(input)};
        }
    }
}
