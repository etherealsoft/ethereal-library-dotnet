using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Web;

namespace Ethereal.Library.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string into an html attribute encoded string.
        /// </summary>
        /// <param name="source">The string to encode.</param>
        /// <returns>The html attribute endcoded string.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="source"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static string AttributeEncode(this string source)
        {
            Invariant.IsNotNull(source, nameof(source));

            return HttpUtility.HtmlAttributeEncode(source);
        }

        /// <summary>
        /// Decodes a string that was html encoded.
        /// </summary>
        /// <param name="source">The encoded string to decode.</param>
        /// <returns>A decoded html string.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="source"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static string HtmlDecode(this string source)
        {
            Invariant.IsNotNull(source, nameof(source));

            return HttpUtility.HtmlDecode(source);
        }

        /// <summary>
        /// Converts a string into an html encoded string.
        /// </summary>
        /// <param name="source">The string to encode.</param>
        /// <returns>An encoded html string.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="source"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static string HtmlEncode(this string source)
        {
            Invariant.IsNotNull(source, nameof(source));

            return HttpUtility.HtmlEncode(source);
        }

        /// <summary>
        /// Converts an enum valued string to its enum value.
        /// </summary>
        /// <param name="source">The string to be converted.</param>
        /// <returns>The converted enum.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="source"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static T ToEnum<T>(this string source) where T : struct, IComparable, IFormattable
        {
            Invariant.IsNotNull(source, nameof(source));

            Enum.TryParse<T>(source, true, out var value);

            return value;
        }

        /// <summary>
        /// Decodes a string that was url encoded.
        /// </summary>
        /// <param name="source">The string to decode.</param>
        /// <returns>A decoded url string.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="source"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static string UrlDecode(this string source)
        {
            Invariant.IsNotNull(source, nameof(source));

            return HttpUtility.UrlDecode(source);
        }

        /// <summary>
        /// Converts a string into a url encoded string.
        /// </summary>
        /// <param name="source">The url string to encode.</param>
        /// <returns>The encoded url string.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="source"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static string UrlEncode(this string source)
        {
            Invariant.IsNotNull(source, nameof(source));

            return HttpUtility.UrlEncode(source);
        }
    }
}
