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
        public void Shrink_Should_Base64_Encode_Guid()
        {
            var guid = new Guid("9CF256CB-F640-4995-ACE5-D4CB09C67036");
            var expected = "y1bynED2lUms5dTLCcZwNg";

            Assert.AreEqual(expected, guid.Shrink());
        }

        #endregion
    }
}
