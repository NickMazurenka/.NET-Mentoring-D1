using System;

namespace Task2
{
	class Program
	{
		static void Main()
		{
			var test = new IterableCollection<string>();
			test.Add("test1");
			test.Add("test2");
			test.Add("???");

			Console.WriteLine("Default order");
			foreach (var item in test)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("Reverse order");
			foreach (var item in test.GetReverseIterator())
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("Custom search");
			foreach (var item in test.Search(CustomSearchMethod))
			{
				Console.WriteLine(item);
			}

		}

		private static bool CustomSearchMethod(string s)
		{
			return s.Contains("test");
		}
	}
}
