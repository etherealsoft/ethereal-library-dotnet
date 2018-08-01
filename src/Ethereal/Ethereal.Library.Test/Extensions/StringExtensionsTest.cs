using System;
using System.Web;
using NUnit.Framework;

namespace Ethereal.Library.Extensions.Test
{
    [TestFixture]
    public class StringExtensionsTest
    {
        #region AttributeEncode

        [Test]
        public void AttributeEncode_When_Null_Should_Throw_ArgumentNullException()
        {
            string target = null;

            Assert.Throws<ArgumentNullException>(() => target.AttributeEncode());
        }

        [Test]
        public void AttributeEncode_Should_Encode_Correctly()
        {
            var target = "<&\"";
            var expected = HttpUtility.HtmlAttributeEncode(target);

            var actual = target.AttributeEncode();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region HtmlDecode

        [Test]
        public void HtmlDecode_When_Null_Should_Throw_ArgumentNullException()
        {
            string target = null;

            Assert.Throws<ArgumentNullException>(() => target.HtmlDecode());
        }

        [Test]
        public void HtmlDecode_Should_Decode_Correctly()
        {
            var target = "&#x3C;&#x3E;&#x26;&#x22";
            var expected = HttpUtility.HtmlDecode(target);

            var actual = target.HtmlDecode();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region HtmlEncode

        [Test]
        public void HtmlEncode_When_Null_Should_Throw_ArgumentNullException()
        {
            string target = null;

            Assert.Throws<ArgumentNullException>(() => target.HtmlEncode());
        }

        [Test]
        public void HtmlEncode_Should_Encode_Correctly()
        {
            var target = "<>&\"";
            var expected = HttpUtility.HtmlEncode(target);

            var actual = target.HtmlEncode();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ToEnum

        [Test]
        public void ToEnum_When_Null_Should_Throw_ArgumentNullException()
        {
            string target = null;

            Assert.Throws<ArgumentNullException>(() => target.ToEnum<TestEnum>());
        }

        [Test]
        public void ToEnum_When_Match_Returns_Match()
        {
            var target = "Foo";
            var expected = TestEnum.Foo;

            var actual = target.ToEnum<TestEnum>();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToEnum_When_Match_Not_Found_Returns_Default()
        {
            var target = "Bar";
            var expected = TestEnum.Unknown;

            var actual = target.ToEnum<TestEnum>();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region UrlDecode

        [Test]
        public void UrlDecode_When_Null_Should_Throw_ArgumentNullException()
        {
            string target = null;

            Assert.Throws<ArgumentNullException>(() => target.UrlDecode());
        }

        [Test]
        public void UrlDecode_Should_Decode_Correctly()
        {
            var target = "%23%24%25%26%20";
            var expected = HttpUtility.UrlDecode(target);

            var actual = target.UrlDecode();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region UrlEncode

        [Test]
        public void UrlEncode_When_Null_Should_Throw_ArgumentNullException()
        {
            string target = null;

            Assert.Throws<ArgumentNullException>(() => target.UrlEncode());
        }

        [Test]
        public void UrlEncode_Should_Encode_Correctly()
        {
            var target = "#$%& ";
            var expected = HttpUtility.UrlEncode(target);

            var actual = target.UrlEncode();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        private enum TestEnum
        {
            Unknown,
            Foo
        }
    }
}
