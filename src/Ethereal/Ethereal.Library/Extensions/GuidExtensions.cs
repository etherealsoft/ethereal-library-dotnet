using System;
using System.Diagnostics;

namespace Ethereal.Library.Extensions
{
    public static class GuidExtensions
    {
        private const int SHRUNKEN_GUID_LENGTH = 22;

        /// <summary>
        /// Determines if a Guid is the empty Guid.
        /// </summary>
        /// <param name="source">The Guid.</param>
        /// <returns>True if <paramref name="source"/> is the empty Guid. False otherwise.</returns>
        [DebuggerStepThrough]
        public static bool IsEmpty(this Guid source)
        {
            return source == Guid.Empty;
        }

        /// <summary>
        /// Shrinks a Guid without compromising uniqueness.
        /// </summary>
        /// <param name="source">The Guid to shrink.</param>
        /// <returns>The base64 encoded string value.</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="source"> is the empty guid.
        /// </exception>
        [DebuggerStepThrough]
        public static string Shrink(this Guid source)
        {
            Invariant.IsNotEmpty(source, nameof(source));

            var base64 = Convert.ToBase64String(source.ToByteArray());
            var encoded = base64.Replace("/", "_").Replace("+", "-");

            return encoded.Substring(0, SHRUNKEN_GUID_LENGTH);
        }

        /// <summary>
        /// Expands a shrunken Guid.
        /// </summary>
        /// <param name="source">The shrunken Guid.</param>
        /// <returns>The expanded Guid.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="source"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static Guid ExpandGuid(this string source)
        {
            Invariant.IsNotNull(source, nameof(source));

            var result = Guid.Empty;

            if (source.Length == SHRUNKEN_GUID_LENGTH)
            {
                var encoded = string.Concat(source.Replace("-", "+").Replace("_", "/"), "==");

                try
                {
                    var base64 = Convert.FromBase64String(encoded);

                    result = new Guid(base64);
                }
                catch (FormatException)
                {
                }
            }

            return result;
        }
    }
}
