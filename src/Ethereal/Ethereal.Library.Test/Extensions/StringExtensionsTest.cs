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
        public void AttributeEncode_Should_Encode_Correctly()
        {
            var input = "<&\"";
            var expected = HttpUtility.HtmlAttributeEncode(input);

            var actual = input.AttributeEncode();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region HtmlDecode

        [Test]
        public void HtmlDecode_Should_Decode_Correctly()
        {
            var input = "&#x3C;&#x3E;&#x26;&#x22";
            var expected = HttpUtility.HtmlDecode(input);

            var actual = input.HtmlDecode();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region HtmlEncode

        [Test]
        public void HtmlEncode_Should_Encode_Correctly()
        {
            var input = "<>&\"";
            var expected = HttpUtility.HtmlEncode(input);

            var actual = input.HtmlEncode();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ToEnum

        [Test]
        public void ToEnum_When_Match_Returns_Match()
        {
            var input = "Foo";
            var expected = TestEnum.Foo;

            var actual = input.ToEnum(TestEnum.Unknown);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToEnum_When_Match_Not_Found_Returns_Default()
        {
            var input = "Bar";
            var expected = TestEnum.Unknown;

            var actual = input.ToEnum(expected);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ToGuid

        [Test]
        public void ToGuid_When_String_Is_Shrunk_Guid_Should_Return_Expanded_Guid_From_Shrunk_Guid()
        {
            var expected = new Guid("E6F36EB3-5774-4CF5-BAA4-7883B519CDE5");
            var input = expected.Shrink();

            var actual = input.ToGuid();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToGuid_When_String_Is_Not_Shrunk_Guid_Should_Return_Empty_Guid()
        {
            var input = "Foo";

            var actual = input.ToGuid();

            Assert.AreEqual(Guid.Empty, actual);
        }

        #endregion

        #region UrlDecode

        [Test]
        public void UrlDecode_Should_Decode_Correctly()
        {
            var input = "%23%24%25%26%20";
            var expected = HttpUtility.UrlDecode(input);

            var actual = input.UrlDecode();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region UrlEncode

        [Test]
        public void UrlEncode_Should_Encode_Correctly()
        {
            var input = "#$%& ";
            var expected = HttpUtility.UrlEncode(input);

            var actual = input.UrlEncode();

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
