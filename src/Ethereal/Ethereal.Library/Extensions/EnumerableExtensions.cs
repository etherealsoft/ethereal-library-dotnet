using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ethereal.Library.Extensions
{
    public static class EnumerableExtensions
    {
        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self)
            {
                action(item);
            }
        }
    }
}
