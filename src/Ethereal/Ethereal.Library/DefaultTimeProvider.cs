using System;

namespace Ethereal.Library
{
    internal sealed class DefaultTimeProvider : TimeProvider
    {
        private DefaultTimeProvider() { }

        public static DefaultTimeProvider Instance { get; } = new DefaultTimeProvider();

        public override DateTime Now => DateTime.Now;
        public override DateTime UtcNow => DateTime.UtcNow;
        public override DateTime Today => DateTime.Today;
    }
}
