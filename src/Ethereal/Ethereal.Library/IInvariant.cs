using System;
using System.Collections.Generic;

namespace Ethereal.Library
{
    public interface IInvariant
    {
        void HasMaxLength(string argument, int maxLength, string name);

        void HasMaxLength<T>(IEnumerable<T> argument, int maxLength, string name);

        void HasMinLength(string argument, int minLength, string name);

        void HasMinLength<T>(IEnumerable<T> argument, int minLength, string name);

        void IsAtLeast<T>(T argument, T min, string name) where T : IComparable;

        void IsAtMost<T>(T argument, T max, string name) where T : IComparable;

        void IsInInterval<T>(T argument, T min, T max, string name) where T : IComparable;

        void IsNotEmpty(Guid argument, string name);

        void IsNotEmpty(string argument, string name);

        void IsNotInFuture(DateTime argument, string name);

        void IsNotInFutureUtc(DateTime argument, string name);

        void IsNotInPast(DateTime argument, string name);

        void IsNotInPastUtc(DateTime argument, string name);

        void IsNotNegative(int argument, string name);

        void IsNotNegative(long argument, string name);

        void IsNotNegative(float argument, string name);

        void IsNotNegative(decimal argument, string name);

        void IsNotNegative(TimeSpan argument, string name);

        void IsNotNegativeOrZero(int argument, string name);

        void IsNotNegativeOrZero(long argument, string name);

        void IsNotNegativeOrZero(float argument, string name);

        void IsNotNegativeOrZero(decimal argument, string name);

        void IsNotNegativeOrZero(TimeSpan argument, string name);

        void IsNotNull(object argument, string name);

        void IsNotNull<T>(T argument, string name);

        void IsNotNullOrEmpty(string argument, string name);

        void IsNotNullOrEmpty<T>(IEnumerable<T> argument, string name);

        void IsNotNullOrWhitespace(string argument, string name);

        void IsNotWhitespace(string argument, string name);

        void IsValidModel<T>(T argument);

        void IsValidProperty<T>(T argument, object value, string name);

        void MatchesRegex(string argument, string expression, string name);
    }
}
