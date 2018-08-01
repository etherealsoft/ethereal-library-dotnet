using System;
using NUnit.Framework;

namespace Ethereal.Library.Extensions.Test
{
    [TestFixture]
    public class GuidExtensionsTest
    {
        #region IsEmpty

        [Test]
        public void IsEmpty_When_Guid_Is_Empty_Should_Return_True()
        {
            Assert.IsTrue(Guid.Empty.IsEmpty());
        }

        [Test]
        public void IsEmpty_When_Guid_Is_Not_Empty_Should_Return_False()
        {
            Assert.IsFalse((new Guid("60F9C45F-D482-4820-8E6A-EFD9D231A30A")).IsEmpty());
        }

        #endregion

        #region Shrink

        [Test]
        public void Shrink_When_Is_Empty_Should_Throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Guid.Empty.Shrink());
        }

        [Test]
        public void Shrink_Should_Base64_Encode_Guid()
        {
            var guid = new Guid("9CF256CB-F640-4995-ACE5-D4CB09C67036");
            var expected = "y1bynED2lUms5dTLCcZwNg";

            Assert.AreEqual(expected, guid.Shrink());
        }

        #endregion

        #region ExpandGuid

        [Test]
        public void ExpandGuid_When_String_Is_Null_Should_Throw_ArgumentNullException()
        {
            string target = null;

            Assert.Throws<ArgumentNullException>(() => target.ExpandGuid());
        }

        [Test]
        public void ExpandGuid_When_String_Is_Shrunk_Guid_Should_Return_Expanded_Guid_From_Shrunk_Guid()
        {
            var expected = new Guid("E6F36EB3-5774-4CF5-BAA4-7883B519CDE5");
            var target = expected.Shrink();

            var actual = target.ExpandGuid();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpandGuid_When_String_Is_Not_Shrunk_Guid_Should_Return_Empty_Guid()
        {
            var target = "Foo";

            var actual = target.ExpandGuid();

            Assert.AreEqual(Guid.Empty, actual);
        }

        #endregion
    }
}
