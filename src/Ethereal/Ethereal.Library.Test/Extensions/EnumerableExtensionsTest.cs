using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Ethereal.Library.Extensions.Test
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        #region ForEach<T>

        [Test]
        public void ForEach_Should_Call_Action_On_Each_Enumerable_Element()
        {
            var expected = new List<int> { 1, 2 };
            var actual = new List<int>();

            expected.ForEach(item => actual.Add(item));

            Assert.AreEqual(expected[0], actual.ElementAtOrDefault(0));
            Assert.AreEqual(expected[1], actual.ElementAtOrDefault(1));
        }

        #endregion
    }
}
