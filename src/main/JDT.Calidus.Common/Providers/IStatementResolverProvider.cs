using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Statements;

namespace JDT.Calidus.Common.Providers
{
    /// <summary>
    /// This interface is implemented by providers of statement resolvers
    /// </summary>
    public interface IStatementResolverProvider
    {
        /// <summary>
        /// Loads the resolvers from the provider
        /// </summary>
        /// <returns>The resolvers</returns>
        IEnumerable<IStatementResolver> GetResolvers();
    }
}