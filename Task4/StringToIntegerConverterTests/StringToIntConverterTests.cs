using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringToIntegerConverter;

namespace StringToIntegerConverterTests
{
    [TestClass]
    public class StringToIntConverterTests
    {
        [TestMethod]
        public void Convert_FiveDigitInt_Converted()
        {
            // Arrange
            var s = "12345";

            // Act
            var r = StringToIntConverter.Convert(s);

            // Assert
            Assert.AreEqual(r, 12345);
        }

        [TestMethod]
        public void Convert_PositiveInt_Converted()
        {
            // Arrange
            var s = "+2147483647";

            // Act
            var r = StringToIntConverter.Convert(s);

            // Assert
            Assert.AreEqual(r, 2147483647);
        }

        [TestMethod]
        public void Convert_NegativeInt_Converted()
        {
            // Arrange
            var s = "-2147483648";

            // Act
            var r = StringToIntConverter.Convert(s);

            // Assert
            Assert.AreEqual(r, -2147483648);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_Null_ArgumentException()
        {
            // Arrange
            string s = null;

            // Act
            var r = StringToIntConverter.Convert(s);

            // Assert exception is thrown
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Convert_InvalidFormat_FormatException()
        {
            // Arrange
            string s = "-456wat";

            // Act
            var r = StringToIntConverter.Convert(s);

            // Assert exception is thrown
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Convert_TooBigInt_OverflowException()
        {
            // Arrange
            string s = "2147483648";

            // Act
            var r = StringToIntConverter.Convert(s);

            // Assert exception is thrown
        }
    }
}