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
    }
}
