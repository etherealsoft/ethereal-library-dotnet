using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Ethereal.Library.Test
{
    [TestFixture]
    public class InvariantTest
    {
        private const string PARAMETER_NAME = "foo";

        private Invariant _target;

        [SetUp]
        public void Setup()
        {
            _target = new Invariant();
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
    }
}
