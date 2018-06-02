using System;

namespace Ethereal.Library
{
    public abstract class TimeProvider
    {
        private static TimeProvider _current = DefaultTimeProvider.Instance;
        public static TimeProvider Current { get; set; } = _current;

        public abstract DateTime Now { get; }
        public abstract DateTime UtcNow { get; }
        public abstract DateTime Today { get; }

        public static void Reset() => Current = _current;
  }
}
