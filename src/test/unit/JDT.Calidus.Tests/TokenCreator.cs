using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Tokens;
using JDT.Calidus.Tokens.Common;

namespace JDT.Calidus.Tests
{
    /// <summary>
    /// This class creates tokens with line, column and position information
    /// automatically filled in
    /// </summary>
    public class TokenCreator
    {
        private int _currentLine;
        private int _currentColumn;
        private int _currentPosition;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public TokenCreator()
        {
            _currentLine = 1;
            _currentColumn = 1;
            _currentPosition = 0;
        }

        /// <summary>
        /// Creates a new token at the next position
        /// </summary>
        /// <typeparam name="TTokenType">The token type</typeparam>
        /// <param name="content">The token content</param>
        /// <returns>The requested token</returns>
        public TokenBase Create<TTokenType>(String content) where TTokenType:TokenBase
        {
            object[] args = new object[] { _currentLine, _currentColumn, _currentPosition, content };
            TokenBase result = (TTokenType)Activator.CreateInstance(typeof(TTokenType), args);

            UpdateInformation(result);

            return result;
        }

        /// <summary>
        /// Creates a new token at the next position
        /// </summary>
        /// <typeparam name="TTokenType">The token type</typeparam>
        /// <param name="content">The token content</param>
        /// <param name="hint">The token hint</param>
        /// <returns>The requested token</returns>
        public TokenBase Create<TTokenType>(String content, object hint)
            where TTokenType : GenericToken
        {
            object[] args = new object[] { _currentLine, _currentColumn, _currentPosition, content, hint };
            TokenBase result = (TTokenType)Activator.CreateInstance(typeof(TTokenType), args);

            UpdateInformation(result);

            return result;
        }

        /// <summary>
        /// Creates a new token at the next position
        /// </summary>
        /// <typeparam name="TTokenType">The token type</typeparam>
        /// <returns>The requested token</returns>
        public TokenBase Create<TTokenType>()
            where TTokenType : TokenBase
        {
            object[] args = new object[] { _currentLine, _currentColumn, _currentPosition };
            TokenBase result = (TTokenType)Activator.CreateInstance(typeof(TTokenType), args);

            UpdateInformation(result);

            return result;
        }

        /// <summary>
        /// Advances position count a number of times
        /// </summary>
        /// <param name="times">The times</param>
        public void Advance(int times)
        {
            _currentPosition += times;
            _currentColumn += times;
        }

        /// <summary>
        /// Adds a number of newlines
        /// </summary>
        /// <param name="number">The number of newlines</param>
        public void NewLine(int number)
        {
            _currentPosition += number;
            _currentLine += number;
            _currentColumn = 1;
        }

        private void UpdateInformation(TokenBase token)
        {
            _currentColumn += token.Content.Length;
            _currentPosition += token.Content.Length;

            if(token is NewLineToken)
            {
                _currentColumn = 1;
                _currentLine++;
            }
        }
    }
}
