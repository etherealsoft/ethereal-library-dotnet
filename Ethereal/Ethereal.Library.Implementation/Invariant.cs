﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ethereal.Library
{
    public class Invariant : IInvariant
    {
        private readonly ISystemTime _systemTime;

        public Invariant(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }

        [DebuggerStepThrough]
        public void HasMaxLength(string argument, int maxLength, string name)
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
        public void HasMaxLength<T>(IEnumerable<T> argument, int maxLength, string name)
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
        public void HasMinLength(string argument, int minLength, string name)
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
        public void HasMinLength<T>(IEnumerable<T> argument, int minLength, string name)
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
        public void IsAtLeast<T>(T argument, T min, string name) where T : IComparable
        {
            if (argument.CompareTo(min) < 0)
            {
                throw new ArgumentException($"{name} must not be less than {min}.");
            }
        }

        [DebuggerStepThrough]
        public void IsAtMost<T>(T argument, T max, string name) where T : IComparable
        {
            if (argument.CompareTo(max) > 0)
            {
                throw new ArgumentException($"{name} must not be greater than {max}.");
            }
        }

        [DebuggerStepThrough]
        public void IsInInterval<T>(T argument, T min, T max, string name) where T : IComparable
        {
            if (max.CompareTo(min) < 0)
            {
                throw new InvalidOperationException("Max must not be less than min.");
            }

            IsAtLeast(argument, min, name);
            IsAtMost(argument, max, name);
        }

        [DebuggerStepThrough]
        public void IsNotEmpty(Guid argument, string name)
        {
            if (argument == Guid.Empty)
            {
                throw new ArgumentException($"{name} must not be the empty guid.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotEmpty(string argument, string name)
        {
            if (argument == string.Empty)
            {
                throw new ArgumentException($"{name} must not be empty.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotInFuture(DateTime argument, string name)
        {
            if (argument > _systemTime.Now())
            {
                throw new ArgumentException($"{name} must not be in the future.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotInFutureUtc(DateTime argument, string name)
        {
            if (argument > _systemTime.UtcNow())
            {
                throw new ArgumentException($"{name} must not be in the future.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotInPast(DateTime argument, string name)
        {
            if (argument < _systemTime.Now())
            {
                throw new ArgumentException($"{name} must not be in the past.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotInPastUtc(DateTime argument, string name)
        {
            if (argument < _systemTime.UtcNow())
            {
                throw new ArgumentException($"{name} must not be in the past.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegative(int argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"{name} must not have a negative value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegative(long argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"{name} must not have a negative value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegative(float argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"{name} must not have a negative value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegative(decimal argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"{name} must not have a negative value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegative(TimeSpan argument, string name)
        {
            if (argument < TimeSpan.Zero)
            {
                throw new ArgumentException($"{name} must not have a negative value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegativeOrZero(int argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"{name} must not have a negative or zero value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegativeOrZero(long argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"{name} must not have a negative or zero value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegativeOrZero(float argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"{name} must not have a negative or zero value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegativeOrZero(decimal argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"{name} must not have a negative or zero value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNegativeOrZero(TimeSpan argument, string name)
        {
            if (argument <= TimeSpan.Zero)
            {
                throw new ArgumentException($"{name} must not have a negative or zero value.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNull(object argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        [DebuggerStepThrough]
        public void IsNotNull<T>(T argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        [DebuggerStepThrough]
        public void IsNotNullOrEmpty(string argument, string name)
        {
            IsNotNull(argument, name);

            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentException($"{name} must not be an empty string.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNullOrEmpty<T>(IEnumerable<T> argument, string name)
        {
            IsNotNull(argument, name);

            if (!argument.Any())
            {
                throw new ArgumentException($"{name} must not be empty.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotNullOrWhitespace(string argument, string name)
        {
            IsNotNull(argument, name);

            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException($"{name} must not be empty or whitespace.");
            }
        }

        [DebuggerStepThrough]
        public void IsNotWhitespace(string argument, string name)
        {
            if (argument != null && string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException($"{name} must not be empty or whitespace.");
            }
        }

        [DebuggerStepThrough]
        public void IsValidModel<T>(T argument)
        {
            var context = new ValidationContext(argument, null, null);
            Validator.ValidateObject(argument, context, true);
        }

        public void IsValidProperty<T>(T argument, object value, string name)
        {
            var context = new ValidationContext(argument, null, null) { MemberName = name };
            Validator.ValidateProperty(value, context);
        }

        [DebuggerStepThrough]
        public void MatchesRegex(string argument, string expression, string name)
        {
            IsNotNull(argument, name);

            if (!Regex.IsMatch(argument, expression))
            {
                throw new ArgumentException($"{name} must match regular expression {expression}.");
            }
        }
    }
}
