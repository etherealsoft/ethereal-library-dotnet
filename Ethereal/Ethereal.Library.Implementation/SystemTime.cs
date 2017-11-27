using System;

namespace Ethereal.Library
{
    public class SystemTime : ISystemTime
    {
        public Func<DateTime> Now => () => DateTime.Now;

        public Func<DateTime> UtcNow => () => DateTime.UtcNow;

        public Func<DateTime> Today => () => DateTime.Today;
    }
}
