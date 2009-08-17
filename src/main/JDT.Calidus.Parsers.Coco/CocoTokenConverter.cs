using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Tokens.Common;
using JDT.Calidus.Tokens;

namespace JDT.Calidus.Parsers.Coco
{
    /// <summary>
    /// This class converts Coco tokens to Calidus tokens
    /// </summary>
    public static class CocoTokenConverter
    {
        /// <summary>
        /// Converts the supplied token to a Calidus token
        /// </summary>
        /// <param name="token">The coco token</param>
        /// <returns>The Calidus tokens</returns>
        public static TokenBase Convert(Token token)
        {
            switch (token.kind)
            {
                case 1:
                    return CreateTokenInstance<IdentifierToken>(token);
                default:
                    return CreateTokenInstance<GenericToken>(token);
            }
        }

        //creates a basic instance with line, column, position and value information
        private static TToken CreateTokenInstance<TToken>(Token token)
        {
            object[] args = new object[] { token.line, token.col, token.pos, token.val };
            return (TToken)Activator.CreateInstance(typeof(TToken), args);
        }
    }
}
