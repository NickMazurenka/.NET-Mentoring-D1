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
            Assert.AreEqual(r, int.Parse(s));
        }
    }
}