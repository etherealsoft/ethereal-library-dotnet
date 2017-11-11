using System;

namespace Ethereal.Library
{
    public interface ISystemTime
    {
        Func<DateTime> Now { get; }

        Func<DateTime> UtcNow { get; }

        Func<DateTime> Today { get; }
    }
}
