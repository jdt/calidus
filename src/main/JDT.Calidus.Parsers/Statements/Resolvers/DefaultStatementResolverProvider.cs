using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT.Calidus.Parsers.Statements.Resolvers
{    
    /// <summary>
    /// This interface is implemented by providers of statement resolvers
    /// </summary>
    public class DefaultStatementResolverProvider : IStatementResolverProvider
    {
        /// <summary>
        /// Loads the resolvers from the provider
        /// </summary>
        /// <returns>The resolvers</returns>
        public IEnumerable<IStatementResolver> GetResolvers()
        {
            return new List<IStatementResolver>();
        }
    }
}
