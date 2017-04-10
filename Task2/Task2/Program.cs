using System;

namespace Task2
{
	class Program
	{
		static void Main()
		{
			var test = new Iterator<string>();
			test.Add("test1");
			test.Add("test2");

			foreach (var item in test)
			{
				Console.WriteLine(item);
			}
		}
	}
}
