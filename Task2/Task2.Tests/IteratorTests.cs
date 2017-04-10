using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
	[TestClass]
	public class IteratorTests
	{
		[TestMethod]
		public void Add_ReferenceType_ItemAdded()
		{
			// Arrange
			var iterator = new Iterator<Person>();
			var item = new Person();
			Person result;

			// Act
			iterator.Add(item);
			using (var enumerator = iterator.GetEnumerator())
			{
				enumerator.MoveNext();
				result = enumerator.Current;
			}

			// Assert
			Assert.AreSame(item, result);
		}

		[TestMethod]
		public void GetEnumerator_SimpleClass_EnumeratorNotNull()
		{
			// Arrange
			var iterator = new Iterator<Person>();

			// Act
			var enumerator = iterator.GetEnumerator();

			// Assert
			Assert.IsNotNull(enumerator);
		}

		[TestMethod]
		public void GetReverseEnumerator_SimpleClass_EnumeratorNotNull()
		{
			// Arrange
			var iterator = new Iterator<Person>();

			// Act
			var enumerator = iterator.GetReverseEnumerator();

			// Assert
			Assert.IsNotNull(enumerator);
		}
	}
}