using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
	[TestClass]
	public class PersonClassTests
	{
		// Equals

		[TestMethod]
		public void Equals_FieldsEqual_ReturnsTrue()
		{
			// Arrange
			var p1 = new PersonClass
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
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Equals_FirstNameNotEqual_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
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
		public void Equals_LastNameNotEqual_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
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
		public void Equals_AllNamesNotEqual_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
			{
				FirstName = "Kimm",
				LastName = "Kuann"
			};

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Equals_EmptyPersons_ReturnsTrue()
		{
			// Arrange
			var p1 = new PersonClass();
			var p2 = new PersonClass();

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Equals_SecondPersonEmpty_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass();

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Equals_SecondPersonIsNull_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			PersonClass p2 = null;

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Equals_SecondPersonHasIncompatibleType_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonClass
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
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Equals_SecondPersonFirstNameNull_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
			{
				LastName = "Kuan"
			};

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Equals_SecondPersonLastNameNull_ReturnsFalse()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
			{
				FirstName = "Kim"
			};

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Equals_PersonsLastNamesNull_ReturnsTrue()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
			};
			var p2 = new PersonClass
			{
				FirstName = "Kim"
			};

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Equals_PersonsFirstNamesNull_ReturnsTrue()
		{
			// Arrange
			var p1 = new PersonClass
			{
				LastName = "Kuan"
			};
			var p2 = new PersonClass
			{
				LastName = "Kuan"
			};

			// Act
			var result = p1.Equals(p2);

			// Assert
			Assert.IsTrue(result);
		}

		// GetHashCode

		[TestMethod]
		public void GetHashCode_AllFieldsEqual_Equal()
		{
			// Arrange
			var p1 = new PersonClass
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
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreEqual(hash1, hash2);
		}

		[TestMethod]
		public void GetHashCode_FirstNameNotEqual_NotEqual()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
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
		public void GetHashCode_LastNameNotEqual_NotEqual()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
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

		[TestMethod]
		public void GetHashCode_AllFieldsNotEqual_NotEqual()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
			{
				FirstName = "Kimm",
				LastName = "Kuann"
			};

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreNotEqual(hash1, hash2);
		}

		[TestMethod]
		public void GetHashCode_EmptyPersons_Equal()
		{
			// Arrange
			var p1 = new PersonClass();
			var p2 = new PersonClass();

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreEqual(hash1, hash2);
		}

		[TestMethod]
		public void GetHashCode_SecondPersonsIsEmpty_NotEqual()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass();

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreNotEqual(hash1, hash2);
		}

		[TestMethod]
		public void GetHashCode_SecondPersonFirstNameNull_NotEqual()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
			{
				LastName = "Kuan"
			};

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreNotEqual(hash1, hash2);
		}

		[TestMethod]
		public void GetHashCode_SecondPersonLastNameNull_NotEqual()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
				LastName = "Kuan"
			};
			var p2 = new PersonClass
			{
				FirstName = "Kim"
			};

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreNotEqual(hash1, hash2);
		}

		[TestMethod]
		public void GetHashCode_PersonsLastNamesNull_Equal()
		{
			// Arrange
			var p1 = new PersonClass
			{
				FirstName = "Kim",
			};
			var p2 = new PersonClass
			{
				FirstName = "Kim"
			};

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreEqual(hash1, hash2);
		}

		[TestMethod]
		public void GetHashCode_PersonsFirstNamesNull_Equal()
		{
			// Arrange
			var p1 = new PersonClass
			{
				LastName = "Kuan"
			};
			var p2 = new PersonClass
			{
				LastName = "Kuan"
			};

			// Act
			var hash1 = p1.GetHashCode();
			var hash2 = p2.GetHashCode();

			// Assert
			Assert.AreEqual(hash1, hash2);
		}
	}
}
