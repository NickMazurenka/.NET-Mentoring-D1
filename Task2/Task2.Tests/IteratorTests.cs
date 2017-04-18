using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
	[TestClass]
	public class IteratableCollectionTests
	{
		[TestMethod]
		public void Add_ReferenceType_ItemAdded()
		{
			// Arrange
			var iterator = new IterableCollection<Person>();
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
			var iterator = new IterableCollection<Person>();

			// Act
			var enumerator = iterator.GetEnumerator();

			// Assert
			Assert.IsNotNull(enumerator);
		}

		[TestMethod]
		public void GetReverseEnumerator_SimpleClass_EnumeratorNotNull()
		{
			// Arrange
			var iterator = new IterableCollection<Person>();

			// Act
			var enumerator = iterator.GetReverseIterator();

			// Assert
			Assert.IsNotNull(enumerator);
		}

		[TestMethod]
		public void Search_SimpleClassSimpleDelegate_EnumeratorNotNull()
		{
			// Arrange
			var iterator = new IterableCollection<Person>();

			// Act
			var enumerator = iterator.Search(person => false);

			// Assert
			Assert.IsNotNull(enumerator);
		}
	}
}