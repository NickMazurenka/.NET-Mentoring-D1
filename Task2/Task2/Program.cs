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

			// Reverse alternative:
			//foreach (var item in test.Reverse())
			//{
			//	Console.WriteLine(item);
			//}
		}
	}
}
