using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
	public class IterableCollection<T> : IEnumerable<T>
	{
		private readonly List<T> _items = new List<T>();

		public void Add(T item)
		{
			_items.Add(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < _items.Count; i++)
			{
				yield return _items[i];
			}
		}

		public IEnumerable<T> GetReverseIterator()
		{
			for (int i = _items.Count - 1; i >= 0; i--)
			{
				yield return _items[i];
			}
		}

		public IEnumerable<T> Search(Predicate<T> match)
		{
			for (int i = 0; i < _items.Count; i++)
			{
				if (match(_items[i]))
					yield return _items[i];
			}

			// Alternative:
			//return _items.Where(t => match(t));
		}

	}
}
