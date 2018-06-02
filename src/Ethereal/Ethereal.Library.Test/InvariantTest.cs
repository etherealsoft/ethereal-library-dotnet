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
        private DateTime _currentDate;
        private Mock<TimeProvider> _timeProvider;

        [SetUp]
        public void Setup()
        {
            _currentDate = new DateTime(2018, 6, 2);
            _timeProvider = new Mock<TimeProvider>();
            TimeProvider.Current = _timeProvider.Object;
        }

        [TearDown]
        public void Teardown()
        {
            TimeProvider.Reset();
        }

        #region HasMaxLength

        [Test]
        public void HasMaxLength_When_MaxLength_Is_Less_Than_Zero_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(
                () => Invariant.HasMaxLength(string.Empty, -1, PARAMETER_NAME));

            Assert.AreEqual("Must not specify a max length less than zero.", ex.Message);
        }

        [Test]
        public void HasMaxLength_When_MaxLength_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMaxLength(string.Empty, 0, PARAMETER_NAME));
        }

        [Test]
        public void HasMaxLength_When_Argument_Length_Exceeds_MaxLength_Should_Throw_ArgumentException()
        {
            const int MAX_LENGTH = 0;

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.HasMaxLength("a", MAX_LENGTH, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have length greater than {MAX_LENGTH}.", ex.Message);
        }

        [Test]
        public void HasMaxLength_When_Argument_Length_Is_Equal_To_MaxLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMaxLength("a", 1, PARAMETER_NAME));
        }

        [Test]
        public void HasMaxLength_When_Argument_Length_Is_Less_Than_MaxLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMaxLength("a", 2, PARAMETER_NAME));
        }

        #endregion

        #region HasMaxLength<T>

        [Test]
        public void HasMaxLengthOfT_When_MaxLength_Is_Less_Than_Zero_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(
                () => Invariant.HasMaxLength<int>(new List<int>(), -1, PARAMETER_NAME));

            Assert.AreEqual("Must not specify a max length less than zero.", ex.Message);
        }

        [Test]
        public void HasMaxLengthOfT_When_MaxLength_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMaxLength<int>(new List<int>(), 0, PARAMETER_NAME));
        }

        [Test]
        public void HasMaxLengthOfT_When_Argument_Length_Exceeds_MaxLength_Should_Throw_ArgumentException()
        {
            const int MAX_LENGTH = 0;

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.HasMaxLength<int>(new List<int> { 1 }, MAX_LENGTH, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have length greater than {MAX_LENGTH}.", ex.Message);
        }

        [Test]
        public void HasMaxLengthOfT_When_Argument_Length_Is_Equal_To_MaxLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMaxLength<int>(new List<int> { 1 }, 1, PARAMETER_NAME));
        }

        [Test]
        public void HasMaxLengthOfT_When_Argument_Length_Is_Less_Than_MaxLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMaxLength<int>(new List<int> { 1 }, 2, PARAMETER_NAME));
        }

        #endregion

        #region HasMinLength

        [Test]
        public void HasMinLength_When_MinLength_Is_Less_Than_Zero_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(
                () => Invariant.HasMinLength(string.Empty, -1, PARAMETER_NAME));

            Assert.AreEqual("Must not specify a min length less than zero.", ex.Message);
        }

        [Test]
        public void HasMinLength_When_MinLength_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMinLength(string.Empty, 0, PARAMETER_NAME));
        }

        [Test]
        public void HasMinLength_When_Argument_Length_Is_Less_Than_MinLength_Should_Throw_ArgumentException()
        {
            const int MIN_LENGTH = 1;

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.HasMinLength(string.Empty, MIN_LENGTH, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have length less than {MIN_LENGTH}.", ex.Message);
        }

        [Test]
        public void HasMinLength_When_Argument_Length_Is_Equal_To_MinLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMinLength("a", 1, PARAMETER_NAME));
        }

        [Test]
        public void HasMinLength_When_Argument_Length_Exceeds_MinLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMinLength("aa", 1, PARAMETER_NAME));
        }

        #endregion

        #region HasMinLength<T>

        [Test]
        public void HasMinLengthOfT_When_MinLength_Is_Less_Than_Zero_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(
                () => Invariant.HasMinLength<int>(new List<int>(), -1, PARAMETER_NAME));

            Assert.AreEqual("Must not specify a min length less than zero.", ex.Message);
        }

        [Test]
        public void HasMinLengthOfT_When_MinLength_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMinLength<int>(new List<int>(), 0, PARAMETER_NAME));
        }

        [Test]
        public void HasMinLengthOfT_When_Argument_Length_Is_Less_Than_MinLength_Should_Throw_ArgumentException()
        {
            const int MIN_LENGTH = 1;

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.HasMinLength<int>(new List<int>(), MIN_LENGTH, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have length less than {MIN_LENGTH}.", ex.Message);
        }

        [Test]
        public void HasMinLengthOfT_When_Argument_Length_Is_Equal_To_MinLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMinLength<int>(new List<int> { 1 }, 1, PARAMETER_NAME));
        }

        [Test]
        public void HasMinLengthOfT_When_Argument_Length_Exceeds_MinLength_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.HasMinLength<int>(new List<int> { 1, 2 }, 1, PARAMETER_NAME));
        }

        #endregion

        #region IsAtLeast

        [Test]
        public void IsAtLeast_When_Argument_Is_Less_Than_Min_Should_Throw_ArgumentException()
        {
            const int MIN_VALUE = 1;

            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsAtLeast(0, MIN_VALUE, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be less than {MIN_VALUE}.", ex.Message);
        }

        [Test]
        public void IsAtLeast_When_Argument_Is_Equal_To_Min_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsAtLeast(0, 0, PARAMETER_NAME));
        }

        [Test]
        public void IsAtLeast_When_Argument_Exceeds_Min_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsAtLeast(1, 0, PARAMETER_NAME));
        }

        #endregion

        #region IsAtMost

        [Test]
        public void IsAtMost_When_Argument_Exceeds_Max_Should_Throw_ArgumentException()
        {
            const int MAX_VALUE = 0;

            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsAtMost(1, MAX_VALUE, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be greater than {MAX_VALUE}.", ex.Message);
        }

        [Test]
        public void IsAtMost_When_Argument_Is_Equal_To_Max_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsAtMost(0, 0, PARAMETER_NAME));
        }

        [Test]
        public void IsAtMost_When_Argument_Is_Less_Than_Max_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsAtMost(0, 1, PARAMETER_NAME));
        }

        #endregion

        #region IsInInterval

        [Test]
        public void IsInInterval_When_Max_Is_Less_Than_Min_Should_Throw_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => Invariant.IsInInterval(0, 1, 0, PARAMETER_NAME));

            Assert.AreEqual("Max must not be less than min.", ex.Message);
        }

        [Test]
        public void IsInInterval_When_Max_Is_Equal_To_Min_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsInInterval(0, 0, 0, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Max_Exceeds_Than_Min_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsInInterval(0, 0, 1, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Argument_Is_Less_Than_Min_Should_Throw_ArgumentException()
        {
            const int MIN_VALUE = 0;

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsInInterval(-1, MIN_VALUE, MIN_VALUE + 1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be less than {MIN_VALUE}.", ex.Message);
        }

        [Test]
        public void IsInInterval_When_Argument_Is_Equal_To_Min_Should_Not_Throw()
        {
            const int MIN_VALUE = 0;

            Assert.DoesNotThrow(() => Invariant.IsInInterval(MIN_VALUE, MIN_VALUE, MIN_VALUE + 1, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Argument_Exceeds_Min_And_Is_Less_Than_Max_Should_Not_Throw()
        {
            const int MIN_VALUE = 0;

            Assert.DoesNotThrow(() => Invariant.IsInInterval(MIN_VALUE + 1, MIN_VALUE, MIN_VALUE + 2, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Argument_Is_Equal_To_Max_Should_Not_Throw()
        {
            const int MAX_VALUE = 2;

            Assert.DoesNotThrow(() => Invariant.IsInInterval(MAX_VALUE, MAX_VALUE - 1, MAX_VALUE, PARAMETER_NAME));
        }

        [Test]
        public void IsInInterval_When_Argument_Exceeds_Max_Should_Throw_ArgumentException()
        {
            const int MAX_VALUE = 2;

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsInInterval(MAX_VALUE + 1, MAX_VALUE - 1, MAX_VALUE, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be greater than {MAX_VALUE}.", ex.Message);
        }

        #endregion

        #region IsNotEmpty<Guid>

        [Test]
        public void IsNotEmptyOfGuid_When_Argument_Is_Empty_Guid_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotEmpty(Guid.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be the empty guid.", ex.Message);
        }

        [Test]
        public void IsNotEmptyOfGuid_When_Argument_Is_Not_Empty_Guid_Should_Not_Throw()
        {
            Assert.DoesNotThrow(
                () => Invariant.IsNotEmpty(new Guid("B51ADF9B-077C-42F3-91D0-5E97E6B25B9D"), PARAMETER_NAME));
        }

        #endregion

        #region IsNotEmpty<string>

        [Test]
        public void IsNotEmptyOfString_When_Argument_Is_Empty_String_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotEmpty(string.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty.", ex.Message);
        }

        [Test]
        public void IsNotEmptyOfString_When_Argument_Is_Not_Empty_String_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotEmpty("foo", PARAMETER_NAME));
        }

        [Test]
        public void IsNotEmptyOfString_When_Argument_Is_Null_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotEmpty(null, PARAMETER_NAME));
        }

        #endregion

        #region IsNotInFuture

        [Test]
        public void IsNotInFuture_When_Argument_Exceeds_Current_DateTime_Should_Throw_ArgumentException()
        {
            _timeProvider.Setup(s => s.Now).Returns(() => _currentDate);

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsNotInFuture(_currentDate.AddTicks(1), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be in the future.", ex.Message);
        }

        [Test]
        public void IsNotInFuture_When_Argument_Is_Current_DateTime_Should_Not_Throw()
        {
            _timeProvider.Setup(s => s.Now).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => Invariant.IsNotInFuture(_currentDate, PARAMETER_NAME));
        }

        [Test]
        public void IsNotInFuture_When_Argument_Is_Earlier_Than_Current_DateTime_Should_Not_Throw()
        {
            _timeProvider.Setup(s => s.Now).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => Invariant.IsNotInFuture(_currentDate.AddTicks(-1), PARAMETER_NAME));
        }

        #endregion

        #region IsNotInFutureUtc

        [Test]
        public void IsNotInFutureUtc_When_Argument_Exceeds_Current_DateTime_Should_Throw_ArgumentException()
        {
            _timeProvider.Setup(s => s.UtcNow).Returns(() => _currentDate);

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsNotInFutureUtc(_currentDate.AddTicks(1), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be in the future.", ex.Message);
        }

        [Test]
        public void IsNotInFutureUtc_When_Argument_Is_Current_DateTime_Should_Not_Throw()
        {
            _timeProvider.Setup(s => s.UtcNow).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => Invariant.IsNotInFutureUtc(_currentDate, PARAMETER_NAME));
        }

        [Test]
        public void IsNotInFutureUtc_When_Argument_Is_Earlier_Than_Current_DateTime_Should_Not_Throw()
        {
            _timeProvider.Setup(s => s.UtcNow).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => Invariant.IsNotInFutureUtc(_currentDate.AddTicks(-1), PARAMETER_NAME));
        }

        #endregion

        #region IsNotInPast

        [Test]
        public void IsNotInPast_When_Argument_Is_Earlier_Then_Current_DateTime_Should_Throw_ArgumentException()
        {
            _timeProvider.Setup(s => s.Now).Returns(() => _currentDate);

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsNotInPast(_currentDate.AddTicks(-1), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be in the past.", ex.Message);
        }

        [Test]
        public void IsNotInPast_When_Argument_Is_Current_DateTime_Should_Not_Throw()
        {
            _timeProvider.Setup(s => s.Now).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => Invariant.IsNotInPast(_currentDate, PARAMETER_NAME));
        }

        [Test]
        public void IsNotInPast_When_Argument_Exceeds_Current_DateTime_Should_Not_Throw()
        {
            _timeProvider.Setup(s => s.Now).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => Invariant.IsNotInPast(_currentDate.AddTicks(1), PARAMETER_NAME));
        }

        #endregion

        #region IsNotInPastUtc

        [Test]
        public void IsNotInPastUtc_When_Argument_Is_Earlier_Then_Current_DateTime_Should_Throw_ArgumentException()
        {
            _timeProvider.Setup(s => s.UtcNow).Returns(() => _currentDate);

            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsNotInPastUtc(_currentDate.AddTicks(-1), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be in the past.", ex.Message);
        }

        [Test]
        public void IsNotInPastUtc_When_Argument_Is_Current_DateTime_Should_Not_Throw()
        {
            _timeProvider.Setup(s => s.UtcNow).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => Invariant.IsNotInPastUtc(_currentDate, PARAMETER_NAME));
        }

        [Test]
        public void IsNotInPastUtc_When_Argument_Exceeds_Current_DateTime_Should_Not_Throw()
        {
            _timeProvider.Setup(s => s.UtcNow).Returns(() => _currentDate);

            Assert.DoesNotThrow(() => Invariant.IsNotInPastUtc(_currentDate.AddTicks(1), PARAMETER_NAME));
        }

        #endregion

        #region IsNotNegative<int>

        [Test]
        public void IsNotNegativeOfInt_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegative(0, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfInt_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegative(-1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegative<long>

        [Test]
        public void IsNotNegativeOfLong_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegative((long) 0, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfLong_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegative((long) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegative<float>

        [Test]
        public void IsNotNegativeOfFloat_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegative((float) 0, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfFloat_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegative((float) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegative<decimal>

        [Test]
        public void IsNotNegativeOfDecimal_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegative((decimal) 0, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfDecimal_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegative((decimal) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegative<TimeSpan>

        [Test]
        public void IsNotNegativeOfTimeSpan_When_Argument_Is_Zero_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegative(TimeSpan.Zero, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOfTimeSpan_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsNotNegative(TimeSpan.FromTicks(1).Negate(), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<int>

        [Test]
        public void IsNotNegativeOrZeroOfInt_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegativeOrZero(1, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfInt_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegativeOrZero(0, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfInt_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegativeOrZero(-1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<long>

        [Test]
        public void IsNotNegativeOrZeroOfLong_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegativeOrZero((long) 1, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfLong_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegativeOrZero((long) 0, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfLong_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegativeOrZero((long) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<float>

        [Test]
        public void IsNotNegativeOrZeroOfFloat_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegativeOrZero((float) 1, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfFloat_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegativeOrZero((float) 0, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfFloat_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegativeOrZero((float) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<decimal>

        [Test]
        public void IsNotNegativeOrZeroOfDecimal_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegativeOrZero((decimal) 1, PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfDecimal_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegativeOrZero((decimal) 0, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfDecimal_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegativeOrZero((decimal) -1, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNegativeOrZero<TimeSpan>

        [Test]
        public void IsNotNegativeOrZeroOfTimeSpan_When_Argument_Is_One_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNegativeOrZero(TimeSpan.FromTicks(1), PARAMETER_NAME));
        }

        [Test]
        public void IsNotNegativeOrZeroOfTimeSpan_When_Argument_Is_Zero_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNegativeOrZero(TimeSpan.Zero, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        [Test]
        public void IsNotNegativeOrZeroOfTimeSpan_When_Argument_Is_Negative_One_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsNotNegativeOrZero(TimeSpan.FromTicks(1).Negate(), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not have a negative or zero value.", ex.Message);
        }

        #endregion

        #region IsNotNull<object>

        [Test]
        public void IsNotNullOfObject_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Invariant.IsNotNull((object) null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOfObject_When_Argument_Is_Not_Null_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNull(new Object(), PARAMETER_NAME));
        }

        #endregion

        #region IsNotNull<T>

        [Test]
        public void IsNotNullOfT_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Invariant.IsNotNull((string) null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOfT_When_Argument_Is_Not_Null_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNull(string.Empty, PARAMETER_NAME));
        }

        #endregion

        #region IsNotNullOrEmpty<string>

        [Test]
        public void IsNotNullOrEmptyOfString_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => Invariant.IsNotNullOrEmpty((string) null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOrEmptyOfString_When_Argument_Is_Empty_String_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNullOrEmpty(string.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be an empty string.", ex.Message);
        }

        [Test]
        public void IsNotNullOrEmptyOfString_When_Argument_Is_Whitespace_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNullOrEmpty(" ", PARAMETER_NAME));
        }

        [Test]
        public void IsNotNullOrEmptyOfString_When_Argument_Is_Not_Null_Or_Empty_Or_Whitespace_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNullOrEmpty("foo", PARAMETER_NAME));
        }

        #endregion

        #region IsNotNullOrEmpty<IEnumerable<T>>

        [Test]
        public void IsNotNullOrEmptyOfIEnumerable_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => Invariant.IsNotNullOrEmpty((IEnumerable<int>) null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOrEmptyOfIEnumerable_When_Argument_Is_Empty_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsNotNullOrEmpty(Enumerable.Empty<int>(), PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty.", ex.Message);
        }

        [Test]
        public void IsNotNullOrEmptyOfIEnumerable_When_Argument_Is_Not_Empty_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotNullOrEmpty(new List<int> { 1 }, PARAMETER_NAME));
        }

        #endregion

        #region IsNotNullOrWhitespace

        [Test]
        public void IsNotNullOrWhitespace_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Invariant.IsNotNullOrWhitespace(null, PARAMETER_NAME));

            Assert.AreEqual(PARAMETER_NAME, ex.ParamName);
        }

        [Test]
        public void IsNotNullOrWhitespace_When_Argument_Is_Empty_String_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Invariant.IsNotNullOrWhitespace(string.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty or whitespace.", ex.Message);
        }

        [Test]
        public void IsNotNullOrWhitespace_When_Argument_Is_Whitespace_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotNullOrWhitespace(" ", PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty or whitespace.", ex.Message);
        }

        #endregion

        #region IsNotWhitespace

        [Test]
        public void IsNotWhitespace_When_Argument_Is_Null_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsNotWhitespace(null, PARAMETER_NAME));
        }

        [Test]
        public void IsNotWhitespace_When_Argument_Is_Empty_String_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotWhitespace(string.Empty, PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty or whitespace.", ex.Message);
        }

        [Test]
        public void IsNotWhitespace_When_Argument_Is_Whitespace_Should_Throw_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Invariant.IsNotWhitespace(" ", PARAMETER_NAME));

            Assert.AreEqual($"{PARAMETER_NAME} must not be empty or whitespace.", ex.Message);
        }

        #endregion

        #region IsValidModel

        [Test]
        public void IsValidModel_When_Argument_Is_Null_Should_Throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Invariant.IsValidModel<object>(null));
        }

        [Test]
        public void IsValidModel_When_Argument_Is_Not_Valid_Should_Throw_ValidationException()
        {
            Assert.Throws<ValidationException>(() => Invariant.IsValidModel(new TestModel()));
        }

        [Test]
        public void IsValidModel_When_Model_Is_Valid_Should_Not_Throw()
        {
            Assert.DoesNotThrow(() => Invariant.IsValidModel(new TestModel { RequiredProperty = 1 }));
        }

        #endregion

        #region IsValidProperty

        [Test]
        public void IsValidProperty_When_Property_Is_Null_Should_Throw_ValidationException()
        {
            var model = new TestModel();
            Assert.Throws<ValidationException>(
                () => Invariant.IsValidProperty(model, model.RequiredProperty, nameof(model.RequiredProperty)));
        }

        [Test]
        public void IsValidProperty_When_Property_Is_Invalid_Should_Throw_ValidationException()
        {
            var model = new TestModel { RequiredProperty = 2 };
            Assert.Throws<ValidationException>(
                () => Invariant.IsValidProperty(model, model.RequiredProperty, nameof(model.RequiredProperty)));
        }

        #endregion

        #region MatchesRegex

        [Test]
        public void MatchesRegex_When_Argument_Is_Null_Should_Throw_NullReferenceException()
        {
            Assert.Throws<ArgumentNullException>(() => Invariant.MatchesRegex(null, @"\s+", PARAMETER_NAME));
        }

        [Test]
        public void MatchesRegex_When_Argument_Does_Not_Match_Should_Throw()
        {
            var expression = @"\s+";
            var ex = Assert.Throws<ArgumentException>(() => Invariant.MatchesRegex("a", expression, PARAMETER_NAME));
            Assert.AreEqual($"{PARAMETER_NAME} must match regular expression {expression}.", ex.Message);
        }

        [Test]
        public void MatchesRegex_When_Argument_Matches_Should_Not_Throw()
        {
            var expression = @"\s+";
            Assert.DoesNotThrow(() => Invariant.MatchesRegex(" ", expression, PARAMETER_NAME));
        }

        #endregion
    }
}
