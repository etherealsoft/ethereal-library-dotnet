using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ethereal.Library.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Executes an action on every element of an enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="action">The action.</param>
        /// <typeparam name="T">The type of the elements in the enumerable.</typeparam>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="source"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Invariant.IsNotNull(source, nameof(source));

            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
