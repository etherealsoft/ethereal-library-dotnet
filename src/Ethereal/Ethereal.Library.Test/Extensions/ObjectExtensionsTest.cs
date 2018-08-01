using System;
using NUnit.Framework;

namespace Ethereal.Library.Extensions.Test
{
    [TestFixture]
    public class ObjectExtensionsTest
    {
        #region AsDictionary

        [Test]
        public void AsDictionary_When_Null_Should_Throw_ArgumentNullException()
        {
            object target = null;

            Assert.Throws<ArgumentNullException>(() => target.AsDictionary());
        }

        [Test]
        public void AsDictionary_Should_Convert_Object_To_Dictionary()
        {
            var target = new {
                Foo = "foo",
                Bar = 1
            };

            var actual = target.AsDictionary();

            object value1, value2;
            actual.TryGetValue("Foo", out value1);
            actual.TryGetValue("Bar", out value2);

            Assert.AreEqual(target.Foo, value1);
            Assert.AreEqual(target.Bar, value2);
        }

        #endregion
    }
}
