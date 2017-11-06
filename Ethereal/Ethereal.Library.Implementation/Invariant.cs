using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ethereal.Library
{
    public class Invariant : IInvariant
    {
        [DebuggerStepThrough]
        public void HasMaxLength(string argument, int maxLength, string name = "parameter")
        {
            if (maxLength < 0)
            {
                throw new InvalidOperationException("Must not specify a max length less than zero.");
            }

            if (argument.Length > maxLength)
            {
                throw new ArgumentException($"{name} must not have length greater than {maxLength}.");
            }
        }
        
        [DebuggerStepThrough]
        public void HasMaxLength<T>(IEnumerable<T> argument, int maxLength, string name = "parameter")
        {
            if (maxLength < 0)
            {
                throw new InvalidOperationException("Must not specify a max length less than zero.");
            }

            if (argument.Count() > maxLength)
            {
                throw new ArgumentException($"{name} must not have length greater than {maxLength}.");
            }
        }
        
        [DebuggerStepThrough]
        public void HasMinLength(string argument, int minLength, string name = "parameter")
        {
            if (minLength < 0)
            {
                throw new InvalidOperationException("Must not specify a min length less than zero.");
            }

            if (argument.Length < minLength)
            {
                throw new ArgumentException($"{name} must not have length less than {minLength}.");
            }
        }
        
        [DebuggerStepThrough]
        public void HasMinLength<T>(IEnumerable<T> argument, int minLength, string name = "parameter")
        {
            if (minLength < 0)
            {
                throw new InvalidOperationException("Must not specify a min length less than zero.");
            }

            if (argument.Count() < minLength)
            {
                throw new ArgumentException($"{name} must not have length less than {minLength}.");
            }
        }
        
        [DebuggerStepThrough]
        public void IsAtLeast<T>(T argument, T min, string name = "parameter") where T : IComparable
        {
            if (argument.CompareTo(min) < 0)
            {
                throw new ArgumentException($"{name} must not be less than {min}.");
            }
        }
        
        [DebuggerStepThrough]
        public void IsAtMost<T>(T argument, T max, string name = "parameter") where T : IComparable
        {
            if (argument.CompareTo(max) > 0)
            {
                throw new ArgumentException($"{name} must not be greater than {max}.");
            }
        }
    }
}
