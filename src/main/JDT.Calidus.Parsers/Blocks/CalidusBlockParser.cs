using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common;
using JDT.Calidus.Common.Blocks;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Parsers.Blocks
{
    /// <summary>
    /// This class is the calidus block parser. It parses a full statement list and returns any blocks that could be identified in the list
    /// </summary>
    public class CalidusBlockParser
    {
        private IBlockFactoryProvider _blockFactoryProvider;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public CalidusBlockParser()
            : this(ObjectFactory.Get<IBlockFactoryProvider>())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="blockFactoryProvider">The block factory provider to use</param>
        public CalidusBlockParser(IBlockFactoryProvider blockFactoryProvider)
        {
            _blockFactoryProvider = blockFactoryProvider;
        }

        /// <summary>
        /// Parses the list of statements into blocks
        /// </summary>
        /// <param name="statements">The list of statements</param>
        /// <returns>The list of blocks</returns>
        public IEnumerable<BlockBase> Parse(IEnumerable<StatementBase> statements)
        {
            IList<BlockBase> res = new List<BlockBase>();

            //check all block factories
            foreach (IBlockFactory blockFactory in _blockFactoryProvider.GetFactories())
            {
                foreach (BlockBase aBlock in blockFactory.Create(statements))
                    res.Add(aBlock);
            }

            return res;
        }
    }
}
