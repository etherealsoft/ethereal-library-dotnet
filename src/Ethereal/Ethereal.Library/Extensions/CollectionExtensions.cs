using System.Collections.Generic;
using System.Diagnostics;

namespace Ethereal.Library.Extensions
{
    public static class CollectionExtensions
    {
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this ICollection<T> self)
        {
            return self == null || self.Count == 0;
        }
    }
}
