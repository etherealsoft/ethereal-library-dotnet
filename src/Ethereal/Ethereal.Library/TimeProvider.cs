using System;

namespace Ethereal.Library
{
    public abstract class TimeProvider
    {
        private static TimeProvider _current = DefaultTimeProvider.Instance;

        /// <summary>
        /// The current TimeProvider.
        /// </summary>
        /// <returns>The current TimeProvider.</returns>
        public static TimeProvider Current { get; set; } = _current;

        /// <summary>
        /// An object whose value is the current local date and time.
        /// </summary>
        /// <returns>An object whose value is the current local date and time.</returns>
        public abstract DateTime Now { get; }

        /// <summary>
        /// An object whose value is the current UTC date and time.
        /// </summary>
        /// <returns>An object whose value is the current UTC date and time.</returns>
        public abstract DateTime UtcNow { get; }

        /// <summary>
        /// An object whose value is the current local date.
        /// </summary>
        /// <returns>An object whose value is the current local date.</returns>
        public abstract DateTime Today { get; }

        /// <summary>
        /// Reset the current TimeProvider to the DefaultTimeProvider.
        /// </summary>
        public static void Reset() => Current = _current;
  }
}
