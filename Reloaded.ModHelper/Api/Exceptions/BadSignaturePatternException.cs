using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to indicate that a bad pattern was provided when creating a <see cref="Signature"/>.
    /// </summary>
    public class BadSignaturePatternException : Exception
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string Message => "The Signature Pattern Provided was not valid";

        /// <summary>
        /// Initializes a new instance of <see cref="BadSignaturePatternException"/>.
        /// </summary>
        public BadSignaturePatternException()
        {
            
        }
    }
}
