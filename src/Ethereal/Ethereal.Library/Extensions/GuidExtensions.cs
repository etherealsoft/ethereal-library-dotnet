using System;
using System.Diagnostics;

namespace Ethereal.Library.Extensions
{
    public static class GuidExtensions
    {
        [DebuggerStepThrough]
        public static bool IsEmpty(this Guid self)
        {
            return self == Guid.Empty;
        }

        [DebuggerStepThrough]
        public static string Shrink(this Guid self)
        {
            Invariant.IsNotEmpty(self, nameof(self));

            var base64 = Convert.ToBase64String(self.ToByteArray());
            var encoded = base64.Replace("/", "_").Replace("+", "-");

            return encoded.Substring(0, 22);
        }
    }
}
