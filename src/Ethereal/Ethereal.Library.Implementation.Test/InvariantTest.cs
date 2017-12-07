using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace Ethereal.Library.Test
{
    [TestFixture]
    public class InvariantTest
    {
        private const string PARAMETER_NAME = "foo";
        private readonly DateTime _currentDate = new DateTime(2017, 11, 6);

        private Mock<ISystemTime> _systemTime;
        private Invariant _target;

        [SetUp]
        public void Setup()
        {
            _systemTime = new Mock<ISystemTime>();
            _target = new Invariant(_systemTime.Object);
        }

        #region HasMaxLength

        [Test]
        public void HasMaxLength_When_MaxLength_Is_Less_Than_Zero_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(
                () => _target.HasMaxLength(string.Empty, -1, PARAMETER_NAME));

            Assert.AreEqual("Must not specify a max length less than zero.", ex.Message);
        }

        [Test]
        public void HasMaxLength_When_MaxLength_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMaxLength(string.Empty, 0, PARAMETER_NAME));
        }

        [Test]
        public void HasMaxLength_When_Argument_Length_Exceeds_MaxLength_Should_Throw_ArgumentException()
        {
            const int MAX_LENGTH = 0;

            var ex = Assert.Throws<ArgumentException>(
                () => _target.HasMaxLength("a", MAX_LENGTH, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have length greater than {MAX_LENGTH}.", ex.Message);
        }

        [Test]
        public void HasMaxLength_When_Argument_Length_Is_Equal_To_MaxLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMaxLength("a", 1, PARAMETER_NAME));
        }

        [Test]
        public void HasMaxLength_When_Argument_Length_Is_Less_Than_MaxLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMaxLength("a", 2, PARAMETER_NAME));
        }

        #endregion

        #region HasMaxLength<T>

        [Test]
        public void HasMaxLengthOfT_When_MaxLength_Is_Less_Than_Zero_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(
                () => _target.HasMaxLength<int>(new List<int>(), -1, PARAMETER_NAME));

            Assert.AreEqual("Must not specify a max length less than zero.", ex.Message);
        }

        [Test]
        public void HasMaxLengthOfT_When_MaxLength_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMaxLength<int>(new List<int>(), 0, PARAMETER_NAME));
        }

        [Test]
        public void HasMaxLengthOfT_When_Argument_Length_Exceeds_MaxLength_Should_Throw_ArgumentException()
        {
            const int MAX_LENGTH = 0;

            var ex = Assert.Throws<ArgumentException>(
                () => _target.HasMaxLength<int>(new List<int> { 1 }, MAX_LENGTH, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have length greater than {MAX_LENGTH}.", ex.Message);
        }

        [Test]
        public void HasMaxLengthOfT_When_Argument_Length_Is_Equal_To_MaxLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMaxLength<int>(new List<int> { 1 }, 1, PARAMETER_NAME));
        }

        [Test]
        public void HasMaxLengthOfT_When_Argument_Length_Is_Less_Than_MaxLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMaxLength<int>(new List<int> { 1 }, 2, PARAMETER_NAME));
        }

        #endregion

        #region HasMinLength

        [Test]
        public void HasMinLength_When_MinLength_Is_Less_Than_Zero_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(
                () => _target.HasMinLength(string.Empty, -1, PARAMETER_NAME));

            Assert.AreEqual("Must not specify a min length less than zero.", ex.Message);
        }

        [Test]
        public void HasMinLength_When_MinLength_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMinLength(string.Empty, 0, PARAMETER_NAME));
        }

        [Test]
        public void HasMinLength_When_Argument_Length_Is_Less_Than_MinLength_Should_Throw_ArgumentException()
        {
            const int MIN_LENGTH = 1;

            var ex = Assert.Throws<ArgumentException>(
                () => _target.HasMinLength(string.Empty, MIN_LENGTH, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have length less than {MIN_LENGTH}.", ex.Message);
        }

        [Test]
        public void HasMinLength_When_Argument_Length_Is_Equal_To_MinLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMinLength("a", 1, PARAMETER_NAME));
        }

        [Test]
        public void HasMinLength_When_Argument_Length_Exceeds_MinLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMinLength("aa", 1, PARAMETER_NAME));
        }

        #endregion

        #region HasMinLength<T>

        [Test]
        public void HasMinLengthOfT_When_MinLength_Is_Less_Than_Zero_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(
                () => _target.HasMinLength<int>(new List<int>(), -1, PARAMETER_NAME));

            Assert.AreEqual("Must not specify a min length less than zero.", ex.Message);
        }

        [Test]
        public void HasMinLengthOfT_When_MinLength_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMinLength<int>(new List<int>(), 0, PARAMETER_NAME));
        }

        [Test]
        public void HasMinLengthOfT_When_Argument_Length_Is_Less_Than_MinLength_Should_Throw_ArgumentException()
        {
            const int MIN_LENGTH = 1;

            var ex = Assert.Throws<ArgumentException>(
                () => _target.HasMinLength<int>(new List<int>(), MIN_LENGTH, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have length less than {MIN_LENGTH}.", ex.Message);
        }

        [Test]
        public void HasMinLengthOfT_When_Argument_Length_Is_Equal_To_MinLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMinLength<int>(new List<int> { 1 }, 1, PARAMETER_NAME));
        }

        [Test]
        public void HasMinLengthOfT_When_Argument_Length_Exceeds_MinLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.HasMinLength<int>(new List<int> { 1, 2 }, 1, PARAMETER_NAME));
        }

        #endregion

        #region IsAtLeast

        [Test]
        public void IsAtLeast_When_Argument_Is_Less_Than_Min_Should_Throw_ArgumentException()
        {
            const int MIN_VALUE = 1;

            var ex = Assert.Throws<ArgumentException>(() => _target.IsAtLeast(0, MIN_VALUE, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be less than {MIN_VALUE}.", ex.Message);
        }

        [Test]
        public void IsAtLeast_When_Argument_Is_Equal_To_Min_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsAtLeast(0, 0, PARAMETER_NAME));
        }

        [Test]
        public void IsAtLeast_When_Argument_Exceeds_Min_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsAtLeast(1, 0, PARAMETER_NAME));
        }

        #endregion

        #region IsAtMost

        [Test]
        public void IsAtMost_When_Argument_Exceeds_Max_Should_Throw_ArgumentException()
        {
            const int MAX_VALUE = 0;

            var ex = Assert.Throws<ArgumentException>(() => _target.IsAtMost(1, MAX_VALUE, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be greater than {MAX_VALUE}.", ex.Message);
        }

        [Test]
        public void IsAtMost_When_Argument_Is_Equal_To_Max_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsAtMost(0, 0, PARAMETER_NAME));
        }

        [Test]
        public void IsAtMost_When_Argument_Is_Less_Than_Max_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsAtMost(0, 1, PARAMETER_NAME));
        }

        #endregion

        #region IsInInterval

        [Test]
        public void IsInInterval_When_Max_Is_Less_Than_Min_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => _target.IsInInterval(0, 1, 0, PARAMETER_NAME));

            Assert.AreEqual("Max must not be less than min.", ex.Message);
        }

        [Test]
        public void IsInInterval_When_Max_Is_Equal_To_Min_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsInInterval(0, 0, 0, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Max_Exceeds_Than_Min_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsInInterval(0, 0, 1, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Argument_Is_Less_Than_Min_Should_Throw_ArgumentException()
        {
            const int MIN_VALUE = 0;

            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsInInterval(-1, MIN_VALUE, MIN_VALUE + 1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be less than {MIN_VALUE}.", ex.Message);
        }

        [Test]
        public void IsInInterval_When_Argument_Is_Equal_To_Min_Should_Not_Throw()
        {
            const int MIN_VALUE = 0;

            Assert.DoesNotThrow(() => _target.IsInInterval(MIN_VALUE, MIN_VALUE, MIN_VALUE + 1, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Argument_Exceeds_Min_And_Is_Less_Than_Max_Should_Not_Throw()
        {
            const int MIN_VALUE = 0;

            Assert.DoesNotThrow(() => _target.IsInInterval(MIN_VALUE + 1, MIN_VALUE, MIN_VALUE + 2, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Argument_Is_Equal_To_Max_Should_Not_Throw()
        {
            const int MAX_VALUE = 2;

            Assert.DoesNotThrow(() => _target.IsInInterval(MAX_VALUE, MAX_VALUE - 1, MAX_VALUE, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Argument_Exceeds_Max_Should_Throw_ArgumentException()
        {
            const int MAX_VALUE = 2;

            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsInInterval(MAX_VALUE + 1, MAX_VALUE - 1, MAX_VALUE, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be greater than {MAX_VALUE}.", ex.Message);
        }

        #endregion

        #region IsNotEmpty<Guid>

        [Test]
        public void IsNotEmptyOfGuid_When_Argument_Is_Empty_Guid_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotEmpty(Guid.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be the empty guid.", ex.Message);
        }

        [Test]
        public void IsNotEmptyOfGuid_When_Argument_Is_Not_Empty_Guid_Should_Not_Throw()
        {
            Assert.DoesNotThrow(
                () => _target.IsNotEmpty(new Guid("B51ADF9B-077C-42F3-91D0-5E97E6B25B9D"), PARAMETER_NAME));
        }

        #endregion

        #region IsNotEmpty<string>

        [Test]
        public void IsNotEmptyOfString_When_Argument_Is_Empty_String_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotEmpty(string.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty.", ex.Message);
        }

        [Test]
        public void IsNotEmptyOfString_When_Argument_Is_Not_Empty_String_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotEmpty("foo", PARAMETER_NAME));
        }

        [Test]
        public void IsNotEmptyOfString_When_Argument_Is_Null_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotEmpty(null, PARAMETER_NAME));
        }

        #endregion

        #region IsNotInFuture

        [Test]
        public void IsNotInFuture_When_Argument_Exceeds_Current_DateTime_Should_Throw_ArgumentException()
        {
            _systemTime.Setup(s => s.Now).Returns(() => _currentDate);

            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsNotInFuture(_currentDate.AddTicks(1), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be in the future.", ex.Message);
        }

        [Test]
        public void IsNotInFuture_When_Argument_Is_Current_DateTime_Should_Not_Throw()
        {
            _systemTime.Setup(s => s.Now).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => _target.IsNotInFuture(_currentDate, PARAMETER_NAME));
        }

        [Test]
        public void IsNotInFuture_When_Argument_Is_Earlier_Than_Current_DateTime_Should_Not_Throw()
        {
            _systemTime.Setup(s => s.Now).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => _target.IsNotInFuture(_currentDate.AddTicks(-1), PARAMETER_NAME));
        }

        #endregion

        #region IsNotInFutureUtc

        [Test]
        public void IsNotInFutureUtc_When_Argument_Exceeds_Current_DateTime_Should_Throw_ArgumentException()
        {
            _systemTime.Setup(s => s.UtcNow).Returns(() => _currentDate);

            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsNotInFutureUtc(_currentDate.AddTicks(1), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be in the future.", ex.Message);
        }

        [Test]
        public void IsNotInFutureUtc_When_Argument_Is_Current_DateTime_Should_Not_Throw()
        {
            _systemTime.Setup(s => s.UtcNow).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => _target.IsNotInFutureUtc(_currentDate, PARAMETER_NAME));
        }

        [Test]
        public void IsNotInFutureUtc_When_Argument_Is_Earlier_Than_Current_DateTime_Should_Not_Throw()
        {
            _systemTime.Setup(s => s.UtcNow).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => _target.IsNotInFutureUtc(_currentDate.AddTicks(-1), PARAMETER_NAME));
        }

        #endregion

        #region IsNotInPast

        [Test]
        public void IsNotInPast_When_Argument_Is_Earlier_Then_Current_DateTime_Should_Throw_ArgumentException()
        {
            _systemTime.Setup(s => s.Now).Returns(() => _currentDate);

            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsNotInPast(_currentDate.AddTicks(-1), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be in the past.", ex.Message);
        }

        [Test]
        public void IsNotInPast_When_Argument_Is_Current_DateTime_Should_Not_Throw()
        {
            _systemTime.Setup(s => s.Now).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => _target.IsNotInPast(_currentDate, PARAMETER_NAME));
        }

        [Test]
        public void IsNotInPast_When_Argument_Exceeds_Current_DateTime_Should_Not_Throw()
        {
            _systemTime.Setup(s => s.Now).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => _target.IsNotInPast(_currentDate.AddTicks(1), PARAMETER_NAME));
        }

        #endregion

        #region IsNotInPastUtc

        [Test]
        public void IsNotInPastUtc_When_Argument_Is_Earlier_Then_Current_DateTime_Should_Throw_ArgumentException()
        {
            _systemTime.Setup(s => s.UtcNow).Returns(() => _currentDate);

            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsNotInPastUtc(_currentDate.AddTicks(-1), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be in the past.", ex.Message);
        }

        [Test]
        public void IsNotInPastUtc_When_Argument_Is_Current_DateTime_Should_Not_Throw()
        {
            _systemTime.Setup(s => s.UtcNow).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => _target.IsNotInPastUtc(_currentDate, PARAMETER_NAME));
        }

        [Test]
        public void IsNotInPastUtc_When_Argument_Exceeds_Current_DateTime_Should_Not_Throw()
        {
            _systemTime.Setup(s => s.UtcNow).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => _target.IsNotInPastUtc(_currentDate.AddTicks(1), PARAMETER_NAME));
        }

        #endregion

        #region IsNotNegative<int>

        [Test]
        public void IsNotNegativeOfInt_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegative(0, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfInt_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegative(-1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegative<long>

        [Test]
        public void IsNotNegativeOfLong_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegative((long) 0, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfLong_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegative((long) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegative<float>

        [Test]
        public void IsNotNegativeOfFloat_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegative((float) 0, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfFloat_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegative((float) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegative<decimal>

        [Test]
        public void IsNotNegativeOfDecimal_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegative((decimal) 0, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfDecimal_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegative((decimal) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegative<TimeSpan>

        [Test]
        public void IsNotNegativeOfTimeSpan_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegative(TimeSpan.Zero, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfTimeSpan_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsNotNegative(TimeSpan.FromTicks(1).Negate(), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<int>

        [Test]
        public void IsNotNegativeOrZeroOfInt_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegativeOrZero(1, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfInt_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegativeOrZero(0, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfInt_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegativeOrZero(-1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<long>

        [Test]
        public void IsNotNegativeOrZeroOfLong_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegativeOrZero((long) 1, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfLong_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegativeOrZero((long) 0, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfLong_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegativeOrZero((long) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<float>

        [Test]
        public void IsNotNegativeOrZeroOfFloat_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegativeOrZero((float) 1, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfFloat_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegativeOrZero((float) 0, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfFloat_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegativeOrZero((float) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<decimal>

        [Test]
        public void IsNotNegativeOrZeroOfDecimal_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegativeOrZero((decimal) 1, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfDecimal_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegativeOrZero((decimal) 0, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfDecimal_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegativeOrZero((decimal) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<TimeSpan>

        [Test]
        public void IsNotNegativeOrZeroOfTimeSpan_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNegativeOrZero(TimeSpan.FromTicks(1), PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfTimeSpan_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNegativeOrZero(TimeSpan.Zero, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfTimeSpan_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsNotNegativeOrZero(TimeSpan.FromTicks(1).Negate(), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNull<object>

        [Test]
        public void IsNotNullOfObject_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _target.IsNotNull((object) null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOfObject_When_Argument_Is_Not_Null_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNull(new Object(), PARAMETER_NAME));
        }

        #endregion

        #region IsNotNull<T>

        [Test]
        public void IsNotNullOfT_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _target.IsNotNull((string) null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOfT_When_Argument_Is_Not_Null_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNull(string.Empty, PARAMETER_NAME));
        }

        #endregion

        #region IsNotNullOrEmpty<string>

        [Test]
        public void IsNotNullOrEmptyOfString_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _target.IsNotNullOrEmpty((string) null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOrEmptyOfString_When_Argument_Is_Empty_String_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNullOrEmpty(string.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be an empty string.", ex.Message);
        }

        [Test]
        public void IsNotNullOrEmptyOfString_When_Argument_Is_Whitespace_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNullOrEmpty(" ", PARAMETER_NAME));
        }

        [Test]
        public void IsNotNullOrEmptyOfString_When_Argument_Is_Not_Null_Or_Empty_Or_Whitespace_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNullOrEmpty("foo", PARAMETER_NAME));
        }

        #endregion

        #region IsNotNullOrEmpty<IEnumerable<T>>

        [Test]
        public void IsNotNullOrEmptyOfIEnumerable_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _target.IsNotNullOrEmpty((IEnumerable<int>) null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOrEmptyOfIEnumerable_When_Argument_Is_Empty_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsNotNullOrEmpty(Enumerable.Empty<int>(), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty.", ex.Message);
        }

        [Test]
        public void IsNotNullOrEmptyOfIEnumerable_When_Argument_Is_Not_Empty_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotNullOrEmpty(new List<int> { 1 }, PARAMETER_NAME));
        }

        #endregion

        #region IsNotNullOrWhitespace

        [Test]
        public void IsNotNullOrWhitespace_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _target.IsNotNullOrWhitespace(null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOrWhitespace_When_Argument_Is_Empty_String_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => _target.IsNotNullOrWhitespace(string.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty or whitespace.", ex.Message);
        }

        [Test]
        public void IsNotNullOrWhitespace_When_Argument_Is_Whitespace_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotNullOrWhitespace(" ", PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty or whitespace.", ex.Message);
        }

        #endregion

        #region IsNotWhitespace

        [Test]
        public void IsNotWhitespace_When_Argument_Is_Null_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsNotWhitespace(null, PARAMETER_NAME));
        }

        [Test]
        public void IsNotWhitespace_When_Argument_Is_Empty_String_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotWhitespace(string.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty or whitespace.", ex.Message);
        }

        [Test]
        public void IsNotWhitespace_When_Argument_Is_Whitespace_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _target.IsNotWhitespace(" ", PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty or whitespace.", ex.Message);
        }

        #endregion

        #region IsValidModel

        [Test]
        public void IsValidModel_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _target.IsValidModel<object>(null));
        }

        [Test]
        public void IsValidModel_When_Argument_Is_Not_Valid_Should_Throw_ValidationException()
        {
            Assert.Throws<ValidationException>(() => _target.IsValidModel(new TestModel()));
        }

        [Test]
        public void IsValidModel_When_Model_Is_Valid_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => _target.IsValidModel(new TestModel { RequiredProperty = 1 }));
        }

        #endregion

        #region IsValidProperty

        [Test]
        public void IsValidProperty_When_Property_Is_Null_Should_Throw_ValidationException()
        {
            var model = new TestModel();
            Assert.Throws<ValidationException>(
                () => _target.IsValidProperty(model, model.RequiredProperty, nameof(model.RequiredProperty)));
        }

        [Test]
        public void IsValidProperty_When_Property_Is_Invalid_Should_Throw_ValidationException()
        {
            var model = new TestModel { RequiredProperty = 2 };
            Assert.Throws<ValidationException>(
                () => _target.IsValidProperty(model, model.RequiredProperty, nameof(model.RequiredProperty)));
        }

        #endregion

        #region MatchesRegex

        [Test]
        public void MatchesRegex_When_Argument_Is_Null_Should_Throw_NullReferenceException()
        {
            Assert.Throws<ArgumentNullException>(() => _target.MatchesRegex(null, @"\s+", PARAMETER_NAME));
        }

        [Test]
        public void MatchesRegex_When_Argument_Does_Not_Match_Should_Throw()
        {
            var expression = @"\s+";
            var ex = Assert.Throws<ArgumentException>(() => _target.MatchesRegex("a", expression, PARAMETER_NAME));
            Assert.AreEqual($"{PARAMETER_NAME} must match regular expression {expression}.", ex.Message);
        }

        [Test]
        public void MatchesRegex_When_Argument_Matches_Should_Not_Throw()
        {
            var expression = @"\s+";
            Assert.DoesNotThrow(() => _target.MatchesRegex(" ", expression, PARAMETER_NAME));
        }

        #endregion
    }
}
