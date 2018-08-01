using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ethereal.Library
{
    public static class Invariant
    {
        /// <summary>
        /// Assert the maximum length of a string.
        /// </summary>
        /// <param name="argument">The string argument.</param>
        /// <param name="maxLength">The maximum length of the string argument.</param>
        /// <param name="name">The name of the string argument.</param>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when <paramref name="maxLength"/> is less than zero.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when length of <paramref name="argument"/> is greater than <paramref name="maxLength"/>.
        /// </exception>
        [DebuggerStepThrough]
        public static void HasMaxLength(string argument, int maxLength, string name)
        {
            if (maxLength < 0)
            {
                throw new InvalidOperationException("Must not specify a max length less than zero.");
            }

            if (argument.Length > maxLength)
            {
                throw new ArgumentException($"Argument '{name}' must not have length greater than {maxLength}.");
            }
        }

        /// <summary>
        /// Assert the maximum length of an enumerable.
        /// </summary>
        /// <param name="argument">The enumerable argument.</param>
        /// <param name="maxLength">The maximum length of the enumerable argument.</param>
        /// <param name="name">The name of the enumerable argument.</param>
        /// <typeparam name="T">The type of the elements in the enumerable.</typeparam>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when <paramref name="maxLength"/> is less than zero.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when length of <paramref name="argument"/> is greater than <paramref name="maxLength"/>.
        /// </exception>
        [DebuggerStepThrough]
        public static void HasMaxLength<T>(IEnumerable<T> argument, int maxLength, string name)
        {
            if (maxLength < 0)
            {
                throw new InvalidOperationException("Must not specify a max length less than zero.");
            }

            if (argument.Count() > maxLength)
            {
                throw new ArgumentException($"Argument '{name}' must not have length greater than {maxLength}.");
            }
        }

        /// <summary>
        /// Assert the minimum length of a string.
        /// </summary>
        /// <param name="argument">The string argument.</param>
        /// <param name="minLength">The minimum length of the string argument.</param>
        /// <param name="name">The name of the string argument.</param>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when <paramref name="minLength"/> is less than zero.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when length of <paramref name="argument"/> is less than <paramref name="minLength"/>.
        /// </exception>
        [DebuggerStepThrough]
        public static void HasMinLength(string argument, int minLength, string name)
        {
            if (minLength < 0)
            {
                throw new InvalidOperationException("Must not specify a min length less than zero.");
            }

            if (argument.Length < minLength)
            {
                throw new ArgumentException($"Argument '{name}' must not have length less than {minLength}.");
            }
        }

        /// <summary>
        /// Assert the minimum length of an enumerable.
        /// </summary>
        /// <param name="argument">The enumerable argument.</param>
        /// <param name="minLength">The minimum length of the enumerable argument.</param>
        /// <param name="name">The name of the enumerable argument.</param>
        /// <typeparam name="T">The type of the elements in the enumerable.</typeparam>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when <paramref name="minLength"/> is less than zero.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when length of <paramref name="argument"/> is less than <paramref name="minLength"/>.
        /// </exception>
        [DebuggerStepThrough]
        public static void HasMinLength<T>(IEnumerable<T> argument, int minLength, string name)
        {
            if (minLength < 0)
            {
                throw new InvalidOperationException("Must not specify a min length less than zero.");
            }

            if (argument.Count() < minLength)
            {
                throw new ArgumentException($"Argument '{name}' must not have length less than {minLength}.");
            }
        }

        /// <summary>
        /// Assert the minimum value of a comparable.
        /// </summary>
        /// <param name="argument">The comparable argument.</param>
        /// <param name="min">The minimum value of the comparable argument.</param>
        /// <param name="name">The name of the comparable argument.</param>
        /// <typeparam name="T">The type of elements in the comparable.</typeparam>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is less than <paramref name="min"/>.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsAtLeast<T>(T argument, T min, string name) where T : IComparable
        {
            if (argument.CompareTo(min) < 0)
            {
                throw new ArgumentException($"Argument '{name}' must not be less than {min}.");
            }
        }

        /// <summary>
        /// Assert the maximum value of a comparable.
        /// </summary>
        /// <param name="argument">The comparable argument.</param>
        /// <param name="max">The maximum value of the comparable argument.</param>
        /// <param name="name">The name of the comparable argument.</param>
        /// <typeparam name="T">The type of elements in the comparable.</typeparam>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is greater than <paramref name="max"/>.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsAtMost<T>(T argument, T max, string name) where T : IComparable
        {
            if (argument.CompareTo(max) > 0)
            {
                throw new ArgumentException($"Argument '{name}' must not be greater than {max}.");
            }
        }

        /// <summary>
        /// Assert the interval of a comparable.
        /// </summary>
        /// <param name="argument">The comparable argument.</param>
        /// <param name="min">The mimimum value of the comparable argument.</param>
        /// <param name="max">The maximum value of the comparable argument.</param>
        /// <param name="name">The name of the comparable argument.</param>
        /// <typeparam name="T">The type of elements in the comparable.</typeparam>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when <paramref name="max"/> is less than <paramref name="min"/>.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is less than <paramref name="min"/>.
        /// </exception>
        /// <exception>
        /// Thrown when <paramref name="argument"/> is greater than <paramref name="max"/>.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsInInterval<T>(T argument, T min, T max, string name) where T : IComparable
        {
            if (max.CompareTo(min) < 0)
            {
                throw new InvalidOperationException("Max must not be less than min.");
            }

            IsAtLeast(argument, min, name);
            IsAtMost(argument, max, name);
        }

        /// <summary>
        /// Assert that a guid is not empty.
        /// </summary>
        /// <param name="argument">The guid argument.</param>
        /// <param name="name">The name of the guid argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is the empty guid.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotEmpty(Guid argument, string name)
        {
            if (argument == Guid.Empty)
            {
                throw new ArgumentException($"Argument '{name}' must not be the empty guid.");
            }
        }

        /// <summary>
        /// Assert that a string is not empty.
        /// </summary>
        /// <param name="argument">The string argument.</param>
        /// <param name="name">The name of the string argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is the empty string.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotEmpty(string argument, string name)
        {
            if (argument == string.Empty)
            {
                throw new ArgumentException($"Argument '{name}' must not be empty.");
            }
        }

        /// <summary>
        /// Assert that a local DateTime is not in the future.
        /// </summary>
        /// <param name="argument">The DateTime argument.</param>
        /// <param name="name">The name of the DateTime argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is in the future.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotInFuture(DateTime argument, string name)
        {
            if (argument > TimeProvider.Current.Now)
            {
                throw new ArgumentException($"Argument '{name}' must not be in the future.");
            }
        }

        /// <summary>
        /// Assert that a UTC DateTime is not in the future.
        /// </summary>
        /// <param name="argument">The DateTime argument.</param>
        /// <param name="name">The name of the DateTime argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is in the future.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotInFutureUtc(DateTime argument, string name)
        {
            if (argument > TimeProvider.Current.UtcNow)
            {
                throw new ArgumentException($"Argument '{name}' must not be in the future.");
            }
        }

        /// <summary>
        /// Assert that a local DateTime is not in the past.
        /// </summary>
        /// <param name="argument">The DateTime argument.</param>
        /// <param name="name">The name of the DateTime argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is in the future.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotInPast(DateTime argument, string name)
        {
            if (argument < TimeProvider.Current.Now)
            {
                throw new ArgumentException($"Argument '{name}' must not be in the past.");
            }
        }

        /// <summary>
        /// Assert that a UTC DateTime is not in the past.
        /// </summary>
        /// <param name="argument">The DateTime argument.</param>
        /// <param name="name">The name of the DateTime argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is in the future.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotInPastUtc(DateTime argument, string name)
        {
            if (argument < TimeProvider.Current.UtcNow)
            {
                throw new ArgumentException($"Argument '{name}' must not be in the past.");
            }
        }

        /// <summary>
        /// Assert that an integer is not negative.
        /// </summary>
        /// <param name="argument">The integer argument.</param>
        /// <param name="name">The name of the integer argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegative(int argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative value.");
            }
        }

        /// <summary>
        /// Assert that a long is not negative.
        /// </summary>
        /// <param name="argument">The long argument.</param>
        /// <param name="name">The name of the long argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegative(long argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative value.");
            }
        }

        /// <summary>
        /// Assert that a float is not negative.
        /// </summary>
        /// <param name="argument">The float argument.</param>
        /// <param name="name">The name of the float argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegative(float argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative value.");
            }
        }

        /// <summary>
        /// Assert that a decimal is not negative.
        /// </summary>
        /// <param name="argument">The decimal argument.</param>
        /// <param name="name">The name of the decimal argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegative(decimal argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative value.");
            }
        }

        /// <summary>
        /// Assert that a TimeSpan is not negative.
        /// </summary>
        /// <param name="argument">The TimeSpan argument.</param>
        /// <param name="name">The name of the TimeSpan argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegative(TimeSpan argument, string name)
        {
            if (argument < TimeSpan.Zero)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative value.");
            }
        }

        /// <summary>
        /// Assert that an integer is not negative or zero.
        /// </summary>
        /// <param name="argument">The integer argument.</param>
        /// <param name="name">The name of the integer argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative or zero value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(int argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative or zero value.");
            }
        }

        /// <summary>
        /// Assert that a long is not negative or zero.
        /// </summary>
        /// <param name="argument">The long argument.</param>
        /// <param name="name">The name of the long argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative or zero value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(long argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative or zero value.");
            }
        }

        /// <summary>
        /// Assert that a float is not negative or zero.
        /// </summary>
        /// <param name="argument">The float argument.</param>
        /// <param name="name">The name of the float argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative or zero value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(float argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative or zero value.");
            }
        }

        /// <summary>
        /// Assert that a decimal is not negative or zero.
        /// </summary>
        /// <param name="argument">The decimal argument.</param>
        /// <param name="name">The name of the decimal argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative or zero value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(decimal argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative or zero value.");
            }
        }

        /// <summary>
        /// Assert that a TimeSpan is not negative or zero.
        /// </summary>
        /// <param name="argument">The TimeSpan argument.</param>
        /// <param name="name">The name of the TimeSpan argument.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> has a negative or zero value.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(TimeSpan argument, string name)
        {
            if (argument <= TimeSpan.Zero)
            {
                throw new ArgumentException($"Argument '{name}' must not have a negative or zero value.");
            }
        }

        /// <summary>
        /// Assert that the argument is not null.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="argument"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNull(object argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Assert that the argument is not null.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="argument"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNull<T>(T argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Assert that a string is not null or empty.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="argument"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is the empty string.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNullOrEmpty(string argument, string name)
        {
            IsNotNull(argument, name);

            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentException($"Argument '{name}' must not be an empty string.");
            }
        }

        /// <summary>
        /// Assert that an enumerable is not null or empty.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="argument"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is empty.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNullOrEmpty<T>(IEnumerable<T> argument, string name)
        {
            IsNotNull(argument, name);

            if (!argument.Any())
            {
                throw new ArgumentException($"Argument '{name}' must not be empty.");
            }
        }

        /// <summary>
        /// Assert that a string is not null or whitespace.
        /// </summary>
        /// <param name="argument">The string argument.</param>
        /// <param name="name">The name of the string argument.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="argument"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> is the empty string.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsNotNullOrWhitespace(string argument, string name)
        {
            IsNotNull(argument, name);

            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException($"Argument '{name}' must not be empty or whitespace.");
            }
        }

        /// <summary>
        /// Assert that an annotated model is valid.
        /// </summary>
        /// <param name="argument">The model argument.</param>
        /// <typeparam name="T">The type of the model argument.</typeparam>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="argument"/> is null.
        /// </exception>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">
        /// Thrown when <paramref name="argument"/> is an invalid model.
        /// </exception>
        [DebuggerStepThrough]
        public static void IsValidModel<T>(T argument)
        {
            var context = new ValidationContext(argument, null, null);
            Validator.ValidateObject(argument, context, true);
        }

        /// <summary>
        /// Assert that an annotated model property is valid.
        /// </summary>
        /// <param name="argument">The model argument.</param>
        /// <param name="value">The value of the model property.</param>
        /// <param name="name">The name of the model Property</param>
        /// <typeparam name="T">The type of the model.</typeparam>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="value"/> cannot be assigned to the property.
        /// </exception>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">
        /// Thrown when <paramref name="value"/> is not valid.
        /// </exception>
        public static void IsValidProperty<T>(T argument, object value, string name)
        {
            var context = new ValidationContext(argument, null, null) { MemberName = name };
            Validator.ValidateProperty(value, context);
        }

        /// <summary>
        /// Assert that a string matches a given regular expression.
        /// </summary>
        /// <param name="argument">The string argument.</param>
        /// <param name="expression">The regular expression.</param>
        /// <param name="name">The name of the argument.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="argument"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="argument"/> does not match the regular expression.
        /// </exception>
        [DebuggerStepThrough]
        public static void MatchesRegex(string argument, string expression, string name)
        {
            IsNotNull(argument, name);

            if (!Regex.IsMatch(argument, expression))
            {
                throw new ArgumentException($"Argument '{name}' must match regular expression {expression}.");
            }
        }
    }
}
