using System.Collections;
using System.Collections.Generic;

namespace Task2
{
	public class Iterator<T> : IEnumerable
	{
		private readonly List<T> _items = new List<T>();

		public void Add(T item)
		{
			_items.Add(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < _items.Count; i++)
			{
				yield return _items[i];
			}
		}
	}
}
