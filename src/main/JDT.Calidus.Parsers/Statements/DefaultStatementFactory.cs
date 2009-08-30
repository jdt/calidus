using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Providers;
using JDT.Calidus.Common.Statements;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Common;

namespace JDT.Calidus.Parsers.Statements
{
    /// <summary>
    /// This interface is implemented by statement factories
    /// </summary>
    public class DefaultStatementFactory : IStatementFactory
    {
        private IStatementResolverProvider _resolverProvider;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public DefaultStatementFactory()
            : this(ObjectFactory.Get<IStatementResolverProvider>())
        {
        }

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="resolver">The IStatementResolverProvider to use</param>
        public DefaultStatementFactory(IStatementResolverProvider resolverProvider)
        {
            _resolverProvider = resolverProvider;
        }

        /// <summary>
        /// Create a statement based on a token list
        /// </summary>
        /// <param name="tokenList">The token list</param>
        /// <returns>The statement represented by the token list</returns>
        public StatementBase Create(IList<TokenBase> tokenList)
        {
            foreach (IStatementResolver aResolver in _resolverProvider.GetResolvers())
            {
                if (aResolver.CanResolve(tokenList))
                    return aResolver.Resolve(tokenList);
            }
            return new GenericStatement(tokenList);
        }
    }
}
