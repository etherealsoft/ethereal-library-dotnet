using System.Collections.Generic;
using NUnit.Framework;

namespace Ethereal.Library.Extensions.Test
{
    [TestFixture]
    public class CollectionExtensionsTest
    {
        #region IsNullOrEmpty<T>

        [Test]
        public void IsNullOrEmptyOfT_When_Self_Is_Null_Returns_True()
        {
            List<int> target = null;

            Assert.IsTrue(target.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmptyOfT_When_Self_Is_Empty_Returns_True()
        {
            var target = new List<int>();

            Assert.IsTrue(target.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmptyOfT_When_Self_Is_Not_Empty_Returns_False()
        {
            var target = new List<int> { 1 };

            Assert.IsFalse(target.IsNullOrEmpty());
        }

        #endregion
    }
}
