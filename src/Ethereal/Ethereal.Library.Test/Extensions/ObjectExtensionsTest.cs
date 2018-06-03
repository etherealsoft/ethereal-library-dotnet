using NUnit.Framework;

namespace Ethereal.Library.Extensions.Test
{
    [TestFixture]
    public class ObjectExtensionsTest
    {
        #region AsDictionary

        [Test]
        public void AsDictionary_Should_Convert_Object_To_Dictionary()
        {
            var input = new {
                Foo = "foo",
                Bar = 1
            };

            var actual = input.AsDictionary();

            object value1, value2;
            actual.TryGetValue("Foo", out value1);
            actual.TryGetValue("Bar", out value2);

            Assert.AreEqual(input.Foo, value1);
            Assert.AreEqual(input.Bar, value2);
        }

        #endregion
    }
}
