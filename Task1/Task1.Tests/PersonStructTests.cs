using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
	[TestClass]
	public class PersonStructTests
	{
		// Equals

		[TestMethod]
		public void Equals_FieldsEqual_ReturnsTrue()
		{
			// Arrange
			var p1 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Equals_FirstNamesNotEqual_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonStruct
			{
				FirstName = "Kimm",
				LastName = "Kuan"
			};

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Equals_LastNamesNotEqual_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuann"
			};

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
 		public void Equals_SecondPersonHasIncompatibleType_ReturnsFalse()
 		{
 			// Arrange
 			var p1 = new PersonStruct
			{
 				FirstName = "Kim",
 				LastName = "Kuan"
 			};
 			var p2 = new PersonClass
			{
 				FirstName = "Kim",
 				LastName = "Kuan"
 			};
 
 			// Act
 			var result = p1.Equals(p2);
 
 			// Assert
 			Assert.IsFalse(result);
 		}

		[TestMethod]
		public void Equals_SecondPersonIsNull_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};

			// Act
			var result = p1.Equals(null);

			// Assert
			Assert.IsFalse(result);
		}

		// GetHashCode

		// Unit tests according to Jon Skeet:
		// http://stackoverflow.com/questions/1696881/c-how-would-you-unit-test-gethashcode

		[TestMethod]
		public void GetHashCode_AllFieldsEqual_Equal()
		{
			// Arrange
			var p1 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreEqual(hash1, hash2);
		}

		[TestMethod]
		public void GetHashCode_FirstNamesNotEqual_NotEqual()
		{
			// Arrange
			var p1 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonStruct
			{
				FirstName = "Kimm",
				LastName = "Kuan"
			};

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreNotEqual(hash1, hash2);
		}

		[TestMethod]
		public void GetHashCode_LastNamesNotEqual_NotEqual()
		{
			// Arrange
			var p1 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonStruct
			{
				FirstName = "Kim",
				LastName = "Kuann"
			};

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreNotEqual(hash1, hash2);
		}
	}
}
