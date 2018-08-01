using System.Collections.Generic;
using System.Diagnostics;

namespace Ethereal.Library.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Determines if a collection is null or empty.
        /// </summary>
        /// <param name="source">The collection.</param>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <returns>True if <paramref name="source"/> is null or empty. False otherwise.</returns>
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count == 0;
        }
    }
}
